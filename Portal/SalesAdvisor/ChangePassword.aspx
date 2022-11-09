<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
 
    <div class="panel panel-info">
        <div class="panel-heading">Change Password</div>
        <div class="panel-body">
            <p class="help-block">
                Use the form below to change your password.  
            </p>
            <p class="help-block">
                New passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
            </p>
            <div class="form-horizontal">
                <asp:Label ID="lblMessage" runat="server" />
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="alert alert-warning"
                    ValidationGroup="ChangeUserPasswordValidationGroup" />
                <div class="form-group">
                    <asp:Label ID="CurrentPasswordLabel" CssClass="col-sm-4 control-label" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                    <div class="col-sm-8 form-inline">
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            ErrorMessage="Old password is required." ToolTip="Old password is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="NewPasswordLabel" CssClass="col-sm-4 control-label" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                    <div class="col-sm-8 form-inline">
                        <asp:TextBox ID="NewPassword" CssClass="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="ConfirmNewPasswordLabel" CssClass="col-sm-4 control-label" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                    <div class="col-sm-8 form-inline">
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                            ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-4 col-sm-10">
                        <asp:LinkButton   runat="server" ID="ChangePasswordPushButton" CssClass="btn btn-primary btn-sm"
                            CommandName="ChangePassword" Text="Change Password" OnClick="ChangePasswordPushButton_Click"
                            ValidationGroup="ChangeUserPasswordValidationGroup" />
                        <asp:LinkButton   runat="server" ID="CancelPushButton" CausesValidation="False" CssClass="btn btn-info btn-sm"
                            CommandName="Cancel" Text="Cancel" />

                    </div>
                </div>


                <%-- <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false"
                    SuccessPageUrl="ChangePasswordSuccess.aspx">
                    <ChangePasswordTemplate>
                        
                      
                    </ChangePasswordTemplate>
                </asp:ChangePassword>--%>
            </div>

        </div>
    </div>


</asp:Content>
