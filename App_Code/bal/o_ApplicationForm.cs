using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Web.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Web.Services;

namespace DSP.BAL
{

    public class ApplicationForm
    {

        public int _app_id;
        public bool isNewApplication = false;
        public bool isCompletedApplication = false;

        public string _app_Title;
        public string _app_FirstName;
        public string _app_Surname;
        public string _app_Gender;
        public string _app_DOB;
        public string _app_NI;
        public string _app_PermAddress1;
        public string _app_PermAddress2;
        public string _app_PermAddress3;
        public string _app_PermAddress4;
        public string _app_PermAddress5;
        public string _app_PermPostCode;
        public string _app_Email;
        public string _app_HomeTel;
        public string _app_Mobile;
        public string _app_Nationality;
        public string _app_LegalResidency;
        public string _app_LegalResidency_doc;
        public string _app_IsLivedEULast3Years;
        public string _app_LivedEntryDate;
        public string _app_NonEUUKHowLongLiveInUK;

        public string _app_Ethnicity;
        public string _app_Religion;
        //public string _app_SexualOrientation;
        public string _app_LengthOfAddress;
        public string _app_PrePlannedAbsence;
        public string _app_Circumstance;

        public string _app_AnyDisability;
        public string _app_AnyDisabilityPrimary;
        public string _app_AnyDisabilitySecondaries;

        public string _app_NeedLearningSupport;
        public string _app_HaveLearnerSupportProgram;
        public string _app_ProgramAppliedFor;
        public string _app_IsAccessToComputer;
        public string _app_IsAccessToFaceTime;
        public string _app_IsAccessToEmail;
        public string _app_IsEPortoflioAware;
        public string _app_IsPartnerOfOwner;
        public string _app_ManageWorkStudy;
        public string _app_educ_HighestQual;
        public string _app_educ_IsGCSEEnglish;
        public string _app_educ_IsGCSEMath;
        public string _app_educ_EquivalentQualification;

        public string _app_educ_IsEnrolledOther;
        public string _app_educ_PreviousCollege;
        public string _app_educ_PreviousQual;
        public string _app_educ_PreviousTraining;
        public string _app_educ_IsALLFund;
        public string _app_educ_ALLFundQualDetails;
        // public string _app_educ_TrainingPlannedNext12Months;
        //public string _app_educ_FutureInspirations;
        public string _app_emp_CompanyName;
        public string _app_emp_EmpoyementStartDate;

        public string _app_emp_WorkPlaceAddress;
        public string _app_emp_WorkPlaceAddress1;
        public string _app_emp_WorkPlaceAddress2;
        public string _app_emp_WorkPlaceAddress3;
        public string _app_emp_WorkPlaceAddress4;
        public string _app_emp_WorkPlaceAddress5;
        public string _app_emp_WorkPlacePostCode;
        public string _app_emp_Email;
        public string _app_emp_Tel;
        public string _app_emp_ContactName;
        public string _app_emp_Position;
        public string _app_emp_BusinessSector;
        public string _app_emp_CompanyEstablished;
        public string _app_emp_WeeklyHours;
        public string _app_emp_IsSelfEmployed;
        //public string _app_emp_IsEmployerPaying;
        public string _app_job_JobFunction;
        public string _app_job_HowLongWorkingJob;
        public string _app_job_HowLongWorkingEmployer;
        public string _app_job_AnyPreviousManagement;
        public string _app_job_HaveCurrentDevPlan;
        public string _app_job_IsAwareFundamentalStd;
        //  public string _app_job_IsResponsibleCQCPIR;
        public string _app_job_IsResponsibleRecruitment;
        public string _app_job_IsResponsibleStaffInduction;
        public string _app_job_IsResponsibleStaffAppraisal;
        public string _app_job_IsResponsibleMonitoringStaff;
        // public string _app_job_IsResponsibleTaskAllocationRotas;
        public string _app_job_IsResponsiblePlanningReviewing;
        //  public string _app_job_IsResponsibleOrganisingReferrals;
        public string _app_job_IsResponsibleOrganisingPartnerships;
        public string _app_job_IsResponsibleEffectivenessPartnerships;
        public string _app_job_IsReviewAuditPolicies;
        public string _app_job_IsRespondingToComplaints;
        public string _app_job_IsInvestigatingSafeguarding;
        public string _app_job_IsAuditFeedback;
        public string _app_job_IsOrganisingLeadStaffMeetings;

        //public string _app_job_IsResponsibleWritingDevPlan;
        //public string _app_job_HaveRegularStaffMeetings;
        public string _app_job_IsAttendingStrategicMeetings;
        public string _app_job_IsEnsuringComplianceHS;
        public string _app_job_IsFurtherTrainingNeeded;
        //public string _app_job_IsSpecificSupportNeeded;
        public string _app_job_RelevantPathway;
        public string _app_job_HaveJobDescription;
        public string _app_job_HaveJobDescription_doc;

        //public string _app_job_CarryOutAuditing;

        public string _app_job_DailyMainDuties;
        //public string _app_job_UsualHoursAttendancy;
        public string _app_job_OtherPositionResponsabilities;
        public string _app_job_AboutYourStrenghts;
        public string _app_job_AreasOfDevelopment;
        public string _app_job_AllowWorkplaceObsVisit;
        public bool _app_job_Confirm16hrs = false;
        public int _app_job_Confirm16hrsId = 0;
        public string _app_job_Confirm16hrsTitle = "";

        public string _app_job_HaveStartedGLH;

        public string _app_officeuse_UniqueLearnerReference;
        public string _app_officeuse_StartDate;
        public string _app_officeuse_EndDate;
        public string _app_officeuse_ApprenticeshipFramework;
        public string _app_officeuse_LearnerId;
        public string _app_officeuse_ReferenceId;
        public string _app_officeuse_CQCInspectionDate;
        public string _app_officeuse_UKPRN;
        public string _app_officeuse_EmployerId;

        public string _app_officeuse_ReferenceDate;
        public int _app_officeuse_FundingId = 0;
        public string _app_officeuse_FundingTitle = "";
        public bool _app_officeuse_IsEvidenceSeen = false;
        public string _app_officeuse_ReferenceIdType = "";

        public bool _app_officeuse1_IsLiteracyNumeracyDone = false;
        public bool _app_officeuse1_IsAllDocumentsSigned = false;
        public bool _app_officeuse1_IsConfirmEnrolment = false;
        public int _app_officeuse1_CourseId = 5;
        public string _app_officeuse1_CourseTitle = "";
        public int _app_officeuse1_CourseLevel = 50;

        public string _app_job_IsAssessReviewImplementCare;
        public string _app_job_IsInvolvedRiskAssessment;
        public string _app_job_IsEnsureOthersFollowPolicy;
        public string _app_job_IsSupportServiceInPersonalCare;
        public string _app_job_IsWorkSupportRoleServiceUsers;
        public string _app_job_IsPlanReviewImplmentCare;
        public string _app_job_IsInvolvedSafeguardingInvestigations;
        public string _app_job_IsTakePartInRiskAssessment;
        public string _app_job_IsTakePartInManagingQuality;

        public string _app_job_RelevantPathway_L3;
        public string _app_job_HaveJobDescription_L3;
        public string _app_job_HaveJobDescription_L3_doc;

        public string _app_mktg_HearAbout;
        public string _app_mktg_ContactConsent;
        public string _app_mktg_ByPhone;
        public string _app_mktg_ByEmail;
        public string _app_mktg_ByPost;
        public string _app_PrintName;
        public string _app_ApplicationDate;
        public int _app_AdvisorUserId;
        public bool _app_IsAmended = false;

        public string _app_Saved_Password;
        public string _app_ACS_WDSNumber;

        public string _app_job_IsContributeSelfAssessment;
        public string _app_job_IsReviewAuditPolicy;
        public string _app_job_IsLeadPartnershipWorking;
        public string _app_job_IsLeadProvisionDelivers;
        public string _app_job_IsResponsibleKeyResources;
        public string _app_job_IsResponsibleStaffTraining;
        public string _app_job_ExampleProjectManaged;
        public string _app_job_ExampleSupportingCarePractice;
        public string _app_job_ExampleCPDRecent;
        public string _app_job_ExampleCourageImplement;
        public string _app_job_IsResponsibleManagingQuality;
        public string _app_job_IsResponsibleIncludeDevelopment;

        public string _app_job_102_KnowledgeStatutoryFrameworks;
        public string _app_job_103_ExperienceOfManaging;
        public string _app_job_104_AbilityImplementStrategies;
        public string _app_job_105_ExperienceLeadingSupporting;
        public string _app_job_106_CarriedOutActivitiesMonitor;
        public string _app_EUEEAStatus;
        public string _app_job_TherapySessions;
        public string _app_job_HealthPromotion;
        public string _app_job_Advocate;
        public string _app_job_SupportServiceUsers;
        public string _app_EUEEANational;
        public string _app_job_AssessReviewSupportPlans;
        public string _app_job_IsInvolvedInRiskAssessments;
        public string _app_job_ContributeToMentalHealth;
        public string _app_job_SupportIndvDepressionPhobias;
        public string _app_job_WorkinPartnershipswthProfessionals;
        public string _app_job_SafeguardReports;

        public string _app_job_RecruitmentResponsibilities;
        public string _app_job_StaffInductionCareCertificate;
        public string _app_job_RespondCompliments;
        public string _app_job_WorkMgtRole;

        public string _app_job_TakePartSupervisions;
        public string _app_job_TakePartMeetings;
        public string _app_job_MaintainPersonalRecord;
        public string _app_job_RiskAssessOthersComply;
        public string _app_job_SafeguardInvestigations;
        public string _app_job_WorkSupportiveRole;
        public string _app_job_ReviewSupportPlans;
        public string _app_job_WorkPartnerProfessionals;
        public string _app_job_CVPResilience;
        public string _app_job_TechCommunication;
        public string _app_job_RegularSupervisions;
        public string _app_job_CarryoutRiskAssessment;
        public string _app_job_SupportCYP;
        public string _app_job_PositiveRiskTaking;

        public string _app_job_KeyWorker;
        public string _app_job_PlanImplementcare;
        public string _app_job_WriteRecordReports;
        public string _app_job_SocialActivitieswithServiceUser;
        public string _app_job_LeadCommunicationProcesses;
        public string _app_job_OrgProvidesResidentialServices;
        public string _app_job_PersonalCareAssistingMoving;
        public string _app_job_AssistEatingDrinking;

        public string _app_job_70;
        public string _app_job_71;
        public string _app_job_72;
        public string _app_job_73;


        // rahmat new add for ESF
  
        public string _app_Org_Skill;
        public string _app_Org_Cqc;
        public string _app_Org_Reg_Cqc;
        public string _app_Org_Employee;
        public string _app_Org_PId;
        public string _app_Org_Reg_Local_Authority;


        public string _app_Esf_Q_Million_Balance;
        public string _app_Esf_Q_Manager_Register;
        public string _app_Esf_Q_Basic_English;
        public string _app_Esf_Q_Basic_Math;
        public string _app_Esf_Q_Level_2_English;
        public string _app_Esf_Q_Level_2_Math;
        public string _app_Esf_Q_High_Qualification;
        public string _app_Esf_Q_Type_Service_Provider;
        public string _app_Esf_Q_Unique_Number;
        public string _app_Esf_Q_Refugee;
        public string _app_Esf_Q_Granted_Leave;
        public string _app_Esf_Q_Single_Adult;

        public string _app_Esf_Q_Access_Skill_Hold;
        public string _app_Esf_Q_European_Social;
        public string _app_Esf_Q_Employee_Million;
        public string _app_Esf_Q_Behalf;
        public string _app_Esf_Q_Assessment;
        public string _app_Esf_Q_Access_Skill;
        public string _app_Esf_Q_Info_Supplied;
        public string _app_Esf_Q_Legally_Uk;

        public ApplicationForm()
        {

        }
        public ApplicationForm(bool bNew = false)
        {
            if (bNew)
            {

                isNewApplication = true;
                isCompletedApplication = false;
                _app_Title = "";
                _app_FirstName = "";
                _app_Surname = "";
                _app_Gender = "";
                _app_DOB = "";
                _app_NI = "";
                _app_PermAddress1 = "";
                _app_PermAddress2 = "";
                _app_PermAddress3 = "";
                _app_PermAddress4 = "";
                _app_PermAddress5 = "";
                _app_PermPostCode = "";
                _app_Email = "";
                _app_HomeTel = "";
                _app_Mobile = "";
                _app_Nationality = "";
                _app_LegalResidency = "";
                _app_LegalResidency_doc = "";
                _app_IsLivedEULast3Years = "";
                _app_LivedEntryDate = "";
                _app_NonEUUKHowLongLiveInUK = "";
                _app_EUEEAStatus = "";
                _app_Ethnicity = "";
                _app_Religion = "";
                //_app_SexualOrientation = "";
                _app_LengthOfAddress = "";
                _app_PrePlannedAbsence = "";
                _app_Circumstance = "";

                _app_AnyDisability = "";
                _app_AnyDisabilityPrimary = "";
                _app_AnyDisabilitySecondaries = "";
                _app_NeedLearningSupport = "";
                _app_HaveLearnerSupportProgram = "";
                _app_ProgramAppliedFor = "";
                _app_IsAccessToComputer = "";
                _app_IsAccessToFaceTime = "";
                _app_IsAccessToEmail = "";
                _app_IsPartnerOfOwner = "";
                _app_IsEPortoflioAware = "";
                // _app_ManageWorkStudy = "";
                _app_educ_HighestQual = "";
                _app_educ_IsGCSEEnglish = "";
                _app_educ_IsGCSEMath = "";
                _app_educ_EquivalentQualification = "";

                _app_educ_IsEnrolledOther = "";
                _app_educ_PreviousCollege = "";
                _app_educ_PreviousQual = "";
                _app_educ_PreviousTraining = "";
                _app_educ_IsALLFund = "";
                _app_educ_ALLFundQualDetails = "";
                //_app_educ_TrainingPlannedNext12Months = "";
                //_app_educ_FutureInspirations = "";
                _app_emp_CompanyName = "";
                _app_emp_EmpoyementStartDate = "";

                _app_emp_WorkPlaceAddress = "";
                _app_emp_WorkPlaceAddress1 = "";
                _app_emp_WorkPlaceAddress2 = "";
                _app_emp_WorkPlaceAddress3 = "";
                _app_emp_WorkPlaceAddress4 = "";
                _app_emp_WorkPlaceAddress5 = "";
                _app_emp_WorkPlacePostCode = "";
                _app_emp_Email = "";
                _app_emp_Tel = "";
                _app_emp_ContactName = "";
                _app_emp_Position = "";
                _app_emp_BusinessSector = "";
                _app_emp_CompanyEstablished = "";
                _app_emp_WeeklyHours = "";
                _app_emp_IsSelfEmployed = "";
                //_app_emp_IsEmployerPaying = "";
                _app_job_JobFunction = "";
                _app_job_HowLongWorkingJob = "";
                _app_job_HowLongWorkingEmployer = "";
                _app_job_AnyPreviousManagement = "";
                _app_job_HaveCurrentDevPlan = "";
                _app_job_IsAwareFundamentalStd = "";
                // _app_job_IsResponsibleCQCPIR = "";
                _app_job_IsResponsibleRecruitment = "";
                _app_job_IsResponsibleStaffInduction = "";
                _app_job_IsResponsibleStaffAppraisal = "";
                _app_job_IsResponsibleMonitoringStaff = "";
                //   _app_job_IsResponsibleTaskAllocationRotas = "";
                _app_job_IsResponsiblePlanningReviewing = "";
                //   _app_job_IsResponsibleOrganisingReferrals = "";
                //   _app_job_IsResponsibleOrganisingPartnerships = "";
                _app_job_IsResponsibleEffectivenessPartnerships = "";
                _app_job_IsReviewAuditPolicies = "";
                _app_job_IsRespondingToComplaints = "";
                _app_job_IsInvestigatingSafeguarding = "";
                _app_job_IsAuditFeedback = "";
                _app_job_IsOrganisingLeadStaffMeetings = "";
                //_app_job_IsResponsibleWritingDevPlan = "";
                //_app_job_HaveRegularStaffMeetings = "";
                _app_job_IsAttendingStrategicMeetings = "";
                _app_job_IsEnsuringComplianceHS = "";
                _app_job_IsFurtherTrainingNeeded = "";
                // _app_job_IsSpecificSupportNeeded = "";
                _app_job_RelevantPathway = "";
                _app_job_HaveJobDescription = "";
                _app_job_HaveJobDescription_doc = "";
                // _app_job_CarryOutAuditing = "";

                _app_job_DailyMainDuties = "";
                //_app_job_UsualHoursAttendancy = "";
                _app_job_OtherPositionResponsabilities = "";
                _app_job_AboutYourStrenghts = "";
                _app_job_AreasOfDevelopment = "";
                _app_job_AllowWorkplaceObsVisit = "";
                _app_job_Confirm16hrs = false;
                _app_job_Confirm16hrsId = 0;
                _app_job_Confirm16hrsTitle = "";

                _app_job_HaveStartedGLH = "";
                _app_officeuse_UniqueLearnerReference = "";
                _app_officeuse_StartDate = "";
                _app_officeuse_EndDate = "";
                _app_officeuse_ApprenticeshipFramework = "";
                _app_officeuse_LearnerId = "";
                _app_officeuse_ReferenceId = "";
                _app_officeuse_CQCInspectionDate = "";
                _app_officeuse_UKPRN = "";
                _app_officeuse_EmployerId = "";
                _app_officeuse_ReferenceDate = "";
                _app_officeuse_FundingId = 0;
                _app_officeuse_FundingTitle = "";
                _app_officeuse_IsEvidenceSeen = false;
                _app_officeuse_ReferenceIdType = "";

                _app_officeuse1_IsLiteracyNumeracyDone = false;
                _app_officeuse1_IsAllDocumentsSigned = false;
                _app_officeuse1_IsConfirmEnrolment = false;

                _app_officeuse1_CourseId = 5;
                _app_officeuse1_CourseTitle = setCourseTitle(_app_officeuse1_CourseId.ToString());
                //save now and save the id


                _app_job_IsAssessReviewImplementCare = "";
                _app_job_IsInvolvedRiskAssessment = "";
                _app_job_IsEnsureOthersFollowPolicy = "";
                _app_job_IsSupportServiceInPersonalCare = "";
                _app_job_IsWorkSupportRoleServiceUsers = "";
                _app_job_IsPlanReviewImplmentCare = "";
                _app_job_IsInvolvedSafeguardingInvestigations = "";
                _app_job_IsTakePartInRiskAssessment = "";
                _app_job_IsTakePartInManagingQuality = "";

                _app_job_RelevantPathway_L3 = "";
                _app_job_HaveJobDescription_L3 = "";
                _app_job_HaveJobDescription_L3_doc = "";
                _app_mktg_HearAbout = "";
                _app_mktg_ContactConsent = "";
                _app_mktg_ByPhone = "";
                _app_mktg_ByEmail = "";
                _app_mktg_ByPost = "";
                _app_PrintName = "";
                _app_ApplicationDate = "";

                _app_Saved_Password = "";
                _app_ACS_WDSNumber = "";

                _app_job_IsContributeSelfAssessment = "";
                _app_job_IsReviewAuditPolicy = "";
                _app_job_IsLeadPartnershipWorking = "";
                _app_job_IsLeadProvisionDelivers = "";
                _app_job_IsResponsibleKeyResources = "";
                _app_job_IsResponsibleStaffTraining = "";
                _app_job_ExampleProjectManaged = "";
                _app_job_ExampleSupportingCarePractice = "";
                _app_job_ExampleCPDRecent = "";
                _app_job_ExampleCourageImplement = "";
                _app_job_IsResponsibleManagingQuality = "";
                _app_job_IsResponsibleIncludeDevelopment = "";

                _app_job_102_KnowledgeStatutoryFrameworks = "";
                _app_job_103_ExperienceOfManaging = "";
                _app_job_104_AbilityImplementStrategies = "";
                _app_job_105_ExperienceLeadingSupporting = "";
                _app_job_106_CarriedOutActivitiesMonitor = "";
                _app_job_TherapySessions = "";
                _app_job_HealthPromotion = "";
                _app_job_Advocate = "";
                _app_job_SupportServiceUsers = "";
                _app_EUEEANational = "";
                _app_job_AssessReviewSupportPlans = "";
                _app_job_IsInvolvedInRiskAssessments = "";
                _app_job_ContributeToMentalHealth = "";
                _app_job_SupportIndvDepressionPhobias = "";
                _app_job_WorkinPartnershipswthProfessionals = "";
                _app_job_SafeguardReports = "";

                _app_job_RecruitmentResponsibilities = "";
                _app_job_StaffInductionCareCertificate = "";
                _app_job_RespondCompliments = "";
                _app_job_WorkMgtRole = "";
                _app_job_TakePartSupervisions = "";
                _app_job_TakePartMeetings = "";
                _app_job_MaintainPersonalRecord = "";
                _app_job_RiskAssessOthersComply = "";
                _app_job_SafeguardInvestigations = "";
                _app_job_WorkSupportiveRole = "";
                _app_job_ReviewSupportPlans = "";
                _app_job_WorkPartnerProfessionals = "";
                _app_job_CVPResilience = "";
                _app_job_TechCommunication = "";
                _app_job_RegularSupervisions = "";
                _app_job_CarryoutRiskAssessment = "";
                _app_job_SupportCYP = "";
                _app_job_PositiveRiskTaking = "";
                _app_job_KeyWorker = "";
                _app_job_PlanImplementcare = "";
                _app_job_WriteRecordReports = "";
                _app_job_SocialActivitieswithServiceUser = "";
                _app_job_LeadCommunicationProcesses = "";
                _app_job_OrgProvidesResidentialServices = "";
                _app_job_PersonalCareAssistingMoving = "";
                _app_job_AssistEatingDrinking = "";
                _app_job_70 = "";
                _app_job_71 = "";
                _app_job_72 = "";
                _app_job_73 = "";




                string sql = "";

                sql = "INSERT INTO [oscauser].[Applications] ";
                sql += "  ([App_Title]";
                sql += ",[App_FirstName]";
                sql += ",[App_Surname]";
                sql += ",[App_Gender]";
                sql += ",[App_NI]";
                sql += ",[App_PermAddress1]";
                sql += ",[App_PermAddress2]";
                sql += ",[App_PermAddress3]";
                sql += ",[App_PermAddress4]";
                sql += ",[App_PermAddress5]";
                sql += ",[App_PermPostCode]";
                sql += ",[App_Email]";
                sql += ",[App_HomeTel]";
                sql += ",[App_Mobile]";
                sql += ",[App_Nationality]";
                sql += ",[App_LegalResidency]";
                sql += ",[App_LegalResidency_doc]";
                sql += ",[App_IsLivedEULast3Years]";
                sql += ",[App_NonEUUKHowLongLiveInUK]";

                sql += ",[App_Ethnicity]";
                sql += ",[App_Religion]";
                //sql += ",[App_SexualOrientation]";
                sql += ",[App_LengthOfAddress]";
                sql += ",[App_PrePlannedAbsence]";
                sql += ",[App_Circumstance]";
                sql += ",[App_AnyDisability]";
                sql += ",[App_AnyDisabilityPrimary]";
                sql += ",[App_AnyDisabilitySecondaries]";
                sql += ",[App_NeedLearningSupport]";
                sql += ",[App_HaveLearnerSupportProgram]";
                sql += ",[App_ProgramAppliedFor]";
                sql += ",[App_IsAccessToComputer]";
                sql += ",[App_IsAccessToFaceTime]";
                sql += ",[App_IsAccessToEmail]";
                sql += ",[App_IsPartnerOfOwner]";
                sql += ",[App_IsEPortoflioAware]";
                //sql += ",[App_ManageWorkStudy]";
                sql += ",[App_educ_HighestQual]";
                sql += ",[App_educ_IsGCSEEnglish]";
                sql += ",[App_educ_IsGCSEMath]";
                sql += ",[App_educ_EquivalentQualification]";
                sql += ",[App_educ_IsEnrolledOther]";
                sql += ",[App_educ_PreviousCollege]";
                sql += ",[App_educ_PreviousQual]";
                sql += ",[App_educ_PreviousTraining]";
                sql += ",[App_educ_IsAllFund]";
                sql += ",[App_educ_ALLFundQualDetails]";
                // sql += ",[App_educ_TrainingPlannedNext12Months]";
                //sql += ",[App_educ_FutureInspirations]";
                sql += ",[App_emp_CompanyName]";
                sql += ",[App_emp_EmpoyementStartDate]";
                sql += ",[App_emp_WorkPlaceAddress]";
                sql += ",[App_emp_WorkPlaceAddress1]";
                sql += ",[App_emp_WorkPlaceAddress2]";
                sql += ",[App_emp_WorkPlaceAddress3]";
                sql += ",[App_emp_WorkPlaceAddress4]";
                sql += ",[App_emp_WorkPlaceAddress5]";
                sql += ",[App_emp_WorkPlacePostCode]";
                sql += ",[App_emp_Email]";
                sql += ",[App_emp_Tel]";
                sql += ",[App_emp_ContactName]";
                sql += ",[App_emp_Position]";
                sql += ",[App_emp_BusinessSector]";
                sql += ",[App_emp_CompanyEstablished]";
                sql += ",[App_emp_WeeklyHours]";
                sql += ",[App_emp_IsSelfEmployed]";
                // sql += ",[App_emp_IsEmployerPaying]";
                sql += ",[App_job_JobFunction]";
                sql += ",[App_job_HowLongWorkingJob]";
                sql += ",[App_job_HowLongWorkingEmployer]";
                sql += ",[App_job_AnyPreviousManagement]";
                sql += ",[App_job_HaveCurrentDevPlan]";
                sql += ",[App_job_IsAwareFundamentalStd]";
                // sql += ",[App_job_IsResponsibleCQCPIR]";
                sql += ",[App_job_IsResponsibleRecruitment]";
                sql += ",[App_job_IsResponsibleStaffInduction]";
                sql += ",[App_job_IsResponsibleStaffAppraisal]";
                sql += ",[App_job_IsResponsibleMonitoringStaff]";
                //   sql += ",[App_job_IsResponsibleTaskAllocationRotas]";
                sql += ",[App_job_IsResponsiblePlanningReviewing]";
                //   sql += ",[App_job_IsResponsibleOrganisingReferrals]";
                //   sql += ",[App_job_IsResponsibleOrganisingPartnerships]";
                sql += ",[App_job_IsResponsibleEffectivenessPartnerships]";
                sql += ",[App_job_IsReviewAuditPolicies]";
                sql += ",[App_job_IsRespondingToComplaints]";
                sql += ",[App_job_IsInvestigatingSafeguarding]";
                sql += ",[App_job_IsAuditFeedback]";
                sql += ",[App_job_IsOrganisingLeadStaffMeetings]";
                // sql += ",[App_job_IsResponsibleWritingDevPlan]";
                //sql += ",[App_job_HaveRegularStaffMeetings]";
                sql += ",[App_job_IsAttendingStrategicMeetings]";
                sql += ",[App_job_IsEnsuringComplianceHS]";
                sql += ",[App_job_IsFurtherTrainingNeeded]";
                //sql += ",[App_job_IsSpecificSupportNeeded]";
                sql += ",[App_job_RelevantPathway]";
                sql += ",[App_job_HaveJobDescription]";
                sql += ",[App_job_HaveJobDescription_doc]";
                // sql += ",[App_job_CarryOutAuditing]";
                sql += ",[App_job_DailyMainDuties]";
                //sql += ",[App_job_UsualHoursAttendancy]";
                sql += ",[App_job_OtherPositionResponsabilities]";
                sql += ",[App_job_AboutYourStrenghts]";
                sql += ",[App_job_AreasOfDevelopment]";
                sql += ",[App_job_AllowWorkplaceObsVisit]";
                sql += ",[App_job_Confirm16hrs]";
                sql += ",[App_job_Confirm16hrsId]";
                sql += ",[App_job_Confirm16hrsTitle]";

                sql += ",[App_job_HaveStartedGLH]";
                sql += ",[App_officeuse_UniqueLearnerReference]";
                sql += ",[App_officeuse_ApprenticeshipFramework]";
                sql += ",[App_officeuse_LearnerId]";
                sql += ",[App_officeuse_ReferenceId]";
                sql += ",[App_officeuse_CQCInspectionDate]";
                sql += ",[App_officeuse_UKPRN]";
                sql += ",[App_officeuse_EmployerId] ";

                sql += ",[App_officeuse_ReferenceDate]";
                sql += ",[App_officeuse_FundingId]";
                sql += ",[App_officeuse_FundingTitle]";
                sql += ",[App_officeuse_IsEvidenceSeen] ";
                sql += ",[App_officeuse_ReferenceIdType] ";

                sql += ",App_officeuse1_IsLiteracyNumeracyDone";
                sql += ",App_officeuse1_IsAllDocumentsSigned";
                sql += ",App_officeuse1_IsConfirmEnrolment  ";
                sql += ",App_officeuse1_CourseId";

                sql += ",App_job_IsAssessReviewImplementCare";
                sql += ",App_job_IsInvolvedRiskAssessment";
                sql += ",App_job_IsEnsureOthersFollowPolicy";
                sql += ",App_job_IsSupportServiceInPersonalCare";
                sql += ",App_job_IsWorkSupportRoleServiceUsers";
                sql += ",App_job_IsPlanReviewImplmentCare";
                sql += ",App_job_IsInvolvedSafeguardingInvestigations";
                sql += ",App_job_IsTakePartInRiskAssessment";
                sql += ",App_job_IsTakePartInManagingQuality";
                sql += ",App_job_RelevantPathway_L3";
                sql += ",App_job_HaveJobDescription_L3";
                sql += ",App_job_HaveJobDescription_L3_doc";
                sql += ",App_mktg_HearAbout";
                sql += ",App_mktg_ContactConsent";
                sql += ",App_mktg_ByPhone";
                sql += ",App_mktg_ByEmail";
                sql += ",App_mktg_ByPost";
                sql += ",App_PrintName";
                sql += ",App_ApplicationDate";
                sql += ",App_ACS_WDSNumber";

                sql += ",App_job_IsContributeSelfAssessment";
                sql += ",App_job_IsReviewAuditPolicy";
                sql += ",App_job_IsLeadPartnershipWorking";
                sql += ",App_job_IsLeadProvisionDelivers";
                sql += ",App_job_IsResponsibleKeyResources";
                sql += ",App_job_IsResponsibleStaffTraining";
                sql += ",App_job_ExampleProjectManaged";
                sql += ",App_job_ExampleSupportingCarePractice";
                sql += ",App_job_ExampleCPDRecent";
                sql += ",App_job_ExampleCourageImplement";
                sql += ",App_job_IsResponsibleManagingQuality";
                sql += ",App_job_IsResponsibleIncludeDevelopment";

                sql += ",App_job_102_KnowledgeStatutoryFrameworks";
                sql += ",App_job_103_ExperienceOfManaging";
                sql += ",App_job_104_AbilityImplementStrategies";
                sql += ",App_job_105_ExperienceLeadingSupporting";
                sql += ",App_job_106_CarriedOutActivitiesMonitor";
                //New DB Changes for new Questions
                sql += ",[App_EUEEAStatus]";
                sql += ",[App_job_TherapySessions]";

                sql += ",[App_job_HealthPromotion]";
                sql += ",[App__job_Advocate]";
                sql += ",[App_job_SupportServiceUsers]";
                sql += ",[App_EUEEANational]";
                sql += ",[App_job_AssessReviewSupportPlans]";
                sql += ",[App_job_IsInvolvedInRiskAssessments]";
                sql += ",[App_job_ContributeToMentalHealth]";
                sql += ",[App_job_SupportIndvDepressionPhobias]";
                sql += ",[App_job_WorkinPartnershipswthProfessionals]";
                sql += ",[App_job_SafeguardReports]";

                sql += ",[App_job_RecruitmentResponsibilities]";
                sql += ",[App_job_StaffInductionCareCertificate]";
                sql += ",[App_job_RespondCompliments]";
                sql += ",[App_job_WorkMgtRole]";
                sql += ",[App_job_TakePartSupervisions]";
                sql += ",[App_job_TakePartMeetings]";
                sql += ",[App_job_MaintainPersonalRecord]";
                sql += ",[App_job_RiskAssessOthersComply]";
                sql += ",[App_job_SafeguardInvestigations]";
                sql += ",[App_job_WorkSupportiveRole]";
                sql += ",[App_job_ReviewSupportPlans]";
                sql += ",[App_job_WorkPartnerProfessionals]";
                sql += ",[App_job_CVPResilience]";
                sql += ",[App_job_TechCommunication]";
                sql += ",[App_job_RegularSupervisions]";
                sql += ",[App_job_CarryoutRiskAssessment]";
                sql += ",[App_job_SupportCYP]";
                sql += ",[App_job_PositiveRiskTaking]";

                sql += ",[App_job_KeyWorker]";
                sql += ",[App_job_PlanImplementcare]";
                sql += ",[App_job_WriteRecordReports]";
                sql += ",[App_job_SocialActivitieswithServiceUser]";
                sql += ",[App_job_LeadCommunicationProcesses]";
                sql += ",[App_job_OrgProvidesResidentialServices]";
                sql += ",[App_job_PersonalCareAssistingMoving]";
                sql += ",[App_job_AssistEatingDrinking]";
                sql += ",[App_job_70]";
                sql += ",[App_job_71]";
                sql += ",[App_job_72]";
                sql += ",[App_job_73]";
                sql += " )";

                sql += "VALUES ";
                //sql += " ('' ";// App_Title
                //sql += ", '' ";// App_FirstName
                //sql += ", '' "; //     App_Surname
                //sql += ", '' "; //     

                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     

                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' "; //     
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //// sql += ", '' ";// 
                ////sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", 0 ";//learner id
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", '' ";// 
                //sql += ", 0 ";// 
                //sql += ", 0 ";// 
                //sql += ", 0 ";// 
                //sql += ", 0) "; // App_officeuse1_CourseId



                sql += " ('' ";//  ([App_Title
                sql += ", '' ";//    App_FirstName
                sql += ", '' ";//    App_Surname
                sql += ", '' ";//    App_Gender
                sql += ", '' ";//    App_NI
                sql += ", '' ";//    App_PermAddress1
                sql += ", '' ";//    App_PermAddress2
                sql += ", '' ";//    App_PermAddress3
                sql += ", '' ";//    App_PermAddress4
                sql += ", '' ";//    App_PermAddress5
                sql += ", '' ";//    App_PermPostCode
                sql += ", '' ";//    App_Email
                sql += ", '' ";//    App_HomeTel
                sql += ", '' ";//    App_Mobile
                sql += ", '' ";//    App_Nationality
                sql += ", '' ";//    App_LegalResidency
                sql += ", '' ";//    App_LegalResidency_doc
                sql += ", '' ";//    App_IsLivedEULast3Years
                sql += ", '' ";//    App_NonEUUKHowLongLiveInUK
                sql += ", '' ";//    App_Ethnicity
                sql += ", '' ";//    App_Religion
                               //sql += ", '' ";//    App_SexualOrientation
                sql += ", '' ";//    App_LengthOfAddress
                sql += ", '' ";//    App_PrePlannedAbsence
                sql += ", '' ";//    App_Circumstance
                sql += ", '' ";//    App_AnyDisability
                sql += ", '' ";//    App_AnyDisabilityPrimary
                sql += ", '' ";//    App_AnyDisabilitySecondaries
                sql += ", '' ";//    App_NeedLearningSupport
                sql += ", '' ";//    App_HaveLearnerSupportProgram
                sql += ", '' ";//    App_ProgramAppliedFor
                sql += ", '' ";//    App_IsAccessToComputer
                sql += ", '' ";//    App_IsAccessToFaceTime
                sql += ", '' ";//    App_IsAccessToEmail
                sql += ", '' ";//    App_IsPartnerOfOwner
                sql += ", '' ";//    App_IsEPortoflioAware
                               //sql += ", '' ";//    App_ManageWorkStudy
                sql += ", '' ";//    App_educ_HighestQual
                sql += ", '' ";//    App_educ_IsGCSEEnglish
                sql += ", '' ";//    App_educ_IsGCSEMath
                sql += ", '' ";//    App_educ_EquivalentQualification
                sql += ", '' ";//    App_educ_IsEnrolledOther
                sql += ", '' ";//    App_educ_PreviousCollege
                sql += ", '' ";//    App_educ_PreviousQual
                sql += ", '' ";//    App_educ_PreviousTraining
                sql += ", '' ";//    App_educ_IsAllFund
                sql += ", '' ";//    App_educ_ALLFundQualDetails
                // sql += ", '' ";//    App_educ_TrainingPlannedNext12Months
                //sql += ", '' ";//    App_educ_FutureInspirations
                sql += ", '' ";//    App_emp_CompanyName
                sql += ", '' ";//    App_emp_EmpoyementStartDate
                sql += ", '' ";//    App_emp_WorkPlaceAddress
                sql += ", '' ";//    App_emp_WorkPlaceAddress1
                sql += ", '' ";//    App_emp_WorkPlaceAddress2
                sql += ", '' ";//    App_emp_WorkPlaceAddress3
                sql += ", '' ";//    App_emp_WorkPlaceAddress4
                sql += ", '' ";//    App_emp_WorkPlaceAddress5
                sql += ", '' ";//    App_emp_WorkPlacePostCode
                sql += ", '' ";//    App_emp_Email
                sql += ", '' ";//    App_emp_Tel
                sql += ", '' ";//    App_emp_ContactName
                sql += ", '' ";//    App_emp_Position
                sql += ", '' ";//    App_emp_BusinessSector
                sql += ", '' ";//    App_emp_CompanyEstablished
                sql += ", '' ";//    App_emp_WeeklyHours
                sql += ", '' ";//    App_emp_IsSelfEmployed
                               // sql += ", '' ";//    App_emp_IsEmployerPaying
                sql += ", '' ";//    App_job_JobFunction
                sql += ", '' ";//    App_job_HowLongWorkingJob
                sql += ", '' ";//    App_job_HowLongWorkingEmployer
                sql += ", '' ";//    App_job_AnyPreviousManagement
                sql += ", '' ";//    App_job_HaveCurrentDevPlan
                sql += ", '' ";//    App_job_IsAwareFundamentalStd
                //sql += ", '' ";//    App_job_IsResponsibleCQCPIR
                sql += ", '' ";//    App_job_IsResponsibleRecruitment
                sql += ", '' ";//    App_job_IsResponsibleStaffInduction
                sql += ", '' ";//    App_job_IsResponsibleStaffAppraisal
                sql += ", '' ";//    App_job_IsResponsibleMonitoringStaff
                               //   sql += ", '' ";//    App_job_IsResponsibleTaskAllocationRotas
                sql += ", '' ";//    App_job_IsResponsiblePlanningReviewing
                               //   sql += ", '' ";//    App_job_IsResponsibleOrganisingReferrals
                               //   sql += ", '' ";//    App_job_IsResponsibleOrganisingPartnerships
                sql += ", '' ";//    App_job_IsResponsibleEffectivenessPartnerships
                sql += ", '' ";//    App_job_IsReviewAuditPolicies
                sql += ", '' ";//    App_job_IsRespondingToComplaints
                sql += ", '' ";//    App_job_IsInvestigatingSafeguarding
                sql += ", '' ";//    App_job_IsAuditFeedback
                sql += ", '' ";//    App_job_IsOrganisingLeadStaffMeetings
                               // sql += ", '' ";//    App_job_IsResponsibleWritingDevPlan
                               //sql += ", '' ";//    App_job_HaveRegularStaffMeetings
                sql += ", '' ";//    App_job_IsAttendingStrategicMeetings
                sql += ", '' ";//    App_job_IsEnsuringComplianceHS
                sql += ", '' ";//    App_job_IsFurtherTrainingNeeded
                               //sql += ", '' ";//    App_job_IsSpecificSupportNeeded
                sql += ", '' ";//    App_job_RelevantPathway
                sql += ", '' ";//    App_job_HaveJobDescription
                sql += ", '' ";//    App_job_HaveJobDescription_doc
                               // sql += ", '' ";//    App_job_CarryOutAuditing
                sql += ", '' ";//    App_job_DailyMainDuties
                               //sql += ", '' ";//    App_job_UsualHoursAttendancy
                sql += ", '' ";//    App_job_OtherPositionResponsabilities
                sql += ", '' ";//    App_job_AboutYourStrenghts
                sql += ", '' ";//    App_job_AreasOfDevelopment
                sql += ", '' ";//    App_job_AllowWorkplaceObsVisit
                sql += ", 0 ";//   _App._app_job_Confirm16hrs = chk_job_Confirm16hrs.Checked;
                sql += ", 0 ";//    App_officeuse_Confirm16hrsId
                sql += ", '' ";//    App_officeuse_Confirm16hrsTitle
                sql += ", '' ";//    App_job_HaveStartedGLH
                sql += ", '' ";//    App_officeuse_UniqueLearnerReference
                sql += ", '' ";//    App_officeuse_ApprenticeshipFramework
                sql += ", 0 ";//    App_officeuse_LearnerId
                sql += ", '' ";//    App_officeuse_ReferenceId
                sql += ", '' ";//    App_officeuse_CQCInspectionDate
                sql += ", '' ";//    App_officeuse_UKPRN
                sql += ", '' ";//    App_officeuse_EmployerId] ";

                sql += ", '' ";//    App_officeuse_ReferenceDate
                sql += ", 0 ";//    App_officeuse_FundingId
                sql += ", 'Full Cost' ";//    App_officeuse_FundingTitle
                sql += ", 0 ";      //  App_officeuse_IsEvidenceSeen;
                sql += ", '' ";     //  App_officeuse_ReferenceIdType
                sql += ", 0 ";//App_officeuse1_IsLiteracyNumeracyDone;
                sql += ", 0 ";//App_officeuse1_IsAllDocumentsSigned;
                sql += ", 0 ";//App_officeuse1_IsConfirmEnrolment  ;
                sql += ", 0  ";//App_officeuse1_CourseId ;

                sql += ", '' ";//App_job_IsAssessReviewImplementCare";
                sql += ", '' ";//App_job_IsInvolvedRiskAssessment";
                sql += ", '' ";//App_job_IsEnsureOthersFollowPolicy";
                sql += ", '' ";//App_job_IsSupportServiceInPersonalCare";
                sql += ", '' ";//App_job_IsWorkSupportRoleServiceUsers";
                sql += ", '' ";//App_job_IsPlanReviewImplmentCare";
                sql += ", '' ";//App_job_IsInvolvedSafeguardingInvestigations";
                sql += ", '' ";//App_job_IsTakePartInRiskAssessment";
                sql += ", '' ";//App_job_IsTakePartInManagingQuality";

                sql += ", '' ";//App_job_RelevantPathway_L3";
                sql += ", '' ";//App_job_HaveJobDescription_L3";
                sql += ", '' ";//App_job_HaveJobDescription_L3_doc";

                sql += ", '' ";//App_mktg_HearAbout";
                sql += ", '' ";//App_mktg_ContactConsent";
                sql += ", '' ";//App_mktg_ByPhone";
                sql += ", '' ";//App_mktg_ByEmail";
                sql += ", '' ";//App_mktg_ByPost";

                sql += ", '' ";//App_PrintName";
                sql += ", '' ";//App_ApplicationDate";
                sql += ", '' ";//App_ACS_WDSNumber";

                sql += ", '' ";//App_job_IsContributeSelfAssessment";
                sql += ", '' ";//App_job_IsReviewAuditPolicy";
                sql += ", '' ";//App_job_IsLeadPartnershipWorking";
                sql += ", '' ";//App_job_IsLeadProvisionDelivers";
                sql += ", '' ";//App_job_IsResponsibleKeyResources";
                sql += ", '' ";//App_job_IsResponsibleStaffTraining";
                sql += ", '' ";//App_job_ExampleProjectManaged";
                sql += ", '' ";//App_job_ExampleSupportingCarePractice";
                sql += ", '' ";//App_job_ExampleCPDRecent";
                sql += ", '' ";//App_job_ExampleCourageImplement";
                sql += ", '' ";//App_job_IsResponsibleManagingQuality";
                sql += ", '' ";//App_job_IsResponsibleIncludeDevelopment";

                sql += ", '' ";//App_job_102_KnowledgeStatutoryFrameworks
                sql += ", '' ";//App_job_103_ExperienceOfManaging
                sql += ", '' ";//App_job_104_AbilityImplementStrategies
                sql += ", '' ";//App_job_105_ExperienceLeadingSupporting
                sql += ", '' ";//App_job_106_CarriedOutActivitiesMonitor
                sql += ", '' ";//App_EUEEAStatus 
                sql += ", '' ";// App_job_TherapySessions 

                sql += ", '' ";//App_job_HealthPromotion
                sql += ", '' ";//App__job_Advocate 
                sql += ", '' ";//App_job_SupportServiceUsers 
                sql += ", '' ";//App_EUEEANational
                sql += ", '' ";//App_job_AssessReviewSupportPlans
                sql += ", '' ";//App_job_IsInvolvedInRiskAssessments
                sql += ", '' ";//App_job_ContributeToMentalHealth
                sql += ", '' ";//App_job_SupportIndvDepressionPhobias
                sql += ", '' ";//App_job_WorkinPartnershipswthProfessionals
                sql += ", '' ";//App_job_SafeguardReports
                sql += ", '' ";//App_job_RecruitmentResponsibilities
                sql += ", '' ";//App_job_StaffInductionCareCertificate
                sql += ", '' ";//App_job_RespondCompliments
                sql += ", '' ";//App_job_WorkMgtRole
                sql += ", '' ";//App_job_TakePartSupervisions
                sql += ", '' ";//App_job_TakePartMeetings
                sql += ", '' ";//App_job_MaintainPersonalRecord
                sql += ", '' ";//App_job_RiskAssessOthersComply
                sql += ", '' ";//App_job_SafeguardInvestigations
                sql += ", '' ";//App_job_WorkSupportiveRole
                sql += ", '' ";//App_job_ReviewSupportPlans
                sql += ", '' ";//App_job_WorkPartnerProfessionals
                sql += ", '' ";//App_job_CVPResilience
                sql += ", '' ";//App_job_TechCommunication
                sql += ", '' ";//App_job_RegularSupervisions
                sql += ", '' ";//App_job_CarryoutRiskAssessment
                sql += ", '' ";//App_job_SupportCYP
                sql += ", '' ";//App_job_PositiveRiskTaking
                sql += ", '' ";//App_job_KeyWorker
                sql += ", '' ";//App_job_PlanImplementcare
                sql += ", '' ";//App_job_WriteRecordReports
                sql += ", '' ";//App_job_SocialActivitieswithServiceUser
                sql += ", '' ";//App_job_LeadCommunicationProcesses
                sql += ", '' ";//App_job_OrgProvidesResidentialServices
                sql += ",''";//App_job_PersonalCareAssistingMoving
                sql += ",''";//App_job_AssistEatingDrinking
                sql += ",''";//App_job_70
                sql += ",''";//App_job_71
                sql += ",''";//App_job_72
                sql += ",''";//App_job_73

                sql += " )  ";// ending 

                int iLastAdded = 0;
                sql += "; SELECT App_Id FROM [oscauser].[Applications] WHERE App_Id = @@IDENTITY ";
                DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(sql);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    iLastAdded = int.Parse(ds.Tables[0].Rows[0]["App_Id"].ToString());
                }
                else
                {
                    iLastAdded = 0;
                }

                _app_id = iLastAdded;

                if (_app_id != 0)
                {
                    //we need to save to applications users
                    int iUserId = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName);
                    string sql2 = "INSERT INTO [oscauser].[ApplicationsUsers] (AppUser_App_Id, AppUser_UserId, AppUser_CreatedDate, AppUser_CreatedByUser) VALUES ({0},{1},{2},'{3}')";
                    DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, _app_id, iUserId, " GetDate() ", Membership.GetUser().UserName));
                }
            }
            else
            {
                isNewApplication = false;
                isCompletedApplication = false;
            }
        }

        public ApplicationForm GetApplication(int iId = 0)
        {
            ApplicationForm myApp = null;
            if (iId != 0)
            {
                myApp = new ApplicationForm();
                DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT *,Convert(varchar,convert(date,App_emp_EmpoyementStartDate,103),103)App_emp_EmpoyementStartDate1 FROM [oscauser].[Applications] WHERE App_Id = " + iId.ToString());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    myApp._app_id = iId;
                    myApp._app_Title = ds.Tables[0].Rows[0]["App_Title"].ToString();
                    myApp._app_FirstName = ds.Tables[0].Rows[0]["App_FirstName"].ToString();
                    myApp._app_Surname = ds.Tables[0].Rows[0]["App_Surname"].ToString();
                    myApp._app_Gender = ds.Tables[0].Rows[0]["App_Gender"].ToString();
                    myApp._app_DOB = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_DOB"].ToString());
                    myApp._app_NI = ds.Tables[0].Rows[0]["App_NI"].ToString();
                    myApp._app_PermAddress1 = ds.Tables[0].Rows[0]["App_PermAddress1"].ToString();
                    myApp._app_PermAddress2 = ds.Tables[0].Rows[0]["App_PermAddress2"].ToString();
                    myApp._app_PermAddress3 = ds.Tables[0].Rows[0]["App_PermAddress3"].ToString();
                    myApp._app_PermAddress4 = ds.Tables[0].Rows[0]["App_PermAddress4"].ToString();
                    myApp._app_PermAddress5 = ds.Tables[0].Rows[0]["App_PermAddress5"].ToString();
                    myApp._app_PermPostCode = ds.Tables[0].Rows[0]["App_PermPostCode"].ToString();
                    myApp._app_Email = ds.Tables[0].Rows[0]["App_Email"].ToString();
                    myApp._app_HomeTel = ds.Tables[0].Rows[0]["App_HomeTel"].ToString();
                    myApp._app_Mobile = ds.Tables[0].Rows[0]["App_Mobile"].ToString();
                    myApp._app_Nationality = ds.Tables[0].Rows[0]["App_Nationality"].ToString();
                    myApp._app_LegalResidency = ds.Tables[0].Rows[0]["App_LegalResidency"].ToString();
                    myApp._app_LegalResidency_doc = ds.Tables[0].Rows[0]["App_LegalResidency_doc"].ToString();
                    myApp._app_IsLivedEULast3Years = ds.Tables[0].Rows[0]["App_IsLivedEULast3Years"].ToString();
                    myApp._app_LivedEntryDate = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_LivedEntryDate"].ToString());
                    myApp._app_NonEUUKHowLongLiveInUK = ds.Tables[0].Rows[0]["App_NonEUUKHowLongLiveInUK"].ToString();

                    myApp._app_Ethnicity = ds.Tables[0].Rows[0]["App_Ethnicity"].ToString();
                    myApp._app_Religion = ds.Tables[0].Rows[0]["App_Religion"].ToString();
                    //myApp._app_SexualOrientation = ds.Tables[0].Rows[0]["App_SexualOrientation"].ToString();
                    myApp._app_LengthOfAddress = ds.Tables[0].Rows[0]["App_LengthOfAddress"].ToString();
                    myApp._app_PrePlannedAbsence = ds.Tables[0].Rows[0]["App_PrePlannedAbsence"].ToString();
                    myApp._app_Circumstance = ds.Tables[0].Rows[0]["App_Circumstance"].ToString();

                    myApp._app_AnyDisability = ds.Tables[0].Rows[0]["App_AnyDisability"].ToString();
                    myApp._app_AnyDisabilityPrimary = ds.Tables[0].Rows[0]["App_AnyDisabilityPrimary"].ToString();
                    myApp._app_AnyDisabilitySecondaries = ds.Tables[0].Rows[0]["App_AnyDisabilitySecondaries"].ToString();

                    myApp._app_NeedLearningSupport = ds.Tables[0].Rows[0]["App_NeedLearningSupport"].ToString();
                    myApp._app_HaveLearnerSupportProgram = ds.Tables[0].Rows[0]["App_HaveLearnerSupportProgram"].ToString();
                    myApp._app_ProgramAppliedFor = ""; // ds.Tables[0].Rows[0]["App_ProgramAppliedFor"].ToString();
                    myApp._app_IsAccessToComputer = ds.Tables[0].Rows[0]["App_IsAccessToComputer"].ToString();
                    myApp._app_IsAccessToFaceTime = ds.Tables[0].Rows[0]["App_IsAccessToFaceTime"].ToString();
                    myApp._app_IsAccessToEmail = ds.Tables[0].Rows[0]["App_IsAccessToEmail"].ToString();
                    myApp._app_IsPartnerOfOwner = ds.Tables[0].Rows[0]["App_IsPartnerOfOwner"].ToString();
                    myApp._app_IsEPortoflioAware = ds.Tables[0].Rows[0]["App_IsEPortoflioAware"].ToString();
                    //myApp._app_ManageWorkStudy = ds.Tables[0].Rows[0]["App_ManageWorkStudy"].ToString();
                    myApp._app_educ_HighestQual = ds.Tables[0].Rows[0]["App_educ_HighestQual"].ToString();
                    myApp._app_educ_IsGCSEEnglish = ds.Tables[0].Rows[0]["App_educ_IsGCSEEnglish"].ToString();
                    myApp._app_educ_IsGCSEMath = ds.Tables[0].Rows[0]["App_educ_IsGCSEMath"].ToString();
                    myApp._app_educ_EquivalentQualification = ds.Tables[0].Rows[0]["App_educ_EquivalentQualification"].ToString();

                    myApp._app_educ_IsEnrolledOther = ds.Tables[0].Rows[0]["App_educ_IsEnrolledOther"].ToString();
                    myApp._app_educ_PreviousCollege = ds.Tables[0].Rows[0]["App_educ_PreviousCollege"].ToString();
                    myApp._app_educ_PreviousQual = ds.Tables[0].Rows[0]["App_educ_PreviousQual"].ToString();
                    myApp._app_educ_PreviousTraining = ds.Tables[0].Rows[0]["App_educ_PreviousTraining"].ToString();
                    myApp._app_educ_IsALLFund = ds.Tables[0].Rows[0]["App_educ_IsAllFund"].ToString();
                    myApp._app_educ_ALLFundQualDetails = ds.Tables[0].Rows[0]["App_educ_ALLFundQualDetails"].ToString();

                    //myApp._app_educ_TrainingPlannedNext12Months = ds.Tables[0].Rows[0]["App_educ_TrainingPlannedNext12Months"].ToString();
                    //myApp._app_educ_FutureInspirations = ds.Tables[0].Rows[0]["App_educ_FutureInspirations"].ToString();
                    myApp._app_emp_CompanyName = ds.Tables[0].Rows[0]["App_emp_CompanyName"].ToString();
                    myApp._app_emp_EmpoyementStartDate = ds.Tables[0].Rows[0]["App_emp_EmpoyementStartDate1"].ToString();

                    myApp._app_emp_WorkPlaceAddress = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress"].ToString();
                    myApp._app_emp_WorkPlaceAddress1 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress1"].ToString();
                    myApp._app_emp_WorkPlaceAddress2 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress2"].ToString();
                    myApp._app_emp_WorkPlaceAddress3 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress3"].ToString();
                    myApp._app_emp_WorkPlaceAddress4 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress4"].ToString();
                    myApp._app_emp_WorkPlaceAddress5 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress5"].ToString();
                    myApp._app_emp_WorkPlacePostCode = ds.Tables[0].Rows[0]["App_emp_WorkPlacePostCode"].ToString();
                    myApp._app_emp_Email = ds.Tables[0].Rows[0]["App_emp_Email"].ToString();
                    myApp._app_emp_Tel = ds.Tables[0].Rows[0]["App_emp_Tel"].ToString();
                    myApp._app_emp_ContactName = ds.Tables[0].Rows[0]["App_emp_ContactName"].ToString();
                    myApp._app_emp_Position = ds.Tables[0].Rows[0]["App_emp_Position"].ToString();
                    myApp._app_emp_BusinessSector = ds.Tables[0].Rows[0]["App_emp_BusinessSector"].ToString();
                    myApp._app_emp_CompanyEstablished = ds.Tables[0].Rows[0]["App_emp_CompanyEstablished"].ToString();
                    myApp._app_emp_WeeklyHours = ds.Tables[0].Rows[0]["App_emp_WeeklyHours"].ToString();
                    myApp._app_emp_IsSelfEmployed = ds.Tables[0].Rows[0]["App_emp_IsSelfEmployed"].ToString();
                    //myApp._app_emp_IsEmployerPaying = ds.Tables[0].Rows[0]["App_emp_IsEmployerPaying"].ToString();
                    myApp._app_job_JobFunction = ds.Tables[0].Rows[0]["App_job_JobFunction"].ToString();
                    myApp._app_job_HowLongWorkingJob = ds.Tables[0].Rows[0]["App_job_HowLongWorkingJob"].ToString();
                    myApp._app_job_HowLongWorkingEmployer = ds.Tables[0].Rows[0]["App_job_HowLongWorkingEmployer"].ToString();
                    myApp._app_job_AnyPreviousManagement = ds.Tables[0].Rows[0]["App_job_AnyPreviousManagement"].ToString();
                    myApp._app_job_HaveCurrentDevPlan = ds.Tables[0].Rows[0]["App_job_HaveCurrentDevPlan"].ToString();
                    myApp._app_job_IsAwareFundamentalStd = ds.Tables[0].Rows[0]["App_job_IsAwareFundamentalStd"].ToString();
                    //  myApp._app_job_IsResponsibleCQCPIR = ds.Tables[0].Rows[0]["App_job_IsResponsibleCQCPIR"].ToString();
                    myApp._app_job_IsResponsibleRecruitment = ds.Tables[0].Rows[0]["App_job_IsResponsibleRecruitment"].ToString();
                    myApp._app_job_IsResponsibleStaffInduction = ds.Tables[0].Rows[0]["App_job_IsResponsibleStaffInduction"].ToString();
                    myApp._app_job_IsResponsibleStaffAppraisal = ds.Tables[0].Rows[0]["App_job_IsResponsibleStaffAppraisal"].ToString();
                    myApp._app_job_IsResponsibleMonitoringStaff = ds.Tables[0].Rows[0]["App_job_IsResponsibleMonitoringStaff"].ToString();
                    // myApp._app_job_IsResponsibleTaskAllocationRotas = ds.Tables[0].Rows[0]["App_job_IsResponsibleTaskAllocationRotas"].ToString();
                    myApp._app_job_IsResponsiblePlanningReviewing = ds.Tables[0].Rows[0]["App_job_IsResponsiblePlanningReviewing"].ToString();
                    //    myApp._app_job_IsResponsibleOrganisingReferrals = ds.Tables[0].Rows[0]["App_job_IsResponsibleOrganisingReferrals"].ToString();
                    //    myApp._app_job_IsResponsibleOrganisingPartnerships = ds.Tables[0].Rows[0]["App_job_IsResponsibleOrganisingPartnerships"].ToString();
                    myApp._app_job_IsResponsibleEffectivenessPartnerships = ds.Tables[0].Rows[0]["App_job_IsResponsibleEffectivenessPartnerships"].ToString();
                    myApp._app_job_IsReviewAuditPolicies = ds.Tables[0].Rows[0]["App_job_IsReviewAuditPolicies"].ToString();
                    myApp._app_job_IsRespondingToComplaints = ds.Tables[0].Rows[0]["App_job_IsRespondingToComplaints"].ToString();
                    myApp._app_job_IsInvestigatingSafeguarding = ds.Tables[0].Rows[0]["App_job_IsInvestigatingSafeguarding"].ToString();
                    myApp._app_job_IsAuditFeedback = ds.Tables[0].Rows[0]["App_job_IsAuditFeedback"].ToString();
                    myApp._app_job_IsOrganisingLeadStaffMeetings = ds.Tables[0].Rows[0]["App_job_IsOrganisingLeadStaffMeetings"].ToString();
                    // myApp._app_job_IsResponsibleWritingDevPlan = ds.Tables[0].Rows[0]["App_job_IsResponsibleWritingDevPlan"].ToString();
                    //myApp._app_job_HaveRegularStaffMeetings = ds.Tables[0].Rows[0]["App_job_HaveRegularStaffMeetings"].ToString();
                    myApp._app_job_IsAttendingStrategicMeetings = ds.Tables[0].Rows[0]["App_job_IsAttendingStrategicMeetings"].ToString();
                    myApp._app_job_IsEnsuringComplianceHS = ds.Tables[0].Rows[0]["App_job_IsEnsuringComplianceHS"].ToString();
                    myApp._app_job_IsFurtherTrainingNeeded = ds.Tables[0].Rows[0]["App_job_IsFurtherTrainingNeeded"].ToString();
                    // myApp._app_job_IsSpecificSupportNeeded = ds.Tables[0].Rows[0]["App_job_IsSpecificSupportNeeded"].ToString();
                    myApp._app_job_RelevantPathway = ds.Tables[0].Rows[0]["App_job_RelevantPathway"].ToString();
                    myApp._app_job_HaveJobDescription = ds.Tables[0].Rows[0]["App_job_HaveJobDescription"].ToString();
                    myApp._app_job_HaveJobDescription_doc = ds.Tables[0].Rows[0]["App_job_HaveJobDescription_doc"].ToString();
                    //myApp._app_job_CarryOutAuditing = ds.Tables[0].Rows[0]["App_job_CarryOutAuditing"].ToString();

                    myApp._app_job_DailyMainDuties = ds.Tables[0].Rows[0]["App_job_DailyMainDuties"].ToString();
                    //myApp._app_job_UsualHoursAttendancy = ds.Tables[0].Rows[0]["App_job_UsualHoursAttendancy"].ToString();
                    myApp._app_job_OtherPositionResponsabilities = ds.Tables[0].Rows[0]["App_job_OtherPositionResponsabilities"].ToString();
                    myApp._app_job_AboutYourStrenghts = ds.Tables[0].Rows[0]["App_job_AboutYourStrenghts"].ToString();
                    myApp._app_job_AreasOfDevelopment = ds.Tables[0].Rows[0]["App_job_AreasOfDevelopment"].ToString();

                    myApp._app_job_AllowWorkplaceObsVisit = ds.Tables[0].Rows[0]["App_job_AllowWorkplaceObsVisit"].ToString();
                    myApp._app_job_TherapySessions = ds.Tables[0].Rows[0]["App_job_TherapySessions"].ToString();

                    myApp._app_job_HealthPromotion = ds.Tables[0].Rows[0]["App_job_HealthPromotion"].ToString();
                    myApp._app_job_Advocate = ds.Tables[0].Rows[0]["App__job_Advocate"].ToString();
                    myApp._app_job_SupportServiceUsers = ds.Tables[0].Rows[0]["App_job_SupportServiceUsers"].ToString();
                    myApp._app_EUEEANational = ds.Tables[0].Rows[0]["App_EUEEANational"].ToString();
                    myApp._app_job_Confirm16hrs = ds.Tables[0].Rows[0]["App_job_Confirm16hrs"].ToString() == "1" ? true : false;
                    myApp._app_job_Confirm16hrsId = ds.Tables[0].Rows[0]["App_job_Confirm16hrsId"].ToString() == "" ? 1 : int.Parse(ds.Tables[0].Rows[0]["App_job_Confirm16hrsId"].ToString());
                    myApp._app_job_Confirm16hrsTitle = ds.Tables[0].Rows[0]["App_job_Confirm16hrsTitle"].ToString() == "" ? "" : ds.Tables[0].Rows[0]["App_job_Confirm16hrsTitle"].ToString();

                    myApp._app_job_HaveStartedGLH = ds.Tables[0].Rows[0]["App_job_HaveStartedGLH"].ToString();

                    myApp._app_officeuse_UniqueLearnerReference = ds.Tables[0].Rows[0]["App_officeuse_UniqueLearnerReference"].ToString();
                    myApp._app_officeuse_StartDate = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_officeuse_StartDate"].ToString());
                    myApp._app_officeuse_EndDate = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_officeuse_EndDate"].ToString());
                    myApp._app_officeuse_ApprenticeshipFramework = ds.Tables[0].Rows[0]["App_officeuse_ApprenticeshipFramework"].ToString();
                    myApp._app_officeuse_LearnerId = ds.Tables[0].Rows[0]["App_officeuse_LearnerId"].ToString();
                    myApp._app_officeuse_ReferenceId = ds.Tables[0].Rows[0]["App_officeuse_ReferenceId"].ToString();
                    myApp._app_officeuse_CQCInspectionDate = ds.Tables[0].Rows[0]["App_officeuse_CQCInspectionDate"].ToString();
                    myApp._app_officeuse_UKPRN = ds.Tables[0].Rows[0]["App_officeuse_UKPRN"].ToString();
                    myApp._app_officeuse_EmployerId = ds.Tables[0].Rows[0]["App_officeuse_EmployerId"].ToString();

                    myApp._app_officeuse_ReferenceDate = ds.Tables[0].Rows[0]["App_officeuse_ReferenceDate"].ToString();
                    myApp._app_officeuse_FundingId = ds.Tables[0].Rows[0]["App_officeuse_FundingId"].ToString() == "" ? 0 : int.Parse(ds.Tables[0].Rows[0]["App_officeuse_FundingId"].ToString());
                    myApp._app_officeuse_FundingTitle = ds.Tables[0].Rows[0]["App_officeuse_FundingTitle"].ToString() == "" ? "Full Cost" : ds.Tables[0].Rows[0]["App_officeuse_FundingTitle"].ToString();
                    myApp._app_officeuse_IsEvidenceSeen = ds.Tables[0].Rows[0]["App_officeuse_IsEvidenceSeen"].ToString() == "1" ? true : false;
                    myApp._app_officeuse_ReferenceIdType = ds.Tables[0].Rows[0]["App_officeuse_ReferenceIdType"].ToString();

                    myApp._app_officeuse1_IsLiteracyNumeracyDone = ds.Tables[0].Rows[0]["App_officeuse1_IsLiteracyNumeracyDone"].ToString() == "1" ? true : false;
                    myApp._app_officeuse1_IsAllDocumentsSigned = ds.Tables[0].Rows[0]["App_officeuse1_IsAllDocumentsSigned"].ToString() == "1" ? true : false;
                    myApp._app_officeuse1_IsConfirmEnrolment = ds.Tables[0].Rows[0]["App_officeuse1_IsConfirmEnrolment"].ToString() == "1" ? true : false;

                    myApp._app_officeuse1_CourseId = ds.Tables[0].Rows[0]["App_officeuse1_CourseId"].ToString() == "" ? 5 : int.Parse(ds.Tables[0].Rows[0]["App_officeuse1_CourseId"].ToString());
                    //myApp._app_officeuse1_CourseTitle = ds.Tables[0].Rows[0]["App_officeuse1_CourseTitle"].ToString() == "" ? "NOT SELECTED" : ds.Tables[0].Rows[0]["App_officeuse1_CourseTitle"].ToString();
                    myApp._app_officeuse1_CourseTitle = setCourseTitle(myApp._app_officeuse1_CourseId.ToString());

                    myApp._app_officeuse1_CourseLevel = ds.Tables[0].Rows[0]["App_officeuse1_CourseLevel"].ToString() == "" ? 5 : int.Parse(ds.Tables[0].Rows[0]["App_officeuse1_CourseLevel"].ToString());

                    myApp._app_job_IsAssessReviewImplementCare = ds.Tables[0].Rows[0]["App_job_IsAssessReviewImplementCare"].ToString();
                    myApp._app_job_IsInvolvedRiskAssessment = ds.Tables[0].Rows[0]["App_job_IsInvolvedRiskAssessment"].ToString();
                    myApp._app_job_IsEnsureOthersFollowPolicy = ds.Tables[0].Rows[0]["App_job_IsEnsureOthersFollowPolicy"].ToString();
                    myApp._app_job_IsSupportServiceInPersonalCare = ds.Tables[0].Rows[0]["App_job_IsSupportServiceInPersonalCare"].ToString();
                    myApp._app_job_IsWorkSupportRoleServiceUsers = ds.Tables[0].Rows[0]["App_job_IsWorkSupportRoleServiceUsers"].ToString();
                    myApp._app_job_IsPlanReviewImplmentCare = ds.Tables[0].Rows[0]["App_job_IsPlanReviewImplmentCare"].ToString();
                    myApp._app_job_IsInvolvedSafeguardingInvestigations = ds.Tables[0].Rows[0]["App_job_IsInvolvedSafeguardingInvestigations"].ToString();
                    myApp._app_job_IsTakePartInRiskAssessment = ds.Tables[0].Rows[0]["App_job_IsTakePartInRiskAssessment"].ToString();
                    myApp._app_job_IsTakePartInManagingQuality = ds.Tables[0].Rows[0]["App_job_IsTakePartInManagingQuality"].ToString();

                    myApp._app_job_RelevantPathway_L3 = ds.Tables[0].Rows[0]["App_job_RelevantPathway_L3"].ToString();
                    myApp._app_job_HaveJobDescription_L3 = ds.Tables[0].Rows[0]["App_job_HaveJobDescription_L3"].ToString();
                    myApp._app_job_HaveJobDescription_L3_doc = ds.Tables[0].Rows[0]["App_job_HaveJobDescription_L3_doc"].ToString();


                    myApp._app_mktg_HearAbout = ds.Tables[0].Rows[0]["App_mktg_HearAbout"].ToString();
                    myApp._app_mktg_ContactConsent = ds.Tables[0].Rows[0]["App_mktg_ContactConsent"].ToString();
                    myApp._app_mktg_ByPhone = ds.Tables[0].Rows[0]["App_mktg_ByPhone"].ToString();
                    myApp._app_mktg_ByEmail = ds.Tables[0].Rows[0]["App_mktg_ByEmail"].ToString();
                    myApp._app_mktg_ByPost = ds.Tables[0].Rows[0]["App_mktg_ByPost"].ToString();


                    myApp._app_PrintName = ds.Tables[0].Rows[0]["App_PrintName"].ToString();
                    myApp._app_ApplicationDate = ds.Tables[0].Rows[0]["App_ApplicationDate"].ToString();
                    myApp._app_ACS_WDSNumber = ds.Tables[0].Rows[0]["App_ACS_WDSNumber"].ToString();

                    myApp._app_job_IsContributeSelfAssessment = ds.Tables[0].Rows[0]["App_job_IsContributeSelfAssessment"].ToString();
                    myApp._app_job_IsReviewAuditPolicy = ds.Tables[0].Rows[0]["App_job_IsReviewAuditPolicy"].ToString();
                    myApp._app_job_IsLeadPartnershipWorking = ds.Tables[0].Rows[0]["App_job_IsLeadPartnershipWorking"].ToString();
                    myApp._app_job_IsLeadProvisionDelivers = ds.Tables[0].Rows[0]["App_job_IsLeadProvisionDelivers"].ToString();
                    myApp._app_job_IsResponsibleKeyResources = ds.Tables[0].Rows[0]["App_job_IsResponsibleKeyResources"].ToString();
                    myApp._app_job_IsResponsibleStaffTraining = ds.Tables[0].Rows[0]["App_job_IsResponsibleStaffTraining"].ToString();
                    myApp._app_job_ExampleProjectManaged = ds.Tables[0].Rows[0]["App_job_ExampleProjectManaged"].ToString();
                    myApp._app_job_ExampleSupportingCarePractice = ds.Tables[0].Rows[0]["App_job_ExampleSupportingCarePractice"].ToString();
                    myApp._app_job_ExampleCPDRecent = ds.Tables[0].Rows[0]["App_job_ExampleCPDRecent"].ToString();
                    myApp._app_job_ExampleCourageImplement = ds.Tables[0].Rows[0]["App_job_ExampleCourageImplement"].ToString();
                    myApp._app_job_IsResponsibleManagingQuality = ds.Tables[0].Rows[0]["App_job_IsResponsibleManagingQuality"].ToString();
                    myApp._app_job_IsResponsibleIncludeDevelopment = ds.Tables[0].Rows[0]["App_job_IsResponsibleIncludeDevelopment"].ToString();


                    myApp._app_job_102_KnowledgeStatutoryFrameworks = ds.Tables[0].Rows[0]["App_job_102_KnowledgeStatutoryFrameworks"].ToString();
                    myApp._app_job_103_ExperienceOfManaging = ds.Tables[0].Rows[0]["App_job_103_ExperienceOfManaging"].ToString();
                    myApp._app_job_104_AbilityImplementStrategies = ds.Tables[0].Rows[0]["App_job_104_AbilityImplementStrategies"].ToString();
                    myApp._app_job_105_ExperienceLeadingSupporting = ds.Tables[0].Rows[0]["App_job_105_ExperienceLeadingSupporting"].ToString();
                    myApp._app_job_106_CarriedOutActivitiesMonitor = ds.Tables[0].Rows[0]["App_job_106_CarriedOutActivitiesMonitor"].ToString();
                    myApp._app_EUEEAStatus = ds.Tables[0].Rows[0]["App_EUEEAStatus"].ToString();
                    myApp._app_job_AssessReviewSupportPlans = ds.Tables[0].Rows[0]["App_job_AssessReviewSupportPlans"].ToString();
                    myApp._app_job_IsInvolvedInRiskAssessments = ds.Tables[0].Rows[0]["App_job_IsInvolvedInRiskAssessments"].ToString();
                    myApp._app_job_ContributeToMentalHealth = ds.Tables[0].Rows[0]["App_job_ContributeToMentalHealth"].ToString();
                    myApp._app_job_SupportIndvDepressionPhobias = ds.Tables[0].Rows[0]["App_job_SupportIndvDepressionPhobias"].ToString();
                    myApp._app_job_WorkinPartnershipswthProfessionals = ds.Tables[0].Rows[0]["App_job_WorkinPartnershipswthProfessionals"].ToString();
                    myApp._app_job_SafeguardReports = ds.Tables[0].Rows[0]["App_job_SafeguardReports"].ToString();
                    myApp._app_job_RecruitmentResponsibilities = ds.Tables[0].Rows[0]["App_job_RecruitmentResponsibilities"].ToString();
                    myApp._app_job_StaffInductionCareCertificate = ds.Tables[0].Rows[0]["App_job_StaffInductionCareCertificate"].ToString();
                    myApp._app_job_RespondCompliments = ds.Tables[0].Rows[0]["App_job_RespondCompliments"].ToString();
                    myApp._app_job_WorkMgtRole = ds.Tables[0].Rows[0]["App_job_WorkMgtRole"].ToString();
                    myApp._app_job_TakePartSupervisions = ds.Tables[0].Rows[0]["App_job_TakePartSupervisions"].ToString();
                    myApp._app_job_TakePartMeetings = ds.Tables[0].Rows[0]["App_job_TakePartMeetings"].ToString();
                    myApp._app_job_MaintainPersonalRecord = ds.Tables[0].Rows[0]["App_job_MaintainPersonalRecord"].ToString();
                    myApp._app_job_RiskAssessOthersComply = ds.Tables[0].Rows[0]["App_job_RiskAssessOthersComply"].ToString();
                    myApp._app_job_SafeguardInvestigations = ds.Tables[0].Rows[0]["App_job_SafeguardInvestigations"].ToString();
                    myApp._app_job_WorkSupportiveRole = ds.Tables[0].Rows[0]["App_job_WorkSupportiveRole"].ToString();

                    myApp._app_job_ReviewSupportPlans = ds.Tables[0].Rows[0]["App_job_ReviewSupportPlans"].ToString();
                    myApp._app_job_WorkPartnerProfessionals = ds.Tables[0].Rows[0]["App_job_WorkPartnerProfessionals"].ToString();
                    myApp._app_job_CVPResilience = ds.Tables[0].Rows[0]["App_job_CVPResilience"].ToString();
                    myApp._app_job_TechCommunication = ds.Tables[0].Rows[0]["App_job_TechCommunication"].ToString();
                    myApp._app_job_RegularSupervisions = ds.Tables[0].Rows[0]["App_job_RegularSupervisions"].ToString();
                    myApp._app_job_CarryoutRiskAssessment = ds.Tables[0].Rows[0]["App_job_CarryoutRiskAssessment"].ToString();
                    myApp._app_job_SupportCYP = ds.Tables[0].Rows[0]["App_job_SupportCYP"].ToString();
                    myApp._app_job_PositiveRiskTaking = ds.Tables[0].Rows[0]["App_job_PositiveRiskTaking"].ToString();
                    myApp._app_job_KeyWorker = ds.Tables[0].Rows[0]["App_job_KeyWorker"].ToString();
                    myApp._app_job_PlanImplementcare = ds.Tables[0].Rows[0]["App_job_PlanImplementcare"].ToString();
                    myApp._app_job_WriteRecordReports = ds.Tables[0].Rows[0]["App_job_WriteRecordReports"].ToString();
                    myApp._app_job_SocialActivitieswithServiceUser = ds.Tables[0].Rows[0]["App_job_SocialActivitieswithServiceUser"].ToString();
                    myApp._app_job_LeadCommunicationProcesses = ds.Tables[0].Rows[0]["App_job_LeadCommunicationProcesses"].ToString();
                    myApp._app_job_OrgProvidesResidentialServices = ds.Tables[0].Rows[0]["App_job_OrgProvidesResidentialServices"].ToString();
                    myApp._app_job_PersonalCareAssistingMoving = ds.Tables[0].Rows[0]["App_job_PersonalCareAssistingMoving"].ToString();

                    //level 2
                    myApp._app_job_70 = ds.Tables[0].Rows[0]["App_job_70"].ToString();
                    myApp._app_job_71 = ds.Tables[0].Rows[0]["App_job_71"].ToString();
                    myApp._app_job_72 = ds.Tables[0].Rows[0]["App_job_72"].ToString();
                    myApp._app_job_73 = ds.Tables[0].Rows[0]["App_job_73"].ToString();
                    myApp._app_job_AssistEatingDrinking = ds.Tables[0].Rows[0]["App_job_AssistEatingDrinking"].ToString();

                    // Rahmat SEC

                    myApp._app_Esf_Q_Type_Service_Provider = ds.Tables[0].Rows[0]["App_Esf_Q_Type_Service_Provider"].ToString();
                    myApp._app_Esf_Q_Unique_Number = ds.Tables[0].Rows[0]["App_Esf_Q_Unique_Number"].ToString();
                    myApp._app_Esf_Q_Refugee = ds.Tables[0].Rows[0]["App_Esf_Q_Refugee"].ToString();
                    myApp._app_Esf_Q_Granted_Leave = ds.Tables[0].Rows[0]["App_Esf_Q_Granted_Leave"].ToString();
                    myApp._app_Esf_Q_Single_Adult = ds.Tables[0].Rows[0]["App_Esf_Q_Single_Adult"].ToString();
                    myApp._app_Org_Skill = ds.Tables[0].Rows[0]["App_Org_Skill"].ToString();
                    myApp._app_Org_Cqc = ds.Tables[0].Rows[0]["App_Org_Cqc"].ToString();
                    myApp._app_Org_Reg_Cqc= ds.Tables[0].Rows[0]["App_Org_Reg_Cqc"].ToString();
                    myApp._app_Org_Employee = ds.Tables[0].Rows[0]["App_Org_Employee"].ToString();
                    myApp._app_Esf_Q_Manager_Register = ds.Tables[0].Rows[0]["App_Esf_Q_Manager_Register"].ToString();
                    myApp._app_Org_PId = ds.Tables[0].Rows[0]["App_Org_PId"].ToString();
                    myApp._app_Org_Reg_Local_Authority = ds.Tables[0].Rows[0]["App_Org_Reg_Local_Authority"].ToString();
                    myApp._app_Esf_Q_Million_Balance = ds.Tables[0].Rows[0]["App_Esf_Q_Million_Balance"].ToString();
                    myApp._app_Esf_Q_Basic_English = ds.Tables[0].Rows[0]["App_Esf_Q_Basic_English"].ToString();
                    myApp._app_Esf_Q_Basic_Math = ds.Tables[0].Rows[0]["App_Esf_Q_Basic_Math"].ToString();
                    myApp._app_Esf_Q_Level_2_English = ds.Tables[0].Rows[0]["App_Esf_Q_Level_2_English"].ToString();
                    myApp._app_Esf_Q_Level_2_Math = ds.Tables[0].Rows[0]["App_Esf_Q_Level_2_Math"].ToString();
                    myApp._app_Esf_Q_High_Qualification = ds.Tables[0].Rows[0]["App_Esf_Q_High_Qualification"].ToString();


                    myApp._app_Esf_Q_Access_Skill_Hold = ds.Tables[0].Rows[0]["App_Esf_Q_Access_Skill_Hold"].ToString();
                    myApp._app_Esf_Q_European_Social = ds.Tables[0].Rows[0]["App_Esf_Q_European_Social"].ToString();
                    myApp._app_Esf_Q_Employee_Million = ds.Tables[0].Rows[0]["App_Esf_Q_Employee_Million"].ToString();
                    myApp._app_Esf_Q_Behalf = ds.Tables[0].Rows[0]["App_Esf_Q_Behalf"].ToString();
                    myApp._app_Esf_Q_Assessment = ds.Tables[0].Rows[0]["App_Esf_Q_Assessment"].ToString();
                    myApp._app_Esf_Q_Access_Skill = ds.Tables[0].Rows[0]["App_Esf_Q_Access_Skill"].ToString();
                    myApp._app_Esf_Q_Info_Supplied = ds.Tables[0].Rows[0]["App_Esf_Q_Info_Supplied"].ToString();
                    myApp._app_Esf_Q_Legally_Uk = ds.Tables[0].Rows[0]["App_Esf_Q_Legally_Uk"].ToString();


                    DataSet dsAppUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT AppUser_IsCompleted FROM [oscauser].[ApplicationsUsers] WHERE AppUser_App_Id = " + iId.ToString());

                    if (dsAppUser != null && dsAppUser.Tables.Count > 0 && dsAppUser.Tables[0].Rows.Count > 0)
                    {
                        myApp.isCompletedApplication = (dsAppUser.Tables[0].Rows[0]["AppUser_IsCompleted"].ToString()) == "1" ? true : false;

                    }
                    else
                    {
                        myApp.isCompletedApplication = false;

                    }

                }

            }
            return myApp;
        }



        public void GetApplicationById(int iId = 0)
        {
            if (iId != 0)
            {
                DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT *,Convert(varchar,convert(date,App_emp_EmpoyementStartDate,103),103)App_emp_EmpoyementStartDate1 FROM [oscauser].[Applications] WHERE App_Id = " + iId.ToString());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this._app_id = iId;
                    this._app_Title = ds.Tables[0].Rows[0]["App_Title"].ToString();
                    this._app_FirstName = ds.Tables[0].Rows[0]["App_FirstName"].ToString();
                    this._app_Surname = ds.Tables[0].Rows[0]["App_Surname"].ToString();
                    this._app_Gender = ds.Tables[0].Rows[0]["App_Gender"].ToString();
                    this._app_DOB = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_DOB"].ToString());
                    this._app_NI = ds.Tables[0].Rows[0]["App_NI"].ToString();
                    this._app_PermAddress1 = ds.Tables[0].Rows[0]["App_PermAddress1"].ToString();
                    this._app_PermAddress2 = ds.Tables[0].Rows[0]["App_PermAddress2"].ToString();
                    this._app_PermAddress3 = ds.Tables[0].Rows[0]["App_PermAddress3"].ToString();
                    this._app_PermAddress4 = ds.Tables[0].Rows[0]["App_PermAddress4"].ToString();
                    this._app_PermAddress5 = ds.Tables[0].Rows[0]["App_PermAddress5"].ToString();
                    this._app_PermPostCode = ds.Tables[0].Rows[0]["App_PermPostCode"].ToString();
                    this._app_Email = ds.Tables[0].Rows[0]["App_Email"].ToString();
                    this._app_HomeTel = ds.Tables[0].Rows[0]["App_HomeTel"].ToString();
                    this._app_Mobile = ds.Tables[0].Rows[0]["App_Mobile"].ToString();
                    this._app_Nationality = ds.Tables[0].Rows[0]["App_Nationality"].ToString();
                    this._app_LegalResidency = ds.Tables[0].Rows[0]["App_LegalResidency"].ToString();
                    this._app_LegalResidency_doc = ds.Tables[0].Rows[0]["App_LegalResidency_doc"].ToString();
                    this._app_IsLivedEULast3Years = ds.Tables[0].Rows[0]["App_IsLivedEULast3Years"].ToString();
                    this._app_LivedEntryDate = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_LivedEntryDate"].ToString());
                    this._app_NonEUUKHowLongLiveInUK = ds.Tables[0].Rows[0]["App_NonEUUKHowLongLiveInUK"].ToString();
                    this._app_EUEEANational = ds.Tables[0].Rows[0]["App_EUEEANational"].ToString();
                    this._app_EUEEAStatus = ds.Tables[0].Rows[0]["App_EUEEAStatus"].ToString();
                    this._app_Ethnicity = ds.Tables[0].Rows[0]["App_Ethnicity"].ToString();
                    this._app_Religion = ds.Tables[0].Rows[0]["App_Religion"].ToString();
                    // this._app_SexualOrientation = ds.Tables[0].Rows[0]["App_SexualOrientation"].ToString();
                    this._app_LengthOfAddress = ds.Tables[0].Rows[0]["App_LengthOfAddress"].ToString();
                    this._app_PrePlannedAbsence = ds.Tables[0].Rows[0]["App_PrePlannedAbsence"].ToString();
                    this._app_Circumstance = ds.Tables[0].Rows[0]["App_Circumstance"].ToString();

                    this._app_AnyDisability = ds.Tables[0].Rows[0]["App_AnyDisability"].ToString();
                    this._app_AnyDisabilityPrimary = ds.Tables[0].Rows[0]["App_AnyDisabilityPrimary"].ToString();
                    this._app_AnyDisabilitySecondaries = ds.Tables[0].Rows[0]["App_AnyDisabilitySecondaries"].ToString();

                    this._app_NeedLearningSupport = ds.Tables[0].Rows[0]["App_NeedLearningSupport"].ToString();
                    this._app_HaveLearnerSupportProgram = ds.Tables[0].Rows[0]["App_HaveLearnerSupportProgram"].ToString();
                    this._app_ProgramAppliedFor = ""; // ds.Tables[0].Rows[0]["App_ProgramAppliedFor"].ToString();
                    this._app_IsAccessToComputer = ds.Tables[0].Rows[0]["App_IsAccessToComputer"].ToString();
                    this._app_IsAccessToFaceTime = ds.Tables[0].Rows[0]["App_IsAccessToFaceTime"].ToString();
                    this._app_IsAccessToEmail = ds.Tables[0].Rows[0]["App_IsAccessToEmail"].ToString();
                    this._app_IsPartnerOfOwner = ds.Tables[0].Rows[0]["App_IsPartnerOfOwner"].ToString();
                    this._app_IsEPortoflioAware = ds.Tables[0].Rows[0]["App_IsEPortoflioAware"].ToString();
                    // this._app_ManageWorkStudy = ds.Tables[0].Rows[0]["App_ManageWorkStudy"].ToString();
                    this._app_educ_HighestQual = ds.Tables[0].Rows[0]["App_educ_HighestQual"].ToString();
                    this._app_educ_IsGCSEEnglish = ds.Tables[0].Rows[0]["App_educ_IsGCSEEnglish"].ToString();
                    this._app_educ_IsGCSEMath = ds.Tables[0].Rows[0]["App_educ_IsGCSEMath"].ToString();
                    this._app_educ_EquivalentQualification = ds.Tables[0].Rows[0]["App_educ_EquivalentQualification"].ToString();

                    this._app_educ_IsEnrolledOther = ds.Tables[0].Rows[0]["App_educ_IsEnrolledOther"].ToString();
                    this._app_educ_PreviousCollege = ds.Tables[0].Rows[0]["App_educ_PreviousCollege"].ToString();
                    this._app_educ_PreviousQual = ds.Tables[0].Rows[0]["App_educ_PreviousQual"].ToString();
                    this._app_educ_PreviousTraining = ds.Tables[0].Rows[0]["App_educ_PreviousTraining"].ToString();
                    this._app_educ_IsALLFund = ds.Tables[0].Rows[0]["App_educ_IsAllFund"].ToString();
                    this._app_educ_ALLFundQualDetails = ds.Tables[0].Rows[0]["App_educ_ALLFundQualDetails"].ToString();

                    //this._app_educ_TrainingPlannedNext12Months = ds.Tables[0].Rows[0]["App_educ_TrainingPlannedNext12Months"].ToString();
                    //this._app_educ_FutureInspirations = ds.Tables[0].Rows[0]["App_educ_FutureInspirations"].ToString();
                    this._app_emp_CompanyName = ds.Tables[0].Rows[0]["App_emp_CompanyName"].ToString();
                    this._app_emp_EmpoyementStartDate = ds.Tables[0].Rows[0]["App_emp_EmpoyementStartDate1"].ToString();

                    this._app_emp_WorkPlaceAddress = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress"].ToString();
                    this._app_emp_WorkPlaceAddress1 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress1"].ToString();
                    this._app_emp_WorkPlaceAddress2 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress2"].ToString();
                    this._app_emp_WorkPlaceAddress3 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress3"].ToString();
                    this._app_emp_WorkPlaceAddress4 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress4"].ToString();
                    this._app_emp_WorkPlaceAddress5 = ds.Tables[0].Rows[0]["App_emp_WorkPlaceAddress5"].ToString();
                    this._app_emp_WorkPlacePostCode = ds.Tables[0].Rows[0]["App_emp_WorkPlacePostCode"].ToString();
                    this._app_emp_Email = ds.Tables[0].Rows[0]["App_emp_Email"].ToString();
                    this._app_emp_Tel = ds.Tables[0].Rows[0]["App_emp_Tel"].ToString();
                    this._app_emp_ContactName = ds.Tables[0].Rows[0]["App_emp_ContactName"].ToString();
                    this._app_emp_Position = ds.Tables[0].Rows[0]["App_emp_Position"].ToString();
                    this._app_emp_BusinessSector = ds.Tables[0].Rows[0]["App_emp_BusinessSector"].ToString();
                    this._app_emp_CompanyEstablished = ds.Tables[0].Rows[0]["App_emp_CompanyEstablished"].ToString();
                    this._app_emp_WeeklyHours = ds.Tables[0].Rows[0]["App_emp_WeeklyHours"].ToString();
                    this._app_emp_IsSelfEmployed = ds.Tables[0].Rows[0]["App_emp_IsSelfEmployed"].ToString();
                    //this._app_emp_IsEmployerPaying = ds.Tables[0].Rows[0]["App_emp_IsEmployerPaying"].ToString();
                    this._app_job_JobFunction = ds.Tables[0].Rows[0]["App_job_JobFunction"].ToString();
                    this._app_job_HowLongWorkingJob = ds.Tables[0].Rows[0]["App_job_HowLongWorkingJob"].ToString();
                    this._app_job_HowLongWorkingEmployer = ds.Tables[0].Rows[0]["App_job_HowLongWorkingEmployer"].ToString();
                    this._app_job_AnyPreviousManagement = ds.Tables[0].Rows[0]["App_job_AnyPreviousManagement"].ToString();
                    this._app_job_HaveCurrentDevPlan = ds.Tables[0].Rows[0]["App_job_HaveCurrentDevPlan"].ToString();
                    this._app_job_IsAwareFundamentalStd = ds.Tables[0].Rows[0]["App_job_IsAwareFundamentalStd"].ToString();
                    //this._app_job_IsResponsibleCQCPIR = ds.Tables[0].Rows[0]["App_job_IsResponsibleCQCPIR"].ToString();
                    this._app_job_IsResponsibleRecruitment = ds.Tables[0].Rows[0]["App_job_IsResponsibleRecruitment"].ToString();
                    this._app_job_IsResponsibleStaffInduction = ds.Tables[0].Rows[0]["App_job_IsResponsibleStaffInduction"].ToString();
                    this._app_job_IsResponsibleStaffAppraisal = ds.Tables[0].Rows[0]["App_job_IsResponsibleStaffAppraisal"].ToString();
                    this._app_job_IsResponsibleMonitoringStaff = ds.Tables[0].Rows[0]["App_job_IsResponsibleMonitoringStaff"].ToString();
                    // this._app_job_IsResponsibleTaskAllocationRotas = ds.Tables[0].Rows[0]["App_job_IsResponsibleTaskAllocationRotas"].ToString();
                    this._app_job_IsResponsiblePlanningReviewing = ds.Tables[0].Rows[0]["App_job_IsResponsiblePlanningReviewing"].ToString();
                    //    this._app_job_IsResponsibleOrganisingReferrals = ds.Tables[0].Rows[0]["App_job_IsResponsibleOrganisingReferrals"].ToString();
                    //    this._app_job_IsResponsibleOrganisingPartnerships = ds.Tables[0].Rows[0]["App_job_IsResponsibleOrganisingPartnerships"].ToString();
                    this._app_job_IsResponsibleEffectivenessPartnerships = ds.Tables[0].Rows[0]["App_job_IsResponsibleEffectivenessPartnerships"].ToString();
                    this._app_job_IsReviewAuditPolicies = ds.Tables[0].Rows[0]["App_job_IsReviewAuditPolicies"].ToString();
                    this._app_job_IsRespondingToComplaints = ds.Tables[0].Rows[0]["App_job_IsRespondingToComplaints"].ToString();
                    this._app_job_IsInvestigatingSafeguarding = ds.Tables[0].Rows[0]["App_job_IsInvestigatingSafeguarding"].ToString();
                    this._app_job_IsAuditFeedback = ds.Tables[0].Rows[0]["App_job_IsAuditFeedback"].ToString();
                    this._app_job_IsOrganisingLeadStaffMeetings = ds.Tables[0].Rows[0]["App_job_IsOrganisingLeadStaffMeetings"].ToString();
                    //this._app_job_IsResponsibleWritingDevPlan = ds.Tables[0].Rows[0]["App_job_IsResponsibleWritingDevPlan"].ToString();
                    //this._app_job_HaveRegularStaffMeetings = ds.Tables[0].Rows[0]["App_job_HaveRegularStaffMeetings"].ToString();
                    this._app_job_IsAttendingStrategicMeetings = ds.Tables[0].Rows[0]["App_job_IsAttendingStrategicMeetings"].ToString();
                    this._app_job_IsEnsuringComplianceHS = ds.Tables[0].Rows[0]["App_job_IsEnsuringComplianceHS"].ToString();
                    this._app_job_IsFurtherTrainingNeeded = ds.Tables[0].Rows[0]["App_job_IsFurtherTrainingNeeded"].ToString();
                    // this._app_job_IsSpecificSupportNeeded = ds.Tables[0].Rows[0]["App_job_IsSpecificSupportNeeded"].ToString();
                    this._app_job_RelevantPathway = ds.Tables[0].Rows[0]["App_job_RelevantPathway"].ToString();
                    this._app_job_HaveJobDescription = ds.Tables[0].Rows[0]["App_job_HaveJobDescription"].ToString();
                    this._app_job_HaveJobDescription_doc = ds.Tables[0].Rows[0]["App_job_HaveJobDescription_doc"].ToString();
                    //this._app_job_CarryOutAuditing = ds.Tables[0].Rows[0]["App_job_CarryOutAuditing"].ToString();

                    this._app_job_DailyMainDuties = ds.Tables[0].Rows[0]["App_job_DailyMainDuties"].ToString();
                    //this._app_job_UsualHoursAttendancy = ds.Tables[0].Rows[0]["App_job_UsualHoursAttendancy"].ToString();
                    this._app_job_OtherPositionResponsabilities = ds.Tables[0].Rows[0]["App_job_OtherPositionResponsabilities"].ToString();
                    this._app_job_AboutYourStrenghts = ds.Tables[0].Rows[0]["App_job_AboutYourStrenghts"].ToString();
                    this._app_job_AreasOfDevelopment = ds.Tables[0].Rows[0]["App_job_AreasOfDevelopment"].ToString();
                    this._app_job_AllowWorkplaceObsVisit = ds.Tables[0].Rows[0]["App_job_AllowWorkplaceObsVisit"].ToString();
                    this._app_job_Confirm16hrs = ds.Tables[0].Rows[0]["App_job_Confirm16hrs"].ToString() == "1" ? true : false;
                    this._app_job_Confirm16hrsId = ds.Tables[0].Rows[0]["App_job_Confirm16hrsId"].ToString() == "" ? 1 : int.Parse(ds.Tables[0].Rows[0]["App_job_Confirm16hrsId"].ToString());
                    this._app_job_Confirm16hrsTitle = ds.Tables[0].Rows[0]["App_job_Confirm16hrsTitle"].ToString() == "" ? "" : ds.Tables[0].Rows[0]["App_job_Confirm16hrsTitle"].ToString();

                    this._app_job_HaveStartedGLH = ds.Tables[0].Rows[0]["App_job_HaveStartedGLH"].ToString();

                    this._app_officeuse_UniqueLearnerReference = ds.Tables[0].Rows[0]["App_officeuse_UniqueLearnerReference"].ToString();
                    this._app_officeuse_StartDate = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_officeuse_StartDate"].ToString());
                    this._app_officeuse_EndDate = DSP.BAL.DBL.ConvertSQLDateToUKDate(ds.Tables[0].Rows[0]["App_officeuse_EndDate"].ToString());
                    this._app_officeuse_ApprenticeshipFramework = ds.Tables[0].Rows[0]["App_officeuse_ApprenticeshipFramework"].ToString();
                    this._app_officeuse_LearnerId = ds.Tables[0].Rows[0]["App_officeuse_LearnerId"].ToString();
                    this._app_officeuse_ReferenceId = ds.Tables[0].Rows[0]["App_officeuse_ReferenceId"].ToString();
                    this._app_officeuse_CQCInspectionDate = ds.Tables[0].Rows[0]["App_officeuse_CQCInspectionDate"].ToString();
                    this._app_officeuse_UKPRN = ds.Tables[0].Rows[0]["App_officeuse_UKPRN"].ToString();
                    this._app_officeuse_EmployerId = ds.Tables[0].Rows[0]["App_officeuse_EmployerId"].ToString();

                    this._app_officeuse_ReferenceDate = ds.Tables[0].Rows[0]["App_officeuse_ReferenceDate"].ToString();
                    this._app_officeuse_FundingId = ds.Tables[0].Rows[0]["App_officeuse_FundingId"].ToString() == "" ? 0 : int.Parse(ds.Tables[0].Rows[0]["App_officeuse_FundingId"].ToString());
                    this._app_officeuse_FundingTitle = ds.Tables[0].Rows[0]["App_officeuse_FundingTitle"].ToString() == "" ? "Full Cost" : ds.Tables[0].Rows[0]["App_officeuse_FundingTitle"].ToString();

                    this._app_officeuse_IsEvidenceSeen = ds.Tables[0].Rows[0]["App_officeuse_IsEvidenceSeen"].ToString() == "1" ? true : false;
                    this._app_officeuse_ReferenceIdType = ds.Tables[0].Rows[0]["App_officeuse_ReferenceIdType"].ToString();


                    this._app_officeuse1_IsLiteracyNumeracyDone = ds.Tables[0].Rows[0]["App_officeuse1_IsLiteracyNumeracyDone"].ToString() == "1" ? true : false;
                    this._app_officeuse1_IsAllDocumentsSigned = ds.Tables[0].Rows[0]["App_officeuse1_IsAllDocumentsSigned"].ToString() == "1" ? true : false;
                    this._app_officeuse1_IsConfirmEnrolment = ds.Tables[0].Rows[0]["App_officeuse1_IsConfirmEnrolment"].ToString() == "1" ? true : false;

                    this._app_officeuse1_CourseId = ds.Tables[0].Rows[0]["App_officeuse1_CourseId"].ToString() == "" ? 5 : int.Parse(ds.Tables[0].Rows[0]["App_officeuse1_CourseId"].ToString());
                    //this._app_officeuse1_CourseTitle = ds.Tables[0].Rows[0]["App_officeuse1_CourseTitle"].ToString() == "" ? "NOT SELECTED" : ds.Tables[0].Rows[0]["App_officeuse1_CourseTitle"].ToString();
                    this._app_officeuse1_CourseTitle = setCourseTitle(this._app_officeuse1_CourseId.ToString());
                    this._app_job_IsAssessReviewImplementCare = ds.Tables[0].Rows[0]["App_job_IsAssessReviewImplementCare"].ToString();
                    this._app_job_IsInvolvedRiskAssessment = ds.Tables[0].Rows[0]["App_job_IsInvolvedRiskAssessment"].ToString();
                    this._app_job_IsEnsureOthersFollowPolicy = ds.Tables[0].Rows[0]["App_job_IsEnsureOthersFollowPolicy"].ToString();
                    this._app_job_IsSupportServiceInPersonalCare = ds.Tables[0].Rows[0]["App_job_IsSupportServiceInPersonalCare"].ToString();
                    this._app_job_IsWorkSupportRoleServiceUsers = ds.Tables[0].Rows[0]["App_job_IsWorkSupportRoleServiceUsers"].ToString();
                    this._app_job_IsPlanReviewImplmentCare = ds.Tables[0].Rows[0]["App_job_IsPlanReviewImplmentCare"].ToString();
                    this._app_job_IsInvolvedSafeguardingInvestigations = ds.Tables[0].Rows[0]["App_job_IsInvolvedSafeguardingInvestigations"].ToString();
                    this._app_job_IsTakePartInRiskAssessment = ds.Tables[0].Rows[0]["App_job_IsTakePartInRiskAssessment"].ToString();
                    this._app_job_IsTakePartInManagingQuality = ds.Tables[0].Rows[0]["App_job_IsTakePartInManagingQuality"].ToString();

                    this._app_job_RelevantPathway_L3 = ds.Tables[0].Rows[0]["App_job_RelevantPathway_L3"].ToString();
                    this._app_job_HaveJobDescription_L3 = ds.Tables[0].Rows[0]["App_job_HaveJobDescription_L3"].ToString();
                    this._app_job_HaveJobDescription_L3_doc = ds.Tables[0].Rows[0]["App_job_HaveJobDescription_L3_doc"].ToString();

                    this._app_mktg_HearAbout = ds.Tables[0].Rows[0]["App_mktg_HearAbout"].ToString();
                    this._app_mktg_ContactConsent = ds.Tables[0].Rows[0]["App_mktg_ContactConsent"].ToString();
                    this._app_mktg_ByPhone = ds.Tables[0].Rows[0]["App_mktg_ByPhone"].ToString();
                    this._app_mktg_ByEmail = ds.Tables[0].Rows[0]["App_mktg_ByEmail"].ToString();
                    this._app_mktg_ByPost = ds.Tables[0].Rows[0]["App_mktg_ByPost"].ToString();

                    this._app_PrintName = ds.Tables[0].Rows[0]["App_PrintName"].ToString();
                    this._app_ApplicationDate = ds.Tables[0].Rows[0]["App_ApplicationDate"].ToString();
                    this._app_ACS_WDSNumber = ds.Tables[0].Rows[0]["App_ACS_WDSNumber"].ToString();

                    this._app_job_IsContributeSelfAssessment = ds.Tables[0].Rows[0]["App_job_IsContributeSelfAssessment"].ToString();
                    this._app_job_IsReviewAuditPolicy = ds.Tables[0].Rows[0]["App_job_IsReviewAuditPolicy"].ToString();
                    this._app_job_IsLeadPartnershipWorking = ds.Tables[0].Rows[0]["App_job_IsLeadPartnershipWorking"].ToString();
                    this._app_job_IsLeadProvisionDelivers = ds.Tables[0].Rows[0]["App_job_IsLeadProvisionDelivers"].ToString();
                    this._app_job_IsResponsibleKeyResources = ds.Tables[0].Rows[0]["App_job_IsResponsibleKeyResources"].ToString();
                    this._app_job_IsResponsibleStaffTraining = ds.Tables[0].Rows[0]["App_job_IsResponsibleStaffTraining"].ToString();
                    this._app_job_ExampleProjectManaged = ds.Tables[0].Rows[0]["App_job_ExampleProjectManaged"].ToString();
                    this._app_job_ExampleSupportingCarePractice = ds.Tables[0].Rows[0]["App_job_ExampleSupportingCarePractice"].ToString();
                    this._app_job_ExampleCPDRecent = ds.Tables[0].Rows[0]["App_job_ExampleCPDRecent"].ToString();
                    this._app_job_ExampleCourageImplement = ds.Tables[0].Rows[0]["App_job_ExampleCourageImplement"].ToString();
                    this._app_job_IsResponsibleManagingQuality = ds.Tables[0].Rows[0]["App_job_IsResponsibleManagingQuality"].ToString();
                    this._app_job_IsResponsibleIncludeDevelopment = ds.Tables[0].Rows[0]["App_job_IsResponsibleIncludeDevelopment"].ToString();

                    this._app_job_102_KnowledgeStatutoryFrameworks = ds.Tables[0].Rows[0]["App_job_102_KnowledgeStatutoryFrameworks"].ToString();
                    this._app_job_103_ExperienceOfManaging = ds.Tables[0].Rows[0]["App_job_103_ExperienceOfManaging"].ToString();
                    this._app_job_104_AbilityImplementStrategies = ds.Tables[0].Rows[0]["App_job_104_AbilityImplementStrategies"].ToString();
                    this._app_job_105_ExperienceLeadingSupporting = ds.Tables[0].Rows[0]["App_job_105_ExperienceLeadingSupporting"].ToString();
                    this._app_job_106_CarriedOutActivitiesMonitor = ds.Tables[0].Rows[0]["App_job_106_CarriedOutActivitiesMonitor"].ToString();
                    this._app_job_TherapySessions = ds.Tables[0].Rows[0]["App_job_TherapySessions"].ToString();

                    this._app_job_HealthPromotion = ds.Tables[0].Rows[0]["App_job_HealthPromotion"].ToString();
                    this._app_job_Advocate = ds.Tables[0].Rows[0]["App__job_Advocate"].ToString();
                    this._app_job_SupportServiceUsers = ds.Tables[0].Rows[0]["App_job_SupportServiceUsers"].ToString();

                    this._app_job_AssessReviewSupportPlans = ds.Tables[0].Rows[0]["App_job_AssessReviewSupportPlans"].ToString();
                    this._app_job_IsInvolvedInRiskAssessments = ds.Tables[0].Rows[0]["App_job_IsInvolvedInRiskAssessments"].ToString();
                    this._app_job_ContributeToMentalHealth = ds.Tables[0].Rows[0]["App_job_ContributeToMentalHealth"].ToString();
                    this._app_job_SupportIndvDepressionPhobias = ds.Tables[0].Rows[0]["App_job_SupportIndvDepressionPhobias"].ToString();
                    this._app_job_WorkinPartnershipswthProfessionals = ds.Tables[0].Rows[0]["App_job_WorkinPartnershipswthProfessionals"].ToString();
                    this._app_job_SafeguardReports = ds.Tables[0].Rows[0]["App_job_SafeguardReports"].ToString();
                    this._app_job_RecruitmentResponsibilities = ds.Tables[0].Rows[0]["App_job_RecruitmentResponsibilities"].ToString();
                    this._app_job_StaffInductionCareCertificate = ds.Tables[0].Rows[0]["App_job_StaffInductionCareCertificate"].ToString();
                    this._app_job_RespondCompliments = ds.Tables[0].Rows[0]["App_job_RespondCompliments"].ToString();
                    this._app_job_WorkMgtRole = ds.Tables[0].Rows[0]["App_job_WorkMgtRole"].ToString();
                    this._app_job_TakePartSupervisions = ds.Tables[0].Rows[0]["App_job_TakePartSupervisions"].ToString();
                    this._app_job_TakePartMeetings = ds.Tables[0].Rows[0]["App_job_TakePartMeetings"].ToString();
                    this._app_job_MaintainPersonalRecord = ds.Tables[0].Rows[0]["App_job_MaintainPersonalRecord"].ToString();
                    this._app_job_RiskAssessOthersComply = ds.Tables[0].Rows[0]["App_job_RiskAssessOthersComply"].ToString();
                    this._app_job_SafeguardInvestigations = ds.Tables[0].Rows[0]["App_job_SafeguardInvestigations"].ToString();
                    this._app_job_WorkSupportiveRole = ds.Tables[0].Rows[0]["App_job_WorkSupportiveRole"].ToString();
                    this._app_job_ReviewSupportPlans = ds.Tables[0].Rows[0]["App_job_ReviewSupportPlans"].ToString();
                    this._app_job_WorkPartnerProfessionals = ds.Tables[0].Rows[0]["App_job_WorkPartnerProfessionals"].ToString();
                    this._app_job_CVPResilience = ds.Tables[0].Rows[0]["App_job_CVPResilience"].ToString();
                    this._app_job_TechCommunication = ds.Tables[0].Rows[0]["App_job_TechCommunication"].ToString();
                    this._app_job_RegularSupervisions = ds.Tables[0].Rows[0]["App_job_RegularSupervisions"].ToString();
                    this._app_job_CarryoutRiskAssessment = ds.Tables[0].Rows[0]["App_job_CarryoutRiskAssessment"].ToString();
                    this._app_job_SupportCYP = ds.Tables[0].Rows[0]["App_job_SupportCYP"].ToString();
                    this._app_job_PositiveRiskTaking = ds.Tables[0].Rows[0]["App_job_PositiveRiskTaking"].ToString();
                    this._app_job_KeyWorker = ds.Tables[0].Rows[0]["App_job_KeyWorker"].ToString();
                    this._app_job_PlanImplementcare = ds.Tables[0].Rows[0]["App_job_PlanImplementcare"].ToString();
                    this._app_job_WriteRecordReports = ds.Tables[0].Rows[0]["App_job_WriteRecordReports"].ToString();
                    this._app_job_SocialActivitieswithServiceUser = ds.Tables[0].Rows[0]["App_job_SocialActivitieswithServiceUser"].ToString();
                    this._app_job_LeadCommunicationProcesses = ds.Tables[0].Rows[0]["App_job_LeadCommunicationProcesses"].ToString();
                    this._app_job_OrgProvidesResidentialServices = ds.Tables[0].Rows[0]["App_job_OrgProvidesResidentialServices"].ToString();
                    this._app_job_PersonalCareAssistingMoving = ds.Tables[0].Rows[0]["App_job_PersonalCareAssistingMoving"].ToString();

                    //level 2
                    this._app_job_70 = ds.Tables[0].Rows[0]["App_job_70"].ToString();
                    this._app_job_71 = ds.Tables[0].Rows[0]["App_job_71"].ToString();
                    this._app_job_72 = ds.Tables[0].Rows[0]["App_job_72"].ToString();
                    this._app_job_73 = ds.Tables[0].Rows[0]["App_job_73"].ToString();
                    this._app_job_AssistEatingDrinking = ds.Tables[0].Rows[0]["App_job_AssistEatingDrinking"].ToString();


                    // Progress_ESF
                    this._app_Esf_Q_Type_Service_Provider = ds.Tables[0].Rows[0]["App_Esf_Q_Type_Service_Provider"].ToString();
                    this._app_Esf_Q_Unique_Number = ds.Tables[0].Rows[0]["App_Esf_Q_Unique_Number"].ToString();
                    this._app_Esf_Q_Refugee = ds.Tables[0].Rows[0]["App_Esf_Q_Refugee"].ToString();
                    this._app_Esf_Q_Granted_Leave = ds.Tables[0].Rows[0]["App_Esf_Q_Granted_Leave"].ToString();
                    this._app_Esf_Q_Single_Adult = ds.Tables[0].Rows[0]["App_Esf_Q_Single_Adult"].ToString();
                    this._app_Org_Skill = ds.Tables[0].Rows[0]["App_Org_Skill"].ToString();
                    this._app_Org_Cqc = ds.Tables[0].Rows[0]["App_Org_Cqc"].ToString();
                    this._app_Org_Reg_Cqc = ds.Tables[0].Rows[0]["App_Org_Reg_Cqc"].ToString();

                    this._app_Org_Employee = ds.Tables[0].Rows[0]["App_Org_Employee"].ToString();
                    this._app_Esf_Q_Manager_Register = ds.Tables[0].Rows[0]["App_Esf_Q_Manager_Register"].ToString();
                    this._app_Org_PId = ds.Tables[0].Rows[0]["App_Org_PId"].ToString();
                    this._app_Org_Reg_Local_Authority = ds.Tables[0].Rows[0]["App_Org_Reg_Local_Authority"].ToString();
                    this._app_Esf_Q_Million_Balance = ds.Tables[0].Rows[0]["App_Esf_Q_Million_Balance"].ToString();
                    this._app_Esf_Q_Basic_English = ds.Tables[0].Rows[0]["App_Esf_Q_Basic_English"].ToString();
                    this._app_Esf_Q_Basic_Math = ds.Tables[0].Rows[0]["App_Esf_Q_Basic_Math"].ToString();
                    this._app_Esf_Q_Level_2_English = ds.Tables[0].Rows[0]["App_Esf_Q_Level_2_English"].ToString();
                    this._app_Esf_Q_Level_2_Math = ds.Tables[0].Rows[0]["App_Esf_Q_Level_2_Math"].ToString();
                    this._app_Esf_Q_High_Qualification = ds.Tables[0].Rows[0]["App_Esf_Q_High_Qualification"].ToString();


                    this._app_Esf_Q_Access_Skill_Hold = ds.Tables[0].Rows[0]["App_Esf_Q_Access_Skill_Hold"].ToString();
                    this._app_Esf_Q_European_Social = ds.Tables[0].Rows[0]["App_Esf_Q_European_Social"].ToString();
                    this._app_Esf_Q_Employee_Million = ds.Tables[0].Rows[0]["App_Esf_Q_Employee_Million"].ToString();
                    this._app_Esf_Q_Behalf = ds.Tables[0].Rows[0]["App_Esf_Q_Behalf"].ToString();
                    this._app_Esf_Q_Assessment = ds.Tables[0].Rows[0]["App_Esf_Q_Assessment"].ToString();
                    this._app_Esf_Q_Access_Skill = ds.Tables[0].Rows[0]["App_Esf_Q_Access_Skill"].ToString();
                    this._app_Esf_Q_Info_Supplied = ds.Tables[0].Rows[0]["App_Esf_Q_Info_Supplied"].ToString();
                    this._app_Esf_Q_Legally_Uk = ds.Tables[0].Rows[0]["App_Esf_Q_Legally_Uk"].ToString();


                    DataSet dsAppUser = DSP.DAL.SQL.GetRecordsBySQL("SELECT AppUser_IsCompleted FROM [oscauser].[ApplicationsUsers] WHERE AppUser_App_Id = " + iId.ToString());

                    if (dsAppUser != null && dsAppUser.Tables.Count > 0 && dsAppUser.Tables[0].Rows.Count > 0)
                    {
                        this.isCompletedApplication = (dsAppUser.Tables[0].Rows[0]["AppUser_IsCompleted"].ToString()) == "1" ? true : false;

                    }
                    else
                    {
                        this.isCompletedApplication = false;

                    }

                }

            }
            //return this;
        }

        public string GetApplicantEmailById(int iId = 0)
        {
            if (iId != 0)
            {
                DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT App_Email FROM [oscauser].[Applications] WHERE App_Id = " + iId.ToString());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds.Tables[0].Rows[0]["App_Email"].ToString();

                }

            }
            return "";
        }

        public bool SaveApplication(ApplicationForm myApp)
        {
            if (myApp != null)
            {
                string sql = " UPDATE  [oscauser].[Applications] ";
                sql += "  SET App_Title  = '" + myApp._app_Title + "' ";
                sql += " ,App_FirstName  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_FirstName) + "' ";
                sql += " ,App_Surname  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_Surname) + "' ";
                sql += " ,App_Gender  = '" + myApp._app_Gender + "' ";
                sql += " ,App_DOB  = '" + DSP.BAL.Basic.ConvertDateToSQL(myApp._app_DOB) + "' ";
                sql += " ,App_NI  = '" + Basic.FormatStringForSQL(myApp._app_NI) + "' ";
                sql += " ,App_PermAddress1  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PermAddress1) + "' ";
                sql += " ,App_PermAddress2  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PermAddress2) + "' ";
                sql += " ,App_PermAddress3  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PermAddress3) + "' ";
                sql += " ,App_PermAddress4  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PermAddress4) + "' ";
                sql += " ,App_PermAddress5  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PermAddress5) + "' ";
                sql += " ,App_PermPostCode  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PermPostCode) + "' ";
                sql += " ,App_Email  = '" + Basic.FormatStringForSQL(myApp._app_Email) + "' ";
                sql += " ,App_HomeTel  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_HomeTel) + "' ";
                sql += " ,App_Mobile  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_Mobile) + "' ";
                sql += " ,App_Nationality  = '" + myApp._app_Nationality + "' ";
                sql += " ,App_LegalResidency  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_LegalResidency) + "' ";
                sql += " ,App_LegalResidency_doc  = '" + myApp._app_LegalResidency_doc + "' ";
                sql += " ,App_IsLivedEULast3Years  = '" + myApp._app_IsLivedEULast3Years + "' ";
                if (myApp._app_LivedEntryDate != "")
                {
                    sql += " ,App_LivedEntryDate  = '" + DSP.BAL.Basic.ConvertDateToSQL(myApp._app_LivedEntryDate) + "' ";
                }
                sql += " ,App_NonEUUKHowLongLiveInUK  = '" + myApp._app_NonEUUKHowLongLiveInUK + "' ";
                sql += " ,App_EUEEANational  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_EUEEANational) + "' ";
                sql += " ,App_Ethnicity  = '" + myApp._app_Ethnicity + "' ";
                sql += " ,App_Religion  = '" + myApp._app_Religion + "' ";
                //sql += " ,App_SexualOrientation  = '" + myApp._app_SexualOrientation + "' ";
                sql += " ,App_LengthOfAddress  = '" + Basic.FormatStringForSQL(myApp._app_LengthOfAddress) + "' ";
                sql += " ,App_PrePlannedAbsence  = '" + Basic.FormatStringForSQL(myApp._app_PrePlannedAbsence) + "' ";
                sql += " ,App_Circumstance  = '" + myApp._app_Circumstance + "' ";

                sql += " ,App_AnyDisability  = '" + myApp._app_AnyDisability + "' ";
                sql += " ,App_AnyDisabilityPrimary  = '" + myApp._app_AnyDisabilityPrimary + "' ";
                sql += " ,App_AnyDisabilitySecondaries  = '" + myApp._app_AnyDisabilitySecondaries + "' ";

                sql += " ,App_NeedLearningSupport  = '" + myApp._app_NeedLearningSupport + "' ";
                sql += " ,App_HaveLearnerSupportProgram  = '" + myApp._app_HaveLearnerSupportProgram + "' ";
                sql += " ,App_ProgramAppliedFor  = '' ";
                sql += " ,App_IsAccessToComputer  = '" + myApp._app_IsAccessToComputer + "' ";
                sql += " ,App_IsAccessToFaceTime  = '" + myApp._app_IsAccessToFaceTime + "' ";
                sql += " ,App_IsAccessToEmail  = '" + myApp._app_IsAccessToEmail + "' ";
                sql += " ,App_IsPartnerOfOwner  = '" + myApp._app_IsPartnerOfOwner + "' ";
                sql += " ,App_IsEPortoflioAware  = '" + myApp._app_IsEPortoflioAware + "' ";
                //sql += " ,App_ManageWorkStudy  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_ManageWorkStudy) + "' ";
                sql += " ,App_educ_HighestQual  = '" + myApp._app_educ_HighestQual + "' ";
                sql += " ,App_educ_IsGCSEEnglish  = '" + myApp._app_educ_IsGCSEEnglish + "' ";
                sql += " ,App_educ_IsGCSEMath  = '" + myApp._app_educ_IsGCSEMath + "' ";
                sql += " ,App_educ_EquivalentQualification  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_EquivalentQualification) + "' ";

                sql += " ,App_educ_IsEnrolledOther  = '" + myApp._app_educ_IsEnrolledOther + "' ";
                sql += " ,App_educ_PreviousCollege  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_PreviousCollege) + "' ";
                sql += " ,App_educ_PreviousQual  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_PreviousQual) + "' ";
                sql += " ,App_educ_PreviousTraining  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_PreviousTraining) + "' ";
                sql += " ,App_educ_IsALLFund  = '" + myApp._app_educ_IsALLFund + "' ";
                sql += " ,App_educ_ALLFundQualDetails  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_ALLFundQualDetails) + "' ";

                //sql += " ,App_educ_TrainingPlannedNext12Months  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_TrainingPlannedNext12Months) + "' ";
                //sql += " ,App_educ_FutureInspirations  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_educ_FutureInspirations) + "' ";
                sql += " ,App_emp_CompanyName  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_CompanyName) + "' ";
                sql += " ,App_emp_EmpoyementStartDate  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_EmpoyementStartDate) + "' ";

                sql += " ,App_emp_WorkPlaceAddress  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlaceAddress) + "' ";
                sql += " ,App_emp_WorkPlaceAddress1  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlaceAddress1) + "' ";
                sql += " ,App_emp_WorkPlaceAddress2  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlaceAddress2) + "' ";
                sql += " ,App_emp_WorkPlaceAddress3  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlaceAddress3) + "' ";
                sql += " ,App_emp_WorkPlaceAddress4  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlaceAddress4) + "' ";
                sql += " ,App_emp_WorkPlaceAddress5  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlaceAddress5) + "' ";
                sql += " ,App_emp_WorkPlacePostCode  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WorkPlacePostCode) + "' ";
                sql += " ,App_emp_Email  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_Email) + "' ";
                sql += " ,App_emp_Tel  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_Tel) + "' ";
                sql += " ,App_emp_ContactName  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_ContactName) + "' ";
                sql += " ,App_emp_Position  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_Position) + "' ";
                sql += " ,App_emp_BusinessSector  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_BusinessSector) + "' ";
                sql += " ,App_emp_CompanyEstablished  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_CompanyEstablished) + "' ";
                sql += " ,App_emp_WeeklyHours  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_emp_WeeklyHours) + "' ";
                sql += " ,App_emp_IsSelfEmployed  = '" + myApp._app_emp_IsSelfEmployed + "' ";
                //sql += " ,App_emp_IsEmployerPaying  = '" + myApp._app_emp_IsEmployerPaying + "' ";
                sql += " ,App_job_JobFunction  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_JobFunction) + "' ";
                sql += " ,App_job_HowLongWorkingJob  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_HowLongWorkingJob) + "' ";
                sql += " ,App_job_HowLongWorkingEmployer  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_HowLongWorkingEmployer) + "' ";
                sql += " ,App_job_AnyPreviousManagement  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_AnyPreviousManagement) + "' ";
                sql += " ,App_job_HaveCurrentDevPlan  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_HaveCurrentDevPlan) + "' ";
                sql += " ,App_job_IsAwareFundamentalStd  = '" + myApp._app_job_IsAwareFundamentalStd + "' ";
                //sql += " ,App_job_IsResponsibleCQCPIR  = '" + myApp._app_job_IsResponsibleCQCPIR + "' ";
                sql += " ,App_job_IsResponsibleRecruitment  = '" + myApp._app_job_IsResponsibleRecruitment + "' ";
                sql += " ,App_job_IsResponsibleStaffInduction  = '" + myApp._app_job_IsResponsibleStaffInduction + "' ";
                sql += " ,App_job_IsResponsibleStaffAppraisal  = '" + myApp._app_job_IsResponsibleStaffAppraisal + "' ";
                sql += " ,App_job_IsResponsibleMonitoringStaff  = '" + myApp._app_job_IsResponsibleMonitoringStaff + "' ";
                //  sql += " ,App_job_IsResponsibleTaskAllocationRotas  = '" + myApp._app_job_IsResponsibleTaskAllocationRotas + "' ";
                sql += " ,App_job_IsResponsiblePlanningReviewing  = '" + myApp._app_job_IsResponsiblePlanningReviewing + "' ";
                //   sql += " ,App_job_IsResponsibleOrganisingReferrals  = '" + myApp._app_job_IsResponsibleOrganisingReferrals + "' ";
                //   sql += " ,App_job_IsResponsibleOrganisingPartnerships  = '" + myApp._app_job_IsResponsibleOrganisingPartnerships + "' ";
                sql += " ,App_job_IsResponsibleEffectivenessPartnerships  = '" + myApp._app_job_IsResponsibleEffectivenessPartnerships + "' ";
                sql += " ,App_job_IsReviewAuditPolicies  = '" + myApp._app_job_IsReviewAuditPolicies + "' ";
                sql += " ,App_job_IsRespondingToComplaints  = '" + myApp._app_job_IsRespondingToComplaints + "' ";
                sql += " ,App_job_IsInvestigatingSafeguarding  = '" + myApp._app_job_IsInvestigatingSafeguarding + "' ";
                sql += " ,App_job_IsAuditFeedback  = '" + myApp._app_job_IsAuditFeedback + "' ";
                sql += " ,App_job_IsOrganisingLeadStaffMeetings  = '" + myApp._app_job_IsOrganisingLeadStaffMeetings + "' ";
                //sql += " ,App_job_IsResponsibleWritingDevPlan  = '" + myApp._app_job_IsResponsibleWritingDevPlan + "' ";
                //sql += " ,App_job_HaveRegularStaffMeetings  = '" + myApp._app_job_HaveRegularStaffMeetings + "' ";
                sql += " ,App_job_IsAttendingStrategicMeetings  = '" + myApp._app_job_IsAttendingStrategicMeetings + "' ";
                sql += " ,App_job_IsEnsuringComplianceHS  = '" + myApp._app_job_IsEnsuringComplianceHS + "' ";
                sql += " ,App_job_IsFurtherTrainingNeeded  = '" + myApp._app_job_IsFurtherTrainingNeeded + "' ";
                //sql += " ,App_job_IsSpecificSupportNeeded  = '" + myApp._app_job_IsSpecificSupportNeeded + "' ";
                sql += " ,App_job_RelevantPathway  = '" + myApp._app_job_RelevantPathway + "' ";
                sql += " ,App_job_HaveJobDescription  = '" + Basic.FormatStringForSQL(myApp._app_job_HaveJobDescription) + "' ";
                sql += " ,App_job_HaveJobDescription_doc  = '" + Basic.FormatStringForSQL(myApp._app_job_HaveJobDescription_doc) + "' ";
                // sql += " ,App_job_CarryOutAuditing  = '" + myApp._app_job_CarryOutAuditing + "' ";

                sql += " ,App_job_DailyMainDuties  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_DailyMainDuties) + "' ";
                //sql += " ,App_job_UsualHoursAttendancy  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_UsualHoursAttendancy) + "' ";
                sql += " ,App_job_OtherPositionResponsabilities  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_OtherPositionResponsabilities) + "' ";
                sql += " ,App_job_AboutYourStrenghts  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_AboutYourStrenghts) + "' ";
                sql += " ,App_job_AreasOfDevelopment  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_job_AreasOfDevelopment) + "' ";
                sql += " ,App_job_AllowWorkplaceObsVisit  = '" + myApp._app_job_AllowWorkplaceObsVisit + "' ";
                sql += " ,App_job_Confirm16hrs  = '" + (myApp._app_job_Confirm16hrs == true ? "1" : "0") + "' ";
                sql += " ,App_job_Confirm16hrsId  = '" + Basic.FormatStringForSQL(myApp._app_job_Confirm16hrsId.ToString()) + "' ";
                sql += " ,App_job_Confirm16hrsTitle  = '" + Basic.FormatStringForSQL(myApp._app_job_Confirm16hrsTitle.ToString()) + "' ";

                sql += " ,App_job_HaveStartedGLH  = '" + myApp._app_job_HaveStartedGLH + "' ";
                sql += " ,App_officeuse_UniqueLearnerReference  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_officeuse_UniqueLearnerReference) + "' ";

                if (myApp._app_officeuse_StartDate != "")
                {
                    sql += " ,App_officeuse_StartDate  = '" + DSP.BAL.Basic.ConvertDateToSQL(myApp._app_officeuse_StartDate) + "' ";
                }
                if (myApp._app_officeuse_EndDate != "")
                {
                    sql += " ,App_officeuse_EndDate  = '" + DSP.BAL.Basic.ConvertDateToSQL(myApp._app_officeuse_EndDate) + "' ";
                }
                sql += " ,App_officeuse_ApprenticeshipFramework  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_officeuse_ApprenticeshipFramework) + "' ";
                sql += " ,App_officeuse_LearnerId  = '" + Basic.FormatStringForSQL(myApp._app_officeuse_LearnerId) + "' ";
                sql += " ,App_officeuse_ReferenceId  = '" + Basic.FormatStringForSQL(myApp._app_officeuse_ReferenceId) + "' ";
                sql += " ,App_officeuse_CQCInspectionDate  = '" + myApp._app_officeuse_CQCInspectionDate + "' ";
                sql += " ,App_officeuse_UKPRN  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_officeuse_UKPRN) + "' ";
                sql += " ,App_officeuse_EmployerId  = '" + myApp._app_officeuse_EmployerId + "' ";

                sql += " ,App_officeuse_ReferenceDate  = '" + myApp._app_officeuse_ReferenceDate + "' ";
                sql += " ,App_officeuse_IsEvidenceSeen  = '" + (myApp._app_officeuse_IsEvidenceSeen == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse_ReferenceIdType  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_officeuse_ReferenceIdType) + "' ";


                sql += " ,App_officeuse_FundingId  = '" + myApp._app_officeuse_FundingId.ToString() + "' ";
                sql += " ,App_officeuse_FundingTitle  = '" + Basic.FormatStringForSQL(myApp._app_officeuse_FundingTitle.ToString()) + "' ";

                sql += " ,App_officeuse1_IsLiteracyNumeracyDone  = '" + (myApp._app_officeuse1_IsLiteracyNumeracyDone == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse1_IsAllDocumentsSigned  = '" + (myApp._app_officeuse1_IsAllDocumentsSigned == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse1_IsConfirmEnrolment  = '" + (myApp._app_officeuse1_IsConfirmEnrolment == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse1_CourseId  = '" + myApp._app_officeuse1_CourseId.ToString() + "' ";
                //sql += " ,App_officeuse1_CourseTitle  = '" + Basic.FormatStringForSQL(myApp._app_officeuse1_CourseTitle.ToString()) + "' ";
                sql += " ,App_officeuse1_CourseTitle= '" + setCourseTitle(myApp._app_officeuse1_CourseId.ToString()) + "'";
                sql += " ,App_job_IsAssessReviewImplementCare = '" + myApp._app_job_IsAssessReviewImplementCare + "' ";
                sql += " ,App_job_IsInvolvedRiskAssessment = '" + myApp._app_job_IsInvolvedRiskAssessment + "' ";
                sql += " ,App_job_IsEnsureOthersFollowPolicy = '" + myApp._app_job_IsEnsureOthersFollowPolicy + "' ";
                sql += " ,App_job_IsSupportServiceInPersonalCare = '" + myApp._app_job_IsSupportServiceInPersonalCare + "' ";
                sql += " ,App_job_IsWorkSupportRoleServiceUsers = '" + myApp._app_job_IsWorkSupportRoleServiceUsers + "' ";
                sql += " ,App_job_IsPlanReviewImplmentCare = '" + myApp._app_job_IsPlanReviewImplmentCare + "' ";
                sql += " ,App_job_IsInvolvedSafeguardingInvestigations = '" + myApp._app_job_IsInvolvedSafeguardingInvestigations + "' ";
                sql += " ,App_job_IsTakePartInRiskAssessment = '" + myApp._app_job_IsTakePartInRiskAssessment + "' ";
                sql += " ,App_job_IsTakePartInManagingQuality = '" + myApp._app_job_IsTakePartInManagingQuality + "' ";

                sql += " ,App_job_RelevantPathway_L3  = '" + myApp._app_job_RelevantPathway_L3 + "' ";
                sql += " ,App_job_HaveJobDescription_L3  = '" + myApp._app_job_HaveJobDescription_L3 + "' ";
                sql += " ,App_job_HaveJobDescription_L3_doc  = '" + myApp._app_job_HaveJobDescription_L3_doc + "' ";

                sql += " ,App_mktg_HearAbout  = '" + myApp._app_mktg_HearAbout + "' ";
                sql += " ,App_mktg_ContactConsent  = '" + myApp._app_mktg_ContactConsent + "' ";
                sql += " ,App_mktg_ByPhone  = '" + myApp._app_mktg_ByPhone + "' ";
                sql += " ,App_mktg_ByEmail  = '" + myApp._app_mktg_ByEmail + "' ";
                sql += " ,App_mktg_ByPost  = '" + myApp._app_mktg_ByPost + "' ";

                sql += " ,App_PrintName  = '" + DSP.BAL.Basic.FormatStringForSQL(myApp._app_PrintName) + "' ";
                sql += " ,App_ApplicationDate  = '" + myApp._app_ApplicationDate + "' ";
                sql += " ,App_ACS_WDSNumber  = '" + Basic.FormatStringForSQL(myApp._app_ACS_WDSNumber) + "' ";

                sql += " ,App_job_IsContributeSelfAssessment  = '" + myApp._app_job_IsContributeSelfAssessment + "' ";
                sql += " ,App_job_IsReviewAuditPolicy  = '" + myApp._app_job_IsReviewAuditPolicy + "' ";
                sql += " ,App_job_IsLeadPartnershipWorking  = '" + myApp._app_job_IsLeadPartnershipWorking + "' ";
                sql += " ,App_job_IsLeadProvisionDelivers  = '" + myApp._app_job_IsLeadProvisionDelivers + "' ";
                sql += " ,App_job_IsResponsibleKeyResources  = '" + myApp._app_job_IsResponsibleKeyResources + "' ";
                sql += " ,App_job_IsResponsibleStaffTraining  = '" + myApp._app_job_IsResponsibleStaffTraining + "' ";
                sql += " ,App_job_ExampleProjectManaged  = '" + Basic.FormatStringForSQL(myApp._app_job_ExampleProjectManaged) + "' ";
                sql += " ,App_job_ExampleSupportingCarePractice  = '" + Basic.FormatStringForSQL(myApp._app_job_ExampleSupportingCarePractice) + "' ";
                sql += " ,App_job_ExampleCPDRecent  = '" + Basic.FormatStringForSQL(myApp._app_job_ExampleCPDRecent) + "' ";
                sql += " ,App_job_ExampleCourageImplement  = '" + Basic.FormatStringForSQL(myApp._app_job_ExampleCourageImplement) + "' ";
                sql += " ,App_job_IsResponsibleManagingQuality  = '" + Basic.FormatStringForSQL(myApp._app_job_IsResponsibleManagingQuality) + "' ";
                sql += " ,App_job_IsResponsibleIncludeDevelopment  = '" + Basic.FormatStringForSQL(myApp._app_job_IsResponsibleIncludeDevelopment) + "' ";

                sql += " ,App_job_102_KnowledgeStatutoryFrameworks = '" + myApp._app_job_102_KnowledgeStatutoryFrameworks + "' ";
                sql += " ,App_job_103_ExperienceOfManaging = '" + myApp._app_job_103_ExperienceOfManaging + "' ";
                sql += " ,App_job_104_AbilityImplementStrategies = '" + myApp._app_job_104_AbilityImplementStrategies + "' ";
                sql += " ,App_job_105_ExperienceLeadingSupporting = '" + myApp._app_job_105_ExperienceLeadingSupporting + "' ";
                sql += " ,App_job_106_CarriedOutActivitiesMonitor = '" + myApp._app_job_106_CarriedOutActivitiesMonitor + "' ";
                sql += " ,App_EUEEAStatus = '" + myApp._app_EUEEAStatus + "' ";
                sql += " ,App_job_TherapySessions  = '" + myApp._app_job_TherapySessions + "' ";

                sql += " ,App_job_HealthPromotion  = '" + myApp._app_job_HealthPromotion + "' ";
                sql += " ,App__job_Advocate  = '" + myApp._app_job_Advocate + "' ";
                sql += " ,App_job_SupportServiceUsers  = '" + myApp._app_job_SupportServiceUsers + "' ";

                sql += " ,App_job_AssessReviewSupportPlans  = '" + myApp._app_job_AssessReviewSupportPlans + "' ";
                sql += " ,App_job_IsInvolvedInRiskAssessments  = '" + myApp._app_job_IsInvolvedInRiskAssessments + "' ";
                sql += " ,App_job_ContributeToMentalHealth  = '" + myApp._app_job_ContributeToMentalHealth + "' ";
                sql += " ,App_job_SupportIndvDepressionPhobias  = '" + myApp._app_job_SupportIndvDepressionPhobias + "' ";
                sql += " ,App_job_WorkinPartnershipswthProfessionals  = '" + myApp._app_job_WorkinPartnershipswthProfessionals + "' ";
                sql += " ,App_job_SafeguardReports  = '" + myApp._app_job_SafeguardReports + "' ";
                sql += " ,App_job_RecruitmentResponsibilities  = '" + myApp._app_job_RecruitmentResponsibilities + "' ";
                sql += " ,App_job_StaffInductionCareCertificate = '" + myApp._app_job_StaffInductionCareCertificate + "' ";
                sql += " ,App_job_RespondCompliments  = '" + myApp._app_job_RespondCompliments + "' ";
                sql += " ,App_job_WorkMgtRole  = '" + myApp._app_job_WorkMgtRole + "' ";
                sql += " ,App_job_TakePartSupervisions  = '" + myApp._app_job_TakePartSupervisions + "' ";
                sql += " ,App_job_TakePartMeetings  = '" + myApp._app_job_TakePartMeetings + "' ";
                sql += " ,App_job_MaintainPersonalRecord  = '" + myApp._app_job_MaintainPersonalRecord + "' ";
                sql += " ,App_job_RiskAssessOthersComply  = '" + myApp._app_job_RiskAssessOthersComply + "' ";
                sql += " ,App_job_SafeguardInvestigations  = '" + myApp._app_job_SafeguardInvestigations + "' ";
                sql += " ,App_job_WorkSupportiveRole  = '" + myApp._app_job_WorkSupportiveRole + "' ";
                sql += " ,App_job_ReviewSupportPlans  = '" + myApp._app_job_ReviewSupportPlans + "' ";
                sql += " ,App_job_WorkPartnerProfessionals  = '" + myApp._app_job_WorkPartnerProfessionals + "' ";
                sql += " ,App_job_CVPResilience  = '" + myApp._app_job_CVPResilience + "' ";
                sql += " ,App_job_TechCommunication  = '" + myApp._app_job_TechCommunication + "' ";
                sql += " ,App_job_RegularSupervisions  = '" + myApp._app_job_RegularSupervisions + "' ";
                sql += " ,App_job_CarryoutRiskAssessment  = '" + myApp._app_job_CarryoutRiskAssessment + "' ";
                sql += " ,App_job_SupportCYP  = '" + myApp._app_job_SupportCYP + "' ";
                sql += " ,App_job_PositiveRiskTaking  = '" + myApp._app_job_PositiveRiskTaking + "' ";
                sql += " ,App_job_KeyWorker  = '" + myApp._app_job_KeyWorker + "' ";
                sql += " ,App_job_PlanImplementcare  = '" + myApp._app_job_PlanImplementcare + "' ";
                sql += " ,App_job_WriteRecordReports  = '" + myApp._app_job_WriteRecordReports + "' ";
                sql += " ,App_job_SocialActivitieswithServiceUser  = '" + myApp._app_job_SocialActivitieswithServiceUser + "' ";
                sql += " ,App_job_LeadCommunicationProcesses  = '" + myApp._app_job_LeadCommunicationProcesses + "' ";
                sql += " ,App_job_OrgProvidesResidentialServices  = '" + myApp._app_job_OrgProvidesResidentialServices + "' ";
                sql += " ,App_job_PersonalCareAssistingMoving  = '" + myApp._app_job_PersonalCareAssistingMoving + "' ";
                sql += " ,App_job_AssistEatingDrinking  = '" + myApp._app_job_AssistEatingDrinking + "' ";
                sql += " ,App_job_70  = '" + myApp._app_job_70 + "' ";
                sql += " ,App_job_71  = '" + myApp._app_job_71 + "' ";
                sql += " ,App_job_72  = '" + myApp._app_job_72 + "' ";
                sql += " ,App_job_73  = '" + myApp._app_job_73 + "' ";

                // rahmat
                
                sql += " ,App_Esf_Q_Unique_Number  = '" + myApp._app_Esf_Q_Unique_Number + "' ";
                sql += " ,App_Esf_Q_Refugee  = '" + myApp._app_Esf_Q_Refugee + "' ";
                sql += " ,App_Esf_Q_Granted_Leave  = '" + myApp._app_Esf_Q_Granted_Leave + "' ";
                sql += " ,App_Esf_Q_Single_Adult  = '" + myApp._app_Esf_Q_Single_Adult + "' ";
                sql += " ,App_Esf_Q_Manger_Register  = '" + myApp._app_Esf_Q_Manager_Register + "' ";
                sql += " ,App_Esf_Q_Million_Balance  = '" + myApp._app_Esf_Q_Million_Balance + "' ";
                sql += " ,App_Esf_Q_Type_Service_Provider  = '" + myApp._app_Esf_Q_Type_Service_Provider + "' ";
                sql += " ,App_Esf_Q_Basic_Math  = '" + myApp._app_Esf_Q_Basic_Math + "' ";
                sql += " ,App_Esf_Q_Basic_English  = '" + myApp._app_Esf_Q_Basic_English + "' ";
                sql += " ,App_Esf_Q_Level_2_Math  = '" + myApp._app_Esf_Q_Level_2_Math + "' ";
                sql += " ,App_Esf_Q_Level_2_English  = '" + myApp._app_Esf_Q_Level_2_English + "' ";
                sql += " ,App_Esf_Q_Hight_Qualification  = '" + myApp._app_Esf_Q_High_Qualification + "' ";

                sql += " ,App_Org_PId  = '" + myApp._app_Org_PId + "' ";
                sql += " ,App_Org_Reg_Local_Authority  = '" + myApp._app_Org_Reg_Local_Authority + "' ";

                sql += " ,App_Org_Skill  = '" + myApp._app_Org_Skill + "' ";
                sql += " ,App_Org_Cqc  = '" + myApp._app_Org_Cqc + "' ";
                sql += " ,App_Org_Reg_Cqc  = '" + myApp._app_Org_Reg_Cqc + "' ";
                sql += " ,App_Org_Employee  = '" + myApp._app_Org_Employee + "' ";




                sql += " ,App_Esf_Q_Access_Skill_Hold  = '" + myApp._app_Esf_Q_Access_Skill_Hold + "' ";
                sql += " ,App_Esf_Q_European_Social  = '" + myApp._app_Esf_Q_European_Social + "' ";
                sql += " ,App_Esf_Q_Employee_Million  = '" + myApp._app_Esf_Q_Employee_Million + "' ";
                sql += " ,App_Esf_Q_Behalf  = '" + myApp._app_Esf_Q_Behalf + "' ";

                sql += " ,App_Esf_Q_Assessment  = '" + myApp._app_Esf_Q_Assessment + "' ";
                sql += " ,App_Esf_Q_Access_Skill  = '" + myApp._app_Esf_Q_Access_Skill + "' ";
                sql += " ,App_Esf_Q_Info_Supplied  = '" + myApp._app_Esf_Q_Info_Supplied + "' ";
                sql += " ,App_Esf_Q_Legally_Uk  = '" + myApp._app_Esf_Q_Legally_Uk + "' ";

                sql += " )";

                sql += " WHERE App_Id = " + myApp._app_id;

                DSP.DAL.SQL.ExecuteSQL(sql);


            }

            return true;


        }
        public bool SaveApplication()
        {
            if (_app_id != 0)
            {
                string sql = " UPDATE  [oscauser].[Applications] ";
                sql += "  SET App_Title  = '" + Basic.FormatStringForSQL(_app_Title) + "' ";
                sql += " ,App_FirstName  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_FirstName) + "' ";
                sql += " ,App_Surname  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_Surname) + "' ";
                sql += " ,App_Gender  = '" + _app_Gender + "' ";
                if (_app_DOB != "")
                {
                    sql += " ,App_DOB  = convert(datetime,'" + _app_DOB + "',103) ";

                }
                sql += " ,App_NI  = '" + Basic.FormatStringForSQL(_app_NI) + "' ";
                sql += " ,App_PermAddress1  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PermAddress1) + "' ";
                sql += " ,App_PermAddress2  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PermAddress2) + "' ";
                sql += " ,App_PermAddress3  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PermAddress3) + "' ";
                sql += " ,App_PermAddress4  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PermAddress4) + "' ";
                sql += " ,App_PermAddress5  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PermAddress5) + "' ";
                sql += " ,App_PermPostCode  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PermPostCode) + "' ";
                sql += " ,App_Email  = '" + Basic.FormatStringForSQL(_app_Email) + "' ";
                sql += " ,App_HomeTel  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_HomeTel) + "' ";
                sql += " ,App_Mobile  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_Mobile) + "' ";
                sql += " ,App_Nationality  = '" + _app_Nationality + "' ";
                sql += " ,App_LegalResidency  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_LegalResidency) + "' ";
                sql += " ,App_LegalResidency_doc  = '" + Basic.FormatStringForSQL(_app_LegalResidency_doc) + "' ";
                sql += " ,App_IsLivedEULast3Years  = '" + _app_IsLivedEULast3Years + "' ";

                if (_app_LivedEntryDate != "")
                {
                    sql += " ,App_LivedEntryDate  = convert(datetime,'" + _app_LivedEntryDate + "',103)";

                }
                sql += " ,App_NonEUUKHowLongLiveInUK  = '" + Basic.FormatStringForSQL(_app_NonEUUKHowLongLiveInUK) + "' ";
                sql += " ,App_EUEEANational  = '" + Basic.FormatStringForSQL(_app_EUEEANational) + "' ";
                sql += " ,App_Ethnicity  = '" + _app_Ethnicity + "' ";
                sql += " ,App_Religion  = '" + _app_Religion + "' ";
                // sql += " ,App_SexualOrientation  = '" + _app_SexualOrientation + "' ";
                sql += " ,App_LengthOfAddress  = '" + Basic.FormatStringForSQL(_app_LengthOfAddress) + "' ";
                sql += " ,App_PrePlannedAbsence  = '" + Basic.FormatStringForSQL(_app_PrePlannedAbsence) + "' ";
                sql += " ,App_Circumstance  = '" + _app_Circumstance + "' ";

                sql += " ,App_AnyDisability  = '" + _app_AnyDisability + "' ";
                sql += " ,App_AnyDisabilityPrimary  = '" + _app_AnyDisabilityPrimary + "' ";
                sql += " ,App_AnyDisabilitySecondaries  = '" + Basic.FormatStringForSQL(_app_AnyDisabilitySecondaries) + "' ";

                sql += " ,App_NeedLearningSupport  = '" + _app_NeedLearningSupport + "' ";
                sql += " ,App_HaveLearnerSupportProgram  = '" + _app_HaveLearnerSupportProgram + "' ";
                //     sql += " ,App_ProgramAppliedFor  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_ProgramAppliedFor) + "' ";
                sql += " ,App_ProgramAppliedFor  = '' ";
                sql += " ,App_IsAccessToComputer  = '" + _app_IsAccessToComputer + "' ";
                sql += " ,App_IsAccessToFaceTime  = '" + _app_IsAccessToFaceTime + "' ";
                sql += " ,App_IsAccessToEmail  = '" + _app_IsAccessToEmail + "' ";
                sql += " ,App_IsPartnerOfOwner  = '" + _app_IsPartnerOfOwner + "' ";
                sql += " ,App_IsEPortoflioAware  = '" + _app_IsEPortoflioAware + "' ";
                //sql += " ,App_ManageWorkStudy  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_ManageWorkStudy) + "' ";
                sql += " ,App_educ_HighestQual  = '" + _app_educ_HighestQual + "' ";
                sql += " ,App_educ_IsGCSEEnglish  = '" + _app_educ_IsGCSEEnglish + "' ";
                sql += " ,App_educ_IsGCSEMath  = '" + _app_educ_IsGCSEMath + "' ";
                sql += " ,App_educ_EquivalentQualification  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_EquivalentQualification) + "' ";

                sql += " ,App_educ_IsEnrolledOther  = '" + _app_educ_IsEnrolledOther + "' ";
                sql += " ,App_educ_PreviousCollege  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_PreviousCollege) + "' ";
                sql += " ,App_educ_PreviousQual  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_PreviousQual) + "' ";
                sql += " ,App_educ_PreviousTraining  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_PreviousTraining) + "' ";
                sql += " ,App_educ_IsAllFund  = '" + _app_educ_IsALLFund + "' ";
                sql += " ,App_educ_ALLFundQualDetails = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_ALLFundQualDetails) + "' ";
                //sql += " ,App_educ_TrainingPlannedNext12Months  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_TrainingPlannedNext12Months) + "' ";
                //sql += " ,App_educ_FutureInspirations  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_educ_FutureInspirations) + "' ";
                sql += " ,App_emp_CompanyName  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_CompanyName) + "' ";
                //sql += " ,App_emp_EmpoyementStartDate  = '" + DateTime.Parse(_app_emp_EmpoyementStartDate.Trim()) + "' ";
                sql += " ,App_emp_EmpoyementStartDate  = convert(datetime, '" + _app_emp_EmpoyementStartDate + "',103)";
                sql += " ,App_emp_WorkPlaceAddress  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlaceAddress) + "' ";
                sql += " ,App_emp_WorkPlaceAddress1  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlaceAddress1) + "' ";
                sql += " ,App_emp_WorkPlaceAddress2  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlaceAddress2) + "' ";
                sql += " ,App_emp_WorkPlaceAddress3  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlaceAddress3) + "' ";
                sql += " ,App_emp_WorkPlaceAddress4  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlaceAddress4) + "' ";
                sql += " ,App_emp_WorkPlaceAddress5  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlaceAddress5) + "' ";
                sql += " ,App_emp_WorkPlacePostCode  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WorkPlacePostCode) + "' ";
                sql += " ,App_emp_Email  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_Email) + "' ";
                sql += " ,App_emp_Tel  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_Tel) + "' ";
                sql += " ,App_emp_ContactName  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_ContactName) + "' ";
                sql += " ,App_emp_Position  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_Position) + "' ";
                sql += " ,App_emp_BusinessSector  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_BusinessSector) + "' ";
                sql += " ,App_emp_CompanyEstablished  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_CompanyEstablished) + "' ";
                sql += " ,App_emp_WeeklyHours  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_emp_WeeklyHours) + "' ";
                sql += " ,App_emp_IsSelfEmployed  = '" + _app_emp_IsSelfEmployed + "' ";
                //sql += " ,App_emp_IsEmployerPaying  = '" + _app_emp_IsEmployerPaying + "' ";
                sql += " ,App_job_JobFunction  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_JobFunction) + "' ";
                sql += " ,App_job_HowLongWorkingJob  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_HowLongWorkingJob) + "' ";
                sql += " ,App_job_HowLongWorkingEmployer  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_HowLongWorkingEmployer) + "' ";
                sql += " ,App_job_AnyPreviousManagement  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_AnyPreviousManagement) + "' ";
                sql += " ,App_job_HaveCurrentDevPlan  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_HaveCurrentDevPlan) + "' ";
                sql += " ,App_job_IsAwareFundamentalStd  = '" + _app_job_IsAwareFundamentalStd + "' ";
                //sql += " ,App_job_IsResponsibleCQCPIR  = '" + _app_job_IsResponsibleCQCPIR + "' ";
                sql += " ,App_job_IsResponsibleRecruitment  = '" + _app_job_IsResponsibleRecruitment + "' ";
                sql += " ,App_job_IsResponsibleStaffInduction  = '" + _app_job_IsResponsibleStaffInduction + "' ";
                sql += " ,App_job_IsResponsibleStaffAppraisal  = '" + _app_job_IsResponsibleStaffAppraisal + "' ";
                sql += " ,App_job_IsResponsibleMonitoringStaff  = '" + _app_job_IsResponsibleMonitoringStaff + "' ";
                //  sql += " ,App_job_IsResponsibleTaskAllocationRotas  = '" + _app_job_IsResponsibleTaskAllocationRotas + "' ";
                // sql += " ,App_job_IsResponsiblePlanningReviewing  = '" + _app_job_IsResponsiblePlanningReviewing + "' ";
                //  sql += " ,App_job_IsResponsibleOrganisingReferrals  = '" + _app_job_IsResponsibleOrganisingReferrals + "' ";
                //  sql += " ,App_job_IsResponsibleOrganisingPartnerships  = '" + _app_job_IsResponsibleOrganisingPartnerships + "' ";
                sql += " ,App_job_IsResponsibleEffectivenessPartnerships  = '" + _app_job_IsResponsibleEffectivenessPartnerships + "' ";
                sql += " ,App_job_IsReviewAuditPolicies  = '" + _app_job_IsReviewAuditPolicies + "' ";
                sql += " ,App_job_IsRespondingToComplaints  = '" + _app_job_IsRespondingToComplaints + "' ";
                sql += " ,App_job_IsInvestigatingSafeguarding  = '" + _app_job_IsInvestigatingSafeguarding + "' ";
                sql += " ,App_job_IsAuditFeedback  = '" + _app_job_IsAuditFeedback + "' ";
                sql += " ,App_job_IsOrganisingLeadStaffMeetings  = '" + _app_job_IsOrganisingLeadStaffMeetings + "' ";
                //sql += " ,App_job_IsResponsibleWritingDevPlan  = '" + _app_job_IsResponsibleWritingDevPlan + "' ";
                //sql += " ,App_job_HaveRegularStaffMeetings  = '" + _app_job_HaveRegularStaffMeetings + "' ";
                sql += " ,App_job_IsAttendingStrategicMeetings  = '" + _app_job_IsAttendingStrategicMeetings + "' ";
                sql += " ,App_job_IsEnsuringComplianceHS  = '" + _app_job_IsEnsuringComplianceHS + "' ";
                sql += " ,App_job_IsFurtherTrainingNeeded  = '" + _app_job_IsFurtherTrainingNeeded + "' ";
                //sql += " ,App_job_IsSpecificSupportNeeded  = '" + _app_job_IsSpecificSupportNeeded + "' ";
                sql += " ,App_job_RelevantPathway  = '" + Basic.FormatStringForSQL(_app_job_RelevantPathway) + "' ";
                sql += " ,App_job_HaveJobDescription  = '" + _app_job_HaveJobDescription + "' ";
                sql += " ,App_job_HaveJobDescription_doc  = '" + Basic.FormatStringForSQL(_app_job_HaveJobDescription_doc) + "' ";
                //sql += " ,App_job_CarryOutAuditing  = '" + _app_job_CarryOutAuditing + "' ";

                sql += " ,App_job_DailyMainDuties  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_DailyMainDuties) + "' ";
                // sql += " ,App_job_UsualHoursAttendancy  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_UsualHoursAttendancy) + "' ";
                sql += " ,App_job_OtherPositionResponsabilities  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_OtherPositionResponsabilities) + "' ";
                sql += " ,App_job_AboutYourStrenghts  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_AboutYourStrenghts) + "' ";
                sql += " ,App_job_AreasOfDevelopment  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_job_AreasOfDevelopment) + "' ";

                sql += " ,App_job_AllowWorkplaceObsVisit  = '" + _app_job_AllowWorkplaceObsVisit + "' ";
                sql += " ,App_job_Confirm16hrs  = '" + (_app_job_Confirm16hrs == true ? "1" : "0") + "' ";
                sql += " ,App_job_Confirm16hrsId  = '" + _app_job_Confirm16hrsId + "' ";
                sql += " ,App_job_Confirm16hrsTitle  = '" + Basic.FormatStringForSQL(_app_job_Confirm16hrsTitle) + "' ";

                sql += " ,App_job_HaveStartedGLH  = '" + Basic.FormatStringForSQL(_app_job_HaveStartedGLH) + "' ";

                sql += " ,App_officeuse_UniqueLearnerReference  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_officeuse_UniqueLearnerReference) + "' ";

                if (_app_officeuse_StartDate != "")
                {
                    sql += " ,App_officeuse_StartDate  = convert(datetime,'" + _app_officeuse_StartDate + "',103)";
                }

                if (_app_officeuse_EndDate != "")
                {
                    sql += " ,App_officeuse_EndDate  = convert(datetime,'" + _app_officeuse_EndDate + "',103) ";
                }
                sql += " ,App_officeuse_ApprenticeshipFramework  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_officeuse_ApprenticeshipFramework) + "' ";
                sql += " ,App_officeuse_LearnerId  = '" + Basic.FormatStringForSQL(_app_officeuse_LearnerId) + "' ";
                sql += " ,App_officeuse_ReferenceId  = '" + Basic.FormatStringForSQL(_app_officeuse_ReferenceId) + "' ";
                sql += " ,App_officeuse_CQCInspectionDate  = '" + Basic.FormatStringForSQL(_app_officeuse_CQCInspectionDate) + "' ";
                sql += " ,App_officeuse_UKPRN  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_officeuse_UKPRN) + "' ";
                sql += " ,App_officeuse_EmployerId  = '" + Basic.FormatStringForSQL(_app_officeuse_EmployerId) + "' ";

                sql += " ,App_officeuse_ReferenceDate  = '" + _app_officeuse_ReferenceDate + "' ";
                sql += " ,App_officeuse_IsEvidenceSeen  = '" + (_app_officeuse_IsEvidenceSeen == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse_ReferenceIdType  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_officeuse_ReferenceIdType) + "' ";

                sql += " ,App_officeuse_FundingId  = '" + _app_officeuse_FundingId + "' ";
                sql += " ,App_officeuse_FundingTitle  = '" + Basic.FormatStringForSQL(_app_officeuse_FundingTitle) + "' ";

                sql += " ,App_officeuse1_IsLiteracyNumeracyDone  = '" + (_app_officeuse1_IsLiteracyNumeracyDone == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse1_IsAllDocumentsSigned  = '" + (_app_officeuse1_IsAllDocumentsSigned == true ? "1" : "0") + "' ";
                sql += " ,App_officeuse1_IsConfirmEnrolment  = '" + (_app_officeuse1_IsConfirmEnrolment == true ? "1" : "0") + "' ";

                sql += " ,App_officeuse1_CourseId  = '" + _app_officeuse1_CourseId + "' ";
                //sql += " ,App_officeuse1_CourseTitle  = '" + Basic.FormatStringForSQL(_app_officeuse1_CourseTitle) + "' ";
                sql += " ,App_officeuse1_CourseTitle  = '" + setCourseTitle(_app_officeuse1_CourseId.ToString()) + "' ";
                sql += " ,App_job_IsAssessReviewImplementCare = '" + _app_job_IsAssessReviewImplementCare + "' ";
                sql += " ,App_job_IsInvolvedRiskAssessment = '" + _app_job_IsInvolvedRiskAssessment + "' ";
                sql += " ,App_job_IsEnsureOthersFollowPolicy = '" + _app_job_IsEnsureOthersFollowPolicy + "' ";
                sql += " ,App_job_IsSupportServiceInPersonalCare = '" + _app_job_IsSupportServiceInPersonalCare + "' ";
                sql += " ,App_job_IsWorkSupportRoleServiceUsers = '" + _app_job_IsWorkSupportRoleServiceUsers + "' ";
                sql += " ,App_job_IsPlanReviewImplmentCare = '" + _app_job_IsPlanReviewImplmentCare + "' ";
                sql += " ,App_job_IsInvolvedSafeguardingInvestigations = '" + _app_job_IsInvolvedSafeguardingInvestigations + "' ";
                sql += " ,App_job_IsTakePartInRiskAssessment = '" + _app_job_IsTakePartInRiskAssessment + "' ";
                sql += " ,App_job_IsTakePartInManagingQuality = '" + _app_job_IsTakePartInManagingQuality + "' ";

                sql += " ,App_job_RelevantPathway_L3  = '" + _app_job_RelevantPathway_L3 + "' ";
                sql += " ,App_job_HaveJobDescription_L3  = '" + _app_job_HaveJobDescription_L3 + "' ";
                sql += " ,App_job_HaveJobDescription_L3_doc  = '" + _app_job_HaveJobDescription_L3_doc + "' ";

                sql += " ,App_mktg_HearAbout  = '" + _app_mktg_HearAbout + "' ";
                sql += " ,App_mktg_ContactConsent  = '" + _app_mktg_ContactConsent + "' ";
                sql += " ,App_mktg_ByPhone  = '" + _app_mktg_ByPhone + "' ";
                sql += " ,App_mktg_ByEmail  = '" + _app_mktg_ByEmail + "' ";
                sql += " ,App_mktg_ByPost  = '" + _app_mktg_ByPost + "' ";

                sql += " ,App_PrintName  = '" + DSP.BAL.Basic.FormatStringForSQL(_app_PrintName) + "' ";
                sql += " ,App_ApplicationDate  = '" + _app_ApplicationDate + "' ";
                sql += " ,App_ACS_WDSNumber  = '" + Basic.FormatStringForSQL(_app_ACS_WDSNumber) + "' ";

                sql += " ,App_job_IsContributeSelfAssessment  = '" + _app_job_IsContributeSelfAssessment + "' ";
                sql += " ,App_job_IsReviewAuditPolicy  = '" + _app_job_IsReviewAuditPolicy + "' ";
                sql += " ,App_job_IsLeadPartnershipWorking  = '" + _app_job_IsLeadPartnershipWorking + "' ";
                sql += " ,App_job_IsLeadProvisionDelivers  = '" + _app_job_IsLeadProvisionDelivers + "' ";
                sql += " ,App_job_IsResponsibleKeyResources  = '" + _app_job_IsResponsibleKeyResources + "' ";
                sql += " ,App_job_IsResponsibleStaffTraining  = '" + _app_job_IsResponsibleStaffTraining + "' ";
                sql += " ,App_job_ExampleProjectManaged  = '" + Basic.FormatStringForSQL(_app_job_ExampleProjectManaged) + "' ";
                sql += " ,App_job_ExampleSupportingCarePractice  = '" + Basic.FormatStringForSQL(_app_job_ExampleSupportingCarePractice) + "' ";
                sql += " ,App_job_ExampleCPDRecent  = '" + Basic.FormatStringForSQL(_app_job_ExampleCPDRecent) + "' ";
                sql += " ,App_job_ExampleCourageImplement  = '" + Basic.FormatStringForSQL(_app_job_ExampleCourageImplement) + "' ";
                sql += " ,App_job_IsResponsibleManagingQuality  = '" + Basic.FormatStringForSQL(_app_job_IsResponsibleManagingQuality) + "' ";
                sql += " ,App_job_IsResponsibleIncludeDevelopment  = '" + Basic.FormatStringForSQL(_app_job_IsResponsibleIncludeDevelopment) + "' ";

                sql += " ,App_job_102_KnowledgeStatutoryFrameworks = '" + _app_job_102_KnowledgeStatutoryFrameworks + "' ";
                sql += " ,App_job_103_ExperienceOfManaging = '" + _app_job_103_ExperienceOfManaging + "' ";
                sql += " ,App_job_104_AbilityImplementStrategies = '" + _app_job_104_AbilityImplementStrategies + "' ";
                sql += " ,App_job_105_ExperienceLeadingSupporting = '" + _app_job_105_ExperienceLeadingSupporting + "' ";
                sql += " ,App_job_106_CarriedOutActivitiesMonitor = '" + _app_job_106_CarriedOutActivitiesMonitor + "' ";
                sql += " ,App_EUEEAStatus = '" + _app_EUEEAStatus + "' ";
                sql += " ,App_job_TherapySessions  = '" + _app_job_TherapySessions + "' ";

                sql += " ,App_job_HealthPromotion  = '" + _app_job_HealthPromotion + "' ";
                sql += " ,App__job_Advocate  = '" + _app_job_Advocate + "' ";
                sql += " ,App_job_SupportServiceUsers  = '" + _app_job_SupportServiceUsers + "' ";
                sql += " ,App_job_AssessReviewSupportPlans  = '" + _app_job_AssessReviewSupportPlans + "' ";
                sql += " ,App_job_IsInvolvedInRiskAssessments  = '" + _app_job_IsInvolvedInRiskAssessments + "' ";
                sql += " ,App_job_ContributeToMentalHealth  = '" + _app_job_ContributeToMentalHealth + "' ";
                sql += " ,App_job_SupportIndvDepressionPhobias  = '" + _app_job_SupportIndvDepressionPhobias + "' ";
                sql += " ,App_job_WorkinPartnershipswthProfessionals  = '" + _app_job_WorkinPartnershipswthProfessionals + "' ";
                sql += " ,App_job_SafeguardReports  = '" + _app_job_SafeguardReports + "' ";
                sql += " ,App_job_RecruitmentResponsibilities  = '" + _app_job_RecruitmentResponsibilities + "' ";
                sql += " ,App_job_StaffInductionCareCertificate  = '" + _app_job_StaffInductionCareCertificate + "' ";
                sql += " ,App_job_RespondCompliments  = '" + _app_job_RespondCompliments + "' ";
                sql += " ,App_job_WorkMgtRole  = '" + _app_job_WorkMgtRole + "' ";
                sql += " ,App_job_TakePartSupervisions  = '" + _app_job_TakePartSupervisions + "' ";
                sql += " ,App_job_TakePartMeetings  = '" + _app_job_TakePartMeetings + "' ";
                sql += " ,App_job_MaintainPersonalRecord  = '" + _app_job_MaintainPersonalRecord + "' ";
                sql += " ,App_job_RiskAssessOthersComply  = '" + _app_job_RiskAssessOthersComply + "' ";
                sql += " ,App_job_SafeguardInvestigations  = '" + _app_job_SafeguardInvestigations + "' ";
                sql += " ,App_job_WorkSupportiveRole  = '" + _app_job_WorkSupportiveRole + "' ";
                sql += " ,App_job_ReviewSupportPlans  = '" + _app_job_ReviewSupportPlans + "' ";
                sql += " ,App_job_WorkPartnerProfessionals  = '" + _app_job_WorkPartnerProfessionals + "' ";
                sql += " ,App_job_CVPResilience  = '" + _app_job_CVPResilience + "' ";
                sql += " ,App_job_TechCommunication  = '" + _app_job_TechCommunication + "' ";
                sql += " ,App_job_RegularSupervisions  = '" + _app_job_RegularSupervisions + "' ";
                sql += " ,App_job_CarryoutRiskAssessment  = '" + _app_job_CarryoutRiskAssessment + "' ";
                sql += " ,App_job_SupportCYP  = '" + _app_job_SupportCYP + "' ";
                sql += " ,App_job_PositiveRiskTaking  = '" + _app_job_PositiveRiskTaking + "' ";
                sql += " ,App_job_KeyWorker  = '" + _app_job_KeyWorker + "' ";
                sql += " ,App_job_PlanImplementcare  = '" + _app_job_PlanImplementcare + "' ";
                sql += " ,App_job_WriteRecordReports  = '" + _app_job_WriteRecordReports + "' ";
                sql += " ,App_job_SocialActivitieswithServiceUser  = '" + _app_job_SocialActivitieswithServiceUser + "' ";
                sql += " ,App_job_LeadCommunicationProcesses  = '" + _app_job_LeadCommunicationProcesses + "' ";
                sql += " ,App_job_OrgProvidesResidentialServices  = '" + _app_job_OrgProvidesResidentialServices + "' ";
                sql += " ,App_job_PersonalCareAssistingMoving  = '" + _app_job_PersonalCareAssistingMoving + "' ";
                sql += " ,App_job_AssistEatingDrinking = '" + _app_job_AssistEatingDrinking + "' ";
                sql += " ,App_job_70  = '" + _app_job_70 + "' ";
                sql += " ,App_job_71  = '" + _app_job_71 + "' ";
                sql += " ,App_job_72  = '" + _app_job_72 + "' ";
                sql += " ,App_job_73  = '" + _app_job_73 + "' ";


                // rahmat

                sql += " ,App_Esf_Q_Unique_Number  = '" + _app_Esf_Q_Unique_Number + "' ";
                sql += " ,App_Esf_Q_Refugee  = '" + _app_Esf_Q_Refugee + "' ";
                sql += " ,App_Esf_Q_Granted_Leave  = '" + _app_Esf_Q_Granted_Leave + "' ";
                sql += " ,App_Esf_Q_Single_Adult  = '" + _app_Esf_Q_Single_Adult + "' ";
                sql += " ,App_Esf_Q_Manager_Register  = '" + _app_Esf_Q_Manager_Register + "' ";
                sql += " ,App_Esf_Q_Million_Balance  = '" + _app_Esf_Q_Million_Balance + "' ";
                sql += " ,App_Esf_Q_Type_Service_Provider  = '" + _app_Esf_Q_Type_Service_Provider + "' ";
                sql += " ,App_Esf_Q_Basic_Math  = '" + _app_Esf_Q_Basic_Math + "' ";
                sql += " ,App_Esf_Q_Basic_English  = '" +_app_Esf_Q_Basic_English + "' ";
                sql += " ,App_Esf_Q_Level_2_Math  = '" + _app_Esf_Q_Level_2_Math + "' ";
                sql += " ,App_Esf_Q_Level_2_English  = '" + _app_Esf_Q_Level_2_English + "' ";
                sql += " ,App_Esf_Q_High_Qualification  = '" + _app_Esf_Q_High_Qualification + "' ";

                sql += " ,App_Org_PId  = '" + _app_Org_PId + "' ";
                sql += " ,App_Org_Reg_Local_Authority  = '" + _app_Org_Reg_Local_Authority + "' ";

                sql += " ,App_Org_Skill  = '" + _app_Org_Skill + "' ";
                sql += " ,App_Org_Cqc  = '" + _app_Org_Cqc + "' ";
                sql += " ,App_Org_Reg_Cqc  = '" + _app_Org_Reg_Cqc + "' ";
                sql += " ,App_Org_Employee  = '" + _app_Org_Employee + "' ";

                sql += " ,App_Esf_Q_Access_Skill_Hold  = '" + _app_Esf_Q_Access_Skill_Hold + "' ";
                sql += " ,App_Esf_Q_European_Social  = '" + _app_Esf_Q_European_Social + "' ";
                sql += " ,App_Esf_Q_Employee_Million  = '" + _app_Esf_Q_Employee_Million + "' ";
                sql += " ,App_Esf_Q_Behalf  = '" + _app_Esf_Q_Behalf + "' ";

                sql += " ,App_Esf_Q_Assessment  = '" + _app_Esf_Q_Assessment + "' ";
                sql += " ,App_Esf_Q_Access_Skill  = '" + _app_Esf_Q_Access_Skill + "' ";
                sql += " ,App_Esf_Q_Info_Supplied  = '" + _app_Esf_Q_Info_Supplied + "' ";
                sql += " ,App_Esf_Q_Legally_Uk  = '" + _app_Esf_Q_Legally_Uk + "' ";

                sql += " WHERE App_Id = " + _app_id;

                return DSP.DAL.SQL.ExecuteSQL(sql);
            }

            return false;
        }
        public bool SaveApplicationCourseLevelAndAdvisor()
        {
            if (_app_id != 0)
            {
                string sql = " UPDATE  [oscauser].[Applications] ";

                sql += " SET App_officeuse1_CourseId  = '" + _app_officeuse1_CourseId + "' ";
                //sql += " ,App_officeuse1_CourseTitle  = '" + _app_officeuse1_CourseTitle + "' ";
                sql += " ,App_officeuse1_CourseTitle  = '" + setCourseTitle(_app_officeuse1_CourseId.ToString()) + "' ";
                sql += " ,App_officeuse1_CourseLevel  = '" + _app_officeuse1_CourseLevel + "' ";
                if (_app_AdvisorUserId > 0)
                {
                    sql += " ,App_AdvisorUserId  = '" + _app_AdvisorUserId + "' ";
                }

                sql += " WHERE App_Id = " + _app_id;

                return DSP.DAL.SQL.ExecuteSQL(sql);
            }

            return false;
        }

        public bool SubmitApplication()
        {


            if (_app_id != 0)
            {
                DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplication() | username: {0} | Application Before Submission | App id: {1} ", Membership.GetUser().UserName, _app_id));

                //we need to save to applications users
                string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET AppUser_SumittedDate = getDate(), AppUser_IsSubmitted = 1,AppUser_IsRejected=0,  AppUser_SubmittedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
                DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, _app_id));
                DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplication() | username: {0} | Application Submitted | App id: {1} ", Membership.GetUser().UserName, _app_id));

                //add this to the audit control
                DSP.BAL.DBL.AddApplicationHistory(_app_id, Membership.GetUser().UserName, "SUBMIT", Membership.GetUser().UserName);

                string strApplicationFormFilled = MergeApplicationFormTemplate(this);
                DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplication() | username: {0} | Application Submitted and Now Mail Merged | App id: {1} ", Membership.GetUser().UserName, _app_id));

                //grab all attachments
                Hashtable htAttachments = new Hashtable();

                htAttachments.Add("LegalResidential", _app_LegalResidency_doc);
                htAttachments.Add("HaveJob", _app_job_HaveJobDescription_doc);
                htAttachments.Add("HaveJobL3", _app_job_HaveJobDescription_L3_doc);
                htAttachments.Add("signature.png", getSignaturePath(_app_id));

                if (ConfigurationManager.AppSettings["cfg_test"] == "true")
                {

                    //trigger email to admin
                    DSP.BAL.EmailNotifications.SendFormattedMail(string.Format(ConfigurationManager.AppSettings["cfg_lang_subject_app_completed"] + " [ADMIN-TEST]", _app_id), "", ConfigurationManager.AppSettings["cfg_portal_email_debug"], strApplicationFormFilled, "", "", htAttachments);
                    DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplication() [ADMIN-TEST] | username: {0} | Application Submitted and Now Emailed | App id: {1} ", Membership.GetUser().UserName, _app_id));

                    return true;
                }

                //trigger email to admin
                string sValue = "";


                // string sFound = DSP.DAL.SQL.GetOneValueBySP("SP_App_GetAnyOpenApplication", "UserId", iUserId, "app_id");
                DataSet ds = DSP.DAL.SQL.GetDsBySP("Sp_App_GetSaleAdvisor", "id", _app_id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        sValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    catch (Exception exx)
                    {
                        sValue = "";
                    }
                }
                else
                {
                    sValue = "";
                }

             
                DataSet userName = DSP.DAL.SQL.GetDsBySP("Get_SaleAdviser_UserName", "id", Convert.ToInt32(sValue));

                string userEmail = "";
                if (userName != null && userName.Tables.Count > 0 && userName.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        userEmail = userName.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    catch (Exception exx)
                    {
                        userEmail = "";
                    }


                }
                else
                {
                    userEmail = "";
                }


                DSP.BAL.EmailNotifications.SendFormattedMail(string.Format(ConfigurationManager.AppSettings["cfg_lang_subject_app_completed"], _app_id), "",userEmail , strApplicationFormFilled, "", "", htAttachments);
                DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplication() | username: {0} | Application Submitted and Now Emailed | App id: {1} ", Membership.GetUser().UserName, _app_id));

            }
            return true;
        }

        public bool SubmitApplicationAdmin()
        {
            if (_app_id != 0)
            {
                //we need to save to applications users
                string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_SumittedDate = getDate(), AppUser_IsRejected =0, AppUser_IsSubmitted = 1, AppUser_SubmittedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
                DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, _app_id));

                DSP.BAL.DBL.AddApplicationHistory(_app_id, _app_Email, "SUBMIT", Membership.GetUser().UserName);

                string strApplicationFormFilled = MergeApplicationFormTemplate(this);

                string sEmailRecipient = ConfigurationManager.AppSettings["cfg_portal_email_to"];
                if (ConfigurationManager.AppSettings["cfg_test"] == "true")
                {
                    sEmailRecipient = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
                }
                //trigger email to admin
                DSP.BAL.EmailNotifications.SendFormattedMail(string.Format(ConfigurationManager.AppSettings["cfg_lang_subject_app_completed"], _app_id), "", sEmailRecipient, strApplicationFormFilled, "", "", null);
                DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplicationAdmin() Email sent to [ADMIN] | username: {0} | Application Id = {1} | Admin has Submitted application and now Emailed to {2}  ", Membership.GetUser().UserName, _app_id, sEmailRecipient));

                sEmailRecipient = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
                DSP.BAL.EmailNotifications.SendFormattedMail(string.Format(ConfigurationManager.AppSettings["cfg_lang_subject_app_completed"], _app_id), "", sEmailRecipient, strApplicationFormFilled, "", "", null);
                DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationForm.SubmitApplicationAdmin() [DEBUG] Email sent to [ADMIN] | username: {0} | Application Id = {1} | Admin has Submitted application and now Emailed to {2}  ", Membership.GetUser().UserName, _app_id, sEmailRecipient));

            }
            return true;
        }
        public string setCourseTitle(string CourseId)
        {
            string courseTitle = "";
            try
            {
                DataSet ds = null;
                string squery = ("SELECT Course_Title FROM Courses WHERE Course_Id = " + CourseId.ToString());
                ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(squery);
                courseTitle = ds.Tables[0].Rows[0]["Course_Title"].ToString();
                return courseTitle;
            }
            catch (Exception)
            {

            }
            return courseTitle;
        }

        public string MergeApplicationFormTemplate(ApplicationForm _App)
        {
            string emailTemplate = "~/Templates/ApplicationFormL5_CYP.html";

            switch (_App._app_officeuse1_CourseLevel)
            {
                case 20:
                    emailTemplate = "~/Templates/ApplicationFormL2.html";
                    break;

                case 30:
                    emailTemplate = "~/Templates/ApplicationFormL3_CYP.html";
                    break;

                case 31:
                    emailTemplate = "~/Templates/ApplicationFormL3_Adult.html";
                    break;

                case 32:
                    emailTemplate = "~/Templates/ApplicationFormL3_MH.html";
                    break;

                case 40:
                    emailTemplate = "~/Templates/ApplicationFormL4_Adult.html";
                    break;

                case 50:
                    emailTemplate = "~/Templates/ApplicationFormL5_CYP.html";
                    break;

                case 51:
                    emailTemplate = "~/Templates/ApplicationFormL5_Adult.html";
                    break;

                case 52:
                    emailTemplate = "~/Templates/ApplicationFormL5_Apprenticeship.html";
                    break;
                case 80:
                    emailTemplate = "~/Templates/ApplicationFormSC.html";
                    break;
                case 102:
                    emailTemplate = "~/Templates/ApplicationFormESF.html";
                    break;

                default:
                    break;
            }

            StreamReader srTmp = new StreamReader(File.OpenRead(HttpContext.Current.Server.MapPath(emailTemplate)));

            StringBuilder sbTemplate = new StringBuilder(srTmp.ReadToEnd());
            srTmp.Close();

            Hashtable ht = new Hashtable();
            //ht.Add("[!lit_App_officeuse_UniqueLearnerReference!]", _App._app_officeuse_UniqueLearnerReference);

            ht.Add("[!lit_App_officeuse_UniqueLearnerReference!]", _App._app_officeuse_UniqueLearnerReference);
            ht.Add("[!lit_App_officeuse_StartDate!]", _App._app_officeuse_StartDate);
            ht.Add("[!lit_App_officeuse_EndDate!]", _App._app_officeuse_EndDate);
            ht.Add("[!lit_App_officeuse_ApprenticeshipFramework!]", _App._app_officeuse_ApprenticeshipFramework);
            ht.Add("[!lit_App_officeuse_LearnerId!]", _App._app_officeuse_LearnerId);
            ht.Add("[!lit_App_officeuse_ReferenceId!]", "");//NOT SHOWING ON PRINTOUT _App._app_officeuse_ReferenceId);
            ht.Add("[!lit_App_officeuse_CQCInspectionDate!]", _App._app_officeuse_CQCInspectionDate);
            ht.Add("[!lit_App_officeuse_UKPRN!]", _App._app_officeuse_UKPRN);
            ht.Add("[!lit_App_officeuse_EmployerId!]", _App._app_officeuse_EmployerId);

            ht.Add("[!lit_App_officeuse_ReferenceDate!]", "");//NOT SHOWING ON PRINTOUT (_App._app_officeuse_ReferenceDate==""? "": String.Format("{0:MM/dd/yyyy}", DateTime.Parse(_App._app_officeuse_ReferenceDate)) ));
            ht.Add("[!lit_App_officeuse_IsEvidenceSeen!]", "");//NOT SHOWING ON PRINTOUT (_App._app_officeuse_IsEvidenceSeen == true ? "Yes" : "No")  );
            ht.Add("[!lit_App_officeuse_ReferenceIdType!]", "");//NOT SHOWING ON PRINTOUT_App._app_officeuse_ReferenceIdType);

            ht.Add("[!lit_App_officeuse_FundingId!]", _App._app_officeuse_FundingId);
            ht.Add("[!lit_App_officeuse_FundingTitle!]", _App._app_officeuse_FundingTitle);


            ht.Add("[!lit_App_officeuse1_IsLiteracyNumeracyDone!]", (_App._app_officeuse1_IsLiteracyNumeracyDone == true ? "Yes" : "No"));
            ht.Add("[!lit_App_officeuse1_IsAllDocumentsSigned!]", (_App._app_officeuse1_IsAllDocumentsSigned == true ? "Yes" : "No"));
            ht.Add("[!lit_App_officeuse1_IsConfirmEnrolment!]", (_App._app_officeuse1_IsConfirmEnrolment == true ? "Yes" : "No"));
            ht.Add("[!lit_App_officeuse1_CourseId!]", _App._app_officeuse1_CourseId);
            ht.Add("[!lit_App_officeuse1_CourseTitle!]", _App._app_officeuse1_CourseTitle);



            ht.Add("[!lit_App_Title!]", DSP.BAL.DBL.GetApplicationOptionTitle("Title", _App._app_Title));
            ht.Add("[!lit_App_FirstName!]", _App._app_FirstName);
            ht.Add("[!lit_App_Surname!]", _App._app_Surname);
            ht.Add("[!lit_App_Gender!]", DSP.BAL.DBL.GetApplicationOptionTitle("Gender", _App._app_Gender));
            ht.Add("[!lit_App_DOB!]", _App._app_DOB);
            ht.Add("[!lit_App_NI!]", _App._app_NI);
            ht.Add("[!lit_App_PermAddress1!]", _App._app_PermAddress1 + "\n" + _App._app_PermAddress2 + "\n" + _App._app_PermAddress3);
            ht.Add("[!lit_App_PermPostCode!]", _App._app_PermPostCode);
            ht.Add("[!lit_App_HomeTel!]", _App._app_HomeTel);
            ht.Add("[!lit_App_Mobile!]", _App._app_Mobile);
            ht.Add("[!lit_App_Email!]", _App._app_Email);
            ht.Add("[!lit_App_Unique_Number!]", _App._app_Esf_Q_Unique_Number);
            ht.Add("[!lit_App_Type_Service_Provided!]", _App._app_Esf_Q_Type_Service_Provider);
//ht.Add("[!lit_App_Job_Role!]", DSP.BAL.DBL.GetApplicationOptionTitle("JobRole", _App._app_job_JobFunction));
            ht.Add("[!lit_App_Org_Skill!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Skill));
            ht.Add("[!lit_App_Org_Reg_Cqc!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Reg_Cqc));
            ht.Add("[!lit_App_Org_Cqc!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Cqc));
            ht.Add("[!lit_App_Org_Emp!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Employee));
            ht.Add("[!lit_App_manager_reg!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Manager_Register));
            ht.Add("[!lit_App_Org_PId!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_PId));
            ht.Add("[!lit_App_Org_Authority!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Reg_Local_Authority));
            ht.Add("[!lit_App_Million_Balance!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Million_Balance));
            ht.Add("[!lit_App_Refugee!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Refugee));
            ht.Add("[!lit_App_Job_Role!]", DSP.BAL.DBL.GetApplicationOptionTitle("Job Function", _App._app_job_JobFunction));


            ht.Add("[!lit_App_Leave_Granted!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Granted_Leave));
            ht.Add("[!lit_App_Single_Adult!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Single_Adult));
            ht.Add("[!lit_App_Basic_English!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Basic_English));

            ht.Add("[!lit_App_Basic_Math!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Basic_Math));
            ht.Add("[!lit_App_Level_2_English!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Level_2_English));
            ht.Add("[!lit_App_Level_2_Math!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Level_2_Math));
            ht.Add("[!lit_App_High_Qulification!]",_App._app_Esf_Q_High_Qualification );


            ht.Add("[!lit_App_Nationality!]", DSP.BAL.DBL.GetApplicationOptionTitle("Nationality", _App._app_Nationality));
            ht.Add("[!lit_App_LegalResidency!]", _App._app_LegalResidency == "" ? "&nbsp;" : _App._app_LegalResidency);
            ht.Add("[!lit_App_IsLivedEULast3Years!]", DSP.BAL.DBL.GetYesNo(_App._app_IsLivedEULast3Years));
            ht.Add("[!lit_App_LivedEntryDate!]", _App._app_LivedEntryDate == "" ? "&nbsp;" : _App._app_LivedEntryDate);
            ht.Add("[!lit_App_NonEUUKHowLongLiveInUK!]", _App._app_NonEUUKHowLongLiveInUK == "" ? "&nbsp;" : _App._app_NonEUUKHowLongLiveInUK);


            ht.Add("[!lit_App_Ethnicity!]", DSP.BAL.DBL.GetApplicationOptionTitle("Ethnicity", _App._app_Ethnicity));
            ht.Add("[!lit_App_Religion!]", DSP.BAL.DBL.GetApplicationOptionTitle("Religion", _App._app_Religion));
            // ht.Add("[!lit_App_SexualOrientation!]", DSP.BAL.DBL.GetApplicationOptionTitle("Sexual Orientation", _App._app_SexualOrientation));
            ht.Add("[!lit_App_LengthOfAddress!]", _App._app_LengthOfAddress);
            ht.Add("[!lit_App_PrePlannedAbsence!]", _App._app_PrePlannedAbsence);

            ht.Add("[!lit_App_Circumstance!]", DSP.BAL.DBL.GetApplicationOptionTitle("Circumstances", _App._app_Circumstance));

            ht.Add("[!lit_App_AnyDisability!]", DSP.BAL.DBL.GetYesNo(_App._app_AnyDisability));
            ht.Add("[!lit_App_AnyDisabilityPrimary!]", DSP.BAL.DBL.GetApplicationOptionTitle("Disabilities", _App._app_AnyDisabilityPrimary));

            ht.Add("[!lit_App_AnyDisabilitySecondaries!]", getAllTickOptions(_App._app_AnyDisabilitySecondaries));

            ht.Add("[!lit_App_NeedLearningSupport!]", DSP.BAL.DBL.GetYesNo(_App._app_NeedLearningSupport));
            ht.Add("[!lit_App_HaveLearnerSupportProgram!]", DSP.BAL.DBL.GetYesNo(_App._app_HaveLearnerSupportProgram));
            ht.Add("[!lit_App_IsAccessToComputer!]", DSP.BAL.DBL.GetYesNo(_App._app_IsAccessToComputer));
            ht.Add("[!lit_App_IsAccessToFaceTime!]", DSP.BAL.DBL.GetYesNo(_App._app_IsAccessToFaceTime));
            ht.Add("[!lit_App_IsAccessToEmail!]", DSP.BAL.DBL.GetYesNo(_App._app_IsAccessToEmail));
            ht.Add("[!lit_App_IsPartnerOfOwner!]", DSP.BAL.DBL.GetYesNo(_App._app_IsPartnerOfOwner));
            ht.Add("[!lit_App_IsEPortoflioAware!]", DSP.BAL.DBL.GetYesNo(_App._app_IsEPortoflioAware));
            //ht.Add("[!lit_App_ManageWorkStudy!]", _App._app_ManageWorkStudy);
            ht.Add("[!lit_App_educ_HighestQual!]", DSP.BAL.DBL.GetApplicationOptionTitle("Qualifications", _App._app_educ_HighestQual));
            ht.Add("[!lit_App_educ_IsGCSEEnglish!]", DSP.BAL.DBL.GetApplicationOptionTitle("GCSE", _App._app_educ_IsGCSEEnglish));
            ht.Add("[!lit_App_educ_IsGCSEMath!]", DSP.BAL.DBL.GetApplicationOptionTitle("GCSE", _App._app_educ_IsGCSEMath));
            ht.Add("[!lit_App_educ_EquivalentQualification!]", _App._app_educ_EquivalentQualification);

            ht.Add("[!lit_App_educ_IsEnrolledOther!]", DSP.BAL.DBL.GetYesNo(_App._app_educ_IsEnrolledOther));
            ht.Add("[!lit_App_educ_PreviousCollege!]", _App._app_educ_PreviousCollege);
            ht.Add("[!lit_App_educ_PreviousQual!]", _App._app_educ_PreviousQual);
            ht.Add("[!lit_App_educ_PreviousTraining!]", _App._app_educ_PreviousTraining);
            ht.Add("[!lit_App_educ_IsALLFund!]", DSP.BAL.DBL.GetYesNo(_App._app_educ_IsALLFund));
            ht.Add("[!lit_App_educ_ALLFundQualDetails!]", _App._app_educ_ALLFundQualDetails);

            // ht.Add("[!lit_App_educ_TrainingPlannedNext12Months!]", _App._app_educ_TrainingPlannedNext12Months);
            // ht.Add("[!lit_App_educ_FutureInspirations!]", _App._app_educ_FutureInspirations);
            ht.Add("[!lit_App_emp_CompanyName!]", _App._app_emp_CompanyName);
            ht.Add("[!lit_App_emp_EmpoyementStartDate!]", _App._app_emp_EmpoyementStartDate);

            ht.Add("[!lit_App_emp_WorkPlaceAddress!]", _App._app_emp_WorkPlaceAddress1 + "\n" + _App._app_emp_WorkPlaceAddress2 + "\n" + _App._app_emp_WorkPlaceAddress3);
            ht.Add("[!lit_App_emp_WorkPlacePostCode!]", _App._app_emp_WorkPlacePostCode);
            ht.Add("[!lit_App_emp_Email!]", _App._app_emp_Email);
            ht.Add("[!lit_App_emp_Tel!]", _App._app_emp_Tel);
            ht.Add("[!lit_App_emp_ContactName!]", _App._app_emp_ContactName);
            ht.Add("[!lit_App_emp_Position!]", _App._app_emp_Position);
            ht.Add("[!lit_App_emp_BusinessSector!]", _App._app_emp_BusinessSector);
            ht.Add("[!lit_App_emp_CompanyEstablished!]", DSP.BAL.DBL.GetApplicationOptionTitle("Company Size", _App._app_emp_CompanyEstablished));
            ht.Add("[!lit_App_emp_WeeklyHours!]", _App._app_emp_WeeklyHours);
            ht.Add("[!lit_App_emp_IsSelfEmployed!]", DSP.BAL.DBL.GetYesNo(_App._app_emp_IsSelfEmployed));
            //ht.Add("[!lit_App_emp_IsEmployerPaying!]", DSP.BAL.DBL.GetYesNo(_App._app_emp_IsEmployerPaying));
            ht.Add("[!lit_App_job_JobFunction!]", DSP.BAL.DBL.GetApplicationOptionTitle("Job Function", _App._app_job_JobFunction));
            ht.Add("[!lit_App_job_HowLongWorkingJob!]", DSP.BAL.DBL.GetApplicationOptionTitle("How long...", _App._app_job_HowLongWorkingJob));
            ht.Add("[!lit_App_job_HowLongWorkingEmployer!]", DSP.BAL.DBL.GetApplicationOptionTitle("Howlongemployment", _App._app_job_HowLongWorkingEmployer));
            ht.Add("[!lit_App_job_AnyPreviousManagement!]", DSP.BAL.DBL.GetYesNo(_App._app_job_AnyPreviousManagement));
            ht.Add("[!lit_App_job_HaveCurrentDevPlan!]", DSP.BAL.DBL.GetYesNo(_App._app_job_HaveCurrentDevPlan));
            ht.Add("[!lit_App_job_IsAwareFundamentalStd!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsAwareFundamentalStd));
            // ht.Add("[!lit_App_job_IsResponsibleCQCPIR!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleCQCPIR));
            ht.Add("[!lit_App_job_IsResponsibleRecruitment!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleRecruitment));
            ht.Add("[!lit_App_job_IsResponsibleStaffInduction!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleStaffInduction));
            ht.Add("[!lit_App_job_IsResponsibleStaffAppraisal!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleStaffAppraisal));
            ht.Add("[!lit_App_job_IsResponsibleMonitoringStaff!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleMonitoringStaff));
            // ht.Add("[!lit_App_job_IsResponsibleTaskAllocationRotas!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleTaskAllocationRotas));
            ht.Add("[!lit_App_job_IsResponsiblePlanningReviewing!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsiblePlanningReviewing));
            // ht.Add("[!lit_App_job_IsResponsibleOrganisingReferrals!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleOrganisingReferrals));
            //  ht.Add("[!lit_App_job_IsResponsibleOrganisingPartnerships!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleOrganisingPartnerships));
            ht.Add("[!lit_App_job_IsResponsibleEffectivenessPartnerships!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleEffectivenessPartnerships));
            ht.Add("[!lit_App_job_IsReviewAuditPolicies!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsReviewAuditPolicies));
            ht.Add("[!lit_App_job_IsRespondingToComplaints!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsRespondingToComplaints));
            ht.Add("[!lit_App_job_IsInvestigatingSafeguarding!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvestigatingSafeguarding));
            ht.Add("[!lit_App_job_IsAuditFeedback!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsAuditFeedback));
            // ht.Add("[!lit_App_job_IsResponsibleWritingDevPlan!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleWritingDevPlan));
            ht.Add("[!lit_App_job_IsOrganisingLeadStaffMeetings!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsOrganisingLeadStaffMeetings));

            //ht.Add("[!lit_App_job_HaveRegularStaffMeetings!]", DSP.BAL.DBL.GetYesNo(_App._app_job_HaveRegularStaffMeetings));
            ht.Add("[!lit_App_job_IsAttendingStrategicMeetings!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsAttendingStrategicMeetings));
            ht.Add("[!lit_App_job_IsEnsuringComplianceHS!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsEnsuringComplianceHS));
            ht.Add("[!lit_App_job_IsFurtherTrainingNeeded!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsFurtherTrainingNeeded));
            //ht.Add("[!lit_App_job_IsSpecificSupportNeeded!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsSpecificSupportNeeded));

             
            string pathways = getPathwaysLevel(_App._app_officeuse1_CourseLevel);
            ht.Add("[!lit_App_job_RelevantPathway!]", DSP.BAL.DBL.GetApplicationOptionTitle(pathways, _App._app_job_RelevantPathway));
            ht.Add("[!lit_App_job_RelevantPathway_L3!]", DSP.BAL.DBL.GetApplicationOptionTitle(pathways, _App._app_job_RelevantPathway));
        
            ht.Add("[!lit_App_job_HaveJobDescription!]", DSP.BAL.DBL.GetYesNo(_App._app_job_HaveJobDescription));
            ht.Add("[!lit_App_job_HaveJobDescription_L3!]", DSP.BAL.DBL.GetYesNo(_App._app_job_HaveJobDescription));
            //ht.Add("[!lit_App_job_CarryOutAuditing!]", DSP.BAL.DBL.GetYesNo(_App._app_job_CarryOutAuditing));

            ht.Add("[!lit_App_job_DailyMainDuties!]", _App._app_job_DailyMainDuties);
            //ht.Add("[!lit_App_job_UsualHoursAttendancy!]", _App._app_job_UsualHoursAttendancy);
            ht.Add("[!lit_App_job_OtherPositionResponsabilities!]", _App._app_job_OtherPositionResponsabilities);
            ht.Add("[!lit_App_job_AboutYourStrenghts!]", _App._app_job_AboutYourStrenghts);
            ht.Add("[!lit_App_job_AreasOfDevelopment!]", _App._app_job_AreasOfDevelopment);
            ht.Add("[!lit_App_job_AllowWorkplaceObsVisit!]", DSP.BAL.DBL.GetYesNo(_App._app_job_AllowWorkplaceObsVisit));
            ht.Add("[!lit_App_job_Confirm16hrs!]", DSP.BAL.DBL.GetYesNo(_App._app_job_Confirm16hrs == true ? "1" : "0"));
            ht.Add("[!lit_App_job_Confirm16hrsTitle!]", _App._app_job_Confirm16hrsTitle);

            ht.Add("[!lit_App_job_HaveStartedGLH!]", _App._app_job_HaveStartedGLH);

            ht.Add("[!lit_App_job_IsAssessReviewImplementCare!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsAssessReviewImplementCare));
            ht.Add("[!lit_App_job_IsInvolvedRiskAssessment!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvolvedRiskAssessment));
            ht.Add("[!lit_App_job_IsEnsureOthersFollowPolicy!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsEnsureOthersFollowPolicy));
            ht.Add("[!lit_App_job_IsSupportServiceInPersonalCare!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsSupportServiceInPersonalCare));
            ht.Add("[!lit_App_job_IsWorkSupportRoleServiceUsers!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsWorkSupportRoleServiceUsers));
            ht.Add("[!lit_App_job_IsPlanReviewImplmentCare!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsPlanReviewImplmentCare));
            ht.Add("[!lit_App_job_IsInvolvedSafeguardingInvestigations!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvolvedSafeguardingInvestigations));
            ht.Add("[!lit_App_job_IsTakePartInRiskAssessment!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsTakePartInRiskAssessment));
            ht.Add("[!lit_App_job_IsTakePartInManagingQuality!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsTakePartInManagingQuality));

            ht.Add("[!lit_App_job_officeuse1_CourseLevel!]", _App._app_officeuse1_CourseLevel);

            ht.Add("[!lit_App_mktg_HearAbout!]", DSP.BAL.DBL.GetApplicationOptionTitle("Marketing", _App._app_mktg_HearAbout));
            ht.Add("[!lit_App_mktg_ContactConsent!]", DSP.BAL.DBL.GetChecked(_App._app_mktg_ContactConsent));
            ht.Add("[!lit_App_mktg_ContactConsentNo!]", DSP.BAL.DBL.GetChecked((_App._app_mktg_ContactConsent == "1" ? "0" : "1")));
            ht.Add("[!lit_App_mktg_ByPhone!]", DSP.BAL.DBL.GetChecked(_App._app_mktg_ByPhone));
            ht.Add("[!lit_App_mktg_ByEmail!]", DSP.BAL.DBL.GetChecked(_App._app_mktg_ByEmail));
            ht.Add("[!lit_App_mktg_ByPost!]", DSP.BAL.DBL.GetChecked(_App._app_mktg_ByPost));

            ht.Add("[!lit_PrintName!]", _App._app_PrintName);
            ht.Add("[!lit_ApplicationDate!]", _App._app_ApplicationDate);
            ht.Add("[!lit_App_ACS_WDSNumber!]", _App._app_ACS_WDSNumber);

            ht.Add("[!lit_App_job_IsContributeSelfAssessment!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsContributeSelfAssessment));
            ht.Add("[!lit_App_job_IsReviewAuditPolicy!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsReviewAuditPolicy));
            ht.Add("[!lit_App_job_IsLeadPartnershipWorking!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsLeadPartnershipWorking));
            ht.Add("[!lit_App_job_IsLeadProvisionDelivers!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsLeadProvisionDelivers));
            ht.Add("[!lit_App_job_IsResponsibleKeyResources!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleKeyResources));
            ht.Add("[!lit_App_job_IsResponsibleStaffTraining!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleStaffTraining));
            ht.Add("[!lit_App_job_ExampleProjectManaged!]", _App._app_job_ExampleProjectManaged);
            ht.Add("[!lit_App_job_ExampleSupportingCarePractice!]", _App._app_job_ExampleSupportingCarePractice);
            ht.Add("[!lit_App_job_ExampleCPDRecent!]", _App._app_job_ExampleCPDRecent);
            ht.Add("[!lit_App_job_ExampleCourageImplement!]", _App._app_job_ExampleCourageImplement);
            ht.Add("[!lit_App_job_IsResponsibleManagingQuality!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleManagingQuality));
            ht.Add("[!lit_App_job_IsResponsibleIncludeDevelopment!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsResponsibleIncludeDevelopment));


            ht.Add("[!lit_App_job_102_KnowledgeStatutoryFrameworks!]", DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_102_KnowledgeStatutoryFrameworks));
            ht.Add("[!lit_App_job_103_ExperienceOfManaging!]", DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_103_ExperienceOfManaging));
            ht.Add("[!lit_App_job_104_AbilityImplementStrategies!]", DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_104_AbilityImplementStrategies));
            ht.Add("[!lit_App_job_105_ExperienceLeadingSupporting!]", DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_105_ExperienceLeadingSupporting));
            ht.Add("[!lit_App_job_106_CarriedOutActivitiesMonitor!]", DSP.BAL.DBL.GetApplicationOptionTitle("LowMediumHigh", _App._app_job_106_CarriedOutActivitiesMonitor));
            ht.Add("[!lit_App_EUEEAStatus!]", DSP.BAL.DBL.GetApplicationOptionTitle("EUEEAStatus", _App._app_EUEEAStatus));
            ht.Add("[!lit_App_job_TherapySessions!]", DSP.BAL.DBL.GetYesNo(_App._app_job_TherapySessions));

            ht.Add("[!lit_App_job_HealthPromotion!]", DSP.BAL.DBL.GetYesNo(_App._app_job_HealthPromotion));
            ht.Add("[!lit_App__job_Advocate!]", DSP.BAL.DBL.GetYesNo(_App._app_job_Advocate));
            ht.Add("[!lit_App_job_SupportServiceUsers!]", DSP.BAL.DBL.GetYesNo(_App._app_job_SupportServiceUsers));
            ht.Add("[!lit_App_EUEEANational!]", DSP.BAL.DBL.GetYesNo(_App._app_EUEEANational));

            ht.Add("[!lit_App_job_AssessReviewSupportPlans!]", DSP.BAL.DBL.GetYesNo(_App._app_job_AssessReviewSupportPlans));

            ht.Add("[!lit_App_job_IsInvolvedInRiskAssessments!]", DSP.BAL.DBL.GetYesNo(_App._app_job_IsInvolvedInRiskAssessments));
            ht.Add("[!lit_App_job_ContributeToMentalHealth!]", DSP.BAL.DBL.GetYesNo(_App._app_job_ContributeToMentalHealth));
            ht.Add("[!lit_App_job_SupportIndvDepressionPhobias!]", DSP.BAL.DBL.GetYesNo(_App._app_job_SupportIndvDepressionPhobias));
            ht.Add("[!lit_App_job_WorkinPartnershipswthProfessionals!]", DSP.BAL.DBL.GetYesNo(_App._app_job_WorkinPartnershipswthProfessionals));
            ht.Add("[!lit_App_job_SafeguardReports!]", DSP.BAL.DBL.GetYesNo(_App._app_job_SafeguardReports));


            ht.Add("[!lit_App_job_RecruitmentResponsibilities!]", DSP.BAL.DBL.GetYesNo(_App._app_job_RecruitmentResponsibilities));
            ht.Add("[!lit_App_job_StaffInductionCareCertificate!]", DSP.BAL.DBL.GetYesNo(_App._app_job_StaffInductionCareCertificate));
            ht.Add("[!lit_App_job_RespondCompliments!]", DSP.BAL.DBL.GetYesNo(_App._app_job_RespondCompliments));
            ht.Add("[!lit_App_job_WorkMgtRole!]", DSP.BAL.DBL.GetYesNo(_App._app_job_WorkMgtRole));
            ht.Add("[!lit_App_job_TakePartSupervisions!]", DSP.BAL.DBL.GetYesNo(_App._app_job_WorkMgtRole));
            ht.Add("[!lit_App_job_TakePartMeetings!]", DSP.BAL.DBL.GetYesNo(_App._app_job_TakePartMeetings));
            ht.Add("[!lit_App_job_MaintainPersonalRecord!]", DSP.BAL.DBL.GetYesNo(_App._app_job_MaintainPersonalRecord));
            ht.Add("[!lit_App_job_RiskAssessOthersComply!]", DSP.BAL.DBL.GetYesNo(_App._app_job_RiskAssessOthersComply));
            ht.Add("[!lit_App_job_SafeguardInvestigations!]", DSP.BAL.DBL.GetYesNo(_App._app_job_SafeguardInvestigations));
            ht.Add("[!lit_App_job_WorkSupportiveRole!]", DSP.BAL.DBL.GetYesNo(_App._app_job_WorkSupportiveRole));
            ht.Add("[!lit_App_job_ReviewSupportPlans!]", DSP.BAL.DBL.GetYesNo(_App._app_job_ReviewSupportPlans));
            ht.Add("[!lit_App_job_WorkPartnerProfessionals!]", DSP.BAL.DBL.GetYesNo(_App._app_job_WorkPartnerProfessionals));
            ht.Add("[!lit_App_job_CVPResilience!]", DSP.BAL.DBL.GetYesNo(_App._app_job_CVPResilience));
            ht.Add("[!lit_App_job_TechCommunication!]", DSP.BAL.DBL.GetYesNo(_App._app_job_TechCommunication));
            ht.Add("[!lit_App_job_RegularSupervisions!]", DSP.BAL.DBL.GetYesNo(_App._app_job_RegularSupervisions));
            ht.Add("[!lit_App_job_CarryoutRiskAssessment!]", DSP.BAL.DBL.GetYesNo(_App._app_job_CarryoutRiskAssessment));
            ht.Add("[!lit_App_job_SupportCYP!]", DSP.BAL.DBL.GetYesNo(_App._app_job_SupportCYP));
            ht.Add("[!lit_App_job_PositiveRiskTaking!]", DSP.BAL.DBL.GetYesNo(_App._app_job_PositiveRiskTaking));
            ht.Add("[!lit_App_job_KeyWorker!]", DSP.BAL.DBL.GetYesNo(_App._app_job_KeyWorker));
            ht.Add("[!lit_App_job_PlanImplementcare!]", DSP.BAL.DBL.GetYesNo(_App._app_job_PlanImplementcare));
            ht.Add("[!lit_App_job_WriteRecordReports!]", DSP.BAL.DBL.GetYesNo(_App._app_job_WriteRecordReports));
            ht.Add("[!lit_App_job_SocialActivitieswithServiceUser!]", DSP.BAL.DBL.GetYesNo(_App._app_job_SocialActivitieswithServiceUser));
            ht.Add("[!lit_App_job_LeadCommunicationProcesses!]", DSP.BAL.DBL.GetYesNo(_App._app_job_LeadCommunicationProcesses));
            ht.Add("[!lit_App_job_OrgProvidesResidentialServices!]", DSP.BAL.DBL.GetYesNo(_App._app_job_OrgProvidesResidentialServices));
            ht.Add("[!lit_App_job_PersonalCareAssistingMoving!]", DSP.BAL.DBL.GetYesNo(_App._app_job_PersonalCareAssistingMoving));
           
            //level 2
            ht.Add("[!lit_App_job_70!]", DSP.BAL.DBL.GetYesNo(_App._app_job_70));
            ht.Add("[!lit_App_job_AssistEatingDrinking!]", DSP.BAL.DBL.GetYesNo(_App._app_job_AssistEatingDrinking));
            ht.Add("[!lit_App_job_71!]", DSP.BAL.DBL.GetYesNo(_App._app_job_71));
            ht.Add("[!lit_App_job_72!]", DSP.BAL.DBL.GetYesNo(_App._app_job_72));
            ht.Add("[!lit_App_job_73!]", DSP.BAL.DBL.GetYesNo(_App._app_job_73));


            ht.Add("[!lit_App_Esf_Q_Type_Service_Provider!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Type_Service_Provider));
            ht.Add("[!lit_App_Esf_Q_Unique_Number!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Unique_Number));
            ht.Add("[!lit_App_Esf_Q_Refugee!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Refugee));
            ht.Add("[!lit_App_Esf_Q_Granted_Leave!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Granted_Leave));
            ht.Add("[!lit_App_Esf_Q_Single_Adult!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Single_Adult));
            ht.Add("[!lit_App_Esf_Q_Manager_Register!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Manager_Register));
            ht.Add("[!lit_App_Esf_Q_Million_Balance!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Million_Balance));
            ht.Add("[!lit_App_Esf_Q_Basic_English!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Basic_English));
            ht.Add("[!lit_App_Esf_Q_Basic_Math!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Basic_Math));
            ht.Add("[!lit_App_Esf_Q_Level_2_English!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Level_2_English));
            ht.Add("[!lit_App_Esf_Q_Level_2_Math!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Level_2_Math));
            ht.Add("[!lit_App_Esf_Q_High_Qualification!]", _App._app_Esf_Q_High_Qualification);


         //   ht.Add("[!lit_App_Org_PId!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_PId));
            ht.Add("[!lit_App_Org_Reg_Local_Authority!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Reg_Local_Authority));
            //ht.Add("[!lit_App_Org_Skill!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Skill));
            //ht.Add("[!lit_App_Org_Cqc!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Cqc)); 
            //ht.Add("[!lit_App_Org_Employee!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Employee));
            //ht.Add("[!lit_App_Org_Reg_Cqc!]", DSP.BAL.DBL.GetYesNo(_App._app_Org_Reg_Cqc));

            ht.Add("[!lit_App_skill_access_hold!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Access_Skill_Hold));
            ht.Add("[!lit_App_europen_social!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_European_Social));
            ht.Add("[!lit_App_employee_million!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Employee_Million));
            ht.Add("[!lit_App_behalf!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Behalf));
            ht.Add("[!lit_App_assesment!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Assessment));
            ht.Add("[!lit_App_access_skill!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Access_Skill));
            ht.Add("[!lit_App_info_supplied!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Info_Supplied));
            ht.Add("[!lit_App_legally_uk!]", DSP.BAL.DBL.GetYesNo(_App._app_Esf_Q_Legally_Uk));




            /*ht.Add("[!lit_uploaded_file_legalresidency!]", _App._app_LegalResidency_doc);
            ht.Add("[!lit_uploaded_file_havejob!]", _App._app_job_HaveJobDescription_doc);
            ht.Add("[!lit_uploaded_file_havejob_l3!]", _App._app_job_HaveJobDescription_L3_doc);*/
            // ht.Add("[!lit_app_signature!]", getSignatureData(_App._app_id));//  String.Format("DD/MM/YY",_App.);
            ht.Add("[!lit_app_signature!]", getSignatureData2(_App._app_id));//  String.Format("DD/MM/YY",_App.);
            ht.Add("[!lit_app_signature_accessskills!]", getSignatureDataForAccessSkills(0));//  String.Format("DD/MM/YY",_App.);



            ht.Add("[!lit_App_Submit_Date!]", DateTime.Now.ToString("dd/MM/yyyy"));//  String.Format("DD/MM/YY",_App.);
                                                                                   //DateTime dt = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);



            IDictionaryEnumerator _enumerator = ht.GetEnumerator();
            try
            {
                while (_enumerator.MoveNext())
                {
                    sbTemplate.Replace(_enumerator.Key.ToString(), _enumerator.Value.ToString());
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return sbTemplate.ToString();

        }

        private string getSignaturePath(int iAppId)
        {

            string sPath = Path.Combine(ConfigurationManager.AppSettings["cfg_appportaldata_path"], ConfigurationManager.AppSettings["cfg_appportaldata_app_signatures"], iAppId + ".png");
            return sPath;
        }

        private string getSignatureData(int iAppId)
        {
            string imgData = "";
            //  Byte[] imgDataBytes = "";
            DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(String.Format("Select CONVERT(VARCHAR(MAX), CONVERT(VARBINARY(MAX), AppSig_Signature)) as sig From oscauser.ApplicationsSignatures WHERE AppSig_Id_App = {0}; ", iAppId));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    imgData = ds.Tables[0].Rows[0]["sig"].ToString();
                }
                catch (Exception exx)
                {

                }
            }

            return imgData;

        }

        private string getSignatureData2(int iAppId)
        {
            string imgData = "";
            //  Byte[] imgDataBytes = "";
            DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(String.Format("Select  'data:image/png;base64,'+(select AppSig_Signature as '*' for xml path('')) as sig From oscauser.ApplicationsSignatures WHERE AppSig_Id_App = {0}; ", iAppId));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    imgData = ds.Tables[0].Rows[0]["sig"].ToString();
                }
                catch (Exception exx)
                {

                }
            }

            return imgData;

        }
        private string getSignatureDataForAccessSkills(int iAppId)
        {
            //http://www.garciabarreto.com.br/brasil/salvador-ba/images/projeto-1.png

            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAZAAAADICAYAAADGFbfiAAAC3ElEQVR4nO3VMQ0AIBDAQHRg+w2jgS6E5Ibbu3XNzAaAW+t1AAB/MhAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgMRAAEgMBIDEQABIDASAxEAASAwEgOTAvMucY2ZVJAAAAAElFTkSuQmCC";
        }

        private string getAllTickOptions(string sAllIds)
        {    //1, 2, 3, 4, ....
             //get all string for each id from options

            string[] singleIds = sAllIds.Split(',');
            string selectedOptions = "";
            foreach (string s in singleIds)
            {
                selectedOptions += DSP.BAL.DBL.GetApplicationOptionTitle("Disabilities", s.Trim()) + Environment.NewLine;
            }
            return selectedOptions;

        }
        public int EnrolNowApplicationAdmin()
        {
            int learnerId = 0;
            if (_app_id != 0)
            {
                //we need to save to applications users
                // int iUserId = DSP.BAL.DBL.GetUser_UserId(Membership.GetUser().UserName);
                //string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET  AppUser_LockedDate = getDate(), AppUser_IsCompleted = 1, AppUser_LockedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
                // DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, _app_id));

                string sql2 = "UPDATE [oscauser].[ApplicationsUsers] SET AppUser_EnrolledDate = getDate(), AppUser_IsCompleted = 1, AppUser_EnrolledByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
                DSP.DAL.SQL.ExecuteSQL(string.Format(sql2, Membership.GetUser().UserName, _app_id));

                //create osca record
                OscaLearner ol = new OscaLearner();

                int iLearner = ol.CreateOscaLearner(this);
                _app_officeuse_LearnerId = iLearner.ToString();

                SaveApplication();
                //get last osca id

                //update few osca learner information
                ol.updateLearnerContacts(this, iLearner);

                //create portal record
                //string sPassword = "qwerty123";
                string sRawPassword = DSP.BAL.Basic.GenerateRandomPasswordUsingGUID(6);

                _app_Saved_Password = sRawPassword;

                //email portal login
                PortalUser portalusr = new PortalUser();
                if (portalusr.Step1_CreatePortalUser(iLearner, _app_FirstName + " " + _app_Surname, sRawPassword, _app_Email))
                {
                    //all ok!
                    //create the course and assign to this learner in osca
                    //'getcourseid from osca
                    // string sql3 = "SELECT SET  AppUser_LockedDate = getDate(), AppUser_IsCompleted = 1, AppUser_LockedByUser = '{0}' WHERE AppUser_App_Id = {1} ;";
                    int iCourseId = _app_officeuse1_CourseId; //find the right one! //45
                    int iLearnerCourseId = ol.InsertLearnerCourses(false, false, "", iLearner.ToString(), iCourseId.ToString(), "1");

                    learnerId = iLearner;
                }
                else
                {
                    //user already there
                }

                string sDisplayName = _app_FirstName + " " + _app_Surname;

                //------commented due to new api implementation----------------------------------------

                ////create QCS account
                //if (ConfigurationManager.AppSettings["cfg_test"] != "true")
                //{
                //    portalusr.Step2_AddUsertoQCSDB(iLearner, sRawPassword, _app_Email, sDisplayName);
                //}

                //--------------------------------------------------------------------------------------

                //send account creation login details notification to who?
                //Account creation COPY TO ADMIN : studentsupport@accessskills.co.uk                                FALSE  = do not send to learner
                portalusr.Step3_SendAccountCreationNotifications(iLearner, sDisplayName, sRawPassword, _app_Email, false);



                //generate email template for admin (osca info only)
                string strApplicationFormFilled = MergeApplicationFormTemplate(this);
                //trigger email to   info@accessskills.co.uk 
                string sRecipientEmail = "";
                if (ConfigurationManager.AppSettings["cfg_test"] == "true")
                {
                    sRecipientEmail = ConfigurationManager.AppSettings["cfg_portal_email_debug"];
                }
                else
                {
                    sRecipientEmail = ConfigurationManager.AppSettings["cfg_portal_email_to"];
                }


                DSP.BAL.EmailNotifications.SendFormattedMail(string.Format(ConfigurationManager.AppSettings["cfg_lang_subject_app_enrol"], _app_id), "", sRecipientEmail, strApplicationFormFilled, "", "", null);

            }
            return learnerId;

        }


        public int GetCourseLevelForCourseId(int iCourseId)
        {
            string sCourseLevel = "Level 5";
            int CourseLevel = 5;

            DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(String.Format("Select top 1 Course_Level From Courses WHERE Course_Id = {0}; ", iCourseId));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sCourseLevel = ds.Tables[0].Rows[0]["Course_Level"].ToString();
                }
                catch (Exception exx)
                {
                    sCourseLevel = "Level 5";
                }
            }

            switch (sCourseLevel)
            {
                case "Level 2":
                    CourseLevel = 20;
                    break;
                case "Level 3 CYP":
                    CourseLevel = 30;
                    break;
                case "Level 3 Adult":
                    CourseLevel = 31;
                    break;
                case "Level 3 Mental Health":
                    CourseLevel = 32;
                    break;
                case "Level 4 Adult":
                    CourseLevel = 40;
                    break;
                case "Level 5 CYP":
                    CourseLevel = 50;
                    break;
                case "Level 5 Adult":
                    CourseLevel = 51;
                    break;
                case "Level 5 Apprenticeship":
                    CourseLevel = 52;
                    break;
                case "Short Course":
                    CourseLevel = 80;
                    break;
                case "ESF":
                    CourseLevel = 102;
                    break;
                default:
                    CourseLevel = 50;
                    break;
            }
            return CourseLevel;
        }

        public bool SaveChangesToApplicationsTrackChanges(List<ApplicationsTrackChanges> ApplicationsTrackChangesList, int appId, int userId, bool isAmnended)
        {
            if (isAmnended)
            {
                string updateIsAmendedQuery = "update [oscauser].Applications set App_IsAmended = 1 where App_Id = " + appId;
                DAL.SQL.ExecuteSQL(updateIsAmendedQuery);

                foreach (var item in ApplicationsTrackChangesList)
                {
                    string query = "select * from [oscauser].[ApplicationsTrackChanges] where ATC_AppId = " + appId + " and ATC_FieldName = '" + item.ATC_FieldName + "' and ATC_IsNotified != 1";
                    DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(query);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string updateQuery = "update [oscauser].[ApplicationsTrackChanges] set ATC_ValueTo = '" + item.ATC_ValueTo + "', ATC_NotifiedDate = getDate(), ATC_ChangedBy = " + userId + " WHERE ATC_Id = " + ds.Tables[0].Rows[0]["ATC_Id"];
                        DAL.SQL.ExecuteSQL(updateQuery);
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO [oscauser].[ApplicationsTrackChanges] ";
                        insertQuery += "([ATC_AppId]";
                        insertQuery += ",[ATC_FieldName]";
                        insertQuery += ",[ATC_ValueFrom]";
                        insertQuery += ",[ATC_ValueTo]";
                        insertQuery += ",[ATC_FieldDesciption]";
                        insertQuery += ",[ATC_ChangedBy]";
                        insertQuery += ",[ATC_ChangedDate]";
                        insertQuery += ",[ATC_IsNotified]) ";
                        insertQuery += "VALUES ({0}, '{1}', '{2}', '{3}', {4}, {5}, getDate(), 0)";

                        DAL.SQL.ExecuteSQL(String.Format(insertQuery, appId, item.ATC_FieldName, item.ATC_ValueFrom, item.ATC_ValueTo, "(select top 1 AFD_FieldDescription from [oscauser].[ApplicationsFieldDescriptions] where AFD_FieldName = '" + item.ATC_FieldName + "')", userId));
                        DSP.BAL.Log.WriteLogTxt(String.Format("ApplicationsTrackChanges_" + DateTime.Now.Millisecond, "<br/>The following change occured in " + item.ATC_FieldName + ":<br/>" + "Change From : (" + item.ATC_ValueFrom + ") Change To : (" + item.ATC_ValueTo + ")"));
                    }
                }
            }
            return true;
        }
        public class ApplicationsTrackChanges
        {
            public string ATC_FieldName { get; set; }
            public string ATC_ValueFrom { get; set; }
            public string ATC_ValueTo { get; set; }
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

    }//EmailLogs


    #region Enum
    public enum CourseLevel
    {
        L2 = 2,
        L3 = 3,
        L4 = 4,
        L5 = 5,
        L6 = 6,
        RMA = 7,
        SC = 99
    }
    #endregion







} //DSP.BAL




