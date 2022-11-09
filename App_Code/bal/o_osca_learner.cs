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

    public class OSCA_Learner
    {
        public OSCA_Learner()
        {

        }

        public static string GetLearnerEmailById(string sOscaId)
        {
            return DSP.DAL.SQLOSCA.GetOneValueBySQL("SELECT Learner_Email1 FROM LearnerContacts WHERE Learner_Id = " + sOscaId, "Learner_Email1");
  
        }

        


       

    }// 
} //DSP.BAL

 