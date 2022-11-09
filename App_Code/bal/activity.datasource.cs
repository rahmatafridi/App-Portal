using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace DSP.BAL
{


    /// <summary>
    /// Summary description for activity
    /// </summary>
    public class activity_datasource
    {
        public activity_datasource()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        List<DSP.BAL.typecontacts> _typecontact = new List<DSP.BAL.typecontacts>();
        List<DSP.BAL.typeactivities> _typeactivity = new List<DSP.BAL.typeactivities>();

        public List<DSP.BAL.typecontacts> GetTypeContactsList()
        {
            _typecontact.Clear();
            TypeContactsData();
            return _typecontact;
        }

        public List<DSP.BAL.typeactivities> GetTypeActivitiesList()
        {
            _typeactivity.Clear();
            TypeActivitiesData();
            return _typeactivity;
        }


        #region Data Source

        private void TypeContactsData()
        {
        
            _typecontact.Add(new DSP.BAL.typecontacts { TypeContactTitle = "-- Select Contact Type --", TypeContactId = "0" });
            _typecontact.Add(new DSP.BAL.typecontacts { TypeContactTitle = "Visit", TypeContactId = "1" });
            _typecontact.Add(new DSP.BAL.typecontacts { TypeContactTitle = "Non Visit Contact", TypeContactId = "9" });
          


        }

        private void TypeActivitiesData()
        {
                _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "-- Select Contact Type First --", TypeActivityId = "0", IdTypeContact = "0" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "xInduction", TypeActivityId = "2", IdTypeContact = "1" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Induction and Observation", TypeActivityId = "24", IdTypeContact = "1" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Observation", TypeActivityId = "6", IdTypeContact = "1" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Other Activities", TypeActivityId = "9", IdTypeContact = "1" });
           
           _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Remote Supporting", TypeActivityId = "14", IdTypeContact = "9" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Portfolio Building", TypeActivityId = "13", IdTypeContact = "9" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Meeting Cancelled by Assessor", TypeActivityId = "22", IdTypeContact = "9" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Meeting Cancelled by Learner", TypeActivityId = "23", IdTypeContact = "9" });
            _typeactivity.Add(new DSP.BAL.typeactivities { TypeActivityTitle = "Other Activities", TypeActivityId = "9", IdTypeContact = "9" });
       
          
         
        }

       

        #endregion

        #region "4 QCF"

        public List<DSP.BAL.typecontacts> GetTypeContactsList_4qcf()
        {
            _typecontact.Clear();
            TypeContactsData_4qcf();
            return _typecontact;
        }
        private void TypeContactsData_4qcf()
        {
           
            _typecontact.Add(new DSP.BAL.typecontacts { TypeContactTitle = "-- Select Contact Type --", TypeContactId = "0" });
            _typecontact.Add(new DSP.BAL.typecontacts { TypeContactTitle = "Extra Visit", TypeContactId = "12" });
            _typecontact.Add(new DSP.BAL.typecontacts { TypeContactTitle = "Non Visit Contact", TypeContactId = "9" });



        }
        #endregion





    }

}