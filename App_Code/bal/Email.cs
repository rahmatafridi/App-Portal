using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
// using System.Net.Mail;
using System.Collections;
//using System.Web.Mail;
using System.Net.Mail;
using System.Configuration;

namespace DSP.BAL
{

    /// <summary>
    /// Summary description for Mail
    /// </summary>
    public class ASPMail
    {

        public string sTo = "";
        public string sFrom = "";
        public string sCc = "";
        public string sSubject = "";
        public string sBody = "";
        public string sBcc = "";

        public Hashtable htAttchmentFiles = null;

        MailMessage myMail = new MailMessage();

        // MailPriority.High, 
        // MailPriority,Normal 
        // MailPriority.Low

        public ASPMail()
        {
            //
            // TODO: Add constructor logic here
            //



        }

        public bool SendMail()
        {

            SmtpClient client = null;
            MailAddress from = null;
            MailMessage message = new MailMessage();
            if (ConfigurationManager.AppSettings["cfg_test"] == "true" || ConfigurationManager.AppSettings["cfg_test"] == "dev")
            {
                //client = new SmtpClient("smtp.office365.com");
                //client.UseDefaultCredentials = false;
                //client.EnableSsl = true;
                //client.Port = 587;
                //client.Credentials = new System.Net.NetworkCredential("testaccount@qcs.co.uk", "London2015TA");
                //from = new MailAddress("noreply@qcs.co.uk", "Access Skills Test Admin", System.Text.Encoding.UTF8);
                //// sTo = "khurram.raftaz@moftak.com, anees.ur.rehman@moftak.com";
                //message.Bcc.Add(ConfigurationManager.AppSettings["cfg_portal_email_debug"].ToString());
                //foreach (var address in sTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    message.To.Add(address);
                //}

                client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("devsight.mail@gmail.com", "oaflbhndtqbbpztf");
                from = new MailAddress("noreply@accessskills.co.uk", "Access Skills Test Admin", System.Text.Encoding.UTF8);
                
                message.To.Add("accessskills.wave@gmail.com");


            }
            else
            {
                client = new SmtpClient(ConfigurationManager.AppSettings["cfg_email_server"]);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cfg_email_un"], ConfigurationManager.AppSettings["cfg_email_pw"]);
                from = new MailAddress(ConfigurationManager.AppSettings["cfg_portal_email_from"],
                ConfigurationManager.AppSettings["cfg_portal_email_from_name"],
                System.Text.Encoding.UTF8);
               // message.Bcc.Add(ConfigurationManager.AppSettings["cfg_portal_email_debug"].ToString());
                foreach (var address in sTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(address);
                }
                sBcc = ConfigurationManager.AppSettings["cfg_portal_email_debug"].ToString();
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
                        if (_enumFiles.Value != null && _enumFiles.Value != "")
                        {
                            message.Attachments.Add(new Attachment(_enumFiles.Value.ToString()));
                        }
                       

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

         
    }
}