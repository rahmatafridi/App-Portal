<%@ Page Title="Register" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="root_register" %>


    <asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
   
    <script src="../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />


</asp:Content>




<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h2>
       Register
    </h2>
    <p>
        Please enter your name and email. You will need to confirm your email before proceeding. 
     </p>
   
    <fieldset class="login">
        <legend>Account Information</legend>
        
         <p>
            <asp:Label ID="lblName" runat="server" AssociatedControlID="txtEmail">Full Name</asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" 
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
        </p>

        <p>
            <asp:Label ID="lblEmailLabel" runat="server" AssociatedControlID="txtEmail">Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtEmailRequired" runat="server" ControlToValidate="txtEmail" 
                    CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required." 
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

        </p>
          
          <p><asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="<b>Your email is invalid.<br/> Please try again.</b>" Visible="False"></asp:Label> </p>
         
        <asp:RequiredFieldValidator 
            runat="server" 
            ID="UserValid"
            ControlToValidate="txtEmail"
            Display="None"
            ErrorMessage="<b>Required Field Missing</b><br />An email is required." 
        />
          
        
           <asp:LinkButton ID="btnRegister" SkinID="LinkButton" runat="server" OnClick="Register_Click"   Text="Register"  />
          
    </fieldset>
   
    <br />
        Click   
        <a id="lnkLogin" 
            class="forget" 
            href="Login.aspx" 
             >here</a> to login.
        <br />


             
</asp:Content>