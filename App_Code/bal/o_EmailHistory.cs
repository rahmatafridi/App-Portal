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


namespace DSP.BAL
{

    public class EmailHistory
    {
        public EmailHistory()
        {

        }

        public static DataSet GetEmailById(int iEmailId)
        {
            return DSP.DAL.SQL.GetRecordsBySQL("SELECT eh.*, el.* FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id WHERE eh.EH_Id = " + iEmailId.ToString());

        }

         

        
        public static int GetTotalEmails(string sReceipient)
        {
            DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT count(el.EL_Id) as nb FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id WHERE EH_IsDeleted = 0 AND EH_To = '" + sReceipient + "' AND EH_IsRead = 0 ");
            int i = 0 ;
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
            {
                i = int.Parse(ds.Tables[0].Rows[0]["nb"].ToString());                
            }   
            return i;
        }

       


        public static DataSet GetAllEmails(string sReceipient, int iread )
        {

            string strsql = "SELECT eh.*, el.* FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id WHERE EH_IsDeleted = 0 AND EH_To = '" + sReceipient + "' {0} ORDER BY EH_SentDate DESC ";
            if (iread != 0) {
                strsql = string.Format(strsql, " AND EH_IsRead = 1 ");
                }else{
                    strsql = string.Format(strsql, " AND EH_IsRead = 0 ");
           
            }
             return DSP.DAL.SQL.GetRecordsBySQL(strsql);

        }



        public static DataSet GetAllEmails(string sReceipient, int iLearner, int iread )
        {

            string strsql = "SELECT eh.*, el.* FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id WHERE EH_IsDeleted = 0 AND EH_To = '" + sReceipient + "' AND EH_LearnerId = '" + iLearner.ToString() + "' {0} ORDER BY EH_SentDate DESC ";

            if (iread != 0) {
                strsql = string.Format(strsql, " AND EH_IsRead = 1 ");
            }
            else
            {
                strsql = string.Format(strsql, "  AND EH_IsRead = 0 ");
            }
              return DSP.DAL.SQL.GetRecordsBySQL(strsql);

        }
        

        public static DataSet GetAllEmailsForLearnerCourse(int iLearnerId, int iCourseId, int iTopicId)
        {
             string sql = "SELECT eh.*, el.*, u.Users_Username FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id left outer join Users as u ON u.Users_Id = eh.EH_SentByUser WHERE EH_IsDeleted = 0 AND  EH_LearnerId = {0} AND EH_CourseId = {1} AND EH_TopicId = {2}  ORDER BY EH_SentDate DESC";
            sql = string.Format(sql, iLearnerId.ToString(), iCourseId.ToString(), iTopicId.ToString());
            return DSP.DAL.SQL.GetRecordsBySQL(sql);
      
        }



        public static void UpdateRead(int iEmailId)
        {
            DSP.DAL.SQL.ExecuteSQL("UPDATE EmailHistory SET EH_ReadOn=getdate() , EH_IsRead = 1 WHERE EH_Id = " + iEmailId.ToString());

        }
        public static void UpdateUnRead(int iEmailId)
        {
            DSP.DAL.SQL.ExecuteSQL("UPDATE EmailHistory SET EH_UnReadOn=getdate() , EH_IsRead = 0 WHERE EH_Id = " + iEmailId.ToString());

        }
        public static void Delete(int iEmailId, int iUserId, string sUsername)
        {
            DSP.DAL.SQL.ExecuteSQL("UPDATE EmailHistory SET EH_IsDeleted= 1 , EH_DeletedDate =getdate() , EH_DeletedByUser = '" + iUserId + "', EH_DeletedByUserName = '"+sUsername+"' WHERE EH_Id = " + iEmailId.ToString());

        }



        public static void InsertEmailHistory(int iEmailId, string sSubject, string sUsername, string sFrom, string sTo, string sBody, string sUserId, string sCourseName, string sTopicName, string sFileName, int iLearnerId, int iLearnerCourse, int iTopic, string sFileCaption)
        {
            string sLearnerName = DSP.BAL.DBL.GetLearnerNameSurname(iLearnerId);

            string sSQL = "INSERT INTO EmailHistory (EH_Id_Email, EH_Subject, EH_Username, EH_From, EH_To, EH_SentDate, EH_SentByUser,EH_IsArchived,EH_Body, EH_CourseName,EH_TopicName,EH_FileName, EH_LearnerId, EH_LearnerName, EH_CourseId , EH_TopicId , EH_FileCaption) ";
            sSQL += " VALUES ('" + iEmailId.ToString() + "','" + DSP.BAL.Basic.FormatStringForSQL(sSubject) + "', '" + sUsername + "', '" + sFrom + "', '" + sTo + "', getdate(), " + sUserId + ",0, '" + DSP.BAL.Basic.FormatStringForSQL(sBody) + "','" + sCourseName + "','" + sTopicName + "','" + sFileName + "'," + iLearnerId.ToString() + ",'" + sLearnerName + "', " + iLearnerCourse.ToString() + "," + iTopic.ToString() + " , '" + sFileCaption + "') ";
            DSP.DAL.SQL.ExecuteSQL(sSQL);

        }

 


        public static DataSet GetAllEmailsForLearner(string sLearnerEmail)
        {

            return DSP.DAL.SQL.GetRecordsBySQL("SELECT eh.*, el.* FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id WHERE EH_IsDeleted = 0 AND EH_To = '" + sLearnerEmail + "'AND EH_IsRead = 0 ORDER BY EH_SentDate DESC ");

        }
        public static DataSet GetAllEmailsForLearnerRead(string sLearnerEmail)
        {

            return DSP.DAL.SQL.GetRecordsBySQL("SELECT eh.*, el.* FROM EmailLogs as el inner join EmailHistory as eh ON eh.EH_Id_Email = el.EL_Id WHERE EH_IsDeleted = 0 AND EH_To = '" + sLearnerEmail + "' AND EH_IsRead = 1 ORDER BY EH_SentDate DESC ");

        }


    }//EmailHistory
} //DSP.BAL

 