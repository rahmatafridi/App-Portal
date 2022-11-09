using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string strOld = "";
        string strNew = "";
        string strSql = "";

        int userId = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName);
        strNew = NewPassword.Text;

        if (strNew.Length < 6)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "Password must be 6 or more charactors in length.";
        }
        else
        {
            //Check SQL for Internal User with in SQL
            string md5PW = DSP.BAL.Basic.EncodePassword(CurrentPassword.Text);

            string sSQL = "SELECT * FROM Users WHERE Users_UserName = '" + Membership.GetUser().UserName + "' AND Users_Password = '" + md5PW + "' ORDER BY Users_IsActive DESC ";
            DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                strNew = DSP.BAL.Basic.EncodePassword(strNew);
                strOld = ds.Tables[0].Rows[0]["Users_Password"].ToString();

                MembershipUser u1 = Membership.GetUser();
                string strresetpassword = u1.ResetPassword();


                if (u1.ChangePassword(strresetpassword, strNew))
                {
                    strSql = "UPDATE Users SET Users_Password = '" + strNew + "' WHERE Users_UserName = '" + u1.UserName + "' AND Users_Password = '" + strOld + "'";
                    DSP.DAL.SQL.ExecuteSQL(strSql);

                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Password has been changed successfully.";
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "New password or old password is invalid.";
                }
            }
            else
            {
                //old password invalid
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "New password or old password is invalid.";
            }


        }
    }
}
