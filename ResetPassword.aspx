<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="ResetPassword.aspx.cs" Inherits="root_resetpassword" %>


    <asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
   
    <script src="/App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="/App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="/App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />


</asp:Content>




<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h2>
        Reset my password
    </h2>
    <p>
        Please enter your email and we will send your new password.
     </p>
   
    <fieldset class="login">
        <legend>Account Information</legend>
        <p>
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Email:</asp:Label>
            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
      
         
             
            <p><asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="<b>Your email is invalid.<br/> Please try again.</b>" Visible="False"></asp:Label> </p>
         
        <asp:RequiredFieldValidator 
            runat="server" 
            ID="UserValid"
            ControlToValidate="UserName"
            Display="None"
            ErrorMessage="<b>Required Field Missing</b><br />An email is required." 
        />
         
          
          
        
           <asp:LinkButton ID="LoginButton" SkinID="LinkButton" runat="server" OnClick="ResetPassword_Click"   Text="Send"  />
          
    </fieldset>
   
    <br />
        Click   
        <a id="lnkLogin" 
            class="forget" 
            href="Login.aspx" 
             >here</a> to login.
        <br />


             
</asp:Content>