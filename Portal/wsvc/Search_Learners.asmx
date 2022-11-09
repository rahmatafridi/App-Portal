<%@ WebService Language="C#" Class="Search_Learners" %>

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

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Search_Learners : System.Web.Services.WebService 
{

 
     
    [WebMethod]
    public string[] Get_LearnerSurnames(string prefixText)
    {
        //MyFunctions func = new MyFunctions();

        int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());
       
        string sSQL = "SELECT  distinct([LC].Learner_Surname) FROM LearnerContacts as [LC]";
        sSQL += " inner join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";
        sSQL += " AND [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
        sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
        sSQL += " WHERE Learner_Surname like '" + prefixText + "%' ORDER BY Learner_Surname ASC ";
      
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
    public string[] Get_AssessorLearnerSurnames(string prefixText)
    {        
        int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());

        string sSQL = "SELECT  distinct([LC].Learner_Surname) FROM LearnerContacts as [LC]";
        sSQL += " inner join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";
        sSQL += " inner join AssessorContacts as [ac] on [ac].Assessor_Id = [LLC].LearnerAssessor_Id_Assessor ";
         
        sSQL += " WHERE [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
      //  sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
        sSQL += " AND [ac].Assessor_ReportToIV = '" + iIdAssessor + "' ";
          
        sSQL += " AND Learner_Surname like '" + prefixText + "%' ORDER BY Learner_Surname ASC ";

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
    public string[] Get_SuggestionSendTo(string prefixText)
    {
        //MyFunctions func = new MyFunctions();

        int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());

        string sSQL = "SELECT  Learner_FirstName + ' ' + Learner_Surname + ' ' + cast(Learner_Id as varchar(10)) + '<'+ [LC].Learner_Email1 + '>' ";
        sSQL += " FROM LearnerContacts as [LC] ";
        sSQL += " WHERE Learner_Id IN (select distinct ([LLC].LearnerAssessor_Id_Learner) ";
        sSQL += "    FROM  Link_LearnerAssessor as [LLC] WHERE [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID AND [LLC].LearnerAssessor_DealingWith = 1 " ; // = '" + iIdAssessor + "' ";
        sSQL += "    AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ) ";
        sSQL += " AND [LC].Learner_IsInProcess = 0  AND (Learner_Surname like '" + prefixText + "%'   ";
        sSQL += "  OR Learner_FirstName like '" + prefixText + "%'  ";
        sSQL += "  OR Learner_Email1 like '%" + prefixText + "%'  ";
        sSQL += "  OR Learner_Id like '" + prefixText + "%' ) ";
        sSQL += "  ORDER BY Learner_Email1 ASC ";

    /*    string sSQL = "SELECT  distinct(Learner_FirstName + ' ' + Learner_Surname + ' ' + cast(Learner_Id as varchar(10)) + '<'+ [LC].Learner_Email1 + '>' ) as Learner FROM LearnerContacts as [LC]";
        sSQL += " inner join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";
        sSQL += " WHERE [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
        sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
        sSQL += "  AND Learner_Surname like '" + prefixText + "%'   ";
        sSQL += "  OR Learner_FirstName like '" + prefixText + "%'  ";
        sSQL += "  OR Learner_Email1 like '%" + prefixText + "%'  ";
        sSQL += "  OR Learner_Id like '" + prefixText + "%'  ";
        sSQL += "  ORDER BY Learner_Email1 ASC ";*/
        
        
        
        /* 

 
 
AND [LLC].LearnerAssessor_Id_Assessor = '181' )
AND [LC].Learner_IsInProcess = 0  
 AND 
(Learner_Surname like 'pa%' 
    OR Learner_FirstName like 'pa%'    
OR Learner_Email1 like '%pa%'    OR Learner_Id like 'pa%' ) */
        
        
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
        
        int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());

        string sSQL = "SELECT  distinct(euss.EUSS_Title) FROM EmailUserSubjectSuggestions as euss";
        //sSQL += " inner join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";
        //sSQL += " AND [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
        //sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
        sSQL += " WHERE EUSS_CreatedByUsername = '" + Membership.GetUser().UserName + "'   ";
        sSQL += "  AND EUSS_IsDeleted = 0 ";
        sSQL += "  ORDER BY EUSS_Title  ASC ";
    
        DataSet dtst = DSP.DAL.SQL.GetRecordsBySQL(sSQL);

        string[] cntName = new string[dtst.Tables[0].Rows.Count];
        
        int i = 0;
        
        foreach (DataRow rdr in dtst.Tables[0].Rows)
        {
            cntName.SetValue(rdr[0].ToString(), i);
            i++;
        }
        
        return cntName;
    }   
    
}

