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

public partial class root_ActivateFailed : System.Web.UI.Page
{
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["Tempering"] != "false")
        {
            Response.Redirect("~/Login.aspx");
        }
     

    }

     
}
