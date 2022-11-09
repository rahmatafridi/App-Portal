<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuc_email_tpl_all.ascx.cs"
 Inherits="account_wuc_email_tpl_all" %>
  
<%@ Register Src="~/Portal/wuc/wuc_MessageBox.ascx" TagName="MyMessageBox" TagPrefix="msgbx" %>
<%@ Register TagPrefix="atk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>  
  
 


<msgbx:MyMessageBox ID="MessageBox" runat="server"  /> 
  
  
  
   
 <!-- --------------------------- -->
  <div class="grid-viewer grid_19 clearfix">    

<asp:Literal EnableViewState="false" runat="server" ID="ltlMessage"></asp:Literal>
<asp:GridView ID="grid_templates" runat="server" SkinID="GridView" 
  Width="95%" DataSourceID="SDS_EmailTemplates_GetList"
ClientIDMode="Static" DataKeyNames="ET_Id">
 
<EmptyDataTemplate>
<div class="notice">
    Sorry, no data available.
    </div>
</EmptyDataTemplate>  
<Columns>
<asp:TemplateField Visible="false">
<ItemTemplate>
<asp:CheckBox runat="server" ID="chkEmployeeSelector" />
</ItemTemplate>
<HeaderTemplate>
<asp:CheckBox runat="server" ID="chkSelectAll" ClientIDMode="Static" onclick="SelectAll('grid_templates','chkSelectAll')" />
</HeaderTemplate>
</asp:TemplateField>
 
<asp:TemplateField HeaderText="Id" Visible="true " HeaderStyle-Width="5%">
<ItemTemplate>
<asp:Label ID="lbl_ET_Id" runat="server" Text='<%# Bind("ET_Id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
 
<asp:TemplateField HeaderText="Title" HeaderStyle-Width="60%" >
<ItemTemplate>  
<asp:Label ID="lbl_ET_Title" runat="server" Text='<%# Bind("ET_Title") %>'></asp:Label>
  
</ItemTemplate>
</asp:TemplateField>
      
<asp:TemplateField HeaderText="Active?" HeaderStyle-Width="20px" >
<ItemTemplate>  
   
<asp:CheckBox CssClass="ob_gTXT"  ID="chk_IsChecked" Enabled="false" runat="server" ToolTip="Active"
Text=""
Checked='<%# ReturnStatus(DataBinder.Eval(Container.DataItem, "ET_IsActive")) %>' 

></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>  
 
<asp:TemplateField HeaderText="Update"  HeaderStyle-Width="50px" ItemStyle-Width="50px">
<ItemTemplate>
<asp:LinkButton OnClick="btn_Update_Click" CssClass="GridIcon ico-view"  ID="btn_Update" Text='' runat="server" />
</ItemTemplate>
</asp:TemplateField> 
  
<asp:TemplateField HeaderText="Copy"  HeaderStyle-Width="50px" ItemStyle-Width="50px">
<ItemTemplate>
<asp:LinkButton OnClick="btn_Duplicate_Click" CssClass="GridIcon ico-copy"  ID="btn_Duplicate" Text='' runat="server" />
</ItemTemplate>
</asp:TemplateField>
 
 <asp:TemplateField HeaderText="Delete"  HeaderStyle-Width="50px" ItemStyle-Width="50px">
<ItemTemplate>
<asp:LinkButton OnClick="btn_RequestDelete_Click" CssClass="GridIcon ico-delete"  ID="btn_RequestDelete" Text='' runat="server" />

</ItemTemplate>
</asp:TemplateField>     

</Columns>
</asp:GridView>

 <asp:SqlDataSource ID="SDS_EmailTemplates_GetList" runat="server" 
       ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
       SelectCommand="SP_EmailTemplates_GetList" SelectCommandType="StoredProcedure">
       
    </asp:SqlDataSource>
       
</div>

<div class="clearfix">
             
         
</div>

  <!-- --------------------------- -->
  <!-- --------------------------- -->
  <!-- --------------------------- -->



