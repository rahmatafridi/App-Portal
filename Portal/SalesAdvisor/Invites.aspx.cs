using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Portal_Admin_Invites : System.Web.UI.Page
{
    UtilityFunctions utils = new UtilityFunctions();

    private string strPath;
    private string strDate;
    private string strTheFile;
    private string strLearnerRef;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddl_Courses.DataBind();
            ListItem li = new ListItem();
            li.Text = "Any";
            li.Value = "-1";
            li.Selected = true;
            ddl_Courses.Items.Add(li);
            ddl_Courses.SelectedIndex = ddl_Courses.Items.Count - 1;

            if (Roles.IsUserInRole(Membership.GetUser().UserName, "Admin") == true)
            {

            }
            else if (Roles.IsUserInRole(Membership.GetUser().UserName, "SalesAdvisor") == true)
            {
                txtUserId.Text = DSP.BAL.Session.GetSessionUserId();
            }
        }
    }

    private string getLearnerRef()
    {
        GridViewRow r1 = ListAllLearners.SelectedRow;

        if (r1 == null)
        {
            return "ERROR";
        }
        else
        {
            return r1.Cells[2].Text;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string strRedirect = "~/Portal/SalesAdvisor/Invites.aspx";

        Response.Redirect(strRedirect);

    }
    protected void DeselectTheRow(object sender, EventArgs e)
    {
        ListAllLearners.SelectedIndex = -1;
    }

    protected int iColId = 0; //first item is the id
    protected string getLearnerStatus(object learnerid)
    {
        string strId = learnerid.ToString();
        string strReturn = "";
        if (strId != "")
        {
            strReturn = "<span style=\"color:" + strId + ";font-size:160%\">&#9632;</span>";
        }
        return strReturn;
    }
    //delete an invite

    protected void btn_DeleteInvite_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string strID = ((Label)grdRow.FindControl("lbl_Id")).Text;
        string strEmail = ((Label)grdRow.FindControl("lbl_API_Email")).Text;
        string strUser = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName).ToString();

        if (strUser == "0" || strUser == "")
        {
            MessageBox.ShowError("Session expired");
            return;
        }
        string Username = strEmail.ToLower().Trim();
        Hashtable ht = new Hashtable();
        ht.Add("@API_Id", strID);
        bool bExecuted = DSP.DAL.SQL.ExecuteSPByHashTable("SP_AppPortal_DeleteInvite", ht);

        // return bExecuted;
        string strUserName = Username.Trim();

        string strSQL = "DELETE FROM Users WHERE Users_Username = '{0}' ;";
        DSP.DAL.SQL.ExecuteScalar(string.Format(strSQL, strUserName));

        Hashtable htvalues = new Hashtable();
        htvalues.Add("@ApplicationName", "/");
        htvalues.Add("@UserName", strUserName);
        htvalues.Add("@TablesToDeleteFrom", 15);
        DSP.DAL.SQL.ExecuteSPByHashTable("aspnet_Users_DeleteUser", htvalues);

        ListAllLearners.DataBind();
        MessageBox.ShowInfo("Invite is now deleted.");
    }

    public static string GetSession(string sNameSession)
    {
        string sValue = "";
        try
        {
            sValue = HttpContext.Current.Session[sNameSession].ToString();
        }
        catch (Exception ex)
        {
            //  Response.Write(ex.ToString());
            sValue = "0";
        }
        if (sValue == "")
        {
            sValue = "0";
        }
        return sValue;
    }
    private int getCourseLevelForCourseId(int iCourseId)
    {
        string sCourseLevel = "Level 5";
        int CourseLevel = 5;

        DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(String.Format("Select top 1 Course_Level From Courses WHERE Course_Id = {0}; ", iCourseId));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                sCourseLevel = ds.Tables[0].Rows[0]["Course_Level"].ToString();
            }
            catch (Exception exx)
            {
                sCourseLevel = "Level 5";
            }
        }

        switch (sCourseLevel)
        {
            case "Short Course":
                CourseLevel = 99;
                break;
            case "Level 2":
                CourseLevel = 2;
                break;
            case "Level 3":
                CourseLevel = 3;
                break;
            case "Level 4":
                CourseLevel = 4;
                break;
            case "Level 5":
                CourseLevel = 5;
                break;
            case "Level 6":
                CourseLevel = 6;
                break;
            case "RMA":
                CourseLevel = 7;
                break;
            default:
                CourseLevel = 5;
                break;
        }
        return CourseLevel;
    }
    protected void btn_SubmitChangeCourse_Click(object sender, EventArgs e)
    {
        string sCourseId = ddl_ChangeCourse.SelectedValue.ToString();
        if (sCourseId == "")
        {
            return;
        }
        string inviteId = ViewState["inviteId"].ToString();
        string userName = ViewState["strEmail"].ToString();
        string courseTitle = ddl_ChangeCourse.SelectedItem.Text;
        int iCourseLevel = 5;

        iCourseLevel = getCourseLevelForCourseId(Convert.ToInt32(sCourseId));

        if (!string.IsNullOrEmpty(inviteId) && !string.IsNullOrEmpty(userName))
        {
            int userId = DSP.BAL.DBL.GetUser_UserId(userName);

            if (userId > 0)
            {

                string sSQL = "SELECT * FROM Users WHERE Users_UserName = '" + userName + "' AND Users_Id = " + userId + " ORDER BY Users_IsActive DESC ";
                DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(sSQL);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string updateUserRecordQuery = "update Users set Users_Id_Course = {0}, Users_CourseLevel = {1} where Users_Id = {2} and Users_Username = '{3}'";
                    bool result = DSP.DAL.SQL.ExecuteSQL(string.Format(updateUserRecordQuery, sCourseId, iCourseLevel, userId, userName));
                    if (result)
                    {
                        string updInviteQuery = "update AppPortal_Invites set API_CourseId = {0}, API_CourseTitle = '{1}' where API_Id = {2}";
                        DSP.DAL.SQL.ExecuteSQL(string.Format(updInviteQuery, sCourseId, courseTitle, inviteId));
                        DSP.BAL.Log.WriteLogTxt(String.Format("Invites.btn_SubmitChangeCourse_Click | username: {0} | Invites course change successfully | Invite id: {1} ", Membership.GetUser().UserName, inviteId));
                    }
                    else
                    {
                        DSP.BAL.Log.WriteLogTxt(String.Format("Invites.btn_SubmitChangeCourse_Click | username: {0} | Error changing invite course | Invite id: {1} ", Membership.GetUser().UserName, inviteId));
                    }
                    ListAllLearners.DataBind();
                }
            }
            else
            {
                MessageBox.ShowError("User not found.");
                DSP.BAL.Log.WriteLogTxt(String.Format("Invites.btn_SubmitChangeCourse_Click | username: {0} | Error changing invite course. User not found | Invite id: {1} ", Membership.GetUser().UserName, inviteId));
            }
        }
    }

    protected void btn_ChangeCourse_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string inviteId = ((Label)grdRow.FindControl("lbl_Id")).Text;
        string strEmail = ((Label)grdRow.FindControl("lbl_API_Email")).Text;

        ddl_ChangeCourse.SelectedIndex = -1;
        ViewState["inviteId"] = inviteId;
        ViewState["strEmail"] = strEmail;
        ClientScript.RegisterStartupScript(this.GetType(), "ChangeCourseModal", "$('#ChangeCourseModal').modal();", true);
    }
}