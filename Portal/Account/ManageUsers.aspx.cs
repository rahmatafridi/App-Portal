using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Account_ManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            if (!Roles.IsUserInRole("Admin")) return;

            Users_SetGridWithData();
            OSCAUsers_SetGridWithData();

        }


    }


    #region " --- Get My learner details - title only "
    public void LoadChecksControls()
    {


        string sLearnerId1 = (string)ViewState["AssessorLearnerId"];
        string sLearnerId = (string)Page.Session["AssessorLearnerId"];
        if (sLearnerId == null) return;

        DataSet ds;


        ds = DSP.DAL.SQLOSCA.GetRecordsBySQL("SELECT Learner_Firstname,Learner_Surname FROM [LearnerContacts] WHERE Learner_Id = '" + sLearnerId + "'");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            string sfirstname  = ds.Tables[0].Rows[0]["Learner_Firstname"].ToString();
            string ssurname = ds.Tables[0].Rows[0]["Learner_Surname"].ToString();

            lbl_fullname.Text = sLearnerId + " - " + sfirstname  + " " + ssurname ;

    
        }
        else
        {
        
        }
         
        string s4 = "<span class=\"l_status\" style=\"background:#COLOR#\">#STATUS#</span>";

        ds = DSP.DAL.SQLOSCA.GetDsBySP("SP_Track_GetLearnerShortDetails", "@Learner_ID", int.Parse(sLearnerId));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            { 
                s4 = s4.Replace("#COLOR#", ds.Tables[0].Rows[0]["CandidateStatus_BackColor"].ToString());
                lbl_fullname.Text += " - " + s4.Replace("#STATUS#", ds.Tables[0].Rows[0]["CandidateStatus_Title"].ToString());
            }
            catch (Exception exx)
            { }


        }
    }


    #endregion



 
    #region "-common"

    public void Users_SetGridWithData()
    {

        DataSet ds = LoadData();

        if (ds != null)
        {
            // ---------------------------------------------------
            grid_users.DataSource = ds;
            grid_users.DataBind();
        }
        else
        {

            grid_users.DataSource = null;
            grid_users.Visible = false;
        }
    }
   

    
    public DataSet LoadData()
    {

        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT u.* FROM Users as u ORDER BY u.Users_Username ASC");
       if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds; 
 
        }
        else
        {
            return null;
             
        }

      
    }

    protected string getLearnerStatus(object learnerid)
    {

        string strId = learnerid.ToString();
        string strReturn = "";
        if (strId != "")
        {

             strReturn = "<span style=\"color:" + strId + ";font-size:160%\">&#9632;</span>";//
        }
        return strReturn;


    }



    public bool ReturnStatus(object iValue)
    {

        bool sRet = false;

        string strReturn = iValue.ToString().Trim();
        if (strReturn == "" || strReturn == "0") { sRet = false; }
        else { sRet = true; }
        return sRet;

    }
    
    public bool ReturnEnableStatus(object iValue)
    {

        bool sRet = false;

        string strReturn = iValue.ToString().Trim();
        if (strReturn == "" || strReturn == "0") { sRet = false; }
        else { sRet = true; }
        return sRet;

    }


    #endregion


    #region "- update on click"


    protected void btn_UpdateActive_Click(object sender, EventArgs e)
    {
        CheckBox Button1 = (CheckBox)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        UpdateRow(grdRow);

    }



    protected void btn_UpdateTitle2_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        UpdateRow(grdRow);
    }


    protected void UpdateRow(GridViewRow grdRow)
    {

        string strID = ((Label)grdRow.FindControl("lbl_Users_Id")).Text;
      
         string sTitle = ((TextBox)grdRow.FindControl("txt_title")).Text;
        sTitle = sTitle.Trim();
        

        string sEmail = ((TextBox)grdRow.FindControl("txt_Email")).Text;
        sEmail = sEmail.Trim();
        if (sEmail == "" || sEmail.Length < 3)
        {
            MessageBox.ShowError("Enter a valid email address");
            return;
        }

        string sAssessorId = ((TextBox)grdRow.FindControl("txt_AssessorId")).Text;
        sAssessorId = sAssessorId.Trim();
        int iIdAssessor = 0;
        if (sAssessorId != "")
        {
            bool bError = int.TryParse(sAssessorId, out iIdAssessor);
            if (!bError)
            {
                MessageBox.ShowError("Enter a valid assessor id");
                return;
            }

        }

        string sOscaUserId = ((TextBox)grdRow.FindControl("txt_OscaUserId")).Text;
        sOscaUserId = sOscaUserId.Trim();
        int iIdOscaUser = 0;
        if (sOscaUserId != "")
        {
            bool bError = int.TryParse(sOscaUserId, out iIdOscaUser);
            if (!bError)
            {
                MessageBox.ShowError("Enter a valid osca id");
                return;
            }

        }

        string sLearnerId = ((TextBox)grdRow.FindControl("txt_LearnerId")).Text;
        sLearnerId = sLearnerId.Trim();
        int iLearnerId = 0;
        if (sLearnerId != "")
        {
            bool bError = int.TryParse(sLearnerId, out iLearnerId);
            if (!bError)
            {
                MessageBox.ShowError("Enter a learner id");
                return;
            }

        }
        

        bool bIsChecked = ((CheckBox)grdRow.FindControl("chk_IsChecked")).Checked;
        string sValue;

        if (bIsChecked == true)
        { sValue = "1"; }
        else { sValue = "0"; }


        bool bchk_IsAssessor = ((CheckBox)grdRow.FindControl("chk_IsAssessor")).Checked;
        string sbchk_IsAssessor;

        if (bchk_IsAssessor == true)
        { sbchk_IsAssessor = "1"; }
        else { sbchk_IsAssessor = "0"; }


        bool bchk_IsLearner = ((CheckBox)grdRow.FindControl("chk_IsLearner")).Checked;
        string sbchk_IsLearner;

        if (bchk_IsLearner == true)
        { sbchk_IsLearner = "1"; }
        else { sbchk_IsLearner = "0"; }


        bool bFound = false;

      
        if (bFound == false)
        {
            string strSQL = "UPDATE [Users] ";
            strSQL += "SET Users_DisplayName = '" + DSP.BAL.Basic.FormatStringForSQL(sTitle) + "' ";
            strSQL += " ,  Users_Email = '" + DSP.BAL.Basic.FormatStringForSQL(sEmail).ToLower() + "' ";
             strSQL += " , Users_Id_AssessorContacts = '" + iIdAssessor.ToString() + "' ";
            strSQL += " , Users_IsAssessor = " + sbchk_IsAssessor;
            strSQL += " , Users_IsLearner = " + sbchk_IsLearner;
            strSQL += " , Users_IsActive = " + sValue;
            strSQL += " , Users_Id_LearnerContacts = " + sLearnerId;
            strSQL += " , Users_Id_OSCA = " + iIdOscaUser;

            strSQL += " WHERE Users_Id = " + strID;
 

            DSP.DAL.SQL.ExecuteSQL(strSQL);
            


             Users_SetGridWithData();
            MessageBox.ShowSuccess("updated");
        }
        else
        {
         }





    }
 
#endregion





    #region " Sorting ang page index --- "
    protected void grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

         Users_SetGridWithData();

        //point to the page
        grid_users.PageIndex = e.NewPageIndex;
        grid_users.DataBind();
    }

    protected void grid_users_Sorting(object sender, GridViewSortEventArgs e)
    {


        DataSet ds = LoadData();
        DataTable dt = ds.Tables[0]; 
        DataView dataView = new DataView(dt);

        if (e.SortExpression == (string)ViewState["SortColumn"])
        {
            // We are resorting the same column, so flip the sort direction
            e.SortDirection =
            ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
            SortDirection.Descending : SortDirection.Ascending;
        }
        // Apply the sort
        dataView.Sort = e.SortExpression +
        (string)((e.SortDirection == SortDirection.Ascending) ? " ASC" : " DESC");
        ViewState["SortColumn"] = e.SortExpression;
        ViewState["SortColumnDirection"] = e.SortDirection;

        grid_users.DataSource = dataView;
        grid_users.DataBind();
    }

    

    #endregion

    #region "- show_notif"


    protected void show_notif(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }

    #endregion





    #region "- list osca users"


    public void OSCAUsers_SetGridWithData()
    {

        DataSet ds = LoadDataOSCAUsers();

        if (ds != null)
        {
            // ---------------------------------------------------
            grid_osca_users.DataSource = ds;
            grid_osca_users.DataBind();
        }
        else
        {

            grid_osca_users.DataSource = null;
            grid_osca_users.Visible = false;
        }
    }



    public DataSet LoadDataOSCAUsers()
    {

        DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL("SELECT u.Users_Id as 'OSCA Id', u.Users_Username as 'Username', u.Users_Id_AssessorContact as 'Id Assessor' FROM Users as u WHERE u.Users_IsActive = 1 ORDER BY u.Users_Username ASC");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds;

        }
        else
        {
            return null;

        }


    }


    #endregion















}
















 