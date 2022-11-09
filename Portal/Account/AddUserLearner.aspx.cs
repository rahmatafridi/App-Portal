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

public partial class Admin_AddUserLearner : System.Web.UI.Page
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




    protected void ShowNotification(  Page page, string notificationType, string text, bool autoClose)
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
        //}
    }


    protected void show_notif(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'","\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);
 
    }
    
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        string strUser = txtUserName.Text.Trim();
        string strPassword = txtPassword.Text;
        if (strUser.Length < 4)
        {

            show_notif("Learner id is too short.");
 
            return;

        }

        string strDisplayName = txt_displayname.Text.Trim();

        //string strLearnerId = txtLearnerId.Text.Trim();

        int iLearnerId = 0;
        bool bDone = int.TryParse(strUser, out iLearnerId);

        if (iLearnerId == 0)
        {

            show_notif("Learner id is not valid. 4 digits minimum, only numeric value. ");

            return;
        }
       // strLearnerId = iLearnerId.ToString(); 
         
        DataSet dsUser;
        MembershipUser newUser;

       string strPass = DSP.BAL.Basic.EncodePassword(strPassword);
        newUser = Membership.GetUser(strUser);

        if (newUser == null)
        {

            string sLearnerEmail = DSP.BAL.OSCA_Learner.GetLearnerEmailById(strUser);
            
            string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_Id_LearnerContacts, Users_Email) ";
            strSQL += " values ('" + iLearnerId.ToString() + "','" + strPass + "', 1, '" + strDisplayName + "',  getdate(),'0','1','0','0','0', '" + iLearnerId.ToString() + "', '" + sLearnerEmail + "'); select scope_identity() as id;";
            dsUser = DSP.DAL.SQL.GetRecordsBySQL(strSQL);

            newUser = Membership.CreateUser(strUser, strPass);

            show_notif("Learner User " + strUser + " successfully added. ");
            Roles.AddUserToRole(strUser, "Learner");

            if (chkSendDetails.Checked == true )
            {  
                if (sLearnerEmail != "")
                {
                    //TODO YAS XXX
                 //   DSP.BAL.EmailNotifications.Step3_SendAccountCreationNotifications(strUser, strPassword, sDisplayName, sRawPassword, , false);
                 //   DSP.BAL.EmailNotifications.SendMail_LoginDetailsLearner (strUser, strPassword, sLearnerEmail, strDisplayName, true);
                } 
            }         
            
             
        }
        else
        {
             show_notif("Learner User " + strUser + " already exists.");
 
        }

       
    }

 


}
