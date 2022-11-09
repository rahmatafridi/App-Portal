<%@ Page Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ChangeUsersPassword.aspx.cs" Inherits="Admin_ChangeUsersPassword" Title="Change User's Password" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">

    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
     <script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />

</asp:Content>





<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="panel panel-info">
        <div class="panel-heading">Change User's Password</div>
        <div class="panel-body">

            <p>
                <asp:Table runat="server" ID="passwordTable" HorizontalAlign="Center" CellPadding="0" CellSpacing="0">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="center">
                            <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblUserSelect" runat="server" Text="Select User:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlUserList" runat="server" DataSourceID="SDS_UserList" DataTextField="Users_Username" DataValueField="Users_Username"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="center">
                            <asp:Label ID="lblCap" runat="server"><br /><B>Please Enter and Confirm the New Password</B><br /><br /></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label Width="200" ID="lblPass" runat="server" Text="Enter new password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label Width="200" ID="lblPassConfirm" runat="server" Text="Confirm new password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell>
                            <asp:LinkButton ID="btnChangePw" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnChangePw_Click" Text="Change Password" />

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <asp:RequiredFieldValidator
                    ID="password1Required"
                    runat="server"
                    CSsClass="error" Style="display: block"
                    ControlToValidate="txtPassword"
                    ErrorMessage="<b>* You must enter a new Password</b><br />"
                    Display="dynamic">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator
                    ID="password2Required"
                    runat="server"
                    CSsClass="error" Style="display: block"
                    ControlToValidate="txtPasswordConfirm"
                    ErrorMessage="<b>* You must confirm your new Password</b><br />"
                    Display="dynamic">
                </asp:RequiredFieldValidator>

                <asp:CompareValidator ID="passwordCompare"
                    runat="server"
                    CSsClass="error" Style="display: block"
                    ControlToValidate="txtPassword"
                    ControlToCompare="txtPasswordConfirm"
                    Operator="Equal"
                    ErrorMessage="<b>* Passwords Must Match!</b>"
                    Display="dynamic">
                </asp:CompareValidator>

                <asp:SqlDataSource ID="SDS_UserList" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                    SelectCommand="select Users_Username from Users where Users_Password is not null order by Users_Username"></asp:SqlDataSource>
        </div>
    </div>


</asp:Content>

