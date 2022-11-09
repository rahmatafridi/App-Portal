using System;
using System.Data;
using System.Configuration;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
 
using System.Text;
using System.Collections;
 


namespace DSP.BAL
{

    public class EmailNotifications
    {
        public EmailNotifications()
        {
        }

        public static void PrepareMail_LoginDetailsLearner(ref string sEmailFrom, ref string sEmailSubject, ref string sEmailBody, string sUsername, string sPassword, string sEmail, string sDisplayName)
        {
            DSP.BAL.Log.WriteLogTxt(String.Format("PrepareMail_LoginDetailsLearner() | iLearnerId: {0} | sPassword: {1} | sEmail: {2} | sDisplayName: {3} ", sUsername, sPassword, sEmail, sDisplayName));
            sEmailFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
            sEmailSubject = DSP.BAL.DBL.GetEmailTemplateTitle(int.Parse(DSP.BAL.DBL.GetConfigValue("APP_SUBMIT_EMAIL_TPL")));

            Hashtable ht = new Hashtable();
            ht.Add("[FULL_NAME]", sDisplayName);
            ht.Add("[PORTAL_URL]", ConfigurationManager.AppSettings["cfg_portal_url"]);
            ht.Add("[USERNAME]", sUsername);
            ht.Add("[PASSWORD]", sPassword);

            sEmailBody = DSP.BAL.DBL.GetEmailTemplateBodyReplaced(int.Parse(DSP.BAL.DBL.GetConfigValue("APP_SUBMIT_EMAIL_TPL")), ht);
             
        }
        
        public static void SendMail_ContactUs(string sName, string sEmail, string sContactNo, string sMsg)
        {

            DSP.BAL.ASPMail emailContactUs = new DSP.BAL.ASPMail();

            emailContactUs.sTo = ConfigurationManager.AppSettings["cfg_portal_email_studensupport"];   
            emailContactUs.sCc = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
            emailContactUs.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];

            emailContactUs.sSubject = DSP.BAL.DBL.GetEmailTemplateTitle(int.Parse(DSP.BAL.DBL.GetConfigValue("REGISTER_EMAIL_TPL"))) + " "  + sName; //Portal: Contact form of

            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("[USER_NAME]", sName );
            ht.Add("[USER_EMAIL]", sEmail );
            ht.Add("[USER_CONTACTNO]", sContactNo );
            ht.Add("[USER_MSG]", sMsg );

            
            emailContactUs.sBody = DSP.BAL.DBL.GetEmailTemplateBodyReplaced(int.Parse(DSP.BAL.DBL.GetConfigValue("REGISTER_EMAIL_TPL")), ht);

            try
            {
                emailContactUs.SendMail();
            }
            catch (Exception exx)
            {
                emailContactUs.sTo = "accessskills.wave@gmail.com";
                emailContactUs.sSubject += "ERROR: " + "oEmailNotifications.SendMail_ContactUs()";
                emailContactUs.sBody += exx.Message;
                emailContactUs.SendMail();
            }



        }

        public static void SendMail_test(string sEmail, string sSubject, string sMsg)
        {

            DSP.BAL.ASPMail emailNewUser = new DSP.BAL.ASPMail();

            emailNewUser.sTo = sEmail; // ConfigurationManager.AppSettings["cfg_portal_email_debug"];
         //   emailNewUser.sCc = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
            emailNewUser.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];

            emailNewUser.sSubject = sSubject; //Portal: Contact form of
             

            emailNewUser.sBody =sMsg  ;

            try
            {
                emailNewUser.SendMail();
            }
            catch (Exception exx)
            {
                Log.WriteLogTxt(string.Format(exx.Message ));
      
                emailNewUser.sTo = "accessskills.wave@gmail.com";
                emailNewUser.sSubject += "ERROR: " + "oEmailNotifications.SendMail_ContactUs()";
                emailNewUser.sBody += exx.Message;
                emailNewUser.SendMail();
            }



        }

        public static void SendFormattedMail(string sSubject, string sFrom, string sTo, string sBody, string sCc = "", string sBcc = "", Hashtable htAttchmentFiles = null)
        {
            DSP.BAL.ASPMail emailFormated = new DSP.BAL.ASPMail();
            
            emailFormated.sTo = sTo;
            emailFormated.sCc = sCc;
            emailFormated.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
            emailFormated.sSubject = sSubject;
            emailFormated.sBody = sBody;

            emailFormated.htAttchmentFiles = htAttchmentFiles;
                        
          //  DSP.BAL.Log.WriteLogTxt(String.Format("SendFormattedMail() | emailFormated.sTo: {0} | emailFormated.sCc: {1} | emailFormated.sFrom: {2} |  emailFormated.sSubject: {3} ", emailFormated.sTo, emailFormated.sCc, emailFormated.sFrom , emailFormated.sSubject));


            try
            {
                emailFormated.SendMail();
            }
            catch (Exception exx)
            {
                DSP.BAL.Log.WriteLogTxt(String.Format("SendFormattedMail() ERROR | {0} ", exx.Message));               
            }
        }



    }//EmailNotifications
} //DSP.BAL

 