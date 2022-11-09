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

    public class Log
    {
        public Log()
        {

        }

       
 
        public static void WriteLogTxt(string msg)
        {

            if (!vars.LOGGING_ENABLE) return;

             System.IO.StreamWriter sw = new System.IO.StreamWriter(ConfigurationManager.AppSettings["cfg_portal_log"], true);

            string sFullLine = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "|" + DateTime.Now.ToShortTimeString() + "| " + msg; // +Environment.NewLine;  
             sw.WriteLine(sFullLine);
            sw.Close();

        }
        public static void log(string sLog, string sSource, string sEvent)
        {

            //  if (cfg_DebugMode
            if (ConfigurationManager.AppSettings["cfg_DebugMode"] == "0") return;

            if (sLog == "") { sLog = "Portal"; }
            if (sSource == "") { sSource = "File"; }
            if (sEvent == "") { sEvent = "test"; }
            
            System.IO.StreamWriter sfw = new System.IO.StreamWriter(ConfigurationManager.AppSettings["cfg_portal_log"], true);
            string sTime = string.Format("{0}.{1}.{2}|{3}:{4}:{5}", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);
            sfw.WriteLine(string.Format("{0}|{1}:{2}>>{3}", sTime, sLog, sSource, sEvent));

            sfw.Close();

            sfw = null;

        }


    }// 
} //DSP.BAL

