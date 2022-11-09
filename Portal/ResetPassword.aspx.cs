using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;
using System.Collections;
 

public partial class portal_resetpassword : System.Web.UI.Page
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
     

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        DataSet dsUser = null;

        Boolean blLogin = false;
        string groups = string.Empty;
        string strUserId = "";
        string strUserName = "";
        string strIdLearner = "0";
        string strIdCare = "0";

        //Check SQL for Internal User with in SQL
       // string md5PW = DSP.BAL.Basic.EncodePassword(Password.Text);

        if (UserName.Text.Trim() == "")
        {
            InvalidCredentialsMessage.Text = "Please enter your email.";
            show_notif(InvalidCredentialsMessage.Text);
            return;

        }



        dsUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM Users WHERE Users_UserName = '" + UserName.Text + "' ");

        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
            InvalidCredentialsMessage.Text = "Your email is not on the system. Please contact Access Skills for more details";
            show_notif(InvalidCredentialsMessage.Text);


        }
        else
        {
            string sActive = dsUser.Tables[0].Rows[0]["Users_IsActive"].ToString();
            if (sActive == "1")
            {
                string strEmail = dsUser.Tables[0].Rows[0]["Users_Email"].ToString();
                 string strDisplayName = dsUser.Tables[0].Rows[0]["Users_DisplayName"].ToString();
                 string strOldPassword = dsUser.Tables[0].Rows[0]["Users_Password"].ToString();
                //check for 24hrs!
                string sLastChangedDateTime = dsUser.Tables[0].Rows[0]["Users_PasswordChangedDate"].ToString();
               

                
                //    string strEmail = UserName.Text;
                DSP.BAL.ASPMail emailReminder = new DSP.BAL.ASPMail();
                emailReminder.sTo = strEmail;
                emailReminder.sFrom = "portal@accessskills.co.uk";
                emailReminder.sSubject = "Portal: Your new requested password";

                MembershipUser u1 = Membership.GetUser(UserName.Text);

                if (u1.IsLockedOut)
                {
                    show_notif("Your account is locked out. Please contact Access Skills for further details.");
             
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
                  //  bError = true;
                   // sErrorMsg = exx.Message;
                }

                show_notif("An email has been sent with your new password.");
                UserName.Text = "";
             //   Response.Redirect("~/Portal/Login.aspx");

            }
            else
            {
                InvalidCredentialsMessage.Text = "Your are not an active user on the system. Please contact Access Skills for more details.";
                show_notif(InvalidCredentialsMessage.Text);

                blLogin = false;
            }//end if active user !
        }


        //string sSQL = "SELECT * FROM Users WHERE Users_UserName = '" + UserName.Text + "' AND Users_Password = '" + md5PW + "' ORDER BY Users_IsActive DESC ";
        //dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);


        //// ---------------------------------------------------
        //if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        //{
        //    // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";

        //}
        //else
        //{

        //    string sActive = dsUser.Tables[0].Rows[0]["Users_IsActive"].ToString();
        //    if (sActive == "1")
        //    {
        //        MembershipUser u1 = Membership.GetUser(UserName.Text);

        //        /*strUserId = dsUser.Tables[0].Rows[0]["Users_ID"].ToString();
        //        strIdLearner = dsUser.Tables[0].Rows[0]["Users_Id_Learner"].ToString();
        //        strIdCare = dsUser.Tables[0].Rows[0]["Users_Id_CareUser"].ToString();
        //        */
        //        strUserName = u1.UserName;

        //        /*if (u1 == null)
        //        {
        //            MembershipUser newUser = Membership.CreateUser(UserName.Text, md5PW);

        //        }*/
        //      //  string sss = u1.ResetPassword();
        //      //  u1.ChangePassword(sss, md5PW);


        //        if (Membership.ValidateUser(UserName.Text, md5PW))
        //        {

        //            blLogin = true;
        //        }

        //    }
        //    else
        //    {
        //        //  InvalidCredentialsMessage.Text = "You are not active user on this system.";

        //        blLogin = false;
        //    }//end if active user !  

        //}

        // --------------------------------------------------
     


        //if (blLogin)
        //{
        //    redirUrl = createCookie(UserName.Text, groups);

        //    Session.Timeout = 35;
        //    Session["UserId"] = strUserId;
        //    Session["UserName"] = strUserName;



        //    if ((strIdCare != "") && (strIdCare != "0") && (strIdCare != null))
        //    {
        //         strIdLearner = null;
        //    }
        //    else
        //    {

        //        strIdCare = null;

        //    }

        //    Session["IdLearner"] = strIdLearner;
        //    Session["IdCare"] = strIdCare;
             

        //    HttpContext.Current.Session.Add("UserId", strUserId);
        //    HttpContext.Current.Session.Add("UserName", strUserName);
        //  /*  HttpContext.Current.Session.Add("IdLearner", strIdLearner);
        //    HttpContext.Current.Session.Add("IdCare", strIdCare);
        //    */

           

        //    Response.Redirect(redirUrl);
        //}
        //else
        //{
        //    InvalidCredentialsMessage.Visible = true;
        //}
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
