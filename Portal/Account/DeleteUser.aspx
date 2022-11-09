<%@ Page Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true" CodeFile="DeleteUser.aspx.cs" Inherits="Admin_DeleteUser" Title="Delete User" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
     <script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
    <script src="../../App_Resources/js/jgrowl/jquery.ui.all.js" type="text/javascript"></script>
    <link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="Server">


    <div class="panel panel-info">
        <div class="panel-heading">Delete user from the system</div>
        <div class="panel-body">


            <span id="jgrowlwarn"></span>




            <asp:Table runat="server" ID="AddUserTable" CellPadding="0" CellSpacing="0">



                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label Width="150" ID="lblUsername" runat="server" Text="Username "></asp:Label>
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>


                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>

                    <asp:TableCell>
                        <asp:LinkButton CssClass="btn btn-primary btn-sm" runat="server" ID="btnDelete" Text="Delete User" OnClick="btnDelete_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>



        </div>

    </div>
</asp:Content>
