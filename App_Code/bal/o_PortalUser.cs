using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Web.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Collections;
using QMS_BLL;


namespace DSP.BAL
{

    public class PortalUser
    {

        public int _learner_id;
        public PortalUser()
        {

        }
        
        public bool Step1_CreatePortalUser(int iLearnerId, string sDisplayName, string sPassword, string sEmail)
        {
            DataSet dsUser;
            MembershipUser newUser;

            string strPass = DSP.BAL.Basic.EncodePassword(sPassword);
            newUser = System.Web.Security.Membership.GetUser(iLearnerId.ToString());

            if (newUser == null)
            {
                // Create the Learner User into Portal
                //string sLearnerEmail = DSP.BAL.OSCA_Learner.GetLearnerEmailById(strUser);
                 
                string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_Id_LearnerContacts, Users_Email) ";
                strSQL += " values ('{0}','{1}', 1, '{2}',  getdate(),'0','1','0','0','0', '{3}', '{4}'); select scope_identity() as id;";
                dsUser = DSP.DAL.SQLPortal.GetRecordsBySQL(string.Format(strSQL, iLearnerId.ToString(), strPass, sDisplayName, iLearnerId.ToString(), sEmail));

                Hashtable ht = new Hashtable();
                ht.Add("@ApplicationName", "/");
                ht.Add("@UserName", iLearnerId.ToString());
                ht.Add("@Password", strPass);
                ht.Add("@Email", sEmail);
                ht.Add("@PasswordQuestion", "''");
                ht.Add("@PasswordAnswer", "''");
                DSP.DAL.SQLPortal.ExecuteSPByHashTable("aspnet_CreateUser", ht);

                DSP.BAL.Log.WriteLogTxt(String.Format("Step1_CreatePortalUser()  aspnet_CreateUser... user is added to the portal | UserName: {0} | strPass: {1} | sEmail: {2} | sDisplayName: {3} ", iLearnerId.ToString(), strPass, sEmail, sDisplayName));

                Hashtable ht2 = new Hashtable();
                //  ht.Add("@rolename", "Learner");
                // ht.Add("@membername", strUser);
                //  DSP.DAL.SQLPortal.ExecuteSPByHashTable("sp_addrolemember", ht2);
                // aspnet_UsersInRoles_AddUsersToRoles '/', '5964','Learner', null

                //commented out old method for adding roles in portal db and added new mthod.
                //ht2.Add("@ApplicationName", "/");
                //ht2.Add("@RoleNames", "Learner");
                //ht2.Add("@UserNames", strUser);
                //ht2.Add("@CurrentTimeUtc", "");
                //DSP.DAL.SQLPortal.ExecuteSPByHashTable("aspnet_UsersInRoles_AddUsersToRoles", ht2);
                //////string[] user = new string[] { strUser };
                //////string[] userRole = new string[] { "Learner" };
                //////PortalRoleProvider portalRoleProvider = Roles.Providers["PortalRoleProvider"] as PortalRoleProvider;
                //////if (portalRoleProvider.RoleExists("Learner"))
                //////{
                //////    portalRoleProvider.AddUsersToRoles(user, userRole);
                //////}

                ht2.Add("@ApplicationName", "/");
                ht2.Add("@RoleNames", "Learner");
                ht2.Add("@UserNames", iLearnerId.ToString());
                ht2.Add("@CurrentTimeUtc", "");
                DSP.DAL.SQLPortal.ExecuteSPByHashTable("aspnet_UsersInRoles_AddUsersToRoles", ht2);

                DSP.BAL.Log.WriteLogTxt(String.Format("Step1_CreatePortalUser() user added to role Learner"));

                //newUser = Membership.CreateUser(strUser, strPass);
                //Roles.AddUserToRole(strUser, "Learner");

                //   DSP.BAL.Log.WriteLogTxt(String.Format("Step1_CreatePortalUser() ERROR OCCURED: {0} "));


                return true;
            }
            else
            {
                return false;
            }

        }

        public void Step2_AddUsertoQCSDB(int iLearnerId, string sPassword, string sEmail, string sDisplayName)
        {
            DSP.BAL.Log.WriteLogTxt(String.Format("Step2_AddUsertoQCSDB() | iLearnerId: {0} | sPassword: {1} | sEmail: {2} | sDisplayName: {3} ", iLearnerId, sPassword, sEmail, sDisplayName));
             
            try
            {
                string Username = iLearnerId.ToString();
                //Add User to QCS DB
                string role = "Trial User";
                DateTime validUntil = DateTime.Now.AddYears(1);
                bool IsLoginFirstTime = true;
                string clientId = "1741";
                MembershipUser newUserForQcs;
                newUserForQcs = System.Web.Security.Membership.Providers["QCSMembershipProvider"].GetUser(Username, false);
                MembershipCreateStatus status;
                if (newUserForQcs == null)
                {
                    newUserForQcs = System.Web.Security.Membership.Providers["QCSMembershipProvider"].CreateUser(Username, sPassword, sEmail, null, null, true, null, out status);
                    // get the GUID of the user just created     
                    MembershipUser myObject = System.Web.Security.Membership.Providers["QCSMembershipProvider"].GetUser(Username, false);
                    if (status == MembershipCreateStatus.Success)
                    {
                        string UserID = myObject.ProviderUserKey.ToString();
                        string[] user = new string[] { Username };
                        string[] userRole = new string[] { "Student", "Trial User" };
                        QCSRoleProvider qcsRoleProvider = Roles.Providers["QCSRoleProvider"] as QCSRoleProvider;
                        if (qcsRoleProvider.RoleExists("Student"))
                        {
                            qcsRoleProvider.AddUsersToRoles(user, userRole);
                        }

                        int user_Id = QMS_BLL.Membership.GetUserId(UserID);

                        SavePermissions(role, user_Id, int.Parse(clientId));
                        int MaxDocs = 1000;
                        string UserMobileNo = "Null";
                        int webEnquiry_ID = 0;
                        int? webEnquiryTypeId = null;
                        QMS_BLL.Membership.CreateUser(UserID, Username, sDisplayName, sDisplayName, int.Parse(clientId), validUntil, user_Id, MaxDocs, 233, UserMobileNo, webEnquiryTypeId, IsLoginFirstTime, 0);

                        DSP.BAL.Log.WriteLogTxt(String.Format("Step2_AddUsertoQCSDB() | User has been created in QCS"));
                        
                    }
                }
            }
            catch (Exception ex)
            {
                DSP.BAL.Log.WriteLogTxt(String.Format("Step2_AddUsertoQCSDB() | ERROR:  {0} ##### {1}", ex.Message , ex.StackTrace));

            }
        }

        public bool Step3_SendAccountCreationNotifications(int iLearnerId, string sDisplayName, string sPassword, string sRecipientEmail, bool bCopyToLearner)
        {
            string sEmailSubject = "";
            string sEmailBody = "";
            string sEmailFrom = "";
            if (sRecipientEmail != "")
            {
                //first prepare the email 
                DSP.BAL.EmailNotifications.PrepareMail_LoginDetailsLearner(ref sEmailFrom, ref sEmailSubject, ref sEmailBody, iLearnerId.ToString(), sPassword, sRecipientEmail, sDisplayName);
                //send to learner?
                //   DSP.BAL.EmailNotifications.SendMail_LoginDetailsLearner(iLearnerId.ToString(), sPassword, sRecipientEmail, sDisplayName);
                if (bCopyToLearner)
                {
                    DSP.BAL.EmailNotifications.SendFormattedMail(sEmailSubject, sEmailFrom, sRecipientEmail, sEmailBody);
                  //  DSP.BAL.EmailNotifications.SendMail_LoginDetails(sEmailFrom, sEmailSubject, sEmailBody, iLearnerId.ToString(), sPassword, sRecipientEmail, sDisplayName);
                }

                //copy to admin
                //if (ConfigurationManager.AppSettings["cfg_test"] == "true")
                //{
                //    sRecipientEmail = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
                //}
                //else {
                //    sRecipientEmail = ConfigurationManager.AppSettings["cfg_portal_email_admin"];
                //}
                sRecipientEmail = ConfigurationManager.AppSettings["cfg_portal_email_admin"];
                DSP.BAL.EmailNotifications.SendFormattedMail(sEmailSubject + " [ADMIN]", sEmailFrom, sRecipientEmail, sEmailBody);
                sRecipientEmail = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
                DSP.BAL.EmailNotifications.SendFormattedMail(sEmailSubject + " [DEV-COPY]", sEmailFrom, sRecipientEmail, sEmailBody);

                //DSP.BAL.EmailNotifications.SendMail_LoginDetails(sEmailFrom, sEmailSubject, sEmailBody, iLearnerId.ToString(), sPassword, sRecipientEmail, sDisplayName);

                //register into History?

                //save email to learner notes as output
                Step3a_SaveAccountCreationNotificationsToNotes(iLearnerId, sEmailBody);


            }

            return true;
        }


        public bool Step3a_SaveAccountCreationNotificationsToNotes(int iLearnerId, string sEmailContent)
        {
            //save email to learner notes as output

            OscaLearner ol = new OscaLearner();
            ol.InsertLearnerNote(iLearnerId, sEmailContent, "291");
            

            return true;
        }

        public void SavePermissions(string role, int user_Id, int clientId)
        {
            string query = "";
            switch (role)
            {
                case "User":
                    query = "SELECT Module_ID FROM Modules WHERE Module_AvailableToUsers  = 1";
                    break;
                case "Supervisor":
                    query = "SELECT Module_ID FROM Modules WHERE Module_AvailableToSupervisors  = 1";
                    break;
                case "Trial User":
                    query = "SELECT Module_ID FROM Modules WHERE Module_AvailableToTrialUsers  = 1";
                    break;
                case "Administrator":
                    query = "SELECT Module_ID FROM Modules WHERE Module_AvailableToAdministrators  = 1";
                    break;
            }
            int client_Id = clientId;
            string selectedModules = "";
            int packagePurchased = Clients.GetPackageIdForClient(client_Id);
            char[] toTrim = { ',' };
            if (packagePurchased == 10)
                selectedModules = "4,17,18,19,";
            else
            {
                DataSet dsModules = Modules.GetModulesForRole(query);
                foreach (DataTable table in dsModules.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        selectedModules += row["Module_ID"] + ",";
                    }
                }
            }
            Modules.SaveModulePermissions(selectedModules.TrimEnd(toTrim), user_Id, client_Id);
        }
    }//PortalUser
} //DSP.BAL



//protected void AddUsertoQCSDB(int iLearnerId, string sPassword, string sEmail, string sDisplayName)
//{
//    DSP.BAL.Log.WriteLogTxt(String.Format("AddUsertoQCSDB() | iLearnerId: {0} | sPassword: {1} | sEmail: {2} | sDisplayName: {3} ", iLearnerId, sPassword, sEmail, sDisplayName));


//    try
//    {
//        string Username = iLearnerId.ToString();
//        //Add User to QCS DB
//        string role = "Trial User";
//        DateTime validUntil = DateTime.Now.AddYears(1);
//        bool IsLoginFirstTime = true;
//        string clientId = "1741";
//        MembershipUser newUserForQcs;
//        newUserForQcs = System.Web.Security.Membership.Providers["QCSMembershipProvider"].GetUser(Username, false);
//        MembershipCreateStatus status;
//        if (newUserForQcs == null)
//        {
//            newUserForQcs = System.Web.Security.Membership.Providers["QCSMembershipProvider"].CreateUser(Username, sPassword, sEmail, null, null, true, null, out status);
//            // get the GUID of the user just created     
//            MembershipUser myObject = System.Web.Security.Membership.Providers["QCSMembershipProvider"].GetUser(Username, false);
//            if (status == MembershipCreateStatus.Success)
//            {
//                string UserID = myObject.ProviderUserKey.ToString();
//                string[] user = new string[] { Username };
//                string[] userRole = new string[] { "Student", "Trial User" };
//                QCSRoleProvider qcsRoleProvider = Roles.Providers["QCSRoleProvider"] as QCSRoleProvider;
//                if (qcsRoleProvider.RoleExists("Student"))
//                {
//                    qcsRoleProvider.AddUsersToRoles(user, userRole);
//                }

//                int user_Id = QMS_BLL.Membership.GetUserId(UserID);

//                SavePermissions(role, user_Id, int.Parse(clientId));
//                int MaxDocs = 1000;
//                string UserMobileNo = "Null";
//                int webEnquiry_ID = 0;
//                int? webEnquiryTypeId = null;
//                QMS_BLL.Membership.CreateUser(UserID, Username, sDisplayName, sDisplayName, int.Parse(clientId), validUntil, user_Id, MaxDocs, 233, UserMobileNo, webEnquiryTypeId, IsLoginFirstTime, 0);
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//    }
//}



//public int CreatePortalLearnerUser(ApplicationForm app)
//{


//    string sql = "";

//    Hashtable ht = new Hashtable();

//    ht.Add("Learner_Ref", "");

//    int iTitle = 1;
//    switch (app._app_Title)
//    {

//        case "Mr": iTitle = 1;
//            break;
//        case "Mrs": iTitle = 3;
//            break;
//        case "Dr": iTitle = 4;
//            break;
//        case "Miss": iTitle = 7;
//            break;
//        default: iTitle = 1;
//            break;
//    }

//    string[] sPostCode = app._app_PermPostCode.Split(' ');
//    string Learner_PostCode1 = "";
//    string Learner_PostCode2 = "";
//    if (sPostCode.Length > 1)
//    {
//        Learner_PostCode1 = sPostCode[0];
//        Learner_PostCode2 = sPostCode[1];

//    }

//    DateTime dt = new DateTime();

//    ht.Add("Learner_Id_Titles", iTitle);
//    ht.Add("Learner_FirstName", app._app_FirstName);
//    ht.Add("Learner_Middlename", "");
//    ht.Add("Learner_Surname", app._app_Surname);
//    ht.Add("Learner_Gender", app._app_Gender == "1" ? 1 : 2);
//    ht.Add("Learner_DOB", DSP.BAL.Basic.ConvertDateToSQL(app._app_DOB));
//    ht.Add("Learner_IsActive", 1);
//    ht.Add("Learner_Address1", app._app_PermAddress1);
//    ht.Add("Learner_Address2", app._app_PermAddress2);
//    ht.Add("Learner_Address3", app._app_PermAddress3);
//    ht.Add("Learner_Address4", app._app_PermAddress4);
//    ht.Add("Learner_Address5", app._app_PermAddress5);
//    ht.Add("Learner_PostCode1", Learner_PostCode1);
//    ht.Add("Learner_PostCode2", Learner_PostCode2);

//    ht.Add("Learner_Telephone", app._app_HomeTel);
//    ht.Add("Learner_Telephone2", "");
//    ht.Add("Learner_TelephoneWork1", "");
//    ht.Add("Learner_TelephoneWork2", "");
//    ht.Add("Learner_Mobile1", app._app_Mobile);
//    ht.Add("Learner_Mobile2", "");
//    ht.Add("Learner_Email1", app._app_Email);
//    ht.Add("Learner_Email2", "");
//    ht.Add("Learner_IsOverseas", 0);
//    ht.Add("Learner_OCRDate", DSP.BAL.Basic.ConvertDateToSQL(dt.ToShortDateString()));
//    ht.Add("Learner_OCRNumber", "");
//    ht.Add("Learner_IsOCRRegistered", "0");
//    ht.Add("Learner_ReceivedDate", DSP.BAL.Basic.ConvertDateToSQL(dt.ToShortDateString()));
//    ht.Add("Learner_BookedDate", DSP.BAL.Basic.ConvertDateToSQL(dt.ToShortDateString()));
//    ht.Add("Learner_IsFunded", "0");
//    ht.Add("Learner_IsClaimed", "0");
//    ht.Add("Learner_Occupation", "0");
//    ht.Add("Learner_CreatedDate", DSP.BAL.Basic.ConvertDateToSQL(DateTime.Now.ToShortDateString()));
//    ht.Add("Learner_Id_MaritalStatus", "1");
//    ht.Add("Learner_Id_Assessor1", "0");
//    ht.Add("Learner_Id_Employer", "0");
//    ht.Add("Learner_Id_Status", "1");
//    ht.Add("Learner_Id_DealingPerson", "197");

//    ht.Add("Learner_Id_Ethnicity", app._app_Ethnicity);
//    ht.Add("Learner_Id_Country", 224);
//    ht.Add("Learner_CreatedByUser", 291);
//    ht.Add("Learner_Id_PStatus", 1);

//    ht.Add("LastLearnerId", "0");
//    //DSP.DAL.SQLOSCA.GetDsBySPArray("SP_AddNewLearner", ht);



//    int iLastAdded = DSP.DAL.SQLOSCA.ExecuteSPByHashTableAndReturnScalar("SP_AddNewLearner", ht);

//    sql = " SELECT top 1 Learner_Id FROM LearnerContacts Order by Learner_Id desc ";//SELECT Learner_Id FROM LearnerContacts WHERE Learner_Id = @@IDENTITY "; //SELECT SCOPE_IDENTITY() ;
//    DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(sql);
//    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//    {
//        try
//        {
//            iLastAdded = int.Parse(ds.Tables[0].Rows[0]["Learner_Id"].ToString());
//        }
//        catch (Exception exx)
//        {
//            iLastAdded = 0;
//        }
//    }
//    else
//    {
//        iLastAdded = 0;
//    }

//    _learner_id = iLastAdded;
//    return iLastAdded;


//}

//public bool CreatePortalLearnerUser(int iLearnerId, string sDisplayName, string sPassword, string sEmail)
//{
//    DataSet dsUser;
//    MembershipUser newUser;

//    string strPass = DSP.BAL.Basic.EncodePassword(sPassword);
//    newUser =System.Web.Security.Membership.GetUser(iLearnerId.ToString());

//    if (newUser == null)
//    {
//        // Create the Learner User into Portal
//        //string sLearnerEmail = DSP.BAL.OSCA_Learner.GetLearnerEmailById(strUser);
//        string strUser = iLearnerId.ToString();
//        string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_Id_LearnerContacts, Users_Email) ";
//        strSQL += " values ('{0}','{1}', 1, '{2}',  getdate(),'0','1','0','0','0', '{3}', '{4}'); select scope_identity() as id;";
//        dsUser = DSP.DAL.SQLPortal.GetRecordsBySQL(string.Format(strSQL, strUser, strPass, sDisplayName, strUser, sEmail));

//        Hashtable ht = new Hashtable();
//        ht.Add("@ApplicationName", "/");
//        ht.Add("@UserName", strUser);
//        ht.Add("@Password", strPass);
//        ht.Add("@Email", sEmail);
//        ht.Add("@PasswordQuestion", "''");
//        ht.Add("@PasswordAnswer", "''");
//        DSP.DAL.SQLPortal.ExecuteSPByHashTable("aspnet_CreateUser", ht);

//        DSP.BAL.Log.WriteLogTxt(String.Format("CreatePortalLearnerUser()  aspnet_CreateUser... user is added to the portal | UserName: {0} | strPass: {1} | sEmail: {2} | sDisplayName: {3} ", strUser, strPass, sEmail, sDisplayName));

//        Hashtable ht2 = new Hashtable();
//        //  ht.Add("@rolename", "Learner");
//        // ht.Add("@membername", strUser);
//        //  DSP.DAL.SQLPortal.ExecuteSPByHashTable("sp_addrolemember", ht2);
//        // aspnet_UsersInRoles_AddUsersToRoles '/', '5964','Learner', null

//        //commented out old method for adding roles in portal db and added new mthod.
//        //ht2.Add("@ApplicationName", "/");
//        //ht2.Add("@RoleNames", "Learner");
//        //ht2.Add("@UserNames", strUser);
//        //ht2.Add("@CurrentTimeUtc", "");
//        //DSP.DAL.SQLPortal.ExecuteSPByHashTable("aspnet_UsersInRoles_AddUsersToRoles", ht2);
//        //////string[] user = new string[] { strUser };
//        //////string[] userRole = new string[] { "Learner" };
//        //////PortalRoleProvider portalRoleProvider = Roles.Providers["PortalRoleProvider"] as PortalRoleProvider;
//        //////if (portalRoleProvider.RoleExists("Learner"))
//        //////{
//        //////    portalRoleProvider.AddUsersToRoles(user, userRole);
//        //////}

//        ht2.Add("@ApplicationName", "/");
//        ht2.Add("@RoleNames", "Learner");
//        ht2.Add("@UserNames", strUser);
//        ht2.Add("@CurrentTimeUtc", "");
//        DSP.DAL.SQLPortal.ExecuteSPByHashTable("aspnet_UsersInRoles_AddUsersToRoles", ht2);

//        DSP.BAL.Log.WriteLogTxt(String.Format("CreatePortalLearnerUser() user added to Learner Role"));


//        //newUser = Membership.CreateUser(strUser, strPass);
//        //Roles.AddUserToRole(strUser, "Learner");

//        //Insert User in QCS db:
//        if (ConfigurationManager.AppSettings["cfg_test"] != "true")
//        {   //dont add to QCS DB if this is for test
//            AddUsertoQCSDB(iLearnerId, sPassword, sEmail, sDisplayName);
//        }

//        if (ConfigurationManager.AppSettings["cfg_test"] == "true")
//        {
//            //dont sent to learner if test
//            sEmail = ConfigurationManager.AppSettings["cfg_portal_email_debug"].ToString(); // "web@fdesigns.co.uk";                    
//        }

//        if (sEmail != "")
//        {
//            //STOP SENDING TO USERS!!!
//            //DSP.BAL.EmailNotifications.SendMail_LoginDetailsLearner(strUser, sPassword, sEmail, sDisplayName);
//            //SEND A COPY TO ADMINS
//            DSP.BAL.EmailNotifications.SendMail_LoginDetailsLearner(strUser, sPassword, sEmail, sDisplayName,);

//        }

//        return true;
//    }
//    else
//    {
//        return false;
//    }

//}