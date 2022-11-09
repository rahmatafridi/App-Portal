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
public partial class Application_Progress_ESF : System.Web.UI.Page
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
            //ddlEnrolmentCourse.DataBind();

            if (Page.Session["CurrentApplication"] != null)
            {
                _App = (ApplicationForm)Page.Session["CurrentApplication"];
                lblAppId.Text = _App._app_id.ToString();
                // _CourseId = _App._app_officeuse1_CourseId;                
                COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);

                if (!_App.isNewApplication)
                {

                    //load office use 
                   
                    //load all elements
                    txtName.Text = _App._app_FirstName;
                    txtSurname.Text = _App._app_Surname;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlTitles, _App._app_Title);
                    txtNI.Text = _App._app_NI;
                    txt_Unique_Number.Text = _App._app_Esf_Q_Unique_Number;
                    txtAddress1.Text = _App._app_PermAddress1;
                    txtAddress2.Text = _App._app_PermAddress2;
                    txtAddress3.Text = _App._app_PermAddress3;
                    txtPostcode.Text = _App._app_PermPostCode;
                    txtTel.Text = _App._app_HomeTel;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlGender, _App._app_Gender);
                    txtDOB.Text = _App._app_DOB;

                    txtMobile.Text = _App._app_Mobile;
                    txt_Email.Text = _App._app_Email;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlNationality, _App._app_Nationality);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsLivedEULast3Years, _App._app_IsLivedEULast3Years);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlrefugee, _App._app_Esf_Q_Refugee);
                    txtNonEUUKHowLongLiveInUK.Text = _App._app_NonEUUKHowLongLiveInUK;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlgrantedleave, _App._app_Esf_Q_Granted_Leave);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEthnicity, _App._app_Ethnicity);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlsingleadult, _App._app_Esf_Q_Single_Adult);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlAnyDisability, _App._app_AnyDisability);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlAnyDisabilityPrimary, _App._app_AnyDisabilityPrimary);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlNeedLearningSupport, _App._app_NeedLearningSupport);

                    LoadTicksAndCheck(_App._app_AnyDisabilitySecondaries);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_JobFunction, _App._app_job_JobFunction);
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                    txt_type_ServiceProvider.Text = _App._app_Esf_Q_Type_Service_Provider;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlOrg_Skill, _App._app_Org_Skill);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Org_Reg_Cqc, _App._app_Org_Reg_Cqc);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Org_Cqc, _App._app_Org_Cqc);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Org_Emp, _App._app_Org_Employee);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlmangerreg, _App._app_Esf_Q_Manager_Register);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlorgpid, _App._app_Org_PId);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlorgreglocalAuthority, _App._app_Org_Reg_Local_Authority);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlmillionbalance, _App._app_Esf_Q_Million_Balance);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlbasicenglish, _App._app_Esf_Q_Basic_English);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlbasicmath, _App._app_Esf_Q_Basic_Math);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddllevel2english, _App._app_Esf_Q_Level_2_English);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddllevel2math, _App._app_Esf_Q_Level_2_Math);
                    txt_hight_qualification.Text = _App._app_Esf_Q_High_Qualification;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Access_Skill_Hold, _App._app_Esf_Q_Access_Skill_Hold);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_European_Social, _App._app_Esf_Q_European_Social);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Employee_Million, _App._app_Esf_Q_Employee_Million);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Behalf, _App._app_Esf_Q_Behalf);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(dll_Assessment, _App._app_Esf_Q_Assessment);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Access_Skill, _App._app_Esf_Q_Access_Skill);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Info_Supplied, _App._app_Esf_Q_Info_Supplied);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Legally_Uk, _App._app_Esf_Q_Legally_Uk);
                    


                    txt_emp_CompanyName.Text = _App._app_emp_CompanyName;
                    txt_emp_WorkPlaceAddress1.Text = _App._app_emp_WorkPlaceAddress1;
                    //txt_emp_WorkPlaceAddress2.Text = _App._app_emp_WorkPlaceAddress2;
                    txt_emp_WorkPlaceAddress3.Text = _App._app_emp_WorkPlaceAddress3;
                    txt_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                   // txt_emp_ContactName.Text = _App._app_emp_ContactName;
                    //txt_emp_Email.Text = _App._app_emp_Email;
                   // txt_ACS_WDSNumber.Text = _App._app_ACS_WDSNumber;

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
                            //pnl_confirmEnrolment.Visible = true;
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
                        LoadDataForStep(3);
                    }
                    else
                    {
                        divError.Visible = true;
                    }

               
                    break;

                case 2:
                    if (SaveStep(2))
                    {
                        LoadDataForStep(4);
                    }
                    else
                    {
                        divError.Visible = true;
                    }
                    break;
                case 3:
                    if (SaveStep(3))
                    {
                        HideControlsForLevel(_App._app_officeuse1_CourseLevel);
                        LoadApplicationForConfirmation(_App);
                    }
                    else
                    {
                        divError.Visible = true;
                    }

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
    private void LoadTicksAndCheck(string sAllIds)
    {
        string[] singleIds = sAllIds.Split(',');
        foreach (string s in singleIds)
        {
            if (s != "")
            {
                foreach (ListItem li in chkListDisabilities.Items)
                {
                    if (li.Value == s.Trim())
                    {
                        li.Selected = true;
                    }
                }
            }
        }
    }
    private string getSelectedTicks()
    {
        string sAllTicks = "";

        foreach (ListItem li in chkListDisabilities.Items)
        {
            if (li.Selected)
            {
                sAllTicks += li.Value + ",";
            }
        }
        if (sAllTicks.Length > 0)
        {
            sAllTicks = sAllTicks.Substring(0, sAllTicks.Length - 1);
        }
        return sAllTicks;

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
                _App._app_Title = ddlTitles.SelectedValue;
                _App._app_NI = DSP.BAL.Basic.FormatStringForSQL(txtNI.Text.Trim());
                _App._app_Esf_Q_Unique_Number = DSP.BAL.Basic.FormatStringForSQL(txt_Unique_Number.Text.Trim());
                _App._app_PermAddress1 = DSP.BAL.Basic.FormatStringForSQL(txtAddress1.Text.Trim());
                _App._app_PermAddress2 = DSP.BAL.Basic.FormatStringForSQL(txtAddress2.Text.Trim());
                _App._app_PermAddress3 = DSP.BAL.Basic.FormatStringForSQL(txtAddress3.Text.Trim());
                _App._app_PermPostCode = DSP.BAL.Basic.FormatStringForSQL(txtPostcode.Text.Trim());
                _App._app_HomeTel = DSP.BAL.Basic.FormatStringForSQL(txtTel.Text.Trim());
                _App._app_Mobile = DSP.BAL.Basic.FormatStringForSQL(txtMobile.Text.Trim());
                _App._app_Email = DSP.BAL.Basic.FormatStringForSQL(txt_Email.Text.Trim());
                _App._app_Nationality = ddlNationality.SelectedValue;
                _App._app_IsLivedEULast3Years = DSP.BAL.Basic.FormatStringForSQL(ddlIsLivedEULast3Years.Text.Trim());
                _App._app_NonEUUKHowLongLiveInUK = DSP.BAL.Basic.FormatStringForSQL(txtNonEUUKHowLongLiveInUK.Text.Trim());
                _App._app_Esf_Q_Refugee = DSP.BAL.Basic.FormatStringForSQL(ddlrefugee.SelectedValue);
                _App._app_Esf_Q_Granted_Leave= DSP.BAL.Basic.FormatStringForSQL(ddlgrantedleave.SelectedValue);
                _App._app_Ethnicity = ddlEthnicity.SelectedValue;
                _App._app_Esf_Q_Single_Adult = ddlsingleadult.SelectedValue;
                _App._app_AnyDisability = ddlAnyDisability.SelectedValue;
                _App._app_AnyDisabilityPrimary = ddlAnyDisabilityPrimary.SelectedValue;
                _App._app_AnyDisabilitySecondaries = getSelectedTicks();
                _App._app_NeedLearningSupport = ddlNeedLearningSupport.SelectedValue;


                return _App.SaveApplication();
            //break;
            case 1:
                _App._app_emp_CompanyName = DSP.BAL.Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim());
                _App._app_emp_WorkPlaceAddress1 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim());
                //_App._app_emp_WorkPlaceAddress2 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim());
                _App._app_emp_WorkPlaceAddress3 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim());
                _App._app_emp_WorkPlacePostCode = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlacePostCode.Text.Trim());
                _App._app_emp_Tel = DSP.BAL.Basic.FormatStringForSQL(txt_emp_Tel.Text.Trim());
                _App._app_Esf_Q_Type_Service_Provider = DSP.BAL.Basic.FormatStringForSQL(txt_type_ServiceProvider.Text.Trim());
                _App._app_job_JobFunction = ddl_job_JobFunction.SelectedValue;
                _App._app_Org_Skill = ddlOrg_Skill.SelectedValue;
                _App._app_Org_Cqc = ddl_Org_Cqc.SelectedValue;
                _App._app_Org_Reg_Cqc = ddl_Org_Reg_Cqc.SelectedValue;
                _App._app_Org_Employee = ddl_Org_Emp.SelectedValue;
                _App._app_Esf_Q_Manager_Register = ddlmangerreg.SelectedValue;
                _App._app_Org_PId = ddlorgpid.SelectedValue;
                _App._app_Org_Reg_Local_Authority = ddlorgreglocalAuthority.SelectedValue;
                _App._app_Esf_Q_Million_Balance = ddlmillionbalance.SelectedValue;

               

                return _App.SaveApplication();
            case 2:
                _App._app_Esf_Q_Basic_Math = ddlbasicmath.SelectedValue;
                _App._app_Esf_Q_Basic_English = ddlbasicenglish.SelectedValue;
                _App._app_Esf_Q_Level_2_English = ddllevel2english.SelectedValue;
                _App._app_Esf_Q_Level_2_Math = ddllevel2math.SelectedValue;
                _App._app_Esf_Q_High_Qualification = DSP.BAL.Basic.FormatStringForSQL(txt_hight_qualification.Text.Trim());
                return _App.SaveApplication();
            case 3:
                _App._app_Esf_Q_Access_Skill_Hold = ddl_Access_Skill_Hold.SelectedValue;
                _App._app_Esf_Q_European_Social = ddl_European_Social.SelectedValue;
                _App._app_Esf_Q_Employee_Million = ddl_Employee_Million.SelectedValue;
                _App._app_Esf_Q_Behalf = ddl_Behalf.SelectedValue;
                _App._app_Esf_Q_Assessment = dll_Assessment.SelectedValue;
                _App._app_Esf_Q_Access_Skill = ddl_Access_Skill.SelectedValue;
                _App._app_Esf_Q_Info_Supplied = ddl_Info_Supplied.SelectedValue;
                _App._app_Esf_Q_Legally_Uk = ddl_Legally_Uk.SelectedValue;
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
        lit_App_Title.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Title", _App._app_Title);
        lit_App_FirstName.Text = _App._app_FirstName;
        lit_App_Surname.Text = _App._app_Surname;
        lit_App_Gender.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Gender", _App._app_Gender);
        lit_App_DOB.Text = _App._app_DOB;
        lit_App_Mobile.Text = _App._app_Mobile;
        lit_App_Email.Text = _App._app_Email;
        lit_App_NI.Text = _App._app_NI;
        lit_App_Unique_Number.Text = _App._app_Esf_Q_Unique_Number;

        lit_App_PermAddress1.Text = _App._app_PermAddress1 + "</br>" + _App._app_PermAddress2 + "</br>" + _App._app_PermAddress3;
        lit_App_PermPostCode.Text = _App._app_PermPostCode;

        lit_App_Job_Role.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Job Function", _App._app_job_JobFunction);
       
        lit_App_emp_CompanyName.Text = _App._app_emp_CompanyName;
        lit_App_emp_WorkPlaceAddress.Text = _App._app_emp_WorkPlaceAddress1 + "</br>" + _App._app_emp_WorkPlaceAddress2 + "</br>" + _App._app_emp_WorkPlaceAddress3;
        lit_App_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;

        lit_App_emp_Tel.Text = _App._app_emp_Tel;
        lit_App_Type_Service_Proivded.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Type_Service_Provider);
        
        lit_App_Org_Skill.Text= DSP.BAL.DBL.GetYesNo(_App._app_Org_Skill);
        lit_App_Org_Reg_Cqc.Text = DSP.BAL.DBL.GetYesNo(_App._app_Org_Reg_Cqc);
        lit_App_Org_Cqc.Text = DSP.BAL.DBL.GetYesNo(_App._app_Org_Cqc);
        lit_App_Org_Emp.Text = DSP.BAL.DBL.GetYesNo(_App._app_Org_Employee);
        lit_App_Manager_Reg.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Manager_Register);
        lit_App_Org_PId.Text = DSP.BAL.DBL.GetYesNo(_App._app_Org_PId);
        lit_App_Org_Local_Authority.Text = DSP.BAL.DBL.GetYesNo(_App._app_Org_Reg_Local_Authority);
        lit_App_Million_Balance.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Million_Balance);

        lit_App_Granted_Leave.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Granted_Leave);




         lit_App_Nationality.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Nationality", _App._app_Nationality);
        lit_App_IsLivedEULast3Years.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsLivedEULast3Years);

        lit_App_NonEUUKHowLongLiveInUK.Text = _App._app_NonEUUKHowLongLiveInUK;


        lit_App_Ethnicity.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Ethnicity", _App._app_Ethnicity);

        //lit_App_SexualOrientation.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Sexual Orientation", _App._app_SexualOrientation);

        lit_App_AnyDisability.Text = DSP.BAL.DBL.GetYesNo(_App._app_AnyDisability);
        lit_App_AnyDisabilityPrimary.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Disabilities", _App._app_AnyDisabilityPrimary);

        // displays all ticks selcted... 
        lit_App_AnyDisabilitySecondaries.Text = getAllTickOptions(_App._app_AnyDisabilitySecondaries);

        lit_App_NeedLearningSupport.Text = DSP.BAL.DBL.GetYesNo(_App._app_NeedLearningSupport);

        lit_App_Refugee.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Refugee);
        lit_App_Signle.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Single_Adult);
        lit_App_Bacis_English.Text= DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Basic_English);
        lit_App_Basic_Match.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Basic_Math);
        lit_App_Level_2_English.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Level_2_English);
        lit_App_Level_2_Math.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Level_2_Math);
        lit_App_High_Qu.Text = _App._app_Esf_Q_High_Qualification;

        lit_App_access_skill_hold.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Access_Skill_Hold);
        lit_App_european.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_European_Social);
        lit_App_employee_million.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Employee_Million);
        lit_App_behalf.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Behalf);
        lit_App_assessment.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Assessment);
        lit_App_access_skill.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Access_Skill);
        lit_App_info_supplied.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Info_Supplied);
        lit_App_legally_uk.Text = DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Legally_Uk);



        // fetch the en-GB culture
        CultureInfo ukCulture = new CultureInfo("en-GB");
        // pass the DateTimeFormat information to DateTime.Parse
        DateTime myDateTime = DateTime.Parse(DateTime.Now.ToString(), ukCulture.DateTimeFormat);
        txtApplicationDate.Text = myDateTime.Date.ToString("d");

    }
    private string getAllTickOptions(string sAllIds)
    {
        //1, 2, 3, 4, ....
        //get all string for each id from options
        string[] singleIds = sAllIds.Split(',');
        string selectedOptions = "";
        foreach (string s in singleIds)
        {
            selectedOptions += DSP.BAL.DBL.GetApplicationOptionTitle("Disabilities", s.Trim()) + Environment.NewLine + "<br/>";
        }
        return selectedOptions;
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
                   // txt_emp_WorkPlaceAddress2.Text = _App._app_emp_WorkPlaceAddress2;
                    txt_emp_WorkPlaceAddress3.Text = _App._app_emp_WorkPlaceAddress3;
                    txt_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                    //  txt_emp_ContactName.Text = _App._app_emp_ContactName;
                    txt_type_ServiceProvider.Text = _App._app_Esf_Q_Type_Service_Provider;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_JobFunction, _App._app_job_JobFunction);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlOrg_Skill, _App._app_Org_Skill);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Org_Reg_Cqc, _App._app_Org_Reg_Cqc);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Org_Cqc, _App._app_Org_Cqc);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Org_Emp, _App._app_Org_Employee);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlmangerreg, _App._app_Esf_Q_Manager_Register);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlorgpid, _App._app_Org_PId);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlorgreglocalAuthority, _App._app_Org_Reg_Local_Authority);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlmillionbalance, _App._app_Esf_Q_Million_Balance);


                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ContactConsent, _App._app_mktg_ContactConsent);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPhone, _App._app_mktg_ByPhone);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByEmail, _App._app_mktg_ByEmail);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPost, _App._app_mktg_ByPost);
                }
                break;
            case 3:
                txt_hight_qualification.Text = _App._app_Esf_Q_High_Qualification;
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlbasicenglish, _App._app_Esf_Q_Basic_English);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlbasicmath, _App._app_Esf_Q_Basic_Math);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddllevel2english, _App._app_Esf_Q_Level_2_English);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddllevel2math, _App._app_Esf_Q_Level_2_Math);

                break;
            case 4:
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Access_Skill_Hold, _App._app_Esf_Q_Access_Skill_Hold);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_European_Social, _App._app_Esf_Q_European_Social);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Employee_Million, _App._app_Esf_Q_Employee_Million);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Behalf, _App._app_Esf_Q_Behalf);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(dll_Assessment, _App._app_Esf_Q_Assessment);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Access_Skill, _App._app_Esf_Q_Access_Skill);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Info_Supplied, _App._app_Esf_Q_Info_Supplied);
                DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_Legally_Uk, _App._app_Esf_Q_Legally_Uk);

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

            Response.Redirect("~/Application/Default.aspx");
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

            Response.Redirect("~/Application/Default.aspx");
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
    protected void btnConfirmEnrolment_Click(object sender, EventArgs e)
    {
        if (Page.Session["CurrentApplication"] != null)
        {
            _App = (ApplicationForm)Page.Session["CurrentApplication"];
            _App._app_officeuse1_IsLiteracyNumeracyDone = true;
            _App._app_officeuse1_IsAllDocumentsSigned = true;
            _App._app_officeuse1_IsConfirmEnrolment = true;
          //  _App._app_officeuse1_CourseId = int.Parse(ddlEnrolmentCourse.SelectedValue);
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
                if (_App._app_emp_WorkPlaceAddress1 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim())|| _App._app_emp_WorkPlaceAddress3 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_WorkPlaceAddress1 + "\n" + _App._app_emp_WorkPlaceAddress2 + "\n" + _App._app_emp_WorkPlaceAddress3, Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim()) + "\n"  + "\n" + Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim())
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
             //   if (_App._app_emp_ContactName != DSP.BAL.Basic.FormatStringForSQL(txt_emp_ContactName.Text.Trim()))
               // {
               //     SetValueOfChanges(_App._app_emp_ContactName, Basic.FormatStringForSQL(txt_emp_ContactName.Text.Trim()), "app_emp_ContactName"); isAmended = true;
              //  }
             //   if (_App._app_emp_Email != DSP.BAL.Basic.FormatStringForSQL(txt_emp_Email.Text.Trim()))
             //   {
             //       SetValueOfChanges(_App._app_emp_Email, Basic.FormatStringForSQL(txt_emp_Email.Text.Trim()), "app_emp_Email"); isAmended = true;
             //   }
             //   if (_App._app_ACS_WDSNumber != DSP.BAL.Basic.FormatStringForSQL(txt_ACS_WDSNumber.Text.Trim()))
             //   {
             //       SetValueOfChanges(_App._app_ACS_WDSNumber, Basic.FormatStringForSQL(txt_ACS_WDSNumber.Text.Trim()), "app_ACS_WDSNumber"); isAmended = true;
             //   }
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