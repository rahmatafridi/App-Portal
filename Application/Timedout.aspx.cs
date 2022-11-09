using DSP.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class root_App_Timedout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
          
        lbl_UserId.Text = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName).ToString();  

    }
    protected void btnStart_Click(object sender, EventArgs e)
    {
        Page.Session["CurrentApplication"] = null;
        ApplicationForm myApp = new ApplicationForm(true);

        myApp._app_Email = Membership.GetUser().UserName;
     
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication ;
      
        myApp = null;
        Server.Transfer("Progress.aspx");

    }

    #region "grid"

    protected void grid_userapplications_OnRowDataBound(object sender, EventArgs e)
    {
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

            if (lblSubmitted.Text == "Yes")
            {
                imbtn.Visible = false;
            }
       
        }
       
    }


    public void btn_Edit_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;

       

        Page.Session["CurrentApplication"] = null;
        ApplicationForm myApp = new ApplicationForm();
        myApp = myApp.GetApplication(int.Parse(sAppId));
        myApp._app_Email = Membership.GetUser().UserName;
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null;
        Server.Transfer("Progress.aspx");

    }

    #endregion




    protected void btnLogout_Click(object sender, EventArgs e)
    {
       
        System.Web.UI.Control lw = (System.Web.UI.Control)this.Master.FindControl("loggedinfo");
        if (lw != null)
        { lw.Visible = false; }

       
        Response.Redirect("~/Portal/Logout.aspx");


    }





}
