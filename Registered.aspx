<%@ Page Title="About Us" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Registered.aspx.cs" Inherits="root_registered" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h1 class="title-regular">Thank you for registering </h1>  

        
   
    <p>
        We've sent an email <asp:Literal runat="server" id="litEmail"></asp:Literal> for an activation with a password. Click the link inside your email and continue your application process.

    </p>
    <br />

     <br />
        Click   
        <a id="lnkLogin" 
            class="forget" 
            href="Login.aspx" 
             >here</a> to login.
        <br />
</asp:Content>
