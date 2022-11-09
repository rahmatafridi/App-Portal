<%@ Page Title="Forms Page" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Forms.aspx.cs" Inherits="root_Forms" %>

<%@ Register TagPrefix="atk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">

    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="../../App_Resources/css/modal/basic.css" rel="stylesheet" type="text/css" />

    <link href="../../App_Resources/css/ajax_tabs.css" rel="stylesheet" type="text/css" />
  
    <script type='text/javascript' src='../../App_Resources/js/modal/jquery.simplemodal.js'></script>
    <script type='text/javascript' src='../../App_Resources/js/modal/basic.js'></script>
     
    <script type="text/javascript">


        function OnSuccess(response) {
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
                url: "Forms.aspx/GetApplicationForDisplay",
                data: '{id: "' + sId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {


                    var wnd = window.open("about:blank", "", "_blank");
                    wnd.document.write(data.d);
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
                url: "Forms.aspx/GetApplicationForDisplay",
                data: '{id: "' + sId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var wnd = window.open("about:blank", "", "_blank");
                    wnd.document.write(data.d);
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
            //$(".DatepickerInput").datepicker({
            //    changeMonth: true,
            //    changeYear: true,
            //    dateFormat: 'dd/mm/yy',
            //    yearRange: '-100:+10'

            //}); 



           <%-- $("#<%=btnConfirmEnrolment.ClientID%>").toggle(false);

            $("#<%=chkApp_officeuse1_IsLiteracyNumeracyDone.ClientID%>").click(function () {
                changedcheck(this.checked);
            });
            $("#<%=chkApp_officeuse1_IsAllDocumentsSigned.ClientID%>").click(function () {
                changedcheck(this.checked);
            });
            $("#<%=chkApp_officeuse1_IsConfirmEnrolment.ClientID%>").click(function () {
                changedcheck(this.checked);
            });--%>



        //    ValidatePage();

            //end of ready

        });

        <%--  function changedcheck(state) {
            if ((document.getElementById('<%=chkApp_officeuse1_IsLiteracyNumeracyDone.ClientID%>').checked)
                && (document.getElementById('<%=chkApp_officeuse1_IsAllDocumentsSigned.ClientID%>').checked)
                && (document.getElementById('<%=chkApp_officeuse1_IsConfirmEnrolment.ClientID%>').checked)) {
                $("#<%=btnConfirmEnrolment.ClientID%>").toggle(true);
            } else { $("#<%=btnConfirmEnrolment.ClientID%>").toggle(false); }

        }
        
        <asp:RequiredFieldValidator ID="rfvEnrolmentCourse" runat="server" EnableClientScript="False"
                    ControlToValidate="ddlEnrolmentCourse" ErrorMessage="* Course is required to generate the learner on Portal" class="required-field-indicator" />
                <asp:CustomValidator ID="cvEnrolmentCourse" runat="server" EnableClientScript="True" class="required-field-indicator"
                    ControlToValidate="ddlEnrolmentCourse" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />

        --%>

    </script>


</asp:Content>
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <atk:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />

    <asp:Label ID="lbl_UserId" runat="server" Visible="false"></asp:Label>

    <h4 class="title-regular">Application forms  
        <asp:LinkButton OnClick="btnHomePortal_Click" SkinID="LinkButton" ID="btnHomePortal" Text='Home' runat="server" />
    </h4>
 
    <div class="error_panel required-field-indicator" style="display: none">There are errors on the page, please correct and try again.</div>
    <br />


   <%-- <div class="alert alert-info" role="alert">
        <div class="row">
            <div class="col-md-4 col-sm-4">
                Start a new application  
            </div>
            <div class="col-md-6 col-sm-6">
                <asp:DropDownList ID="ddlEnrolmentCourse" runat="server" class="form-control input-sm" DataTextField="CourseTitle"
                    DataValueField="Course_Id" DataSourceID="SDS_GetCourseList"></asp:DropDownList><asp:SqlDataSource ID="SDS_GetCourseList" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionOsca %>"
                    SelectCommand="SP_GetListQualCourses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>

            <div class="col-md-2 col-sm-2">
                <asp:LinkButton OnClick="btnStart_Click" SkinID="LinkButton" ID="btnStart" Text='Start >>' runat="server" />
            </div>

        </div>
    </div>--%>

    <atk:TabContainer ID="tabs" runat="server" Width="100%" Height="100%" CssClass="ajax__tab_yuitabview-theme">
        <atk:TabPanel ID="tab_progress" runat="server" HeaderText="Submitted">
            <HeaderTemplate>Completed Applications</HeaderTemplate>
            <ContentTemplate>

                <%--**************************************--%>

                <asp:UpdatePanel ID="upnlOutstanding" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        
                        <asp:LinkButton ID="lbRemoveFilterOutstanding" runat="server" Text="Reset Filters"
                            OnClick="lbRemoveFilterOutstanding_Click"></asp:LinkButton>

                        <asp:GridView ID="grdViewApplications" runat="server" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="5"
                            GridLines="Both" AllowPaging="True" CellSpacing="1"
                            PageSize="20" AllowSorting="true" Visible="True"
                            OnPageIndexChanging="grdViewApplications_PageIndexChanging"
                            OnRowDataBound="grdViewApplications_RowDataBound"
                            OnSorting="grdViewApplications_Sorting">

                            <PagerStyle HorizontalAlign="Center" CssClass="pgr" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" />
                            <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                            <FooterStyle CssClass="FooterStyle" />
                            <%--<HeaderStyle CssClass="HeaderStyle" />--%>
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <%--  <SelectedRowStyle CssClass="SelectedRowStyle" />--%>
                            <SortedAscendingHeaderStyle CssClass="sortasc-header" />
                            <SortedDescendingHeaderStyle CssClass="sortdesc-header" />
                            <SortedAscendingCellStyle CssClass="sortasc-row" />
                            <SortedDescendingCellStyle CssClass="sortdesc-row" />
                            <HeaderStyle BackColor="#005f9c" Font-Bold="True" ForeColor="Black" Font-Size="10" />
                            <EmptyDataTemplate>
                                <div class="notice">
                                    No records found.
                                </div>
                            </EmptyDataTemplate>


                            <Columns>


                                <asp:TemplateField HeaderText="Id" Visible="True" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbAppUser_App_Id" runat="server" Text="App Id" CommandName="Sort" CommandArgument="AppUser_App_Id"></asp:LinkButton>
                                        <br />
                                        <asp:DropDownList runat="server" ID="ddlFilterTypeLine">
                                            <asp:ListItem Text="=" Value="=" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                                            <asp:ListItem Text=">=" Value=">="></asp:ListItem>
                                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:TextBox runat="server" ID="txtAppUser_App_Id" AutoPostBack="true" Width="50px"
                                            OnTextChanged="txtApplication_TextChanged" CssClass="upperCaseText"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>


                                        <asp:Label ID="lbl_AppId" Text='<%# Eval("AppUser_App_Id")%>' runat="server" Visible="True"></asp:Label>
                                        <asp:Label ID="lbl_UserId" Text='<%# Eval("AppUser_UserId")%>' runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>


                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="By User" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%">

                                    <ItemTemplate>
                                        <img src="../../App_Resources/images/uploader/Message_Information.png" runat="server" title='<%# Eval("AppUser_CreatedByUser")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbItem" runat="server" Text="Applicant" CommandName="Sort" CommandArgument="applicantname"></asp:LinkButton>
                                        <br />
                                        <asp:TextBox runat="server" ID="txtApplication" CssClass="textEntry" AutoPostBack="true" OnTextChanged="txtApplication_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_applicantname" Text='<%# Eval("applicantname")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>




                                <asp:TemplateField HeaderText="Date" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_CreatedOn" Text='<%# Eval("CreatedOn")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Submitted" Visible="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Submitted" runat="server" Text='<%# Bind("IsSubmitted") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Completed on" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_SumittedDate" runat="server" Text='<%# Bind("SumittedDate") %>'></asp:Label>
                                        <%-- <asp:TextBox Style="text-transform: uppercase"
                            ID="d_complete_date" runat="server" MaxLength="10" ToolTip="Complete Date"
                            Width="70px" CssClass="DatepickerInput"></asp:TextBox>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Rejected?" Visible="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Rejected" runat="server" Text='<%# Bind("IsRejected") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rejected on" Visible="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_RejectedOn" runat="server" Text='<%# Bind("RejectedOn") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:LinkButton SkinID="LinkButton" ID="btnPrintout" OnClientClick="GetApplicationForDisplay(this);" Text='Printout' runat="server" />
                                        <asp:LinkButton OnClick="btn_Edit_Click" SkinID="LinkButton" ID="btn_Edit" Visible="False" Text='Continue/Amend' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" Visible="False" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:LinkButton OnClick="btnReject_Click" SkinID="LinkButton" ID="btn_Reject" Text='Reject' runat="server" />
                                        <asp:LinkButton OnClick="btnDeReject_Click" SkinID="LinkButton" ID="btn_DeReject" Text='DeReject' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="" Visible="False" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:LinkButton OnClick="btnDelete_Click" SkinID="LinkButton" ID="btnDelete" Text='Delete' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Osca Id" Visible="True" ShowHeader="true" HeaderStyle-Width="20px" ItemStyle-Width="40px">
                                    <ItemTemplate>
                                       <asp:Label ID="lbl_osca_id" runat="server" Text='<%# Bind("osca_id") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <%-- <asp:TemplateField SortExpression="Item">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbItem" runat="server" Text="Item" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                        <br />
                                        <asp:TextBox runat="server" ID="txtItem" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Item") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>


                               
                            </Columns>


                            <%--<HeaderStyle  Font-Bold="True" ForeColor="Black" Font-Size="10"/>--%>
                            <%-- <AlternatingRowStyle BackColor="#CCCCCC" />--%>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%--**************************************--%>
                <%--**************************************--%>
                <%--**************************************--%>

                <%-- CssClass="GridView" SkinID="GridView"--%>

               <%-- <asp:SqlDataSource ID="SDS_App_GetUserApplications" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                    SelectCommand="oscauser.SP_App_GetUserApplicationsForAdminForms"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="submitted" Type="Int32" />
                    </SelectParameters>

                </asp:SqlDataSource>
                <asp:GridView ID="grid_userapplications" runat="server" 
                    AutoGenerateColumns="False" Visible="false"
                    OnRowDataBound="grid_userapplications_OnRowDataBound"
                    DataSourceID="SDS_App_GetUserApplications" PageSize="30"
                    Width="100%" EnableModelValidation="True">

                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <FooterStyle CssClass="FooterStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <SortedAscendingHeaderStyle CssClass="sortasc-header" />
                    <SortedDescendingHeaderStyle CssClass="sortdesc-header" />
                    <SortedAscendingCellStyle CssClass="sortasc-row" />
                    <SortedDescendingCellStyle CssClass="sortdesc-row" />
                    <PagerStyle />
                    <EditRowStyle />
                    <EmptyDataRowStyle />
                    <EmptyDataTemplate>
                        <div class="notice">
                            No application recorded.
                        </div>
                    </EmptyDataTemplate>


                    <Columns>


                        <asp:TemplateField HeaderText="Id" Visible="True" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_AppId" Text='<%# Eval("AppUser_App_Id")%>' runat="server" Visible="True"></asp:Label>
                                <asp:Label ID="lbl_UserId" Text='<%# Eval("AppUser_UserId")%>' runat="server" Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="By User" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%">
                            <ItemTemplate>
                                 <img src="../../App_Resources/images/uploader/Message_Information.png" runat="server" title='<%# Eval("AppUser_CreatedByUser")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="applicantname" HeaderText="Name" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_applicantname" Text='<%# Eval("applicantname")%>' runat="server"></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        


                        <asp:TemplateField HeaderText="Date" Visible="True" ItemStyle-Font-Bold="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_CreatedOn" Text='<%# Eval("CreatedOn")%>' runat="server"></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Submitted" Visible="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Submitted" runat="server" Text='<%# Bind("IsSubmitted") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Completed on" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_SumittedDate" runat="server" Text='<%# Bind("SumittedDate") %>'></asp:Label>
                               
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Rejected?" Visible="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Rejected" runat="server" Text='<%# Bind("IsRejected") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rejected on" Visible="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_RejectedOn" runat="server" Text='<%# Bind("RejectedOn") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="" ShowHeader="true"  HeaderStyle-Width="20px" ItemStyle-Width="30%">
                            <ItemTemplate>
                                <asp:LinkButton SkinID="LinkButton" ID="btnPrintout" OnClientClick="GetApplicationForDisplay(this);" Text='Printout' runat="server" />
                                <asp:LinkButton OnClick="btn_Edit_Click" SkinID="LinkButton" Visible="False" ID="btn_Edit" Text='Continue/Amend' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ShowHeader="true" Visible="False" HeaderStyle-Width="20px" ItemStyle-Width="30%">
                            <ItemTemplate>
                                <asp:LinkButton OnClick="btnReject_Click" SkinID="LinkButton" ID="btn_Reject" Text='Reject' runat="server" />
                                <asp:LinkButton OnClick="btnDeReject_Click" SkinID="LinkButton" ID="btn_DeReject" Text='DeReject' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="" ShowHeader="true" Visible="False" HeaderStyle-Width="20px" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:LinkButton OnClick="btnDelete_Click" SkinID="LinkButton" ID="btnDelete" Text='Delete' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>--%>


            </ContentTemplate>

        </atk:TabPanel>



    </atk:TabContainer>












</asp:Content>
