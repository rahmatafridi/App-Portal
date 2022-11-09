<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   <h1 class="title-regular"> Administrator Home page   </h1>  

        Dear admin  <asp:LoginName ID="HeadLoginName" runat="server" />....
     
    <p>
         
    </p>
    
</asp:Content>
