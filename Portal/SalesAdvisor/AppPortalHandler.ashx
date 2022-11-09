<%@ WebHandler Language="C#" Class="AppPortalHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data;

public class AppPortalHandler : IHttpHandler
{
    UtilityFunctions objUtils = new UtilityFunctions();
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.QueryString.Count > 0)
            {              
                string id = context.Request.QueryString["id"];
                string contents = getEmailBody(id);

                context.Response.Write(contents );
            }
        }
        catch
        {
            context.Response.Write("There is some error updating matrix. Please contact admin.");
            return;
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public void update(int id)
    {

    }
   
    private string getEmailBody(string id)
    {        
        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("Select API_EmailBody FROM AppPortal_Invites WHERE API_ID = " + id + " ;");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["API_EmailBody"].ToString();

        }
        return "x";
    }
}