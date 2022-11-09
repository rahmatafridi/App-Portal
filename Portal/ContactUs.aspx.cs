using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;
using System.Collections;


public partial class portal_ContactUs : System.Web.UI.Page
{
    private string redirUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
       //if (true == Request.IsAuthenticated)
       // {
       //     //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
       //     string ss= Request.QueryString["ReturnUrl"];
       //     Response.Redirect(ss);
       // }
         
         
       

    }
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
     

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        bool bCanSubmit = false;

        if (Session["ContactUsSubmitted"] == null)
        {
            bCanSubmit = true;

        }
        else
        {
            DateTime dt ;
            string sTime = Session["ContactUsSubmitted"].ToString();
            bool bDone = DateTime.TryParse(sTime, out dt);
            if (bDone)
            {
                TimeSpan elapsed = DateTime.Now.Subtract(dt);
                if (elapsed.TotalDays <= 1)
                {

                }
                else
                {//you can 
                    bCanSubmit = true;
                }

            }
            else
            {
                bCanSubmit = true;
            }

            
        }


        if (bCanSubmit == true)
        {


            string sName = txt_Name.Text.Trim();
            string sEmail = txt_Email.Text.Trim();
            string sContactNo = txt_Contactno.Text.Trim();
            string sMsg = txt_msg.Text.Trim();

            if (sName == "" || sEmail == "" || sContactNo == "" || sMsg == "")
            {
                InvalidCredentialsMessage.Text = "Please enter required information.";
                show_notif(InvalidCredentialsMessage.Text);

                return;
            }

            DSP.BAL.EmailNotifications.SendMail_ContactUs(sName, sEmail, sContactNo , sMsg );
             
            show_notif("Thank you for contacting us, we will contact you shortly.");
            txt_Name.Text = "";
            txt_Email.Text = "";
            txt_Contactno.Text = "";
            txt_msg.Text = "";

            Session["ContactUsSubmitted"] = DateTime.Now.ToString();
        }// cookie
        else {
         
            show_notif("Sorry, you can not submit another enquiry within 24 hours. If you need to contact us, please call us.");
         
        
        }

    }
     

}
