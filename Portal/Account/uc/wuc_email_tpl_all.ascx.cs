using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class account_wuc_email_tpl_all : System.Web.UI.UserControl
{


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //LoadChecksControls();
        }
    }


    public void Refresh()
    {

        LoadChecksControls();

    }

    #region " --- Get My details "
    public void LoadChecksControls()
    {
        DataSet ds;

        ds = DSP.DAL.SQL.GetDsBySP("SP_EmailTemplates_GetList");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grid_templates.DataSource = ds;
            grid_templates.DataBind();
            grid_templates.Visible = true;
        }
        else
        {
            grid_templates.DataSource = null;
            grid_templates.Visible = false;
        }

        //  DataSet ds;
        //  int iIdAssessor = 0;
        //  string sSQL = "SELECT Users_Id_AssessorContacts FROM Users WHERE Users_UserName = '" + Membership.GetUser() + "' AND Users_IsActive =  1 ; ";
        //  DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);


        //  // ---------------------------------------------------
        //  if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        //  {
        //  // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
        //      return;
        //  }
        //  else
        //  {
        //      iIdAssessor = int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString());

        ////  string sActive = dsUser.Tables[0].Rows[0]["Users_IsActive"].ToString();

        //  }

        //  /*string sUserLogged =HttpContext.Current.Session["IdAssessor"].ToString(); ; // DSP.BAL.Session.GetSession("IdAssessor"); // HttpContext.Current.Session["IdLearner"].ToString();
        //  if (sUserLogged == null || sUserLogged == "0")
        //  {
        //      return;
        //      Response.Redirect("~/Portal/Login.aspx");
        //  }*/


        //  ds = DSP.DAL.SQLOSCA.GetRecordsBySQL("SELECT * FROM [AssessorContacts] WHERE Assessor_Id = '" + iIdAssessor + "'");
        //  if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //  {
        //      //     grid_all.DataSource = ds;
        //      //     grid_all.DataBind();
        //      //     grid_all.Visible = true; 
        //      // Assessor_Id_Titles

        //      lbl_pfirstname.Text = ds.Tables[0].Rows[0]["Assessor_Firstname"].ToString();
        //   //   lbl_pmiddle.Text = ds.Tables[0].Rows[0]["Assessor_Middlename"].ToString();
        //      lbl_psurname.Text = ds.Tables[0].Rows[0]["Assessor_Surname"].ToString();
        //   //   lbl_pdob.Text = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["Assessor_DOB"].ToString());
        //      //
        //     // lbl_pmobile.Text = ds.Tables[0].Rows[0]["Assessor_Mobile1"].ToString();
        //      lbl_pmobile.Text = ds.Tables[0].Rows[0]["Assessor_Tel1Work"].ToString();
        //      if (lbl_pmobile.Text.Length < 1) { lbl_pmobile.Text = "Not Provided!"; }

        //      lbl_ptel.Text = ds.Tables[0].Rows[0]["Assessor_Tel1"].ToString();
        //      if (lbl_ptel.Text.Length < 1) { lbl_ptel.Text = "Not Provided!"; }
        //      lbl_pemail.Text = ds.Tables[0].Rows[0]["Assessor_Email1"].ToString(); ;// Session["UserName"].ToString();
        //      //  lbl_pclass.Text = ds.Tables[0].Rows[0]["Learner_Class"].ToString();

        //    //  string sClass = ds.Tables[0].Rows[0]["Learner_Class"].ToString();

        //     /* if (sClass == "")
        //      {
        //          lbl_pclass.Text = "You have not currently been timetabled. Please contact our Customer Services Team on 0845 363 6139 or email studentsupport@wavetraining.co.uk for more information.";
        //      }
        //      else if (sClass == "TBA")
        //      {
        //          lbl_pclass.Text = "You have not been assigned to a specific class and will need to contact your assessor directly to arrange appointments. Please click on the “Assessor Details” section for full contact details.";
        //      }
        //      else
        //      {
        //          lbl_pclass.Text = sClass;

        //      }
        //      */


        //      //lbl_pjobtitle           
        //      lbl_pjobtitle.Text = ReturnJobTitle(ds.Tables[0].Rows[0]["Assessor_IsJobAssessor"].ToString(), ds.Tables[0].Rows[0]["Assessor_IsJobIV"].ToString(), ds.Tables[0].Rows[0]["Assessor_IsJobTrainer"].ToString(), ds.Tables[0].Rows[0]["Assessor_IsJobTutor"].ToString());

        //      lbl_paddress.Text = ds.Tables[0].Rows[0]["Assessor_Address1"].ToString();
        //      lbl_paddress.Text += ", " + ds.Tables[0].Rows[0]["Assessor_Address2"].ToString();
        //      lbl_paddress.Text += ", " + ds.Tables[0].Rows[0]["Assessor_Address3"].ToString();
        //      lbl_paddress.Text += ", " + ds.Tables[0].Rows[0]["Assessor_Address4"].ToString();
        //      lbl_paddress.Text += ", " + ds.Tables[0].Rows[0]["Assessor_Address5"].ToString();
        //      lbl_paddress.Text.Replace(", ,", ",");
        //      lbl_ppostcode.Text = ds.Tables[0].Rows[0]["Assessor_PostCode1"].ToString() + " " + ds.Tables[0].Rows[0]["Assessor_PostCode2"].ToString();

        //      Page.Session["AssessorPostCode"] = lbl_ppostcode.Text;
        //  }
        //  else
        //  {
        //      //     grid_all.DataSource = null;
        //      //     grid_all.Visible = false;
        //  }
    }


    #endregion


    #region " --- "


    //  <label>Create a New Role </label>
    //   <b> </b> 
    //    <asp:TextBox ID="RoleName" runat="server"></asp:TextBox>  
    //    <asp:LinkButton SkinID="LinkButton" runat="server" ID="btn_CreateRole" Text="Create Role"
    //    OnClick="CreateRoleButton_Click" />


    //    <br />

    //     <asp:UpdatePanel ID="upd" runat="server">
    //        <ContentTemplate>


    //            <div class="grid_9 omega align-right">
    //                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    //                    <ProgressTemplate>
    //                        <img src="../../App_Resources/images/loader-life.gif" alt="Loading Data" />
    //                    </ProgressTemplate>
    //                </asp:UpdateProgress>
    //            </div>
    //            <div class="grid-viewer grid_19 clearfix">
    //                <asp:Literal EnableViewState="false" runat="server" ID="ltlMessage"></asp:Literal>


    //<asp:GridView ID="grid_roles_list" runat="server" OnRowDeleting="grid_roles_list_RowDeleting" 
    //AutoGenerateDeleteButton="True" AutoGenerateColumns="False" SkinID="GridView" >      
    //<Columns>         
    //<asp:TemplateField HeaderText="Role">
    //<ItemTemplate>
    //<asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' />                
    //</ItemTemplate>
    //</asp:TemplateField>
    //</Columns>  
    //</asp:GridView>



    //            </div>
    //            <div class="clearfix">


    //            </div>
    //            <div class="clearfix align-right">


    //                    </div>
    //        </ContentTemplate>
    //    </asp:UpdatePanel>
    #endregion


    #region "-- Templates"

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

    protected void btn_Duplicate_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string strID = ((Label)grdRow.FindControl("lbl_ET_Id")).Text;
        string strTitle = ((Label)grdRow.FindControl("lbl_ET_Title")).Text;
        bool bFound = CheckCopy(ref strTitle);

        if (!bFound)
        {
            CopyTemplate(strID, strTitle);

        }
    }
    protected bool CheckCopy(ref string strTitle)
    {
        if (DSP.BAL.Basic.CheckIfItemExists(DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM [EmailTemplates] WHERE ET_IsDeleted =  0 AND  ET_Title ='" + strTitle.Trim() + "'")))
        {
            strTitle = "Copy " + strTitle;

            CheckCopy(ref strTitle);

        }
        return false;
    }
    public void CopyTemplate(string strId, string strTitle)
    {
        string sUserId = DSP.DAL.SQL.GetOneValueBySQL("SELECT Users_Id FROM Users WHERE Users_UserName = '" + Membership.GetUser() + "' ; ", "Users_Id");
        string strSQL = "";
        try
        {
            strSQL = " INSERT INTO  [EmailTemplates]";
            strSQL += "(";

            strSQL += "  [ET_Title]";
            strSQL += " ,[ET_CreatedDate]";
            strSQL += " ,[ET_CreatedByUser]";
            strSQL += " ,[ET_IsActive]";
            strSQL += " ,[ET_Body]";
            strSQL += " ) SELECT ";
            strSQL += "   '" + strTitle + "'";
            strSQL += " , getDate() ";
            strSQL += " , '" + sUserId + "'";
            strSQL += " , 1  ";

            strSQL += " , ET_Body ";
            strSQL += "   FROM EmailTemplates WHERE ET_Id = " + strId;

            DSP.DAL.SQL.ExecuteSQL(strSQL);

            string strLog = "";
            strLog += "Email Template Copied with name: " + strTitle + vars.STR_LOG_SEP;
            strLog += "From Id: " + strId + vars.STR_LOG_SEP;

            DSP.BAL.Log.log(strLog, "wuc_email_tpl_all.ascx.CopyTemplate()", "COPY " + vars.STR_LOG_SECT_EMAIL_TPL);

            MessageBox.ShowSuccess("Template is copied.");
            grid_templates.DataBind();
        }
        catch (Exception exx)
        {
            MessageBox.ShowError(exx.ToString());
        }
    }    
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string strID = ((Label)grdRow.FindControl("lbl_ET_Id")).Text;
        
        Response.Redirect(string.Format(vars.STR_EMAIL_TPL_LINK_EDIT, strID));        
    }


    public void btn_RequestDelete_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string strID = ((Label)grdRow.FindControl("lbl_ET_Id")).Text;
        if (strID == "1")
        {
            MessageBox.ShowError("Sorry you cannot delete this template as it is used by the system");

            return;
        }
        string sUserId = DSP.DAL.SQL.GetOneValueBySQL("SELECT Users_Id FROM Users WHERE Users_UserName = '" + Membership.GetUser() + "' ; ", "Users_Id");
        string strSQl = ""; // grdRow.Cells[0].Text + grdRow.Cells[1].Text + grdRow.Cells[2].Text + grdRow.Cells[3].Text + grdRow.Cells[4].Text;        
        bool bFound = checkIfItemIsUsed(strID, true);
        if (bFound == false)
        {
            strSQl = "UPDATE [EmailTemplates] SET ET_IsDeleted = 1, ET_DeletedByUser =" + sUserId + ", ET_DeletedDate = getdate()  WHERE ET_Id = " + strID;
            DSP.DAL.SQL.ExecuteSQL(strSQl);            
        }
        MessageBox.ShowSuccess("Template is deleted.");
        grid_templates.DataBind();
    }
    #endregion

    protected bool checkIfItemIsUsed(string sId, bool bIsDelete)
    {
        bool bFound = false;

        //DataSet ds = objFuncs.GetDsBySP("SP_CDB_CheckIfProductsUsed","@Id_Product", int.Parse(sId));

        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    bFound = true;
        //    if (bIsDelete)
        //        MessageBox.ShowError(GlobalVars.STR_MSG_DELETE_ALREADYINUSE);
        //    else
        //        MessageBox.ShowError(GlobalVars.STR_MSG_DESACTIVE_ALREADYINUSE);

        // //  MessageBox.ShowError(GlobalVars.STR_MSG_DELETE_PROD_ALREADYINUSE);

        //    grid_found_invoices.DataSource = ds;
        //    grid_found_invoices.DataBind();
        //    grid_found_invoices.Visible = true;

        //}
        //else
        //{
        // //   MessageBox.ShowError(GlobalVars.STR_MSG_DELETE_ALREADYINUSE);

        //    grid_found_invoices.Visible = false;

        //}
        return bFound;
    }
}
