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
 

public partial class root_resetpassword : System.Web.UI.Page
{
    private string redirUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
       //if (true == Request.IsAuthenticated)
       // {
          
       // }
         
         
  
   

    }
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
     

    protected void ResetPassword_Click(object sender, EventArgs e)
    {
        DataSet dsUser = null;

        Boolean blLogin = false;
        string groups = string.Empty;
        string strUserId = "";
        string strUserName = "";
        string strIdLearner = "0";
        string strIdCare = "0";

      
        if (UserName.Text.Trim() == "")
        {
            InvalidCredentialsMessage.Text = "Please enter your email.";
            show_notif(InvalidCredentialsMessage.Text);
            return;

        }



        dsUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM Users WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL(UserName.Text) + "' ");

        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
            InvalidCredentialsMessage.Text = ConfigurationManager.AppSettings["cfg_lang_emailnopresent"];
            show_notif(InvalidCredentialsMessage.Text);            
        }
        else
        {
            string sActive = dsUser.Tables[0].Rows[0]["Users_IsActive"].ToString();
            if (sActive == "1")
            {
                string strEmail = UserName.Text.Trim(); // dsUser.Tables[0].Rows[0]["Users_Email"].ToString();
                 string strDisplayName = dsUser.Tables[0].Rows[0]["Users_DisplayName"].ToString();
                 string strOldPassword = dsUser.Tables[0].Rows[0]["Users_Password"].ToString();
                //check for 24hrs!
                string sLastChangedDateTime = dsUser.Tables[0].Rows[0]["Users_PasswordChangedDate"].ToString();
               

                
                DSP.BAL.ASPMail emailReminder = new DSP.BAL.ASPMail();
                emailReminder.sTo = strEmail;
                emailReminder.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];  
                emailReminder.sSubject = ConfigurationManager.AppSettings["cfg_lang_emailresetsubject"]; //   " Your new requested password";

                MembershipUser u1 = Membership.GetUser(UserName.Text);

                if (u1.IsLockedOut)
                {
                    show_notif(ConfigurationManager.AppSettings["cfg_lang_accountlocked"]);// "Your account is locked out. Please contact Access Skills for further details.");

                    return;
                }
                string sOldGeneratedPassword = u1.ResetPassword();
                string sRawPassword = DSP.BAL.Basic.GenerateRandomPasswordUsingGUID(6);
                string sNewPassword = DSP.BAL.Basic.EncodePassword(sRawPassword);

                if (u1 != null)
                {
                    if (u1.ChangePassword(sOldGeneratedPassword, sNewPassword))
                    {

                        string strSql = "UPDATE Users SET Users_PasswordChangedDate = getdate() , Users_Password = '" + sNewPassword + "'  WHERE Users_UserName = '" + u1.UserName + "' AND Users_Password = '" + strOldPassword + "'";
                        DSP.DAL.SQL.ExecuteSQL(strSql);
                    }
                }
                Hashtable ht = new Hashtable();
                ht.Clear();
                ht.Add("[USER_FULLNAME]", strDisplayName );
                ht.Add("[USER_PASSWORD]", sRawPassword);
                ht.Add("[USER_EMAIL]", strEmail );
             
                emailReminder.sBody = DSP.BAL.DBL.GetEmailTemplateBodyReplaced(1, ht);

                try
                {
                    emailReminder.SendMail();

                }
                catch (Exception exx)
                {
                
                }

                show_notif("An email has been sent with your new password.");
                UserName.Text = "";
        
            }
            else
            {
                InvalidCredentialsMessage.Text = "Your are not an active user on the system. Please contact Access Skills for more details.";
                show_notif(InvalidCredentialsMessage.Text);

                blLogin = false;
            }//end if active user !
        }


       

     

      
    }

    private string createCookie(string strUser, string groups)
    {
        string userDataString = groups;

        HttpCookie authCookie = FormsAuthentication.GetAuthCookie(strUser, false);
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

        authCookie.Value = FormsAuthentication.Encrypt(newTicket);
        authCookie.HttpOnly = true;
        Response.Cookies.Add(authCookie);

        return FormsAuthentication.GetRedirectUrl(strUser, false);
    }


}
