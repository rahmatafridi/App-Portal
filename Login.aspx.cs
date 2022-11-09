using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;
using System.Security.Principal;
using System.Configuration;
using System.Collections;
 
public partial class root_Login : System.Web.UI.Page
{
    private string redirUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
       /* if (true == Request.IsAuthenticated)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            string ss= Request.QueryString["ReturnUrl"];
            Response.Redirect(ss);
        }
         
        */
        if (true == Request.IsAuthenticated)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        //    string ss = Request.QueryString["ReturnUrl"];
        //    Response.Redirect("~/Portal/Account/ManageRoles.aspx");
        }
       // RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

        //string ss = Request.QueryString["ReturnUrl"];
      //  Response.Redirect(ss);


        //if (false == Request.IsAuthenticated)
        //{
        //    System.Web.UI.Control lw = (System.Web.UI.Control)this.Master.FindControl("loggedinfo");
        //    if (lw != null)
        //    { lw.Visible = false; }
        //}



    }



   

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        DataSet dsUser = null;

        Boolean blLogin = false;
        string groups = string.Empty;
        string strUserId = "";
        string strUserName = "";
        string strIdLearner = "0";
        string strUsers_Id_OSCA = "0";
        
        string strIdAssessor = "0";
        string strIdIV = "0";

        

        //Check SQL for Internal User with in SQL
        string md5PW = DSP.BAL.Basic.EncodePassword(Password.Text);

        string sSQL = "SELECT * FROM Users WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL ( UserName.Text) + "' AND Users_Password = '" + md5PW + "' ORDER BY Users_IsActive DESC ";
        dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);


        // ---------------------------------------------------
        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
            // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";

        }
        else
        {

            string sActive = dsUser.Tables[0].Rows[0]["Users_IsActive"].ToString();
            if (sActive == "1")
            {
                MembershipUser u1 = Membership.GetUser(UserName.Text);

                strUserId = dsUser.Tables[0].Rows[0]["Users_ID"].ToString();
               // strIdLearner = dsUser.Tables[0].Rows[0]["Users_Id_Learner"].ToString();


                //if (Roles.IsUserInRole(u1.UserName, "Applicant") == true)
                //{

                //  Response.Redirect("~/Application/Default.aspx");
                //}

                strIdAssessor = dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString();
                //strIdIV = dsUser.Tables[0].Rows[0]["Users_Id_IVContacts"].ToString();
                strUsers_Id_OSCA = dsUser.Tables[0].Rows[0]["Users_Id_OSCA"].ToString();

                //if (Roles.IsUserInRole(u1.UserName, "Assessor") == true)
                //{
                //    strIdAssessor = dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString();
                
                //   // Response.Redirect("~/Portal/Assessors/Default.aspx");
                //}


                //if (Roles.IsUserInRole(u1.UserName, "Learner") == true)
                //{
                //    strIdLearner = dsUser.Tables[0].Rows[0]["Users_Id_LearnerContacts"].ToString();

                //    // Response.Redirect("~/Portal/Assessors/Default.aspx");
                //}



                //if (Roles.IsUserInRole(u1.UserName ,"IV") == true)
                //{
                //    strIdIV = dsUser.Tables[0].Rows[0]["Users_Id_IVContacts"].ToString();
                //}


                if (Roles.IsUserInRole(u1.UserName , "Admin") == true)
                {
                    string strs = "yes";
                   // Response.Redirect("~/Portal/Account/Default.aspx");
                }
 



                strUserName = u1.UserName;

                /*if (u1 == null)
                {
                    MembershipUser newUser = Membership.CreateUser(UserName.Text, md5PW);

                }*/
              //  string sss = u1.ResetPassword();
              //  u1.ChangePassword(sss, md5PW);


                //if (Membership.ValidateUser(UserName.Text, md5PW))
                //{

                    blLogin = true;
                //}

            }
            else
            {
                //  InvalidCredentialsMessage.Text = "You are not active user on this system.";

                blLogin = false;
            }//end if active user !  

        }

        // --------------------------------------------------
     


        if (blLogin)
        {
            redirUrl = createCookie(UserName.Text, groups);

            Session.Timeout = 35;
            Session["UserId"] = strUserId;
            Session["UserName"] = strUserName;

           // Session["IdAssessor"] = strIdAssessor; 

            if ((strIdAssessor != "") && (strIdAssessor != "0") && (strIdAssessor != null))
            {
                 strIdLearner = null;
            }
            else
            {

                strIdAssessor = null;

            }

            Session["IdLearner"] = strIdLearner;
            Session["IdAssessor"] = strIdAssessor;
            Session["IdIV"] = strIdIV;

            Session["Users_Id_OSCA"] = strUsers_Id_OSCA;
           

            
            
                
            HttpContext.Current.Session.Add("UserId", strUserId);
            HttpContext.Current.Session.Add("UserName", strUserName);
            HttpContext.Current.Session.Add("IdAssessor", strIdAssessor);
            HttpContext.Current.Session.Add("IdIV", strIdIV);
            HttpContext.Current.Session.Add("IdLearner", strIdLearner);
            HttpContext.Current.Session.Add("Users_Id_OSCA", strUsers_Id_OSCA);
         

          /*  HttpContext.Current.Session.Add("IdLearner", strIdLearner);
            HttpContext.Current.Session.Add("IdCare", strIdCare);
            */



            getCustomisedUrl(Membership.GetUser(UserName.Text));
           //LIVE!!! Response.Redirect(redirUrl);
        }
        else
        {
            InvalidCredentialsMessage.Visible = true;
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        DataSet dsUser = null;
        string groups = string.Empty;


        if (!Page.IsValid)
        {
            return;
        }
       
        if (txtEmail.Text.Trim() == "")
        {
            InvalidCredentialsMessage.Text = "Please enter your email.";
            return;
        }

        dsUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM Users WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL(txtEmail.Text) + "' ");

        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {

            MembershipUser uExisting = Membership.GetUser(txtEmail.Text);
            if (uExisting != null)
            {
                InvalidRegisterCredentialsMessage.Visible = true;
                InvalidRegisterCredentialsMessage.Text = "This email is already registered with us. If you have difficulties please reset your password or please contact us for more help.";

            }
            else
            {

                DSP.BAL.ASPMail emailReminder = new DSP.BAL.ASPMail();
                emailReminder.sTo = txtEmail.Text;
                emailReminder.sSubject = "Portal: Your new requested password";
                emailReminder.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
                emailReminder.sSubject = ConfigurationManager.AppSettings["cfg_lang_registersubject"]; //   " Your new requested password";

                string sRawPassword = DSP.BAL.Basic.GenerateRandomPasswordUsingGUID(6);
                string sNewPassword = DSP.BAL.Basic.EncodePassword(sRawPassword);
                string sFullName = DSP.BAL.Basic.FormatStringForSQL(txtName.Text.Trim());

                MembershipUser u1 = Membership.CreateUser(txtEmail.Text, sNewPassword, txtEmail.Text);

                Roles.AddUserToRole(txtEmail.Text, "Applicant");

                string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, ";
                strSQL += " Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_ProviderUserKey, Users_IsActivated) values ('{0}','{1}', 0, '{2}',  getdate(),'0','0','0','0','0','{3}', 0); select scope_identity() as id;";
                dsUser = DSP.DAL.SQL.GetRecordsBySQL(string.Format(strSQL, txtEmail.Text, sNewPassword, sFullName, u1.ProviderUserKey));

                string sActivationURL = string.Format("/Activate.aspx?un={0}&ac={1}", txtEmail.Text, u1.ProviderUserKey);

                Hashtable ht = new Hashtable();
                ht.Clear();
                ht.Add("[USER_FULLNAME]", sFullName);
                ht.Add("[USER_PASSWORD]", sRawPassword);
                ht.Add("[USER_EMAIL]", txtEmail.Text);
                ht.Add("[ACTIVATIONURL]", sActivationURL);

                emailReminder.sBody = DSP.BAL.DBL.GetEmailTemplateBodyReplaced(2, ht); //Reister


                DSP.BAL.ActivationMail.InsertActivationMail(txtEmail.Text, sRawPassword, emailReminder.sBody.ToString());


                emailReminder.SendMail();

                InvalidRegisterCredentialsMessage.Visible = true;
                InvalidRegisterCredentialsMessage.Text = "An email has been sent with your activation link and password.";
                txtEmail.Text = "";

                Page.Session["RegisteredEmail"] = txtEmail.Text;
                Response.Redirect("~/Registered.aspx");
            }
        }
        else
        {
            InvalidRegisterCredentialsMessage.Visible = true;
            InvalidRegisterCredentialsMessage.Text = "This email is already registered with us. If you have difficulties please reset your password or please contact us for more help.";
       
        }

    }

    private void getCustomisedUrl( MembershipUser u1 )
    {

      

        if (Roles.IsUserInRole(u1.UserName, "Applicant") == true)
        {

            Response.Redirect("~/Application/Default.aspx");
        }

      

        if (Roles.IsUserInRole(u1.UserName, "Admin") == true)
        {
            Response.Redirect("~/Portal/Account/Default.aspx");
        }

        if (Roles.IsUserInRole(u1.UserName, "SalesAdvisor") == true)
        {
            Response.Redirect("~/Portal/SalesAdvisor/Account.aspx");
        }

    }

    public static bool IsUserInRole(string username , string roleName)
    {
        return IsUserInRole(username, roleName);
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
