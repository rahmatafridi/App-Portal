<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invites.aspx.cs" 
    MasterPageFile="~/Portal/PortalMaster.master" Inherits="Portal_Admin_Invites" Title="All Invites" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Portal/wuc/wuc_MessageBox.ascx" TagName="MyMessageBox" TagPrefix="msgbx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
    <link type="text/css" href="../../editors/tinyeditor/tinyeditor.css" rel="stylesheet" />
    <script type="text/javascript" src="../../editors/tinyeditor/tiny.editor.packed.js"></script>

    <script type="text/javascript" src='<%#ResolveUrl("~/App_Resources/bs/js/bootstrap.min.js")%>'></script>
    <%--<link type="text/css" href="../../App_Resources/css/cupertino/jquery-ui-1.8.18.custom.css" rel="stylesheet" />--%>
    <%--<script type="text/javascript" src="../../App_Resources/js/ui/jquery-1.7.1.min.js"></script>--%>
    <%--<script type="text/javascript" src="../../App_Resources/js/ui/jquery-ui-1.8.18.custom.min.js"></script>--%>

    <style type="text/css">
        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 10px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 5px 7px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 5px 7px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }

        .table-sm {
            font-size: 11px !important;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }

        .panel-body {
            padding: 0px !important;
        }

        .table {
            margin-bottom: 0px !important;
        }

            .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
                vertical-align: middle !important;
            }
    </style>
    <script type="text/javascript">

        function open_email(ctr) {
            var obj = document.getElementById(ctr);
            var ids = $(ctr).data("txt");
            $.ajax({
                url: "AppPortalHandler.ashx",
                data: {
                    "id": ids
                },
                success: function (response) {
                    var data = response.hasOwnProperty('d') ? response.d : response;
                    $(dialog).html(data);
                    $("#dialog").dialog({
                        open: function (event, ui)
                        { $(".ui-dialog-titlebar-close", ui.dialog | ui).hide(); }
                        ,
                        title: "Email Contents",
                        width: "90%",
                        dialogClass: 'ui-dialog-osx',
                        modal: true,
                        buttons: {
                            Close: function () {
                                $(dialog).html("");
                                $(this).dialog('close');

                            }
                        }
                    });
                }
            });
        }


        function resend_email(ctr) {

            var obj = document.getElementById(ctr);
            var ids = $(ctr).data("txt");
            $.ajax({
                url: "AppPortalHandlerResend.ashx",
                data: {
                    "id": ids
                },
                success: function (response) {
                    var data = response.hasOwnProperty('d') ? response.d : response;
                    $("#dialogresent").html(data);
                    $("#dialogresent").dialog({
                        open: function (event, ui)
                        { $(".ui-dialog-titlebar-close", ui.dialog | ui).hide(); }
                        ,
                        title: "Confirmation",
                        width: "20%",
                        dialogClass: 'ui-dialog-osx',
                        modal: true,
                        buttons: {
                            Close: function () {
                                $("#dialogresent").html("");
                                $(this).dialog('close');

                            }
                        }
                    });
                }
            });
        }
    </script>

</asp:Content>





<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="Server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"></ajaxToolkit:ToolkitScriptManager>


    <div id="ChangeCourseModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Change Course</h4>
                </div>
                <div class="modal-body col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lblPassConfirm" CssClass="col-sm-8 control-label" runat="server" Text="Select course to change"></asp:Label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddl_ChangeCourse" CssClass="form-control input-sm"
                                runat="server" DataSourceID="SDS_ListCourses"
                                DataTextField="Course_Title" DataValueField="Course_Id"
                                AutoPostBack="false">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfd_ddl_ChangeCourse" runat="server" ControlToValidate="ddl_ChangeCourse" ValidationGroup="CommentValidation"
                                CssClass="failureNotification" ErrorMessage="Reason is required." ToolTip="Please select a course"><span class="text-danger">* Please select course</span></asp:RequiredFieldValidator>
                        </div>
                    </div>                   
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                    <asp:LinkButton CssClass="btn btn-primary btn-sm" runat="server" ID="btn_SubmitChangeCourse" Text="Submit" OnClick="btn_SubmitChangeCourse_Click" CauseValidation="false" ValidationGroup="CommentValidation" />
                </div>
            </div>

        </div>
    </div>

    <div id="dialog" style="display: none"></div>
    <div id="dialogresent" style="display: none"></div>
    <asp:Panel ID="SearchPanel" runat="server" DefaultButton="btnSearch">
        <div class="panel panel-info">
            <div class="panel-heading">Invite Search</div>
            <div class="panel-body">
                <table class="table table-condensed">
                    <tr>
                        <td>First name</td>
                        <td colspan="1">
                            <asp:TextBox CssClass="form-control input-sm" ID="txtUserId" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox CssClass="form-control input-sm" ID="txtFirstName" runat="server"></asp:TextBox></td>

                        <td>Surname </td>
                        <td colspan="1">
                            <asp:TextBox CssClass="form-control input-sm" ID="txtSurname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>

                        <td colspan="3">
                            <asp:TextBox CssClass="form-control input-sm" ID="txtEmail" Style="text-transform: lowercase" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Course</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddl_Courses" CssClass="form-control input-sm"
                                runat="server" DataSourceID="SDS_ListCourses"
                                DataTextField="Course_Title" DataValueField="Course_Id"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SDS_ListCourses" runat="server"
                                ConnectionString="<%$ ConnectionStrings:DBConnectionOsca %>"
                                SelectCommand="SP_SS_GetListCourses"
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>Activity</td>
                        <td colspan="1">
                            <asp:DropDownList CssClass="form-control input-sm" ID="ddl_Activated" runat="server">
                                <asp:ListItem Selected="True" Value="-1">Any</asp:ListItem>
                                <asp:ListItem Value="1">Logged in</asp:ListItem>
                                <asp:ListItem Value="0">Never logged in</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Enrolled</td>
                        <td colspan="1">
                            <asp:DropDownList CssClass="form-control input-sm" ID="ddl_Enrolled" runat="server">
                                <asp:ListItem Selected="True" Value="-1">Any</asp:ListItem>
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearch" runat="server" Text="Search" />
                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnReset" OnClick="btnReset_Click" runat="server" Text="Reset" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>


    </asp:Panel>
    <msgbx:MyMessageBox ID="MessageBox" runat="server" />

    <div class="panel panel-info">
        <div class="panel-heading">Invites List</div>
        <div class="panel-body">
            <asp:GridView CssClass="table table-condensed table-striped table-bordered table-sm" ID="ListAllLearners" runat="server"
                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID"
                DataSourceID="SDS_AppPortal_GetListInvites"
                ForeColor="#333333" GridLines="None"
                AllowPaging="True" OnSorted="DeselectTheRow" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Id" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="First name" SortExpression="API_FirstName">
                        <ItemTemplate>
                            <asp:Label ID="lbl_API_FirstName" runat="server" Text='<%# Bind("API_FirstName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>




                    <asp:TemplateField Visible="true" HeaderText="Surname" SortExpression="API_LastName">
                        <ItemTemplate>
                            <asp:Label ID="lbl_API_LastName" runat="server" Text='<%# Bind("API_LastName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>


                    <asp:TemplateField Visible="true" HeaderText="Email" SortExpression="API_Email">
                        <ItemTemplate>
                            <asp:Label ID="lbl_API_Email" runat="server" Text='<%# Bind("API_Email") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Course" SortExpression="API_CourseTitle">
                        <ItemTemplate>
                            <asp:Label ID="lbl_API_CourseTitle" runat="server" Text='<%# Bind("API_CourseTitle") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Logged" SortExpression="Activated">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Activated" runat="server" Text='<%# Bind("Activated") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Enroll" SortExpression="Enrolled">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Enrolled" runat="server" Text='<%# Bind("Enrolled") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Sent" SortExpression="dt">
                        <ItemTemplate>
                            <asp:Label ID="lbl_dt" runat="server" Text='<%# Bind("dt") %>'></asp:Label>
                            <asp:Label ID="lbl_dtm" runat="server" Text='<%# Bind("dtm") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField ShowHeader="true" HeaderStyle-Width="35px" ItemStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_ChangeCourse" runat="server" ToolTip="Edit"
                                AlternateText="Edit" CssClass="GridIcon ico-edit"
                                OnClick="btn_ChangeCourse_Click" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="true" HeaderStyle-Width="35px" ItemStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl_email" runat="server" Text='<%# Bind("API_Email") %>' Visible="false"></asp:Label>
                            <%--<img src='../images/mail-icon.png' onclick='open_email(this)' border="0" data-txt='<%# Eval("ID") %>' alt='View email' />--%>
                            <a onclick='open_email(this)' title="View" class="GridIcon ico-view" data-txt='<%# Eval("ID")%>' />

                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField ShowHeader="true" HeaderStyle-Width="30px" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%--<img src='../images/override.jpg' onclick='resend_email(this)' border="0" data-txt='<%# Eval("ID") %>' alt='Resend email' />--%>
                            <a onclick='resend_email(this)' title="Resend" class="GridIcon ico-copy" data-txt='<%# Eval("ID")%>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField ShowHeader="true" HeaderStyle-Width="30px" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_DeleteInvite" runat="server" ToolTip="Delete"
                                AlternateText="Delete this invite" CssClass="GridIcon ico-delete"
                                OnClick="btn_DeleteInvite_Click" />
                            <ajaxToolkit:ConfirmButtonExtender ID="cbeMoveEntry" runat="server"
                                ConfirmOnFormSubmit="true" ConfirmText="Are you sure to delete this invite?"
                                TargetControlID="btn_DeleteInvite">
                            </ajaxToolkit:ConfirmButtonExtender>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

                <PagerStyle CssClass="pagination-ys" />
                <PagerSettings PageButtonCount="20" Position="TopAndBottom" />
            </asp:GridView>


            <asp:SqlDataSource ID="SDS_AppPortal_GetListInvites" runat="server"
                ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                SelectCommand="SP_AppPortal_GetListInvites"
                SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddl_Activated" DefaultValue="-1" Name="IsActivated" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="ddl_Enrolled" DefaultValue="-1" Name="IsEnrolled" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="txtFirstName" DefaultValue="%" Name="Fname" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtSurname" DefaultValue="%" Name="Surname" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtEmail" DefaultValue="%" Name="Email" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="ddl_Courses" DefaultValue="1" Name="Course_Id" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="txtUserId" DefaultValue="-1" Name="UserId" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>



</asp:Content>
