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

    public class Applicant
    {
        public Applicant()
        {

        }


        public static bool UnableNewApplication(string sUsername )
        {
            bool bUnable = true;
            //check if we can allow new application 

            int iUserId = DSP.BAL.DBL.GetUser_UserId(sUsername);
            string sFound = DSP.DAL.SQL.GetOneValueBySP("SP_App_GetAnyOpenApplication","UserId", iUserId, "app_id");

            if (sFound != "")
            {
                bUnable = false;
            }

            return bUnable;
        
        }

        
 
 

       


    }//EmailLogs
} //DSP.BAL

 