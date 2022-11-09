<%@ Page Title="Log In" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="ActivateSuccess.aspx.cs" Inherits="root_ActivateSuccess" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h2>Activation Successful
    </h2>
    <p>
     Your account is now activated, you can now login and continue your application progress.
        
          <br />
        Click   
        <a id="lnkLogin" 
            class="forget" 
            href="Login.aspx" 
             >here</a> to login.
        <br />
    </p>
      
</asp:Content>
