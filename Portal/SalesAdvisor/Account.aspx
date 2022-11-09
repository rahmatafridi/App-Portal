<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Portal_SalesAdvisor_Account" MasterPageFile="~/Portal/PortalMaster.master"%>

 
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
    <link type="text/css" href="../../editors/tinyeditor/tinyeditor.css" rel="stylesheet" />
    <script type="text/javascript" src="../../editors/tinyeditor/tiny.editor.packed.js"></script>

    <script type="text/javascript" src='<%#ResolveUrl("~/App_Resources/bs/js/bootstrap.min.js")%>'></script>
    
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
  
  <div class="panel panel-info">
            <div class="panel-heading">Account home</div>
            <div class="panel-body">
           Dear  <asp:LoginName ID="HeadLoginName" runat="server" />....
  
                </div>
   </div>

</asp:Content>