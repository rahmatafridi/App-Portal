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


namespace DSP.BAL
{

    public class ActivationMail
    {
        public ActivationMail()
        {

        }
          
        public static void InsertActivationMail(string sUserName, string sPassword, string sBody)
        {
            string sSQL = "INSERT INTO ApplicationsActivationMails ( ActMail_Username, ActMail_Password, ActMail_MailBody, ActMail_CreatedOn) ";
            sSQL += " VALUES ('" + DSP.BAL.Basic.FormatStringForSQL(sUserName) + "', '" + sPassword + "', '" + DSP.BAL.Basic.FormatStringForSQL(sBody) + "',  getdate() ) ";
            DSP.DAL.SQL.ExecuteSQL(sSQL);
        }

        

    }//EmailLogs
} //DSP.BAL

 