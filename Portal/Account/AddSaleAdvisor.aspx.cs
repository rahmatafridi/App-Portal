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
using DSP.BAL;

public partial class Admin_AddUserAdvisor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Bind the users and roles
            BindRolesToList();
        }
    }
    private void BindRolesToList()
    {
        // Get all of the roles

    }
    protected void ShowNotification(Page page, string notificationType, string text, bool autoClose)
    {
        string className = null;
        className = "fail";
        string notification = "jQuery('body').showMessage({'thisMessage':['" + text.Replace(Environment.NewLine, "','") + "'],'className':'" + className + "','autoClose':" + autoClose.ToString().ToLower() + ",'delayTime':4000,'displayNavigation':" + (!autoClose).ToString().ToLower() + ",'useEsc':" + (!autoClose).ToString().ToLower() + "});";

        if (ScriptManager.GetCurrent(page) != null)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                                                "notification",
                                                notification,
                                                true);
        }
        else
        {
            page.ClientScript.RegisterStartupScript(page.GetType(),
                                                    "notification",
                                                    notification,
                                                    true);
        }
    }


    protected void show_notif(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        string strUser = txtUserName.Text.Trim();
        string strPassword = txtPassword.Text;
        string strDisplayName = txt_displayname.Text.Trim();
        DataSet dsUser;
        MembershipUser newUser;

        string strPass = DSP.BAL.Basic.EncodePassword(strPassword);
        newUser = Membership.GetUser(strUser);

        if (newUser == null)
        {

            string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAdvisor, Users_IsAssessor, Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_Id_AssessorContacts) values ";
            strSQL += "('" + strUser + "','" + strPass + "', 1, '" + strDisplayName + "',  getdate(),'1', '0','0','0','0','0', '0'); select scope_identity() as id;";
            dsUser = DSP.DAL.SQL.GetRecordsBySQL(strSQL);

            newUser = Membership.CreateUser(strUser, strPass);
            Roles.AddUserToRole(strUser, "SalesAdvisor");
            if (chkSendDetails.Checked == true)
            {
                SendInviteEmailToAdvisor(strUser, strDisplayName, strPassword);
            }
            show_notif("Advisor User " + strUser + " successfully added. ");
            txtUserName.Text = "";
            txt_displayname.Text = "";
        }
        else
        {
            show_notif("Advisor User " + strUser + " already exists.");
        }
    }

    private bool SendInviteEmailToAdvisor(string email, string displayName, string password)
    {
        string sContents = "";
        string scurr_email_tpl_id = "4";
        string strSQL = "SELECT * FROM [EmailTemplates] WHERE ET_IsDeleted = 0 AND ET_Id = '" + scurr_email_tpl_id + "'";
        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(strSQL);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {           
            sContents = ds.Tables[0].Rows[0]["ET_Body"].ToString();
        }

        sContents = sContents.Replace("[FULL_NAME]", displayName.Trim());
        sContents = sContents.Replace("[USERNAME]", email.Trim().ToLower());
        sContents = sContents.Replace("[PASSWORD]", txtPassword.Text.Trim());
        sContents = sContents.Replace("[PORTAL_URL]", "http://www.accessskills.co.uk/apply");

        string strEmailBody = sContents;
        string strEmail = email.ToLower().Trim();
        string strEmailCopy = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        string strEmailFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
        string strEmailSubject = ConfigurationManager.AppSettings["cfg_lang_registersubject"];

        bool bError = false;
        string sErrorMsg = "";

        try
        {
            //  ================================
            ASPMail emailNewUser = new ASPMail();
            emailNewUser.sTo = strEmail;
            emailNewUser.sFrom = strEmailFrom;
            emailNewUser.sSubject = strEmailSubject;

            emailNewUser.sBody = strEmailBody;

            try
            {
                emailNewUser.SendMail();

            }
            catch (Exception exx)
            {
                bError = true;
                sErrorMsg = exx.Message;
            }
        }
        catch (Exception ex)
        {
            Log.log(ex.Message, "AddSaleAdvisor.aspx.cs>SendInviteEmailToAdvisor()", "Error");
        }

        return true;
    }
}
