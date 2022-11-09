using DSP.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class root_Default : System.Web.UI.Page
{

    [Serializable]
    public class SubmittedApplication
    {


        public int AppUser_App_Id { get; set; }
        public int AppUser_UserId { get; set; }
        public string AppUser_CreatedByUser { get; set; }

        public string applicantname { get; set; }

        public string CreatedOn { get; set; }

        public string IsSubmitted { get; set; }
        public string SumittedDate { get; set; }

        public string IsRejected { get; set; }

        public string RejectedOn { get; set; }

        public List<SubmittedApplication> GetOutstanding()
        {
            // List<SubmittedApplication> lstSubmittedApplication = new List<SubmittedApplication>();
            Hashtable ht = new Hashtable();
            ht.Add("submitted", "1");
            //List<Outstanding> lstSubmittedApplication = new List<Outstanding>();
            //lstSubmittedApplication = objOutstanding.GetOutstanding();
            DataSet ds = DSP.DAL.SQL.GetDsBySPArray("oscauser.SP_App_GetUserApplicationsForAdmin", ht);


            var lstSubmittedApplication = ds.Tables[0].AsEnumerable().Select(dataRow =>
                new SubmittedApplication
                {
                    AppUser_App_Id = dataRow.Field<int>("AppUser_App_Id"),
                    AppUser_UserId = dataRow.Field<int>("AppUser_UserId"),
                    applicantname = dataRow.Field<string>("applicantname"),
                    IsSubmitted = dataRow.Field<string>("IsSubmitted"),
                    IsRejected = dataRow.Field<string>("IsRejected"),
                    CreatedOn = dataRow.Field<string>("CreatedOn"),
                    SumittedDate = dataRow.Field<string>("SumittedDate"),
                    RejectedOn = dataRow.Field<string>("RejectedOn")
                }).ToList();


            //lstOrders.Add(new Outstanding() { Item = "CocaCola", Order = "000101", Line = 1, Status = 20, ToLocation = "Sydney", Qty = 2000, RegDate = new DateTime(2014, 1, 1), Location = "USA", AllocQty = 100 });
            //lstOrders.Add(new Outstanding() { Item = "BubbleGum", Order = "000101", Line = 1, Status = 20, ToLocation = "Sydney", Qty = 2500, RegDate = new DateTime(2014, 1, 11), Location = "USA", AllocQty = 300 });
            //lstOrders.Add(new Outstanding() { Item = "Coffee", Order = "000111", Line = 1, Status = 50, ToLocation = "Melbourne", Qty = 2500, RegDate = new DateTime(2014, 1, 10), Location = "USA", AllocQty = 100 });
            //lstOrders.Add(new Outstanding() { Item = "Sugar", Order = "000112", Line = 1, Status = 50, ToLocation = "Melbourne", Qty = 2300, RegDate = new DateTime(2014, 1, 10), Location = "NZ", AllocQty = 300 });
            //lstOrders.Add(new Outstanding() { Item = "Milk", Order = "000112", Line = 1, Status = 50, ToLocation = "Melbourne", Qty = 2300, RegDate = new DateTime(2014, 1, 10), Location = "NZ", AllocQty = 200 });
            //lstOrders.Add(new Outstanding() { Item = "Green Tea", Order = "000112", Line = 1, Status = 20, ToLocation = "Melbourne", Qty = 300, RegDate = new DateTime(2014, 1, 10), Location = "NZ", AllocQty = 220 });
            //lstOrders.Add(new Outstanding() { Item = "Biscuit", Order = "000131", Line = 1, Status = 70, ToLocation = "Perth", Qty = 200, RegDate = new DateTime(2014, 1, 12), Location = "IND", AllocQty = 10 });
            //lstOrders.Add(new Outstanding() { Item = "Wrap", Order = "000131", Line = 1, Status = 20, ToLocation = "Perth", Qty = 2100, RegDate = new DateTime(2014, 1, 12), Location = "IND", AllocQty = 110 });


            return lstSubmittedApplication;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Membership.GetUser() != null)
        {
            lbl_UserId.Text = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName).ToString();
            grid_AllUserApplications.DataBind();
        }

        if (!Page.IsPostBack)
        {
            ddlCourseFilter.DataBind();
            ListItem li = new ListItem();
            li.Text = "Any";
            li.Value = "-1";
            li.Selected = true;
            ddlCourseFilter.Items.Add(li);
            ddlCourseFilter.SelectedIndex = ddlCourseFilter.Items.Count - 1;
            if (Roles.IsUserInRole(Membership.GetUser().UserName, "Admin") == true)
            {

            }
            else if (Roles.IsUserInRole(Membership.GetUser().UserName, "SalesAdvisor") == true)
            {
                txtUserId.Text = lbl_UserId.Text;
                grid_AllUserApplications.Columns[18].Visible = false;
            }
            if (Roles.IsUserInRole(Membership.GetUser().UserName, "Admin") == true)
            {
                grid_AllUserApplications.Columns[18].Visible = true;
            }
            grid_AllUserApplications.Columns[4].Visible = false;
            grid_AllUserApplications.Columns[5].Visible = true;
            grid_AllUserApplications.Columns[6].Visible = false;
            grid_AllUserApplications.Columns[7].Visible = false;
            grid_AllUserApplications.Columns[8].Visible = false;
            grid_AllUserApplications.Columns[9].Visible = false;
            grid_AllUserApplications.Columns[10].Visible = false;
            grid_AllUserApplications.Columns[11].Visible = false;
            grid_AllUserApplications.Columns[12].Visible = false;
            grid_AllUserApplications.Columns[13].Visible = true;
            grid_AllUserApplications.Columns[14].Visible = true;
            grid_AllUserApplications.Columns[15].Visible = true;
            grid_AllUserApplications.Columns[16].Visible = true;
            grid_AllUserApplications.Columns[17].Visible = false;
        }
        if (Page.IsPostBack)
        {
            if (ddl_Type.SelectedValue == "Submitted")
            {
                grid_AllUserApplications.Columns[4].Visible = false;
                grid_AllUserApplications.Columns[5].Visible = true;
                grid_AllUserApplications.Columns[6].Visible = false;
                grid_AllUserApplications.Columns[7].Visible = false;
                grid_AllUserApplications.Columns[8].Visible = false;
                grid_AllUserApplications.Columns[9].Visible = false;
                grid_AllUserApplications.Columns[10].Visible = false;
                grid_AllUserApplications.Columns[11].Visible = false;
                grid_AllUserApplications.Columns[12].Visible = false;
                grid_AllUserApplications.Columns[13].Visible = true;
                grid_AllUserApplications.Columns[14].Visible = true;
                grid_AllUserApplications.Columns[15].Visible = true;
                grid_AllUserApplications.Columns[16].Visible = true;
                grid_AllUserApplications.Columns[17].Visible = false;

            }
            else if (ddl_Type.SelectedValue == "NotSubmitted")
            {
                grid_AllUserApplications.Columns[4].Visible = true;
                grid_AllUserApplications.Columns[5].Visible = false;
                grid_AllUserApplications.Columns[6].Visible = false;
                grid_AllUserApplications.Columns[7].Visible = false;
                grid_AllUserApplications.Columns[8].Visible = false;
                grid_AllUserApplications.Columns[9].Visible = false;
                grid_AllUserApplications.Columns[10].Visible = false;
                grid_AllUserApplications.Columns[11].Visible = false;
                grid_AllUserApplications.Columns[12].Visible = false;
                grid_AllUserApplications.Columns[13].Visible = true;
                grid_AllUserApplications.Columns[14].Visible = false;
                grid_AllUserApplications.Columns[15].Visible = false;
                grid_AllUserApplications.Columns[16].Visible = false;
                grid_AllUserApplications.Columns[17].Visible = false;

            }
            else if (ddl_Type.SelectedValue == "Rejected")
            {

                grid_AllUserApplications.Columns[4].Visible = true;
                grid_AllUserApplications.Columns[5].Visible = false;
                grid_AllUserApplications.Columns[6].Visible = true;
                grid_AllUserApplications.Columns[7].Visible = true;
                grid_AllUserApplications.Columns[8].Visible = false;
                grid_AllUserApplications.Columns[9].Visible = false;
                grid_AllUserApplications.Columns[10].Visible = true;
                grid_AllUserApplications.Columns[11].Visible = false;
                grid_AllUserApplications.Columns[12].Visible = false;
                grid_AllUserApplications.Columns[13].Visible = true;
                grid_AllUserApplications.Columns[14].Visible = false;
                grid_AllUserApplications.Columns[15].Visible = false;
                grid_AllUserApplications.Columns[16].Visible = false;
                grid_AllUserApplications.Columns[17].Visible = false;
            }
            else if (ddl_Type.SelectedValue == "Deleted")
            {
                grid_AllUserApplications.Columns[4].Visible = true;
                grid_AllUserApplications.Columns[5].Visible = false;
                grid_AllUserApplications.Columns[6].Visible = false;
                grid_AllUserApplications.Columns[7].Visible = false;
                grid_AllUserApplications.Columns[8].Visible = true;
                grid_AllUserApplications.Columns[9].Visible = true;
                grid_AllUserApplications.Columns[10].Visible = true;
                grid_AllUserApplications.Columns[11].Visible = false;
                grid_AllUserApplications.Columns[12].Visible = false;
                grid_AllUserApplications.Columns[13].Visible = true;
                grid_AllUserApplications.Columns[14].Visible = false;
                grid_AllUserApplications.Columns[15].Visible = false;
                grid_AllUserApplications.Columns[16].Visible = false;
                grid_AllUserApplications.Columns[17].Visible = false;
            }
            else if (ddl_Type.SelectedValue == "Enrolled")
            {
                grid_AllUserApplications.Columns[4].Visible = false;
                grid_AllUserApplications.Columns[5].Visible = false;
                grid_AllUserApplications.Columns[6].Visible = false;
                grid_AllUserApplications.Columns[7].Visible = false;
                grid_AllUserApplications.Columns[8].Visible = false;
                grid_AllUserApplications.Columns[9].Visible = false;
                grid_AllUserApplications.Columns[10].Visible = false;
                grid_AllUserApplications.Columns[11].Visible = true;
                grid_AllUserApplications.Columns[12].Visible = true;
                grid_AllUserApplications.Columns[13].Visible = true;
                grid_AllUserApplications.Columns[14].Visible = false;
                grid_AllUserApplications.Columns[15].Visible = false;
                grid_AllUserApplications.Columns[16].Visible = false;
                grid_AllUserApplications.Columns[17].Visible = false;
            }
        }
    }


    #region "btns"


    protected void btnStart_Click(object sender, EventArgs e)
    {
        int iCourseID = int.Parse(ddlEnrolmentCourse.SelectedValue);

        //  return;
        Page.Session["CurrentApplication"] = null;
        ApplicationForm myApp = new ApplicationForm(true);

        //  myApp._app_Email = Membership.GetUser().UserName;
        myApp._app_AdvisorUserId = DBL.GetUser_UserId(Membership.GetUser().UserName);
        myApp._app_officeuse1_CourseId = iCourseID;
        myApp._app_officeuse1_CourseTitle = ddlEnrolmentCourse.SelectedItem.Text;
        myApp._app_officeuse1_CourseLevel = myApp.GetCourseLevelForCourseId(iCourseID);

        int courseLevel_Id = myApp._app_officeuse1_CourseLevel;

        myApp.SaveApplicationCourseLevelAndAdvisor();

        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null;

        if (courseLevel_Id == 80)
        {
            Server.Transfer("Progress_SC.aspx");
        }
        else if(courseLevel_Id== 102)
        {
            Server.Transfer("Progress_ESF.aspx");
        }
        else
        {
            Server.Transfer("Progress.aspx");
        }
    }

    protected void btnHomePortal_Click(object sender, EventArgs e)
    {

        Server.Transfer("~/Portal/Account/Default.aspx");

    }

    #endregion

    #region "WebMethod"


    [System.Web.Services.WebMethod]
    public static string GetApplicationForDisplay(string id)
    {

        ApplicationForm myApp = new ApplicationForm();
        myApp = myApp.GetApplication(int.Parse(id));
        string sPage = myApp.MergeApplicationFormTemplate(myApp);
        //ClientScript.RegisterStartupScript(this.GetType(), "ReasonModal", "$('#ReasonModal').modal();", true);

        return sPage;
    }
    #endregion













    #region " xxxxxxxxxxxx"
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    private string columnName = "";
    private int doneColouring = 0;
    private int doneColouring2 = 0;

    #endregion


    public string returnJS(object obj)
    {
        string s = obj.ToString();
        return "GetApplicationForDisplay2(" + s + ");";


    }
    #region " xxxxx  GRID BUTTON CLICKS  xxxxxxx"

    protected void grid_AllUserApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAppId = ((Label)ea.Row.FindControl("lbl_AppId"));
            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            Label lblUsername = ((Label)ea.Row.FindControl("lbl_Username"));
            Label lblSalesAdvName = ((Label)ea.Row.FindControl("lbl_SalesAdvName"));
            System.Web.UI.HtmlControls.HtmlImage imgUserName = ((System.Web.UI.HtmlControls.HtmlImage)ea.Row.FindControl("img_UserName"));
            System.Web.UI.HtmlControls.HtmlImage imgSalesAdvName = ((System.Web.UI.HtmlControls.HtmlImage)ea.Row.FindControl("img_SalesAdvName"));
            LinkButton btnEdit = (LinkButton)ea.Row.FindControl("btn_Edit");
            Label lblReadyToEnrollByUser = ((Label)ea.Row.FindControl("lbl_ReadyToEnrollByUser"));
            Label lblRejected = ((Label)ea.Row.FindControl("lbl_Rejected"));
            Label lblIsAmended = ((Label)ea.Row.FindControl("lbl_IsAmended"));
            Label lblIsReadyToEnroll = ((Label)ea.Row.FindControl("lbl_IsReadyToEnroll"));
            LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
            LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");
            LinkButton btnPrintout = (LinkButton)ea.Row.FindControl("btnPrintout");
            LinkButton btn_RejectNew = (LinkButton)ea.Row.FindControl("btn_RejectNew");
            LinkButton btnNotify = (LinkButton)ea.Row.FindControl("btn_Notify");
            LinkButton btnReadyToEnroll = (LinkButton)ea.Row.FindControl("btn_ReadyToEnroll");
            Label lblYesReadyToEnrolled = (Label)ea.Row.FindControl("lbl_YesReadyToEnrolled");
            Label lblRTE_Comment = (Label)ea.Row.FindControl("lbl_RTE_Comment");

            if (ddl_Type.SelectedValue == "Submitted")
            {
                //if (lblSubmitted.Text == "Yes")
                //{
                //    btnEdit.Visible = false;
                //}
                if (lblIsAmended.Text == "Yes")
                {
                    btnNotify.Visible = true;
                }
                else
                {
                    btnNotify.Visible = false;
                }
                if (lblIsReadyToEnroll.Text == "Yes")
                {
                    btnReadyToEnroll.Visible = false;
                    lblYesReadyToEnrolled.Visible = true;
                    lblYesReadyToEnrolled.ToolTip = "Ready to enrolled by " + lblReadyToEnrollByUser.Text + "\nComments : " + lblRTE_Comment.Text;
                }
                else
                {
                    btnReadyToEnroll.Visible = true;
                    lblYesReadyToEnrolled.Visible = false;
                }
                btnDeReject.Visible = false;
                btnPrintout.Visible = true;
                lblUsername.Visible = false;
                lblSalesAdvName.Visible = false;
                imgUserName.Visible = true;
                imgSalesAdvName.Visible = true;
            }
            else if (ddl_Type.SelectedValue == "NotSubmitted")
            {
                btnDeReject.Visible = false;
                btnPrintout.Visible = true;
                lblUsername.Visible = true;
                lblSalesAdvName.Visible = true;
                imgUserName.Visible = false;
                imgSalesAdvName.Visible = false;
                btnEdit.Visible = false;
            }
            else if (ddl_Type.SelectedValue == "Rejected")
            {
                lblUsername.Visible = false;
                lblSalesAdvName.Visible = false;
                imgUserName.Visible = true;
                imgSalesAdvName.Visible = true;
                btnPrintout.Visible = true;
                btnEdit.Visible = false;
                if (lblRejected.Text == "Yes")
                {
                    btnReject.Visible = false;
                    btnDeReject.Visible = true;
                }
                else
                {
                    btnReject.Visible = true;
                    btnDeReject.Visible = false;
                }
            }
            else if (ddl_Type.SelectedValue == "Deleted")
            {
                btnPrintout.Visible = true;
                btnEdit.Visible = false;
                lblUsername.Visible = false;
                lblSalesAdvName.Visible = false;
                imgUserName.Visible = true;
                imgSalesAdvName.Visible = true;
            }
            else if (ddl_Type.SelectedValue == "Enrolled")
            {
                lblUsername.Visible = true;
                lblSalesAdvName.Visible = true;
                imgUserName.Visible = false;
                imgSalesAdvName.Visible = false;
                btnEdit.Visible = false;
            }

            if (string.IsNullOrEmpty(lblSalesAdvName.Text))
            {
                imgSalesAdvName.Visible = false;
            }

            //print button 
            btnPrintout.ID = "btnPrintout__" + lblAppId.Text;

        }
    }

    public void btnRecover_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;


        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_DeletedDate = null , AppUser_IsDeleted = 0 , AppUser_DeletedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, sAppId));
        ApplicationForm app = new ApplicationForm();
        string sEmailApplicant = app.GetApplicantEmailById(int.Parse(sAppId));
        app = null;

        DSP.BAL.DBL.AddApplicationHistory(int.Parse(sAppId), sEmailApplicant, "RECOVERED", Membership.GetUser().UserName);

        grid_AllUserApplications.DataBind();
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

        int courseLevel_Id = myApp._app_officeuse1_CourseLevel;
        // myApp._app_Email = Membership.GetUser().UserName;
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null; 
        if (courseLevel_Id == 80)
        {
            Server.Transfer("Progress_SC.aspx");
        }
        else if(courseLevel_Id == 102)
        {
            Server.Transfer("Progress_ESF.aspx");
        }
        else
        {
            Server.Transfer("Progress.aspx");
        }

    }


    public void btnPrintout_Click(object sender, EventArgs e)
    {


        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;

        //ViewState["CurrentApplicationId"] = sAppId;
        //Page.Session.Add("CurrentApplicationId", sAppId);


        //string strRedirect = "~/Application/Assessors/MyMessages.aspx";

        //Response.Redirect(strRedirect);

        Page.Session["CurrentApplication"] = null;
        ApplicationForm myApp = new ApplicationForm();
        myApp = myApp.GetApplication(int.Parse(sAppId));

        int courseLevel_Id = myApp._app_officeuse1_CourseLevel;

        // myApp._app_Email = Membership.GetUser().UserName;
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null; 
        if (courseLevel_Id == 80)
        {
            Server.Transfer("Progress_SC.aspx");
        }
        else if(courseLevel_Id== 102)
        {
            Server.Transfer("Progress_ESF.aspx");
        }
        else
        {
            Server.Transfer("Progress.aspx");
        }

    }

    public void btnReject_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;


        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_RejectedDate = getDate(), AppUser_IsRejected = 1, AppUser_IsSubmitted = 0, AppUser_RejectedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, sAppId));

        ApplicationForm app = new ApplicationForm();
        string sEmailApplicant = app.GetApplicantEmailById(int.Parse(sAppId));
        app = null;
        DSP.BAL.DBL.AddApplicationHistory(int.Parse(sAppId), sEmailApplicant, "REJECT", Membership.GetUser().UserName);

        //bind grid here
        grid_AllUserApplications.DataBind();

    }
    public void btnDeReject_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;


        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_RejectedDate = null , AppUser_IsRejected = 0 , AppUser_RejectedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, sAppId));
        ApplicationForm app = new ApplicationForm();
        string sEmailApplicant = app.GetApplicantEmailById(int.Parse(sAppId));
        app = null;
        DSP.BAL.DBL.AddApplicationHistory(int.Parse(sAppId), sEmailApplicant, "DEREJECT", Membership.GetUser().UserName);

        grid_AllUserApplications.DataBind();
        //bindallgrids();

    }
    public void btnDelete_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;


        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_DeletedDate = getdate() , AppUser_IsDeleted = 1 ,  AppUser_DeletedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, sAppId));

        ApplicationForm app = new ApplicationForm();
        string sEmailApplicant = app.GetApplicantEmailById(int.Parse(sAppId));
        app = null;

        DSP.BAL.DBL.AddApplicationHistory(int.Parse(sAppId), sEmailApplicant, "DELETED", Membership.GetUser().UserName);

        //bindallgrids();
        grid_AllUserApplications.DataBind();

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        string strRedirect = "~/Portal/SalesAdvisor/ManageApplications.aspx";

        Response.Redirect(strRedirect);
    }


    protected void btn_RejectWithReason_Click(object sender, EventArgs e)
    {
        string sAppId = ViewState["lbl_AppId"].ToString();
        string rejectedReason = txtReason.Text;
        string applicantname = ViewState["lbl_applicantname"].ToString();

        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_RejectedDate = getDate(), AppUser_IsRejected = 1, AppUser_IsSubmitted = 0, AppUser_RejectedByUser = '{0}', AppUser_RejectedReason = '{1}' WHERE AppUser_App_Id = {2} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, rejectedReason, sAppId));

        ApplicationForm app = new ApplicationForm();

        app.GetApplicationById(int.Parse(sAppId));
        string applicantEmail = app.GetApplicantEmailById(int.Parse(sAppId));

        DSP.BAL.DBL.AddApplicationHistory(int.Parse(sAppId), applicantEmail, "REJECT", Membership.GetUser().UserName, rejectedReason);

        Hashtable ht = new Hashtable();
        ht.Add("[USER_FULLNAME]", applicantname);
        ht.Add("[AppId]", sAppId);
        string sBody = DBL.GetEmailTemplateBodyReplacedByCode("ARE001", ht);

        DSP.BAL.EmailNotifications.SendFormattedMail(string.Format(ConfigurationManager.AppSettings["cfg_lang_subject_app_rejected"], sAppId), "", applicantEmail, sBody, "", "");
        DSP.BAL.Log.WriteLogTxt(String.Format("ManageApplications.btn_RejectWithReason_Click | username: {0} | Application Rejected and Now Emailed | App id: {1} ", Membership.GetUser().UserName, sAppId));

        app = null;
        grid_AllUserApplications.DataBind();

    }

    protected void btn_RejectNew_Click(object sender, EventArgs e)
    {
        LinkButton btn_FileOpen = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)btn_FileOpen.Parent.Parent;
        string lbl_AppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;
        string applicantname = ((Label)grdRow.FindControl("lbl_applicantname")).Text;

        btn_RejectWithReason.Visible = true;
        btn_DeleteWithReason.Visible = false;
        txtReason.Text = "";
        lblReason.Text = "Reason for rejection";
        ViewState["lbl_AppId"] = lbl_AppId;
        ViewState["lbl_applicantname"] = applicantname;
        ClientScript.RegisterStartupScript(this.GetType(), "ReasonModal", "$('#ReasonModal').modal();", true);
    }

    protected void btn_DeleteWithReason_Click(object sender, EventArgs e)
    {
        string sAppId = ViewState["lbl_AppId"].ToString();
        string deletedReason = txtReason.Text;


        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_DeletedDate = getDate(), AppUser_IsDeleted = 1, AppUser_IsSubmitted = 0, AppUser_DeletedByUser = '{0}', AppUser_DeletedReason = '{1}' WHERE AppUser_App_Id = {2} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, deletedReason, sAppId));

        ApplicationForm app = new ApplicationForm();

        string sEmail = app.GetApplicantEmailById(int.Parse(sAppId));


        DBL.AddApplicationHistory(int.Parse(sAppId), sEmail, "DELETE", Membership.GetUser().UserName, deletedReason);
        DSP.BAL.Log.WriteLogTxt(String.Format("ManageApplications.btn_DeleteWithReason_Click | username: {0} | Application Deleted | App id: {1} ", Membership.GetUser().UserName, sAppId));

        app = null;
        grid_AllUserApplications.DataBind();
    }

    protected void btn_DeleteNew_Click(object sender, EventArgs e)
    {
        LinkButton btnDeleteWithReason = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)btnDeleteWithReason.Parent.Parent;
        string lbl_AppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;
        btn_RejectWithReason.Visible = false;
        btn_DeleteWithReason.Visible = true;
        lblReason.Text = "Reason for deletion";
        txtReason.Text = "";
        ViewState["lbl_AppId"] = lbl_AppId;
        ClientScript.RegisterStartupScript(this.GetType(), "ReasonModal", "$('#ReasonModal').modal();", true);
    }

    protected void btn_Notify_Click(object sender, EventArgs e)
    {
        //get all changes from [ApplicationsTrackChanges] by appId and isnotified = false

        LinkButton btn_Notify = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)btn_Notify.Parent.Parent;
        string applicantEmail = ((Label)grdRow.FindControl("lbl_ApplicantEmail")).Text;
        string applicantname = ((Label)grdRow.FindControl("lbl_applicantname")).Text;
        string sAppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;
        string query = "select ATC_AppID, ATC_FieldName , ATC_FieldDesciption, ATC_ValueFrom, ATC_ValueTo, ATC_ChangedBy, ATC_ChangedDate , AFD_FieldSectionID from [oscauser].[ApplicationsTrackChanges] inner join  [oscauser].[ApplicationsFieldDescriptions] on ATC_FieldName = AFD_FieldName where ATC_IsNotified = 0 and AFD_IncludeNotify = 1 and ATC_AppID = " + sAppId;

        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(query);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string tbl = "<table>";
            tbl += "    <tbody>";
            tbl += "        <tr>";
            tbl += "            <th>Change From</th>";
            tbl += "            <th>Change To</th>";
            tbl += "        </tr>";
            tbl += "    </tbody>";
            tbl += "    <tbody>";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string qusetion = dr["ATC_FieldDesciption"].ToString();
                string valueFrom = dr["ATC_ValueFrom"].ToString();
                string valueTo = dr["ATC_ValueTo"].ToString();
                //create table for changes to be sent to learner
                tbl += "<tr style='background-color:#d9edf7;'>";
                tbl += "     <td colspan='2'>" + qusetion + "</td>";
                tbl += " </tr>";
                tbl += " <tr>";
                tbl += "     <td>" + valueFrom + "</td>";
                tbl += "     <td>" + valueTo + "</td>";
                tbl += " </tr>";

            }
            tbl += "    </tbody>";
            tbl += "</table>";

            string updateQuery = "update oscauser.ApplicationsTrackChanges set ATC_IsNotified = 1, ATC_NotifiedDate = GETDATE(), ATC_NotifiedBy = " + DBL.GetUser_UserId(Membership.GetUser().UserName) + " where ATC_AppID = " + sAppId;
            bool result = DSP.DAL.SQL.ExecuteSQL(updateQuery);
            if (result)
            {
                string updateIsAmendedQuery = "update [oscauser].Applications set App_IsAmended = 0 where App_Id = " + sAppId;
                DSP.DAL.SQL.ExecuteSQL(updateIsAmendedQuery);
            }

            SendEmailToApplicant(applicantEmail, tbl, applicantname);
            grid_AllUserApplications.DataBind();
        }
    }

    private bool SendEmailToApplicant(string applicantEmail, string tableRows, string applicantname)
    {
        Hashtable ht = new Hashtable();
        ht.Add("[LEARNER]", applicantname);
        ht.Add("[TABLEROWS]", tableRows);
        string sBody = DBL.GetEmailTemplateBodyReplacedByCode("NCL001", ht);
        try
        {
            //  ================================
            ASPMail emailNewUser = new ASPMail();
            emailNewUser.sTo = applicantEmail;
            emailNewUser.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];
            emailNewUser.sSubject = ConfigurationManager.AppSettings["cfg_email_send_changes_subject"];

            emailNewUser.sBody = sBody;


            try
            {
                emailNewUser.SendMail();

            }
            catch (Exception exx)
            {

            }
        }
        catch (Exception ex)
        {
            Log.log(ex.Message, "Addinvite.aspx.cs>sendEmailForInvite()", "Error");
            return false;
        }
        return true;
    }

    protected void btn_SubmitComment_Click(object sender, EventArgs e)
    {
        string sAppId = ViewState["lbl_AppId"].ToString();
        string comment = txtComment.Text;


        string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_ReadyToEnrollDate = getDate(), AppUser_IsReadyToEnroll = 1,  AppUser_ReadyToEnrollByUser = '{0}', AppUser_ReadyToEnroll_Comment = '{1}' WHERE AppUser_App_Id = {2} ;";
        DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, comment, sAppId));

        ApplicationForm app = new ApplicationForm();

        string sEmail = app.GetApplicantEmailById(int.Parse(sAppId));


        DBL.AddApplicationHistory(int.Parse(sAppId), sEmail, "READYTOENROLL", Membership.GetUser().UserName, comment);
        DSP.BAL.Log.WriteLogTxt(String.Format("ManageApplications.btn_SubmitComment_Click | username: {0} | Application Status Changed To Ready To Enroll | App id: {1} ", Membership.GetUser().UserName, sAppId));

        app = null;
        grid_AllUserApplications.DataBind();
    }

    protected void btn_ReadyToEnroll_Click(object sender, EventArgs e)
    {
        LinkButton btnDeleteWithReason = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)btnDeleteWithReason.Parent.Parent;
        string lbl_AppId = ((Label)grdRow.FindControl("lbl_AppId")).Text;

        txtComment.Text = "";
        ViewState["lbl_AppId"] = lbl_AppId;
        ClientScript.RegisterStartupScript(this.GetType(), "CommentModal", "$('#CommentModal').modal();", true);
    }

    #endregion
}
