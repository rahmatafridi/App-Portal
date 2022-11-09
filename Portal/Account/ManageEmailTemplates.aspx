<%@ Page Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ManageEmailTemplates.aspx.cs" Inherits="Account_ManageEmailTemplates" Title="Manage Email Templates" %>

<%@ Register Src="uc/wuc_email_tpl_all.ascx" TagName="wuc_email_tpl_all" TagPrefix="wuc_email_tpl_all_1" %>
<%@ Register Src="uc/wuc_email_tpl_create.ascx" TagName="wuc_email_tpl_create" TagPrefix="wuc_email_tpl_create_1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    <script type="text/javascript" src="../../editors/tinyeditor/tiny.editor.packed.js"></script>

    <link type="text/css" href="../../App_Resources/css/cupertino/jquery-ui-1.8.18.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../App_Resources/js/ui/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../App_Resources/js/ui/jquery-ui-1.8.18.custom.min.js"></script>
 
    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
        $(function () {
            $('#tabs').tabs();
        });
    </script>


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="panel panel-info">
        <div class="panel-heading">Manage Email Templates</div>
        <div class="panel-body">
            <p>Manage all email templates used in the portal </p>

            <asp:ScriptManager ID="scriptManager" runat="server" />

            <div id="tabs">
                <ul>
                    <li><a href="#tabs-1">List Templates </a></li>
                    <li><a href="#tabs-2">Add/Edit Template</a></li>
                </ul>

                <div id="tabs-1">
                    <!-- START PANEL: list Template panel-->
                    <wuc_email_tpl_all_1:wuc_email_tpl_all ID="wuc_email_tpl_all_now" runat="server" />
                    <!-- END PANEL  : list Template -->
                </div>
                <div id="tabs-2">
                    <!-- START PANEL: create Template panel-->
                    <wuc_email_tpl_create_1:wuc_email_tpl_create ID="wuc_email_tpl_create_now" runat="server" />
                    <!-- END PANEL  : create Template -->
                </div>

            </div>
        </div>
    </div>
</asp:Content>

