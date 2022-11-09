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

public partial class Admin_ChangeUsersPassword : System.Web.UI.Page
{
     
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    /* ************************************************* 
     * Show jgrowl notification
     *
     * *************************************************
     */
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
    /* ***********************************************/

    protected void btnChangePw_Click(object sender, EventArgs e)
    {
        string strOld = "";
        string strNew = "";
        string strActionText = "";
        string strSql = "";

        strNew = txtPassword.Text;

        if (strNew.Length < 6)
        {
           
            strActionText = "<b>NEW PASSWORD INVALID</b><BR/>Password must be 6 or more charactors in length!<br/>";
            show_notif(strActionText);
        }
        else
        {
            DataSet ds1 = DSP.DAL.SQL.GetRecordsBySQL("SELECT Users_Password FROM Users WHERE Users_Username = '" + ddlUserList.SelectedValue + "';");


            strNew = DSP.BAL.Basic.EncodePassword(strNew);
            strOld = ds1.Tables[0].Rows[0]["Users_Password"].ToString();

            MembershipUser u1 = Membership.GetUser(ddlUserList.SelectedValue);
            string strresetpassword = u1.ResetPassword();


            if (u1.ChangePassword(strresetpassword, strNew))
            {
                strSql = "UPDATE Users SET Users_Password = '" + strNew + "' WHERE Users_UserName = '" + u1.UserName + "' AND Users_Password = '" + strOld + "'";
               DSP.DAL.SQL.ExecuteSQL(strSql);

               // ActionStatus.ForeColor = System.Drawing.Color.Green;
                strActionText = "<b>PASSWORD CHANGE SUCCESSFUL</b><BR/>New password may be used straight away.<br/>";
               show_notif(strActionText);
            }
            else
            {
                strActionText = "<b>NEW PASSWORD INVALID</b><BR/>Old password may be incorrect!<br/>";
               show_notif(strActionText);
            }
        }

     
    }
}
