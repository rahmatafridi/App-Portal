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

        // string sLink = "http://localhost:29247/PortalOne/Portal/ValidationEmail.aspx?id={0}&gd={1}&tp=v";
       
        string sId = Request.QueryString["id"];
        string sGd= Request.QueryString["gd"];
        string sTp = Request.QueryString["tp"];
        if (sId == null || sId.Length < 1 || sGd == null || sGd.Length < 1)
        {
            //invalid link
            lblInformation.Text = "The link is invalid for email validation.";

        }
        else {

            lblInformation.Text = ValidateEmail (sId, sGd, sTp);
            
        }
      
    }

    private string ValidateEmail(string sId, string sGd, string sTp)
    {
        string sMessage = "";

        string strSQL = "Select * FROM AccountValidation WHERE AV_Guid = '{0}' AND AV_Learner_Id = {1} and AV_IsValidated = 0 ";
             
        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(string.Format(strSQL,sGd, sId));

        if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
        {
            //found on e so update it and reset all others
            strSQL = "Update AccountValidation set AV_IsValidated = 1,AV_Ignore =0  WHERE AV_Guid = '{0}' AND AV_Learner_Id = {1}  ";
            DSP.DAL.SQL.ExecuteSQL(string.Format(strSQL, sGd, sId));
            strSQL = "Update AccountValidation set AV_IsValidated = 0,AV_Ignore =1  WHERE AV_Learner_Id = {0} ";
            DSP.DAL.SQL.ExecuteSQL(string.Format(strSQL, sId));

            //update OSCA email and also learner id email in the user table of portal
            string sEmail = ds.Tables[0].Rows[0]["AV_Email"].ToString();
            DSP.BAL.DBL.UpdateUser_Email(sId, sEmail);
            DSP.BAL.DBL.UpdateOsca_LearnerEmail(sId, sEmail);
            sMessage = "You email is validated and updated. You need to log off and log back again for changes to take effect.";
        }
        else {
            sMessage = "You email cannot be validated. You have either validated previously or the email is not valid anymore.";
        
        }

        return sMessage;
    
    }
        
    
    //public void openFileNow(string sId, string strFilename)
    //{

    //    // public static string MASTERPORTALDOCS = "c:\\OSCAData\\PortalDocs\\";

    //    string sPath = Path.Combine(@"c:\OSCAData\PortalDocs\", sId + "\\" + strFilename);

    //    if (strFilename.IndexOf(":") > 0)
    //    {
    //        sPath = strFilename;
    //    }
    //    if (ConfigurationManager.AppSettings["cfg_live"] == "false")
    //    {
    //        sPath = sPath.Replace("D:", "E:");
    //    }


    //    FileInfo file = new FileInfo(sPath);

    //    file.Refresh();



    //    if (file.Exists)
    //    {
    //        // Clear the content of the response
    //        Response.ClearContent();

    //        // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
    //        //Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); //inline;
    //        Response.AddHeader("Content-Disposition", "attachement; filename=" + file.Name);

    //        // Add the file size into the response header
    //        Response.AddHeader("Content-Length", file.Length.ToString());

    //        // Set the ContentType
    //        Response.ContentType = DSP.BAL.Basic.ReturnExtensionImage(file.Extension.ToLower());

    //        // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
    //        Response.TransmitFile(file.FullName);

    //        // End the response
    //        Response.End();

    //    }

    //}


    
    

}

