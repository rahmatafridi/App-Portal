<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ManageResources.aspx.cs" Inherits="Account_ManageResources" %>
   
 <%@ Register Src="~/Portal/wuc/wuc_MessageBox.ascx" TagName="MyMessageBox" TagPrefix="msgbx" %>
     <%@ Register TagPrefix="atk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>    
 
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    
<link   href="../../App_Resources/css/ajax_tabs.css" rel="stylesheet" type="text/css" />
   


 <link type="text/css" href="../../App_Resources/css/cupertino/jquery-ui-1.8.18.custom.css" rel="stylesheet" />	
<script type="text/javascript" src="../../App_Resources/js/ui/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../App_Resources/js/ui/jquery-ui-1.8.18.custom.min.js"></script>
	
<script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
<link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
 


<script language="javascript" type="text/javascript">
    $(function () {
       
        
    });
</script>

  
<script language="javascript" type="text/javascript">

    $(document).ready(function () {
        // Datepicker
        $(".DatepickerInput").datepicker({ dateFormat: 'dd/mm/yy' });
         $(".d_complete_date").datepicker({ dateFormat: 'dd/mm/yy' });




    }); 


</script> 



</asp:Content>

 
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
     
  <atk:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />


 <h1 class="title-regular"><asp:Label ID="lbl_fullname" runat="server" Text="">Manage Documents</asp:Label></h1>  
  
  <p></p>

   <msgbx:MyMessageBox ID="MessageBox" runat="server"  />
     <span id="jgrowlwarn" ></span> 

 
    
   
    <atk:TabContainer ID="tabs" runat="server" Width="100%" Height="100%" CssClass="ajax__tab_yuitabview-theme">
    <atk:TabPanel ID="tab_cats" runat="server" HeaderText="Categories"  >
    <HeaderTemplate>
    <img src="../../App_Resources/images/mail_in.gif" alt="" /> Categories
    </HeaderTemplate>
    <ContentTemplate>



    <!-- CATS -->







<table width="100%">
    <tr  >
        <td><asp:Label ID="CatName" runat="server" Text="Category Name"></asp:Label></td>
        <td><asp:TextBox ID="txtCatName" Width="90%" runat="server"></asp:TextBox></td>
    </tr>
    <tr class="ob_gNRM">
        <td>
            <asp:Label ID="CatAccess" runat="server" Text="Access Level"></asp:Label>
        </td>
        <td>
               <asp:DropDownList ID="ddlAccess" runat="server" Width="90%"
                DataSourceID="SDS_Track_GetListDocAccessLevels" 
                 DataTextField="DAL_Title" DataValueField="DAL_Id"></asp:DropDownList>
               
            
        </td>
    </tr>
  <tr  >
        <td colspan = "2" align="left">
            <asp:LinkButton  SkinID="LinkButton"  ID="btnAddCat" runat="server" Text="Add Category"  OnClick="btnAddCat_Click"  />
        </td>
    </tr>
</table>  
   <asp:SqlDataSource ID="SDS_Track_GetListDocAccessLevels" runat="server" 
      ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
      SelectCommand="SELECT DAL_Id , DAL_Title FROM DocAccessLevels WHERE  DAL_IsActive  = 1 ORDER BY DAL_Title ASC"> 
           
    </asp:SqlDataSource>
     

     

    <asp:GridView   ID="grdCats" SkinID="GridView" runat="server" 
    DataSourceID="SDS_CatListing"

    AutoGenerateColumns="False"  
    AllowPaging="true" BorderWidth="1px" 
    BorderStyle="Solid" UseAccessibleHeader="False" 
    AllowSorting="true" CssClass="GridView"  
     
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

  
<asp:BoundField DataField="DocCat_Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="DocCat_Id" ControlStyle-Width="10%" Visible="true"/>
<asp:BoundField DataField="DocCat_Title" HeaderText="Title" SortExpression="DocCat_Title" ControlStyle-Width="60%" />  
<asp:BoundField DataField="DAL_Title" HeaderText="Access" SortExpression="DAL_Title" ControlStyle-Width="30%" /> 
<asp:TemplateField HeaderStyle-Width="10%">
<ItemTemplate>
<asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick = "return confirm('Are you sure you want to delete this record?');" OnClick = "btnDelete_Click" SkinID="LinkButton"   />
</ItemTemplate>        
</asp:TemplateField> 
            
         
</Columns>
</asp:GridView>
     <asp:SqlDataSource ID="SDS_CatListing" runat="server"
     ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
     SelectCommand="SP_Docs_GetListDocCategories" SelectCommandType="StoredProcedure" 
     DeleteCommand="SP_Docs_DeleteDocCat" DeleteCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="docCatId" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
         
                   





     <!-- CATS -->

    </ContentTemplate>


 
     
    </atk:TabPanel>




    <atk:TabPanel ID="tab_files" runat="server" HeaderText="Files" >
    <HeaderTemplate>
    <img src="../../App_Resources/images/mail_new.gif" alt="" /> Files
    </HeaderTemplate> 
    <ContentTemplate>
       
    <!-- FILES -->
    <table width="100%">
    <tr  >
            <td><asp:Label ID="lblCap1" runat="server" Text="Select a File"></asp:Label></td>
            <td><asp:FileUpload ID="upLoadFile" runat="server" /></td>
        </tr>


          <tr  >
            <td><asp:Label ID="Label1" runat="server" Text="File Date"></asp:Label></td>
            <td><asp:TextBox  style="text-transform:uppercase" ID="dAct_entry_date" runat="server" MaxLength="10" ToolTip="Date"
        Width="80px" CssClass="DatepickerInput" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="req_entry_date" runat="server" ControlToValidate="dAct_entry_date"
        Display="None" ErrorMessage="<b>Invalid Data!</b><br />Only a valid date allowed (dd/mm/yyyy)"
        ValidationExpression="\d{2}/\d{2}/\d{4}"></asp:RegularExpressionValidator> </td>
        </tr>
 
           <tr  >
            <td><asp:Label ID="Label2" runat="server" Text="File Version (ie v1.0.0)"></asp:Label></td>
            <td><asp:TextBox ID="txtVersion" runat="server"></asp:TextBox>
          </td>
        </tr>


        <tr>
            <td><asp:Label ID="lblCap2" runat="server" Text="Select a category"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlPublicCatList" Width="90%" runat="server" DataSourceID="SDS_PublicCats" DataTextField="DocCat_Title" DataValueField="DocCat_Id"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:LinkButton ID="btnUpload" runat="server" Text="Upload File" SkinID="LinkButton"  OnClick="btnUpload_Click"   /></td>
            <td></td>
        </tr>
    </table>
    
    <asp:SqlDataSource ID="SDS_PublicCats" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBConnection %>"
         SelectCommand="select DocCat_Id, DocCat_Title from DocCategories "></asp:SqlDataSource>




         
     <table  width="100%">
    <tr  >
            <td><asp:Label ID="lblCap3" runat="server" Text="<b>Select the category to show files<b>"></asp:Label></td>
            <td><asp:DropDownList Width="90%" ID="ddlCatList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCatList_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
    </table>

    <asp:GridView   ID="grid_files" SkinID="GridView" runat="server" 
   

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


<asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" ControlStyle-Width="10%" Visible="true"/>
<asp:BoundField DataField="File_Name" HeaderText="Title" SortExpression="File_Name" ControlStyle-Width="80%"  ItemStyle-Width="80%"  />  
 <asp:BoundField DataField="Docs_Version" HeaderText="Ver." SortExpression="Docs_Version" ControlStyle-Width="10%" /> 

<asp:TemplateField>
<ItemTemplate>
    <asp:LinkButton ID="btnDeleteFiles" SkinID="LinkButton" runat="server" Text="Delete" OnClientClick = "return confirm('Are you sure you want to delete this file?');" OnClick = "btnDeleteFiles_Click" />
</ItemTemplate>        
</asp:TemplateField> 


    
<asp:BoundField DataField="File_Path" HeaderText="Path" SortExpression="File_Path"  ItemStyle-Width="10px" Visible="false" /> 


</Columns>


    </asp:GridView>
    





    
    <!-- FILES -->
    </ContentTemplate>
          
    </atk:TabPanel>




     </atk:TabContainer>



    



















</asp:Content>
