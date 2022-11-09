<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="portal_ContactUs" %>


    <asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
   
    <script src="../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />


</asp:Content>




<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h2>
        Contact Us
    </h2>
    <p>
        Please fill the form below and one of the member of the team will contact you soon.
     </p>
   
 
    <p>  <asp:Label ID="lbl_Name" runat="server" AssociatedControlID="txt_Name">Name:</asp:Label><br />
    <asp:TextBox ID="txt_Name" runat="server" CssClass="textEntry" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txt_Name" 
    CssClass="failureNotification" ErrorMessage="Your name is required." ToolTip="Your name is required." 
    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
          
    </p>
      
    <p>  <asp:Label ID="lbl_Email" runat="server" AssociatedControlID="txt_Email">Email:</asp:Label><br />
    <asp:TextBox ID="txt_Email" runat="server" CssClass="textEntry" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Email" 
    CssClass="failureNotification" ErrorMessage="Your email is required." ToolTip="Your email is required." 
    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
          
    </p>
    
     <p>  <asp:Label ID="lbl_Contactno" runat="server" AssociatedControlID="txt_Contactno">Contact No:</asp:Label><br />
    <asp:TextBox ID="txt_Contactno" runat="server" CssClass="textEntry" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Contactno" 
    CssClass="failureNotification" ErrorMessage="Your contact number is required." ToolTip="Your contact number is required." 
    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
          
    </p>


   
    <p>  <asp:Label ID="lbl_msg" runat="server" AssociatedControlID="txt_msg">Message:</asp:Label><br />
    <asp:TextBox ID="txt_msg" runat="server" CssClass="textEntry"   Width="300px" 
            Height="100px" Rows="8"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_msg" 
    CssClass="failureNotification" ErrorMessage="Your email is required." ToolTip="Your email is required." 
    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
          
    </p>
    


   
         
             
    <p><asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="<b>Your email is invalid.<br/> Please try again.</b>" Visible="False"></asp:Label> </p>
         
    <asp:RequiredFieldValidator 
    runat="server" 
    ID="UserValid"
    ControlToValidate="txt_Name"
    Display="None"
    ErrorMessage="<b>Required Field Missing</b><br />Your name is required." 
    />
         
          
          
        
           <asp:LinkButton ID="LoginButton" SkinID="LinkButton" runat="server" OnClick="LoginButton_Click"   Text="Submit"  />
          
   
      <br />   <br />

        Click   
        <a id="lnkLogin" 
            class="forget" 
            href="Login.aspx" 
             >here</a> to login.
        <br />


             
</asp:Content>