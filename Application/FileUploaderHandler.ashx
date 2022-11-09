<%@ WebHandler Language="C#" Class="FileUploaderHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.IO;

public class FileUploaderHandler : IHttpHandler {

    //public void ProcessRequest (HttpContext context) {
    //    context.Response.ContentType = "text/plain";
    //    context.Response.Write("Hello World");
    //}

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.QueryString["upload"] != null)
            {
                string pathrefer = context.Request.UrlReferrer.ToString();
                string Serverpath = Path.Combine(ConfigurationManager.AppSettings["cfg_appportaldata_path"], ConfigurationManager.AppSettings["cfg_appportaldata_app_uploads"]);
                //string Serverpath = HttpContext.Current.Server.MapPath("Upload");

                var postedFile = context.Request.Files[0];

                string file;

                //For IE to get file name
                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                {
                    string[] files = postedFile.FileName.Split(new char[] { '\\' });
                    file = files[files.Length - 1];
                }
                else
                {
                    file = postedFile.FileName;
                }


                if (!Directory.Exists(Serverpath))
                    Directory.CreateDirectory(Serverpath);

                int app_id = 0;
                if (context.Request.QueryString["appid"] != null)
                {
                    int.TryParse(context.Request.QueryString["appid"].ToString(), out app_id);
                }
                string sAppId = app_id.ToString() + "_";

                string fileDirectory = Serverpath;
                if (context.Request.QueryString["fileName"] != null)
                {
                    file = context.Request.QueryString["fileName"];
                    if (File.Exists(fileDirectory + "\\" + sAppId + file))
                    {
                        File.Delete(fileDirectory + "\\" + sAppId + file);
                    }
                }

                string ext = Path.GetExtension(fileDirectory + "\\" + file);
                file = sAppId + Guid.NewGuid() + ext;

                fileDirectory = Serverpath + "\\" + file;

                postedFile.SaveAs(fileDirectory);

                context.Response.AddHeader("Vary", "Accept");
                try
                {
                    if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                        context.Response.ContentType = "application/json";
                    else
                        context.Response.ContentType = "text/plain";
                }
                catch
                {
                    context.Response.ContentType = "text/plain";
                }
                    //"Success"
                context.Response.Write(fileDirectory);
            }
        }
        catch (Exception exp)
        {
            context.Response.Write(exp.Message);
        }
    }




    public bool IsReusable {
        get {
            return false;
        }
    }

}