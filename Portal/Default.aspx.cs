using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

        if (Roles.IsUserInRole("Guest") == true)
        {

            Response.Redirect("~/Portal/Guest/Default.aspx");
        }
        if (Roles.IsUserInRole("Assessor") == true)
        {
          
            
           // string sUserLogged =  Session["IdAssessor"].ToString(); ; // DSP.BAL.Session.GetSession("IdAssessor"); // HttpContext.Current.Session["IdLearner"].ToString();
          

            Response.Redirect("~/Portal/Assessors/Default.aspx");
        }

        if (Roles.IsUserInRole("Admin") == true)
        {

            Response.Redirect("~/Portal/Account/Default.aspx");
        }


        if (Roles.IsUserInRole("Learner") == true)
        {

            Response.Redirect("~/Portal/Learners/Default.aspx");
        }

        if (false== Request.IsAuthenticated)
        {
            System.Web.UI.Control lw = (System.Web.UI.Control)this.Master.FindControl("loggedinfo");
            if (lw != null)
            { lw.Visible = false; }
        }



    }
}
