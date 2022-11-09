<%@ Page Title="Manage Applications" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="ManageApplications.aspx.cs" Inherits="root_Default" %>

<%@ Register TagPrefix="atk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    <link rel="Shortcut Icon" href='<%# ResolveUrl ("~/App_Resources/images/favicon.ico") %>' />

    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
    <link href='<%#ResolveUrl("~/App_Resources/jquery-ui-1.11.2.custom/jquery-ui.theme.min.css") %>' rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <link href="../../App_Resources/css/modal/basic.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Resources/css/ajax_tabs.css" rel="stylesheet" type="text/css" />
    <script type='text/javascript' src='../../App_Resources/js/modal/jquery.simplemodal.js'></script>
    <script type='text/javascript' src='../../App_Resources/js/modal/basic.js'></script>
    <script type="text/javascript" src='<%#ResolveUrl("~/App_Resources/bs/js/bootstrap.min.js")%>'></script>
    <link type="text/css" href="../../editors/tinyeditor/tinyeditor.css" rel="stylesheet" />

    <style type="text/css">
        .ContentArea a:hover {
            color: #a94442;
        }
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
            font-size: 13px !important;
            font-family: Calibri, Sans-Serif !important;
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
        $(document).ready(function () {
            $(".DatepickerInput").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                yearRange: '-100:+0'

            });
        });
        function OnSuccess(response) {
            // alert(response.d);
            $.jGrowl(response.d);
        } 

        function OnSuccessTickAll(response) {
            // alert(response.d);
            //  $.jGrowl(response.d);
            //   $.jGrowl('Multiple actions performed');
        }

        function GetApplicationForDisplay(ctrl) {

            var ctlid = ctrl.id;
            var res = ctlid.split("__");
            ctlid = res[1];
            var res2 = ctlid.split("_");
            ctlid = res2[0];
            var sId = ctlid;

            $.ajax({
                type: "POST",
                url: "ManageApplications.aspx/GetApplicationForDisplay",
                data: '{id: "' + sId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    
                    var wnd = window.open("about:blank", "", "_blank");
                    wnd.document.write(data.d);
                    //var text_d = data.d;
                    //text_d = text_d.replace(/"/g, '\'');                    

                    //$("#print_modal_body").html(text_d);
                    //$('#PrintModal').modal();
                    //$("#print_modal_body").html("Hi this is text");
                    //  $('#regTitle').empty().append("HELLLLLLLLLLLL");

                    //$('#popup2').html(data.d);
                    // $('#popup2').html("hello");
                    //// alert($('#popup2').html());
                    // $("#megadiv").html(data.d);
                    // $("#basic-modal-content").fullScreenPopup({
                    //     bgColor: '#fefefe'
                    // });
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        
        function GetApplicationForDisplay2(ctr) {
            var obj = document.getElementById(ctr);
            var sId = $(ctr).data("txt");
            $.ajax({
                type: "POST",
                url: "ManageApplications.aspx/GetApplicationForDisplay",
                data: '{id: "' + sId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var wnd = window.open("about:blank", "", "_blank");
                    wnd.document.write(data.d);
                    //$("#print_modal_body").html(data.d);
                    //$('#PrintModal').modal();
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

        }

    </script>

    <script type="text/javascript">

        /*
     *  jQuery fullscreen popup - v0.0.1
     *  Simple fullscreen popup plugin
     *  https://github.com/nurislamov/jquery-fullscreen-popup
     *
     *  Made by Timur Nurislamov
     *  Under MIT License
     */
        (function () {
            var __bind = function (fn, me) { return function () { return fn.apply(me, arguments); }; };

            (function ($) {
                var FSP, defaults, pluginName;
                pluginName = "fullScreenPopup";
                defaults = {
                    bgColor: "#fff",
                    inlineStyles: true,
                    lockDocumentScroll: true,
                    mainWrapperClass: "fsp-wrapper",
                    contentWrapperClass: "fsp-content",
                    closePopupClass: "fsp-close",
                    animationSpeed: 200
                };
                FSP = (function () {
                    function FSP(element, options) {
                        this.element = element;
                        this.closePopup = __bind(this.closePopup, this);
                        this.init = __bind(this.init, this);
                        this.options = $.extend({}, defaults, options);
                        this._defaults = defaults;
                        this._name = pluginName;
                        this.element = $(this.element);
                        this.body = $("body");
                        this.element.on("click", this.init);
                    }

                    FSP.prototype.init = function (event) {
                        event.preventDefault();
                        this.getTarget();
                        this.getTargetSizes();
                        this.createWrappers();
                        this.wrapTarget();
                        if (this.options.lockDocumentScroll) {
                            this.lockDocumentScroll();
                        }
                        this.render();
                        return this.bindEvents();
                    };

                    FSP.prototype.getTarget = function () {
                        this.target = $(this.element.attr("href") || this.element.data("popup"));
                        return this.targetParent = this.target.parent();
                    };

                    FSP.prototype.getTargetSizes = function () {
                        return this.targetSizes = {
                            width: this.target.width(),
                            height: this.target.height()
                        };
                    };

                    FSP.prototype.wrapTarget = function () {
                        this.target = this.detachFromDom(this.target);
                        return this.target.appendTo(this.contentWrapper);
                    };

                    FSP.prototype.render = function () {
                        this.target.show();
                        this.attachToDom(this.mainWrapper, "body");
                        this.popupCentered();
                        return this.mainWrapper.fadeIn(this.options.animationSpeed);
                    };

                    FSP.prototype.detachFromDom = function (element) {
                        return element.detach();
                    };

                    FSP.prototype.attachToDom = function (element, target) {
                        return element.appendTo(target);
                    };

                    FSP.prototype.bindEvents = function () {
                        return this.close.on("click", this.closePopup);
                    };

                    FSP.prototype.createWrappers = function () {
                        this.mainWrapper = $("<div/>", {
                            "class": "" + this.options.mainWrapperClass,
                            "style": this.options.inlineStyles ? "background: " + this.options.bgColor + "; position: fixed; top: 0; left: 0; right: 0; bottom: 0; z-index: 9999; overflow-y: auto; overflow-x: hidden; display: none" : void 0
                        });
                        this.contentWrapper = $("<div/>", {
                            "class": "" + this.options.contentWrapperClass,
                            "style": "width: " + this.targetSizes.width + "px; height: " + this.targetSizes.height + "px;  position: absolute; top: 50%; left: 50%; margin-left: -" + (this.targetSizes.width / 2) + "px; margin-top: -" + (this.targetSizes.height / 2) + "px"
                        }).appendTo(this.mainWrapper);
                        return this.close = $("<a/>", {
                            href: "#",
                            html: "&times;",
                            "class": "" + this.options.closePopupClass,
                            "style": this.options.inlineStyles ? "position: absolute; right: 2em; top: 2em;" : void 0
                        }).appendTo(this.mainWrapper);
                    };

                    FSP.prototype.popupCentered = function () { };

                    FSP.prototype.closePopup = function (event) {
                        var self;
                        event.preventDefault();
                        self = this;
                        return this.mainWrapper.fadeOut(this.options.animationSpeed, function () {
                            if (self.options.lockDocumentScroll) {
                                self.unlockDocumentScroll();
                            }
                            self.target = self.detachFromDom(self.target);
                            self.target.hide();
                            self.attachToDom(self.target, self.targetParent);
                            return self.deleteWrappers();
                        });
                    };

                    FSP.prototype.deleteWrappers = function () {
                        return this.mainWrapper.remove();
                    };

                    FSP.prototype.lockDocumentScroll = function () {
                        return this.body.css({
                            "overflow": "hidden"
                        });
                    };

                    FSP.prototype.unlockDocumentScroll = function () {
                        return this.body.css({
                            "overflow": "visible"
                        });
                    };

                    return FSP;

                })();
                return $.fn[pluginName] = function (options) {
                    return this.each(function () {
                        if (!$.data(this, "plugin_" + pluginName)) {
                            return $.data(this, "plugin_" + pluginName, new FSP(this, options));
                        }
                    });
                };
            })(jQuery);

        }).call(this);
    </script>

    <script type="text/javascript">
        $(function () {
            $(".open-popup").fullScreenPopup({
                bgColor: '#fefefe'
            });
        });
    </script>


    <script type="text/javascript">

        var bAnyErrors = false;
        function ValidatePage() {
            if (typeof (Page_ClientValidate) == 'validateSelect') {
                Page_ClientValidate();
            }
            // if (Page_IsValid) { bAnyErrors = false; }
            showErrorPanel(Page_IsValid);
        }
        function validateSelect(oSrc, args) {
            args.IsValid = (args.Value != 0);
            if (!args.IsValid)
            { bAnyErrors = true; }
            showErrorPanel(args.IsValid);
        }

        function showErrorPanel(state) {

            if (!state || bAnyErrors) {

                $(".error_panel").show();

            } else {
                $(".error_panel").hide();

            }

        }

        $(document).ready(function () {

        });
    </script>


</asp:Content>
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <atk:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true"></atk:ToolkitScriptManager>

    <asp:Label ID="lbl_UserId" runat="server" Visible="false"></asp:Label>
     
    <div class="error_panel required-field-indicator" style="display: none">There are errors on the page, please correct and try again.</div>
    <br />


    <div class="alert alert-info" role="alert">
        <div class="row">
            <div class="col-md-4 col-sm-4">
                Start a new application  
            </div>
            <div class="col-md-6 col-sm-6">
                <asp:DropDownList ID="ddlEnrolmentCourse" runat="server" class="form-control input-sm" DataTextField="CourseTitle"
                    DataValueField="Course_Id" DataSourceID="SDS_GetCourseList">
                </asp:DropDownList><asp:SqlDataSource ID="SDS_GetCourseList" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionOsca %>"
                    SelectCommand="SP_GetListQualCourses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>  

            <div class="col-md-2 col-sm-2">
                <asp:LinkButton OnClick="btnStart_Click" CssClass ="btn btn-primary btn-sm"  ID="btnStart" Text='Start >>' runat="server" CausesValidation="False" />
            </div>

        </div>
    </div>
    <asp:Panel ID="SearchPanel" runat="server" DefaultButton="btnSearch">
        <div class="panel panel-info">
            <div class="panel-heading">Application Search</div>
            <div class="panel-body">
                <table class="table table-condensed">
                    <tr>
                        <td width="15%">Id</td>
                        <td width="35%">
                            <asp:TextBox CssClass="form-control input-sm" ID="txtInviteId" runat="server"></asp:TextBox></td>

                        <td width="15%">Email </td>
                        <td width="35%">
                            <asp:TextBox CssClass="form-control input-sm" ID="txtEmail" AutoCompleteType="Email" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>First Name</td>
                        <td>
                            <asp:TextBox CssClass="form-control input-sm" ID="txtUserId" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox CssClass="form-control input-sm" ID="txtFirstName" runat="server"></asp:TextBox></td>

                        <td>Surname </td>
                        <td>
                            <asp:TextBox CssClass="form-control input-sm" ID="txtSurname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Status</td>
                        <td>
                            <asp:DropDownList CssClass="form-control input-sm" ID="ddl_Type" runat="server">
                                <asp:ListItem Selected="True" Value="Submitted">Submitted / In Progress</asp:ListItem>
                                <asp:ListItem Value="NotSubmitted">Not Submitted</asp:ListItem>
                                <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                <asp:ListItem Value="Deleted">Deleted</asp:ListItem>
                                <asp:ListItem Value="Enrolled">Enrolled</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Course</td>
                        <td>
                            <asp:DropDownList ID="ddlCourseFilter" CssClass="form-control input-sm"
                                runat="server" DataSourceID="SDS_ListCourses"
                                DataTextField="Course_Title" DataValueField="Course_Id"
                                AutoPostBack="false">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SDS_ListCourses" runat="server"
                                ConnectionString="<%$ ConnectionStrings:DBConnectionOsca %>"
                                SelectCommand="SP_SS_GetListCourses"
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </td>
                    </tr>
                     <tr>
                        <td>From Date</td>
                        <td>
                            <asp:TextBox ID="txtFromDateStr" runat="server" CssClass="DatepickerInput form-control input-sm" />                            
                        </td>

                        <td>To Date</td>
                        <td>
                            <asp:TextBox CssClass="form-control input-sm DatepickerInput" ID="txtToDateString" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearch" runat="server" CausesValidation="False" Text="Search" />
                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnReset" OnClick="btnReset_Click" CausesValidation="False" runat="server" Text="Reset" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>

    <div class="panel panel-info">

        <!-- Modal -->
        <div id="ReasonModal" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Reason</h4>
                    </div>
                    <div class="modal-body col-md-12">
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:Label ID="lblReason" CssClass="col-form-label" Text='' runat="server" Visible="True"></asp:Label>
                                <div>
                                    <asp:TextBox ID="txtReason" runat="server" Visible="true" Rows="4" TextMode="MultiLine" class="form-control" placeholder="Please type reason..."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Reason" runat="server" ControlToValidate="txtReason" ValidationGroup="ReasonValidate"
                                        CssClass="failureNotification" ErrorMessage="Reason is required." ToolTip="Reason is required."><span class="text-danger">* Reason is required</span></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                        <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="btn_RejectWithReason" Text="Submit" OnClick="btn_RejectWithReason_Click" CauseValidation="True" ValidationGroup="ReasonValidate"/>
                        <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="btn_DeleteWithReason" Text="Submit" OnClick="btn_DeleteWithReason_Click" CauseValidation="True" ValidationGroup="ReasonValidate"/>
                    </div>
                </div>

            </div>
        </div>

        <div id="CommentModal" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Comment</h4>
                    </div>
                    <div class="modal-body col-md-12">
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:Label ID="Label1" CssClass="col-form-label" Text='' runat="server" Visible="True"></asp:Label>
                                <div>
                                    <asp:TextBox ID="txtComment" runat="server" Visible="true" Rows="4" TextMode="MultiLine" class="form-control" placeholder="Please type your comment..."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfd_txtComment" runat="server" ControlToValidate="txtComment" ValidationGroup="CommentValidation"
                                        CssClass="failureNotification" ErrorMessage="Reason is required." ToolTip="Reason is required."><span class="text-danger">* Reason is required</span></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                        <asp:LinkButton CssClass="btn btn-primary btn-sm" runat="server" ID="btn_SubmitComment" Text="Submit" OnClick="btn_SubmitComment_Click" CauseValidation="false" ValidationGroup="CommentValidation" />
                    </div>
                </div>

            </div>
        </div>

        <div id="PrintModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">

                <!-- Modal content-->
                <div class="modal-content">
                   <%-- <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Comment</h4>
                    </div>--%>
                    <div class="modal-body col-md-12">
                        <div id="print_modal_body">

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>                        
                    </div>
                </div>

            </div>
        </div>

        <div class="panel-heading">Applications List</div>
        <div class="panel-body">
            <asp:GridView CssClass="table table-condensed table-striped table-bordered table-sm" ID="grid_AllUserApplications" runat="server"
                AllowSorting="True" AutoGenerateColumns="False"
                OnRowDataBound="grid_AllUserApplications_RowDataBound"
                DataSourceID="ODS_App_GetUserApplicationsByFilterAndPaging"
                EnableModelValidation="True"
                ForeColor="#333333" GridLines="None"
                AllowPaging="True" PageSize="20">
                <EmptyDataTemplate>
                    <div class="notice">
                        No application recorded.
                    </div>
                </EmptyDataTemplate>
                <Columns>


                    <asp:TemplateField SortExpression="App_Id" HeaderText="Id" Visible="True" HeaderStyle-Width="8px" ItemStyle-Width="8px">
                        <ItemTemplate>
                            <asp:Label ID="lbl_AppId" Text='<%# Bind("AppUser_App_Id")%>' runat="server" Visible="True"></asp:Label>
                            <asp:Label ID="lbl_UserId" Text='<%# Bind("AppUser_UserId")%>' runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lbl_ApplicantEmail" Text='<%# Bind("App_Email")%>' runat="server" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="CreatedByUser" HeaderText="By User" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <img id="img_UserName" src="../../App_Resources/images/uploader/Message_Information.png" runat="server" title='<%# Eval("AppUser_CreatedByUser")%>' />
                            <asp:Label ID="lbl_Username" Text='<%# Eval("AppUser_CreatedByUser")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="applicantname" HeaderText="Name" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_applicantname" Text='<%# Eval("applicantname")%>' runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField SortExpression="CreatedDate" HeaderText="Date" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_CreatedOn" Text='<%# Eval("CreatedOn")%>' runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Submitted" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Submitted" runat="server" Text='<%# Bind("IsSubmitted") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField SortExpression="SumittedDate" HeaderText="Submitted on/Completed" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_SumittedDate" runat="server" Text='<%# Bind("SumittedDate") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Rejected?" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Rejected" runat="server" Text='<%# Bind("IsRejected") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField SortExpression="RejectedDate" HeaderText="Rejected on" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lbl_RejectedOn" runat="server" Text='<%# Bind("RejectedOn") %>'></asp:Label><br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Deleted?" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Deleted" runat="server" Text='<%# Bind("IsDeleted") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField SortExpression="DeletedDate"  HeaderText="Deleted on" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lbl_DeletedOn" runat="server" Text='<%# Bind("DeletedOn") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="18%" ItemStyle-Width="18%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_deletedReason" runat="server" Text='<%# Bind("AppUser_DeletedReason") %>'></asp:Label>
                            <asp:Label ID="lbl_rejectedReason" runat="server" Text='<%# Bind("AppUser_RejectedReason") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="LearnerId" HeaderText="Learner Id" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_LearnerId" Text='<%# Eval("LearnerId")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="EnrolledDate" HeaderText="Enrolled on" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_EnrolledDate" runat="server" Text='<%# Bind("EnrolledDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="45px" ItemStyle-Width="45px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div style="font-size: medium !important;">

                                <asp:LinkButton SkinID="LinkButton" ID="btnPrintout" CssClass="glyphicon glyphicon-print" OnClientClick="GetApplicationForDisplay(this); return false;" CausesValidation="False" ToolTip="Print" Text='' runat="server" OnClick="btnPrintout_Click"/>
                                <asp:LinkButton OnClick="btn_Edit_Click" SkinID="LinkButton" CssClass="glyphicon glyphicon-edit glyphicon-th-large " CausesValidation="False" ID="btn_Edit" Text='' ToolTip="Continue/Amend" runat="server" />
                            </div>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="45px" ItemStyle-Width="45px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl_ReadyToEnrollByUser" runat="server" Text='<%# Bind("appUser_ReadyToEnrollByUser") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lbl_IsReadyToEnroll" runat="server" Text='<%# Bind("IsReadyToEnroll") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lbl_IsAmended" runat="server" Text='<%# Bind("IsAmended") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lbl_RTE_Comment" runat="server" Text='<%# Bind("RTE_Comment") %>' Visible="false"></asp:Label>
                            <div style="font-size: medium !important;">
                                <asp:LinkButton SkinID="LinkButton" ID="btn_Notify" OnClick="btn_Notify_Click" CssClass="glyphicon glyphicon-envelope" CausesValidation="False" ToolTip="Notify for changes" Text='' runat="server" />
                                <asp:Label ID="lbl_YesReadyToEnrolled" runat="server" CssClass="glyphicon glyphicon-ok-circle" ForeColor="Green" Text='' ToolTip="test tip"></asp:Label>
                                <asp:LinkButton SkinID="LinkButton" ID="btn_ReadyToEnroll" OnClick="btn_ReadyToEnroll_Click" CssClass="glyphicon glyphicon-user" CausesValidation="False" ToolTip="Ready To Enroll" Text='' runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div style="font-size: medium !important;">
                                <asp:LinkButton SkinID="LinkButton" ID="btn_Reject" OnClick="btn_RejectNew_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" Text='' ToolTip="Reject" runat="server" />
                                <%--<asp:LinkButton OnClick="btnReject_Click1" SkinID="LinkButton" ID="btn_Reject" CausesValidation="False" CssClass="glyphicon glyphicon-remove" Text='' ToolTip="Reject" runat="server" />--%>
                                <asp:LinkButton OnClick="btnDeReject_Click" SkinID="LinkButton" ID="btn_DeReject" CausesValidation="False" CssClass="glyphicon glyphicon-repeat" Text='' ToolTip="DeReject" runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div style="font-size: medium !important;">
                                <asp:LinkButton OnClick="btn_DeleteNew_Click" SkinID="LinkButton" ID="btnDelete" CssClass="glyphicon glyphicon-trash" CausesValidation="False" Text='' ToolTip="Delete" runat="server" />                                
                                <%--<asp:LinkButton OnClick="btnDelete_Click" SkinID="LinkButton" ID="btnDelete" CssClass="glyphicon glyphicon-trash" CausesValidation="False" Text='' ToolTip="Delete" runat="server" />--%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div style="font-size: medium !important;">
                                <asp:LinkButton OnClick="btnRecover_Click" SkinID="LinkButton" CssClass="glyphicon glyphicon-refresh" CausesValidation="False" ID="btnRecover" Text='' ToolTip="Recover" runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="SalesAdvisorName" HeaderText="Sales Adv" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="11%" ItemStyle-Width="11%">
                        <ItemTemplate>
                            <img id="img_SalesAdvName" src="../../App_Resources/images/uploader/Message_Information.png" runat="server" title='<%# Eval("SalesAdvisorName")%>' />
                            <asp:Label ID="lbl_SalesAdvName" runat="server" Text='<%# Bind("SalesAdvisorName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

                <PagerStyle CssClass="pagination-ys" />
                <PagerSettings PageButtonCount="20" Position="TopAndBottom" />
            </asp:GridView>

        </div>
        <asp:ObjectDataSource ID="ODS_App_GetUserApplicationsByFilterAndPaging" runat="server" SortParameterName="sortColumnName"
            SelectCountMethod="GetTotalCount"
            EnablePaging="True" SelectMethod="GetApplicationsWithPaging" TypeName="DSP.BAL.DBL">
            <SelectParameters>
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:ControlParameter PropertyName="SelectedValue" ControlID="ddl_Type" Name="type" DefaultValue="Submitted" Type="String" />
                <asp:ControlParameter ControlID="txtUserId" DefaultValue="0" Name="userId" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="txtFirstName" DefaultValue=" " Name="firstName" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtSurname" DefaultValue=" " Name="surName" PropertyName="Text" Type="String" />
                <asp:ControlParameter PropertyName="SelectedValue" ControlID="ddlCourseFilter" Name="courseId" DefaultValue="-1" Type="Int32" />
                <asp:ControlParameter ControlID="txtEmail" DefaultValue=" " Name="email" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtInviteId" DefaultValue="0" Name="inviteId" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="txtFromDateStr" DefaultValue=" " Name="fromDateStr" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtToDateString" DefaultValue=" " Name="toDateStr" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </div>
</asp:Content>
