using DSP.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

public partial class SalesAdvisor_Progress : System.Web.UI.Page
{
    public CourseLevel COURSE_LEVEL;
    public int COURSE_LEVEL_NUMER;
    public int COURSE_ID;
    // private static int _CourseId;
    public ApplicationForm _App;
    public string filePath;

    protected void Page_Load(object sender, EventArgs e)
    {
        Wizard1.PreRender += new EventHandler(Wizard1_PreRender);

        if (!Page.IsPostBack)
        {
            Wizard1.FinishCompleteButtonText = "Submit Application";
            Wizard1.FinishCompleteButtonStyle.CssClass = "button medium blue";
            ddlNationality.DataBind();
            ddlEnrolmentCourse.DataBind();
            DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlNationality, 0);

            if (Page.Session["CurrentApplication"] != null)
            {
                _App = (ApplicationForm)Page.Session["CurrentApplication"];
                lblAppId.Text = _App._app_id.ToString();
                var  _CourseId = _App._app_officeuse1_CourseId;                
                COURSE_LEVEL = (CourseLevel)Enum.ToObject(typeof(CourseLevel), _App._app_officeuse1_CourseLevel);
                if(_App._app_officeuse1_CourseLevel != 50 || _App._app_officeuse1_CourseLevel != 51)
                {
                    setPathwaysLevel(_App._app_officeuse1_CourseLevel);

                }

                if (_App._app_officeuse1_CourseLevel == 20)
                {
                    rfv_educ_IsALLFund.Enabled = false;
                    rfv_educ_IsALLFund.EnableClientScript = false;
                    rfv_emp_IsSelfEmployed.Enabled = false;
                    rfv_emp_IsSelfEmployed.EnableClientScript = false;
                }
                if (_App._app_officeuse1_CourseLevel == 51)
                {
                    //rfvNI.Enabled = false;
                    //rfvNI.EnableClientScript = false;


                    rfvEUEEAStatus.Enabled = false;
                    rfvEUEEAStatus.EnableClientScript = false;

                    rfvEUEAA.Enabled = false;
                    rfvEUEAA.EnableClientScript = false;


                    rfvHaveLearnerSupportProgram.Enabled = false;
                    rfvHaveLearnerSupportProgram.EnableClientScript = false;

                    rfvIsAccessToFaceTime.Enabled = false;
                    rfvIsAccessToFaceTime.EnableClientScript = false;

                    RequiredFieldValidator1.Enabled = false;
                    RequiredFieldValidator1.EnableClientScript = false;
                    RequiredFieldValidator3.Enabled = false;
                    RequiredFieldValidator3.EnableClientScript = false;
                    RequiredFieldValidator4.Enabled = false;
                    RequiredFieldValidator4.EnableClientScript = false;
                    rfvCircumstance.Enabled = false;
                    rfvCircumstance.EnableClientScript = false;

                    rfv_educ_IsEnrolledOther.Enabled = false;
                    rfv_educ_IsEnrolledOther.EnableClientScript = false;
                    rfv_educ_IsALLFund.Enabled = false;
                    rfv_educ_IsALLFund.EnableClientScript = false;
                    cv_educ_ALLFundQualDetails.Enabled = false;
                    cv_educ_ALLFundQualDetails.EnableClientScript = false;

                    rfv_emp_BusinessSector.Enabled = false;
                    rfv_emp_BusinessSector.EnableClientScript = false;
                    rfv_emp_IsSelfEmployed.Enabled = false;
                    rfv_emp_IsSelfEmployed.EnableClientScript = false;


                    //jobs

                    //rfv_job_JobFunction.Enabled = false;
                    //rfv_job_JobFunction.EnableClientScript = false;
                    rfv_job_HowLongWorkingJob.Enabled = false;
                    rfv_job_HowLongWorkingJob.EnableClientScript = false;
                    rfv_job_HowLongWorkingEmployer.Enabled = false;
                    rfv_job_HowLongWorkingEmployer.EnableClientScript = false;

                    //rfv_job_HaveCurrentDevPlan.Enabled = false;
                    //rfv_job_HaveCurrentDevPlan.EnableClientScript = false;

                    //rfv_job_IsAwareFundamentalStd.Enabled = false;
                    //rfv_job_IsAwareFundamentalStd.EnableClientScript = false;

                    //rfv_job_IsFurtherTrainingNeeded.Enabled = false;
                    //rfv_job_IsFurtherTrainingNeeded.EnableClientScript = false;

                    //rfv_job_RelevantPathway.Enabled = false;
                    //rfv_job_RelevantPathway.EnableClientScript = false;


                   // rfv_job_DailyMainDuties.Enabled = false;
                   // rfv_job_DailyMainDuties.EnableClientScript = false;

                   // rfv_job_OtherPositionResponsabilities.Enabled = false;
                   // rfv_job_OtherPositionResponsabilities.EnableClientScript = false;

                    //rfv_job_AboutYourStrenghts.Enabled = false;
                   // rfv_job_AboutYourStrenghts.EnableClientScript = false;

                    //rfv_job_AreasOfDevelopment.Enabled = false;
                   // rfv_job_AreasOfDevelopment.EnableClientScript = false;


                    rev_job_WorkMgtRole.Enabled = false;
                    rev_job_WorkMgtRole.EnableClientScript = false;


                    //rfv_ddl_job_Confirm16hrsId.Enabled = false;
                    //rfv_ddl_job_Confirm16hrsId.EnableClientScript = false;

                    rev_job_WorkMgtRole.Enabled = false;
                    rev_job_WorkMgtRole.EnableClientScript = false;
                    rev_job_RespondCompliments.Enabled = false;
                    rev_job_RespondCompliments.EnableClientScript = false;

                    rfv_job_IsInvestigatingSafeguarding.Enabled = false;
                    rfv_job_IsInvestigatingSafeguarding.EnableClientScript = false;

                    //rfv_ddl_job_IsContributeSelfAssessment.Enabled = false;
                    //rfv_ddl_job_IsContributeSelfAssessment.EnableClientScript = false;

                    //rfv_ddl_job_IsLeadPartnershipWorking.Enabled = false;
                   // rfv_ddl_job_IsLeadPartnershipWorking.EnableClientScript = false;

                    rfv_ddl_job_IsLeadProvisionDelivers.Enabled = false;
                    rfv_ddl_job_IsLeadProvisionDelivers.EnableClientScript = false;

                    //rfv_ddl_job_IsResponsibleKeyResources.Enabled = false;
                   // rfv_ddl_job_IsResponsibleKeyResources.EnableClientScript = false;

                    //rfv_ddl_job_IsResponsibleManagingQuality.Enabled = false;
                   // rfv_ddl_job_IsResponsibleManagingQuality.EnableClientScript = false;

                    //rev_job_StaffInductionCareCertificate.Enabled = false;
                    //rev_job_StaffInductionCareCertificate.EnableClientScript = false;
                    rfv_job_IsEnsuringComplianceHS.Enabled = false;
                    rfv_job_IsEnsuringComplianceHS.EnableClientScript = false;


                }


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
                    //txt_FileData.Text = _App._app_job_HaveJobDescription_doc;
                    //if (_App._app_job_HaveJobDescription_doc == "")
                    //{
                    //   DownloadFile.Visible = false;
                    //}
                    txtApp_officeuse_UKPRN.Text = _App._app_officeuse_UKPRN;
                    txtApp_officeuse_EmployerId.Text = _App._app_officeuse_EmployerId;

                    if (_App._app_officeuse1_CourseId != 0)
                        DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEnrolmentCourse, _App._app_officeuse1_CourseId);


                    //load all elements
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlTitles, _App._app_Title);
                    txtName.Text = _App._app_FirstName;
                    txtSurname.Text = _App._app_Surname;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlGender, _App._app_Gender);
                    txtDOB.Text = _App._app_DOB;
                    txtNI.Text = _App._app_NI;
                    txtAddress1.Text = _App._app_PermAddress1;
                    txtAddress2.Text = _App._app_PermAddress2;
                    txtAddress3.Text = _App._app_PermAddress3;
                    txtPostcode.Text = _App._app_PermPostCode;
                    txtTel.Text = _App._app_HomeTel;
                    txtMobile.Text = _App._app_Mobile;
                    txt_Email.Text = _App._app_Email;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlNationality, _App._app_Nationality);
                    txtLegalResidency.Text = _App._app_LegalResidency;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsLivedEULast3Years, _App._app_IsLivedEULast3Years);
                    txtLivedEntryDate.Text = _App._app_LivedEntryDate;
                    txtNonEUUKHowLongLiveInUK.Text = _App._app_NonEUUKHowLongLiveInUK;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEUEAANational, _App._app_EUEEANational);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEUEEAStatus, _App._app_EUEEAStatus);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEthnicity, _App._app_Ethnicity);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlReligion, _App._app_Religion);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlSexualOrientation, _App._app_SexualOrientation);
                    txtLengthOfAddress.Text = _App._app_LengthOfAddress;
                    txtPrePlannedAbsence.Text = _App._app_PrePlannedAbsence;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlCircumstance, _App._app_Circumstance);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlAnyDisability, _App._app_AnyDisability);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlAnyDisabilityPrimary, _App._app_AnyDisabilityPrimary);
                    //loading all checkboxes
                    //split and load ticks
                    LoadTicksAndCheck(_App._app_AnyDisabilitySecondaries);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlNeedLearningSupport, _App._app_NeedLearningSupport);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlHaveLearnerSupportProgram, _App._app_HaveLearnerSupportProgram);
                    //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlProgramAppliedFor, _App._app_ProgramAppliedFor);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsAccessToComputer, _App._app_IsAccessToComputer);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsAccessToFaceTime, _App._app_IsAccessToFaceTime);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsAccessToEmail, _App._app_IsAccessToEmail);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsPartnerOfOwner, _App._app_IsPartnerOfOwner);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlIsEPortoflioAware, _App._app_IsEPortoflioAware);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlManageWorkStudy, _App._app_ManageWorkStudy);
                    //txtManageWorkStudy.Text = _App._app_ManageWorkStudy;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_HighestQual, _App._app_educ_HighestQual);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsGCSEEnglish, _App._app_educ_IsGCSEEnglish);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsGCSEMath, _App._app_educ_IsGCSEMath);
                    txt_educ_EquivalentQualification.Text = _App._app_educ_EquivalentQualification;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsEnrolledOther, _App._app_educ_IsEnrolledOther);
                    txt_educ_PreviousCollege.Text = _App._app_educ_PreviousCollege;
                    txt_educ_PreviousQual.Text = _App._app_educ_PreviousQual;
                    txt_educ_PreviousTraining.Text = _App._app_educ_PreviousTraining;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsALLFund, _App._app_educ_IsALLFund);
                    txt_educ_ALLFundQualDetails.Text = _App._app_educ_ALLFundQualDetails;
                    //txt_educ_TrainingPlannedNext12Months.Text = _App._app_educ_TrainingPlannedNext12Months;
                    //txt_educ_FutureInspirations.Text = _App._app_educ_FutureInspirations;

                    txt_emp_CompanyName.Text = _App._app_emp_CompanyName;
                    txt_emp_EmpoyementStartDate.Text = _App._app_emp_EmpoyementStartDate;

                    txt_emp_WorkPlaceAddress1.Text = _App._app_emp_WorkPlaceAddress1;
                    txt_emp_WorkPlaceAddress2.Text = _App._app_emp_WorkPlaceAddress2;
                    txt_emp_WorkPlaceAddress3.Text = _App._app_emp_WorkPlaceAddress3;
                    txt_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                    txt_emp_ContactName.Text = _App._app_emp_ContactName;
                    txt_emp_Position.Text = _App._app_emp_Position;
                    txt_emp_Email.Text = _App._app_emp_Email;

                    txt_emp_BusinessSector.Text = _App._app_emp_BusinessSector;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_CompanyEstablished, _App._app_emp_CompanyEstablished);

                    txt_emp_WeeklyHours.Text = _App._app_emp_WeeklyHours;
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_WeeklyHours, _App._app_emp_WeeklyHours);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_IsSelfEmployed, _App._app_emp_IsSelfEmployed);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_IsEmployerPaying, _App._app_emp_IsEmployerPaying);


                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_JobFunction, _App._app_job_JobFunction);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HowLongWorkingJob, _App._app_job_HowLongWorkingJob);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HowLongWorkingEmployer, _App._app_job_HowLongWorkingEmployer);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AnyPreviousManagement, _App._app_job_AnyPreviousManagement);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveCurrentDevPlan, _App._app_job_HaveCurrentDevPlan);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAwareFundamentalStd, _App._app_job_IsAwareFundamentalStd);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleCQCPIR, _App._app_job_IsResponsibleCQCPIR);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleRecruitment, _App._app_job_IsResponsibleRecruitment);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleStaffInduction, _App._app_job_IsResponsibleStaffAppraisal);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleStaffraisal, _App._app_job_IsResponsibleStaffAppraisal);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleMonitoringStaff, _App._app_job_IsResponsibleMonitoringStaff);
                    //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleTaskAllocationRotas, _App._app_job_IsResponsibleTaskAllocationRotas);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsiblePlanningReviewing, _App._app_job_IsResponsiblePlanningReviewing);
                    //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleOrganisingReferrals, _App._app_job_IsResponsibleOrganisingReferrals);
                    //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleOrganisingPartnerships, _App._app_job_IsResponsibleOrganisingPartnerships);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleEffectivenessPartnerships, _App._app_job_IsResponsibleEffectivenessPartnerships);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsReviewAuditPolicies, _App._app_job_IsReviewAuditPolicies);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsRespondingToComplaints, _App._app_job_IsRespondingToComplaints);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvestigatingSafeguarding, _App._app_job_IsInvestigatingSafeguarding);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsOrganisingLeadStaffMeetings, _App._app_job_IsOrganisingLeadStaffMeetings);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleWritingDevPlan, _App._app_job_IsResponsibleWritingDevPlan);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveRegularStaffMeetings, _App._app_job_HaveRegularStaffMeetings);
                    //   DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAttendingStrategicMeetings, _App._app_job_IsAttendingStrategicMeetings);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsEnsuringComplianceHS, _App._app_job_IsEnsuringComplianceHS);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsFurtherTrainingNeeded, _App._app_job_IsFurtherTrainingNeeded);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsSpecificSupportNeeded, _App._app_job_IsSpecificSupportNeeded);
                    if (_App._app_officeuse1_CourseLevel != 51 || _App._app_officeuse1_CourseLevel != 52)
                    {
                        DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RelevantPathway, _App._app_job_RelevantPathway);
                    }
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RelevantPathway_L3, _App._app_job_RelevantPathway_L3, false);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveJobDescription, _App._app_job_HaveJobDescription);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveJobDescription_L3, _App._app_job_HaveJobDescription_L3);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_CarryOutAuditing, _App._app_job_CarryOutAuditing);

                  //  txt_job_AreasOfDevelopment.Text = _App._app_job_AreasOfDevelopment;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AllowWorkplaceObsVisit, _App._app_job_AllowWorkplaceObsVisit);
                    // New Questions for CourseID 94
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TherapySessions, _App._app_job_TherapySessions);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HealthPromotion, _App._app_job_HealthPromotion);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_Advocate, _App._app_job_Advocate);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SupportServiceUsers, _App._app_job_SupportServiceUsers);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddlEUEAANational, _App._app_EUEEANational);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AssessReviewSupportPlans, _App._app_job_AssessReviewSupportPlans);

                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvolvedInRiskassessments, _App._app_job_IsInvolvedInRiskAssessments);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_ContributeToMentalHealth, _App._app_job_ContributeToMentalHealth);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SupportIndvDepresionPhobias, _App._app_job_SupportIndvDepressionPhobias);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkinPartnershipswthProfesionals, _App._app_job_WorkinPartnershipswthProfessionals);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SafeguardReports, _App._app_job_SafeguardReports);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RecruitmentResponsibilities, _App._app_job_RecruitmentResponsibilities);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_StaffInductionCareCertificate, _App._app_job_StaffInductionCareCertificate);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RespondCompliments, _App._app_job_RespondCompliments);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkMgtRole, _App._app_job_WorkMgtRole);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TakePartSupervisions, _App._app_job_TakePartSupervisions);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TakePartMeetings, _App._app_job_TakePartMeetings);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_MaintainPersonalRecord, _App._app_job_MaintainPersonalRecord);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RiskAssessOthersComply, _App._app_job_RiskAssessOthersComply);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SafeguardInvestigations, _App._app_job_SafeguardInvestigations);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkSupportiveRole, _App._app_job_WorkSupportiveRole);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_ReviewSupportPlans, _App._app_job_ReviewSupportPlans);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkPartnerProfessionals, _App._app_job_WorkPartnerProfessionals);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_CVPResilience, _App._app_job_CVPResilience);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TechCommunication, _App._app_job_TechCommunication);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RegularSupervisions, _App._app_job_RegularSupervisions);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_CarryoutRiskAssessment, _App._app_job_CarryoutRiskAssessment);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SupportCYP, _App._app_job_SupportCYP);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_PositiveRiskTaking, _App._app_job_PositiveRiskTaking);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_KeyWorker, _App._app_job_KeyWorker);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_PlanImplementcare, _App._app_job_PlanImplementcare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WriteRecordReports, _App._app_job_WriteRecordReports);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SocialActivitieswithServiceUser, _App._app_job_SocialActivitieswithServiceUser);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_LeadCommunicationProcesses, _App._app_job_LeadCommunicationProcesses);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_OrgProvidesResidentialServices, _App._app_job_OrgProvidesResidentialServices);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_PersonalCareAssistingMoving, _App._app_job_PersonalCareAssistingMoving);


                    //level 2
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_70, _App._app_job_70);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AssistEatingDrinking, _App._app_job_AssistEatingDrinking);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_71, _App._app_job_71);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_72, _App._app_job_72);
                     
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_job_Confirm16hrs, _App._app_job_Confirm16hrs);
                    //if (chk_job_Confirm16hrs.Checked)
                    //{ ddl_job_Confirm16hrsId.Enabled = true; }
                    //else { ddl_job_Confirm16hrsId.Enabled = false; }
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_Confirm16hrsId, _App._app_job_Confirm16hrsId);

                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveStartedGLH , _App._app_job_HaveStartedGLH);

                    //txt_job_DailyMainDuties.Text = _App._app_job_DailyMainDuties;
                    //txt_job_UsualHoursAttendancy.Text = _App._app_job_UsualHoursAttendancy;
                   // txt_job_OtherPositionResponsabilities.Text = _App._app_job_OtherPositionResponsabilities;
                    //txt_job_AboutYourStrenghts.Text = _App._app_job_AboutYourStrenghts;

                    /*DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAssessReviewImplementCare, _App._app_job_IsAssessReviewImplementCare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvolvedRiskAssessment, _App._app_job_IsInvolvedRiskAssessment);
                    */
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsEnsureOthersFollowPolicy, _App._app_job_IsEnsureOthersFollowPolicy);
                    
                    /*DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsSupportServiceInPersonalCare, _App._app_job_IsSupportServiceInPersonalCare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsWorkSupportRoleServiceUsers, _App._app_job_IsWorkSupportRoleServiceUsers);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsPlanReviewImplmentCare, _App._app_job_IsPlanReviewImplmentCare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvolvedSafeguardingInvestigations, _App._app_job_IsInvolvedSafeguardingInvestigations);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsTakePartInRiskAssessment, _App._app_job_IsTakePartInRiskAssessment);
                    */
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsTakePartInManagingQuality, _App._app_job_IsTakePartInManagingQuality);

                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsContributeSelfAssessment, _App._app_job_IsContributeSelfAssessment);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsReviewAuditPolicy, _App._app_job_IsReviewAuditPolicy);
                  //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsLeadPartnershipWorking, _App._app_job_IsLeadPartnershipWorking);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsLeadProvisionDelivers, _App._app_job_IsLeadProvisionDelivers);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleKeyResources, _App._app_job_IsResponsibleKeyResources);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleStaffTraining, _App._app_job_IsResponsibleStaffTraining);
                  //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleManagingQuality, _App._app_job_IsResponsibleManagingQuality);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleIncludeDevelopment, _App._app_job_IsResponsibleIncludeDevelopment);

                    //txt_job_ExampleProjectManaged.Text = _App._app_job_ExampleProjectManaged;
                    //txt_job_ExampleSupportingCarePractice.Text = _App._app_job_ExampleSupportingCarePractice;
                    //txt_job_ExampleCPDRecent.Text = _App._app_job_ExampleCPDRecent;
                    //txt_job_ExampleCourageImplement.Text = _App._app_job_ExampleCourageImplement;

                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_mktg_HearAbout, _App._app_mktg_HearAbout);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ContactConsent, _App._app_mktg_ContactConsent);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPhone, _App._app_mktg_ByPhone);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByEmail, _App._app_mktg_ByEmail);
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_mktg_ByPost, _App._app_mktg_ByPost);

                  

                    if (COURSE_LEVEL == CourseLevel.L3)
                    {
                        //pLevel3.Visible = true;
                        //pLevel4.Visible = false;
                        //pLevel5.Visible = false;
                    }

                    if (COURSE_LEVEL == CourseLevel.L4)
                    {
                        // pLevel3.Visible = false;
                        // pLevel4.Visible = true;
                        // pLevel5.Visible = false;
                    }
                    if (COURSE_LEVEL == CourseLevel.L5)
                    {
                        //pLevel3.Visible = false;
                        //pLevel4.Visible = false;
                        //pLevel5.Visible = true;

                        switch (_App._app_officeuse1_CourseId)
                        {
                            case 82:
                                //hide questions
                                //pLevel5Hide82.Visible = false;
                                //show questions
                                break;
                            case 96:
                                //show questions
                                 
                                 
                                 
                                break;
                        }
                       
                      
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
            setPathwaysLevel(_App._app_officeuse1_CourseLevel);
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
                setPathwaysLevel(_App._app_officeuse1_CourseLevel);
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

                case 4:
                    //load all data here to display                
                    HideControlsForLevel(_App._app_officeuse1_CourseLevel);
                    LoadApplicationForConfirmation(_App);
                    break;

            }

        }
    }
    protected void bntDownloadFile_Click(object sender, EventArgs e)
    {
        const int bufferLength = 10000;
        byte[] buffer = new Byte[bufferLength];
     

        //string filePath = txt_FileData.Text;
        //FileInfo file = new FileInfo(filePath);
        //if (file.Exists)
        //{
        //    Response.Clear();
        //    Response.ClearHeaders();
        //    Response.ClearContent();
        //    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        //    Response.AddHeader("Content-Length", file.Length.ToString());
        //    Response.ContentType = "text/plain";
        //    Response.Flush();
        //    Response.TransmitFile(file.FullName);
        //    Response.End();
        //}
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
            //if (!_App.isNewApplication)
            //{ }
        }

        int iStep = Wizard1.ActiveStepIndex;

        if (CheckAppAndValidate("btnSaveAndLogout_Click()") == false) return;

        DSP.BAL.Log.WriteLogTxt(String.Format("btnSaveAndLogout_Click() ...now saving steps |username: {0} | App id: {1} | Step: {2} | ", Membership.GetUser().UserName, _App._app_id, iStep));

        SaveStep(iStep);

        /* LoginView lw = (LoginView)this.Master.FindControl("HeadLoginView");
                 if (lw != null)
                 { lw.Visible = false; }*/

        System.Web.UI.Control lw = (System.Web.UI.Control)this.Master.FindControl("loggedinfo");
        if (lw != null)
        { lw.Visible = false; }

        //Session.Abandon();
        //Response.Redirect("~/Default.aspx");
        //Session.Abandon();
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

                _App._app_Title = ddlTitles.SelectedValue;
                _App._app_FirstName = DSP.BAL.Basic.FormatStringForSQL(txtName.Text.Trim());
                _App._app_Surname = DSP.BAL.Basic.FormatStringForSQL(txtSurname.Text.Trim());
                _App._app_Gender = DSP.BAL.Basic.FormatStringForSQL(ddlGender.Text.Trim());
                _App._app_DOB = DSP.BAL.Basic.FormatStringForSQL(txtDOB.Text.Trim());
                _App._app_NI = DSP.BAL.Basic.FormatStringForSQL(txtNI.Text.Trim());
                _App._app_PermAddress1 = DSP.BAL.Basic.FormatStringForSQL(txtAddress1.Text.Trim());
                _App._app_PermAddress2 = DSP.BAL.Basic.FormatStringForSQL(txtAddress2.Text.Trim());
                _App._app_PermAddress3 = DSP.BAL.Basic.FormatStringForSQL(txtAddress3.Text.Trim());
                _App._app_PermPostCode = DSP.BAL.Basic.FormatStringForSQL(txtPostcode.Text.Trim());
                _App._app_HomeTel = DSP.BAL.Basic.FormatStringForSQL(txtTel.Text.Trim());
                _App._app_Mobile = DSP.BAL.Basic.FormatStringForSQL(txtMobile.Text.Trim());
                _App._app_Email = DSP.BAL.Basic.FormatStringForSQL(txt_Email.Text.Trim());
                _App._app_Nationality = ddlNationality.SelectedValue;
                _App._app_LegalResidency = DSP.BAL.Basic.FormatStringForSQL(txtLegalResidency.Text.Trim());
                _App._app_LegalResidency_doc = Request.Form["uploaded_file_legalresidency"];// uploaded_file_path_legalresidency.Text.Trim();
                _App._app_IsLivedEULast3Years = DSP.BAL.Basic.FormatStringForSQL(ddlIsLivedEULast3Years.Text.Trim());
                _App._app_LivedEntryDate = DSP.BAL.Basic.FormatStringForSQL(txtLivedEntryDate.Text.Trim());
                _App._app_NonEUUKHowLongLiveInUK = DSP.BAL.Basic.FormatStringForSQL(txtNonEUUKHowLongLiveInUK.Text.Trim());
                _App._app_EUEEANational = DSP.BAL.Basic.FormatStringForSQL(ddlEUEAANational.SelectedValue);
                _App._app_EUEEAStatus = ddlEUEEAStatus.SelectedValue;
                _App._app_Ethnicity = ddlEthnicity.SelectedValue;
                _App._app_Religion = ddlReligion.SelectedValue;
                //_App._app_SexualOrientation = ddlSexualOrientation.SelectedValue;
                _App._app_LengthOfAddress = DSP.BAL.Basic.FormatStringForSQL(txtLengthOfAddress.Text.Trim());
                _App._app_PrePlannedAbsence = DSP.BAL.Basic.FormatStringForSQL(txtPrePlannedAbsence.Text.Trim());
                _App._app_Circumstance = ddlCircumstance.SelectedValue;
                _App._app_AnyDisability = ddlAnyDisability.SelectedValue;
                _App._app_AnyDisabilityPrimary = ddlAnyDisabilityPrimary.SelectedValue;
                //collects all ticks values and make a string to save into one field - extract on loading
                _App._app_AnyDisabilitySecondaries = getSelectedTicks();
                _App._app_NeedLearningSupport = ddlNeedLearningSupport.SelectedValue;
                _App._app_HaveLearnerSupportProgram = ddlHaveLearnerSupportProgram.SelectedValue;
                //   _App._app_ProgramAppliedFor = ddlProgramAppliedFor.SelectedValue;
                _App._app_ProgramAppliedFor = "";
                _App._app_IsAccessToComputer = ddlIsAccessToComputer.SelectedValue;
                _App._app_IsAccessToFaceTime = ddlIsAccessToFaceTime.SelectedValue;
                _App._app_IsAccessToEmail = ddlIsAccessToEmail.SelectedValue;
                _App._app_IsPartnerOfOwner = ddlIsPartnerOfOwner.SelectedValue;
                _App._app_IsEPortoflioAware = ddlIsEPortoflioAware.SelectedValue;
                //  _App._app_ManageWorkStudy = DSP.BAL.Basic.FormatStringForSQL(txtManageWorkStudy.Text.Trim());
                return _App.SaveApplication();
            //break;

            case 1:
                _App._app_educ_HighestQual = ddl_educ_HighestQual.SelectedValue;
                _App._app_educ_IsGCSEEnglish = ddl_educ_IsGCSEEnglish.SelectedValue;
                _App._app_educ_IsGCSEMath = ddl_educ_IsGCSEMath.SelectedValue;
                _App._app_educ_EquivalentQualification = DSP.BAL.Basic.FormatStringForSQL(txt_educ_EquivalentQualification.Text.Trim());

                _App._app_educ_IsEnrolledOther = ddl_educ_IsEnrolledOther.SelectedValue;
                _App._app_educ_PreviousCollege = DSP.BAL.Basic.FormatStringForSQL(txt_educ_PreviousCollege.Text.Trim());
                _App._app_educ_PreviousQual = DSP.BAL.Basic.FormatStringForSQL(txt_educ_PreviousQual.Text.Trim());
                _App._app_educ_PreviousTraining = DSP.BAL.Basic.FormatStringForSQL(txt_educ_PreviousTraining.Text.Trim());
                _App._app_educ_IsALLFund = ddl_educ_IsALLFund.SelectedValue;
                _App._app_educ_ALLFundQualDetails = DSP.BAL.Basic.FormatStringForSQL(txt_educ_ALLFundQualDetails.Text.Trim());

                //_App._app_educ_TrainingPlannedNext12Months = DSP.BAL.Basic.FormatStringForSQL(txt_educ_TrainingPlannedNext12Months.Text.Trim());
                // _App._app_educ_FutureInspirations = DSP.BAL.Basic.FormatStringForSQL(txt_educ_FutureInspirations.Text.Trim());


                return _App.SaveApplication();
            //break;

            case 2:
                _App._app_emp_CompanyName = DSP.BAL.Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim());
                _App._app_emp_EmpoyementStartDate = DSP.BAL.Basic.FormatStringForSQL(txt_emp_EmpoyementStartDate.Text.Trim());


                _App._app_emp_WorkPlaceAddress1 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim());
                _App._app_emp_WorkPlaceAddress2 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim());
                _App._app_emp_WorkPlaceAddress3 = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim());
                _App._app_emp_WorkPlacePostCode = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlacePostCode.Text.Trim());
                _App._app_emp_Tel = DSP.BAL.Basic.FormatStringForSQL(txt_emp_Tel.Text.Trim());
                _App._app_emp_ContactName = DSP.BAL.Basic.FormatStringForSQL(txt_emp_ContactName.Text.Trim());
                _App._app_emp_Position = DSP.BAL.Basic.FormatStringForSQL(txt_emp_Position.Text.Trim());
                _App._app_emp_Email = DSP.BAL.Basic.FormatStringForSQL(txt_emp_Email.Text.Trim());
                _App._app_emp_BusinessSector = DSP.BAL.Basic.FormatStringForSQL(txt_emp_BusinessSector.Text.Trim());
                _App._app_emp_CompanyEstablished = ddl_emp_CompanyEstablished.SelectedValue;

                _App._app_emp_WeeklyHours = DSP.BAL.Basic.FormatStringForSQL(txt_emp_WeeklyHours.Text.Trim());
                //_App._app_emp_WeeklyHours = ddl_emp_WeeklyHours.SelectedValue;

                _App._app_emp_IsSelfEmployed = ddl_emp_IsSelfEmployed.SelectedValue;
                //_App._app_emp_IsEmployerPaying = ddl_emp_IsEmployerPaying.SelectedValue;

                return _App.SaveApplication();
            //  break;

            case 3:
                _App._app_job_JobFunction = ddl_job_JobFunction.SelectedValue;
                _App._app_job_HowLongWorkingJob = ddl_job_HowLongWorkingJob.SelectedValue;
                _App._app_job_HowLongWorkingEmployer = ddl_job_HowLongWorkingEmployer.SelectedValue;
                //_App._app_job_AnyPreviousManagement = ddl_job_AnyPreviousManagement.SelectedValue;
               // _App._app_job_HaveCurrentDevPlan = ddl_job_HaveCurrentDevPlan.SelectedValue;
               // _App._app_job_IsAwareFundamentalStd = ddl_job_IsAwareFundamentalStd.SelectedValue;
                //_App._app_job_IsResponsibleCQCPIR = ddl_job_IsResponsibleCQCPIR.SelectedValue;
                _App._app_job_IsResponsibleRecruitment = ddl_job_IsResponsibleRecruitment.SelectedValue;
                _App._app_job_IsResponsibleStaffInduction = ddl_job_IsResponsibleStaffInduction.SelectedValue;
                _App._app_job_IsResponsibleStaffAppraisal = ddl_job_IsResponsibleStaffraisal.SelectedValue;
                _App._app_job_IsResponsibleMonitoringStaff = ddl_job_IsResponsibleMonitoringStaff.SelectedValue;
                //   _App._app_job_IsResponsibleTaskAllocationRotas = ddl_job_IsResponsibleTaskAllocationRotas.SelectedValue;
                // _App._app_job_IsResponsiblePlanningReviewing = ddl_job_IsResponsiblePlanningReviewing.SelectedValue;
                //   _App._app_job_IsResponsibleOrganisingReferrals = ddl_job_IsResponsibleOrganisingReferrals.SelectedValue;
                //   _App._app_job_IsResponsibleOrganisingPartnerships = ddl_job_IsResponsibleOrganisingPartnerships.SelectedValue;
                // _App._app_job_IsResponsibleEffectivenessPartnerships = ddl_job_IsResponsibleEffectivenessPartnerships.SelectedValue;
                _App._app_job_IsReviewAuditPolicies = ddl_job_IsReviewAuditPolicies.SelectedValue;
                //_App._app_job_IsRespondingToComplaints = ddl_job_IsRespondingToComplaints.SelectedValue;
                _App._app_job_IsInvestigatingSafeguarding = ddl_job_IsInvestigatingSafeguarding.SelectedValue;
                //  _App._app_job_IsAuditFeedback = ddl_job_IsAuditFeedback.SelectedValue;
                _App._app_job_IsOrganisingLeadStaffMeetings = ddl_job_IsOrganisingLeadStaffMeetings.SelectedValue;
                //_App._app_job_IsResponsibleWritingDevPlan = ddl_job_IsResponsibleWritingDevPlan.SelectedValue;
                //_App._app_job_HaveRegularStaffMeetings = ddl_job_HaveRegularStaffMeetings.SelectedValue;
                // _App._app_job_IsAttendingStrategicMeetings = ddl_job_IsAttendingStrategicMeetings.SelectedValue;
                _App._app_job_IsEnsuringComplianceHS = ddl_job_IsEnsuringComplianceHS.SelectedValue;
                //  _App._app_job_IsFurtherTrainingNeeded = ddl_job_IsFurtherTrainingNeeded.SelectedValue;
                // _App._app_job_IsSpecificSupportNeeded = ddl_job_IsSpecificSupportNeeded.SelectedValue;
                if (_App._app_officeuse1_CourseLevel != 51 || _App._app_officeuse1_CourseLevel != 52)
                {
                    _App._app_job_RelevantPathway = ddl_job_RelevantPathway.SelectedValue;
                }
                //_App._app_job_RelevantPathway_L3 = ddl_job_RelevantPathway_L3.SelectedValue;

                _App._app_job_HaveJobDescription = ddl_job_HaveJobDescription.SelectedValue;
                _App._app_job_HaveJobDescription_doc = Request.Form["uploaded_file_havejobdescription"];// uploaded_file_path_havejobdescription_doc.Text;


                //_App._app_job_HaveJobDescription_L3 = ddl_job_HaveJobDescription_L3.SelectedValue;
                _App._app_job_HaveJobDescription_L3_doc = Request.Form["uploaded_file_havejobdescription_l3"];//  uploaded_file_path_havejobdescription_l3_doc.Text;

                //_App._app_job_CarryOutAuditing = ddl_job_CarryOutAuditing.SelectedValue;

               // _App._app_job_DailyMainDuties = DSP.BAL.Basic.FormatStringForSQL(txt_job_DailyMainDuties.Text.Trim());
                //_App._app_job_UsualHoursAttendancy = DSP.BAL.Basic.FormatStringForSQL(txt_job_UsualHoursAttendancy.Text.Trim());
                //_App._app_job_OtherPositionResponsabilities = DSP.BAL.Basic.FormatStringForSQL(txt_job_OtherPositionResponsabilities.Text.Trim());
                //_App._app_job_AboutYourStrenghts = DSP.BAL.Basic.FormatStringForSQL(txt_job_AboutYourStrenghts.Text.Trim());
             //   _App._app_job_AreasOfDevelopment = DSP.BAL.Basic.FormatStringForSQL(txt_job_AreasOfDevelopment.Text.Trim());

                _App._app_job_AllowWorkplaceObsVisit = ddl_job_AllowWorkplaceObsVisit.SelectedValue;
                _App._app_job_TherapySessions = ddl_job_TherapySessions.SelectedValue;
            
                _App._app_job_HealthPromotion = ddl_job_HealthPromotion.SelectedValue;
                _App._app_job_Advocate = ddl_job_Advocate.SelectedValue;
                _App._app_job_SupportServiceUsers = ddl_job_SupportServiceUsers.SelectedValue;

                _App._app_job_AssessReviewSupportPlans = ddl_job_AssessReviewSupportPlans.SelectedValue;
                //_App._app_job_IsInvolvedInRiskAssessments = ddl_job_IsInvolvedInRiskassessments.SelectedValue;
                _App._app_job_ContributeToMentalHealth = ddl_job_ContributeToMentalHealth.SelectedValue;
                _App._app_job_SupportIndvDepressionPhobias = ddl_job_SupportIndvDepresionPhobias.SelectedValue;
                _App._app_job_WorkinPartnershipswthProfessionals = ddl_job_WorkinPartnershipswthProfesionals.SelectedValue;
                _App._app_job_SafeguardReports = ddl_job_SafeguardReports.SelectedValue;
                _App._app_job_RecruitmentResponsibilities = ddl_job_RecruitmentResponsibilities.SelectedValue;
               // _App._app_job_StaffInductionCareCertificate = ddl_job_StaffInductionCareCertificate.SelectedValue;
                _App._app_job_RespondCompliments = ddl_job_RespondCompliments.SelectedValue;
                _App._app_job_WorkMgtRole = ddl_job_WorkMgtRole.SelectedValue;
                _App._app_job_TakePartSupervisions = ddl_job_TakePartSupervisions.SelectedValue;
                _App._app_job_TakePartMeetings = ddl_job_TakePartMeetings.SelectedValue;
                _App._app_job_MaintainPersonalRecord = ddl_job_MaintainPersonalRecord.SelectedValue;
                _App._app_job_RiskAssessOthersComply = ddl_job_RiskAssessOthersComply.SelectedValue;
                _App._app_job_SafeguardInvestigations = ddl_job_SafeguardInvestigations.SelectedValue;
                _App._app_job_WorkSupportiveRole = ddl_job_WorkSupportiveRole.SelectedValue;

                _App._app_job_ReviewSupportPlans = ddl_job_ReviewSupportPlans.SelectedValue;
                _App._app_job_WorkPartnerProfessionals = ddl_job_WorkPartnerProfessionals.SelectedValue;
                _App._app_job_CVPResilience = ddl_job_CVPResilience.SelectedValue;
                _App._app_job_TechCommunication = ddl_job_TechCommunication.SelectedValue;
                //_App._app_job_RegularSupervisions = ddl_job_RegularSupervisions.SelectedValue;
                _App._app_job_CarryoutRiskAssessment = ddl_job_CarryoutRiskAssessment.SelectedValue;
                _App._app_job_SupportCYP = ddl_job_SupportCYP.SelectedValue;
                _App._app_job_PositiveRiskTaking = ddl_job_PositiveRiskTaking.SelectedValue;
                _App._app_job_KeyWorker = ddl_job_KeyWorker.SelectedValue;
                _App._app_job_PlanImplementcare = ddl_job_PlanImplementcare.SelectedValue;
                _App._app_job_WriteRecordReports = ddl_job_WriteRecordReports.SelectedValue;
                _App._app_job_SocialActivitieswithServiceUser = ddl_job_SocialActivitieswithServiceUser.SelectedValue;
                _App._app_job_LeadCommunicationProcesses = ddl_job_LeadCommunicationProcesses.SelectedValue;
                _App._app_job_OrgProvidesResidentialServices = ddl_job_OrgProvidesResidentialServices.SelectedValue;
                _App._app_job_PersonalCareAssistingMoving = ddl_job_PersonalCareAssistingMoving.SelectedValue;


                //level 2
                _App._app_job_70 = ddl_App_job_70.SelectedValue;
                _App._app_job_71 = ddl_App_job_71.SelectedValue;
               // _App._app_job_72 = ddl_App_job_72.SelectedValue;
                _App._app_job_AssistEatingDrinking = ddl_job_AssistEatingDrinking.SelectedValue;

                _App._app_job_Confirm16hrs = chk_job_Confirm16hrs.Checked;
                _App._app_job_Confirm16hrsId = int.Parse(ddl_job_Confirm16hrsId.SelectedValue);
                _App._app_job_Confirm16hrsTitle = ddl_job_Confirm16hrsId.SelectedItem.Text;

                // _App._app_job_HaveStartedGLH = ddl_job_HaveStartedGLH.SelectedValue;

                //_App._app_job_IsAssessReviewImplementCare = ddl_job_IsAssessReviewImplementCare.SelectedValue;
                //_App._app_job_IsInvolvedRiskAssessment = ddl_job_IsInvolvedRiskAssessment.SelectedValue;
                _App._app_job_IsEnsureOthersFollowPolicy = ddl_job_IsEnsureOthersFollowPolicy.SelectedValue;
                
                /*_App._app_job_IsSupportServiceInPersonalCare = ddl_job_IsSupportServiceInPersonalCare.SelectedValue;
                _App._app_job_IsWorkSupportRoleServiceUsers = ddl_job_IsWorkSupportRoleServiceUsers.SelectedValue;
                _App._app_job_IsPlanReviewImplmentCare = ddl_job_IsPlanReviewImplmentCare.SelectedValue;
                _App._app_job_IsInvolvedSafeguardingInvestigations = ddl_job_IsInvolvedSafeguardingInvestigations.SelectedValue;
                _App._app_job_IsTakePartInRiskAssessment = ddl_job_IsTakePartInRiskAssessment.SelectedValue;
                */
                _App._app_job_IsTakePartInManagingQuality = ddl_job_IsTakePartInManagingQuality.SelectedValue;
                
               // _App._app_job_IsContributeSelfAssessment = ddl_job_IsContributeSelfAssessment.SelectedValue;
                _App._app_job_IsReviewAuditPolicy = ddl_job_IsReviewAuditPolicy.SelectedValue;
               // _App._app_job_IsLeadPartnershipWorking = ddl_job_IsLeadPartnershipWorking.SelectedValue;
                _App._app_job_IsLeadProvisionDelivers = ddl_job_IsLeadProvisionDelivers.SelectedValue;
              //  _App._app_job_IsResponsibleKeyResources = ddl_job_IsResponsibleKeyResources.SelectedValue;
                _App._app_job_IsResponsibleStaffTraining = ddl_job_IsResponsibleStaffTraining.SelectedValue;
              //  _App._app_job_IsResponsibleManagingQuality = ddl_job_IsResponsibleManagingQuality.SelectedValue;
              //  _App._app_job_IsResponsibleIncludeDevelopment = ddl_job_IsResponsibleIncludeDevelopment.SelectedValue;

                //_App._app_job_ExampleProjectManaged = DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleProjectManaged.Text.Trim());
                //_App._app_job_ExampleSupportingCarePractice = DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleSupportingCarePractice.Text.Trim());
                //_App._app_job_ExampleCPDRecent = DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleCPDRecent.Text.Trim());
                //_App._app_job_ExampleCourageImplement = DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleCourageImplement.Text.Trim());

              //  _App._app_job_102_KnowledgeStatutoryFrameworks = ddl_job_102_KnowledgeStatutoryFrameworks.SelectedValue;
              //  _App._app_job_103_ExperienceOfManaging = ddl_job_103_ExperienceOfManaging.SelectedValue;
             //   _App._app_job_104_AbilityImplementStrategies = ddl_job_104_AbilityImplementStrategies.SelectedValue;
              //  _App._app_job_105_ExperienceLeadingSupporting = ddl_job_105_ExperienceLeadingSupporting.SelectedValue;
               // _App._app_job_106_CarriedOutActivitiesMonitor = ddl_job_106_CarriedOutActivitiesMonitor.SelectedValue;

            

                _App._app_mktg_HearAbout = "";
                _App._app_mktg_ContactConsent = (chk_mktg_ContactConsent.Checked ? "1" : "0");
                _App._app_mktg_ByPhone = (chk_mktg_ByPhone.Checked ? "1" : "0");
                _App._app_mktg_ByEmail = (chk_mktg_ByEmail.Checked ? "1" : "0");
                _App._app_mktg_ByPost = (chk_mktg_ByPost.Checked ? "1" : "0");

                return _App.SaveApplication();
            //break;

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
        lit_App_NI.Text = _App._app_NI;
        lit_App_PermAddress1.Text = _App._app_PermAddress1 + "</br>" + _App._app_PermAddress2 + "</br>" + _App._app_PermAddress3;
        lit_App_PermPostCode.Text = _App._app_PermPostCode;
        lit_App_HomeTel.Text = _App._app_HomeTel;
        lit_App_Mobile.Text = _App._app_Mobile;
        lit_App_Email.Text = _App._app_Email;

        lit_App_Nationality.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Nationality", _App._app_Nationality);
        lit_App_LegalResidency.Text = _App._app_LegalResidency == "" ? "&nbsp;" : _App._app_LegalResidency;
        lit_App_IsLivedEULast3Years.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsLivedEULast3Years);
        lit_App_LivedEntryDate.Text = _App._app_LivedEntryDate == "" ? "&nbsp;" : _App._app_LivedEntryDate;

        lit_App_NonEUUKHowLongLiveInUK.Text =_App._app_NonEUUKHowLongLiveInUK;
        lit_App_EUEEANational.Text= DSP.BAL.DBL.GetYesNo(_App._app_EUEEANational);
        lit_App_EUEEAStatus.Text=DSP.BAL.DBL.GetApplicationOptionTitle("EUEEAStatus", _App._app_EUEEAStatus);


        lit_App_Ethnicity.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Ethnicity", _App._app_Ethnicity);
        lit_App_Religion.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Religion", _App._app_Religion);

        //lit_App_SexualOrientation.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Sexual Orientation", _App._app_SexualOrientation);
        lit_App_LengthOfAddress.Text = _App._app_LengthOfAddress;
        lit_App_PrePlannedAbsence.Text = _App._app_PrePlannedAbsence;
        lit_App_Circumstance.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Circumstances", _App._app_Circumstance);

        lit_App_AnyDisability.Text = DSP.BAL.DBL.GetYesNo(_App._app_AnyDisability);
        lit_App_AnyDisabilityPrimary.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Disabilities", _App._app_AnyDisabilityPrimary);

        // displays all ticks selcted... 
        lit_App_AnyDisabilitySecondaries.Text = getAllTickOptions(_App._app_AnyDisabilitySecondaries);

        lit_App_NeedLearningSupport.Text = DSP.BAL.DBL.GetYesNo(_App._app_NeedLearningSupport);
        lit_App_HaveLearnerSupportProgram.Text = DSP.BAL.DBL.GetYesNo(_App._app_HaveLearnerSupportProgram);
        //   lit_App_ProgramAppliedFor.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Program Applied For", _App._app_ProgramAppliedFor);
        lit_App_IsAccessToComputer.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsAccessToComputer);
        lit_App_IsAccessToFaceTime.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsAccessToFaceTime);
        lit_App_IsAccessToEmail.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsAccessToEmail);
        lit_App_IsPartnerOfOwner.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsPartnerOfOwner);

        lit_App_IsEPortoflioAware.Text = DSP.BAL.DBL.GetYesNo(_App._app_IsEPortoflioAware);
        //lit_App_ManageWorkStudy.Text = _App._app_ManageWorkStudy;
        lit_App_educ_HighestQual.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Qualifications", _App._app_educ_HighestQual);
        lit_App_educ_IsGCSEEnglish.Text = DSP.BAL.DBL.GetApplicationOptionTitle("GCSE", _App._app_educ_IsGCSEEnglish);
        lit_App_educ_IsGCSEMath.Text = DSP.BAL.DBL.GetApplicationOptionTitle("GCSE", _App._app_educ_IsGCSEMath);
        lit_App_educ_EquivalentQualification.Text = _App._app_educ_EquivalentQualification;

        lit_App_educ_IsEnrolledOther.Text = DSP.BAL.DBL.GetYesNo(_App._app_educ_IsEnrolledOther);
        lit_App_educ_PreviousCollege.Text = _App._app_educ_PreviousCollege;
        lit_App_educ_PreviousQual.Text = _App._app_educ_PreviousQual;
        lit_App_educ_PreviousTraining.Text = _App._app_educ_PreviousTraining;
        lit_App_educ_IsALLFund.Text = DSP.BAL.DBL.GetYesNo(_App._app_educ_IsALLFund);
        lit_App_educ_ALLFundQualDetails.Text = _App._app_educ_ALLFundQualDetails;
        //lit_App_educ_TrainingPlannedNext12Months.Text = _App._app_educ_TrainingPlannedNext12Months;
        //lit_App_educ_FutureInspirations.Text = _App._app_educ_FutureInspirations;

        lit_App_emp_CompanyName.Text = _App._app_emp_CompanyName;

        lit_App_emp_EmpoyementStartDate.Text = _App._app_emp_EmpoyementStartDate;

        lit_App_emp_WorkPlaceAddress.Text = _App._app_emp_WorkPlaceAddress1 + "</br>" + _App._app_emp_WorkPlaceAddress2 + "</br>" + _App._app_emp_WorkPlaceAddress3;
        lit_App_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
        lit_App_emp_Tel.Text = _App._app_emp_Tel;
        lit_App_emp_Email.Text = _App._app_emp_Email;
        lit_App_emp_ContactName.Text = _App._app_emp_ContactName;
        lit_App_emp_Position.Text = _App._app_emp_Position;
        lit_App_emp_BusinessSector.Text = _App._app_emp_BusinessSector;
        lit_App_emp_CompanyEstablished.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Company Size", _App._app_emp_CompanyEstablished);
        lit_App_emp_WeeklyHours.Text = _App._app_emp_WeeklyHours;
        lit_App_emp_IsSelfEmployed.Text = DSP.BAL.DBL.GetYesNo(_App._app_emp_IsSelfEmployed);
        //lit_App_emp_IsEmployerPaying.Text = DSP.BAL.DBL.GetYesNo(_App._app_emp_IsEmployerPaying);
        lit_App_job_JobFunction.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Job Function", _App._app_job_JobFunction);
        lit_App_job_HowLongWorkingJob.Text = DSP.BAL.DBL.GetApplicationOptionTitle("How long...", _App._app_job_HowLongWorkingJob);
        lit_App_job_HowLongWorkingEmployer.Text = DSP.BAL.DBL.GetApplicationOptionTitle("Howlongemployment", _App._app_job_HowLongWorkingEmployer);
        //lit_App_job_AnyPreviousManagement.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_AnyPreviousManagement);
       // lit_App_job_HaveCurrentDevPlan.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_HaveCurrentDevPlan);
       // lit_App_job_IsAwareFundamentalStd.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsAwareFundamentalStd);
        //lit_App_job_IsResponsibleCQCPIR.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleCQCPIR);
        lit_App_job_IsResponsibleRecruitment.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleRecruitment);
        lit_App_job_IsResponsibleStaffInduction.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleStaffInduction);
        lit_App_job_IsResponsibleStaffAppraisal.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleStaffAppraisal);
        lit_App_job_IsResponsibleMonitoringStaff.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleMonitoringStaff);
        //   lit_App_job_IsResponsibleTaskAllocationRotas.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleTaskAllocationRotas);
        lit_App_job_IsResponsiblePlanningReviewing.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsiblePlanningReviewing);
        //   lit_App_job_IsResponsibleOrganisingReferrals.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleOrganisingReferrals);
        //   lit_App_job_IsResponsibleOrganisingPartnerships.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleOrganisingPartnerships);
        //lit_App_job_IsResponsibleEffectivenessPartnerships.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleEffectivenessPartnerships);
        lit_App_job_IsReviewAuditPolicies.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsReviewAuditPolicies);
        //lit_App_job_IsRespondingToComplaints.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsRespondingToComplaints);
        lit_App_job_IsInvestigatingSafeguarding.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvestigatingSafeguarding);
        //   lit_App_job_IsAuditFeedback.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsAuditFeedback);
        lit_App_job_IsOrganisingLeadStaffMeetings.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsOrganisingLeadStaffMeetings);
        //lit_App_job_IsResponsibleWritingDevPlan.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleWritingDevPlan);
        //lit_App_job_HaveRegularStaffMeetings.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_HaveRegularStaffMeetings);
        // lit_App_job_IsAttendingStrategicMeetings.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsAttendingStrategicMeetings);
        lit_App_job_IsEnsuringComplianceHS.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsEnsuringComplianceHS);
      //  lit_App_job_IsFurtherTrainingNeeded.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsFurtherTrainingNeeded);
        //lit_App_job_IsSpecificSupportNeeded.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsSpecificSupportNeeded);

        lit_App_job_RelevantPathway.Text = DSP.BAL.DBL.GetApplicationOptionTitle(getPathwaysLevel(_App._app_officeuse1_CourseLevel), _App._app_job_RelevantPathway);
       
        lit_App_job_HaveJobDescription.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_HaveJobDescription);
        //lit_App_job_HaveJobDescription_L3.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_HaveJobDescription_L3);
        //lit_App_job_CarryOutAuditing.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_CarryOutAuditing);

        //lit_App_job_DailyMainDuties.Text = _App._app_job_DailyMainDuties;
        //lit_App_job_UsualHoursAttendancy.Text = _App._app_job_UsualHoursAttendancy;
        //lit_App_job_OtherPositionResponsabilities.Text = _App._app_job_OtherPositionResponsabilities;
        //lit_App_job_AboutYourStrenghts.Text = _App._app_job_AboutYourStrenghts;
        //lit_App_job_AreasOfDevelopment.Text = _App._app_job_AreasOfDevelopment;

        lit_App_job_AllowWorkplaceObsVisit.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_AllowWorkplaceObsVisit);
        lit_App_job_TherapySessions.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_TherapySessions);
     
        lit_App_job_HealthPromotion.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_HealthPromotion);
        lit_App__job_Advocate.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_Advocate);
        lit_App_job_SupportServiceUsers.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_SupportServiceUsers);

        lit_App_job_AssessReviewSupportPlans.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_AssessReviewSupportPlans);
        //lit_App_job_IsInvolvedInRiskAssessments.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvolvedInRiskAssessments);
        lit_App_job_ContributeToMentalHealth.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_ContributeToMentalHealth);
        lit_App_job_SupportIndvDepressionPhobias.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_SupportIndvDepressionPhobias);
        lit_App_job_WorkinPartnershipswthProfessionals.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_WorkinPartnershipswthProfessionals);
        lit_App_job_SafeguardReports.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_SafeguardReports);
        lit_App_job_RecruitmentResponsibilities.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_RecruitmentResponsibilities);
        //lit_App_job_StaffInductionCareCertificate.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_StaffInductionCareCertificate);
        lit_App_job_RespondCompliments.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_RespondCompliments);
        lit_App_job_WorkMgtRole.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_WorkMgtRole);
        lit_App_job_TakePartSupervisions.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_TakePartSupervisions);
        lit_App_job_TakePartMeetings.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_TakePartMeetings);
        lit_App_job_MaintainPersonalRecord.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_MaintainPersonalRecord);
        lit_App_job_RiskAssessOthersComply.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_RiskAssessOthersComply);
        lit_App_job_SafeguardInvestigations.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_SafeguardInvestigations);
        lit_App_job_WorkSupportiveRole.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_WorkSupportiveRole);
        lit_App_job_ReviewSupportPlans.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_ReviewSupportPlans);
        lit_App_job_WorkPartnerProfessionals.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_WorkPartnerProfessionals);
        lit_App_job_CVPResilience.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_CVPResilience);
        lit_App_job_TechCommunication.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_TechCommunication);
        //lit_App_job_RegularSupervisions.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_RegularSupervisions);
        lit_App_job_CarryoutRiskAssessment.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_CarryoutRiskAssessment);
        lit_App_job_SupportCYP.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_SupportCYP);
        lit_App_job_PositiveRiskTaking.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_PositiveRiskTaking);
        lit_App_job_KeyWorker.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_KeyWorker);
        lit_App_job_PlanImplementcare.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_PlanImplementcare);
        lit_App_job_WriteRecordReports.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_WriteRecordReports);
        lit_App_job_SocialActivitieswithServiceUser.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_SocialActivitieswithServiceUser);
        lit_App_job_LeadCommunicationProcesses.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_LeadCommunicationProcesses);
        lit_App_job_OrgProvidesResidentialServices.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_OrgProvidesResidentialServices);
        lit_App_job_PersonalCareAssistingMoving.Text= DSP.BAL.DBL.GetYesNo(_App._app_job_PersonalCareAssistingMoving);

        lit_App_job_70.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_70);
        lit_App_job_AssistEatingDrinking.Text= DSP.BAL.DBL.GetYesNo(_App._app_job_AssistEatingDrinking);
		lit_App_job_71.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_71);
        //lit_App_job_72.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_72);
        
        lit_App_job_Confirm16hrs.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_Confirm16hrs == true ? "1" : "0");
        lit_App_job_Confirm16hrsTitle.Text = _App._app_job_Confirm16hrsTitle;

        // lit_App_job_HaveStartedGLH.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_HaveStartedGLH);

        // lit_App_job_IsAssessReviewImplementCare.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsAssessReviewImplementCare);
        //lit_App_job_IsInvolvedRiskAssessment.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvolvedRiskAssessment);
        lit_App_job_IsEnsureOthersFollowPolicy.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsEnsureOthersFollowPolicy);
        //lit_App_job_IsSupportServiceInPersonalCare.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsSupportServiceInPersonalCare);
        // lit_App_job_IsWorkSupportRoleServiceUsers.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsWorkSupportRoleServiceUsers);
        //lit_App_job_IsPlanReviewImplmentCare.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsPlanReviewImplmentCare);
        // lit_App_job_IsInvolvedSafeguardingInvestigations.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvolvedSafeguardingInvestigations);
        // lit_App_job_IsTakePartInRiskAssessment.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsTakePartInRiskAssessment);
        lit_App_job_IsTakePartInManagingQuality.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsTakePartInManagingQuality);

        //lit_App_job_IsContributeSelfAssessment.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsContributeSelfAssessment);
        lit_App_job_IsReviewAuditPolicy.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsReviewAuditPolicy);
        //lit_App_job_IsLeadPartnershipWorking.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsLeadPartnershipWorking);
        lit_App_job_IsLeadProvisionDelivers.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsLeadProvisionDelivers);
        //lit_App_job_IsResponsibleKeyResources.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleKeyResources);
        //lit_App_job_IsResponsibleStaffTraining.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleStaffTraining);
        //lit_App_job_IsResponsibleManagingQuality.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleManagingQuality);
        //lit_App_job_IsResponsibleIncludeDevelopment.Text = DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleIncludeDevelopment);

        //lit_App_job_ExampleProjectManaged.Text = _App._app_job_ExampleProjectManaged;
        //lit_App_job_ExampleSupportingCarePractice.Text = _App._app_job_ExampleSupportingCarePractice;
        //lit_App_job_ExampleCPDRecent.Text = _App._app_job_ExampleCPDRecent;
        //lit_App_job_ExampleCourageImplement.Text = _App._app_job_ExampleCourageImplement;

        lit_App_job_102_KnowledgeStatutoryFrameworks.Text = DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_102_KnowledgeStatutoryFrameworks);
        lit_App_job_103_ExperienceOfManaging.Text = DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_103_ExperienceOfManaging);
        lit_App_job_104_AbilityImplementStrategies.Text = DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_104_AbilityImplementStrategies);
        //lit_App_job_105_ExperienceLeadingSupporting.Text = DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_105_ExperienceLeadingSupporting);
        //lit_App_job_106_CarriedOutActivitiesMonitor.Text = DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_106_CarriedOutActivitiesMonitor);
 

        //lit_App_mktg_HearAbout.Text = DSP.BAL.DBL.GetYesNo(_App._app_mktg_HearAbout);
        //lit_App_mktg_ContactConsent.Text = DSP.BAL.DBL.GetYesNo(_App._app_mktg_ContactConsent);
        //lit_App_mktg_ByPhone.Text = DSP.BAL.DBL.GetYesNo(_App._app_mktg_ByPhone);
        //lit_App_mktg_ByEmail.Text = DSP.BAL.DBL.GetYesNo(_App._app_mktg_ByEmail);
        //lit_App_mktg_ByPost.Text = DSP.BAL.DBL.GetYesNo(_App._app_mktg_ByPost);

       
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
                if (!_App.isNewApplication)
                {

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_HighestQual, _App._app_educ_HighestQual);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsGCSEEnglish, _App._app_educ_IsGCSEEnglish);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsGCSEMath, _App._app_educ_IsGCSEMath);
                    txt_educ_EquivalentQualification.Text = _App._app_educ_EquivalentQualification;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsEnrolledOther, _App._app_educ_IsEnrolledOther);
                    txt_educ_PreviousCollege.Text = _App._app_educ_PreviousCollege;
                    txt_educ_PreviousQual.Text = _App._app_educ_PreviousQual;
                    txt_educ_PreviousTraining.Text = _App._app_educ_PreviousTraining;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsALLFund, _App._app_educ_IsALLFund);
                    txt_educ_ALLFundQualDetails.Text = _App._app_educ_ALLFundQualDetails;

                    //txt_educ_TrainingPlannedNext12Months.Text = _App._app_educ_TrainingPlannedNext12Months;
                    //txt_educ_FutureInspirations.Text = _App._app_educ_FutureInspirations;

                }

                break;
            case 3:
                DSP.BAL.Log.WriteLogTxt(String.Format("LoadDataForStep() | username: {0} |  STEP 3 ", Membership.GetUser().UserName));
                // DisableValidatorForLevel(_App._app_officeuse1_CourseLevel);

                if (!_App.isNewApplication)
                {

                    txt_emp_CompanyName.Text = _App._app_emp_CompanyName;
                    txt_emp_EmpoyementStartDate.Text = _App._app_emp_EmpoyementStartDate;

                    txt_emp_WorkPlaceAddress1.Text = _App._app_emp_WorkPlaceAddress1;
                    txt_emp_WorkPlaceAddress2.Text = _App._app_emp_WorkPlaceAddress2;
                    txt_emp_WorkPlaceAddress3.Text = _App._app_emp_WorkPlaceAddress3;
                    txt_emp_WorkPlacePostCode.Text = _App._app_emp_WorkPlacePostCode;
                    txt_emp_Tel.Text = _App._app_emp_Tel;
                    txt_emp_ContactName.Text = _App._app_emp_ContactName;
                    txt_emp_Position.Text = _App._app_emp_Position;
                    txt_emp_BusinessSector.Text = _App._app_emp_BusinessSector;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_CompanyEstablished, _App._app_emp_CompanyEstablished);

                    txt_emp_WeeklyHours.Text = _App._app_emp_WeeklyHours;
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_WeeklyHours, _App._app_emp_WeeklyHours);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_IsSelfEmployed, _App._app_emp_IsSelfEmployed);
                    //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_emp_IsEmployerPaying, _App._app_emp_IsEmployerPaying);

                }
                break;

            case 4:

                DSP.BAL.Log.WriteLogTxt(String.Format("LoadDataForStep() | username: {0} |  STEP 4 ", Membership.GetUser().UserName));
                DisableValidatorForLevel(_App._app_officeuse1_CourseLevel);

                if (!_App.isNewApplication)
                {
                    ddl_job_HowLongWorkingEmployer.DataBind();
                    if (_App._app_officeuse1_CourseLevel != 51 || _App._app_officeuse1_CourseLevel != 52)
                    {
                        ddl_job_RelevantPathway.DataBind();
                    }
                    // ddl_job_RelevantPathway_L3.DataBind();
                    // ddl_job_JobFunction.DataBind();
                    // ddl_job_HowLongWorkingJob.DataBind();
                    ddl_job_Confirm16hrsId.DataBind();

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_HighestQual, _App._app_educ_HighestQual);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsGCSEEnglish, _App._app_educ_IsGCSEEnglish);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsGCSEMath, _App._app_educ_IsGCSEMath);
                    txt_educ_EquivalentQualification.Text = _App._app_educ_EquivalentQualification;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsEnrolledOther, _App._app_educ_IsEnrolledOther);
                    txt_educ_PreviousCollege.Text = _App._app_educ_PreviousCollege;
                    txt_educ_PreviousQual.Text = _App._app_educ_PreviousQual;
                    txt_educ_PreviousTraining.Text = _App._app_educ_PreviousTraining;
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_educ_IsALLFund, _App._app_educ_IsALLFund);
                    txt_educ_ALLFundQualDetails.Text = _App._app_educ_ALLFundQualDetails;
                    //txt_educ_TrainingPlannedNext12Months.Text = _App._app_educ_TrainingPlannedNext12Months;
                    //txt_educ_FutureInspirations.Text = _App._app_educ_FutureInspirations;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_JobFunction, _App._app_job_JobFunction);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HowLongWorkingJob, _App._app_job_HowLongWorkingJob);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HowLongWorkingEmployer, _App._app_job_HowLongWorkingEmployer, false);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AnyPreviousManagement, _App._app_job_AnyPreviousManagement);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveCurrentDevPlan, _App._app_job_HaveCurrentDevPlan);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAwareFundamentalStd, _App._app_job_IsAwareFundamentalStd);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleCQCPIR, _App._app_job_IsResponsibleCQCPIR);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleRecruitment, _App._app_job_IsResponsibleRecruitment);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleStaffInduction, _App._app_job_IsResponsibleStaffAppraisal);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleStaffraisal, _App._app_job_IsResponsibleStaffAppraisal);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleMonitoringStaff, _App._app_job_IsResponsibleMonitoringStaff);
                    //   DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleTaskAllocationRotas, _App._app_job_IsResponsibleTaskAllocationRotas);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsiblePlanningReviewing, _App._app_job_IsResponsiblePlanningReviewing);
                    //   DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleOrganisingReferrals, _App._app_job_IsResponsibleOrganisingReferrals);
                    //   DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleOrganisingPartnerships, _App._app_job_IsResponsibleOrganisingPartnerships);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleEffectivenessPartnerships, _App._app_job_IsResponsibleEffectivenessPartnerships);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsReviewAuditPolicies, _App._app_job_IsReviewAuditPolicies);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsRespondingToComplaints, _App._app_job_IsRespondingToComplaints);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvestigatingSafeguarding, _App._app_job_IsInvestigatingSafeguarding);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAuditFeedback, _App._app_job_IsAuditFeedback);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsOrganisingLeadStaffMeetings, _App._app_job_IsOrganisingLeadStaffMeetings);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleWritingDevPlan, _App._app_job_IsResponsibleWritingDevPlan);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveRegularStaffMeetings, _App._app_job_HaveRegularStaffMeetings);
                    //  DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAttendingStrategicMeetings, _App._app_job_IsAttendingStrategicMeetings);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsEnsuringComplianceHS, _App._app_job_IsEnsuringComplianceHS);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsFurtherTrainingNeeded, _App._app_job_IsFurtherTrainingNeeded);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsSpecificSupportNeeded, _App._app_job_IsSpecificSupportNeeded);
                    if (_App._app_officeuse1_CourseLevel != 51 || _App._app_officeuse1_CourseLevel != 52)
                    {
                        DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RelevantPathway, _App._app_job_RelevantPathway);
                    }
                        //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RelevantPathway_L3, _App._app_job_RelevantPathway_L3, false);

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveJobDescription, _App._app_job_HaveJobDescription);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveJobDescription_L3, _App._app_job_HaveJobDescription_L3);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_CarryOutAuditing, _App._app_job_CarryOutAuditing);

                    //txt_job_AreasOfDevelopment.Text = _App._app_job_AreasOfDevelopment;

                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AllowWorkplaceObsVisit, _App._app_job_AllowWorkplaceObsVisit);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TherapySessions, _App._app_job_TherapySessions);

         
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HealthPromotion, _App._app_job_HealthPromotion);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_Advocate, _App._app_job_Advocate);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SupportServiceUsers, _App._app_job_SupportServiceUsers);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AssessReviewSupportPlans, _App._app_job_AssessReviewSupportPlans);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvolvedInRiskassessments, _App._app_job_IsInvolvedInRiskAssessments);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_ContributeToMentalHealth, _App._app_job_ContributeToMentalHealth);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SupportIndvDepresionPhobias, _App._app_job_SupportIndvDepressionPhobias);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkinPartnershipswthProfesionals, _App._app_job_WorkinPartnershipswthProfessionals);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SafeguardReports, _App._app_job_SafeguardReports);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RecruitmentResponsibilities, _App._app_job_RecruitmentResponsibilities);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_StaffInductionCareCertificate, _App._app_job_StaffInductionCareCertificate);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RespondCompliments, _App._app_job_RespondCompliments);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkMgtRole, _App._app_job_WorkMgtRole);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TakePartSupervisions, _App._app_job_TakePartSupervisions);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TakePartMeetings, _App._app_job_TakePartMeetings);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_MaintainPersonalRecord, _App._app_job_MaintainPersonalRecord);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RiskAssessOthersComply, _App._app_job_RiskAssessOthersComply);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SafeguardInvestigations, _App._app_job_SafeguardInvestigations);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkSupportiveRole, _App._app_job_WorkSupportiveRole);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_ReviewSupportPlans, _App._app_job_ReviewSupportPlans);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WorkPartnerProfessionals, _App._app_job_WorkPartnerProfessionals);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_CVPResilience, _App._app_job_CVPResilience);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_TechCommunication, _App._app_job_TechCommunication);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_RegularSupervisions, _App._app_job_RegularSupervisions);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_CarryoutRiskAssessment, _App._app_job_CarryoutRiskAssessment);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SupportCYP, _App._app_job_SupportCYP);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_PositiveRiskTaking, _App._app_job_PositiveRiskTaking);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_KeyWorker, _App._app_job_KeyWorker);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_PlanImplementcare, _App._app_job_PlanImplementcare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_WriteRecordReports, _App._app_job_WriteRecordReports);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_SocialActivitieswithServiceUser, _App._app_job_SocialActivitieswithServiceUser);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_LeadCommunicationProcesses, _App._app_job_LeadCommunicationProcesses);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_OrgProvidesResidentialServices, _App._app_job_OrgProvidesResidentialServices);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_PersonalCareAssistingMoving, _App._app_job_PersonalCareAssistingMoving);


                    //level 2
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_70, _App._app_job_70);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_AssistEatingDrinking, _App._app_job_AssistEatingDrinking);
 					DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_71, _App._app_job_71);
                   //	DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_72, _App._app_job_72);
                  
                    DSP.BAL.Basic.convertAndCheckNullAndSetCheckBox(chk_job_Confirm16hrs, _App._app_job_Confirm16hrs);
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_Confirm16hrsId, _App._app_job_Confirm16hrsId);
                    if (_App._app_job_Confirm16hrsId != 0)
                    {
                        DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_Confirm16hrsId, _App._app_job_Confirm16hrsId);
                    }
                     
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_HaveStartedGLH, _App._app_job_HaveStartedGLH);

                    //txt_job_DailyMainDuties.Text = _App._app_job_DailyMainDuties;
                    //txt_job_UsualHoursAttendancy.Text = _App._app_job_UsualHoursAttendancy;
                    //txt_job_OtherPositionResponsabilities.Text = _App._app_job_OtherPositionResponsabilities;
                    //txt_job_AboutYourStrenghts.Text = _App._app_job_AboutYourStrenghts;

                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsAssessReviewImplementCare, _App._app_job_IsAssessReviewImplementCare);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvolvedRiskAssessment, _App._app_job_IsInvolvedRiskAssessment);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsEnsureOthersFollowPolicy, _App._app_job_IsEnsureOthersFollowPolicy);
                    
                    /*DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsSupportServiceInPersonalCare, _App._app_job_IsSupportServiceInPersonalCare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsWorkSupportRoleServiceUsers, _App._app_job_IsWorkSupportRoleServiceUsers);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsPlanReviewImplmentCare, _App._app_job_IsPlanReviewImplmentCare);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsInvolvedSafeguardingInvestigations, _App._app_job_IsInvolvedSafeguardingInvestigations);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsTakePartInRiskAssessment, _App._app_job_IsTakePartInRiskAssessment);
                    */
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsTakePartInManagingQuality, _App._app_job_IsTakePartInManagingQuality);

                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsContributeSelfAssessment, _App._app_job_IsContributeSelfAssessment);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsReviewAuditPolicy, _App._app_job_IsReviewAuditPolicy);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsLeadPartnershipWorking, _App._app_job_IsLeadPartnershipWorking);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsLeadProvisionDelivers, _App._app_job_IsLeadProvisionDelivers);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleKeyResources, _App._app_job_IsResponsibleKeyResources);
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleStaffTraining, _App._app_job_IsResponsibleStaffTraining);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleManagingQuality, _App._app_job_IsResponsibleManagingQuality);
                   /// DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_IsResponsibleIncludeDevelopment, _App._app_job_IsResponsibleIncludeDevelopment);

                    //txt_job_ExampleProjectManaged.Text = _App._app_job_ExampleProjectManaged;
                    //txt_job_ExampleSupportingCarePractice.Text = _App._app_job_ExampleSupportingCarePractice;
                    //txt_job_ExampleCPDRecent.Text = _App._app_job_ExampleCPDRecent;
                    //txt_job_ExampleCourageImplement.Text = _App._app_job_ExampleCourageImplement;

                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_102_KnowledgeStatutoryFrameworks, _App._app_job_102_KnowledgeStatutoryFrameworks);
                   // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_103_ExperienceOfManaging, _App._app_job_103_ExperienceOfManaging);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_104_AbilityImplementStrategies, _App._app_job_104_AbilityImplementStrategies);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_105_ExperienceLeadingSupporting, _App._app_job_105_ExperienceLeadingSupporting);
                    //DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_job_106_CarriedOutActivitiesMonitor, _App._app_job_106_CarriedOutActivitiesMonitor);
                   
                    // DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_mktg_HearAbout, _App._app_mktg_HearAbout);
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

            // Server.Transfer(vars.ERROR_PAGE_SESSIONTIMEDOUT);
            // Server.Transfer("Default.aspx");
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

            // _App._app_PrintName = txtPrintName.Text.Trim();
            //  _App._app_ApplicationDate = txtApplicationDate.Text.Trim();

            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | username: {0} | Application ready for submission | App id: {1} ", Membership.GetUser().UserName, _App._app_id, _App._app_id));

            _App.SubmitApplicationAdmin();

            DSP.BAL.Log.WriteLogTxt(String.Format("Wizard1_FinishButtonClick() | username: {0} | Application SUBMITTED | App id: {1} ", Membership.GetUser().UserName, _App._app_id, _App._app_id));

            /*  if (vars.LIVEMODE)
              {
                  Server.Transfer(vars.LANDING_PAGE_LIVE);
              }
              else
              {
                  Server.Transfer(vars.LANDING_PAGE_DEV);
              }
  */
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
            setPathwaysLevel(_App._app_officeuse1_CourseLevel);
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
                setPathwaysLevel(_App._app_officeuse1_CourseLevel);
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
                //pLevel3a.Visible = true;
                //pLevel4a.Visible = false;
                //pLevel5a.Visible = false;
                DisableValidatorForLevel4();
                DisableValidatorForLevel5();

                break;
            case 4:

                //pLevel3a.Visible = false;
                // pLevel4a.Visible = true;
                //pLevel5a.Visible = false;
                DisableValidatorForLevel3();
                DisableValidatorForLevel5();
                break;
            case 5:
               /* pLevel3a.Visible = false;
                pLevel4a.Visible = false;
                pLevel5a.Visible = true;*/

                switch (_App._app_officeuse1_CourseId)
                {
                    case 82:
                        //hide questions
                       // pLevel5Hide82.Visible = false;
                        //show questions
                        
                        break;
                    case 96:
                        //show questions
                        
                          
                         
                        break;

                }
                     


                


                DisableValidatorForLevel3();
                DisableValidatorForLevel4();
                break;
            default:
                //pLevel3a.Visible = false;
                // pLevel4a.Visible = false;
                // pLevel5a.Visible = true;

                DisableValidatorForLevel3();
                DisableValidatorForLevel4();
                break;


        }


    }
    protected void DisableValidatorForLevel3()
    {
        DSP.BAL.Log.WriteLogTxt(String.Format("DisableValidatorForLevel3() | username: {0} ", Membership.GetUser().UserName));

       // rfv_job_IsAssessReviewImplementCare.Enabled = false;
      //  rfv_job_IsInvolvedRiskAssessment.Enabled = false;
        rfv_job_IsEnsureOthersFollowPolicy.Enabled = false;
       // rfv_job_IsSupportServiceInPersonalCare.Enabled = false;
       // rfv_job_RelevantPathway_L3.Enabled = false;
       // rfv_job_HaveJobDescription_L3.Enabled = false;
    }
    protected void DisableValidatorForLevel4()
    {
        DSP.BAL.Log.WriteLogTxt(String.Format("DisableValidatorForLevel4() | username: {0} ", Membership.GetUser().UserName));
        //level 4 questions disabling
       /* rfv_job_IsWorkSupportRoleServiceUsers.Enabled = false;
        rfv_job_IsPlanReviewImplmentCare.Enabled = false;
        rfv_job_IsInvolvedSafeguardingInvestigations.Enabled = false;
        rfv_job_IsTakePartInRiskAssessment.Enabled = false;*/
        rfv_job_IsTakePartInManagingQuality.Enabled = false;
        //rfv_job_AnyPreviousManagement.Enabled = false;
    }
    protected void DisableValidatorForLevel5()
    {
        DSP.BAL.Log.WriteLogTxt(String.Format("DisableValidatorForLevel5() | username: {0} ", Membership.GetUser().UserName));

        //level 5 questions disabling

        //rfv_job_AnyPreviousManagement.Enabled = false;
        //rfv_job_HaveCurrentDevPlan.Enabled = false;
       // rfv_job_IsAwareFundamentalStd.Enabled = false;
       // rfv_job_IsResponsibleCQCPIR.Enabled = false;
        rfv_job_IsResponsibleRecruitment.Enabled = false;
        rfv_job_IsResponsibleStaffInduction.Enabled = false;
        rfv_job_IsResponsibleStaffraisal.Enabled = false;
        rfv_job_IsResponsibleMonitoringStaff.Enabled = false;
        // rfv_job_IsResponsiblePlanningReviewing.Enabled = false;
        //rfv_job_IsResponsibleEffectivenessPartnerships.Enabled = false;
        rfv_job_IsReviewAuditPolicies.Enabled = false;
        //rfv_job_IsRespondingToComplaints.Enabled = false;
        //rfv_job_IsInvestigatingSafeguarding.Enabled = false;
        rfv_job_IsOrganisingLeadStaffMeetings.Enabled = false;
        rfv_job_IsEnsuringComplianceHS.Enabled = false;
       // rfv_job_IsFurtherTrainingNeeded.Enabled = false;


        rfv_job_RelevantPathway.Enabled = false;
        rfv_job_HaveJobDescription.Enabled = false;

       // rfv_job_DailyMainDuties.Enabled = false;
        //rfv_job_OtherPositionResponsabilities.Enabled = false;
        //rfv_job_AboutYourStrenghts.Enabled = false;
        //rfv_job_AreasOfDevelopment.Enabled = false;

    }
    #endregion


    #region "hide controls for different levels"
    protected void HideControlsForLevel(int CourseLevel)
    {
        switch (CourseLevel)
        {
            case 3:
                //pLevel3.Visible = true;
                //pLevel4.Visible = false;
                // pLevel5.Visible = false;

                break;
            case 4:

                // pLevel3.Visible = false;
                // pLevel4.Visible = true;
                // pLevel5.Visible = false;
                break;
            case 5:
                //pLevel3.Visible = false;
                //pLevel4.Visible = false;
                //pLevel5.Visible = true;


                switch (_App._app_officeuse1_CourseId)
                {
                    case 82:
                        //hide questions
                        // pLevel5Hide82.Visible = false;
                        //show questions
                         
                        break;
                    case 96:
                        //show questions
                          
                         break;
                }
 
                break;
            default:
                //  pLevel3.Visible = false;
                // pLevel4.Visible = false;
                // pLevel5.Visible = true;
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
            setPathwaysLevel(_App._app_officeuse1_CourseLevel); 
            lblAppId.Text = _App._app_id.ToString();

            //if (!_App.isNewApplication)
            //{ }
        }

        int iStep = Wizard1.ActiveStepIndex;

        switch (iStep)
        {

            case 1:

                //string sName = txtName.Text.Trim();
                //_App._app_FirstName = DSP.BAL.Basic.;
                break;

            case 2:
                string sEduc_quali = txt_educ_PreviousTraining.Text.Trim();
                break;

            case 3:
                string sApp_emp_CompanyName = txt_emp_CompanyName.Text.Trim();
                break;

            //case 4:
            //    string sApp_job_DailyMainDuties = txt_job_DailyMainDuties.Text.Trim();
            //    break;

            case 5:

                //load all data here to display


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
        // LoadApplicationForConfirmation(_App);

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
            //if (ConfigurationManager.AppSettings["cfg_test"] == "true")
            //{
            //    _App.EnrolNowApplicationAdmin_TEST();
            //}
            //else
            //{

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
                            "alert('QCS registration failed. ERROR : "+ message + "');window.location ='ManageApplications.aspx';",
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

            //Response.Redirect("~/Portal/SalesAdvisor/ManageApplications.aspx");
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
            emailContactUs.sTo = "accessskills.wave@gmail.com";
            emailContactUs.sSubject += "ERROR: " + "oEmailNotifications.SendMail_ContactUs()";
            emailContactUs.sBody += exx.Message;
            emailContactUs.SendMail();
        }
        return true;
    }

    public void checkCheckBox(object o, ServerValidateEventArgs e)
    {
        if (chk_job_Confirm16hrs.Checked)
        {
            e.IsValid = true;
            //  ddl_job_Confirm16hrsId.Enabled = true;
        }
        else
        {
            e.IsValid = false;
            //  ddl_job_Confirm16hrsId.Enabled = false;
        }
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

                if (_App._app_Title != ddlTitles.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Title", _App._app_Title), DBL.GetApplicationOptionTitle("Title", ddlTitles.SelectedValue), "app_Title"); isAmended = true;
                }
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
                if (_App._app_NI != DSP.BAL.Basic.FormatStringForSQL(txtNI.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_NI, Basic.FormatStringForSQL(txtNI.Text.Trim()), "app_NI"); isAmended = true;
                }
                if (_App._app_PermAddress1 != DSP.BAL.Basic.FormatStringForSQL(txtAddress1.Text.Trim()) || _App._app_PermAddress2 != DSP.BAL.Basic.FormatStringForSQL(txtAddress2.Text.Trim()) || _App._app_PermAddress3 != DSP.BAL.Basic.FormatStringForSQL(txtAddress3.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_PermAddress1 + "\n" + _App._app_PermAddress2 + "\n" + _App._app_PermAddress3,
                        Basic.FormatStringForSQL(txtAddress1.Text.Trim()) + "\n" + Basic.FormatStringForSQL(txtAddress2.Text.Trim()) + "\n" + Basic.FormatStringForSQL(txtAddress3.Text.Trim())
                        , "app_PermAddress1"); isAmended = true;
                }
                //if (_App._app_PermAddress2 != DSP.BAL.Basic.FormatStringForSQL(txtAddress2.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_educ_PreviousCollege, Basic.FormatStringForSQL(txt_educ_PreviousCollege.Text.Trim()), "app_educ_PreviousCollege"); isAmended = true;
                //}
                //if (_App._app_PermAddress3 != DSP.BAL.Basic.FormatStringForSQL(txtAddress3.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_educ_PreviousCollege, Basic.FormatStringForSQL(txt_educ_PreviousCollege.Text.Trim()), "app_educ_PreviousCollege"); isAmended = true;
                //}
                if (_App._app_PermPostCode != DSP.BAL.Basic.FormatStringForSQL(txtPostcode.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_PermPostCode, Basic.FormatStringForSQL(txtPostcode.Text.Trim()), "app_PermPostCode"); isAmended = true;
                }
                if (_App._app_HomeTel != DSP.BAL.Basic.FormatStringForSQL(txtTel.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_HomeTel, Basic.FormatStringForSQL(txtTel.Text.Trim()), "app_HomeTel"); isAmended = true;
                }
                if (_App._app_Mobile != DSP.BAL.Basic.FormatStringForSQL(txtMobile.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_Mobile, Basic.FormatStringForSQL(txtMobile.Text.Trim()), "app_Mobile"); isAmended = true;
                }
                if (_App._app_Email != DSP.BAL.Basic.FormatStringForSQL(txt_Email.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_Email, Basic.FormatStringForSQL(txt_Email.Text.Trim()), "app_Email"); isAmended = true;
                }
                if (_App._app_Nationality != ddlNationality.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Nationality", _App._app_Nationality), DBL.GetApplicationOptionTitle("Nationality", ddlNationality.SelectedValue), "app_Nationality"); isAmended = true;
                }
                if (_App._app_LegalResidency != DSP.BAL.Basic.FormatStringForSQL(txtLegalResidency.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_LegalResidency, Basic.FormatStringForSQL(txtLegalResidency.Text.Trim()), "app_LegalResidency"); isAmended = true;
                }
                //if (_App._app_LegalResidency_doc != Request.Form["uploaded_file_legalresidency"])
                //{
                //    SetValueOfChanges(_App._app_LegalResidency_doc, Request.Form["uploaded_file_legalresidency"], "app_LegalResidency_doc"); isAmended = true;
                //}
                if (_App._app_IsLivedEULast3Years != DSP.BAL.Basic.FormatStringForSQL(ddlIsLivedEULast3Years.Text.Trim()))
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_IsLivedEULast3Years), DBL.GetYesNo(Basic.FormatStringForSQL(ddlIsLivedEULast3Years.Text.Trim())), "app_IsLivedEULast3Years"); isAmended = true;
                }
                if (_App._app_LivedEntryDate != DSP.BAL.Basic.FormatStringForSQL(txtLivedEntryDate.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_LivedEntryDate, Basic.FormatStringForSQL(txtLivedEntryDate.Text.Trim()), "app_LivedEntryDate"); isAmended = true;
                }
                if (_App._app_NonEUUKHowLongLiveInUK != DSP.BAL.Basic.FormatStringForSQL(txtNonEUUKHowLongLiveInUK.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_NonEUUKHowLongLiveInUK, Basic.FormatStringForSQL(txtNonEUUKHowLongLiveInUK.Text.Trim()), "app_NonEUUKHowLongLiveInUK"); isAmended = true;
                }
                if (_App._app_EUEEANational != DSP.BAL.Basic.FormatStringForSQL(ddlEUEAANational.Text.Trim()))
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_EUEEANational), Basic.FormatStringForSQL(ddlEUEAANational.Text.Trim()), "app_EUEEANational"); isAmended = true;
                }

                if (_App._app_EUEEAStatus != DSP.BAL.Basic.FormatStringForSQL(ddlEUEEAStatus.Text.Trim()))
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("EUEEAStatus",_App._app_EUEEAStatus), Basic.FormatStringForSQL(ddlEUEEAStatus.Text.Trim()), "app_EUEEAStatus"); isAmended = true;
                }
                if (_App._app_Ethnicity != ddlEthnicity.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Ethnicity", _App._app_Ethnicity), DBL.GetApplicationOptionTitle("Ethnicity", ddlEthnicity.SelectedValue), "app_Ethnicity"); isAmended = true;
                }
                if (_App._app_Religion != ddlReligion.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Religion", _App._app_Religion), DBL.GetApplicationOptionTitle("Religion", ddlReligion.SelectedValue), "app_Religion"); isAmended = true;
                }
                if (_App._app_LengthOfAddress != DSP.BAL.Basic.FormatStringForSQL(txtLengthOfAddress.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_LengthOfAddress, Basic.FormatStringForSQL(txtLengthOfAddress.Text.Trim()), "app_LengthOfAddress"); isAmended = true;
                }
                if (_App._app_PrePlannedAbsence != DSP.BAL.Basic.FormatStringForSQL(txtPrePlannedAbsence.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_PrePlannedAbsence, Basic.FormatStringForSQL(txtPrePlannedAbsence.Text.Trim()), "app_PrePlannedAbsence"); isAmended = true;
                }
                if (_App._app_Circumstance != ddlCircumstance.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Circumstances", _App._app_Circumstance), DBL.GetApplicationOptionTitle("Circumstances", ddlCircumstance.SelectedValue), "app_Circumstance"); isAmended = true;
                }
                if (_App._app_AnyDisability != ddlAnyDisability.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_AnyDisability), DBL.GetYesNo(ddlAnyDisability.SelectedValue), "app_AnyDisability"); isAmended = true;
                }
                if (_App._app_AnyDisabilityPrimary != ddlAnyDisabilityPrimary.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Disabilities", _App._app_AnyDisabilityPrimary), DBL.GetApplicationOptionTitle("Disabilities", ddlAnyDisabilityPrimary.SelectedValue), "app_AnyDisabilityPrimary"); isAmended = true;
                }
                if (_App._app_AnyDisabilitySecondaries != getSelectedTicks())
                {
                    SetValueOfChanges(getAllTickOptions(_App._app_AnyDisabilitySecondaries), getAllTickOptions(getSelectedTicks()), "app_AnyDisabilitySecondaries"); isAmended = true;
                }
                if (_App._app_NeedLearningSupport != ddlNeedLearningSupport.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_NeedLearningSupport), DBL.GetYesNo(ddlNeedLearningSupport.SelectedValue), "app_NeedLearningSupport"); isAmended = true;
                }
                if (_App._app_HaveLearnerSupportProgram != ddlHaveLearnerSupportProgram.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_HaveLearnerSupportProgram), DBL.GetYesNo(ddlHaveLearnerSupportProgram.SelectedValue), "app_HaveLearnerSupportProgram"); isAmended = true;
                }
                //if (_App._app_ProgramAppliedFor != "")
                //{
                //    SetValueOfChanges(_App._app_educ_PreviousCollege, Basic.FormatStringForSQL(txt_educ_PreviousCollege.Text.Trim()), "app_educ_PreviousCollege"); isAmended = true;
                //}
                if (_App._app_IsAccessToComputer != ddlIsAccessToComputer.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_IsAccessToComputer), DBL.GetYesNo(ddlIsAccessToComputer.SelectedValue), "app_IsAccessToComputer"); isAmended = true;
                }
                if (_App._app_IsAccessToFaceTime != ddlIsAccessToFaceTime.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_IsAccessToFaceTime), DBL.GetYesNo(ddlIsAccessToFaceTime.SelectedValue), "app_IsAccessToFaceTime"); isAmended = true;
                }
                if (_App._app_IsAccessToEmail != ddlIsAccessToEmail.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_IsAccessToEmail), DBL.GetYesNo(ddlIsAccessToEmail.SelectedValue), "app_IsAccessToEmail"); isAmended = true;
                }
                if (_App._app_IsPartnerOfOwner != ddlIsPartnerOfOwner.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_IsPartnerOfOwner), DBL.GetYesNo(ddlIsPartnerOfOwner.SelectedValue), "app_IsPartnerOfOwner"); isAmended = true;
                }
                if (_App._app_IsEPortoflioAware != ddlIsEPortoflioAware.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_IsEPortoflioAware), DBL.GetYesNo(ddlIsEPortoflioAware.SelectedValue), "app_IsEPortoflioAware"); isAmended = true;
                }

                return _App.SaveChangesToApplicationsTrackChanges(applicationsTrackChangesList, _App._app_id, userId, isAmended);

            case 1:
                if (_App._app_educ_HighestQual != ddl_educ_HighestQual.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Qualifications", _App._app_educ_HighestQual), DBL.GetApplicationOptionTitle("Qualifications", ddl_educ_HighestQual.SelectedValue), "app_educ_HighestQual"); isAmended = true;
                }
                if (_App._app_educ_IsGCSEEnglish != ddl_educ_IsGCSEEnglish.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("GCSE", _App._app_educ_IsGCSEEnglish), DBL.GetApplicationOptionTitle("GCSE", ddl_educ_IsGCSEEnglish.SelectedValue), "app_educ_IsGCSEEnglish"); isAmended = true;
                }
                if (_App._app_educ_IsGCSEMath != ddl_educ_IsGCSEMath.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("GCSE", _App._app_educ_IsGCSEMath), DBL.GetApplicationOptionTitle("GCSE", ddl_educ_IsGCSEMath.SelectedValue), "app_educ_IsGCSEMath"); isAmended = true;
                }
                if (_App._app_educ_EquivalentQualification != DSP.BAL.Basic.FormatStringForSQL(txt_educ_EquivalentQualification.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_educ_EquivalentQualification, Basic.FormatStringForSQL(txt_educ_EquivalentQualification.Text.Trim()), "app_educ_EquivalentQualification"); isAmended = true;
                }
                if (_App._app_educ_IsEnrolledOther != ddl_educ_IsEnrolledOther.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_educ_IsEnrolledOther), DBL.GetYesNo(ddl_educ_IsEnrolledOther.SelectedValue), "app_educ_IsEnrolledOther"); isAmended = true;
                }
                if (_App._app_educ_PreviousCollege != DSP.BAL.Basic.FormatStringForSQL(txt_educ_PreviousCollege.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_educ_PreviousCollege, Basic.FormatStringForSQL(txt_educ_PreviousCollege.Text.Trim()), "app_educ_PreviousCollege"); isAmended = true;
                }
                if (_App._app_educ_PreviousQual != DSP.BAL.Basic.FormatStringForSQL(txt_educ_PreviousQual.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_educ_PreviousQual, Basic.FormatStringForSQL(txt_educ_PreviousQual.Text.Trim()), "app_educ_PreviousQual"); isAmended = true;
                }
                if (_App._app_educ_PreviousTraining != DSP.BAL.Basic.FormatStringForSQL(txt_educ_PreviousTraining.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_educ_PreviousTraining, Basic.FormatStringForSQL(txt_educ_PreviousTraining.Text.Trim()), "app_educ_PreviousTraining"); isAmended = true;
                }
                if (_App._app_educ_IsALLFund != ddl_educ_IsALLFund.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_educ_IsALLFund), DBL.GetYesNo(ddl_educ_IsALLFund.SelectedValue), "app_educ_IsALLFund"); isAmended = true;
                }
                if (_App._app_educ_ALLFundQualDetails != DSP.BAL.Basic.FormatStringForSQL(txt_educ_ALLFundQualDetails.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_educ_ALLFundQualDetails, Basic.FormatStringForSQL(txt_educ_ALLFundQualDetails.Text.Trim()), "app_educ_ALLFundQualDetails"); isAmended = true;
                }


                return _App.SaveChangesToApplicationsTrackChanges(applicationsTrackChangesList, _App._app_id, userId, isAmended);

            case 2:
                if (_App._app_emp_CompanyName != DSP.BAL.Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_CompanyName, Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim()), "app_emp_CompanyName"); isAmended = true;
                }
                if (_App._app_emp_EmpoyementStartDate != DSP.BAL.Basic.FormatStringForSQL(txt_emp_EmpoyementStartDate.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_EmpoyementStartDate, Basic.FormatStringForSQL(txt_emp_EmpoyementStartDate.Text.Trim()), "app_emp_EmpoyementStartDate"); isAmended = true;
                }
                if (_App._app_emp_WorkPlaceAddress1 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim()) || _App._app_emp_WorkPlaceAddress2 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim()) || _App._app_emp_WorkPlaceAddress3 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_WorkPlaceAddress1 + "\n" + _App._app_emp_WorkPlaceAddress2 + "\n" + _App._app_emp_WorkPlaceAddress3, Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress1.Text.Trim()) + "\n" + Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim()) + "\n" + Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim())
                        , "app_emp_WorkPlaceAddress1"); isAmended = true;
                }
                //if (_App._app_emp_WorkPlaceAddress2 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress2.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_emp_CompanyName, Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim()), "app_emp_CompanyName"); isAmended = true;
                //}
                //if (_App._app_emp_WorkPlaceAddress3 != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WorkPlaceAddress3.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_emp_CompanyName, Basic.FormatStringForSQL(txt_emp_CompanyName.Text.Trim()), "app_emp_CompanyName"); isAmended = true;
                //}
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
                if (_App._app_emp_Position != DSP.BAL.Basic.FormatStringForSQL(txt_emp_Position.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_Position, Basic.FormatStringForSQL(txt_emp_Position.Text.Trim()), "app_emp_Position"); isAmended = true;
                }
                if (_App._app_emp_Email != DSP.BAL.Basic.FormatStringForSQL(txt_emp_Email.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_Email, Basic.FormatStringForSQL(txt_emp_Email.Text.Trim()), "app_emp_Email"); isAmended = true;
                }
                if (_App._app_emp_BusinessSector != DSP.BAL.Basic.FormatStringForSQL(txt_emp_BusinessSector.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_BusinessSector, Basic.FormatStringForSQL(txt_emp_BusinessSector.Text.Trim()), "app_emp_BusinessSector"); isAmended = true;
                }
                if (_App._app_emp_CompanyEstablished != ddl_emp_CompanyEstablished.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Company Size", _App._app_emp_CompanyEstablished), DBL.GetApplicationOptionTitle("Company Size", ddl_emp_CompanyEstablished.SelectedValue), "app_emp_CompanyEstablished"); isAmended = true;
                }
                if (_App._app_emp_WeeklyHours != DSP.BAL.Basic.FormatStringForSQL(txt_emp_WeeklyHours.Text.Trim()))
                {
                    SetValueOfChanges(_App._app_emp_WeeklyHours, Basic.FormatStringForSQL(txt_emp_WeeklyHours.Text.Trim()), "app_emp_WeeklyHours"); isAmended = true;
                }
                if (_App._app_emp_IsSelfEmployed != ddl_emp_IsSelfEmployed.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_emp_IsSelfEmployed), DBL.GetYesNo(ddl_emp_IsSelfEmployed.SelectedValue), "app_emp_IsSelfEmployed"); isAmended = true;
                }

                return _App.SaveChangesToApplicationsTrackChanges(applicationsTrackChangesList, _App._app_id, userId, isAmended);
            //  break;

            case 3:
                if (_App._app_job_JobFunction != ddl_job_JobFunction.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Job Function", _App._app_job_JobFunction), DBL.GetApplicationOptionTitle("Job Function", ddl_job_JobFunction.SelectedValue), "app_job_JobFunction"); isAmended = true;
                }
                if (_App._app_job_HowLongWorkingJob != ddl_job_HowLongWorkingJob.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("How long...", _App._app_job_HowLongWorkingJob), DBL.GetApplicationOptionTitle("How long...", ddl_job_HowLongWorkingJob.SelectedValue), "app_job_HowLongWorkingJob"); isAmended = true;
                }
                if (_App._app_job_HowLongWorkingEmployer != ddl_job_HowLongWorkingEmployer.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle("Howlongemployment", _App._app_job_HowLongWorkingEmployer), DBL.GetApplicationOptionTitle("Howlongemployment", ddl_job_HowLongWorkingEmployer.SelectedValue), "app_job_HowLongWorkingEmployer"); isAmended = true;

                }
                //if (_App._app_job_AnyPreviousManagement != ddl_job_AnyPreviousManagement.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_AnyPreviousManagement), DBL.GetYesNo(ddl_job_AnyPreviousManagement.SelectedValue), "app_job_AnyPreviousManagement"); isAmended = true;
                //}
                //if (_App._app_job_HaveCurrentDevPlan != ddl_job_HaveCurrentDevPlan.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_HaveCurrentDevPlan), DBL.GetYesNo(ddl_job_HaveCurrentDevPlan.SelectedValue), "app_job_HaveCurrentDevPlan"); isAmended = true;
                //}
                //if (_App._app_job_IsAwareFundamentalStd != ddl_job_IsAwareFundamentalStd.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsAwareFundamentalStd), DBL.GetYesNo(ddl_job_IsAwareFundamentalStd.SelectedValue), "app_job_IsAwareFundamentalStd"); isAmended = true;
                //}
                //if (_App._app_job_IsResponsibleCQCPIR != ddl_job_IsResponsibleCQCPIR.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleCQCPIR), DBL.GetYesNo(ddl_job_IsResponsibleCQCPIR.SelectedValue), "app_job_IsResponsibleCQCPIR"); isAmended = true;
                //}
                if (_App._app_job_IsResponsibleRecruitment != ddl_job_IsResponsibleRecruitment.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleRecruitment), DBL.GetYesNo(ddl_job_IsResponsibleRecruitment.SelectedValue), "app_job_IsResponsibleRecruitment"); isAmended = true;
                }
                if (_App._app_job_IsResponsibleStaffInduction != ddl_job_IsResponsibleStaffInduction.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleStaffInduction), DBL.GetYesNo(ddl_job_IsResponsibleStaffInduction.SelectedValue), "app_job_IsResponsibleStaffInduction"); isAmended = true;
                }
                if (_App._app_job_IsResponsibleStaffAppraisal != ddl_job_IsResponsibleStaffraisal.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleStaffAppraisal), DBL.GetYesNo(ddl_job_IsResponsibleStaffraisal.SelectedValue), "app_job_IsResponsibleStaffAppraisal"); isAmended = true;
                }
                if (_App._app_job_IsResponsibleMonitoringStaff != ddl_job_IsResponsibleMonitoringStaff.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleMonitoringStaff), DBL.GetYesNo(ddl_job_IsResponsibleMonitoringStaff.SelectedValue), "app_job_IsResponsibleMonitoringStaff"); isAmended = true;
                }
                //if (_App._app_job_IsResponsiblePlanningReviewing != ddl_job_IsResponsiblePlanningReviewing.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsiblePlanningReviewing), DBL.GetYesNo(ddl_job_IsResponsiblePlanningReviewing.SelectedValue), "app_job_IsResponsiblePlanningReviewing"); isAmended = true;
                //}
                //if (_App._app_job_IsResponsibleEffectivenessPartnerships != ddl_job_IsResponsibleEffectivenessPartnerships.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleEffectivenessPartnerships), DBL.GetYesNo(ddl_job_IsResponsibleEffectivenessPartnerships.SelectedValue), "app_job_IsResponsibleEffectivenessPartnerships"); isAmended = true;
                //}
                if (_App._app_job_IsReviewAuditPolicies != ddl_job_IsReviewAuditPolicies.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsReviewAuditPolicies), DBL.GetYesNo(ddl_job_IsReviewAuditPolicies.SelectedValue), "app_job_IsReviewAuditPolicies"); isAmended = true;
                }
                //if (_App._app_job_IsRespondingToComplaints != ddl_job_IsRespondingToComplaints.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsRespondingToComplaints), DBL.GetYesNo(ddl_job_IsRespondingToComplaints.SelectedValue), "app_job_IsRespondingToComplaints"); isAmended = true;
                //}
                if (_App._app_job_IsInvestigatingSafeguarding != ddl_job_IsInvestigatingSafeguarding.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsInvestigatingSafeguarding), DBL.GetYesNo(ddl_job_IsInvestigatingSafeguarding.SelectedValue), "app_job_IsInvestigatingSafeguarding"); isAmended = true;
                }
                if (_App._app_job_IsOrganisingLeadStaffMeetings != ddl_job_IsOrganisingLeadStaffMeetings.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsOrganisingLeadStaffMeetings), DBL.GetYesNo(ddl_job_IsOrganisingLeadStaffMeetings.SelectedValue), "app_job_IsOrganisingLeadStaffMeetings"); isAmended = true;
                }
                if (_App._app_job_IsEnsuringComplianceHS != ddl_job_IsEnsuringComplianceHS.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsEnsuringComplianceHS), DBL.GetYesNo(ddl_job_IsEnsuringComplianceHS.SelectedValue), "app_job_IsEnsuringComplianceHS"); isAmended = true;
                }
                //if (_App._app_job_IsFurtherTrainingNeeded != ddl_job_IsFurtherTrainingNeeded.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsFurtherTrainingNeeded), DBL.GetYesNo(ddl_job_IsFurtherTrainingNeeded.SelectedValue), "app_job_IsFurtherTrainingNeeded"); isAmended = true;
                //}
                if (_App._app_job_RelevantPathway != ddl_job_RelevantPathway.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetApplicationOptionTitle(getPathwaysLevel(_App._app_officeuse1_CourseLevel), _App._app_job_RelevantPathway), DBL.GetApplicationOptionTitle(getPathwaysLevel(_App._app_officeuse1_CourseLevel), ddl_job_RelevantPathway.SelectedValue), "app_job_RelevantPathway"); isAmended = true;
                }
                 
                if (_App._app_job_HaveJobDescription != ddl_job_HaveJobDescription.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_HaveJobDescription), DBL.GetYesNo(ddl_job_HaveJobDescription.SelectedValue), "app_job_HaveJobDescription"); isAmended = true;
                }
                //if (_App._app_job_HaveJobDescription_doc != Request.Form["uploaded_file_havejobdescription"])
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_educ_IsALLFund), DBL.GetYesNo(ddl_educ_IsALLFund.SelectedValue), "app_educ_IsALLFund"); isAmended = true;
                //}
                //if (_App._app_job_HaveJobDescription_L3 != ddl_job_HaveJobDescription_L3.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_HaveJobDescription_L3), DBL.GetYesNo(ddl_job_HaveJobDescription_L3.SelectedValue), "app_job_HaveJobDescription_L3"); isAmended = true;
                //}

                //if (_App._app_job_IsContributeSelfAssessment != ddl_job_IsContributeSelfAssessment.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsContributeSelfAssessment), DBL.GetYesNo(ddl_job_IsContributeSelfAssessment.SelectedValue), "app_job_IsContributeSelfAssessment"); isAmended = true;
                //}
                if (_App._app_job_IsReviewAuditPolicy != ddl_job_IsReviewAuditPolicy.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsReviewAuditPolicy), DBL.GetYesNo(ddl_job_IsReviewAuditPolicy.SelectedValue), "app_job_IsReviewAuditPolicy"); isAmended = true;
                }
                //if (_App._app_job_IsLeadPartnershipWorking != ddl_job_IsLeadPartnershipWorking.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsLeadPartnershipWorking), DBL.GetYesNo(ddl_job_IsLeadPartnershipWorking.SelectedValue), "app_job_IsLeadPartnershipWorking"); isAmended = true;
                //}
                if (_App._app_job_IsLeadProvisionDelivers != ddl_job_IsLeadProvisionDelivers.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsLeadProvisionDelivers), DBL.GetYesNo(ddl_job_IsLeadProvisionDelivers.SelectedValue), "app_job_IsLeadProvisionDelivers"); isAmended = true;
                }
                //if (_App._app_job_IsResponsibleKeyResources != ddl_job_IsResponsibleKeyResources.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleKeyResources), DBL.GetYesNo(ddl_job_IsResponsibleKeyResources.SelectedValue), "app_job_IsResponsibleKeyResources"); isAmended = true;
                //}
                if (_App._app_job_IsResponsibleStaffTraining != ddl_job_IsResponsibleStaffTraining.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleStaffTraining), DBL.GetYesNo(ddl_job_IsResponsibleStaffTraining.SelectedValue), "app_job_IsResponsibleStaffTraining"); isAmended = true;
                }
                //if (_App._app_job_IsResponsibleManagingQuality != ddl_job_IsResponsibleManagingQuality.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleManagingQuality), DBL.GetYesNo(ddl_job_IsResponsibleManagingQuality.SelectedValue), "app_job_IsResponsibleManagingQuality"); isAmended = true;
                //}
                //if (_App._app_job_IsResponsibleIncludeDevelopment != ddl_job_IsResponsibleIncludeDevelopment.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsResponsibleIncludeDevelopment), DBL.GetYesNo(ddl_job_IsResponsibleIncludeDevelopment.SelectedValue), "app_job_IsResponsibleIncludeDevelopment"); isAmended = true;
                //}


                //if (_App._app_job_ExampleProjectManaged != DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleProjectManaged.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_ExampleProjectManaged, Basic.FormatStringForSQL(txt_job_ExampleProjectManaged.Text.Trim()), "app_job_ExampleProjectManaged"); isAmended = true;
                //}
                //if (_App._app_job_ExampleSupportingCarePractice != DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleSupportingCarePractice.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_ExampleSupportingCarePractice, Basic.FormatStringForSQL(txt_job_ExampleSupportingCarePractice.Text.Trim()), "app_job_ExampleSupportingCarePractice"); isAmended = true;
                //}
                //if (_App._app_job_ExampleCPDRecent != DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleCPDRecent.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_ExampleCPDRecent, Basic.FormatStringForSQL(txt_job_ExampleCPDRecent.Text.Trim()), "app_job_ExampleCPDRecent"); isAmended = true;
                //}
                //if (_App._app_job_ExampleCourageImplement != DSP.BAL.Basic.FormatStringForSQL(txt_job_ExampleCourageImplement.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_ExampleCourageImplement, Basic.FormatStringForSQL(txt_job_ExampleCourageImplement.Text.Trim()), "app_job_ExampleCourageImplement"); isAmended = true;
                //}



                //if (_App._app_job_102_KnowledgeStatutoryFrameworks != ddl_job_102_KnowledgeStatutoryFrameworks.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_102_KnowledgeStatutoryFrameworks), DBL.GetApplicationOptionTitle("LowMediumHigh", ddl_job_102_KnowledgeStatutoryFrameworks.SelectedValue), "app_job_102_KnowledgeStatutoryFrameworks"); isAmended = true;
                //}
                //if (_App._app_job_103_ExperienceOfManaging != ddl_job_103_ExperienceOfManaging.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_103_ExperienceOfManaging), DBL.GetApplicationOptionTitle("LowMediumHigh", ddl_job_103_ExperienceOfManaging.SelectedValue), "app_job_103_ExperienceOfManaging"); isAmended = true;
                //}
                //if (_App._app_job_104_AbilityImplementStrategies != ddl_job_104_AbilityImplementStrategies.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_104_AbilityImplementStrategies), DBL.GetApplicationOptionTitle("LowMediumHigh", ddl_job_104_AbilityImplementStrategies.SelectedValue), "app_job_104_AbilityImplementStrategies"); isAmended = true;
                //}
                //if (_App._app_job_105_ExperienceLeadingSupporting != ddl_job_105_ExperienceLeadingSupporting.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_105_ExperienceLeadingSupporting), DBL.GetApplicationOptionTitle("LowMediumHigh", ddl_job_105_ExperienceLeadingSupporting.SelectedValue), "app_job_105_ExperienceLeadingSupporting"); isAmended = true;
                //}
                //if (_App._app_job_106_CarriedOutActivitiesMonitor != ddl_job_106_CarriedOutActivitiesMonitor.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_106_CarriedOutActivitiesMonitor), DBL.GetApplicationOptionTitle("LowMediumHigh", ddl_job_106_CarriedOutActivitiesMonitor.SelectedValue), "app_job_106_CarriedOutActivitiesMonitor"); isAmended = true;
                //}
                  
                //if (_App._app_job_HaveJobDescription_L3_doc != Request.Form["uploaded_file_havejobdescription_l3"])
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_educ_IsALLFund), DBL.GetYesNo(ddl_educ_IsALLFund.SelectedValue), "app_educ_IsALLFund"); isAmended = true;
                //}
                //if (_App._app_job_DailyMainDuties != DSP.BAL.Basic.FormatStringForSQL(txt_job_DailyMainDuties.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_DailyMainDuties, Basic.FormatStringForSQL(txt_job_DailyMainDuties.Text.Trim()), "app_job_DailyMainDuties"); isAmended = true;
                //}

                //if (_App._app_job_OtherPositionResponsabilities != DSP.BAL.Basic.FormatStringForSQL(txt_job_OtherPositionResponsabilities.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_OtherPositionResponsabilities, Basic.FormatStringForSQL(txt_job_OtherPositionResponsabilities.Text.Trim()), "app_job_OtherPositionResponsabilities"); isAmended = true;
                //}
                //if (_App._app_job_AboutYourStrenghts != DSP.BAL.Basic.FormatStringForSQL(txt_job_AboutYourStrenghts.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_AboutYourStrenghts, Basic.FormatStringForSQL(txt_job_AboutYourStrenghts.Text.Trim()), "app_job_AboutYourStrenghts"); isAmended = true;
                //}
                //if (_App._app_job_AreasOfDevelopment != DSP.BAL.Basic.FormatStringForSQL(txt_job_AreasOfDevelopment.Text.Trim()))
                //{
                //    SetValueOfChanges(_App._app_job_AreasOfDevelopment, Basic.FormatStringForSQL(txt_job_AreasOfDevelopment.Text.Trim()), "app_job_AreasOfDevelopment"); isAmended = true;
                //}
                if (_App._app_job_AllowWorkplaceObsVisit != ddl_job_AllowWorkplaceObsVisit.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_AllowWorkplaceObsVisit), DBL.GetYesNo(ddl_job_AllowWorkplaceObsVisit.SelectedValue), "app_job_AllowWorkplaceObsVisit"); isAmended = true;
                }

                if (_App._app_job_AssessReviewSupportPlans != ddl_job_AssessReviewSupportPlans.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_AssessReviewSupportPlans), DBL.GetYesNo(ddl_job_AssessReviewSupportPlans.SelectedValue), "app_job_AssessReviewSupportPlans"); isAmended = true;
                }

                //if (_App._app_job_IsInvolvedInRiskAssessments != ddl_job_IsInvolvedInRiskassessments.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsInvolvedInRiskAssessments), DBL.GetYesNo(ddl_job_IsInvolvedInRiskassessments.SelectedValue), "app_job_IsInvolvedInRiskAssessments"); isAmended = true;
                //}

                if (_App._app_job_ContributeToMentalHealth != ddl_job_ContributeToMentalHealth.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_ContributeToMentalHealth), DBL.GetYesNo(ddl_job_ContributeToMentalHealth.SelectedValue), "app_job_ContributeToMentalHealth"); isAmended = true;
                }

                if (_App._app_job_SupportIndvDepressionPhobias != ddl_job_SupportIndvDepresionPhobias.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_SupportIndvDepressionPhobias), DBL.GetYesNo(ddl_job_SupportIndvDepresionPhobias.SelectedValue), "app_job_SupportIndvDepressionPhobias"); isAmended = true;
                }

                if (_App._app_job_WorkinPartnershipswthProfessionals != ddl_job_WorkinPartnershipswthProfesionals.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_WorkinPartnershipswthProfessionals), DBL.GetYesNo(ddl_job_WorkinPartnershipswthProfesionals.SelectedValue), "app_job_WorkinPartnershipswthProfessionals"); isAmended = true;
                }

                if (_App._app_job_SafeguardReports != ddl_job_SafeguardReports.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_SafeguardReports), DBL.GetYesNo(ddl_job_SafeguardReports.SelectedValue), "app_job_SafeguardReports"); isAmended = true;
                }

                if (_App._app_job_RecruitmentResponsibilities != ddl_job_RecruitmentResponsibilities.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_RecruitmentResponsibilities), DBL.GetYesNo(ddl_job_RecruitmentResponsibilities.SelectedValue), "app_job_RecruitmentResponsibilities"); isAmended = true;
                }

                //if (_App._app_job_StaffInductionCareCertificate != ddl_job_StaffInductionCareCertificate.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_StaffInductionCareCertificate), DBL.GetYesNo(ddl_job_StaffInductionCareCertificate.SelectedValue), "app_job_StaffInductionCareCertificate"); isAmended = true;
                //}

                if (_App._app_job_RespondCompliments != ddl_job_RespondCompliments.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_RespondCompliments), DBL.GetYesNo(ddl_job_RespondCompliments.SelectedValue), "app_job_RespondCompliments"); isAmended = true;
                }

                if (_App._app_job_WorkMgtRole != ddl_job_WorkMgtRole.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_WorkMgtRole), DBL.GetYesNo(ddl_job_WorkMgtRole.SelectedValue), "app_job_WorkMgtRole"); isAmended = true;
                }

                if (_App._app_job_TakePartSupervisions != ddl_job_TakePartSupervisions.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_TakePartSupervisions), DBL.GetYesNo(ddl_job_TakePartSupervisions.SelectedValue), "app_job_TakePartSupervisions"); isAmended = true;
                }

                if (_App._app_job_TakePartMeetings != ddl_job_TakePartMeetings.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_TakePartMeetings), DBL.GetYesNo(ddl_job_TakePartMeetings.SelectedValue), "app_job_TakePartMeetings"); isAmended = true;
                }

                if (_App._app_job_MaintainPersonalRecord != ddl_job_MaintainPersonalRecord.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_MaintainPersonalRecord), DBL.GetYesNo(ddl_job_MaintainPersonalRecord.SelectedValue), "app_job_MaintainPersonalRecord"); isAmended = true;
                }

                if (_App._app_job_RiskAssessOthersComply != ddl_job_RiskAssessOthersComply.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_RiskAssessOthersComply), DBL.GetYesNo(ddl_job_RiskAssessOthersComply.SelectedValue), "app_job_RiskAssessOthersComply"); isAmended = true;
                }

                if (_App._app_job_SafeguardInvestigations != ddl_job_SafeguardInvestigations.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_SafeguardInvestigations), DBL.GetYesNo(ddl_job_SafeguardInvestigations.SelectedValue), "app_job_SafeguardInvestigations"); isAmended = true;
                }

                if (_App._app_job_WorkSupportiveRole != ddl_job_WorkSupportiveRole.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_WorkMgtRole), DBL.GetYesNo(ddl_job_WorkSupportiveRole.SelectedValue), "app_job_WorkSupportiveRole"); isAmended = true;
                }

                if (_App._app_job_ReviewSupportPlans != ddl_job_ReviewSupportPlans.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_ReviewSupportPlans), DBL.GetYesNo(ddl_job_ReviewSupportPlans.SelectedValue), "app_job_ReviewSupportPlans"); isAmended = true;
                }

                if (_App._app_job_WorkPartnerProfessionals != ddl_job_WorkPartnerProfessionals.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_WorkPartnerProfessionals), DBL.GetYesNo(ddl_job_WorkPartnerProfessionals.SelectedValue), "app_job_WorkPartnerProfessionals"); isAmended = true;
                }

                if (_App._app_job_CVPResilience != ddl_job_CVPResilience.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_CVPResilience), DBL.GetYesNo(ddl_job_CVPResilience.SelectedValue), "app_job_CVPResilience"); isAmended = true;
                }

                if (_App._app_job_TechCommunication != ddl_job_TechCommunication.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_TechCommunication), DBL.GetYesNo(ddl_job_TechCommunication.SelectedValue), "app_job_TechCommunication"); isAmended = true;
                }

                //if (_App._app_job_RegularSupervisions != ddl_job_RegularSupervisions.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_RegularSupervisions), DBL.GetYesNo(ddl_job_RegularSupervisions.SelectedValue), "app_job_RegularSupervisions"); isAmended = true;
                //}

                if (_App._app_job_CarryoutRiskAssessment != ddl_job_CarryoutRiskAssessment.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_CarryoutRiskAssessment), DBL.GetYesNo(ddl_job_CarryoutRiskAssessment.SelectedValue), "app_job_CarryoutRiskAssessment"); isAmended = true;
                }

                if (_App._app_job_SupportCYP != ddl_job_SupportCYP.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_SupportCYP), DBL.GetYesNo(ddl_job_SupportCYP.SelectedValue), "app_job_SupportCYP"); isAmended = true;
                }

                if (_App._app_job_PositiveRiskTaking != ddl_job_PositiveRiskTaking.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_PositiveRiskTaking), DBL.GetYesNo(ddl_job_PositiveRiskTaking.SelectedValue), "app_job_PositiveRiskTaking"); isAmended = true;
                }

                if (_App._app_job_KeyWorker != ddl_job_KeyWorker.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_KeyWorker), DBL.GetYesNo(ddl_job_KeyWorker.SelectedValue), "app_job_KeyWorker"); isAmended = true;
                }

                if (_App._app_job_PlanImplementcare != ddl_job_PlanImplementcare.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_PlanImplementcare), DBL.GetYesNo(ddl_job_PlanImplementcare.SelectedValue), "app_job_PlanImplementcare"); isAmended = true;
                }

                if (_App._app_job_WriteRecordReports != ddl_job_WriteRecordReports.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_WriteRecordReports), DBL.GetYesNo(ddl_job_WriteRecordReports.SelectedValue), "app_job_WriteRecordReports"); isAmended = true;
                }

                if (_App._app_job_SocialActivitieswithServiceUser != ddl_job_SocialActivitieswithServiceUser.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_SocialActivitieswithServiceUser), DBL.GetYesNo(ddl_job_SocialActivitieswithServiceUser.SelectedValue), "app_job_SocialActivitieswithServiceUser"); isAmended = true;
                }

                if (_App._app_job_LeadCommunicationProcesses != ddl_job_LeadCommunicationProcesses.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_LeadCommunicationProcesses), DBL.GetYesNo(ddl_job_LeadCommunicationProcesses.SelectedValue), "app_job_LeadCommunicationProcesses"); isAmended = true;
                }

                if (_App._app_job_OrgProvidesResidentialServices != ddl_job_OrgProvidesResidentialServices.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_OrgProvidesResidentialServices), DBL.GetYesNo(ddl_job_OrgProvidesResidentialServices.SelectedValue), "app_job_OrgProvidesResidentialServices"); isAmended = true;
                }

                if (_App._app_job_TherapySessions != ddl_job_TherapySessions.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_TherapySessions), DBL.GetYesNo(ddl_job_TherapySessions.SelectedValue), "app_job_TherapySessions"); isAmended = true;
                }

                if (_App._app_job_HealthPromotion != ddl_job_HealthPromotion.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_HealthPromotion), DBL.GetYesNo(ddl_job_HealthPromotion.SelectedValue), "app_job_HealthPromotion"); isAmended = true;
                }

                if (_App._app_job_Advocate != ddl_job_Advocate.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_Advocate), DBL.GetYesNo(ddl_job_Advocate.SelectedValue), "app_job_Advocate"); isAmended = true;
                }

                if (_App._app_job_SupportServiceUsers != ddl_job_SupportServiceUsers.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_SupportServiceUsers), DBL.GetYesNo(ddl_job_SupportServiceUsers.SelectedValue), "app_job_SupportServiceUsers"); isAmended = true;
                }

                if (_App._app_job_PersonalCareAssistingMoving != ddl_job_PersonalCareAssistingMoving.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_PersonalCareAssistingMoving), DBL.GetYesNo(ddl_job_PersonalCareAssistingMoving.SelectedValue), "app_job_PersonalCareAssistingMoving"); isAmended = true;

                }


                if (_App._app_job_70 != ddl_App_job_70.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_70), DBL.GetYesNo(ddl_App_job_70.SelectedValue), "app_job_70"); isAmended = true;
                }
                if (_App._app_job_AssistEatingDrinking != ddl_job_AssistEatingDrinking.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_AssistEatingDrinking), DBL.GetYesNo(ddl_job_AssistEatingDrinking.SelectedValue), "app_job_AssistEatingDrinking"); isAmended = true;
                }
                if (_App._app_job_71 != ddl_App_job_71.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_71), DBL.GetYesNo(ddl_App_job_71.SelectedValue), "app_job_71"); isAmended = true;
                }
                //if (_App._app_job_72 != ddl_App_job_72.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_72), DBL.GetYesNo(ddl_App_job_72.SelectedValue), "app_job_72"); isAmended = true;
                //}
                
                /*        //level 2
                    DSP.BAL.Basic.convertAndCheckNullAndSetDopDownBox(ddl_App_job_70, _App._app_job_70);
                    _App._app_job_70 = ddl_App_job_70.SelectedValue;
             */




                if (_App._app_job_Confirm16hrs != chk_job_Confirm16hrs.Checked)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_Confirm16hrs == true ? "1" : "0"), DBL.GetYesNo(chk_job_Confirm16hrs.Checked == true ? "1" : "0"), "app_job_Confirm16hrs"); isAmended = true;
                }
                //if (_App._app_job_Confirm16hrsId != int.Parse(ddl_job_Confirm16hrsId.SelectedValue))
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_educ_IsALLFund), DBL.GetYesNo(ddl_educ_IsALLFund.SelectedValue), "app_educ_IsALLFund"); isAmended = true;
                //}
                if (_App._app_job_Confirm16hrsTitle != ddl_job_Confirm16hrsId.SelectedItem.Text)
                {
                    SetValueOfChanges(_App._app_job_Confirm16hrsTitle, Basic.FormatStringForSQL(ddl_job_Confirm16hrsId.SelectedItem.Text.Trim()), "app_job_Confirm16hrsTitle"); isAmended = true;
                }
                //if (_App._app_job_IsAssessReviewImplementCare != ddl_job_IsAssessReviewImplementCare.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsAssessReviewImplementCare), DBL.GetYesNo(ddl_job_IsAssessReviewImplementCare.SelectedValue), "app_job_IsAssessReviewImplementCare"); isAmended = true;
                //}
                //if (_App._app_job_IsInvolvedRiskAssessment != ddl_job_IsInvolvedRiskAssessment.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsInvolvedRiskAssessment), DBL.GetYesNo(ddl_job_IsInvolvedRiskAssessment.SelectedValue), "app_job_IsInvolvedRiskAssessment"); isAmended = true;
                //}
                if (_App._app_job_IsEnsureOthersFollowPolicy != ddl_job_IsEnsureOthersFollowPolicy.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsEnsureOthersFollowPolicy), DBL.GetYesNo(ddl_job_IsEnsureOthersFollowPolicy.SelectedValue), "app_job_IsEnsureOthersFollowPolicy"); isAmended = true;
                }
                //if (_App._app_job_IsSupportServiceInPersonalCare != ddl_job_IsSupportServiceInPersonalCare.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsSupportServiceInPersonalCare), DBL.GetYesNo(ddl_job_IsSupportServiceInPersonalCare.SelectedValue), "app_job_IsSupportServiceInPersonalCare"); isAmended = true;
                //}
                //if (_App._app_job_IsWorkSupportRoleServiceUsers != ddl_job_IsWorkSupportRoleServiceUsers.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsWorkSupportRoleServiceUsers), DBL.GetYesNo(ddl_job_IsWorkSupportRoleServiceUsers.SelectedValue), "_app_job_IsWorkSupportRoleServiceUsers"); isAmended = true;
                //}
                //if (_App._app_job_IsPlanReviewImplmentCare != ddl_job_IsPlanReviewImplmentCare.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsPlanReviewImplmentCare), DBL.GetYesNo(ddl_job_IsPlanReviewImplmentCare.SelectedValue), "app_job_IsPlanReviewImplmentCare"); isAmended = true;
                //}
                //if (_App._app_job_IsInvolvedSafeguardingInvestigations != ddl_job_IsInvolvedSafeguardingInvestigations.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsInvolvedSafeguardingInvestigations), DBL.GetYesNo(ddl_job_IsInvolvedSafeguardingInvestigations.SelectedValue), "app_job_IsInvolvedSafeguardingInvestigations"); isAmended = true;
                //}
                //if (_App._app_job_IsTakePartInRiskAssessment != ddl_job_IsTakePartInRiskAssessment.SelectedValue)
                //{
                //    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsTakePartInRiskAssessment), DBL.GetYesNo(ddl_job_IsTakePartInRiskAssessment.SelectedValue), "app_job_IsTakePartInRiskAssessment"); isAmended = true;
                //}
                if (_App._app_job_IsTakePartInManagingQuality != ddl_job_IsTakePartInManagingQuality.SelectedValue)
                {
                    SetValueOfChanges(DBL.GetYesNo(_App._app_job_IsTakePartInManagingQuality), DBL.GetYesNo(ddl_job_IsTakePartInManagingQuality.SelectedValue), "app_job_IsTakePartInManagingQuality"); isAmended = true;
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

                return _App.SaveChangesToApplicationsTrackChanges(applicationsTrackChangesList, appId, userId, isAmended);
            default:
                return false;

        }
    }


    private void setPathwaysLevel(int iCourseLevel)
    {
        string val = "pathways";
        switch (iCourseLevel)
        {
            case 20://"Level 2"
                val = "PathwaysLevel2";
                break;
            case 30: //"Level 3 CYP"
                val = "PathwaysCYP";
                break;

            case 31:// "Level 3 Adult"
                val = "Pathways";
                break;

            case 32://"Level 3 Mental Health"
                val = "Pathways";
                break;

            case 40:// "Level 4 Adult"
                val = "Pathways";
                break;

            case 50:// "Level 5 CYP"
                val = "PathwaysCYP";
                break;

            case 51://"Level 5 Adult"
                val = "Pathways";
                break;

            case 52://"Level 5 Apprenticeship":
                val = "Pathways";
                break;
            case 80://"Short Course":
                val = "";
                break;

            default:
                val = "Pathways";
                break;

        }

        lblPathwaysLevel.Text = val; 
    }
    private string getPathwaysLevel(int iCourseLevel)
    {
        string val = "pathways";
        switch (iCourseLevel)
        {
            case 20://"Level 2"
                val = "PathwaysLevel2";
                break;
            case 30: //"Level 3 CYP"
                val = "PathwaysCYP";
                break;

            case 31:// "Level 3 Adult"
                val = "Pathways";
                break;

            case 32://"Level 3 Mental Health"
                val = "Pathways";
                break;

            case 40:// "Level 4 Adult"
                val = "Pathways";
                break;

            case 50:// "Level 5 CYP"
                val = "PathwaysCYP";
                break;

            case 51://"Level 5 Adult"
                val = "Pathways";
                break;

            case 52://"Level 5 Apprenticeship":
                val = "Pathways";
                break;
            case 80://"Short Course":
                val = "";
                break;

            default:
                val = "Pathways";
                break;

        }

        return val;
    }
}
