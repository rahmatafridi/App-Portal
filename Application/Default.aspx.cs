using DSP.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class root_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DSP.BAL.Applicant.UnableNewApplication(Membership.GetUser().UserName))
        {
            pnl_startapp.Visible = false;
            btnStart.Enabled = false;
        }

        lbl_UserId.Text = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName).ToString();

    }
    protected void btnStart_Click(object sender, EventArgs e)
    {
        Page.Session["CurrentApplication"] = null;


        ApplicationForm myApp = new ApplicationForm(true);

        myApp._app_Email = Membership.GetUser().UserName;


        myApp._app_AdvisorUserId = getLearnerAdvisorId(Membership.GetUser().UserName);
        myApp._app_officeuse1_CourseId = getLearnerCourseId(Membership.GetUser().UserName);
        myApp._app_officeuse1_CourseLevel = myApp.GetCourseLevelForCourseId(myApp._app_officeuse1_CourseId);

        int courseLevel_Id = myApp._app_officeuse1_CourseLevel;

        myApp.SaveApplicationCourseLevelAndAdvisor();

        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null;

        if (courseLevel_Id == 80)
        {
            Server.Transfer("Progress_SC.aspx");
        }
        else if(courseLevel_Id == 102)
        {
            Server.Transfer("Progress_ESF.aspx");
        }
        else
        {
            Server.Transfer("Progress.aspx");
        }

    }


    protected int getLearnerCourseId(string sUsername)
    {
        string sSQL = "SELECT isNull(Users_Id_Course,0) as Users_Id_Course FROM Users WHERE Users_Username = '" + DSP.BAL.Basic.FormatStringForSQL(sUsername) + "' AND Users_IsActivated = 1 AND Users_IsActive= 1; ";
        DataSet dsUser = null;
        dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
        }
        else { 

            int iCourseId = (dsUser.Tables[0].Rows[0]["Users_Id_Course"] != null ? int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_Course"].ToString()) : 0) ;
            if (iCourseId != 0)
            {
                //found one
            }
            else{
                iCourseId = 45;
                //update this learner user name with the new course assigned 
                DSP.DAL.SQL.ExecuteScalar(String.Format("update Users SET Users_Id_Course = {0} WHERE Users_Username = '{1}'", iCourseId, DSP.BAL.Basic.FormatStringForSQL(sUsername))) ;

            }
            return iCourseId;
        }

        return 0;
    }
    protected int getLearnerAdvisorId(string sUsername)
    {
        string sSQL = "SELECT isNull(API_EnteredByUserId,0) as API_EnteredByUserId FROM [AppPortal_Invites] WHERE API_Email = '" + DSP.BAL.Basic.FormatStringForSQL(sUsername) + "'";
        DataSet dsUser = null;
        dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
        }
        else
        {

            int API_EnteredByUserId = (dsUser.Tables[0].Rows[0]["API_EnteredByUserId"] != null ? int.Parse(dsUser.Tables[0].Rows[0]["API_EnteredByUserId"].ToString()) : 0);
            if (API_EnteredByUserId != 0)
            {
                //found one
            }
            //else
            //{
            //    iCourseId = 45;
            //    //update this learner user name with the new course assigned 
            //    DSP.DAL.SQL.ExecuteScalar(String.Format("update Users SET Users_Id_Course = {0} WHERE Users_Username = '{1}'", iCourseId, DSP.BAL.Basic.FormatStringForSQL(sUsername)));

            //}
            return API_EnteredByUserId;
        }

        return 0;
    }
    #region "grid"

    protected void grid_userapplications_OnRowDataBound(object sender, EventArgs e)
    {
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

            if (lblSubmitted.Text == "Yes")
            {
                imbtn.Visible = false;
            }

        }

    }


    public void btn_Edit_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;


        Page.Session["CurrentApplication"] = null;
        ApplicationForm myApp = new ApplicationForm();
        myApp = myApp.GetApplication(int.Parse(sAppId));
        myApp._app_Email = Membership.GetUser().UserName;

        int courseLevel_Id = myApp._app_officeuse1_CourseLevel;

        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null;

        if (courseLevel_Id == 80)
        {
            Server.Transfer("Progress_SC.aspx");
        }
        else if(courseLevel_Id == 102)
        {
            Server.Transfer("Progress_ESF.aspx");
        }
        else
        {
            Server.Transfer("Progress.aspx");
        }

    }

    #endregion




    protected void btnLogout_Click(object sender, EventArgs e)
    {

        System.Web.UI.Control lw = (System.Web.UI.Control)this.Master.FindControl("loggedinfo");
        if (lw != null)
        { lw.Visible = false; }


        Response.Redirect("~/Portal/Logout.aspx");


    }





}
