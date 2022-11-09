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
using System.IO;

public partial class portal_learner_openfile : System.Web.UI.Page
{

     DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {


        string openfilename = Request.QueryString["f"];
        string sId = Request.QueryString["i"];
        openfilename = openfilename.Replace("\\\\", "\\");

        openFileNow(sId, openfilename); 
        //openFileNow(openfilename); 
    }
    public void openFileNow(string sId, string strFilename)
    {

        // public static string MASTERPORTALDOCS = "c:\\OSCAData\\PortalDocs\\";
       // strField1 = strField1.Replace("c:\\OSCAData\\", ConfigurationManager.AppSettings["cfg_oscadata_path"]);
       
        //string sPath = Path.Combine(@"c:\OSCAData\PortalDocs\", sId + "\\" + strFilename);
        string sPath = Path.Combine(ConfigurationManager.AppSettings["cfg_portaldata_docs"], sId + "\\" + strFilename);

        if (strFilename.IndexOf(":") > 0)
        {
            sPath = strFilename;
        }
        //if (ConfigurationManager.AppSettings["cfg_live"] == "false")
        //{
        //    sPath = sPath.Replace("D:", "E:");
        //}


        FileInfo file = new FileInfo(sPath);

        file.Refresh();



        if (file.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); //inline;
            Response.AddHeader("Content-Disposition", "attachement; filename=" + file.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", file.Length.ToString());

            // Set the ContentType
            Response.ContentType = DSP.BAL.Basic.ReturnExtensionImage(file.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(file.FullName);

            // End the response
            Response.End();

        }

    }


    public void openFileNow(string strFilename)
    {

       
        FileInfo file = new FileInfo(strFilename);
      
        file.Refresh();


    
        if (file.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); //inline;
            Response.AddHeader("Content-Disposition", "attachement; filename=" + file.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", file.Length.ToString());

            // Set the ContentType
            Response.ContentType = DSP.BAL.Basic.ReturnExtensionImage(file.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(file.FullName);

            // End the response
            Response.End();

        }

    }

    public void DownloadFile(string filePath)
    {
        if (File.Exists(Server.MapPath(filePath)))
        {
            string strFileName = Path.GetFileName(filePath).Replace(" ", "%20");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
            Response.Clear();
            Response.WriteFile(Server.MapPath(filePath));
            Response.End();
        }
    }


}

