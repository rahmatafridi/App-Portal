<%@ Page Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true" CodeFile="AddSaleAdvisor.aspx.cs" Inherits="Admin_AddUserAdvisor" Title="Add New User" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">


    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
     <script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />

</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="Server">
 
     <div class="panel panel-info">
        <div class="panel-heading">Create new sale advisor user on the system.</div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-10">
                        <asp:RequiredFieldValidator
                            ID="userNameRequired"
                            runat="server"
                            ControlToValidate="txtUserName"
                            ErrorMessage="<b>* You must enter a Username</b><br />"
                            ForeColor="#f0ad4e"
                            Display="dynamic">
                        </asp:RequiredFieldValidator>                        
                        <asp:RequiredFieldValidator
                            ID="password1Required"
                            runat="server"
                            ControlToValidate="txtPassword"
                            ErrorMessage="<b>* You must enter a Password</b><br />"
                            ForeColor="#f0ad4e"
                            Display="dynamic">
                        </asp:RequiredFieldValidator>

                        <asp:RequiredFieldValidator
                            ID="password2Required"
                            runat="server"
                            ControlToValidate="txtPasswordConfirm"
                            ErrorMessage="<b>* You must confirm the Password</b><br />"
                            ForeColor="#f0ad4e"
                            Display="dynamic">
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="passwordCompare"
                            runat="server"
                            ControlToValidate="txtPassword"
                            ControlToCompare="txtPasswordConfirm"
                            Operator="Equal"
                            ErrorMessage="<b>* Passwords Must Match!</b>"
                            ForeColor="#f0ad4e"
                            Display="dynamic">
                        </asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label CssClass="col-sm-3 control-label" ID="lblUsername" runat="server" Text="User Name "></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtUserName" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                        <span class="help-block">(use an email address)
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDisplayname" CssClass="col-sm-3 control-label" runat="server" Text="Display Name "></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txt_displayname" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                        <span class="help-block">(use a nickname or a short name for displaying)
                        </span>
                    </div>
                </div>
                <div class="form-group">

                    <asp:Label ID="lblPass" CssClass="col-sm-3 control-label" runat="server" Text="Password "></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtPassword" CssClass="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPassConfirm" CssClass="col-sm-3 control-label" runat="server" Text="Confirm Password"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtPasswordConfirm" CssClass="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-7">
                        <asp:CheckBox ID="chkSendDetails" runat="server"></asp:CheckBox>  (Tick if you want send login details to the advisor by email)
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-10">
                        <asp:LinkButton SkinID="LinkButton" runat="server" ID="btnAddUser" Text="Create User" CssClass="btn btn-primary btn-sm"
                            OnClick="btnAddUser_Click" />
                    </div>
                </div>
                <span id="jgrowlwarn"></span>
            </div>
        </div>
    </div>
</asp:Content>
