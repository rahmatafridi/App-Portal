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

public partial class account_wuc_email_tpl_create : System.Web.UI.UserControl
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadChecksControls();
        }
    }
    public void Refresh()
    {
        LoadChecksControls();
    }
    #region " --- Get My details "
    public void LoadChecksControls()
    {

        int iId = 0;
        string sEdit = Request.QueryString["ed"];
        if (sEdit != "" && int.TryParse(sEdit, out iId))
        {
            //load template

            btnAdd.Text = "Update";
            lbl_Id.Text = iId.ToString();


            DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(string.Format("SELECT * FROM EmailTemplates WHERE ET_Id = {0} AND ET_IsDeleted = 0  ", iId.ToString()));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                chk_editable.Checked = false;

                txt_title.Text = ds.Tables[0].Rows[0]["ET_Title"].ToString();
                txt_Subject.Text = ds.Tables[0].Rows[0]["ET_Subject"].ToString();
                txt_Code.Text = ds.Tables[0].Rows[0]["ET_Code"].ToString();
                fckEditor.Value = ds.Tables[0].Rows[0]["ET_Body"].ToString();
                if (ds.Tables[0].Rows[0]["ET_IsActive"].ToString() == "1") { chk_editable.Checked = true; }

            }
            //switch to update panel

        }
        else
        {

            btnAdd.Text = "Create";
            lbl_Id.Text = "0";
        }




    }


    #endregion
    
    #region " CREATE --- "

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "Create")
        {
            InsertData();
        }
        else
        {
            UpdateData(int.Parse(lbl_Id.Text));
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(vars.STR_EMAIL_TPL_LINK_ALL);
    }


    protected void show_notif(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
    public void InsertData()
    {
        string sEnabling = "0";
        if (chk_editable.Checked == true) sEnabling = "1";
        
        if (txt_title.Text.Trim() == "" || txt_title.Text.Length < 3)
        {

            MessageBox.ShowError(vars.STR_MSG_ENTER_PROPER_TITLE);

            return;
        }

        if (DSP.BAL.Basic.CheckIfItemExists(DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM [EmailTemplates] WHERE ET_Title ='" + txt_title.Text.Trim() + "'")))
        {
            MessageBox.ShowError(vars.STR_MSG_ENTERED_EXIST_TITLE);

            return;
        }

        /* CREATE NEW cf RECORD  */
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
            strSQL += " ,[ET_Subject]";
            strSQL += " ,[ET_Code]";
            strSQL += " ) VALUES";
            strSQL += " (  ";// +ddl_Categories.SelectedValue; 
            strSQL += "   '" + DSP.BAL.Basic.FormatStringForSQL(txt_title.Text) + "'";
            strSQL += " , getDate() ";
            strSQL += " ," + DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName);
            strSQL += " ,  " + sEnabling;

            strSQL += " , '" + DSP.BAL.Basic.FormatStringForSQL(fckEditor.Value) + "'";
            strSQL += " , '" + DSP.BAL.Basic.FormatStringForSQL(txt_Subject.Text) + "'";
            strSQL += " , '" + DSP.BAL.Basic.FormatStringForSQL(txt_Code.Text) + "'";
            strSQL += "   )";

            DSP.DAL.SQL.ExecuteSQL(strSQL);

            string strLog = "";
            strLog += "New Email Template added with name: " + DSP.BAL.Basic.FormatStringForSQL(txt_title.Text) + vars.STR_LOG_SEP;
            strLog += "By : " + Membership.GetUser().UserName + vars.STR_LOG_SEP;
            strLog += "Active: " + sEnabling + vars.STR_LOG_SEP;

            DSP.BAL.Log.log(strLog, "wuc_email_tpl_create.ascx.cs.InsertData()", vars.STR_LOG_NEW + " " +vars.STR_LOG_SECT_EMAIL_TPL);

            Response.Redirect(vars.STR_EMAIL_TPL_LINK_ALL);

        }
        catch (Exception exx)
        {
            MessageBox.ShowError(exx.ToString());
        }
    }
    public void UpdateData(int iId)
    {
        string sEnabling = "0";
        if (chk_editable.Checked == true) sEnabling = "1";

        if (txt_title.Text.Trim() == "" || txt_title.Text.Length < 3)
        {

            MessageBox.ShowError(vars.STR_MSG_ENTER_PROPER_TITLE);

            return;
        }

        if (DSP.BAL.Basic.CheckIfItemExists(DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM [EmailTemplates] WHERE ET_Title ='" + txt_title.Text.Trim() + "' AND ET_Id <> " + iId.ToString())))
        {
            MessageBox.ShowError(vars.STR_MSG_ENTERED_EXIST_TITLE);

            return;
        }
        /* UPDATE RECORD  */
        string strSQL = "";
        try
        {
            strSQL = " UPDATE [EmailTemplates] ";
            strSQL += "SET ";
            strSQL += "  [ET_Title] = '" + DSP.BAL.Basic.FormatStringForSQL(txt_title.Text) + "'";
            strSQL += " ,[ET_IsActive] = " + sEnabling;
            strSQL += " ,[ET_Body] = '" + DSP.BAL.Basic.FormatStringForSQL(fckEditor.Value) + "'";
            strSQL += " ,[ET_Subject] = '" + DSP.BAL.Basic.FormatStringForSQL(txt_Subject.Text) + "'";
            strSQL += " ,[ET_Code] = '" + DSP.BAL.Basic.FormatStringForSQL(txt_Code.Text) + "'";
            strSQL += " WHERE ET_Id = " + iId.ToString();

            DSP.DAL.SQL.ExecuteSQL(strSQL);
            string strLog = "";
            strLog += "Email Template updated with name: " + DSP.BAL.Basic.FormatStringForSQL(txt_title.Text) + vars.STR_LOG_SEP;
            strLog += "By : " + Membership.GetUser().UserName + vars.STR_LOG_SEP;
            strLog += "Active: " + sEnabling + vars.STR_LOG_SEP;

            DSP.BAL.Log.log(strLog, "wuc_email_tpl_create.ascx.cs.UpdateData()", vars.STR_LOG_UPDATE + " " +vars.STR_LOG_SECT_EMAIL_TPL);


            Response.Redirect(vars.STR_EMAIL_TPL_LINK_ALL);

        }
        catch (Exception exx)
        {
            MessageBox.ShowError(exx.ToString());
        }
    }


    #endregion
    

    protected bool checkIfItemIsUsed(string sId, bool bIsDelete)
    {
        bool bFound = false;
        //todo      
        return bFound;
    }
}
