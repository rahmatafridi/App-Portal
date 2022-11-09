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

public partial class Admin_DeleteUser : System.Web.UI.Page
{
   

     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }

    


   
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'","\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);
 
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strUser = txtUserName.Text.Trim();
        Membership.DeleteUser(strUser ) ;

        string strSQL = "DELETE FROM Users WHERE Users_Username = '{0}' ;";
        DSP.DAL.SQL.ExecuteScalar(string.Format(strSQL,strUser));


        show_notif("User " + strUser + " deleted successfully.<br/>");

     
    }
}
