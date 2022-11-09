using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;
using System.Security.Principal;
using System.Configuration;
using System.Collections;

public partial class root_activate : System.Web.UI.Page
{
    private string redirUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        string sActivationCode = Request.QueryString["ac"];
        string sUsername = Request.QueryString["un"];

        if (ActivateSuccess(sActivationCode, sUsername))
        {
            Page.Session["Tempering"]= "false";
            Response.Redirect("~/ActivateSuccess.aspx");
        }
        else
        {
            Page.Session["Tempering"] = "false";
            Response.Redirect("~/ActivateFailed.aspx");
        }

      
     

    }


    private bool ActivateSuccess(string sActivationCode, string sUsername)
    {
        bool bSuccess = false;
        string sSQL = "SELECT * FROM Users WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL(sUsername) + "' AND Users_ProviderUserKey = '" + sActivationCode + "' AND Users_IsActivated = 0 AND Users_IsActive= 0; ";
        DataSet dsUser = null;
        dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
        if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
        {
            bSuccess = false;
        }
        else {
            bSuccess = true;
            sSQL = "UPDATE Users SET Users_IsActivated = 1 , Users_IsActive= 1, Users_ActivatedOn = getDate()  WHERE Users_UserName = '" + DSP.BAL.Basic.FormatStringForSQL(sUsername) + "' AND Users_ProviderUserKey = '" + sActivationCode + "'   ";
            DSP.DAL.SQL.ExecuteScalar (sSQL);
        
        }
        return bSuccess;    
    }
 

 
   

}
