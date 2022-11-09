<%@ WebHandler Language="C#" Class="AppPortalHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data;
using DSP.BAL;
using System.Web.Security;

public class AppPortalHandler : IHttpHandler
{
    UtilityFunctions objUtils = new UtilityFunctions();
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.QueryString.Count > 0)
            {
                string id = context.Request.QueryString["id"];
                string resp = resendEmailInvite(id);

                context.Response.Write(resp);
            }
        }
        catch
        {
            context.Response.Write("There is some error resending email. Please contact admin.");
            return;
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public void update(int id)
    {

    }

    private bool sendEmailForInvite(string sContent, string sFirstname, string sLastname, string sEmail)
    {

        string strEmailBody = sContent;
        string strFirstName = sFirstname;
        string strLastname = sLastname;
        string strEmail = sEmail;
        string strEmailCopy = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        string strEmailFrom = ConfigurationManager.AppSettings["cfg_portal_email_studensupport"];
        string strEmailSubject = ConfigurationManager.AppSettings["cfg_email_template_app_portal_invite_subject"];

        bool bSuccess = true;
        string sErrorMsg = "";

        try
        {
            //  ================================
            ASPMail emailNewUser = new ASPMail();
            emailNewUser.sTo = strEmail;
            emailNewUser.sTo = strEmailCopy; //remove from Live
            emailNewUser.sFrom = strEmailFrom;
            emailNewUser.sSubject = strEmailSubject;

            emailNewUser.sBody = strEmailBody;

            try
            {
                emailNewUser.SendMail();
            }
            catch (Exception exx)
            {
                bSuccess = false;
                sErrorMsg = exx.Message;
            }
        }
        catch (Exception ex)
        {
            Log.log(ex.Message, "AppPortalHandlerResend.aspx.cs/sendEmailForInvite()", "Error");

            bSuccess = false;
            sErrorMsg = ex.Message;
        }
        return bSuccess;
    }
    string password = DSP.BAL.Basic.GenerateRandomPasswordUsingGUID(8).Trim();
    private string resendEmailInvite(string id)
    {
        string sContent = ""; string sFirstname = ""; string sLastname = ""; string sEmail = ""; string sCourseId = ""; string sCourseTitle = "";

        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("Select API_CourseId, API_CourseTitle,API_EmailBody,API_Email,API_FirstName,API_LastName FROM AppPortal_Invites WHERE API_ID = " + id + " ;");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            sContent = ds.Tables[0].Rows[0]["API_EmailBody"].ToString();
            sFirstname = ds.Tables[0].Rows[0]["API_FirstName"].ToString();
            sLastname = ds.Tables[0].Rows[0]["API_LastName"].ToString();
            sEmail = ds.Tables[0].Rows[0]["API_Email"].ToString();
            sCourseId = ds.Tables[0].Rows[0]["API_CourseId"].ToString();
            sCourseTitle = ds.Tables[0].Rows[0]["API_CourseTitle"].ToString();
        }
        string strID = id;
        string strEmail = sEmail;
        string strUser = DBL.GetUser_UserId(Membership.GetUser().UserName).ToString();
        if (strUser == "0" || strUser == "")
        {
            return "Please login again";
        }
        string Username = strEmail.ToLower().Trim();
        System.Collections.Hashtable ht = new System.Collections.Hashtable();
        ht.Add("@API_Id", strID);

        //WHY DELETING? we just want to resent that email again!
        /*
         bool bExecuted = DSP.DAL.SQL.ExecuteSPByHashTable("SP_AppPortal_DeleteInvite", ht);

        // return bExecuted;
        string strUserName = Username.Trim();

        Membership.DeleteUser(strUserName);

        string strSQL = "DELETE FROM Users WHERE Users_Username = '{0}';";
        DSP.DAL.SQL.ExecuteScalar(string.Format(strSQL, strUserName));

        //add new invite
        updateEmailTemplate(sFirstname, sLastname, sEmail, "");

        createAppPortalAccountDB(sEmail.ToLower().Trim(), password.Trim(), DSP.BAL.Basic.FormatStringForSQL(sFirstname.Trim() + " " + sLastname.Trim()), int.Parse(sCourseId));

        if (addInviteToDB(sFirstname, sLastname, sEmail, int.Parse(sCourseId), sCourseTitle))
        {
            sendEmailForInviteWithAttachments(sEmail);
            Log.log("Invite re sent successfully.", "AppPortalHandlerResend.ashx.cs>resendEmailInvite", "Success");
        }
        */

        sendEmailAgainForInvite(sEmail, sContent);
        Log.log("Invite re-sent successfully.", "AppPortalHandlerResend.ashx.cs>resendEmailInvite", "Success");
   

        return "Email has been resent successfully";
    }
    public string BodyContents = "";

    private void updateEmailTemplate(string firstName, string lastName, string email, string courseTitle)
    {
        System.Collections.Hashtable ht = new System.Collections.Hashtable();
        ht.Add("[LEARNER]", firstName.Trim() + " " + lastName.Trim());
        ht.Add("[COURSENAME]", courseTitle);
        ht.Add("[LEARNEREMAIL]", email.Trim().ToLower());
        ht.Add("[LEARNERPASSWORD]", password);
        ht.Add("[APPPORTALURL]", "http://www.accessskills.co.uk/apply");
        string BodyContents = DBL.GetEmailTemplateBodyReplacedByCode("API001", ht);
    }

    public void createAppPortalAccountDB(string sEmail, string sRawPassword, string sDisplayName, int iCourseId)
    {
        try
        {
            string Username = sEmail.ToLower().Trim();
            string sPassword = DSP.BAL.Basic.EncodePassword(sRawPassword);
            string sFullName = sDisplayName.Trim();
            int iCourseLevel = 5;

            iCourseLevel = getCourseLevelForCourseId(iCourseId);


            MembershipCreateStatus status;

            MembershipUser newUserForAppPortal;
            newUserForAppPortal = System.Web.Security.Membership.Providers["AppPortalMembershipProvider"].GetUser(Username, false);
            if (newUserForAppPortal == null)
            {
                string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_Id_LearnerContacts, Users_Email, Users_IsActivated, Users_Id_Course, Users_CourseLevel ) ";
                strSQL += " values ('{0}','{1}', 1, '{2}',  getdate(),'0','1','0','0','0', '{3}', '{4}', '1', '{5}', '{6}' ); select scope_identity() as id;";
                DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(string.Format(strSQL, Username, sPassword, sDisplayName, "", sEmail, iCourseId, iCourseLevel));

                string[] user = new string[] { Username };
                string[] userRole = new string[] { "Applicant" };
                newUserForAppPortal = System.Web.Security.Membership.Providers["AppPortalMembershipProvider"].CreateUser(Username, sPassword, sEmail, null, null, true, null, out status);
                if (status == MembershipCreateStatus.Success)
                {
                    AppPortalRoleProvider appRoleProvider = Roles.Providers["AppPortalRoleProvider"] as AppPortalRoleProvider;
                    if (appRoleProvider.RoleExists("Applicant"))
                    {
                        appRoleProvider.AddUsersToRoles(user, userRole);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DSP.BAL.Log.WriteLogTxt(String.Format("createAppPortalAccountDB() | ERROR:  {0} ##### {1}", ex.Message, ex.StackTrace));
        }
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

/* public bool sendEmailForInviteWithAttachments(Hashtable htAttachments)
    {
        string strEmailBody = fckEditor.Value;
        string strFirstName = txtFirstname.Text.Trim();
        string strLastname = txtLastName.Text.Trim();
        string strEmail = txtEmail.Text.ToLower().Trim();
        string strEmailCopy = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        string strEmailFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
        string strEmailSubject = ConfigurationManager.AppSettings["cfg_email_template_app_portal_invite_subject"];

        bool bError = false;
        string sErrorMsg = "";

        try
        {
            //  ================================
            ASPMail emailNewUser = new ASPMail();
            emailNewUser.sTo = strEmail;
            //  emailNewUser.sTo = strEmailCopy; //remove from Live
            emailNewUser.sFrom = strEmailFrom;
            emailNewUser.sSubject = strEmailSubject;

            emailNewUser.sBody = strEmailBody;

            emailNewUser.htAttchmentFiles = htAttachments;

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
            Log.log(ex.Message, "Addinvite.aspx.cs>sendEmailForInvite()", "Error");
            return false;
        }
        return true;
    }
*/

    public bool sendEmailAgainForInvite(string emailTo, string bodyContents)
    {
        string strEmailBody = bodyContents;
        string strEmail = emailTo.ToLower().Trim();
        string strEmailCopy = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        string strEmailFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
        string strEmailSubject = ConfigurationManager.AppSettings["cfg_email_template_app_portal_invite_subject"];
             
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
                
                sErrorMsg = exx.Message;
            }
        }
        catch (Exception ex)
        {
            Log.log(ex.Message, "Addinvite.aspx.cs>sendEmailForInviteWithAttachments()", "Error");
            return false;
        }
        return true;

    }
    public bool sendEmailForInviteWithAttachments(string email)
    {
        string strEmailBody = BodyContents;
        string strEmail = email.ToLower().Trim();
        string strEmailCopy = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        string strEmailFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
        string strEmailSubject = ConfigurationManager.AppSettings["cfg_email_template_app_portal_invite_subject"];

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
            Log.log(ex.Message, "Addinvite.aspx.cs>sendEmailForInviteWithAttachments()", "Error");
            return false;
        }
        return true;

    }
    private bool addInviteToDB(string firstName, string lastName, string email, int courseId, string courseTitle)
    {
        System.Collections.Hashtable ht = new System.Collections.Hashtable();
        ht.Add("@CourseId", courseId);
        ht.Add("@CourseTitle", courseTitle);
        ht.Add("@API_Email", email.ToLower().Trim());
        ht.Add("@API_FirstName", DSP.BAL.Basic.FormatStringForSQL(firstName.Trim()));
        ht.Add("@API_LastName", DSP.BAL.Basic.FormatStringForSQL(lastName.Trim()));
        ht.Add("@API_Password", DSP.BAL.Basic.FormatStringForSQL(password.Trim()));
        ht.Add("@API_EmailBody", DSP.BAL.Basic.FormatStringForSQL(BodyContents));
        ht.Add("@API_EnteredByUser", Membership.GetUser().UserName);
        ht.Add("@API_EnteredByUserId", DSP.BAL.Session.GetSessionUserId());

        bool bExecuted = DSP.DAL.SQL.ExecuteSPByHashTable("SP_AppPortal_InsertInvite", ht);

        return bExecuted;
    }
}