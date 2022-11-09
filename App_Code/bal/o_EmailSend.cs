using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net.Mail;
using System.Configuration;

namespace DSP.BAL
{

    public class EmailSendXXX
    {
        public EmailSendXXX()
        {

        }

        public static bool Sendxxx(string sSubject, string sFrom, string sTo, string sBody, string sCc = "", string sBcc = "", Hashtable htAttchmentFiles = null)
        {
            string mail_server = ConfigurationManager.AppSettings["cfg_email_server"];
            string mail_un = ConfigurationManager.AppSettings["cfg_email_un"];
            string mail_pwd = ConfigurationManager.AppSettings["cfg_email_pw"];


            if (ConfigurationManager.AppSettings["cfg_test"] == "true")
            {
                mail_server = "smtp.gmail.com";
            }
            SmtpClient client = new SmtpClient(mail_server);
            client.UseDefaultCredentials = false;

            if (ConfigurationManager.AppSettings["cfg_test"] == "true")
            {
                mail_un = "devsight.mail@gmail.com";
                mail_pwd = "oaflbhndtqbbpztf";
                //  sTo = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
                client.Port = 587;
                client.EnableSsl = true;
                  
            }

            client.Credentials = new System.Net.NetworkCredential(mail_un, mail_pwd);


            //   "Access  Skills", 
            //
            // Specify the e-mail sender. 
            // Create a mailing address that includes a UTF8 character 
            // in the display name.
            MailAddress from = new MailAddress(ConfigurationManager.AppSettings["cfg_portal_email_from"],
               ConfigurationManager.AppSettings["cfg_portal_email_from_name"],
            System.Text.Encoding.UTF8);
            MailMessage message = new MailMessage();
            message.From = from;

            foreach (var address in sTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(address);
            }

            if (ConfigurationManager.AppSettings["cfg_portal_email_enable_bcc"] == "true")
            {
                sBcc = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
            }
            if (sBcc != "")
            {
                MailAddress mBcc = new MailAddress(sBcc);
                message.Bcc.Add(mBcc);
            }

            if (sCc != "")
            {
                MailAddress mCc = new MailAddress(sCc);
                message.CC.Add(mCc);
            }

            message.Body = sBody;
            // Include some non-ASCII characters in body and subject. 
            //string someArrows = new string(new char[] {'\u2190', '\u2191', '\u2192', '\u2193'});
            message.Body += Environment.NewLine;/// + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = sSubject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            try
            {
                if (htAttchmentFiles != null)
                {
                    IDictionaryEnumerator _enumFiles = htAttchmentFiles.GetEnumerator();
                    while (_enumFiles.MoveNext())
                    {
                        message.Attachments.Add(new Attachment(_enumFiles.Value.ToString()));

                    }
                }

                // Set the method that is called back when the send operation ends.
                client.Send(message);

            }
            catch (Exception exx)
            {
                return false;

            }

            return true;
        }
       

        public static bool SendMailAlternative(string sSubject, string sFrom, string sTo, string sBody, string sCc = "", string sBcc = "", Hashtable htAttchmentFiles = null)
        {

            SmtpClient client = null;
            MailAddress from = null;
            MailMessage message = new MailMessage();
            if (ConfigurationManager.AppSettings["cfg_test"] == "true" || ConfigurationManager.AppSettings["cfg_test"] == "dev")
            {
                client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
               client.Credentials = new System.Net.NetworkCredential("devsight.mail@gmail.com", "oaflbhndtqbbpztf");
               from = new MailAddress("noreply@accessskills.co.uk", "Access Skills Test Admin", System.Text.Encoding.UTF8);
               message.Bcc.Add(ConfigurationManager.AppSettings["cfg_portal_email_debug"].ToString());
               foreach (var address in sTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
               {
                    message.To.Add(address);
               }
            }
            else
            {
                client = new SmtpClient(ConfigurationManager.AppSettings["cfg_email_server"]);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cfg_email_un"], ConfigurationManager.AppSettings["cfg_email_pw"]);
                from = new MailAddress(ConfigurationManager.AppSettings["cfg_portal_email_from"],
                ConfigurationManager.AppSettings["cfg_portal_email_from_name"],
                System.Text.Encoding.UTF8);
                message.Bcc.Add(ConfigurationManager.AppSettings["cfg_portal_email_debug"].ToString());
                foreach (var address in sTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(address);
                }
                if (sBcc != "")
                {
                    MailAddress mBcc = new MailAddress(sBcc);
                    message.Bcc.Add(mBcc);
                }

                if (sCc != "")
                {
                    MailAddress mCc = new MailAddress(sCc);
                    message.CC.Add(mCc);
                }
            }
            message.From = from;
            message.Body = sBody;
            message.Body += Environment.NewLine;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = sSubject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            try
            {
                if (htAttchmentFiles != null)
                {
                    IDictionaryEnumerator _enumFiles = htAttchmentFiles.GetEnumerator();
                    while (_enumFiles.MoveNext())
                    {
                        message.Attachments.Add(new Attachment(_enumFiles.Value.ToString()));

                    }
                }
                client.Send(message);

            }
            catch (Exception exx)
            {

                return false;

            }
            return true;
        }



    }//EmailSend
} //DSP.BAL

