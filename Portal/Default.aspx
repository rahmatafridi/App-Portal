<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   <h1 class="title-regular"> Welcome to the Portal</h1>  

        Dear  <asp:LoginName ID="HeadLoginName" runat="server" />....
     
    <p>
        To learn more about   
    </p>
    
</asp:Content>
