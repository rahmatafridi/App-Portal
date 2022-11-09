using DSP.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesAdvisor_Progress_SC : System.Web.UI.Page
{
    public CourseLevel COURSE_LEVEL;
    public int COURSE_LEVEL_NUMER;
    // private static int _CourseId;
    public ApplicationForm _App;


    protected void Page_Load(object sender, EventArgs e)
    {
        Wizard1.PreRender += new EventHandler(Wizard1_PreRender);

        if (!Page.IsPostBack)
        {
            Wizard1.FinishCompleteButtonText = "Submit Application";
            Wizard1.FinishCompleteButtonStyle.CssClass = "button medium blue";
            ddlEnrolmentCourse.DataBind();

            if (Page.Session["CurrentApplication"] != null)
            {
                _App = (ApplicationForm)Page.Session["CurrentApplication"];
                lblAppId.Text = _App._app_id.ToString();
                // _CourseId = _App._app_officeuse1_CourseId;                
                COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);

                if (!_App.isNewApplication)
                {
                    //load office use 
                    txtApp_officeuse_UniqueLearnerReference.Text = _App._app_officeuse_UniqueLearnerReference;
                    txtApp_officeuse_StartDate.Text = _App._app_officeuse_StartDate;
                    txtApp_officeuse_EndDate.Text = _App._app_officeuse_EndDate;
                    txtApp_officeuse_ApprenticeshipFramework.Text = _App._app_officeuse_ApprenticeshipFramework;
                    txtApp_officeuse_LearnerId.Text = _App._app_officeuse_LearnerId;
                    txtApp_officeuse_ReferenceId.Text = _App._app_officeuse_ReferenceId;
                    txtApp_officeuse_CQCInspectionDate.Text = _App._app_officeuse_CQCInspectionDate == "01/01/1900 00:00:00" ? "" : _App._app_officeuse_CQCInspectionDate;

                    txtApp_officeuse_ReferenceDate.Text = _App._app_officeuse_ReferenceDate == "01/01/1900 00:00:00" ? "" : _App._app_officeuse_ReferenceDate;
                    if (_App._app_officeuse_FundingId != 0)
                        DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_office_funding, _App._app_officeuse_FundingId);

                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(txtApp_officeuse_IsEvidenceSeen, _App._app_officeuse_IsEvidenceSeen);
                    txtApp_ReferenceIdType.Text = _App._app_officeuse_ReferenceIdType;


                    txtApp_officeuse_UKPRN.Text = _App._app_officeuse_UKPRN;
                    txtApp_officeuse_EmployerId.Text = _App._app_officeuse_EmployerId;

                    if (_App._app_officeuse1_CourseId != 0)
                        DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEnrolmentCourse, _App._app_officeuse1_CourseId);

                    //load all elements
                    txtName.Text = _App._app_FirstName;
                    txtSurname.Text = _App._app_Surname;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlGender, _App._app_Gender);
                    txtDOB.Text = _App._app_DOB;

                    txtMobile.Text = _App._app_Mobile;
                    txt_Email.Text = _App._app_Email;

                    txt_emp_CompanyName.Text = _App._app_emp_CompanyName;
                    txt_emp_WorkPlaceAddress1.Text = _App._app_emp_WorkPlaceAddress1;
                    txt_emp_WorkPlaceAddress2.Text = _App._app_emp_WorkPlaceAddress2;
                    txt_emp_WorkPlaceAddress3.Text = _App._app_emp_WorkPlaceAddress3;
                    txt_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                    txt_emp_ContactName.Text = _App._app_emp_ContactName;
                    txt_emp_Email.Text = _App._app_emp_Email;
                    txt_ACS_WDSNumber.Text = _App._app_ACS_WDSNumber;

                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ContactConsent, _App._app_mktg_ContactConsent);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPhone, _App._app_mktg_ByPhone);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByEmail, _App._app_mktg_ByEmail);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPost, _App._app_mktg_ByPost);

                    if (COURSE_LEVEL == CourseLevel.L3)
                    {
                    }

                    if (COURSE_LEVEL == CourseLevel.L4)
                    {
                    }
                    if (COURSE_LEVEL == CourseLevel.L5)
                    {
                    }

                    if (!_App.isCompletedApplication)
                        //hide panel for none enrolment officer
                        if (Roles.IsUserInRole(Membership.GetUser().UserName, "EnrolmentOfficer"))
                        {
                            pnl_confirmEnrolment.Visible = true;
                        }
                }
            }
            else
            {
                Server.Transfer("ManageApplications.aspx");
            }
        }
    }

    protected void Wizard1_PreRender(object sender, EventArgs e)
    {
        Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
        SideBarList.DataSource = Wizard1.WizardSteps;
        SideBarList.DataBind();
    }

    protected string GetClassForWizardStep(object wizardStep)
    {
        WizardStep step = wizardStep as WizardStep;

        if (step == null)
        {
            return "";
        }
        int stepIndex = Wizard1.WizardSteps.IndexOf(step);

        if (stepIndex < Wizard1.ActiveStepIndex)
        {
            return "prevStep";
        }
        else if (stepIndex > Wizard1.ActiveStepIndex)
        {
            return "nextStep";
        }
        else
        {
            return "currentStep";
        }
    }

    protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
            COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);

            lblAppId.Text = _App._app_id.ToString();
            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_NextButtonClick() | line: {0} | username: {1} | App id: {2} | Step: {3} | lblAppId: {4} ", "232", Membership.GetUser().UserName, _App._app_id, Wizard1.ActiveStepIndex, lblAppId.Text));
        }
        if (Page.Session["CurrentApplication"] == null)
        {
            if (lblAppId.Text != "")
            {
                int iId = int.Parse(lblAppId.Text);
                _App = new ApplicationForm();
                _App.GetApplicationById(iId);
                COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);

                Page.Session["CurrentApplication"] = _App;
                DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_NextButtonClick() | line: {0} | username: {1} | App id: {2} | Step: {3} | lblAppId: {4} ", "241", Membership.GetUser().UserName, _App._app_id, Wizard1.ActiveStepIndex, lblAppId.Text));
            }
            else
            {
                DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_NextButtonClick(transfering to ManageApplications.aspx) | line: {0} | username: {1} | lblAppId: {2} ", "246", Membership.GetUser().UserName, lblAppId.Text));

                Server.Transfer("ManageApplications.aspx");
            }
        }

        if (!Page.IsValid)
        {
            e.Cancel = true;
            return;
        }
        else
        {
            int iStep = Wizard1.ActiveStepIndex;

            if (CheckAppAndValidate("Wizard1_NextButtonClick()") == false) return;

            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_NextButtonClick() ...now saving and loading steps |username: {0} | App id: {1} | FROM Step: {2} | ", Membership.GetUser().UserName, _App._app_id, iStep));

            switch (iStep)
            {
                case 0:

                    if (SaveStep(0))
                    {
                        LoadDataForStep(2);
                    }
                    else
                    {
                        divError.Visible = true;
                    }
                    break;

                case 1:

                    if (SaveStep(1))
                    {
                        HideControlsForLevel(_App._app_officeuse1_CourseLevel);
                        LoadApplicationForConfirmation(_App);
                    }
                    else
                    {
                        divError.Visible = true;
                    }

                    break;

                case 2:

                    HideControlsForLevel(_App._app_officeuse1_CourseLevel);
                    LoadApplicationForConfirmation(_App);
                    break;
            }
        }
    }

    protected bool CheckAppAndValidate(string sSource)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = new ApplicationForm();
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
            lblAppId.Text = _App._app_id.ToString();

        }
        if (Page.Session["CurrentApplication"] == null)
        {
            if (lblAppId.Text != "")
            {
                int iId = int.Parse(lblAppId.Text);
                _App = new ApplicationForm();
                _App.GetApplicationById(iId);
                Page.Session["CurrentApplication"] = _App;
            }
            else
            {
                _App = null;
            }
        }

        if (_App == null)
        {
            lblError.Visible = true;

            DSP.BAL.Log.WriteLogTxt(String.Format("CheckAppAndValidate({0}) | username: {1} | App id: {2} | Step: {3} | ", sSource, Membership.GetUser().UserName, "null", Wizard1.ActiveStepIndex));
            return false;
        }
        if (_App._app_id == 0)
        {
            lblError.Visible = true;
            DSP.BAL.Log.WriteLogTxt(String.Format("CheckAppAndValidate({0}) | username: {1} | App id: {2} | Step: {3} | ", sSource, Membership.GetUser().UserName, "0", Wizard1.ActiveStepIndex));

            return true;
        }
        DSP.BAL.Log.WriteLogTxt(String.Format("CheckAppAndValidate({0}) | username: {1} | App id: {2} | Step: {3} | ", sSource, Membership.GetUser().UserName, _App._app_id, Wizard1.ActiveStepIndex));

        lblError.Visible = false;

        return true;
    }
    protected void btnSaveAndLogout_Click(object sender, EventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
        }

        int iStep = Wizard1.ActiveStepIndex;

        if (CheckAppAndValidate("btnSaveAndLogout_Click()") == false) return;

        DSP.BAL.Log.WriteLogTxt(String.Format("btnSaveAndLogout_Click() ...now saving steps |username: {0} | App id: {1} | Step: {2} | ", Membership.GetUser().UserName, _App._app_id, iStep));

        SaveStep(iStep);

        System.Web.UI.Control lw = (System.Web.UI.Control)this.Master.FindControl("loggedinfo");
        if (lw != null)
        { lw.Visible = false; }

        Response.Redirect("~/Portal/Logout.aspx");
    }

    protected bool SaveStep(int iStep)
    {
        if (_App == null) return false;
        DSP.BAL.Log.WriteLogTxt(String.Format("SaveStep({2}) |username: {0} | App id: {1} ", Membership.GetUser().UserName, _App._app_id, iStep));

        CheckChangeIfAny(iStep);
        switch (iStep)
        {
            case 0:
                //check changes here

                _App._app_FirstName = DSP.BAL.Basic.FormatStringForSQL(txtName.Text.Trim());
                _App._app_Surname = DSP.BAL.Basic.FormatStringForSQL(txtSurname.Text.Trim());
                _App._app_Gender = DSP.BAL.Basic.FormatStringForSQL(ddlGender.Text.Trim());
                _App._app_DOB = DSP.BAL.Basic.FormatStringForSQL(txtDOB.Text.Trim());
                _App._app_Mobile = DSP.BAL.Basic.FormatStringForSQL(txtMobile.Text.Trim());
                _App._app_Email = DSP.BAL.Basic.FormatStringForSQL(txt_Email.Text.Trim());

                return _App.SaveApplication();
            //break;
            case 1:
                _App._app_emp_CompanyName = DSP.BAL.Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim());
                _App._app_emp_WorkPlaceAddress1 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim());
                _App._app_emp_WorkPlaceAddress2 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim());
                _App._app_emp_WorkPlaceAddress3 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim());
                _App._app_emp_WorkPlacePostCode = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlacePostCode.Text.Trim());
                _App._app_emp_Tel = DSP.BAL.Basic.FormatStringForSQL(txt_emp_Tel.Text.Trim());
                _App._app_emp_ContactName = DSP.BAL.Basic.FormatStringForSQL(txt_emp_ContactName.Text.Trim());
                _App._app_emp_Email = DSP.BAL.Basic.FormatStringForSQL(txt_emp_Email.Text.Trim());
                _App._app_ACS_WDSNumber = DSP.BAL.Basic.FormatStringForSQL(txt_ACS_WDSNumber.Text.Trim());

                return _App.SaveApplication();
            default:

                return false;
        }

        // now update to session
        Page.Session["CurrentApplication"] = _App;
        Page.Session["CurrentApplicationId"] = _App._app_id;
        Page.Session["CurrentApplicationNew"] = _App.isNewApplication;

    }
    private void LoadApplicationForConfirmation(ApplicationForm _App)
    {
        lit_App_FirstName.Text = _App._app_FirstName;
        lit_App_Surname.Text = _App._app_Surname;
        lit_App_Gender.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Gender", _App._app_Gender);
        lit_App_DOB.Text = _App._app_DOB;
        lit_App_Mobile.Text = _App._app_Mobile;
        lit_App_Email.Text = _App._app_Email;

        lit_App_emp_CompanyName.Text = _App._app_emp_CompanyName;
        lit_App_emp_WorkPlaceAddress.Text = _App._app_emp_WorkPlaceAddress1 + "</br>" + _App._app_emp_WorkPlaceAddress2 + "</br>" + _App._app_emp_WorkPlaceAddress3;
        lit_App_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
        
        lit_App_emp_Tel.Text = _App._app_emp_Tel;
        lit_App_emp_Email.Text = _App._app_emp_Email;
        lit_App_emp_ContactName.Text = _App._app_emp_ContactName;
        lit_App_ACS_WDSNumber.Text = _App._app_ACS_WDSNumber;


         
        // fetch the en-GB culture
        CultureInfo ukCulture = new CultureInfo("en-GB");
        // pass the DateTimeFormat information to DateTime.Parse
        DateTime myDateTime = DateTime.Parse(DateTime.Now.ToString(), ukCulture.DateTimeFormat);
        txtApplicationDate.Text = myDateTime.ToString();

    }
    private void LoadDataForStep(int iStepToLoad)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
        }
        else
        {

        }
        switch (iStepToLoad)
        {
            case 2:
                DSP.BAL.Log.WriteLogTxt(String.Format("LoadDataForStep() | username: {0} |  STEP 2 ", Membership.GetUser().UserName));
                DisableValidatorForLevel(_App._app_officeuse1_CourseLevel);

                if (!_App.isNewApplication)
                {
                    txt_emp_CompanyName.Text = _App._app_emp_CompanyName;
                    txt_emp_WorkPlaceAddress1.Text = _App._app_emp_WorkPlaceAddress1;
                    txt_emp_WorkPlaceAddress2.Text = _App._app_emp_WorkPlaceAddress2;
                    txt_emp_WorkPlaceAddress3.Text = _App._app_emp_WorkPlaceAddress3;
                    txt_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                    txt_emp_ContactName.Text = _App._app_emp_ContactName;

                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ContactConsent, _App._app_mktg_ContactConsent);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPhone, _App._app_mktg_ByPhone);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByEmail, _App._app_mktg_ByEmail);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPost, _App._app_mktg_ByPost);
                }
                break;
            case 5:

                DSP.BAL.Log.WriteLogTxt(String.Format("LoadDataForStep() | username: {0} |  STEP 5 ", Membership.GetUser().UserName));

                HideControlsForLevel(_App._app_officeuse1_CourseLevel);

                break;
        }
    }
    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        bool bCanProceed = false;

        _App = (ApplicationForm)Page.Session["CurrentApplication"];
        if (_App != null)
        {
            _App._app_mktg_ContactConsent = (chk_mktg_ContactConsent.Checked ? "1" : "0");
            _App._app_mktg_ByPhone = (chk_mktg_ByPhone.Checked ? "1" : "0");
            _App._app_mktg_ByEmail = (chk_mktg_ByEmail.Checked ? "1" : "0");
            _App._app_mktg_ByPost = (chk_mktg_ByPost.Checked ? "1" : "0");

            string hid_printname = Request.Form["ctl00$BodyContent$Wizard1$txtPrintName"];
            string hid_date = Request.Form["hid_dt"];
            _App._app_PrintName = hid_printname; // txtPrintName.Text.Trim();
            _App._app_ApplicationDate = hid_date;


            _App.SaveApplication();
            string sketchData = Request.Form["sketch_data"];

            if (sketchData != "")
            {

                byte[] bytes = Convert.FromBase64String(sketchData.Split(',')[1]);

                saveCanvas(bytes, _App._app_id);
                bCanProceed = true;

            }
            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | username: {0} | Application ready for submission ", Membership.GetUser().UserName));
        }
        else
        {
            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | expired session username: {0} ", Membership.GetUser().UserName));

            Response.Redirect("~/Portal/SalesAdvisor/ManageApplications.aspx");
        }

        if (bCanProceed == false) { return; }

        if (Page.Session["CurrentApplication"] != null && bCanProceed)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];

            _App._app_mktg_ContactConsent = (chk_mktg_ContactConsent.Checked ? "1" : "0");
            _App._app_mktg_ByPhone = (chk_mktg_ByPhone.Checked ? "1" : "0");
            _App._app_mktg_ByEmail = (chk_mktg_ByEmail.Checked ? "1" : "0");
            _App._app_mktg_ByPost = (chk_mktg_ByPost.Checked ? "1" : "0");

            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | username: {0} | Application ready for submission | App id: {1} ", Membership.GetUser().UserName, _App._app_id, _App._app_id));

            _App.SubmitApplicationAdmin();

            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | username: {0} | Application SUBMITTED | App id: {1} ", Membership.GetUser().UserName, _App._app_id, _App._app_id));

            Response.Redirect("~/Portal/SalesAdvisor/ManageApplications.aspx");
        }
        else
        {
            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | username: {0} | Application not found in session ", Membership.GetUser().UserName, _App._app_id));

            Server.Transfer(vars.ERROR_PAGE_SESSIONTIMEDOUT);
        }
    }

    protected void Wizard1_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
            COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);

            lblAppId.Text = _App._app_id.ToString();
            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_PreviousButtonClick() | line: {0} | username: {1} | App id: {2} | Step: {3} | lblAppId: {4} ", "232", Membership.GetUser().UserName, _App._app_id, Wizard1.ActiveStepIndex, lblAppId.Text));
        }
        if (Page.Session["CurrentApplication"] == null)
        {
            if (lblAppId.Text != "")
            {
                int iId = int.Parse(lblAppId.Text);
                _App = new ApplicationForm();
                _App.GetApplicationById(iId);
                COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);

                Page.Session["CurrentApplication"] = _App;
                DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_PreviousButtonClick() | line: {0} | username: {1} | App id: {2} | Step: {3} | lblAppId: {4} ", "241", Membership.GetUser().UserName, _App._app_id, Wizard1.ActiveStepIndex, lblAppId.Text));
            }
            else
            {
                DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_PreviousButtonClick(transfering to ManageApplications.aspx) | line: {0} | username: {1} | lblAppId: {2} ", "246", Membership.GetUser().UserName, lblAppId.Text));

                Server.Transfer("ManageApplications.aspx");
            }
        }
    }
    #region "disable validators"

    protected void DisableValidatorForLevel(int CourseLevel)
    {
        DSP.BAL.Log.WriteLogTxt(String.Format("DisableValidatorForLevel() | username: {0} | entering with CourseLevel: {1} |  ", Membership.GetUser().UserName, CourseLevel));

        switch (CourseLevel)
        {
            case 3:
                break;
            case 4:

                break;
            case 5:

                break;
            default:
                break;
        }
    }

    #endregion

    #region "hide controls for different levels"

    protected void HideControlsForLevel(int CourseLevel)
    {
        switch (CourseLevel)
        {
            case 3:

                break;
            case 4:

                break;
            case 5:
                break;
            default:
                break;
        }
    }

    #endregion

    protected void Wizard1_NextButtonClick(object sender, EventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
            COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);
            lblAppId.Text = _App._app_id.ToString();
        }

        int iStep = Wizard1.ActiveStepIndex;

        switch (iStep)
        {
            case 1:
                string sApp_emp_CompanyName = txt_emp_CompanyName.Text.Trim();
                break;

            case 3:
                break;

            case 5:

                break;
        }
    }

    #region "saving signature"
    protected void btnSaveSign_Click(object sender, EventArgs e)
    {
        //DSP.BAL.Log.WriteLogTxt(String.Format("btnSaveSign_Click() ..."));

        //string sketchData = Request.Form["sketch_data"];
        //byte[] bytes = Convert.FromBase64String(sketchData.Split(',')[1]);

        //saveCanvas(bytes);



    }

    protected void saveCanvas(byte[] bytes, int iAppId)
    {
        //saving to file (for use in osca or portal)
        string sPath = Path.Combine(ConfigurationManager.AppSettings["cfg_appportaldata_path"], ConfigurationManager.AppSettings["cfg_appportaldata_app_signatures"], iAppId + ".png");

        if (bytes != null)
        {
            //using (var imageFile = new FileStream(Server.MapPath("~/images/signature_.png"), FileMode.Create))
            using (var imageFile = new FileStream(sPath, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
                imageFile.Close();
            }

        }

        //saving to DB
        DSP.DAL.SQL.ExecuteSQL(string.Format("DELETE FROM oscauser.ApplicationsSignatures WHERE AppSig_Id_App = {0} ; ", iAppId));

        Hashtable ht = new Hashtable();
        ht.Add("@App_Id", iAppId);
        ht.Add("@Username", Membership.GetUser().UserName);
        ht.Add("@Signature", bytes);
        int leng = bytes.Length;
        DSP.DAL.SQL.ExecuteSPByHashTable("SP_App_InsertSignature", ht);




    }

    #endregion


    #region admin section

    protected void btnHomePortal_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Portal/SalesAdvisor/ManageApplications.aspx");

    }
    protected void btnSaveOfficeUse_Click(object sender, EventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];

            _App._app_officeuse_UniqueLearnerReference = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_UniqueLearnerReference.Text.Trim());
            _App._app_officeuse_StartDate = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_StartDate.Text.Trim());
            _App._app_officeuse_EndDate = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_EndDate.Text.Trim());
            _App._app_officeuse_ApprenticeshipFramework = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_ApprenticeshipFramework.Text.Trim());
            _App._app_officeuse_LearnerId = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_LearnerId.Text.Trim());
            _App._app_officeuse_ReferenceId = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_ReferenceId.Text.Trim());
            _App._app_officeuse_CQCInspectionDate = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_CQCInspectionDate.Text.Trim());
            _App._app_officeuse_UKPRN = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_UKPRN.Text.Trim());
            _App._app_officeuse_EmployerId = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_EmployerId.Text.Trim());

            _App._app_officeuse_ReferenceDate = DSP.BAL.Basic.FormatStringForSQL(txtApp_officeuse_ReferenceDate.Text.Trim());
            _App._app_officeuse_IsEvidenceSeen = txtApp_officeuse_IsEvidenceSeen.Checked;
            _App._app_officeuse_ReferenceIdType = DSP.BAL.Basic.FormatStringForSQL(txtApp_ReferenceIdType.Text.Trim());
            _App._app_officeuse_FundingId = int.Parse(ddl_office_funding.SelectedValue);
            _App._app_officeuse_FundingTitle = ddl_office_funding.SelectedItem.Text;

            _App.SaveApplication();
        }
    }
    protected void btnConfirmEnrolment_Click(object sender, EventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
            _App._app_officeuse1_IsLiteracyNumeracyDone = true;
            _App._app_officeuse1_IsAllDocumentsSigned = true;
            _App._app_officeuse1_IsConfirmEnrolment = true;
            _App._app_officeuse1_CourseId = int.Parse(ddlEnrolmentCourse.SelectedValue);
            _App.SaveApplication();
            _App.SubmitApplicationAdmin();

            int learnerId = _App.EnrolNowApplicationAdmin();
            if (ConfigurationManager.AppSettings["cfg_test"] != "true")
            {
                if (learnerId > 0)
                {
                    string url = ConfigurationManager.AppSettings["cfg_qcs_url"];
                    string locationId = ConfigurationManager.AppSettings["cfg_qcs_location"];
                    var request = (HttpWebRequest)WebRequest.Create(url);

                    string postData = string.Format("{{\"FirstName\":\"{0}\",\"LastName\":\"{1}\",\"UserName\":\"{2}\",\"Password\":\"{3}\",\"LocationId\":\"{4}\",\"Email\":\"{5}\"}}",
                                                        _App._app_FirstName, _App._app_Surname, learnerId, _App._app_Saved_Password, locationId, _App._app_Email);
                    byte[] data = Encoding.UTF8.GetBytes(postData);

                    //string username = "asadmin";
                    //string password = "@c3$k1L";
                    string username = ConfigurationManager.AppSettings["cfg_qcs_username"];
                    string password = ConfigurationManager.AppSettings["cfg_qcs_password"];

                    string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                    request.Headers.Add("Authorization", "Basic " + encoded);

                    request.Method = "POST";
                    //request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentType = "application/json";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    try
                    {
                        var response = (HttpWebResponse)request.GetResponse();

                        //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Response.Redirect("~/Portal/SalesAdvisor/ManageApplications.aspx");
                        }
                        else
                        {
                            SendEmailForFailedQCSRegistration(_App._app_FirstName + " " + _App._app_Surname, "Unknown error.");
                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('QCS registration failed. ERROR : Unknown reason. ');window.location ='ManageApplications.aspx';",
                            true);
                        }
                    }
                    catch (WebException ex)
                    {
                        string message = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                        SendEmailForFailedQCSRegistration(_App._app_FirstName + " " + _App._app_Surname, message);
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('QCS registration failed. ERROR : " + message + "');window.location ='ManageApplications.aspx';",
                            true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('QCS registration failed. ERROR : Unknown reason. ');window.location ='ManageApplications.aspx';",
                            true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('QCS registration failed. ERROR : Test development running. ');window.location ='ManageApplications.aspx';",
                            true);
            }
        }
    }

    #endregion

    private bool SendEmailForFailedQCSRegistration(string userName, string message)
    {
        Hashtable ht = new Hashtable();
        ht.Add("[USERNAME]", userName);
        ht.Add("[ERRORMESSAGE]", message);

        Tuple<string, string> tuple = DBL.GetSubjectAndEmailTemplateBodyReplacedByCode("RFQCS", ht);

        DSP.BAL.ASPMail emailContactUs = new DSP.BAL.ASPMail();

        emailContactUs.sTo = ConfigurationManager.AppSettings["cfg_email_template_email_recipient"];
        emailContactUs.sFrom = ConfigurationManager.AppSettings["cfg_portal_email_from"];

        emailContactUs.sSubject = tuple.Item1;
        emailContactUs.sBody = tuple.Item2;

        try
        {
            emailContactUs.SendMail();
        }
        catch (Exception exx)
        {
            emailContactUs.sTo = "web@fdesigns.co.uk";
            emailContactUs.sSubject += "ERROR: " + "oEmailNotifications.SendMail_ContactUs()";
            emailContactUs.sBody += exx.Message;
            emailContactUs.SendMail();
        }
        return true;
    }


    private bool SetValueOfChanges(string valueFrom, string valueTo, string fieldName)
    {
        applicationsTrackChangesList.Add(new ApplicationForm.ApplicationsTrackChanges
        {
            ATC_ValueFrom = valueFrom,
            ATC_ValueTo = valueTo,
            ATC_FieldName = fieldName
        });
        return true;
    }

    List<ApplicationForm.ApplicationsTrackChanges> applicationsTrackChangesList;
    private bool CheckChangeIfAny(int iStep)
    {
        applicationsTrackChangesList = new List<ApplicationForm.ApplicationsTrackChanges>();
        bool isAmended = false;
        int appId = _App._app_id;
        int userId = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName);

        switch (iStep)
        {
            case 0:
                if (_App._app_FirstName != DSP.BAL.Basic.FormatStringForSQL(txtName.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_FirstName, Basic.FormatStringForSQL(txtName.Text.Trim()), "app_FirstName"); isAmended = true;
                }
                if (_App._app_Surname != DSP.BAL.Basic.FormatStringForSQL(txtSurname.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_Surname, Basic.FormatStringForSQL(txtSurname.Text.Trim()), "app_Surname"); isAmended = true;
                }
                if (_App._app_Gender != DSP.BAL.Basic.FormatStringForSQL(ddlGender.Text.Trim()))
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Gender", _App._app_Gender), DBL.GetApplicationOptionTitle("Gender", Basic.FormatStringForSQL(ddlGender.Text.Trim())), "app_Gender"); isAmended = true;
                }
                if (_App._app_DOB != DSP.BAL.Basic.FormatStringForSQL(txtDOB.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_DOB, Basic.FormatStringForSQL(txtDOB.Text.Trim()), "app_DOB"); isAmended = true;
                }
                if (_App._app_Mobile != DSP.BAL.Basic.FormatStringForSQL(txtMobile.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_Mobile, Basic.FormatStringForSQL(txtMobile.Text.Trim()), "app_Mobile"); isAmended = true;
                }
                if (_App._app_Email != DSP.BAL.Basic.FormatStringForSQL(txt_Email.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_Email, Basic.FormatStringForSQL(txt_Email.Text.Trim()), "app_Email"); isAmended = true;
                }
                return _App.SaveChangesToApplicationsTrackChanges(applicationsTrackChangesList, _App._app_id, userId, isAmended);

            case 2:
                if (_App._app_emp_CompanyName != DSP.BAL.Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_CompanyName, Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim()), "app_emp_CompanyName"); isAmended = true;
                }
                if (_App._app_emp_WorkPlaceAddress1 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim()) || _App._app_emp_WorkPlaceAddress2 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim()) || _App._app_emp_WorkPlaceAddress3 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_WorkPlaceAddress1 + "\n" + _App._app_emp_WorkPlaceAddress2 + "\n" + _App._app_emp_WorkPlaceAddress3, Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim()) + "\n" + Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim()) + "\n" + Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim())
                        , "app_emp_WorkPlaceAddress1"); isAmended = true;
                }
                if (_App._app_emp_WorkPlacePostCode != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlacePostCode.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_WorkPlacePostCode, Basic.FormatStringForSQL(txt_emp_WorkPlacePostCode.Text.Trim()), "app_emp_WorkPlacePostCode"); isAmended = true;
                }
                if (_App._app_emp_Tel != DSP.BAL.Basic.FormatStringForSQL(txt_emp_Tel.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_Tel, Basic.FormatStringForSQL(txt_emp_Tel.Text.Trim()), "app_emp_Tel"); isAmended = true;
                }
                if (_App._app_emp_ContactName != DSP.BAL.Basic.FormatStringForSQL(txt_emp_ContactName.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_ContactName, Basic.FormatStringForSQL(txt_emp_ContactName.Text.Trim()), "app_emp_ContactName"); isAmended = true;
                }
                if (_App._app_emp_Email != DSP.BAL.Basic.FormatStringForSQL(txt_emp_Email.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_Email, Basic.FormatStringForSQL(txt_emp_Email.Text.Trim()), "app_emp_Email"); isAmended = true;
                }
                if (_App._app_ACS_WDSNumber != DSP.BAL.Basic.FormatStringForSQL(txt_ACS_WDSNumber.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_ACS_WDSNumber, Basic.FormatStringForSQL(txt_ACS_WDSNumber.Text.Trim()), "app_ACS_WDSNumber"); isAmended = true;
                }
                if (_App._app_mktg_HearAbout != "")
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Marketing", _App._app_mktg_HearAbout), DBL.GetApplicationOptionTitle("Marketing", _App._app_mktg_HearAbout), "app_mktg_HearAbout"); isAmended = true;
                }
                if (_App._app_mktg_ContactConsent != (chk_mktg_ContactConsent.Checked ? "1" : "0"))
                {
                    SetValueOfChanges(DBL.GetChecked(_App._app_mktg_ContactConsent), DBL.GetChecked(chk_mktg_ContactConsent.Checked ? "1" : "0"), "app_mktg_ContactConsent"); isAmended = true;
                }
                if (_App._app_mktg_ByPhone != (chk_mktg_ByPhone.Checked ? "1" : "0"))
                {
                    SetValueOfChanges(DBL.GetChecked(_App._app_mktg_ByPhone), DBL.GetChecked(chk_mktg_ByPhone.Checked ? "1" : "0"), "app_mktg_ByPhone"); isAmended = true;
                }
                if (_App._app_mktg_ByEmail != (chk_mktg_ByEmail.Checked ? "1" : "0"))
                {
                    SetValueOfChanges(DBL.GetChecked(_App._app_mktg_ByEmail), DBL.GetChecked(chk_mktg_ByEmail.Checked ? "1" : "0"), "app_mktg_ByEmail"); isAmended = true;
                }
                if (_App._app_mktg_ByPost != (chk_mktg_ByPost.Checked ? "1" : "0"))
                {
                    SetValueOfChanges(DBL.GetChecked(_App._app_mktg_ByPost), DBL.GetChecked(chk_mktg_ByPost.Checked ? "1" : "0"), "app_mktg_ByPost"); isAmended = true;
                }
                return _App.SaveChangesToApplicationsTrackChanges(applicationsTrackChangesList, _App._app_id, userId, isAmended);
            //  break;

            default:
                return false;
        }
    }
}
