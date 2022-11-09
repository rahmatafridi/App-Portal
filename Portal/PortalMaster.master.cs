using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class PortalMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        displayName();
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

    private void displayName()
    {
        if (Membership.GetUser() != null)
        {
       lblDisplayName.Text  = DSP.BAL.DBL.GetUser_DisplayName(Membership.GetUser().UserName);
        }

    }

}


/*    <script type='text/javascript' src='<%# ResolveUrl ("~/App_Resources/js/sidesliders/easySlider1.7.js") %>'></script>
    */
