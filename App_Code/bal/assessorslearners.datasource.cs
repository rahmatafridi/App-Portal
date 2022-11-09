using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace DSP.BAL
{


    /// <summary>
    /// Summary description for activity
    /// </summary>
    public class assessorslearners_datasource
    {
        public assessorslearners_datasource()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string sAssessorUsername = "";

        List<DSP.BAL.listlearners> _type_learners = new List<DSP.BAL.listlearners>();
        List<DSP.BAL.listlearnercourses> _type_learnercourses = new List<DSP.BAL.listlearnercourses>();



        public List<DSP.BAL.listlearners> GetLearnersList2()
        {
            _type_learners.Clear();
            LearnersListData2();
            return _type_learners;
        }

        public List<DSP.BAL.listlearners> GetLearnersListQCF()
        {
            _type_learners.Clear();
            LearnersListDataQCF();
            return _type_learners;
        }



        public List<DSP.BAL.listlearnercourses> GetLearnerCoursesList2(string sLearnerId)
        {
            _type_learnercourses.Clear();
            LearnerCoursesListData2(sLearnerId);
            return _type_learnercourses;
        }

        #region Data Source

        public void LearnersListData2()
        {


            DataSet ds;
            int iIdAssessor = 0;
            string sSQL = "SELECT Users_Id_AssessorContacts FROM Users WHERE Users_UserName = '" + sAssessorUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
                return;
            }
            else
            {
                iIdAssessor = int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString());
            }

            sSQL = "SELECT distinct([LC].Learner_ID), ([LC].Learner_FirstName + ' ' + [LC].Learner_Surname + ' - ' + Titles.Titles_Title + ' (' + convert(varchar(10),[LC].Learner_ID) + ')') as LearnerName ";


            sSQL += " FROM LearnerContacts as [LC] ";


            sSQL += " left outer join Titles on [LC].Learner_Id_Titles = Titles.Titles_Id ";
            sSQL += " left outer join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";

            sSQL += "  WHERE ";
            sSQL += "    [LC].Learner_IsDeleted = 0 ";
            sSQL += "    AND ([LLC].LearnerAssessor_IsPortalAssessor = 1 OR [LLC].LearnerAssessor_DealingWith = 1 ) AND [LC].Learner_IsInProcess = 0 ";
            sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
            sSQL += "  ORDER BY [LC].Learner_ID ASC ;"; // [LC].Learner_FirstName ASC,[LC].Learner_Surname ASC ";
            ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(sSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                _type_learners.Add(new DSP.BAL.listlearners { LearnerFullName = "-- Select Learner --", LearnerId = "0" });
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    _type_learners.Add(new DSP.BAL.listlearners { LearnerFullName = dr["LearnerName"].ToString(), LearnerId = dr["Learner_ID"].ToString() });

                }




            }
            else
            {
                return;
            }


        }



        public void LearnersListDataQCF()
        {


            DataSet ds;
            int iIdAssessor = 0;
            string sSQL = "SELECT Users_Id_AssessorContacts FROM Users WHERE Users_UserName = '" + sAssessorUsername + "' AND Users_IsActive =  1 ; ";
            DataSet dsUser = DSP.DAL.SQL.GetRecordsBySQL(sSQL);
            if (dsUser == null || dsUser.Tables.Count == 0 || dsUser.Tables[0].Rows.Count == 0)
            {
                // InvalidCredentialsMessage.Text = "Your email is not on the system.  ";
                return;
            }
            else
            {
                iIdAssessor = int.Parse(dsUser.Tables[0].Rows[0]["Users_Id_AssessorContacts"].ToString());
            }

            sSQL = "SELECT distinct([LC].Learner_ID), ([LC].Learner_FirstName + ' ' + [LC].Learner_Surname + ' - ' + Titles.Titles_Title + ' (' + convert(varchar(10),[LC].Learner_ID) + ')') as LearnerName ";


            sSQL += " FROM LearnerContacts as [LC] ";


            sSQL += " left outer join Titles on [LC].Learner_Id_Titles = Titles.Titles_Id ";
            sSQL += " left outer join Link_LearnerAssessor as [LLC] on [LLC].LearnerAssessor_Id_Learner = [LC].Learner_ID ";


            sSQL += " inner join LearnerCourses as lcc ON lcc.LearnerCourses_Id_Learner = [LC].Learner_ID ";
            sSQL += " inner join Courses as c ON c.Course_Id = lcc.LearnerCourses_Id_Course ";

            sSQL += "  WHERE ";
            sSQL += "    [LC].Learner_IsDeleted = 0 ";
            sSQL += "    AND [LLC].LearnerAssessor_DealingWith = 1 AND [LC].Learner_IsInProcess = 0 ";
            sSQL += " AND [LLC].LearnerAssessor_Id_Assessor = '" + iIdAssessor + "' ";
            sSQL += "  AND  c.Course_Group = 6  "; // only QCF group
            sSQL += "  AND  ( [LC].Learner_Id_CandidateStatus = 1  OR [LC].Learner_Id_CandidateStatus  = 9 ) "; // only ACTIVE / ON PROCESS
            sSQL += "  ORDER BY [LC].Learner_ID ASC ;";
            ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(sSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                _type_learners.Add(new DSP.BAL.listlearners { LearnerFullName = "-- Select Learner --", LearnerId = "0" });
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    _type_learners.Add(new DSP.BAL.listlearners { LearnerFullName = dr["LearnerName"].ToString(), LearnerId = dr["Learner_ID"].ToString() });

                }




            }
            else
            {
                return;
            }


        }





        public void LearnerCoursesListData2(string sLearnerId)
        {


            DataSet ds;

            ds = DSP.DAL.SQLOSCA.GetDsBySP("SP_Portal_GetLearnerCourses", "LearnerId", int.Parse(sLearnerId));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _type_learnercourses.Add(new DSP.BAL.listlearnercourses { LearnerCourseTitle = dr["LearnerCourse"].ToString(), LearnerCourseId = "LearnerCourses_id", IdLearner = sLearnerId });


                }




            }
            else
            {
                return;
            }


        }




        #endregion


    }

}