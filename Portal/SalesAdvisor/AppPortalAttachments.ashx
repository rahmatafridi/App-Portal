<%@ WebHandler Language="C#" Class="AppPortalAttachments" %>

using System;
using System.Web;
using System.Configuration;
using System.IO;
using DSP.BAL;

public class AppPortalAttachments : IHttpHandler
{
    const string Origin = "Origin";
    const string AccessControlRequestMethod = "Access-Control-Request-Method";
    const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
    const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
    const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
    const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.Files.Count > 0) //new file or update file.
            {
                // context.Response.ContentType = "text/plain";

                string UserId = context.Request.Form["UserName"];
                UserId = UserId.Split(',')[0];
                string identifier = context.Request.Form["ident"];
                identifier = identifier.Split(',')[0];

                string pathToSave = "";
                bool uploadingSuccessful = false;
                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    if ((file.FileName.ToUpper().IndexOf(".EXE") > -1) || (file.FileName.ToUpper().IndexOf(".MSI") > -1))
                    {
                        context.Response.Write(".exe and .msi files are not allowed.");
                        return;
                    }
                    else if (file.FileName.ToUpper().IndexOf(",") > -1)
                    {
                        context.Response.Write("There is invalid character in the file name. Please rename it before uploading.");
                        return;
                    }
                    else
                    {
                        if (file.ContentLength > int.Parse(ConfigurationManager.AppSettings["cfg_portal_maxfile"]))
                        {
                            context.Response.Write(String.Format("Maximum file upload limit is {0}MB.", int.Parse(ConfigurationManager.AppSettings["cfg_portal_maxfile"]) / 10000000));
                            return;
                        }
                        else
                        {
                            string strDate = DateTime.Now.ToShortDateString();
                            string[] theData = strDate.Split("/".ToCharArray());
                            strDate = theData[2] + "-" + theData[1] + "-" + theData[0];
                            string fileName = file.FileName;
                            string fileExtension = file.ContentType;
                            //string pathToSave = HttpContext.Current.Server.MapPath("~/MediaUploader/") + str_image;
                            Log.log("fileName:" + fileName, "AppPortalAttachments.ashx", "Log");
                            if (System.Configuration.ConfigurationManager.AppSettings["cfg_test"] == "true")
                            {
                                //pathToSave = HttpContext.Current.Server.MapPath("~/images/" + "LearnerSignUpDocs" + "\\" + LearnerId + "\\");
                                pathToSave = HttpContext.Current.Server.MapPath("~/temp/InvitesTempDocs/" + "\\" + identifier + "\\");
                                if (!Directory.Exists(pathToSave))
                                {
                                    Directory.CreateDirectory(pathToSave);
                                }
                                pathToSave = pathToSave + fileName;
                            }
                            else
                            {
                                pathToSave = ConfigurationManager.AppSettings["cfg_oscadata_path"] + "InvitesTempDocs" + "\\" + identifier + "\\";
                                Log.log("pathToSave1:" + pathToSave, "AppPortalAttachments.ashx", "Log");
                                if (!Directory.Exists(pathToSave))
                                {
                                    Directory.CreateDirectory(pathToSave);
                                }
                                pathToSave = pathToSave + fileName;
                            }
                            Log.log("pathToSave2:" + pathToSave, "AppPortalAttachments.ashx", "Log");

                            file.SaveAs(pathToSave);
                            Log.log("File is SAVED to disk, pathToSave2:" + pathToSave, "AppPortalAttachments.ashx", "Log");

                            bool blupdate = true;
                            //blupdate = filesToDatabase(pathToSave, UserId, identifier, fileName);
                            //if (DocumentId == null || DocumentId == "") //new file
                            //{
                            //    blupdate = filesToDatabase(pathToSave, LearnerId, UserId, fileName);
                            //}
                            //else //update file
                            //{
                            //    blupdate = UpdatefilesToDatabase(LearnerId, UserId, DocumentId, pathToSave, fileName);
                            //}
                            if (blupdate == false)
                            {
                                context.Response.Write("File uploading failed, Please refresh the page and try again.");
                                return;
                            }
                            else
                            {
                                Log.log("files are saved to disk", "AppPortalAttachments.ashx", "Log");
                                uploadingSuccessful = true;
                            }
                            //}
                            //}
                            //else
                            //{
                            //    context.Response.Write("You can only upload .zip, .pdf, .doc, .tif,.png, .jpg files");
                            //}
                        }
                    }
                }
                if (uploadingSuccessful)
                {
                    context.Response.Write("File uploaded successfully. If you want to remove uploaded files, please refresh the page and try again.");
                }
            }

            else
            {
                context.Response.Write("No file selected to upload");
                return;
            }
        }
        catch (Exception exxx)
        {
            Log.log("Error Message: " + exxx.Message, "AppPortalAttachments.ashx", "Log");

            context.Response.Write("There is some error uploading your document, Please contact admin");
            return;
        }
    }

    private bool UpdatefilesToDatabase(string LearnerId, string UserId, string DocumentId, string pathToSave, string fileName)
    {
        if (UserId != "") // ListAllLearners.SelectedRow != null) //x  Session["curr_id"].ToString();
        {
            string query = "";
                
            query = " UPDATE [LearnerUploadedDocs] SET ";
            query += " ,[FilePath] = '" + UtilityFunctions.FormatStringForSQL(pathToSave.Trim()) +"' ";
            query += " ,[FileName] =  '" + UtilityFunctions.FormatStringForSQL(fileName.Trim()) + "' ";
            query += " WHERE [LearnerUploadedDocsId] =  " + DocumentId + "  ";
            try
            {
                DSP.DAL.SQLOSCA.ExecuteSQL(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}