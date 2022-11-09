using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Collections;
using System.Net.Mail;
using System.IO;

public partial class Error : System.Web.UI.Page
{

    //default message
    private string _errorHeader = "Sorry this service is temporarily unavailable";
    private string _errorMessage = "Please contact the Administrator";
    private string _smtpServer = "";
    private string _moduleName = "Error.aspx";

    public string ErrorMessage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        const string kMehtodName = "Page_Load";
        System.Exception lastError = null;
        try
        {
            _smtpServer = ConfigurationManager.AppSettings["cfg_email_server"];
            lastError = LogErrorAndEmailInfo();

            if (lastError != null)
            {
                lastError = lastError.GetBaseException();
            }



        }
        catch (System.Exception ex)
        {
            LogError(_moduleName, kMehtodName, ex);
        }
        finally
        {
            lastError = null;
        }

    }






    private System.Exception LogErrorAndEmailInfo()
    {
        const string kMehtodName = "LogErrorAndEmailInfo";
        System.Exception lastError = null;
        string rootCause = string.Empty;
        string SourceIP = string.Empty;
        StringBuilder sbSession = new StringBuilder();

        try
        {
            lastError = Server.GetLastError();

            var _with1 = sbSession;
            _with1.AppendLine("<table cellspacing='2' cellpadding='5' border='0' class='session'>" + Environment.NewLine);
            _with1.AppendLine("<tr>" + Environment.NewLine);
            _with1.AppendLine("<td>Web Server</td>" + Environment.NewLine);
            _with1.AppendLine("<td class='info'>");
            _with1.AppendLine(Server.MachineName);
            _with1.AppendLine("</td>" + Environment.NewLine);
            _with1.AppendLine("</tr>" + Environment.NewLine);
            SourceIP = (string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? Request.ServerVariables["REMOTE_ADDR"] : Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            _with1.AppendLine("<tr>" + Environment.NewLine);
            _with1.AppendLine("<td>Client Address</td>" + Environment.NewLine);
            _with1.AppendLine("<td class='info'>");
            _with1.AppendLine(SourceIP);
            _with1.AppendLine("</td>" + Environment.NewLine);
            _with1.AppendLine("</tr>" + Environment.NewLine);
            if (HttpContext.Current.Session != null)
            {
                foreach (string sKey in Session.Keys)
                {

                }
            }
            _with1.AppendLine("</table>");
            LogError(_moduleName, kMehtodName, lastError, sbSession.ToString());
        }
        finally
        {
            Server.ClearError();
        }
        return lastError;
    }












    public void LogError(string className, string functionName, System.Exception ex, string moreInfo = "")
    {
        //log it in event_log
        string sSource = string.Empty;
        string sLog = string.Empty;
        string eventDescription = string.Empty;
        string exceptionMessage = string.Empty;
        string smtpServer = ConfigurationManager.AppSettings["cfg_email_server"];
        string emailRecipients = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
        const string emailTemplate = "~/Templates/PortalError.html";
        string rootCause = string.Empty;
        string emailSubject = string.Empty;
        string defaultReceipient = string.Empty;

        Hashtable ht = null;
        try
        {
            if (string.IsNullOrEmpty(emailRecipients))
            {
                defaultReceipient = "accessskills.wave@gmail.com";
            }
            else
            {
                defaultReceipient = emailRecipients; //.Split(":".ToCharArray()).ToString()[0];
            }
            exceptionMessage = ex.ToString() + Environment.NewLine;
            if (ex.InnerException != null)
            {
                exceptionMessage += ex.InnerException.ToString();
            }
            sSource = "Portal Exception" + Environment.NewLine;
            sLog = "Application" + className + "." + functionName;
            eventDescription = "Exception: " + sLog + Environment.NewLine + exceptionMessage;

            ErrorMessage = _errorHeader + "<br/>" + _errorMessage;//eventDescription;

            if (!string.IsNullOrEmpty(moreInfo))
            {
                if (ex != null)
                {
                    rootCause = ex.GetBaseException().ToString();
                }
                ht = new Hashtable();
                ht.Add("[!EXCEPTION!]", rootCause);
                ht.Add("[!SESSION!]", moreInfo);
                ht.Add("[!TRACE!]", exceptionMessage);
                emailSubject += "Application Portal Exception - ";
                emailSubject += HttpContext.Current.Server.MachineName;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Url.Host))
                {
                    //System.Net.Dns.GetHostAddresses(HttpContext.Current.Request.Url.Host)
                    foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostEntry(HttpContext.Current.Request.Url.Host).AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            emailSubject += string.Format(" [{0}]", ip.ToString());
                        }
                    }
                }

                string moreInfo2 = "<br/>";
                foreach (var crntSession in Session)
                {

                    moreInfo2 += string.Concat(crntSession, "=", Session[crntSession.ToString()]) + "<br />";
                }
                ht.Add("[!SESSION2!]", moreInfo2);

                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["cfg_email_server"]);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cfg_email_un"], ConfigurationManager.AppSettings["cfg_email_pw"]);
                MailAddress from = new MailAddress(ConfigurationManager.AppSettings["cfg_portal_email_from"],
             ConfigurationManager.AppSettings["cfg_portal_email_from_name"],
          System.Text.Encoding.UTF8);
                // Set destinations for the e-mail message.
                MailAddress to = new MailAddress(defaultReceipient);
                // Specify the message content.
                MailMessage message = new MailMessage(from, to);




                message.Body = TemplateMerge(HttpContext.Current.Server.MapPath(emailTemplate), ht);
                message.Body += Environment.NewLine;/// + someArrows;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = emailSubject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;



                // Set the method that is called back when the send operation ends.
                client.Send(message);



            }
        }
        catch (Exception exNew)
        {
            System.Diagnostics.Debug.Print(exNew.ToString());
        }
    }


    public string TemplateMerge(string pTemplateFile, Hashtable pEmailDetails)
    {

        StreamReader srTmp = new StreamReader(File.OpenRead(pTemplateFile));

        StringBuilder sbTemplate = new StringBuilder(srTmp.ReadToEnd());
        srTmp.Close();


        StringBuilder Email = new StringBuilder();



        IDictionaryEnumerator _enumerator = pEmailDetails.GetEnumerator();

        while (_enumerator.MoveNext())
        {
            sbTemplate.Replace(_enumerator.Key.ToString(), _enumerator.Value.ToString());
        }


        return sbTemplate.ToString();



    }


}










