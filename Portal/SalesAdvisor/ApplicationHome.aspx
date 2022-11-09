<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationHome.aspx.cs" Inherits="Portal_SalesAdvisor_ApplicationHome"  MasterPageFile="~/Portal/PortalMaster.master"%>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   <h1 class="title-regular"> Applications Home page   </h1>  

        Dear  <asp:LoginName ID="HeadLoginName" runat="server" />....
    
</asp:Content>