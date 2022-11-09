<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" MasterPageFile="~/SiteMaster.master" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h1 class="title-regular">Error</h1>  
           
   <p class="text-center"><%= this.ErrorMessage%></p> 
</asp:Content>

