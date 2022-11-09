using DSP.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
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
                new SubmittedApplication { AppUser_App_Id = dataRow.Field<int>("AppUser_App_Id"),
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
        //load existing applications
        //check if there is open applications not submitted
        //create new application and load it
        //if (!DSP.BAL.Applicant.UnableNewApplication(Membership.GetUser().UserName))
        //{
        //    btnStart.Enabled = false;
        //}
        if (Membership.GetUser() != null)
        {
            lbl_UserId.Text = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName).ToString();
            grid_userapplications.DataBind();
        }
        if (!Page.IsPostBack)
        {
            loadgrid_initial();
                      
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

        myApp.SaveApplicationCourseLevelAndAdvisor();

        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;
        
        myApp = null;
        Server.Transfer("Progress.aspx");

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
        return sPage;
    }
    #endregion

    #region "grid 1"

    protected void grid_userapplications_OnRowDataBound(object sender, EventArgs e)
    {
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAppId = ((Label)ea.Row.FindControl("lbl_AppId"));
            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

            Label lblRejected = ((Label)ea.Row.FindControl("lbl_Rejected"));
            LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
            LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");

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

            //if (lblSubmitted.Text == "Yes")
            //{
            //    imbtn.Visible = false;
            //}

            // imbtn.Text = "View";

            //print button 
            LinkButton btnPrintout = (LinkButton)ea.Row.FindControl("btnPrintout");
            btnPrintout.ID = "btnPrintout__" + lblAppId.Text;
          

        }


    }

    public void btn_Edit_Click(object sender, EventArgs e)
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
        // myApp._app_Email = Membership.GetUser().UserName;
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null;
        Server.Transfer("Progress.aspx");

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
        // myApp._app_Email = Membership.GetUser().UserName;
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;










        myApp = null;
        Server.Transfer("Progress.aspx");

    }



    public void btn_EditNotSubmitted_Click(object sender, EventArgs e)
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
        // myApp._app_Email = Membership.GetUser().UserName;
        Page.Session["CurrentApplication"] = myApp;
        Page.Session["CurrentApplicationId"] = myApp._app_id;
        Page.Session["CurrentApplicationNew"] = myApp.isNewApplication;

        myApp = null;
        Server.Transfer("Progress.aspx");

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
        DSP.BAL.DBL.AddApplicationHistory(int.Parse(sAppId), sEmailApplicant, "REJECT", Membership.GetUser().UserName  );

        bindallgrids();




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


        bindallgrids();



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

        bindallgrids();


    }

    #endregion



    #region "grid 2"

    protected void grid_userapplicationsNotSubmitted_OnRowDataBound(object sender, EventArgs e)
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


     

    #endregion

    #region "grid 3 rejected"
    protected void grid_userapplicationsRejected_OnRowDataBound(object sender, EventArgs e)
    {
        //GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        //if (ea.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
        //    LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

        //    if (lblSubmitted.Text == "Yes")
        //    {
        //        imbtn.Visible = false;
        //    }      
        //}  

        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            //   LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

            Label lblRejected = ((Label)ea.Row.FindControl("lbl_Rejected"));
            LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
            LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");

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


            //   imbtn.Text = "View";
        }







    }



    #endregion

    #region "grid deleted"


    protected void grid_userapplicationsDeleted_OnRowDataBound(object sender, EventArgs e)
    { 
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));

           // Label lblRejected = ((Label)ea.Row.FindControl("lbl_Rejected"));
            LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
            LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");

            //if (lblRejected.Text == "Yes")
            //{
            //    btnReject.Visible = false;
            //    btnDeReject.Visible = true;
            //}
            //else
            //{
            //    btnReject.Visible = true;
            //    btnDeReject.Visible = false;
            //}
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

        bindallgrids();
    }


    #endregion



     #region "grid ENROLLED"

    protected void grid_userapplicationsEnrolled_OnRowDataBound(object sender, EventArgs e)
    { 
        //GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        //if (ea.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
        //    LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
        //    LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");
        //}


        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAppId = ((Label)ea.Row.FindControl("lbl_AppId"));
            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

            Label lblRejected = ((Label)ea.Row.FindControl("lbl_Rejected"));
            LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
            LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");

            //if (lblRejected.Text == "Yes")
            //{
            //    btnReject.Visible = false;
            //    btnDeReject.Visible = true;
            //}
            //else
            //{
            //    btnReject.Visible = true;
            //    btnDeReject.Visible = false;
            //}
            //print button 
            //LinkButton btnPrintout = (LinkButton)ea.Row.FindControl("btnPrintout");
            //btnPrintout.ID = "btnPrintout__" + lblAppId.Text;


        }


        //if (e.Row.RowType == DataControlRowType.DataRow && doneColouring2 == 0)
        //{
        //    GridViewRow headerRow = grdViewApplications.HeaderRow;
        //    if (ViewState["columnNameO"] != null) columnName = ViewState["columnNameO"].ToString();
        //    for (int i = 0; i < headerRow.Cells.Count; i++)
        //    {
        //        if (headerRow.Cells[i].Controls.Count != 0)
        //        {
        //            //if (!(headerRow.Cells[i].Controls[0] is System.Web.UI.LiteralControl))
        //            //{
        //            if (((LinkButton)headerRow.Cells[i].Controls[1]).Text == columnName)
        //            {
        //                headerRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#2F8CDE");
        //                Image img = new Image();
        //                img.CssClass = "imgClass";
        //                if (GridViewSortDirection == SortDirection.Ascending)
        //                {
        //                    img.ImageUrl = "./Images/up.png";

        //                }
        //                if (GridViewSortDirection == SortDirection.Descending)
        //                {
        //                    img.ImageUrl = "./Images/down.png";
        //                }

        //                headerRow.Cells[i].Controls.Add(img);
        //                doneColouring2 = 1;
        //            }
        //            //}
        //        }
        //    }
        //}









    }

     #endregion

    
    public void bindallgrids()
    {

        grid_userapplications.DataBind();
        grid_userapplicationsNotSubmitted.DataBind();
        grid_userapplicationsRejected.DataBind();
        grid_userapplicationsDeleted.DataBind();



    }

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


    protected void lbRemoveFilterOutstanding_Click(object sender, EventArgs e)
    {
        if (ViewState["Oapplicantname"] != null) ViewState["Oapplicantname"] = null;
        loadgrid_initial();



    }
    protected void ResetFilterAndValueGrid()
    {
        if (ViewState["Oapplicantname"] != null)
            ((TextBox)grdViewApplications.HeaderRow.FindControl("txtApplication")).Text = ViewState["Oapplicantname"].ToString().ToUpper();
        //if (ViewState["OOrder"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtOrder")).Text = ViewState["OOrder"].ToString().ToUpper();
        if (ViewState["OFilterAppId"] != null)
        {
            foreach (ListItem li in ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeLine")).Items)
            {
                if (li.Text == ViewState["OFilterAppId"].ToString()) li.Selected = true; else li.Selected = false;
            }
        }
        if (ViewState["OAppId"] != null)
            ((TextBox)grdViewApplications.HeaderRow.FindControl("txtAppUser_App_Id")).Text = ViewState["OAppId"].ToString();

        //if (ViewState["OFilterStatus"] != null)
        //{
        //    foreach (ListItem li in ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeStatus")).Items)
        //    {
        //        if (li.Text == ViewState["OFilterStatus"].ToString()) li.Selected = true; else li.Selected = false;
        //    }
        //}
        //if (ViewState["OStatus"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtStatus")).Text = ViewState["OStatus"].ToString();
        //if (ViewState["OLocation"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtLocation")).Text = ViewState["OLocation"].ToString();
        //if (ViewState["OToLocation"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtToLocation")).Text = ViewState["OToLocation"].ToString();
        //if (ViewState["OFilterQty"] != null)
        //{
        //    foreach (ListItem li in ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeQty")).Items)
        //    {
        //        if (li.Text == ViewState["OFilterQty"].ToString()) li.Selected = true; else li.Selected = false;
        //    }
        //}
        //if (ViewState["OQty"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtQty")).Text = ViewState["OQty"].ToString();
        //if (ViewState["OFilterAllocQty"] != null)
        //{
        //    foreach (ListItem li in ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeAllocQty")).Items)
        //    {
        //        if (li.Text == ViewState["OFilterAllocQty"].ToString()) li.Selected = true; else li.Selected = false;
        //    }
        //}
        //if (ViewState["OAllocQty"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtAllocQty")).Text = ViewState["OAllocQty"].ToString();
        //if (ViewState["OFilterRegDate"] != null)
        //{
        //    foreach (ListItem li in ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeRegDate")).Items)
        //    {
        //        if (li.Text == ViewState["OFilterRegDate"].ToString()) li.Selected = true; else li.Selected = false;
        //    }
        //}
        //if (ViewState["ORegDate"] != null)
        //    ((TextBox)grdViewApplications.HeaderRow.FindControl("txtRegDate")).Text = ViewState["ORegDate"].ToString();

    }

    protected void txtApplication_TextChanged(object sender, EventArgs e)
    {

        if (sender is TextBox)
        {
            if (ViewState["lstSubmittedApplication"] != null)
            {
                List<SubmittedApplication> allOutstanding = (List<SubmittedApplication>)ViewState["lstSubmittedApplication"];
                TextBox txtBox = (TextBox)sender;
                if (txtBox.ID == "txtApplication")
                {
                    allOutstanding = allOutstanding.Where(x => x.applicantname.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                    ViewState["Oapplicantname"] = txtBox.Text.Trim().ToUpper();
                    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                }
                else if (txtBox.ID == "txtAppUser_App_Id")
                {
                    string filtrerType = ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeLine")).SelectedItem.Value;
                    if (txtBox.Text.Trim().Length < 1) return;

                    if (filtrerType == "=")
                    {
                        allOutstanding = allOutstanding.Where(x => x.AppUser_App_Id == int.Parse(txtBox.Text.Trim())).ToList();
                    }
                    else if (filtrerType == ">")
                    {
                        allOutstanding = allOutstanding.Where(x => x.AppUser_App_Id > int.Parse(txtBox.Text.Trim())).ToList();

                    }
                    else if (filtrerType == ">=")
                    {
                        allOutstanding = allOutstanding.Where(x => x.AppUser_App_Id >= int.Parse(txtBox.Text.Trim())).ToList();

                    }
                    else if (filtrerType == "<")
                    {
                        allOutstanding = allOutstanding.Where(x => x.AppUser_App_Id < int.Parse(txtBox.Text.Trim())).ToList();

                    }
                    else if (filtrerType == "<=")
                    {
                        allOutstanding = allOutstanding.Where(x => x.AppUser_App_Id <= int.Parse(txtBox.Text.Trim())).ToList();

                    }
                    ViewState["OFilterAppId"] = filtrerType;
                    ViewState["OAppId"] = txtBox.Text.Trim();
                    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                }


                //else if (txtBox.ID == "txtOrder")
                //{
                //    allOutstanding = allOutstanding.Where(x => x.Order.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                //    ViewState["OOrder"] = txtBox.Text.Trim().ToUpper();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtLine")
                //{
                //    string filtrerType = ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeLine")).SelectedItem.Value;

                //    if (filtrerType == "=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Line == int.Parse(txtBox.Text.Trim())).ToList();
                //    }
                //    else if (filtrerType == ">")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Line > int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == ">=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Line >= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Line < int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Line <= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    ViewState["OFilterLine"] = filtrerType;
                //    ViewState["OLine"] = txtBox.Text.Trim();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtStatus")
                //{
                //    string filtrerType = ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeStatus")).SelectedItem.Value;
                //    if (filtrerType == "=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Status == int.Parse(txtBox.Text.Trim())).ToList();
                //    }
                //    else if (filtrerType == ">")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Status > int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == ">=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Status >= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Status < int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Status <= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    ViewState["OFilterStatus"] = filtrerType;
                //    ViewState["OStatus"] = txtBox.Text.Trim();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtToLocation")
                //{
                //    allOutstanding = allOutstanding.Where(x => x.ToLocation.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                //    ViewState["OToLocation"] = txtBox.Text.Trim().ToUpper();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtQty")
                //{
                //    string filtrerType = ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeQty")).SelectedItem.Value;
                //    if (filtrerType == "=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Qty == int.Parse(txtBox.Text.Trim())).ToList();
                //    }
                //    else if (filtrerType == ">")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Qty > int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == ">=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Qty >= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Qty < int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.Qty <= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    ViewState["OFilterQty"] = filtrerType;
                //    ViewState["OQty"] = txtBox.Text.Trim();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtLocation")
                //{
                //    allOutstanding = allOutstanding.Where(x => x.Location.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                //    ViewState["OLocation"] = txtBox.Text.Trim().ToUpper();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtAllocQty")
                //{
                //    string filtrerType = ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeAllocQty")).SelectedItem.Value;
                //    if (filtrerType == "=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.AllocQty == int.Parse(txtBox.Text.Trim())).ToList();
                //    }
                //    else if (filtrerType == ">")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.AllocQty > int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == ">=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.AllocQty >= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.AllocQty < int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.AllocQty <= int.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    ViewState["OFilterAllocQty"] = filtrerType;
                //    ViewState["OAllocQty"] = txtBox.Text.Trim();
                //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                //}
                //else if (txtBox.ID == "txtRegDate")
                //{
                //    string filtrerType = ((DropDownList)grdViewApplications.HeaderRow.FindControl("ddlFilterTypeRegDate")).SelectedItem.Value;
                //    if (filtrerType == "=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.RegDate == DateTime.Parse(txtBox.Text.Trim())).ToList();
                //    }
                //    else if (filtrerType == ">")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.RegDate > DateTime.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == ">=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.RegDate >= DateTime.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.RegDate < DateTime.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    else if (filtrerType == "<=")
                //    {
                //        allOutstanding = allOutstanding.Where(x => x.RegDate <= DateTime.Parse(txtBox.Text.Trim())).ToList();

                //    }
                //    ViewState["OFilterRegDate"] = filtrerType;
                //    ViewState["ORegDate"] = txtBox.Text.Trim();

                //}

                ViewState["lstSubmittedApplication"] = allOutstanding;
                grdViewApplications.DataSource = allOutstanding;
                grdViewApplications.DataBind();

                ResetFilterAndValueGrid();

            }
        }


    }


    protected void grdViewApplications_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["lstSubmittedApplication"] != null)
        {
            List<SubmittedApplication> lstSubmittedApplication = (List<SubmittedApplication>)ViewState["lstSubmittedApplication"];
            grdViewApplications.PageIndex = e.NewPageIndex;
            ViewState["lstSubmittedApplication"] = lstSubmittedApplication;
            grdViewApplications.DataSource = lstSubmittedApplication;
            grdViewApplications.DataBind();
            ResetFilterAndValueGrid();
            // upnlOutstanding.Update();


        }
    }

    private void SortGridViewOutstanding(string sortExpression, string direction)
    {
        if (ViewState["lstSubmittedApplication"] != null)
        {

            List<SubmittedApplication> lstSubmittedApplication = (List<SubmittedApplication>)ViewState["lstSubmittedApplication"];

            var param = Expression.Parameter(typeof(SubmittedApplication), sortExpression);
            var sortby = Expression.Lambda<Func<SubmittedApplication, object>>(Expression.Convert(Expression.Property(param, sortExpression), typeof(object)), param);
            if (direction == "ASC")
            {
                lstSubmittedApplication = lstSubmittedApplication.AsQueryable<SubmittedApplication>().OrderBy(sortby).ToList();
            }
            else
            {
                lstSubmittedApplication = lstSubmittedApplication.AsQueryable<SubmittedApplication>().OrderByDescending(sortby).ToList();
            }
            ViewState["lstSubmittedApplication"] = lstSubmittedApplication;
            grdViewApplications.DataSource = lstSubmittedApplication;
            grdViewApplications.DataBind();

            upnlOutstanding.Update();
            ResetFilterAndValueGrid();
        }
    }

    protected void grdViewApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAppId = ((Label)ea.Row.FindControl("lbl_AppId"));
            Label lblSubmitted = ((Label)ea.Row.FindControl("lbl_Submitted"));
            LinkButton imbtn = (LinkButton)ea.Row.FindControl("btn_Edit");

            Label lblRejected = ((Label)ea.Row.FindControl("lbl_Rejected"));
            LinkButton btnReject = (LinkButton)ea.Row.FindControl("btn_Reject");
            LinkButton btnDeReject = (LinkButton)ea.Row.FindControl("btn_DeReject");

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
            //print button 
            LinkButton btnPrintout = (LinkButton)ea.Row.FindControl("btnPrintout");
            btnPrintout.ID = "btnPrintout__" + lblAppId.Text;


        }


        if (e.Row.RowType == DataControlRowType.DataRow && doneColouring2 == 0)
        {
            GridViewRow headerRow = grdViewApplications.HeaderRow;
            if (ViewState["columnNameO"] != null) columnName = ViewState["columnNameO"].ToString();
            for (int i = 0; i < headerRow.Cells.Count; i++)
            {
                if (headerRow.Cells[i].Controls.Count != 0)
                {
                    //if (!(headerRow.Cells[i].Controls[0] is System.Web.UI.LiteralControl))
                    //{
                    if (((LinkButton)headerRow.Cells[i].Controls[1]).Text == columnName)
                    {
                        headerRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#2F8CDE");
                        Image img = new Image();
                        img.CssClass = "imgClass";
                        if (GridViewSortDirection == SortDirection.Ascending)
                        {
                            img.ImageUrl = "./Images/up.png";

                        }
                        if (GridViewSortDirection == SortDirection.Descending)
                        {
                            img.ImageUrl = "./Images/down.png";
                        }

                        headerRow.Cells[i].Controls.Add(img);
                        doneColouring2 = 1;
                    }
                    //}
                }
            }
        }
    }

    protected void grdViewApplications_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        columnName = e.SortExpression;
        ViewState["columnNameO"] = columnName;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridViewOutstanding(sortExpression, "DESC");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridViewOutstanding(sortExpression, "ASC");
        }

    }


    private void loadgrid1()
    {
        Hashtable ht = new Hashtable();
        ht.Add("submitted", "1");
        //List<SubmittedApplication> lstSubmittedApplication = new List<SubmittedApplication>();
        //lstSubmittedApplication = objOutstanding.GetOutstanding();
        DataSet ds = DSP.DAL.SQL.GetDsBySPArray("oscauser.SP_App_GetUserApplicationsForAdmin", ht);
        ViewState["columnNameO"] = "applicantname";
        grdViewApplications.DataSource = ds;
        grdViewApplications.DataBind();

        ViewState["lstSubmittedApplication"] = grdViewApplications;
        upnlOutstanding.Update();

    }

    private void loadgrid_initial()
    {
        SubmittedApplication objSubApp = new SubmittedApplication();

        List<SubmittedApplication> lstSubmittedApplication = new List<SubmittedApplication>();
        lstSubmittedApplication = objSubApp.GetOutstanding();

        ViewState["columnNameO"] = "applicantname";
        grdViewApplications.DataSource = lstSubmittedApplication;
        grdViewApplications.DataBind();

        ViewState["lstSubmittedApplication"] = lstSubmittedApplication;
        upnlOutstanding.Update();

    }
    #endregion

    #region " xxxxxxxxxxxx"
    #endregion

    public string returnJS(object obj)
    {
        string s = obj.ToString();
        return "GetApplicationForDisplay2("+s+");";


    }
    #region " xxxxxxxxxxxx"


    


    #endregion


}
