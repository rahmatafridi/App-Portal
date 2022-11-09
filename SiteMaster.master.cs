using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptInclude(
            this,
            typeof(Page),
            "sidesliders",
            ResolveClientUrl("~/App_Resources/js/sidesliders/easySlider1.7.js"));

        ScriptManager.RegisterClientScriptInclude(
            this,
            typeof(Page),
            "left_menu",
            ResolveClientUrl("~/App_Resources/js/app/left-menu.js"));

        


    }



}
