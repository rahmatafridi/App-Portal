using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


using System.IO;
using System.Configuration;


public partial class Account_ManageResources : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            if (!Roles.IsUserInRole("Admin")) return;


            bindDDLPublicCats();
            DisplayFilesBelongingCats();


         

        }


    }


    #region " --- Get My learner details - title only "
    public void LoadChecksControls()
    {


        string sLearnerId1 = (string)ViewState["AssessorLearnerId"];
        string sLearnerId = (string)Page.Session["AssessorLearnerId"];
        if (sLearnerId == null) return;

        DataSet ds;


        ds = DSP.DAL.SQLOSCA.GetRecordsBySQL("SELECT Learner_Firstname,Learner_Surname FROM [LearnerContacts] WHERE Learner_Id = '" + sLearnerId + "'");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            string sfirstname  = ds.Tables[0].Rows[0]["Learner_Firstname"].ToString();
            string ssurname = ds.Tables[0].Rows[0]["Learner_Surname"].ToString();

            lbl_fullname.Text = sLearnerId + " - " + sfirstname  + " " + ssurname ;

    
        }
        else
        {
        
        }
         
        string s4 = "<span class=\"l_status\" style=\"background:#COLOR#\">#STATUS#</span>";

        ds = DSP.DAL.SQLOSCA.GetDsBySP("SP_Track_GetLearnerShortDetails", "@Learner_ID", int.Parse(sLearnerId));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            { 
                s4 = s4.Replace("#COLOR#", ds.Tables[0].Rows[0]["CandidateStatus_BackColor"].ToString());
                lbl_fullname.Text += " - " + s4.Replace("#STATUS#", ds.Tables[0].Rows[0]["CandidateStatus_Title"].ToString());
            }
            catch (Exception exx)
            { }


        }
    }


    #endregion



 
    #region "-common"

    public void Users_SetGridWithData()
    {

       
    }
   

    
    public DataSet LoadData()
    {

        DataSet ds = DSP.DAL.SQL.GetRecordsBySQL("SELECT u.* FROM Users as u ORDER BY u.Users_Username ASC");
       if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds; 
 
        }
        else
        {
            return null;
             
        }

      
    }

    protected string getLearnerStatus(object learnerid)
    {

        string strId = learnerid.ToString();
        string strReturn = "";
        if (strId != "")
        {

             strReturn = "<span style=\"color:" + strId + ";font-size:160%\">&#9632;</span>";//
        }
        return strReturn;


    }



    public bool ReturnStatus(object iValue)
    {

        bool sRet = false;

        string strReturn = iValue.ToString().Trim();
        if (strReturn == "" || strReturn == "0") { sRet = false; }
        else { sRet = true; }
        return sRet;

    }
    
    public bool ReturnEnableStatus(object iValue)
    {

        bool sRet = false;

        string strReturn = iValue.ToString().Trim();
        if (strReturn == "" || strReturn == "0") { sRet = false; }
        else { sRet = true; }
        return sRet;

    }


    #endregion


    #region "- update on click"


    protected void btn_UpdateActive_Click(object sender, EventArgs e)
    {
        CheckBox Button1 = (CheckBox)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        UpdateRow(grdRow);

    }



    protected void btn_UpdateTitle2_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow;
        grdRow = (GridViewRow)Button1.Parent.Parent;

        UpdateRow(grdRow);
    }


    protected void UpdateRow(GridViewRow grdRow)
    {

        string strID = ((Label)grdRow.FindControl("lbl_Users_Id")).Text;
      

         string sTitle = ((TextBox)grdRow.FindControl("txt_title")).Text;
        sTitle = sTitle.Trim();
      

        string sEmail = ((TextBox)grdRow.FindControl("txt_Email")).Text;
        sEmail = sEmail.Trim();
        if (sEmail == "" || sEmail.Length < 3)
        {
            MessageBox.ShowError("Enter a valid email address");
            return;
        }

        string sAssessorId = ((TextBox)grdRow.FindControl("txt_AssessorId")).Text;
        sAssessorId = sAssessorId.Trim();
        int iIdAssessor = 0;
        if (sAssessorId != "")
        {
            bool bError = int.TryParse(sAssessorId, out iIdAssessor);
            if (!bError)
            {
                MessageBox.ShowError("Enter a valid assessor id");
                return;
            }

        }

        string sOscaUserId = ((TextBox)grdRow.FindControl("txt_OscaUserId")).Text;
        sOscaUserId = sOscaUserId.Trim();
        int iIdOscaUser = 0;
        if (sOscaUserId != "")
        {
            bool bError = int.TryParse(sOscaUserId, out iIdOscaUser);
            if (!bError)
            {
                MessageBox.ShowError("Enter a valid osca id");
                return;
            }

        }

        string sLearnerId = ((TextBox)grdRow.FindControl("txt_LearnerId")).Text;
        sLearnerId = sLearnerId.Trim();
        int iLearnerId = 0;
        if (sLearnerId != "")
        {
            bool bError = int.TryParse(sLearnerId, out iLearnerId);
            if (!bError)
            {
                MessageBox.ShowError("Enter a learner id");
                return;
            }

        }
        

        bool bIsChecked = ((CheckBox)grdRow.FindControl("chk_IsChecked")).Checked;
        string sValue;

        if (bIsChecked == true)
        { sValue = "1"; }
        else { sValue = "0"; }


        bool bchk_IsAssessor = ((CheckBox)grdRow.FindControl("chk_IsAssessor")).Checked;
        string sbchk_IsAssessor;

        if (bchk_IsAssessor == true)
        { sbchk_IsAssessor = "1"; }
        else { sbchk_IsAssessor = "0"; }
         

        bool bFound = false;

         if (bFound == false)
        {
            string strSQL = "UPDATE [Users] ";
            strSQL += "SET Users_DisplayName = '" + DSP.BAL.Basic.FormatStringForSQL(sTitle) + "' ";
            strSQL += " ,  Users_Email = '" + DSP.BAL.Basic.FormatStringForSQL(sEmail).ToLower() + "' ";
            strSQL += " , Users_Id_AssessorContacts = '" + iIdAssessor.ToString() + "' ";
            strSQL += " , Users_IsAssessor = " + sbchk_IsAssessor;
            strSQL += " , Users_IsActive = " + sValue;
            strSQL += " , Users_Id_LearnerContacts = " + sLearnerId;
            strSQL += " , Users_Id_OSCA = " + iIdOscaUser;

             

            strSQL += " WHERE Users_Id = " + strID;




            DSP.DAL.SQL.ExecuteSQL(strSQL);
            


             Users_SetGridWithData();
            MessageBox.ShowSuccess("updated");
        }
        else
        {
         }





    }
 
#endregion





    #region " Sorting ang page index --- "
    protected void grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        
    }

    protected void grid_users_Sorting(object sender, GridViewSortEventArgs e)
    {


        
    }

    

    #endregion

    #region "- show_notif"


    protected void show_notif(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }

    #endregion





    #region "- list osca users"


    public void OSCAUsers_SetGridWithData()
    {
 
    }



    public DataSet LoadDataOSCAUsers()
    {

        DataSet ds = DSP.DAL.SQLOSCA.GetRecordsBySQL("SELECT u.Users_Id as 'OSCA Id', u.Users_Username as 'Username', u.Users_Id_AssessorContact as 'Id Assessor' FROM Users as u WHERE u.Users_IsActive = 1 ORDER BY u.Users_Username ASC");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds;

        }
        else
        {
            return null;

        }


    }


    #endregion










    protected void btnAddCat_Click(object sender, EventArgs e)
    {
        if (txtCatName.Text.Trim() != "")
        {
            string strCatName = txtCatName.Text.Trim();
            string strCatAccess = ddlAccess.SelectedValue;

            if (!isExistingCat(strCatName))
            {
                DSP.DAL.SQL.ExecuteSQL("insert into DocCategories (DocCat_Title, DocCat_Access) values ('" + DSP.BAL.Basic.FormatStringForSQL(strCatName) + "', " + strCatAccess + ")");

                show_notif("Category added.");

                grdCats.DataBind();
                ddlPublicCatList.DataBind();
            }
            else
            {
                show_notif("Category already exists.");

            }
        }
        else
        {
            show_notif("Incorrect category name.");

        }

    }

    private bool isExistingCat(string strCat)
    {
        DataSet isExisting = DSP.DAL.SQL.GetRecordsBySQL("select DocCat_Id from DocCategories where DocCat_Title = '" + strCat + "'");

        if (isExisting != null && isExisting.Tables.Count > 0 && isExisting.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow = (GridViewRow)Button1.Parent.Parent;

        string strCatId = grdRow.Cells[0].Text;

        DataSet docsCount1 = DSP.DAL.SQL.GetRecordsBySQL("SELECT count(Docs_Id) FROM Docs WHERE  Docs_Id_DocCategories = " + strCatId);
     
        int count1 = int.Parse(docsCount1.Tables[0].Rows[0][0].ToString());
     
     
        if (count1 > 0)
        {
            show_notif("Delete failed: " + count1.ToString().Trim() + " documents still assigned to category!");

        }
        else
        {
            DSP.DAL.SQL.ExecuteSQL("delete from DocCategories where DocCat_Id = " + strCatId);

            show_notif("Category deleted!");


            grdCats.DataBind();
            ddlPublicCatList.DataBind();
        }
    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {
         bool bError = false;
        string sPathFile = "";

        if (!upLoadFile.HasFile)
        {
            show_notif("Please select a file to upload");
            return;
        }


        if (upLoadFile.PostedFile.ContentLength > 4000000)
            {
                show_notif("File is too big to upload (max 4MB)");
                return;
            }




        string sDate = dAct_entry_date.Text.Trim();
       
        


        if (sDate == "")
        {
            show_notif("Please enter the correct date<br/>");
            return;
        }


          string sMSg = UploadCSVFile(upLoadFile, ref bError, ref sPathFile);
       
        show_notif(sMSg);

        


    }

    protected string UploadCSVFile(FileUpload fileuploading, ref bool bError, ref string sPathFile)
    {

          string strPath;
        sPathFile = "";

        if (!fileuploading.HasFile)
        {
            bError = true;
            return "file is not valid";
        }
        else
        {
            if (fileuploading.PostedFile.ContentLength > 4000000)
            {

                bError = true;
                return "file is limited to 4Mb";

            }
            else
            {
                string ss = fileuploading.FileName.ToUpper();
        string path = ConfigurationManager.AppSettings["cfg_portaldata_res"]; 
     
                string fileName = Path.GetFileName( fileuploading.PostedFile.FileName);
              
                string sDocFolders = "";//"Docs"
                string sFolderId = sDocFolders + ddlPublicCatList.SelectedValue;
             
                  bool exists = System.IO.Directory.Exists(path + "\\" +  sFolderId );
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(path + "\\" +  sFolderId);
                }

                strPath = path + "\\" +     sFolderId + "\\" + fileName;

                 if (System.IO.File.Exists(strPath))
                {
                    System.IO.File.Delete(strPath);
                }
                 if (!System.IO.File.Exists(strPath))
                {
                    fileuploading.SaveAs(strPath);
                    sPathFile = strPath;

                    string strDocCat = ddlPublicCatList.SelectedValue.ToString().Trim();

                    string strUsersName = Membership.GetUser().UserName;
                    int iUsersID = DSP.BAL.DBL.GetUser_UserId(strUsersName);
                    string sDate = dAct_entry_date.Text.Trim();
      
                     string strSQL = "INSERT INTO Docs (Docs_Id_DocCategories " ;
                    strSQL += ", Docs_Title" ;
                    strSQL += ", Docs_File" ;
                    strSQL += ", Docs_IsActive" ;
                    strSQL += ", Docs_CreatedDate" ;
                    strSQL += ", Docs_EnteredByUser" ;
                    strSQL += ", Docs_EnteredBy ";
                    strSQL += ", Docs_FileDate ";
                    strSQL += ", Docs_Version ";
                    strSQL += " ) VALUES "  ;

                    strSQL += "("  +  strDocCat ;
                    strSQL += ", '" + fileName ;
                    strSQL +=  "', '" + strPath + "'" ;
                    strSQL += ", 1" ;
                    strSQL += ", getdate() " ;
                    strSQL +=  ", '" + strUsersName + "'" ;
                    strSQL += "," + iUsersID ;
                    strSQL += ", '" + DSP.BAL.Basic.ConvertDateToSQL(sDate) + "' ";
                    strSQL += ", '" + DSP.BAL.Basic.FormatStringForSQL(txtVersion.Text.Trim()) + "' "; 
                    strSQL += ")";

                   
                    DSP.DAL.SQL.ExecuteSQL(strSQL);
                    DisplayFilesBelongingCats();


                    bError = false;
                    return "file is uploaded";
                }
                else
                {
                    bError = true;
                    return "file already exists on system. Please choose another name";

                }

                
            }
        }

    }



    private void bindDDLPublicCats()
    {
        DataSet dsPublicCast = DSP.DAL.SQL.GetRecordsBySQL("select DocCat_Id, DocCat_Title from DocCategories "); // WHERE DocCat_Access = 1
        if (dsPublicCast == null || dsPublicCast.Tables.Count == 0 || dsPublicCast.Tables[0].Rows.Count == 0)
        {
            return;
        }
        ddlCatList.DataSource = dsPublicCast.Tables[0];

        ddlCatList.DataTextField = "DocCat_Title";
        ddlCatList.DataValueField = "DocCat_Id";

        ddlCatList.DataBind();
    }

 protected void ddlCatList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayFilesBelongingCats();
    }

    private void DisplayFilesBelongingCats()
    {
        string strSql = "select Docs.Docs_ID as 'Id', Docs.Docs_Title as 'File_Name', Docs.Docs_File as 'File_Path', Users.Users_Username as 'Uploaded By' , CONVERT(varchar(10), Docs_FileDate,103) as 'FileDate'  , Docs_Version FROM Docs Left outer join Users on Users.Users_Id = Docs.Docs_EnteredBy";
        string selectedCat = ddlCatList.SelectedValue;

        if (selectedCat.Trim() != "")
        {
            strSql = strSql + " where Docs_Id_DocCategories = " + selectedCat;
        }

       

        DataSet ds = new DataSet();
        ds = DSP.DAL.SQL.GetRecordsBySQL(strSql);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grid_files.DataSource = ds;
            grid_files.DataBind();
        }
    }



    protected void btnDeleteFiles_Click(object sender, EventArgs e)
    {
        LinkButton Button1 = (LinkButton)sender;
        GridViewRow grdRow = (GridViewRow)Button1.Parent.Parent;

        string strFileId = grdRow.Cells[0].Text;

        string strFilePath = grdRow.Cells[4].Text;

        DSP.DAL.SQL.ExecuteSQL("delete from Docs where Docs_Id = " + strFileId);
        grid_files.DataBind();

        if (System.IO.File.Exists(strFilePath))
        {
            System.IO.File.Delete(strFilePath);
            show_notif("File deleted.");
            DisplayFilesBelongingCats();

        }
        else
        {
            show_notif("Entry deleted but physical file could not be found: " + strFilePath);


        }

    }
   

}
















 






















/*

  
<asp:GridView   ID="grid_users" SkinID="GridView" runat="server" 
    OnPageIndexChanging="grid_users_PageIndexChanging" 
    OnSorting="grid_users_Sorting"

    AutoGenerateColumns="False"  
    AllowPaging="False" BorderWidth="1px" 
    BorderStyle="Solid" UseAccessibleHeader="False" 
    AllowSorting="false" CssClass="GridView"  
     
    Width="100%" EnableModelValidation="True">
    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
    <FooterStyle CssClass="FooterStyle" />
    <HeaderStyle CssClass="HeaderStyle" />
    <PagerStyle CssClass="PagerStyle" />
    <RowStyle CssClass="RowStyle" />
    <SelectedRowStyle CssClass="SelectedRowStyle" />
    <SortedAscendingHeaderStyle CssClass="sortasc-header" />
    <SortedDescendingHeaderStyle CssClass="sortdesc-header" />
    <SortedAscendingCellStyle CssClass="sortasc-row" />
    <SortedDescendingCellStyle CssClass="sortdesc-row" />
     <PagerStyle />
    <EditRowStyle />
    <EmptyDataRowStyle />
    <EmptyDataTemplate>
        <div class="notice">
            Sorry, no data available.
         </div>
    </EmptyDataTemplate>       
<Columns>

 

<asp:TemplateField HeaderText="Id" Visible="False" >
<ItemTemplate>
<asp:Label ID="lbl_Users_Id" runat="server" Text='<%# Bind("Users_Id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 
 
<asp:TemplateField HeaderText="Username" Visible="True" HeaderStyle-Width="120px">
<ItemTemplate>
<asp:Label ID="lbl_Users_Username" runat="server" Text='<%# Bind("Users_Username") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 
 
 
 
<asp:TemplateField HeaderText="Display Name" HeaderStyle-Width="120px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_Title" runat="server" MaxLength="200" ToolTip="Display Name"
Width="80%" Text="<%# Bind('Users_DisplayName') %>"></asp:TextBox>
 
 
</ItemTemplate>
</asp:TemplateField>
  
<asp:TemplateField HeaderText="Email" HeaderStyle-Width="130px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_Email" runat="server" MaxLength="200" ToolTip="Email"
Width="90%" Text="<%# Bind('Users_Email') %>"></asp:TextBox>
 </ItemTemplate>
</asp:TemplateField>  


<asp:TemplateField HeaderText="Assessor Id" HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_AssessorId" runat="server" MaxLength="200" ToolTip="Assessor Id"
Width="90%" Text="<%# Bind('Users_Id_AssessorContacts') %>"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

  

<asp:TemplateField HeaderText="is Assessor?" HeaderStyle-Width="30px"  >
<ItemTemplate>  
<asp:CheckBox CssClass="ob_gTXT"  ID="chk_IsAssessor" runat="server" ToolTip="is an assessor?"
Text=""
Checked='<%# ReturnStatus(DataBinder.Eval(Container.DataItem, "Users_IsAssessor")) %>' 

></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>



<asp:TemplateField HeaderText="OSCA User Id" HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_OscaUserId" runat="server" MaxLength="200" ToolTip="OSCA User Id"
Width="90%" Text="<%# Bind('Users_Id_OSCA') %>"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Learner Id" HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_LearnerId" runat="server" MaxLength="200" ToolTip="Learner Id"
Width="90%" Text="<%# Bind('Users_Id_LearnerContacts') %>"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>





<asp:TemplateField HeaderText="Active"  HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:CheckBox CssClass="ob_gTXT"  ID="chk_IsChecked" runat="server" ToolTip="Active"
OnCheckedChanged="btn_UpdateActive_Click" Text="" AutoPostBack="true"
Checked='<%# ReturnStatus(DataBinder.Eval(Container.DataItem, "Users_IsActive")) %>' 

></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>


 
   
   <asp:TemplateField ShowHeader="False"  HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate>
<asp:LinkButton ID="btnUpdateTitle" SkinID="LinkButton" runat="server"   OnClick="btn_UpdateTitle2_Click" Text='Update' />
</ItemTemplate>
</asp:TemplateField>
  
 
   


</Columns>
 
</asp:GridView>


  
    


 
  
<asp:GridView   ID="grid_osca_users" SkinID="GridView" runat="server" 
     
    AutoGenerateColumns="True"  
    AllowPaging="False" BorderWidth="1px" 
    BorderStyle="Solid" UseAccessibleHeader="False" 
    AllowSorting="false" CssClass="GridView"  
     
    Width="100%" EnableModelValidation="True">
    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
    <FooterStyle CssClass="FooterStyle" />
    <HeaderStyle CssClass="HeaderStyle" />
    <PagerStyle CssClass="PagerStyle" />
    <RowStyle CssClass="RowStyle" />
    <SelectedRowStyle CssClass="SelectedRowStyle" />
    <SortedAscendingHeaderStyle CssClass="sortasc-header" />
    <SortedDescendingHeaderStyle CssClass="sortdesc-header" />
    <SortedAscendingCellStyle CssClass="sortasc-row" />
    <SortedDescendingCellStyle CssClass="sortdesc-row" />
     <PagerStyle />
    <EditRowStyle />
    <EmptyDataRowStyle />
    <EmptyDataTemplate>
        <div class="notice">
            Sorry, no data available.
         </div>
    </EmptyDataTemplate>       
</asp:GridView>
            */



/*

  
<asp:GridView   ID="grid_users" SkinID="GridView" runat="server" 
    OnPageIndexChanging="grid_users_PageIndexChanging" 
    OnSorting="grid_users_Sorting"

    AutoGenerateColumns="False"  
    AllowPaging="False" BorderWidth="1px" 
    BorderStyle="Solid" UseAccessibleHeader="False" 
    AllowSorting="false" CssClass="GridView"  
     
    Width="100%" EnableModelValidation="True">
    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
    <FooterStyle CssClass="FooterStyle" />
    <HeaderStyle CssClass="HeaderStyle" />
    <PagerStyle CssClass="PagerStyle" />
    <RowStyle CssClass="RowStyle" />
    <SelectedRowStyle CssClass="SelectedRowStyle" />
    <SortedAscendingHeaderStyle CssClass="sortasc-header" />
    <SortedDescendingHeaderStyle CssClass="sortdesc-header" />
    <SortedAscendingCellStyle CssClass="sortasc-row" />
    <SortedDescendingCellStyle CssClass="sortdesc-row" />
     <PagerStyle />
    <EditRowStyle />
    <EmptyDataRowStyle />
    <EmptyDataTemplate>
        <div class="notice">
            Sorry, no data available.
         </div>
    </EmptyDataTemplate>       
<Columns>

 

<asp:TemplateField HeaderText="Id" Visible="False" >
<ItemTemplate>
<asp:Label ID="lbl_Users_Id" runat="server" Text='<%# Bind("Users_Id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 
 
<asp:TemplateField HeaderText="Username" Visible="True" HeaderStyle-Width="120px">
<ItemTemplate>
<asp:Label ID="lbl_Users_Username" runat="server" Text='<%# Bind("Users_Username") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 
 
 
 
<asp:TemplateField HeaderText="Display Name" HeaderStyle-Width="120px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_Title" runat="server" MaxLength="200" ToolTip="Display Name"
Width="80%" Text="<%# Bind('Users_DisplayName') %>"></asp:TextBox>
 
 
</ItemTemplate>
</asp:TemplateField>
  
<asp:TemplateField HeaderText="Email" HeaderStyle-Width="130px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_Email" runat="server" MaxLength="200" ToolTip="Email"
Width="90%" Text="<%# Bind('Users_Email') %>"></asp:TextBox>
 </ItemTemplate>
</asp:TemplateField>  


<asp:TemplateField HeaderText="Assessor Id" HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_AssessorId" runat="server" MaxLength="200" ToolTip="Assessor Id"
Width="90%" Text="<%# Bind('Users_Id_AssessorContacts') %>"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

  

<asp:TemplateField HeaderText="is Assessor?" HeaderStyle-Width="30px"  >
<ItemTemplate>  
<asp:CheckBox CssClass="ob_gTXT"  ID="chk_IsAssessor" runat="server" ToolTip="is an assessor?"
Text=""
Checked='<%# ReturnStatus(DataBinder.Eval(Container.DataItem, "Users_IsAssessor")) %>' 

></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>



<asp:TemplateField HeaderText="OSCA User Id" HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_OscaUserId" runat="server" MaxLength="200" ToolTip="OSCA User Id"
Width="90%" Text="<%# Bind('Users_Id_OSCA') %>"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Learner Id" HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:TextBox CssClass="ob_gTXT"  ID="txt_LearnerId" runat="server" MaxLength="200" ToolTip="Learner Id"
Width="90%" Text="<%# Bind('Users_Id_LearnerContacts') %>"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>





<asp:TemplateField HeaderText="Active"  HeaderStyle-Width="30px" >
<ItemTemplate>  
<asp:CheckBox CssClass="ob_gTXT"  ID="chk_IsChecked" runat="server" ToolTip="Active"
OnCheckedChanged="btn_UpdateActive_Click" Text="" AutoPostBack="true"
Checked='<%# ReturnStatus(DataBinder.Eval(Container.DataItem, "Users_IsActive")) %>' 

></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>


 
   
   <asp:TemplateField ShowHeader="False"  HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate>
<asp:LinkButton ID="btnUpdateTitle" SkinID="LinkButton" runat="server"   OnClick="btn_UpdateTitle2_Click" Text='Update' />
</ItemTemplate>
</asp:TemplateField>
  
 
   


</Columns>
 
</asp:GridView>


  
    


 
  
<asp:GridView   ID="grid_osca_users" SkinID="GridView" runat="server" 
     
    AutoGenerateColumns="True"  
    AllowPaging="False" BorderWidth="1px" 
    BorderStyle="Solid" UseAccessibleHeader="False" 
    AllowSorting="false" CssClass="GridView"  
     
    Width="100%" EnableModelValidation="True">
    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
    <FooterStyle CssClass="FooterStyle" />
    <HeaderStyle CssClass="HeaderStyle" />
    <PagerStyle CssClass="PagerStyle" />
    <RowStyle CssClass="RowStyle" />
    <SelectedRowStyle CssClass="SelectedRowStyle" />
    <SortedAscendingHeaderStyle CssClass="sortasc-header" />
    <SortedDescendingHeaderStyle CssClass="sortdesc-header" />
    <SortedAscendingCellStyle CssClass="sortasc-row" />
    <SortedDescendingCellStyle CssClass="sortdesc-row" />
     <PagerStyle />
    <EditRowStyle />
    <EmptyDataRowStyle />
    <EmptyDataTemplate>
        <div class="notice">
            Sorry, no data available.
         </div>
    </EmptyDataTemplate>       
</asp:GridView>
            */



/*<script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
<script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
<link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
    */



/*<script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
<script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
<link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
 
*/