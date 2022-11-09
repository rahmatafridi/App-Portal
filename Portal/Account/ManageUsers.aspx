<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ManageUsers.aspx.cs" Inherits="Account_ManageUsers" %>
  
 <%@ Register Src="~/Portal/wuc/wuc_MessageBox.ascx" TagName="MyMessageBox" TagPrefix="msgbx" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    
<script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
<script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
<link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />

 

</asp:Content>

 
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
     
 

 <h1 class="title-regular"><asp:Label ID="lbl_fullname" runat="server" Text="">Manage Users</asp:Label></h1>  
  
  <p></p>

   <msgbx:MyMessageBox ID="MessageBox" runat="server"  />
      
    
   
  
<asp:GridView   ID="grid_users" SkinID="GridView" runat="server" 
    OnPageIndexChanging="grid_users_PageIndexChanging" 
    OnSorting="grid_users_Sorting"

    AutoGenerateColumns="False"  
    AllowPaging="False" BorderWidth="1px" 
    BorderStyle="Solid" UseAccessibleHeader="False" 
    AllowSorting="false" CssClass="GridView"  
     PageSize="15"
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


<asp:TemplateField HeaderText="is Learner?" HeaderStyle-Width="30px"  >
<ItemTemplate>  
<asp:CheckBox CssClass="ob_gTXT"  ID="chk_IsLearner" runat="server" ToolTip="is an Learner?"
Text=""
Checked='<%# ReturnStatus(DataBinder.Eval(Container.DataItem, "Users_IsLearner")) %>' 

></asp:CheckBox>
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
            



</asp:Content>
