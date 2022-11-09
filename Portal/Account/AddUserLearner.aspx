<%@ Page Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true" CodeFile="AddUserLearner.aspx.cs" Inherits="Admin_AddUserLearner" Title="Add New User" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
  
    <script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />


</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">    
    
    <h1 class="title-regular">Add Learner User</h1>

       <p>
       Create new learner user on the system.
    </p>
    
    <span id="jgrowlwarn" ></span>
     
     <asp:RequiredFieldValidator 
        id="userNameRequired" 
        runat="server" 
        ControlToValidate="txtUserName"
        ErrorMessage="<b>* You must enter a Username</b><br />" 
        Display="dynamic">
    </asp:RequiredFieldValidator>
    
    <asp:RequiredFieldValidator 
        id="password1Required" 
        runat="server" 
        ControlToValidate="txtPassword"
        ErrorMessage="<b>* You must enter a Password</b><br />" 
        Display="dynamic">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator 
        id="password2Required" 
        runat="server" 
        ControlToValidate="txtPasswordConfirm"
        ErrorMessage="<b>* You must confirm the Password</b><br />" 
        Display="dynamic">
    </asp:RequiredFieldValidator>
    
    <asp:CompareValidator id="passwordCompare" 
        runat="server"
        ControlToValidate="txtPassword" 
        ControlToCompare="txtPasswordConfirm"
        Operator = "Equal" 
        ErrorMessage="<b>* Passwords Must Match!</b>"
        Display="dynamic">
    </asp:CompareValidator>



    <asp:Table runat = "server" ID = "AddUserTable" CellPadding = "0" CellSpacing = "0">
     
      <asp:TableRow>
            <asp:TableCell>
                <asp:Label Width = "150" ID="lblUsername" runat="server" Text="Username "></asp:Label>
            </asp:TableCell>
            
            <asp:TableCell>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> (use OSCA ID for login to Portal)
            </asp:TableCell>
        </asp:TableRow>


     
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label Width = "150" ID="lblDisplayname" runat="server" Text="Display Name "></asp:Label>
            </asp:TableCell>
            
            <asp:TableCell>
                <asp:TextBox ID="txt_displayname" runat="server"></asp:TextBox>  (use a nickname or a short name for displaying)
            </asp:TableCell>
        </asp:TableRow>


        
       
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Width = "150" ID="lblPass" runat="server" Text="Password "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Width = "150" ID="lblPassConfirm" runat="server" Text="Confirm Password"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    
   
    

          <asp:TableRow>
            <asp:TableCell>
                <asp:Label Width = "150" ID="Label1" runat="server" Text="Email Details?"></asp:Label>
            </asp:TableCell>
            
            <asp:TableCell>
                <asp:CheckBox ID="chkSendDetails" runat="server"></asp:CheckBox>  (Tick if you want send login details to the learner by email)
            </asp:TableCell>
        </asp:TableRow>


        
        <asp:TableRow>
            <asp:TableCell ColumnSpan = "2">
                 
                 <asp:LinkButton SkinID="LinkButton" runat="server" ID="btnAddUser" Text="Create User"
    OnClick="btnAddUser_Click" />
    
                   
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
   
    
  
    
</asp:Content>
