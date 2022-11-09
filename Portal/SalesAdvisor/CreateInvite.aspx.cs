using DSP.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portal_Admin_CreateInvite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hideInitialControls();
            //updateEmailTemplate();
            setDefaultPassword();
            ddl_Courses_SelectedIndexChanged(null, null);

            //clear temp doc files folder
            deleteTempFilesForInvites();
        }
    }

    public void hideInitialControls()
    {
        btn_AddInvite.Visible = false;
        pnlEmail.Visible = false;
    }

    public string GetTempFilesForInvites()
    {
        string pathToSave = ConfigurationManager.AppSettings["cfg_portaldata_path"] + "InvitesTempDocs" + "\\" + Membership.GetUser().UserName + "\\";
        if (System.Configuration.ConfigurationManager.AppSettings["cfg_test"] == "true")
        {
            pathToSave = HttpContext.Current.Server.MapPath("~/temp/InvitesTempDocs/" + "\\" + Membership.GetUser().UserName + "\\");

        }
        return pathToSave;
    }

    public void deleteTempFilesForInvites()
    {
        string pathToSave = GetTempFilesForInvites();


        if (Directory.Exists(pathToSave))
        {
            try
            {
                Directory.Delete(pathToSave, true);

            }
            catch (Exception ex)
            {
                Log.log(ex.Message, "AddInvite.aspx.cs>deleteTempFilesForInvites()", "Error");
            }

        }


    }
    #region "--- Create invite     ->   "
    public void btn_SeeInvite_Click(object sender, EventArgs e)
    {
        string sCourseId = ddl_Courses.SelectedValue.ToString();
        if (sCourseId == "")
        {
            msgbox.ShowError("Error, please refresh the page and try again.");
            return;
        }
        bool bCheckAllOk = validateControls();

        if (!bCheckAllOk)
        {
            btn_AddInvite.Visible = false;
            return;
        }

        btn_AddInvite.Visible = true;
        pnlEmail.Visible = true;
    }
    public void btn_AddInvite_Click(object sender, EventArgs e)
    {
        string sCourseId = ddl_Courses.SelectedValue.ToString();
        if (sCourseId == "")
        {
            msgbox.ShowError("Error, please refresh the page and try again.");
            return;
        }

        bool bCheckAllOk = validateControls();

        if (!bCheckAllOk)
        {
            btn_AddInvite.Visible = false;
            return;
        }

        Hashtable htAttachments = new Hashtable();
        string pathToSave = GetTempFilesForInvites();
        if (Directory.Exists(pathToSave))
        {
            string[] filesToAttach = Directory.GetFiles(pathToSave);
            for (int i = 0; i < filesToAttach.Length; i++)
            {
                string file = filesToAttach[i];
                htAttachments.Add("filename", file);
            }
        }
        //return; ///xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        if (userExistAppPortal(txtEmail.Text.Trim()))
        {
            msgbox.ShowError("The email has been used for an existing account on App Portal. Please delete that user from App Portal and try again.");
            return;
        }
        int iUserId = DBL.GetUser_UserId(Membership.GetUser().UserName);
        if (iUserId == 0)
        {
            msgbox.ShowError("Please login again.");
            return;
        }

        createAppPortalAccountDB(txtEmail.Text.ToLower().Trim(), txtPassword.Text.Trim(), DSP.BAL.Basic.FormatStringForSQL(txtFirstname.Text.Trim() + " " + txtLastName.Text.Trim()), int.Parse(ddl_Courses.SelectedValue));

        if (addInviteToDB())
        {
            sendEmailForInviteWithAttachments(htAttachments);
            htAttachments = null;
            deleteTempFilesForInvites();  //clear folder of attachments

            msgbox.ShowSuccess("Email has been sent.");

            setDefaultPassword();
            txtEmail.Text = "";
            txtFirstname.Text = "";
            txtLastName.Text = "";
            fckEditor.Value = "";

            //all ok make is invisible again
            btn_AddInvite.Visible = false;
            Log.log("Invite sent successfully.", "Addinvite.aspx.cs>btn_AddInvite_Click", "Success");
        }
    }

    #endregion

    #region "--- check existing invites     ->   "
    private bool checkExistingEmail()
    {
        bool bFound = false;
        if (DSP.BAL.Basic.CheckIfItemExists(DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM [AppPortal_Invites] WHERE API_IsDeleted = 0 AND API_Email ='" + txtEmail.Text.Trim().ToLower() + "'")))
        {
            bFound = true;
        }
        return bFound;
    }
    #endregion

    #region "---  load temlate email    ->   "

    public string BodyContents = "";

    private void updateEmailTemplate()
    {
        Hashtable ht = new Hashtable();
        ht.Add("[LEARNER]", txtFirstname.Text.Trim() + " " + txtLastName.Text.Trim());
        ht.Add("[COURSENAME]", ddl_Courses.SelectedItem.Text);
        ht.Add("[LEARNEREMAIL]", txtEmail.Text.Trim().ToLower());
        ht.Add("[LEARNERPASSWORD]", txtPassword.Text.Trim());
        ht.Add("[APPPORTALURL]", "http://www.accessskills.co.uk/apply");

        string BodyContents = DBL.GetEmailTemplateBodyReplacedByCode("API001", ht);
        lbl_AppPortal_Body.Text = BodyContents;
        fckEditor.Value = BodyContents;
    }

    #endregion

    #region "---  update template email body    ->   "

    private bool validateControls()
    {
        bool bAllOk = true;

        //check if firstname is ok
        //check if last name is ok
        //check if email is ok
        //check if password is ok

        if (txtFirstname.Text.Trim() == "" || txtFirstname.Text.Length < 2)
        {
            msgbox.ShowError("First Name can not be empty or lower than 2 characters.");
            return false;
        }
        if (txtLastName.Text.Trim() == "" || txtLastName.Text.Length < 2)
        {
            msgbox.ShowError("Last Name can not be empty or lower than 2 characters.");
            return false;
        }

        if (txtEmail.Text.Trim() == "" || txtEmail.Text.Length <= 5 || txtEmail.Text.Length >= 100)
        {
            msgbox.ShowError("Email can not be empty or lower than 5 characters or greater than 100 characters.");
            return false;
        }
        if (txtPassword.Text.Trim() == "" || txtPassword.Text.Length < 7)
        {
            msgbox.ShowError("Password can not be empty or lower than 8 characters.");
            return false;
        }

        if (checkExistingEmail())
        {
            msgbox.ShowError("This email is already been used.");
            return false;
        }


        msgbox.Visible = false;

        if (bAllOk)
        {
            updateEmailTemplate();
        }

        return bAllOk;
    }
    #endregion

    private void setDefaultPassword()
    {
        txtPassword.Text = DSP.BAL.Basic.GenerateRandomPasswordUsingGUID(8);
    }
    #region "---   save invite to db   ->   "

    private bool filesToDatabase(string pathToSave, string UserId, string identifier, string fileName, int LearnerId)
    {
        if (UserId != "") // ListAllLearners.SelectedRow != null) //x  Session["curr_id"].ToString();
        {
            fileName = fileName.Split('.')[0];
            string query = "INSERT INTO LearnerSignUpDocs(";
            query += "   LearnerId ";
            query += " , DocName ";
            query += " , DocPath ";
            query += " , UploadDate";
            query += " , IsActive";
            query += " , UploadedBy";
            query += " ) VALUES ( ";
            query += " " + LearnerId;
            query += " , '" + fileName + "'";
            query += " , '" + pathToSave + "'";
            query += " , getdate() ";
            query += " , 1 ";
            query += " , " + UserId;
            query += " )";
            try
            {
                DSP.DAL.SQLOSCA.ExecuteSQL(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private bool addInviteToDB()
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CourseId", ddl_Courses.SelectedValue);
        ht.Add("@CourseTitle", ddl_Courses.SelectedItem.Text);
        ht.Add("@API_Email", txtEmail.Text.ToLower().Trim());
        ht.Add("@API_FirstName", DSP.BAL.Basic.FormatStringForSQL(txtFirstname.Text.Trim()));
        ht.Add("@API_LastName", DSP.BAL.Basic.FormatStringForSQL(txtLastName.Text.Trim()));
        ht.Add("@API_Password", DSP.BAL.Basic.FormatStringForSQL(txtPassword.Text.Trim()));
        ht.Add("@API_EmailBody", DSP.BAL.Basic.FormatStringForSQL(fckEditor.Value));
        ht.Add("@API_EnteredByUser", Membership.GetUser().UserName);
        ht.Add("@API_EnteredByUserId", DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName));

        bool bExecuted = DSP.DAL.SQL.ExecuteSPByHashTable("SP_AppPortal_InsertInvite", ht);

        return bExecuted;
    }


    #endregion

    #region "---   send email invite ->   "

    public bool sendEmailForInvite()
    {
        string strEmailBody = fckEditor.Value;
        string strFirstName = txtFirstname.Text.Trim();
        string strLastname = txtLastName.Text.Trim();
        string strEmail = txtEmail.Text.ToLower().Trim();
        string strEmailCopy = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        string strEmailFrom = ConfigurationManager.AppSettings["cfg_email_support_from"];
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

    public bool sendEmailForInviteWithAttachments(Hashtable htAttachments)
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

    #endregion

    #region "---- create app portal account "

    private bool userExistAppPortal(string sEmail)
    {
        DataSet ds = null;
        ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM Users WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL(sEmail) + "' ");

        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            //not found so go on create one

            return false;
        }
        return true;
    }

    private bool ValueExist(int checkNum, int[] myNums)
    {
        bool exists = false;
        for (int i = 0; i < myNums.Length; i++)
        {
            if (checkNum == myNums[i])
            {
                exists = true;
                break;
            }
        }
        return exists;
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
                CourseLevel = 20;
                break;
            case "Level 3 CYP":
                CourseLevel = 30;
                break;
            case "Level 3 Adult":
                CourseLevel = 31;
                break;
            case "Level 3 Mental Health":
                CourseLevel = 32;
                break;
            case "Level 4 Adult":
                CourseLevel = 40;
                break;
            case "Level 5 CYP":
                CourseLevel = 50;
                break;
            case "Level 5 Adult":
                CourseLevel = 51;
                break;
            case "Level 5 Apprenticeship":
                CourseLevel = 52;
                break;
            case "Level 5 Apprentship":
                CourseLevel = 52;
                break;

            case "Short Course":
                CourseLevel = 80;
                break;
            default:
                CourseLevel = 50;
                break;
        }
        return CourseLevel;
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
    #endregion

    #region "---- course selection "

    protected void ddl_Courses_SelectedIndexChanged(object sender, EventArgs e)
    {
        msgbox.Visible = false;

        string sCourseId = ddl_Courses.SelectedValue.ToString();

        if ((sCourseId != "-1") || (sCourseId != ""))
        {
            Page.Session.Add("AppPortal_CourseId", sCourseId);
            lbl_AppPortal_CourseId.Text = sCourseId;
        }
        else
        {

        }
    }

    #endregion

}