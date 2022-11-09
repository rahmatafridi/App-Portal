<%@ WebService Language="C#" Class="Search_Assessors" %>

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
//using System.IO;
//using System.Threading;
using System.Xml.Serialization;

[WebService(Namespace = "http://tempuri.org/1")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Search_Assessors : System.Web.Services.WebService 
{

 
     
    ////[WebMethod]
    ////public string[] Get_LearnerSurnames(string prefixText)
    ////{
    ////    //MyFunctions func = new MyFunctions();

    ////    int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());
       
    ////    string sSQL = "SELECT  distinct([LC].Learner_Surname) FROM LearnerContacts as [LC]";
    ////    sSQL += " inner join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";
    ////    sSQL += " AND [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
    ////    sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
    ////    sSQL += " WHERE Learner_Surname like '" + prefixText + "%' ORDER BY Learner_Surname ASC ";
      
    ////    DataSet dtst = DSP.DAL.SQLOSCA.GetRecordsBySQL(sSQL);

    ////    string[] cntName = new string[dtst.Tables[0].Rows.Count];
        
    ////    int i = 0;
        
    ////    foreach (DataRow rdr in dtst.Tables[0].Rows)
    ////    {
    ////        cntName.SetValue(rdr[0].ToString(), i);
    ////        i++;
    ////    }
        
    ////    return cntName;
    ////}


    ////[WebMethod]
    ////public string[] Get_AssessorLearnerSurnames(string prefixText)
    ////{        
    ////    int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());

    ////    string sSQL = "SELECT  distinct([LC].Learner_Surname) FROM LearnerContacts as [LC]";
    ////    sSQL += " inner join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";
    ////    sSQL += " inner join AssessorContacts as [ac] on [ac].Assessor_Id = [LLC].LearnerAssessor_Id_Assessor ";
         
    ////    sSQL += " WHERE [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
    ////  //  sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
    ////    sSQL += " AND [ac].Assessor_ReportToIV = '" + iIdAssessor + "' ";
          
    ////    sSQL += " AND Learner_Surname like '" + prefixText + "%' ORDER BY Learner_Surname ASC ";

    ////    DataSet dtst = DSP.DAL.SQLOSCA.GetRecordsBySQL(sSQL);

    ////    string[] cntName = new string[dtst.Tables[0].Rows.Count];

    ////    int i = 0;

    ////    foreach (DataRow rdr in dtst.Tables[0].Rows)
    ////    {
    ////        cntName.SetValue(rdr[0].ToString(), i);
    ////        i++;
    ////    }

    ////    return cntName;
    ////}


    //[WebMethod]
    //public string[] GetClasses(string prefixText)
    //{
    //    MyFunctions func = new MyFunctions();
    //    DataSet dtst = func.GetRecordsBySQL("SELECT DISTINCT (Learner_Class) FROM LearnerContacts WHERE Learner_Class like '" + prefixText + "%' ORDER BY Learner_Class ASC ");

    //    string[] cntName = new string[dtst.Tables[0].Rows.Count];

    //    int i = 0;

    //    foreach (DataRow rdr in dtst.Tables[0].Rows)
    //    {
    //        cntName.SetValue(rdr[0].ToString(), i);
    //        i++;
    //    }

    //    return cntName;
    //}


 
    
    // SEARCH when Composing Messages
     
    [WebMethod]
    public string[] Get_SuggestionSendToAssessor(string prefixText)
    {
        int iIdLearner = DSP.BAL.DBL.GetUser_LearnerId(Membership.GetUser().ToString());

        string sSQL = "SELECT  Assessor_FirstName + ' ' + Assessor_Surname + ' ' + '<'+ [AC].Assessor_Email1 + '>' ";
        sSQL += " FROM AssessorContacts as [AC] ";
        sSQL += " WHERE Assessor_Id IN (select distinct ([LLC].LearnerAssessor_Id_Assessor) ";
        sSQL += "   FROM  Link_LearnerAssessor as [LLC] WHERE [LLC].LearnerAssessor_Id_Assessor = [AC].Assessor_Id " ;// >>>> LIVE >>>> AND [LLC].LearnerAssessor_DealingWith = 1 "; // = '" + iIdAssessor + "' ";
        sSQL += "   AND [LLC].LearnerAssessor_Id_Learner = '" + iIdLearner + "' ) ";
        sSQL += "   AND (Assessor_Surname like '" + prefixText + "%'   ";
        sSQL += "  OR Assessor_FirstName like '" + prefixText + "%'  ";
        sSQL += "  OR Assessor_Email1 like '%" + prefixText + "%'  ";
        sSQL += "  OR Assessor_Id like '" + prefixText + "%' ) ";
        sSQL += "  ORDER BY Assessor_Email1 ASC ";
  
        DataSet dtst = DSP.DAL.SQLOSCA.GetRecordsBySQL(sSQL);

        string[] cntName = new string[dtst.Tables[0].Rows.Count];
        
        int i = 0;
        
        foreach (DataRow rdr in dtst.Tables[0].Rows)
        {
            cntName.SetValue(rdr[0].ToString(), i);
            i++;
        }
        
        return cntName;
    }

        
       [WebMethod]
    public string[] Get_SuggestionSubject(string prefixText)
    {
        
      //  int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());

        string sSQL = "SELECT  distinct(euss.EUSS_Title) FROM EmailUserSubjectSuggestions as euss";         
        sSQL += " WHERE EUSS_CreatedByUsername = '" + Membership.GetUser().UserName + "'   ";
        sSQL += "  AND EUSS_IsDeleted = 0 ";
        sSQL += "  ORDER BY EUSS_Title  ASC ";
    
        DataSet dtst = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
        if (dtst != null && dtst.Tables.Count > 0 && dtst.Tables[0].Rows.Count > 0)
        {
            string[] cntName = new string[dtst.Tables[0].Rows.Count];

            int i = 0;

            foreach (DataRow rdr in dtst.Tables[0].Rows)
            {
                cntName.SetValue(rdr[0].ToString(), i);
                i++;
            }

            return cntName;
        
        }
        return null;
    }   
    
}

