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

public partial class Admin_AddUserAssessor : System.Web.UI.Page
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
        string strPass = txtPassword.Text;

        string strDisplayName = txt_displayname.Text.Trim();

        string strAssessorId = txtAssessorId.Text.Trim();

        int iAssessorId = 0;
        bool bDone = int.TryParse(strAssessorId, out iAssessorId);

        strAssessorId = iAssessorId.ToString(); 

        DataSet dsUser;
        MembershipUser newUser;

        strPass = DSP.BAL.Basic.EncodePassword(strPass);
        newUser = Membership.GetUser(strUser);

        if (newUser == null)
        {

            string strSQL = "Set nocount on; INSERT INTO Users (Users_Username, Users_Password, Users_IsActive, Users_DisplayName, Users_CreatedDate , Users_IsAssessor, Users_IsLearner,Users_IsGuest, Users_IsCare, Users_IsCareGroup, Users_Id_AssessorContacts) values ('" + strUser + "','" + strPass + "', 1, '" + strDisplayName + "',  getdate(),'1','0','0','0','0', '" + strAssessorId + "'); select scope_identity() as id;";
            dsUser = DSP.DAL.SQL.GetRecordsBySQL(strSQL );

            newUser = Membership.CreateUser(strUser, strPass);

            show_notif("Learner User " + strUser + " successfully added. ");
            Roles.AddUserToRole(strUser, "Assessor");
           
             
        }
        else
        {
             show_notif("Learner User " + strUser + " already exists.");
 
        }

       
    }
}
