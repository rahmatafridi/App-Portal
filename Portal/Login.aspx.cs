using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;
using System.Security.Principal;
 
public partial class Account_Login : System.Web.UI.Page
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
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

        //string ss = Request.QueryString["ReturnUrl"];
      //  Response.Redirect(ss);

    }



    //protected void LoginButton_Click(object sender, EventArgs e)
    //{

    //    string ss = "";
    //    DataSet dsUser = null;
    //    Boolean bLogin = false;

    //  /*  dsUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT Users_ID, Users_Id_AccessLevel, Users_IsActive FROM Users WHERE Users_UserName = '" +  + "'");
    //    if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
    //    {
    //        MembershipUser u1 = Membership.GetUser(UserName.Text);

    //    }*/


    //}

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

        string sSQL = "SELECT * FROM Users WHERE Users_UserName = '" + UserName.Text + "' AND Users_Password = '" + md5PW + "' ORDER BY Users_IsActive DESC ";
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


                if (Roles.IsUserInRole(u1.UserName, "Guest") == true)
                {

                   // Response.Redirect("~/Portal/Guest/Default.aspx");
                }

                strIdAssessor = dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString();
                //strIdIV = dsUser.Tables[0].Rows[0]["Users_Id_IVContacts"].ToString();
                strUsers_Id_OSCA = dsUser.Tables[0].Rows[0]["Users_Id_OSCA"].ToString();

                if (Roles.IsUserInRole(u1.UserName, "Assessor") == true)
                {
                    strIdAssessor = dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString();
                
                   // Response.Redirect("~/Portal/Assessors/Default.aspx");
                }


                if (Roles.IsUserInRole(u1.UserName, "Learner") == true)
                {
                    strIdLearner = dsUser.Tables[0].Rows[0]["Users_Id_LearnerContacts"].ToString();

                    // Response.Redirect("~/Portal/Assessors/Default.aspx");
                }



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
               // }

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


    private void getCustomisedUrl( MembershipUser u1 )
    {

        if (Roles.IsUserInRole(u1.UserName, "Assessor") == true)
        {
         
             Response.Redirect("~/Portal/Assessors/Default.aspx");
        }


        if (Roles.IsUserInRole(u1.UserName, "Learner") == true)
        {


            Response.Redirect("~/Portal/Learners/MyCourseSummary.aspx");
        }



        //if (Roles.IsUserInRole(u1.UserName ,"IV") == true)
        //{
        //    strIdIV = dsUser.Tables[0].Rows[0]["Users_Id_IVContacts"].ToString();
        //}


        if (Roles.IsUserInRole(u1.UserName, "Admin") == true)
        {
           // string strs = "yes";
            Response.Redirect("~/Portal/Account/Default.aspx");
        }
 


    }

    public static bool IsUserInRole(string username , string roleName)
    {
      //  return IsUserInRole(GetCurrentUserName(), roleName);
        return IsUserInRole(username, roleName);
    }

    //private static string GetCurrentUserName()
    //{
    //    IPrincipal currentUser =  GetCurrentUser();
    //    if ((currentUser != null) && (currentUser.Identity != null))
    //    {
    //        return currentUser.Identity.Name;
    //    }
    //    return string.Empty;
    //}


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
