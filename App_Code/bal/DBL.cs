using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.Caching;

namespace DSP.BAL
{


    /// <summary>
    /// Summary description for DB Logic - only function that have interaction with the database- 
    /// </summary>
    public class DBL
    {

        public DBL()
        {
        }


        public static string GetEmailTemplateBodyReplacedByCode(string template_code, Hashtable ht)
        {
            string sRowBody = DSP.DAL.SQL.GetOneValueBySP("SP_Gen_GetEmailTemplateByCode", "ET_Code", template_code, "ET_Body");


            IDictionaryEnumerator _enumerator = ht.GetEnumerator();

            while (_enumerator.MoveNext())
            {
                sRowBody = sRowBody.Replace(_enumerator.Key.ToString(), _enumerator.Value.ToString());
            }
            return sRowBody;
        }

        public static Tuple<string, string> GetSubjectAndEmailTemplateBodyReplacedByCode(string template_code, Hashtable ht)
        {
            Hashtable s_ht = new Hashtable();
            s_ht.Add("ET_Code", template_code);
            DataSet ds = DSP.DAL.SQL.GetDsBySPArray("SP_Gen_GetEmailTemplateByCode", s_ht);
            string sRowBody = "";
            string sSubject = "";

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sRowBody = ds.Tables[0].Rows[0]["ET_Body"].ToString();
                    sSubject = ds.Tables[0].Rows[0]["ET_Subject"].ToString();
                }
                catch (Exception ex)
                {
                    sRowBody = "";
                }
            }
            else
            {
                sRowBody = "";
            }
            IDictionaryEnumerator _enumerator = ht.GetEnumerator();

            while (_enumerator.MoveNext())
            {
                sRowBody = sRowBody.Replace(_enumerator.Key.ToString(), _enumerator.Value.ToString());
            }
            return Tuple.Create(sSubject, sRowBody);
        }
        public static string GetEmailTemplateBodyReplaced(int iId, Hashtable ht)
        {
            string sRowBody = DSP.DAL.SQL.GetOneValueBySP("SP_Gen_GetEmailTemplateById", "Id", iId, "ET_Body");


            IDictionaryEnumerator _enumerator = ht.GetEnumerator();

            while (_enumerator.MoveNext())
            {
                sRowBody = sRowBody.Replace(_enumerator.Key.ToString(), _enumerator.Value.ToString());
            }

            //strBody = strBody.Replace("[USER_PASSWORD]", sPass);
            // strBody = strBody.Replace("[USER_IDLEARNER]", sIdLearner);
            // strBody = strBody.Replace("[USER_PASSWORD]", DateTime.Now.ToString());

            return sRowBody;

        }

        public static string GetEmailTemplateTitle(int iId)
        {
            string sRowBody = DSP.DAL.SQL.GetOneValueBySP("SP_Gen_GetEmailTemplateById", "Id", iId, "ET_Title");
            return sRowBody;
        }

        public static string GetConfigValue(string sCode)
        {
            DataSet ds = DSP.DAL.SQL.GetDsBySP("SP_ConfigGet", "Code", sCode);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                 return "";
            }
            else
            {
                return ds.Tables[0].Rows[0]["Value"].ToString() ;
            }
             
        }


        public static string ConvertSQLDateToUKDate(object fieldData)
        {
            string strDate = "";

            if (fieldData.ToString().Trim() != "")
            {
                strDate = Convert.ToDateTime(fieldData).Day + "/" + Convert.ToDateTime(fieldData).Month + "/" + Convert.ToDateTime(fieldData).Year;
            }

            return strDate;
        }



        public static int GetUser_LearnerId(string sUsername)
        {

            string sSQL = "SELECT Users_Id_LearnerContacts FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
                return -1;
            }
            else
            {
                return int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_LearnerContacts"].ToString());
            }



        }

        public static void UpdateUser_Email(string sUsername, string sEmail)
        {

            string sSQL = "UPDATE Users SET Users_Email = '{1}' WHERE Users_UserName = '{0}' AND Users_IsActive =  1 ;";
            DSP.DAL.SQL.ExecuteSQL(String.Format(sSQL, sUsername, sEmail));
        }

        public static void UpdateOsca_LearnerEmail(string sLearnerId, string sEmail)
        {

            string sSQL = "UPDATE LearnerContacts SET Learner_Email1 = '{1}' WHERE Learner_Id = '{0}' ;";
            DSP.DAL.SQLOSCA.ExecuteSQL(String.Format(sSQL, sLearnerId, sEmail));
        }

        public static int GetUser_AssessorId(string sUsername)
        {

            string sSQL = "SELECT Users_Id_AssessorContacts FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
                return -1;
            }
            else
            {
                return int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString());
            }



        }

        public static string GetUser_AssignedAssessorEmail(string sUsername)
        {
            int iAssessorId = 0;
            string sEmailAssessor = "";

            string sSQL = "SELECT Users_Id_AssessorContacts FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
                iAssessorId = -1;
            }
            else
            {
                iAssessorId = int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString());
            }



            // sEmailAssessor = DSP.DAL.SQLOSCA.GetOneValueBySP("SP_GetListAssessorForLearner", "@LearnerId", iAssessorId, "Assessor_Email1");
            sEmailAssessor = DSP.DAL.SQLOSCA.GetOneValueBySP("SP_GetListAssessorForLearner", "@LearnerId", GetUser_LearnerId(sUsername), "Assessor_Email1");
            return sEmailAssessor;

        }

        public static string GetLearnerNameSurname(int iLearner)
        {
            string sLearnerName = "";

            string sSQL = "SELECT  ([LC].Learner_FirstName + ' ' + [LC].Learner_Surname ) as LearnerName ";
            sSQL += " FROM LearnerContacts as [LC] WHERE [LC].Learner_ID = " + iLearner.ToString();


            // sSQL = "SELECT Users_Id_AssessorContacts FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQLOSCA.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
                // sLearnerName = -1;
            }
            else
            {
                sLearnerName = dsUser.Tables[0].Rows[0]["LearnerName"].ToString();
            }



            // sEmailAssessor = DSP.DAL.SQLOSCA.GetOneValueBySP("SP_GetListAssessorForLearner", "@LearnerId", iAssessorId, "Assessor_Email1");
            //      sEmailAssessor = DSP.DAL.SQLOSCA.GetOneValueBySP("SP_GetListAssessorForLearner", "@LearnerId", GetUser_LearnerId(sUsername), "Assessor_Email1");
            return sLearnerName;

        }



        public static int GetUser_UserIdOSCA(string sUsername)
        {

            // string sUsers_Id_OSCA = (string)Page.Session["Users_Id_OSCA"];

            // if ((sUsers_Id_OSCA == null) || (sUsers_Id_OSCA == ""))
            //  {
            string sSQL = "SELECT Users_Id_OSCA FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else
            {
                return int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_OSCA"].ToString());
            }

            //}
            //else
            //{
            //    return int.Parse(sUsers_Id_OSCA);
            //}

        }

        public static int GetUser_UserId(string sUsername)
        {
            string sSQL = "SELECT Users_Id FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else
            {
                return int.Parse(dsUser.Tables[0].Rows[0]["Users_Id"].ToString());
            }

        }

        public static string GetUser_Email(string sUsername)
        {
            string sSQL = "SELECT Users_Email FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dsUser.Tables[0].Rows[0]["Users_Email"].ToString();
            }

        }
        public static string GetUser_LearnerEmail(int iLearnerId)
        {
            string sSQL = "SELECT Users_Email FROM Users WHERE Users_Id_LearnerContacts = '" + iLearnerId.ToString() + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dsUser.Tables[0].Rows[0]["Users_Email"].ToString();
            }

        }

        public static string GetUser_DisplayName(string sUsername)
        {
            string sSQL = "SELECT Users_DisplayName FROM Users WHERE Users_UserName = '" + sUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dsUser.Tables[0].Rows[0]["Users_DisplayName"].ToString();
            }

        }

        public static string GetOneValueBySP(string sSP_Name, string sSP_Var, int iSP_Value, string sField)
        {

            //SP_Track_Global_GetUserEmail
            // DataSet ds = objFuncs.Get(strSQL);

            DataSet ds = DSP.DAL.SQLOSCA.GetDsBySP(sSP_Name, sSP_Var, iSP_Value);

            string sValue = "";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sValue = ds.Tables[0].Rows[0][sField].ToString();
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
            return sValue;


        }

        public static string GetOneValueBySP(string sSP_Name, Hashtable htHashTable, string sField)
        {

            //SP_Track_Global_GetUserEmail
            // DataSet ds = objFuncs.Get(strSQL);

            //IDictionaryEnumerator _enumerator = htHashTable.GetEnumerator();

            //while (_enumerator.MoveNext())
            //{
            //    cmd.Parameters.Add(new SqlParameter(_enumerator.Key.ToString(), int.Parse(_enumerator.Value.ToString())));
            //    cmd.Parameters.Add(new SqlParameter(_enumerator.Key.ToString(), _enumerator.Value.ToString()));

            //    _string += _enumerator.Key + " ";
            //    _string += _enumerator.Value + "\n";
            //}



            DataSet ds = DSP.DAL.SQLOSCA.GetDsBySPArray(sSP_Name, htHashTable);

            string sValue = "";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sValue = ds.Tables[0].Rows[0][sField].ToString();
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
            return sValue;


        }

        public static void QCF_InsertLearnersJourney(int iLearnerId, int iLearnerCourseId)
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("Curr_LearnerId", iLearnerId);
            ht.Add("Curr_CourseId", iLearnerCourseId);
            // course will be found automatically in the SP --   ht.Add("CourseId",);
            DSP.DAL.SQLOSCA.ExecuteSPByHashTable("SP_QCF_InsertLearnersJourney", ht);


        }

        public static void InsertFeedback(string sUsername, string sCategory, string sMsg)
        {


            /*F_Id
    F_UserName
    F_Email
    F_Cat
    F_Message
    F_EnteredDate
    F_IsDeleted
    F_IsActioned
    */
            string sSQL = "INSERT INTO Feedback (F_UserName, F_Email, F_Cat, F_Message, F_EnteredDate,F_IsDeleted,F_IsActioned) ";
            sSQL += " VALUES ('" + sUsername + "', '" + sUsername + "', '" + sCategory + "', '" + DSP.BAL.Basic.FormatStringForSQL(sMsg) + "', getdate(), 0, 0) ";
            DSP.DAL.SQL.ExecuteSQL(sSQL);




        }







        //Application stuff

        public static string GetApplicationOptionTitle(string sHeader, string sValue)
        {
            string sTitle = "";
            Hashtable ht = new Hashtable();
            ht.Add("@Header", sHeader);
            ht.Add("@Value", sValue);
            DataSet ds = DSP.DAL.SQL.GetDsBySPArray("SP_GetApplicationOptionTitleByValue", ht);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                sTitle = ds.Tables[0].Rows[0]["Opt_Title"].ToString();
            }
            ds.Dispose();
            return sTitle;

        }
        public static string GetYesNo(string sValue)
        {
            if (sValue == "1")
            {
                return "Yes";
            }
            else
            {
                return "No";
            }



        }
        public static string GetChecked(string sValue)
        {
            if (sValue == "1")
            {
                return " checked ";
            }
            else
            {
                return " ";
            }



        }
        public static void AddApplicationHistory(int iIdApp, string sUsername, string sStatus, string sEnteredByUsername, string rejectedReason = "")
        {
            Hashtable ht = new Hashtable();
            ht.Add("IdApp", iIdApp);
            ht.Add("Username", sUsername);
            ht.Add("Status", sStatus);
            ht.Add("ByUserName", sEnteredByUsername);
            if (!string.IsNullOrEmpty(rejectedReason))
            {
                ht.Add("RejectedReason", rejectedReason);
            }
            DSP.DAL.SQL.ExecuteSPByHashTable("[oscauser].[SP_App_InsertApplicationsHistory]", ht);
        }

        public DataSet GetApplicationsWithPaging(int startRowIndex, int maximumRows, string type, int userId, string firstName, string surName, int courseId, string email,
            int inviteId, string fromDateStr, string toDateStr, string sortColumnName)
        {
            Hashtable ht = new Hashtable();
            
            ht.Add("@StartIndex", startRowIndex);
            ht.Add("@MaximumRows", maximumRows);
            ht.Add("@Type", type);
            ht.Add("@UserId", userId);

            ht.Add("@FirstName", firstName);
            ht.Add("@Surname", surName);
            ht.Add("@CourseId", courseId);
            ht.Add("@Email", email);
            ht.Add("@InviteId", inviteId);
            ht.Add("@FromDateStr", fromDateStr);
            ht.Add("@ToDateStr", toDateStr);
            ht.Add("@SortColumn", sortColumnName);
            DataSet ds = DSP.DAL.SQL.GetDsBySPArray("SP_App_GetUserApplicationsByFilterAndPaging", ht);

            int totalRowsCount = 0;
            if(ds.Tables[0].Rows.Count > 0)
            {
                totalRowsCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"].ToString());
            }

            if (HttpRuntime.Cache["CacheTotalRowsCount"] != null)
            {
                HttpRuntime.Cache.Remove("CacheTotalRowsCount");
            }
            HttpRuntime.Cache.Add("CacheTotalRowsCount", totalRowsCount, null, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);

            return ds;

        }
        public static int GetTotalCount(int startRowIndex, int maximumRows, string type, int userId, string firstName, string surName, int courseId, string email, 
            int inviteId, string fromDateStr, string toDateStr)
        {
            int total = 0;
            object cachedCount = HttpRuntime.Cache["CacheTotalRowsCount"];
            if (cachedCount != null)
            {
                total = int.Parse(cachedCount.ToString());
            }            
            return total;
        }

    }

}