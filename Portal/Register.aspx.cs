using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;
using System.Collections;
using System.Configuration;


public partial class root_register : System.Web.UI.Page
{
    private string redirUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
       if (true == Request.IsAuthenticated)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            string ss= Request.QueryString["ReturnUrl"];
            Response.Redirect(ss);
        }
         
         
        if (true == Request.IsAuthenticated)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        //    string ss = Request.QueryString["ReturnUrl"];
        //    Response.Redirect("~/Portal/Account/ManageRoles.aspx");
        }
     //   RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

        //string ss = Request.QueryString["ReturnUrl"];
      //  Response.Redirect(ss);

    }
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
     

    protected void Register_Click(object sender, EventArgs e)
    {
        DataSet dsUser = null;
        string groups = string.Empty;
        
        //Check SQL for Internal User with in SQL
       // string md5PW = DSP.BAL.Basic.EncodePassword(Password.Text);

        if (txtEmail.Text.Trim() == "")
        {
            InvalidCredentialsMessage.Text = "Please enter your email.";
            show_notif(InvalidCredentialsMessage.Text);
            return;
        }
        
        dsUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM Users WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL(txtEmail.Text) + "' ");

        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
            DSP.BAL.ASPMail emailReminder = new DSP.BAL.ASPMail();
            emailReminder.sTo = txtEmail.Text;
             emailReminder.sSubject = "Portal: Your new requested password";
            emailReminder.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"]; 
            emailReminder.sSubject = ConfigurationManager.AppSettings["cfg_lang_registersubject"]; //   " Your new requested password";
                       
            string sRawPassword = DSP.BAL.Basic.GenerateRandomPasswordUsingGUID(6);
            string sNewPassword = DSP.BAL.Basic.EncodePassword(sRawPassword);
            string sFullName = txtName.Text.Trim();
            
            MembershipUser u1 = Membership.CreateUser(txtEmail.Text, sRawPassword, txtEmail.Text );

            Roles.AddUserToRole(txtEmail.Text, "Applicant");
                   
            string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, " ;
            strSQL += " Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup) values ('{0}','{1}', 0, '{2}',  getdate(),'0','0','0','0','0'); select scope_identity() as id;";
            dsUser = DSP.DAL.SQL.GetRecordsBySQL(string.Format(strSQL, txtEmail.Text, sNewPassword, sFullName));
                      
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("[USER_FULLNAME]", sFullName );
            ht.Add("[USER_PASSWORD]", sRawPassword);
            ht.Add("[USER_EMAIL]", txtEmail.Text );

            emailReminder.sBody = DSP.BAL.DBL.GetEmailTemplateBodyReplaced(2, ht); //Reister
                       
            emailReminder.SendMail();
                     
            show_notif("An email has been sent with your activation link and password.");
            txtEmail.Text = "";
            Response.Redirect("~/Login.aspx");
            
        }
        else
        {
            InvalidCredentialsMessage.Text = "Your email is not on the system. Please contact Access Skills for more details";
            show_notif(InvalidCredentialsMessage.Text);

        }

    }

    private string createCookie(string strUser, string groups)
    {
        string userDataString = groups;

        // Get the FormsAuthenticationTicket out of the encrypted cookie
        // Create a new FormsAuthenticationTicket that includes our custom User Data
        HttpCookie authCookie = FormsAuthentication.GetAuthCookie(strUser, false);
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

        // Update the authCookie's Value to use the encrypted version of newTicket
        // Setting the HttpOnly value to true, makes this cookie accessible only to ASP.NET.
        // Manually add the authCookie to the Cookies collection
        authCookie.Value = FormsAuthentication.Encrypt(newTicket);
        authCookie.HttpOnly = true;
        Response.Cookies.Add(authCookie);

        return FormsAuthentication.GetRedirectUrl(strUser, false);
    }


}
