using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Assessors_ViewLearnerMatrix : System.Web.UI.Page
{


    #region " ---  Page_Load "

    //[System.Web.Services.WebMethod]
    //public static string GetCurrentTime(string name)
    //{
    //    return "Hello " + name + Environment.NewLine + "The Current Time is: "
    //        + DateTime.Now.ToString();
    //}

    

    [System.Web.Services.WebMethod]
    public static string UpdateOutcome(string name)
    {
             string sUserName = Membership.GetUser().UserName;
            int iUserId = DSP.BAL.DBL.GetUser_UserId(sUserName);
        string [] sId_Status = name.Split('_');

     //   return "Id:" + sId_Status[0] + "-  value:" + sId_Status[1] ;
        string strSQL = "Update SS_MatrixLearners SET SSML_IsCompleted = {0} , SSML_CompletedByUser={1}, SSML_CompletedByUsername='{2}' WHERE SSML_Id = {3};";

        DSP.DAL.SQLOSCA.ExecuteScalar(string.Format(strSQL, sId_Status[1], iUserId, sUserName, sId_Status[0]));

        return "Outcome updated";
      
    }


    #endregion


    #region " ---  Page_Load "

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            string sLearnerId = (string)Page.Session["AssessorLearnerId"];
          sLearnerId = (string)Page.Session["AssessorLearnerId"];
         
            PopulateMyLearners();
    
            btnChooseCourse.Visible = false;

            if (sLearnerId != null)
            {
                DSP.BAL.Basic.SetControl(ddl_list_learners, sLearnerId);
                ddl_list_learners_SelectedIndexChanged(sender, e);
               

            }


            string sLearnerCourseId = (string)Page.Session["AssessorLearnerCourseId"];
            string sLearnerTopicId = (string)Page.Session["AssessorTopicId"];

            if (sLearnerCourseId != null)
            {
                DSP.BAL.Basic.SetControl(ddl_list_learnercourses, sLearnerCourseId);
                chooseCourse(int.Parse(sLearnerCourseId));               
            }

            if (sLearnerTopicId != null)
            {
                DSP.BAL.Basic.SetControl(ddl_CourseTopics, sLearnerTopicId);
                ddl_CourseTopics_SelectedIndexChanged(sender, e);             
            }





            lbl_fullname.Text = "View Matrix"; 
           
        }


    }

     #endregion


    #region " --- PopulateMyLearners "

    private void PopulateMyLearners()
    {
        DSP.BAL.assessorslearners_datasource ds = new DSP.BAL.assessorslearners_datasource();
        ds.sAssessorUsername = Membership.GetUser().ToString();

        ddl_list_learners.DataSource = ds.GetLearnersList2();
        ddl_list_learners.DataValueField = "LearnerId";
        ddl_list_learners.DataTextField = "LearnerFullName";
        ddl_list_learners.DataBind();
    }
       #endregion


    #region " --- PopulateContactActivity "

    private void PopulateContactActivity()
    {
        //DSP.BAL.activity_datasource ds = new DSP.BAL.activity_datasource();
        //ddl_typecontacts.DataSource = ds.GetTypeContactsList();
        //ddl_typecontacts.DataValueField = "TypeContactId";
        //ddl_typecontacts.DataTextField = "TypeContactTitle";
        //ddl_typecontacts.DataBind();
    }


 
    #endregion



     


     



    #region " --- learners on change!  "

    protected void ddl_list_learners_SelectedIndexChanged(object sender, EventArgs e)
    {  
        pnl_activity_ss.Visible = false;
        DataSet ds = DSP.DAL.SQLOSCA.GetDsBySP("SP_Portal_GetLearnerCourses", "LearnerId", int.Parse(ddl_list_learners.SelectedValue));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
              DSP.BAL.Basic.FillDropDownList(ddl_list_learnercourses, ds, "LearnerCourse", "LearnerCourses_id");

              if (ds.Tables[0].Rows.Count == 1)
              {
                  int iCourseId = int.Parse(ddl_list_learnercourses.SelectedValue);
                  chooseCourse(iCourseId);
                  btnChooseCourse.Visible = false;
              }
              else
              {
                  btnChooseCourse.Visible = true;
             //     btnUpdateOutcomes.Visible = false;
              }
        }


       

    }




    #endregion

     #region " --- Choose a course to submit the activity   "



    


    protected void btnChooseCourse_Click(object sender, EventArgs e)
    {
        int iCourseId = int.Parse(ddl_list_learnercourses.SelectedValue);

        chooseCourse(iCourseId);

    }
    protected void chooseCourse(int iCourseId)
    {

        string sGroup = DSP.DAL.SQLOSCA.GetOneValueBySQL("SELECT c.Course_Group FROM [LearnerCourses] as lc inner join Courses as c on c.Course_Id = lc.LearnerCourses_Id_Course WHERE lc.LearnerCourses_id = " + iCourseId.ToString(), "Course_Group");

        if (sGroup == "1" || sGroup == "6")
        {
             pnl_activity_ss.Visible = true;


        
            lbl_LearnerCourseId.Text = iCourseId.ToString();
            lbl_LearnerId.Text = ddl_list_learners.SelectedValue;

         //   DSP.BAL.DBL.QCF_InsertLearnersJourney(int.Parse(ddl_list_learners.SelectedValue), iCourseId);//int.Parse(strLearnerCourseId));

            //load units in ddl and also load grid with already assigned units.
          //  grid_ss_matrix.DataBind();

            fill_topicslearner(int.Parse(lbl_LearnerCourseId.Text));



        }
        else
        {
             pnl_activity_ss.Visible = false;
        //     btnUpdateOutcomes.Visible = false;

        }
    
    
    }


    //protected void getlearnercourses()
    //{
    //    string sUserName = Membership.GetUser().UserName;
    //    int iUserId = DSP.BAL.DBL.GetUser_UserId(sUserName);
    //    int iLearnerId = DSP.BAL.DBL.GetUser_LearnerId(sUserName);
    //    DataSet ds2 = getSSLearnerCourses(iLearnerId.ToString());
    //    if (ds2 != null)
    //    {
    //        ddl_Courses.DataSource = ds2;
    //        ddl_Courses.DataBind();
    //        ds2 = null;
    //    }
    //    ddl_CourseTopics_SelectedIndexChanged(null, null);

    //}

    protected void ddl_CourseTopics_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string sUserName = Membership.GetUser().UserName;
    //    int iLearnerId = int.Parse(ddl_list_learners.SelectedValue);// DSP.BAL.DBL.GetUser_LearnerId(sUserName);

        string sTopicId = ddl_CourseTopics.SelectedValue.ToString();
   
        view_topichistory(int.Parse(sTopicId)); 
        

    }
    protected void fill_topicslearner(int iLearnerCourseId)
    {

        DataSet ds;

        ds = DSP.DAL.SQLOSCA.GetDsBySP("SP_SS_GetListJourneyLearnerProgressAssessors", "@LearnerCourseId", iLearnerCourseId);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddl_CourseTopics.DataSource = ds;
            ddl_CourseTopics.DataBind();
            ddl_CourseTopics.Enabled = true;

            ddl_CourseTopics_SelectedIndexChanged(null, null);
            //  pnl_ss.Visible = true;
            //   bind_courseplan_units(ds);
        }
        else
        {
            ddl_CourseTopics.Enabled = false;

            //   pnl_ss.Visible = false;
            //   bind_courseplan_units(null);
        }

        ds = null;


    }
    protected void getMatrixLearner(int iLearnerCourseId)
    {

       // DataSet ds;
        
       // string strSQL = "SELECT distinct(m.SSM_Id)  FROM SS_Matrix as m "; 
       // strSQL += "inner join SS_MatrixLearners as ml on ml.SSML_Id_Matrix = m.SSM_Id "; 
       // strSQL += "	WHERE SSML_Id_Learner = {0} AND SSML_Id_LearnerCourse = {1} AND SSML_Id_Topic = {2} AND [SSM_IsDeleted] = 0";
       // ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(string.Format (strSQL , ddl_list_learners.SelectedValue.ToString(), iLearnerCourseId, ,) );

       //// ds = DSP.DAL.SQLOSCA.GetDsBySP("SP_SS_GetListJourneyLearnerProgressCompleted", "@LearnerCourseId", iLearnerCourseId);

       // if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
       // {

       //     ddl_CourseTopics.DataSource = ds;
       //     ddl_CourseTopics.DataBind();
       //     ddl_CourseTopics.Enabled = true;

       //     ddl_CourseTopics_SelectedIndexChanged(null, null);
       //     //  pnl_ss.Visible = true;
       //     //   bind_courseplan_units(ds);
       // }
       // else
       // {
       //     ddl_CourseTopics.Enabled = false;

       //     //   pnl_ss.Visible = false;
       //     //   bind_courseplan_units(null);
       // }

       // ds = null;


    }

    //protected void btnUpdateOutcomes_Click(object sender, EventArgs e)
    //{
    //    bool bFound = false;
    // //  ControlCollection ctlCollections = pnl_matrix_levels.Controls   ;

    //    int iCount = pnl_matrix_levels.Controls.Count;
    //    string strSQL = "Update SS_MatrixLearners SET SSML_IsCompleted = {0} WHERE SSML_Id = {1};";
     
    //    foreach (CheckBox chk in this.Page.Controls.OfType<CheckBox>())
    //    {
    //        bFound = true;
    //        //chk = (CheckBox)ctl;
    //        string[] sId = chk.ID.Split('_');
    //        //  DSP.DAL.SQL.ExecuteScalar(string.Format(strSQL, (chk.Checked == true ? "1" : "0"), sId[1]));
    //        strSQL += string.Format(strSQL, (chk.Checked == true ? "1" : "0"), sId[1]); 
    //    }
    //   //foreach (Control ctl in pnl_matrix_levels.Controls )
    //   //{ 
       
    //   //    CheckBox chk = new CheckBox ();
    //   //    if (ctl is CheckBox )
    //   //    {
    //   //        bFound = true;
    //   //        chk = (CheckBox)ctl;
    //   //        string [] sId = chk.ID.Split('_');
    //   //      //  DSP.DAL.SQL.ExecuteScalar(string.Format(strSQL, (chk.Checked == true ? "1" : "0"), sId[1]));
    //   //        strSQL += string.Format(strSQL, (chk.Checked == true ? "1" : "0"), sId[1]) ; 
    //   //    }
       
    //   //}
    //    if (bFound)         DSP.DAL.SQL.ExecuteScalar(strSQL); 


        
    //}

    //protected void btnUpdateOutcomes_Click(object sender, EventArgs e)
    //{
    //    bool bFound = false;
    //    ControlCollection ctlCollections = pnl_matrix_levels.Controls;

    //    string strSQL = "Update SS_MatrixLearners SET SSML_IsCompleted = {0} WHERE SSML_Id = {1};";
    //    foreach (Control ctl in ctlCollections)
    //    {

    //        CheckBox chk = new CheckBox();
    //        if (ctl is CheckBox)
    //        {
    //            bFound = true;
    //            chk = (CheckBox)ctl;
    //            string[] sId = chk.ID.Split('_');
    //            //  DSP.DAL.SQL.ExecuteScalar(string.Format(strSQL, (chk.Checked == true ? "1" : "0"), sId[1]));
    //            strSQL += string.Format(strSQL, (chk.Checked == true ? "1" : "0"), sId[1]);
    //        }

    //    }
    //    if (bFound) DSP.DAL.SQL.ExecuteScalar(strSQL);



    //}

    protected void view_topichistory(int iTopicId)
    {
        pnl_matrix_levels.Controls.Clear();

        lbl_LearnerCourseId.Text =  ddl_list_learnercourses.SelectedValue.ToString();
        lbl_LearnerId.Text = ddl_list_learners.SelectedValue.ToString();
        lbl_TopicId.Text = iTopicId.ToString();


        Label lblTickAll = new Label();
        lblTickAll.ID = "lbl_TickAll_";
        lblTickAll.Text = "<b>" + "SELECT ALL" + "</b> ";
        lblTickAll.Attributes.Add("onclick", "UpdateOutcomeAllTicked()");
        lblTickAll.Visible = true;
        lblTickAll.SkinID = "LinkButton";
       // lblTickAll.CssClass = "pointer";
        lblTickAll.CssClass = "button medium blue pointer";

        string sAllIds = "";

        Label lblUnTickAll = new Label();
        lblUnTickAll.ID = "lbl_UnTickAll_";
        lblUnTickAll.Text = "&nbsp; <b>" + " DESELECT ALL" + "</b> ";
        lblUnTickAll.Attributes.Add("onclick", "UpdateOutcomeAllUnTicked()");
        lblUnTickAll.Visible = true;
        lblUnTickAll.SkinID = "LinkButton";
        //lblUnTickAll.CssClass = "pointer";
        lblUnTickAll.CssClass = "button medium blue pointer";

        sAllIds = "1";
        if (sAllIds != "")
        {
            lblTickAll.ID = "lbl_TickAll_" + sAllIds;
            pnl_matrix_levels.Controls.Add(lblTickAll);

            lblUnTickAll.ID = "lbl_UnTickAll_" + sAllIds;
            pnl_matrix_levels.Controls.Add(lblUnTickAll);

        }
     //   grid_ss_matrix.DataBind();
      
           DataSet ds;
        
        //string strSQL = "SELECT distinct(m.SSM_Id)  FROM SS_Matrix as m "; 
        //strSQL += "inner join SS_MatrixLearners as ml on ml.SSML_Id_Matrix = m.SSM_Id "; 
        //strSQL += "	WHERE SSML_Id_Learner = {0} AND SSML_Id_LearnerCourse = {1} AND SSML_Id_Topic = {2} AND [SSM_IsDeleted] = 0";
        //ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(string.Format (strSQL , ddl_list_learners.SelectedValue.ToString(), iLearnerCourseId, ,) );
           string strSQL = "SELECT distinct(m.SSM_Id ), m.SSM_Name FROM SS_Matrix as m ";
           strSQL += "inner join SS_MatrixLearners as ml on ml.SSML_Id_Matrix = m.SSM_Id 	inner join SS_JourneyLearnerProgress as jlp on jlp.SSJLP_Id_TopicUnit = ml.SSML_Id_Topic ";
           strSQL += "	WHERE SSML_Id_Learner = {0} AND SSML_Id_LearnerCourse = {1} AND jlp.SSJLP_Id = {2} AND [SSM_IsDeleted] = 0";
        ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(string.Format(strSQL, ddl_list_learners.SelectedValue.ToString(), ddl_list_learnercourses.SelectedValue.ToString(), ddl_CourseTopics.SelectedValue.ToString()));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //get all matrix ids 
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string sMatrixId = ds.Tables[0].Rows[i]["SSM_Id"].ToString();
                string sMatrixName = ds.Tables[0].Rows[i]["SSM_Name"].ToString();
                Label lblCaption = new Label();
                lblCaption.ID = "lbl_Matrix_" + sMatrixId;
                lblCaption.Text = "<br/><b>" + sMatrixName + "</b><br/>";
                pnl_matrix_levels.Controls.Add(lblCaption);

                strSQL = "SELECT ml.*, m.SSM_Name FROM SS_Matrix as m ";
                strSQL += "inner join SS_MatrixLearners as ml on ml.SSML_Id_Matrix = m.SSM_Id inner join SS_JourneyLearnerProgress as jlp on jlp.SSJLP_Id_TopicUnit = ml.SSML_Id_Topic ";
                strSQL += "	WHERE SSML_Id_Learner = {0} AND SSML_Id_LearnerCourse = {1} AND jlp.SSJLP_Id = {2} AND [SSM_IsDeleted] = 0 AND m.SSM_Id = {3}";
                DataSet ds2 = DSP.DAL.SQLOSCA.GetRecordsBySQL(string.Format(strSQL, ddl_list_learners.SelectedValue.ToString(), ddl_list_learnercourses.SelectedValue.ToString(), ddl_CourseTopics.SelectedValue.ToString(), sMatrixId));
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    //get all matrix ids 
                    //CheckBoxList chkList = new CheckBoxList();
                    //chkList.ID = "chklist_matrix_" + sMatrixId;
                    //chkList.Visible = true;

                    for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                    {

                        CheckBox chk = new CheckBox();
                        chk.ID = "chk_" + ds2.Tables[0].Rows[j]["SSML_Id"].ToString();
                        chk.Checked = (ds2.Tables[0].Rows[j]["SSML_IsCompleted"].ToString() == "1" ? true : false);
                        chk.Text = ds2.Tables[0].Rows[j]["SSML_Id_LevelKey"].ToString() + "." + ds2.Tables[0].Rows[j]["SSML_Id_LevelValue"].ToString();
                        chk.TextAlign = TextAlign.Left;
                        chk.Visible = true;
                        chk.Attributes.Add("onclick", "UpdateOutcome(this)");
                        pnl_matrix_levels.Controls.Add(chk);

                     //   sAllIds += ds2.Tables[0].Rows[j]["SSML_Id"].ToString() + "|";
                        //chkList.Controls.Add(chk);
                    }
                    //   pnl_matrix_levels.Controls.Add(chkList);

                }

            }


        


        }
        else {

         
        
        }
        
     

        
	



    


    }



     #endregion

    #region "***** QCF panel *****"

    /* ****************************************************************************
    *        
    * ****************************************************************************
    */
    protected void grid_ss_journey_OnRowDataBoundxxx(object sender, EventArgs e)
    {
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Panel pnl = ((Panel)ea.Row.FindControl("pnl"));
            Label lblFileName = ((Label)ea.Row.FindControl("lbl_FileName"));
            Label lblFileCaption = ((Label)ea.Row.FindControl("lbl_FileCaption"));
            //   Label lbl_validated = ((Label)ea.Row.FindControl("JLP_IsValidated"));
            string sLinks ="";
            if (lblFileName.Text != "")
            {
                string[] sFilesPath;
                sFilesPath = lblFileName.Text.Split(';');

                string[] sFilesCaption;
                sFilesCaption = lblFileCaption.Text.Split(';');

                for (int i = 0; i < sFilesPath.Length; i++)
                {

                    if (sFilesPath[i] != "")
                    {
                    string sLink = "<a href=\"{0}\" >{1}</a> ";
                    sLink = string.Format(sLink, sFilesPath[i], sFilesCaption[i]);
                    sLinks += sLink;


                    Button lbtn = new Button();

                    lbtn.ID = "opend_file_btn_" + i.ToString();
                    lbtn.Text = sFilesCaption[i];
                    //lbtn.SkinID = "LinkButton";
                    //lbtn.CssClass = "LinkButton";
                    lbtn.Click += new EventHandler(OpenFile_Click);
                    lbtn.OnClientClick = "openjsfile(" + sFilesCaption[i] + "," + sFilesPath[i] + ")";
                    lbtn.CommandName = "opendocument";
                    lbtn.CommandArgument = sFilesPath[i];
                    lbtn.Visible = true;
                    pnl.Controls.Add(lbtn);
                    }

                }
            }
            pnl.Visible = true;
             


        }
    }
    protected void grid_ss_matrix_OnRowDataBound(object sender, EventArgs e)
    {
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {

            Panel pnl = ((Panel)ea.Row.FindControl("pnl"));
            Label lblFileName = ((Label)ea.Row.FindControl("lbl_FileName"));
            Label lblFileCaption = ((Label)ea.Row.FindControl("lbl_FileCaption"));
            //   Label lbl_validated = ((Label)ea.Row.FindControl("JLP_IsValidated"));
            string sLinks = "";
            if (lblFileName.Text != "")
            {
                string[] sFilesPath;
                sFilesPath = lblFileName.Text.Split(';');

                string[] sFilesCaption;
                sFilesCaption = lblFileCaption.Text.Split(';');

                for (int i = 0; i < sFilesPath.Length; i++)
                {
                   if (sFilesPath[i] != "")
                    {
                        //string sLink = "<a href=\"javascript:window.open('{0}','_blank');\" target=\"_blank\" >{1}</a> &nbsp;";
                       // sLink = sFilesCaption[i].Replace("\\", "\\\\");
                    //    sLink = "<a href=\"javascript:window.open('..\\..\\EmailDocs\\s1\\80F5123634_Rpt ISI.doc.doc','_blank');\" target=\"_blank\" >{1}</a> &nbsp;";
                        string sLink = "<a href=\"javascript:window.open('../OpenFile.aspx?f={0}','_blank');\" target=\"_blank\" >{1}</a> &nbsp;";  
  
                       string sFilePathNew = sFilesPath[i].Replace("\\","\\\\");

                           sLink = string.Format(sLink, sFilePathNew, sFilesCaption[i]);
                        sLinks += sLink;
                                            
                       
                         Label lb = new Label();
                         lb.ID = "all_links" + i.ToString();
                         lb.Text = sLink;
                         
                        pnl.Controls.Add(lb);

                    }

                }
            }
            pnl.Visible = true;

             

        }
    }

    protected Panel getFileLinks(object oFilePaths, object oFileCaptions)
    {
        string sFilePaths = oFilePaths.ToString();
        string sFileCaptions = oFilePaths.ToString();

        Panel pnl = new Panel();
        pnl.ID = "pnl_files";
        //pnl.Controls.Clear();
        pnl.Visible = true;


        //Label lblFileName = ((Label)ea.Row.FindControl("lbl_FileName"));
        //Label lblFileCaption = ((Label)ea.Row.FindControl("lbl_FileCaption"));
        ////   Label lbl_validated = ((Label)ea.Row.FindControl("JLP_IsValidated"));
        string sLinks = "";
        if (sFilePaths  != "")
        {
            string[] sFilesPath;
            sFilesPath = sFilePaths.Split(';');

            string[] sFilesCaption;
            sFilesCaption = sFileCaptions.Split(';');

            for (int i = 0; i < sFilesPath.Length; i++)
            {
                string sLink = "<a href=\"{0}\" >{1}</a> ";
                sLink = string.Format(sLink, sFilesPath[i], sFilesCaption[i]);
                sLinks += sLink;

                LinkButton lbtn = new LinkButton();

                lbtn.ID = "opend_file_btn_" +   i.ToString();
                lbtn.Text = sFilesCaption[i] + " ";
                //lbtn.SkinID = "LinkButton";
                //lbtn.CssClass = "LinkButton";
                lbtn.Click += new EventHandler(OpenFile_Click);
                lbtn.CommandName = "opendocument";
                lbtn.CommandArgument = sFilesPath[i];

                pnl.Controls.Add(lbtn);


            }
        }


        


        //string strReturn = "";

        //if (strId != "")
        //{
        //    strReturn = "<img src=\"../../App_Resources/images/" + strId + "\"  CssClass=\"GridIcon ico-view\"  alt=\"\">";
        //}
        return pnl;
    }


    protected void OpenFile_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;


        if (btn.CommandName == "opendocument")
        {
            DownloadFile(btn.CommandArgument);

        }
        //Button1.Text = "Your request has been sent to the office.";
        // Button1.Enabled = false;

    }

    public void DownloadFile(string filePath)
    {

        //file.exisits(Server.MapPath(xxx))
        if (System.IO.File.Exists(filePath))
        {
            string strFileName = System.IO.Path.GetFileName(filePath).Replace(" ", "%20");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
            Response.Clear();
            Response.WriteFile(filePath); //Server.MapPath(xx)
            Response.End();
        }
    }

    protected string getActivePicture(object bActive)
    {
        string strId = bActive.ToString();
        string strReturn = "";

        if (strId != "")
        {
            strReturn = "<img src=\"../../App_Resources/images/" + strId + "\"  CssClass=\"GridIcon ico-view\"  alt=\"\">";
        }
        return strReturn;
    }


    public void btn_Update_Click(object sender, EventArgs e)
    {

        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        string strID = ((Label)grdRow.FindControl("lbl_SSJLP_Id")).Text;

        //string iHourTT = ((DropDownList)grdRow.FindControl("gddl_HoursTT")).SelectedValue;
        //string iMinTT = ((DropDownList)grdRow.FindControl("gddl_MinTT")).SelectedValue;

        //  string iHour = ((DropDownList)grdRow.FindControl("gddl_Hours")).SelectedValue;
        //string iMin = ((DropDownList)grdRow.FindControl("gddl_Min")).SelectedValue;

        bool bError = false;
        string sMessage = "";
        int iIdOsca = DSP.BAL.DBL.GetUser_UserIdOSCA(Membership.GetUser().ToString());
        if (iIdOsca == -1) { bError = true; sMessage = "Please login back and try again."; }

        string sDate1 = ((TextBox)grdRow.FindControl("d_complete_date")).Text;

        string sDate = DSP.BAL.Basic.switchDayAndMonth(sDate1);

        if (sDate == "") { bError = true; sMessage = "Please enter the completed date."; }

        int iIdAssessor = DSP.BAL.DBL.GetUser_AssessorId(Membership.GetUser().ToString());
        if (iIdAssessor == -1) { bError = true; sMessage = "Please login back and try again."; }


        //bool bIsVisit = (((Label)grdRow.FindControl("lbl_JA_IsVisit")).Text == "1") ? true : false; ;


        //if (bIsVisit)
        //{
        //     if ((iHour == "0") && (iMin == "0"))
        //    {

        //        bError = true; sMessage = "Please enter the correct time spent on the activity.<br/>";

        //    }


        
        //    if ((iHourTT == "0") && (iMinTT == "0"))
        //    {

        //        bError = true; sMessage = "Please enter the correct travel time of the activity.<br/>";

        //    }
        //}
         
       
        //string sCurrentActivityName = ((Label)grdRow.FindControl("lbl_JA_Title")).Text;
        //int iVisit_ActivityCompleted = 0;
        //int iVisit_ContactType = 0;

    
        if (!bError)
        {
            //if (bIsVisit)
            //{ 
            //    iVisit_ContactType = 1;

            //    // insert the activity but not validated
            //    switch (sCurrentActivityName)
            //    {
            //        case "First Visit: Induction and Observation": iVisit_ActivityCompleted= 27; break;
            //        case "2nd Visit: Observation": iVisit_ActivityCompleted = 28; break;
            //        case "3rd Visit: Observation": iVisit_ActivityCompleted = 29; break;
            //        case "3rd Visit and Observation": iVisit_ActivityCompleted = 30; break;
            //        case "4th Visit and Observation": iVisit_ActivityCompleted = 31; break;

            //        default: iVisit_ActivityCompleted = 0; break;
        
            //    }

            //    if (iVisit_ActivityCompleted != 0)
            //    {
            //        InsertActivity(iIdOsca, bIsVisit, sDate1, iHour, iMin, iHourTT, iMinTT, iVisit_ContactType.ToString(), iVisit_ActivityCompleted.ToString());
            //    }
            //}


       
            string strSQL = "";
            strSQL = " UPDATE [SS_JourneyLearnerProgress] ";
            strSQL += " SET [SSJLP_IsCompleted] = 1  ";
            strSQL += " ,[SSJLP_CompletedDate] = '" + sDate + "'";
            strSQL += " ,[SSJLP_EnteredDate] = getdate() ";
            strSQL += " ,[SSJLP_EnteredByUser] = '" + iIdOsca + "' ";
            strSQL += " ,[SSJLP_CompletedByAssessor] = '" + iIdAssessor + "' ";
           // strSQL += " , [SSJLP_IsValidated] = 0 ";
            strSQL += " WHERE SSJLP_Id = " + strID;

            try
            {
                DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);

            }
            catch (Exception exx)
            {
                //  MyMessageBox.ShowError("Error [0X602] : " + exx.Message);
                show_notif(exx.Message);
                return;
            }

            //now add into the activity table!


        }
        else
        {
            show_notif(sMessage);

            //show_notif_inline(sMessage);

        }


   //xx     grid_ss_matrix.DataBind();

       // sMessage = "SS tracking activity has been submitted.";
        show_notif(sMessage);

        

    }



    #region " ### QCF additional   ACTIVITY  ADD ACTIVITY "

    
    //protected void ddl_list_contacts_4qcf_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    string sSubCategories_activities = "";

    //    string sTypeContact = ddl_typecontacts_4qcf.SelectedValue;

    //    switch (sTypeContact)
    //    {
    //        case "12":
    //            //visit
    //            sSubCategories_activities = " IN (25,26 )";
    //            pnl_traveltime_4qcf.Visible = true;

    //            break;

    //        case "9":
    //            //nvc
    //            sSubCategories_activities = " IN ( 13, 14, 22, 23, 9 )";
    //            pnl_traveltime_4qcf.Visible = false;

    //            break;


             

    //        defaut:
    //            sSubCategories_activities = " IN (25,26 )";
    //            pnl_traveltime_4qcf.Visible = false;

    //            break;
    //    }



    //    string strSQL = "SELECT [ActivityCompleted_Id] ,[ActivityCompleted_Title] FROM  [ActivityCompleted] ";
    //    strSQL += " WHERE [ActivityCompleted_Id] " + sSubCategories_activities;
    //    strSQL += "ORDER BY [ActivityCompleted_WeightOrder] ";


    //    DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL(strSQL);

    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        // Fill info 
    //        //  objUtils.convertAndCheckNullAndSetDopDownBox(ddl_Priority, ds.Tables[0].Rows[0]["RAG_SubCat_Id_Priority"]);
    //        //  objUtils.convertAndCheckNullAndSetDopDownBox(ddl_Colours, ds.Tables[0].Rows[0]["RAG_SubCat_Id_Colours"]);

    //        DSP.BAL.Basic.FillDropDownList(ddl_typeactivities_4qcf, ds, "ActivityCompleted_Title", "ActivityCompleted_Id");

    //    }



    //}
   


    //protected void btnSubmit_4qcf_Click(object sender, EventArgs e)
    //{

    //    bool bError = false;
    //    string sMessage = "";
    //    int iIdOsca = DSP.BAL.DBL.GetUser_UserIdOSCA(Membership.GetUser().ToString());
    //    if (iIdOsca == -1) { bError = true; sMessage = "Please login back and try again."; }


    //    string strSQL;

    //    string sDate = dAct_entry_date_4qcf.Text.Trim();
    //    string iHour = ddl_Hours_4qcf.SelectedValue;
    //    string iMin = ddl_Min_4qcf.SelectedValue;

    //    string iHourTT = ddl_HoursTT_4qcf.SelectedValue;
    //    string iMinTT = ddl_MinTT_4qcf.SelectedValue;


    //    if (sDate == "")
    //    {
    //        bError = true; sMessage += "Please enter the correct date.<br/>";

    //    }

    //    if ((iHour == "0") && (iMin == "0"))
    //    {

    //        bError = true; sMessage += "Please enter the correct time spent on the activity.<br/>";
    //        //show_notif_inline(sMessage);
    //        //return;
    //    }

    //    if (pnl_traveltime_4qcf.Visible == true)
    //    {

    //        if ((iHourTT == "0") && (iMinTT == "0"))
    //        {

    //            bError = true; sMessage += "Please enter the correct travel time of the activity.<br/>";
    //            //show_notif_inline(sMessage);
    //            //return;
    //        }
    //    }

    //    // string asss = ddl_list_learnercourses.SelectedItem.Text;

    //    string sLearnerId = ddl_list_learners.SelectedValue;
    //    string sLearnerCourseId = ddl_list_learnercourses.SelectedValue;
    //    string sTypeContact = ddl_typecontacts_4qcf.SelectedValue; ;
    //    string sTypeActivity = ddl_typeactivities_4qcf.SelectedValue;

    //    if (sLearnerId == "0")
    //    {
    //        bError = true; sMessage += "Please select the learner.<br/>";

    //    }
    //    if ((sLearnerCourseId == "") || (sLearnerCourseId == "0"))
    //    {
    //        bError = true; sMessage += "Please select the learner course.<br/>";

    //    }


    //    if ((sTypeContact == "") || (sTypeContact == "0"))
    //    {
    //        bError = true; sMessage += "Please select the contact type.<br/>";

    //    }

    //    if ((sTypeActivity == "") || (sTypeActivity == "0"))
    //    {
    //        bError = true; sMessage += "Please select the activity type.<br/>";

    //    }

    //    if (!bError)
    //    {
    //        strSQL = " INSERT INTO  [Link_LearnerActivities]";
    //        strSQL += "([LA_Id_Learner]";
    //        strSQL += " ,[LA_Id_LearnerCourse]";
    //        strSQL += " ,[LA_CompletedDate]";
    //        strSQL += " ,[LA_TimeSpentHours]";
    //        strSQL += " ,[LA_TimeSpentMin]";

    //        if (pnl_traveltime_4qcf.Visible == true)
    //        {
    //            strSQL += " ,[LA_TravelTimeHours]";
    //            strSQL += " ,[LA_TravelTimeMin]";
    //        }
    //        strSQL += " ,[LA_Id_ContactType]";
    //        strSQL += " ,[LA_ContactTypeOther]";
    //        strSQL += " ,[LA_Id_ActivityCompleted]";
    //        strSQL += " ,[LA_ActivityOther]";
    //        strSQL += " ,[LA_Id_ActivityMaker]";
    //        strSQL += " ,[LA_EnteredDate]";
    //        strSQL += " ,[LA_EnteredByUser]";
    //        strSQL += " ,[LA_IsDeleted]";
    //        strSQL += " ,[LA_DeletedByUser], [LA_IsValidated] )";
    //        strSQL += " VALUES";
    //        strSQL += " (" + sLearnerId;
    //        strSQL += " ," + sLearnerCourseId;
    //        strSQL += " , '" + DSP.BAL.Basic.ConvertDateToSQL(sDate) + "' ";//dateUK.ToShortDateString() 
    //        strSQL += " ," + iHour;
    //        strSQL += " ," + iMin;

    //        if (pnl_traveltime_4qcf.Visible == true)
    //        {
    //            strSQL += " ," + iHourTT;
    //            strSQL += " ," + iMinTT;
    //        }
    //        strSQL += " ," + sTypeContact;
    //        strSQL += " , '' ";
    //        strSQL += " ," + sTypeActivity;
    //        strSQL += " , '' ";
    //        strSQL += " ," + iIdOsca.ToString();
    //        strSQL += " , getdate() ";
    //        strSQL += " ," + iIdOsca.ToString();
    //        strSQL += " , 0 ";
    //        strSQL += " , 0, 0 ) "; // no validated!


    //        DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);
    //        // grid_allactivity.DataBind();
    //        show_notif("Activity has been sumitted for verification.");
    //     //   dAct_entry_date.Text = "";

    //    }
    //    else
    //    {
    //        show_notif(sMessage);

    //       // show_notif_inline(sMessage);

    //    }

    //    //dAct_entry_date.Text = "";

    //    //ddl_Hours.SelectedIndex = 0;
    //    //ddl_Min.SelectedIndex = 0;





    //}


    protected void InsertActivity(int iIdOsca, bool bIsVisit, string sEnteredDate, string iHour, string iMin, string iHourTT, string iMinTT, string sTypeContact, string sTypeActivity)
    {

        bool bError = false;
        string sMessage = "";
        

        string strSQL;

        string sDate = sEnteredDate; //dAct_entry_date.Text.Trim();
        
        

        string sLearnerId = ddl_list_learners.SelectedValue;
        string sLearnerCourseId = ddl_list_learnercourses.SelectedValue;


        //string sTypeContact = ddl_typecontacts.SelectedValue; ;
        //string sTypeActivity = ddl_typeactivities.SelectedValue;

        //if (sLearnerId == "0")
        //{
        //    bError = true; sMessage += "Please select the learner.<br/>";

        //}
        //if ((sLearnerCourseId == "") || (sLearnerCourseId == "0"))
        //{
        //    bError = true; sMessage += "Please select the learner course.<br/>";

        //}


        //if ((sTypeContact == "") || (sTypeContact == "0"))
        //{
        //    bError = true; sMessage += "Please select the contact type.<br/>";

        //}

        //if ((sTypeActivity == "") || (sTypeActivity == "0"))
        //{
        //    bError = true; sMessage += "Please select the activity type.<br/>";

        //}

        if (!bError)
        {
            strSQL = " INSERT INTO  [Link_LearnerActivities]";
            strSQL += "([LA_Id_Learner]";
            strSQL += " ,[LA_Id_LearnerCourse]";
            strSQL += " ,[LA_CompletedDate]";
            strSQL += " ,[LA_TimeSpentHours]";
            strSQL += " ,[LA_TimeSpentMin]";

            if (bIsVisit == true)
            {
                strSQL += " ,[LA_TravelTimeHours]";
                strSQL += " ,[LA_TravelTimeMin]";
            }
            strSQL += " ,[LA_Id_ContactType]";
            strSQL += " ,[LA_ContactTypeOther]";
            strSQL += " ,[LA_Id_ActivityCompleted]";
            strSQL += " ,[LA_ActivityOther]";
            strSQL += " ,[LA_Id_ActivityMaker]";
            strSQL += " ,[LA_EnteredDate]";
            strSQL += " ,[LA_EnteredByUser]";
            strSQL += " ,[LA_IsDeleted]";
            strSQL += " ,[LA_DeletedByUser], [LA_IsValidated] )";
            strSQL += " VALUES";
            strSQL += " (" + sLearnerId;
            strSQL += " ," + sLearnerCourseId;
            strSQL += " , '" + DSP.BAL.Basic.ConvertDateToSQL(sDate) + "' ";//dateUK.ToShortDateString() 
            strSQL += " ," + iHour;
            strSQL += " ," + iMin;

            if (bIsVisit == true)
            {
                strSQL += " ," + iHourTT;
                strSQL += " ," + iMinTT;
            }
            strSQL += " ," + sTypeContact;
            strSQL += " , '' ";
            strSQL += " ," + sTypeActivity;
            strSQL += " , '' ";
            strSQL += " ," + iIdOsca.ToString();
            strSQL += " , getdate() ";
            strSQL += " ," + iIdOsca.ToString();
            strSQL += " , 0 ";
            strSQL += " , 0, 0 ) "; // no validated!


            try
            {
                DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);
            }
            catch (Exception eex)
            {

                show_notif("Message:" + eex.Message );
          
            
            }
            // grid_allactivity.DataBind();
            show_notif("Activity has been sumitted for verification.");
            // dAct_entry_date.Text = "";

        }
        else
        {
            show_notif(sMessage);

         //   show_notif_inline(sMessage);

        }







    }



    #endregion





    #endregion

    

    #region " ---   "
    

    #endregion


    #region " --- Show jgrowl notification "

    /* ************************************************* 
     * Show jgrowl notification
     *
     * *************************************************
     */
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
    

    /* ***********************************************/

    protected void show_notif_inline(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn2", js, true);

    }



    #endregion


    #region " ### nvq  ACTIVITY  ADD ACTIVITY "

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        bool bError = false;
        string sMessage = "";
        int iIdOsca = DSP.BAL.DBL.GetUser_UserIdOSCA(Membership.GetUser().ToString());
        if (iIdOsca == -1) { bError = true; sMessage = "Please login back and try again."; }


        string strSQL;

        //string sDate = dAct_entry_date.Text.Trim();
        //string iHour = ddl_Hours.SelectedValue;
        //string iMin = ddl_Min.SelectedValue;

        //string iHourTT = ddl_HoursTT.SelectedValue;
        //string iMinTT = ddl_MinTT.SelectedValue;


        //if (sDate == "")
        //{
        //    bError = true; sMessage += "Please enter the correct date.<br/>";
           
        //}

        //if ((iHour == "0") && (iMin == "0"))
        //{

        //    bError = true; sMessage += "Please enter the correct time spent on the activity.<br/>";
        //    //show_notif_inline(sMessage);
        //    //return;
        //}

        //if (pnl_traveltime.Visible == true)
        //{ 

        //    if ((iHourTT == "0") && (iMinTT == "0"))
        //    {

        //        bError = true; sMessage += "Please enter the correct travel time of the activity.<br/>";
        //        //show_notif_inline(sMessage);
        //        //return;
        //    }
        //}

        // string asss = ddl_list_learnercourses.SelectedItem.Text;

        string sLearnerId = ddl_list_learners.SelectedValue;
        string sLearnerCourseId = ddl_list_learnercourses.SelectedValue;
        //string sTypeContact = ddl_typecontacts.SelectedValue; ;
        //string sTypeActivity = ddl_typeactivities.SelectedValue;

        if (sLearnerId == "0")
        {
            bError = true; sMessage += "Please select the learner.<br/>";
             
        }
        if ((sLearnerCourseId == "") || (sLearnerCourseId == "0"))
        {
            bError = true; sMessage += "Please select the learner course.<br/>";
             
        }


        //if ((sTypeContact == "") || (sTypeContact == "0"))
        //{
        //    bError = true; sMessage += "Please select the contact type.<br/>";
            
        //}

        //if ((sTypeActivity == "") || (sTypeActivity == "0"))
        //{
        //    bError = true; sMessage += "Please select the activity type.<br/>";
           
        //}

        if (!bError)
        {
            strSQL = " INSERT INTO  [Link_LearnerActivities]";
            strSQL += "([LA_Id_Learner]";
            strSQL += " ,[LA_Id_LearnerCourse]";
            strSQL += " ,[LA_CompletedDate]";
            //strSQL += " ,[LA_TimeSpentHours]";
            //strSQL += " ,[LA_TimeSpentMin]";

 //           if (pnl_traveltime.Visible == true)
 //           {
 //strSQL += " ,[LA_TravelTimeHours]";
 //strSQL += " ,[LA_TravelTimeMin]";
 //}
            strSQL += " ,[LA_Id_ContactType]";
            strSQL += " ,[LA_ContactTypeOther]";
            strSQL += " ,[LA_Id_ActivityCompleted]";
            strSQL += " ,[LA_ActivityOther]";
            strSQL += " ,[LA_Id_ActivityMaker]";
            strSQL += " ,[LA_EnteredDate]";
            strSQL += " ,[LA_EnteredByUser]";
            strSQL += " ,[LA_IsDeleted]";
            strSQL += " ,[LA_DeletedByUser], [LA_IsValidated] )";
            strSQL += " VALUES";
            strSQL += " (" + sLearnerId;
            strSQL += " ," + sLearnerCourseId;
            //strSQL += " , '" + DSP.BAL.Basic.ConvertDateToSQL(sDate) + "' ";//dateUK.ToShortDateString() 
            //strSQL += " ," + iHour;
            //strSQL += " ," + iMin;

            //if (pnl_traveltime.Visible == true)
            //{  
            //    strSQL += " ," + iHourTT;
            //    strSQL += " ," + iMinTT;
            //}
            //strSQL += " ," + sTypeContact;
            //strSQL += " , '' ";
            //strSQL += " ," + sTypeActivity;
            strSQL += " , '' ";
            strSQL += " ," + iIdOsca.ToString();
            strSQL += " , getdate() ";
            strSQL += " ," + iIdOsca.ToString();
            strSQL += " , 0 ";
            strSQL += " , 0, 0 ) "; // no validated!


            DSP.DAL.SQLOSCA.ExecuteSQL(strSQL);
            // grid_allactivity.DataBind();
            show_notif("Activity has been sumitted for verification.");
            //dAct_entry_date.Text = "";

        }
        else
        {
            show_notif(sMessage);
          
           // show_notif_inline(sMessage);

        }

        //dAct_entry_date.Text = "";

        //ddl_Hours.SelectedIndex = 0;
        //ddl_Min.SelectedIndex = 0;





    }


    #endregion
     

}

 
 