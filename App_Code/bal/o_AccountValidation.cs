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

    public class AccountValidation
    {
        public AccountValidation()
        {

        }


        #region " stuff "       
        public static DataSet GetEmailById(int iEmailId)
        {
            return DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM EmailLogs WHERE EL_Id = " + iEmailId.ToString());

        }

        public static DataSet GetAllEmailSentByFrom(string sFrom)
        {
             return DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM EmailLogs WHERE EL_IsDeleted = 0 AND EL_Username = '" + sFrom + "' ORDER BY EL_SentDate DESC ");
       
        }

        public static DataSet GetAllEmailSentByFrom(string sFrom, string sToLearner)
        {
              return DSP.DAL.SQL.GetRecordsBySQL("SELECT * FROM EmailLogs WHERE EL_IsDeleted = 0 AND EL_From = '" + sFrom + "' AND EL_LearnerId = '" + sToLearner + "' ORDER BY EL_SentDate DESC ");

        }
        
        public static void UpdateReadEmail(int iEmailId)
        {
            DSP.DAL.SQL.ExecuteSQL("UPDATE EmailLogs SET EL_ReadOn=getdate() , EL_IsRead = 1 WHERE EL_Id = " + iEmailId.ToString());

        }
        public static void UpdateUnReadEmail(int iEmailId)
        {
            DSP.DAL.SQL.ExecuteSQL("UPDATE EmailLogs SET EL_ReadOn=getdate() , EL_IsRead = 0 WHERE EL_Id = " + iEmailId.ToString());

        }
        public static void DeleteEmail(int iEmailId, int iUserId)
        {
            DSP.DAL.SQL.ExecuteSQL("UPDATE EmailLogs SET EL_IsDeleted= 1 , EL_DeletedDate =getdate() , EL_DeletedByUser = '" + iUserId + "' WHERE EL_Id = " + iEmailId.ToString());

        }
        
        public static int InsertEmailLogs(string sSubject, string sUserName, string sFrom, string sTo, string sBody, string sUserId, string sCourseName, string sTopicName, string sFileName, string sLearnerId, string iTopicId)
        {

            string sLearnerName = DSP.BAL.DBL.GetLearnerNameSurname(int.Parse(sLearnerId));

            string sSQL = "INSERT INTO EmailLogs (EL_Subject, EL_Username, EL_From, EL_To, EL_SentDate, EL_SentByUser,EL_IsArchived,EL_Body, EL_CourseName, EL_TopicName, EL_FileName, EL_LearnerId, EL_LearnerName, EL_Id_Topic) ";
            sSQL += " VALUES ('" + DSP.BAL.Basic.FormatStringForSQL(sSubject) + "', '" + sUserName + "', '" + sFrom + "', '" + sTo + "', getdate(), " + sUserId + ",0, '" + DSP.BAL.Basic.FormatStringForSQL(sBody) + "','" + sCourseName + "','" + sTopicName + "','" + sFileName + "', " + sLearnerId + ",'" + sLearnerName + "'," + iTopicId +" ) ";
         
            int iLastAdded = 0;
            sSQL += "; SELECT EL_Id FROM EmailLogs WHERE EL_Id = @@IDENTITY ";
            DataSet ds = DSP.DAL.SQL.GetRecordsBySQL(sSQL );
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    iLastAdded = int.Parse(ds.Tables[0].Rows[0]["EL_Id"].ToString());
                }
                catch (Exception exx)
                {
                    iLastAdded = 0;
                }


            }
            else
            {
                iLastAdded = 0;
            }


            return iLastAdded;

        }

        public static void InsertEmailSuggestions(string sSubject, string sUserName, string sUserId)
        {

            string sSQL = "INSERT INTO EmailUserSubjectSuggestions (EUSS_Title, EUSS_CreatedDate, EUSS_CreatedByUsername, EUSS_CreatedByUser) ";
            sSQL += " VALUES ('" + DSP.BAL.Basic.FormatStringForSQL(sSubject) + "',  getdate(), '" + sUserName + "', '" + sUserId + "' ) ";
            DSP.DAL.SQL.ExecuteSQL(sSQL);

        }

        public static void ClearEmailSuggestions(string sUserName, string sUserId)
        {

            string sSQL = "Update EmailUserSubjectSuggestions SET EUSS_IsDeleted = 1 , EUSS_DeletedDate = getdate() , EUSS_DeletedByUser = '" + sUserId + "', EUSS_DeletedByUsername = '" + sUserName + "' ";
            sSQL += " WHERE EUSS_CreatedByUsername = '" + sUserName + "' AND EUSS_CreatedByUser = '" + sUserId + "' ; ";
            DSP.DAL.SQL.ExecuteSQL(sSQL);

        }

        #endregion

        #region " account validation "

        public static Guid InsertValidation(int iLearnerId, string sLearnerName, string sLearnerEmail, string sUsername)
        {

            Guid gd = new Guid();
          
            Hashtable ht = new Hashtable();
            ht.Add("@Guid", gd);
            ht.Add("@Learner_Id",iLearnerId );
            ht.Add("@LearnerName", sLearnerName);
            ht.Add("@Email", sLearnerEmail);
            ht.Add("@Username", sUsername);

            DSP.DAL.SQL.ExecuteSPByHashTable("SP_AV_InsertValidation", ht);
         
            return gd;

        }


        #endregion

    }//AccountValidation
} //DSP.BAL

 