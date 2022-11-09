<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">


</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h2>
        Portal Log In
    </h2>
    <p>
        Please enter your username and password.
       <!-- <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink> if you don't have an account.
    --></p>
   
    <fieldset class="login">
        <legend>Account Information</legend>
        <p>
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"  >Username: </asp:Label>
            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" >Password: </asp:Label>
            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>

         
          <p><asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="<b>Your username or password is invalid.<br/> Please try again.</b>" Visible="False"></asp:Label> </p>
    
         <%-- <p>
            <asp:CheckBox ID="RememberMe" runat="server"/>
            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
         </p>--%>
             <asp:LinkButton SkinID="LinkButton" runat="server" OnClick="LoginButton_Click" ID="LoginButton" ValidationGroup="LoginUserValidationGroup"
                     CommandName="Login" Text="Log In"    />
 
        
    </fieldset>
    <p class="submitButton">
                     
   
    
   
 </p>
     
    <a id="lnkPasswdRetrieval" 
            class="forget" 
            href="ResetPassword.aspx" 
           >
        I have forgotten my password</a> 
 
  <a id="lnkContactWave" 
            class="forget" 
            href="ContactUs.aspx" 
           >
       Contact us</a> 

             <script language="javascript" >
                 $(document).ready(function () {
                     $('#<%= Password.ClientID %>').keypress(function (e) {
                         if (e.keyCode == 13)
                             $('#<%= LoginButton.ClientID %>').click();
                     });
                 });
                 </script>
</asp:Content>