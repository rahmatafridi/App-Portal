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


namespace DSP.BAL
{

    public class OscaLearner
    {
        public int _learner_id;

        public bool isActive = true;
        public bool isCompletedApplication = false;
        public bool isFunded = false;
        public bool isClaimed = false;
        public DateTime ReceivedDate;
        public DateTime BookedDate;
        public DateTime CreatedDate;
        public string _reference;
        public int _title;
        public string FirstName;
        public string MiddleName;
        public string Surname;
        public string Gender;
        public string DOB;
        public string NI;
        public string PermAddress1;
        public string PermAddress2;
        public string PermAddress3;
        public string PermAddress4;
        public string PermAddress5;
        public string PermPostCode1;
        public string PermPostCode2;
        public int PermCountry;//id
        public string HomeTel1;
        public string HomeTel2;
        public string WorkTel1;
        public string WorkTel2;
        public string Mobile1;
        public string Mobile2;
        public string Email1;
        public string Email2;
        public bool isOverseas = true;
        public int MaritalStatus;//id
        public int CandidateStatus;//id
        public int DealingPerson = 197;
        public int Ethnicity;//id
        public int AccountStatus;//id
        public int CreatedByUser = 290;

        public OscaLearner()
        {
        }
        public int CreateOscaLearner(ApplicationForm app)
        {

            string sql = "";

            Hashtable ht = new Hashtable();

            ht.Add("Learner_Ref", "");

            int iTitle = 1;
            switch (app._app_Title)
            {

                case "Mr": iTitle = 1;
                    break;
                case "Mrs": iTitle = 3;
                    break;
                case "Dr": iTitle = 4;
                    break;
                case "Miss": iTitle = 7;
                    break;
                default: iTitle = 1;
                    break;
            }

            string[] sPostCode = app._app_PermPostCode.Split(' ');
            string Learner_PostCode1 = "";
            string Learner_PostCode2 = "";
            if (sPostCode.Length > 1)
            {
                Learner_PostCode1 = sPostCode[0];
                Learner_PostCode2 = sPostCode[1];

            }

            DateTime dt = new DateTime();

            ht.Add("Learner_Id_Titles", iTitle);
            ht.Add("Learner_FirstName", app._app_FirstName);
            ht.Add("Learner_Middlename", "");
            ht.Add("Learner_Surname", app._app_Surname);
            ht.Add("Learner_Gender", app._app_Gender == "1" ? 1 : 2);
            ht.Add("Learner_DOB", DSP.BAL.Basic.ConvertDateToSQL(app._app_DOB));
            ht.Add("Learner_IsActive", 1);
            ht.Add("Learner_Address1", app._app_PermAddress1);
            ht.Add("Learner_Address2", app._app_PermAddress2);
            ht.Add("Learner_Address3", app._app_PermAddress3);
            ht.Add("Learner_Address4", app._app_PermAddress4);
            ht.Add("Learner_Address5", app._app_PermAddress5);
            ht.Add("Learner_PostCode1", Learner_PostCode1);
            ht.Add("Learner_PostCode2", Learner_PostCode2);

            ht.Add("Learner_Telephone", app._app_HomeTel);
            ht.Add("Learner_Telephone2", "");
            ht.Add("Learner_TelephoneWork1", "");
            ht.Add("Learner_TelephoneWork2", "");
            ht.Add("Learner_Mobile1", app._app_Mobile);
            ht.Add("Learner_Mobile2", "");
            ht.Add("Learner_Email1", app._app_Email);
            ht.Add("Learner_Email2", "");
            ht.Add("Learner_IsOverseas", 0);
            ht.Add("Learner_OCRDate", DSP.BAL.Basic.ConvertDateToSQL(dt.ToShortDateString()));
            ht.Add("Learner_OCRNumber", "");
            ht.Add("Learner_IsOCRRegistered", "0");
            ht.Add("Learner_ReceivedDate", DSP.BAL.Basic.ConvertDateToSQL(dt.ToShortDateString()));
            ht.Add("Learner_BookedDate", DSP.BAL.Basic.ConvertDateToSQL(dt.ToShortDateString()));
            ht.Add("Learner_IsFunded", "0");
            ht.Add("Learner_IsClaimed", "0");
            ht.Add("Learner_Occupation", "0");
            ht.Add("Learner_CreatedDate", DSP.BAL.Basic.ConvertDateToSQL(DateTime.Now.ToShortDateString()));
            ht.Add("Learner_Id_MaritalStatus", "1");
            ht.Add("Learner_Id_Assessor1", "0");
            ht.Add("Learner_Id_Employer", "0");
            ht.Add("Learner_Id_Status", "1");
            ht.Add("Learner_Id_DealingPerson", "197");

            ht.Add("Learner_Id_Ethnicity", app._app_Ethnicity);
            ht.Add("Learner_Id_Country", 224);
            ht.Add("Learner_CreatedByUser", 291);
            ht.Add("Learner_Id_PStatus", 1);
            ht.Add("LastLearnerId", "0");
          
            int iLastAdded = DSP.DAL.SQLOSCA.ExecuteSPByHashTableAndReturnScalar("SP_AddNewLearner", ht);

            sql = " SELECT top 1 Learner_Id FROM LearnerContacts Order by Learner_Id desc ";//SELECT Learner_Id FROM LearnerContacts WHERE Learner_Id = @@IDENTITY "; //SELECT SCOPE_IDENTITY() ;
            DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                iLastAdded = int.Parse(ds.Tables[0].Rows[0]["Learner_Id"].ToString());              
            }
            else
            {
                iLastAdded = 0;
            }

            _learner_id = iLastAdded;
            return iLastAdded;

        }


        public void updateLearnerContacts(ApplicationForm app, int iLearnerId)
        {                     
            string strSQL = " UPDATE [LearnerContacts] SET ";
            strSQL += "  [Learner_NI] = '" + DSP.BAL.Basic.FormatStringForSQL(app._app_NI.Trim().ToUpper()) + "' ";
            strSQL += " ,[Learner_Id_Nationality] =  " + app._app_Nationality;
            strSQL += " ,[Learner_StartDate] =  getdate() ";
            strSQL += " WHERE [Learner_Id] =  " + iLearnerId.ToString();
            DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);
        }

        
        public int InsertLearnerCourses(bool bCompleted, bool bFunded, string sCompleteDate, string strLearnerId, string strCourseId, string strCourseStatus)
        {
            string sCompleted = "0";
            string sFunded = "0";
            
            string strSQL = "";
            strSQL = "INSERT INTO [LearnerCourses] ";
            strSQL += "([LearnerCourses_Id_Learner] ";
            strSQL += ",[LearnerCourses_Id_Course] ";
            strSQL += ",[LearnerCourses_IsCompleted] ";

            if (bCompleted)
            {
                sCompleted = "1";
                strSQL += ",[LearnerCourses_CompletedDate] ";
            }

            if (bFunded )
            {
                sFunded = "1";
                strSQL += ",[LearnerCourses_IsFunded] ";
            }
            
            strSQL += ",[LearnerCourses_Id_CoursesStatus] ";
            strSQL += ",[LearnerCourses_CreatedByUser] ";
            strSQL += ",[LearnerCourses_CreatedDate] ";
            strSQL += ") ";
            strSQL += "VALUES ";
            strSQL += "( " + strLearnerId;
            strSQL += ", '" + strCourseId + "' ";
            strSQL += ",  " + sCompleted;

            //
            if (bCompleted)
            {
                strSQL += ", '" + sCompleteDate + "'";
            }

            if (bFunded)
            {

                strSQL += ", '" + sFunded + "'";
            }


            strSQL += " , '" + strCourseStatus + "' ";
            strSQL += " , '" + "291" + "' ";
            strSQL += " , getdate() ";
            strSQL += " ) ";

            strSQL += " ; SELECT LearnerCourses_Id FROM LearnerCourses WHERE LearnerCourses_Id = @@IDENTITY";

            int iLastAdded;
            DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(strSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                iLastAdded = int.Parse(ds.Tables[0].Rows[0]["LearnerCourses_Id"].ToString());      

            }
            else
            {
                iLastAdded = 0;
            }


            InsertRegInfoCourseActivity(strLearnerId, iLastAdded.ToString());
            InsertJourneySSandMatrix(int.Parse(strLearnerId), iLastAdded);
            InsertLearnerMatrix(int.Parse(strLearnerId), iLastAdded);
        
            return iLastAdded;



        }



        public void InsertRegInfoCourseActivity(string iLearnerId, string iCurrentCourseId)
        {
            string strSQL = "";
            strSQL = " INSERT INTO [Link_LearnerRegInfo] ";
            strSQL += " ([LRI_Id_Learner] ";
            strSQL += ",[LRI_Id_LearnerCourse]";
            strSQL += ",[LRI_Id_AwardingBody]";
            strSQL += ",[LRI_Id_FolioLocation]";
            strSQL += ",[LRI_Id_FolioStatus]";

            strSQL += ",[LRI_Id_FormativeIV]";
            strSQL += ",[LRI_Id_SummativeIV]";

            strSQL += ",[LRI_EnteredDate]";
            strSQL += ",[LRI_EnteredByUser]";
            strSQL += ")";

            strSQL += " VALUES ( ";
            strSQL += " '" + iLearnerId + "' ";
            strSQL += " ,'" + iCurrentCourseId + "' ";
            strSQL += " , 1 ";
            strSQL += " , 1 ";
            strSQL += " , 6 ";

            strSQL += " , 4 ";
            strSQL += " , 4 ";

            strSQL += " , getdate() ";
            strSQL += " , '291' ";// +objSession.getSessionUserId();
            strSQL += "  )";
            DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);


        }

        public void InsertJourneySSandMatrix(int iLearner, int iLearnerCourseId)
        {

            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("LearnerId", iLearner);
            ht.Add("LearnerCourseId", iLearnerCourseId);
            // course will be found automatically in the SP --   
            DSP.DAL.SQLOSCA.ExecuteSPByHashTable("SP_SS_InsertJLP", ht);
        
        
        }


        public void InsertLearnerMatrix(int iLearner, int iLearnerCourseId)
        {

            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("LearnerId", iLearner);
            ht.Add("LearnerCourseId", iLearnerCourseId);
            // course will be found automatically in the SP --   
         //old method   DSP.DAL.SQLOSCA.ExecuteSPByHashTable("SP_SS_InsertMatrixFaster", ht);
            DSP.DAL.SQLOSCA.ExecuteSPByHashTable("SP_SS_MatrixLearnersCreate", ht);
            



    }


        public void InsertLearnerNote(int iLearner, string sContent, string sUserId)
        { 
            string strSQL; 

            strSQL = "INSERT INTO LearnerNotes ";
            strSQL += " (LearnerNotes_Id_Learner,LearnerNotes_DateTime,LearnerNotes_Note,";
            strSQL += "LearnerNotes_IsActive,LearnerNotes_IsDeleted,";
            strSQL += "LearnerNotes_Id_EnteredByUser, LearnerNotes_isChecked) ";
            strSQL += " VALUES (" + iLearner + ", getDate() , '" + sContent + "', 1 , 0 , " + sUserId + ", 0)";

            DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);
            
        }



    }//OscaLearner
} //DSP.BAL
