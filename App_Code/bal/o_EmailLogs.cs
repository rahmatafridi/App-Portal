using System;
using System.Data;
using System.Configuration;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
 
using System.Text; 

namespace DSP.BAL
{

    public class Learner
    {
        public Learner()
        {

        }

        public static string GetEmail(int iLearnerId)
        {
            return DSP.DAL.SQLOSCA.GetOneValueBySQL("SELECT Learner_Email1 FROM LearnerContacts WHERE Learner_Id = '" + iLearnerId.ToString() + "'", "Learner_Email1");

        }








    }//logs
} //DSP.BAL

 