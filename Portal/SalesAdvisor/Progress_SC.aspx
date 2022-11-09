<%@ Page Title="Application progress" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Progress_SC.aspx.cs" Culture="en-GB" Inherits="SalesAdvisor_Progress_SC" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/App_Resources/css/wizardsteps.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript" src="/App_Resources/js/signpad/signature_pad.min.js"></script>


    <link href="/App_Resources/css/collapsediv.css" rel="stylesheet" type="text/css" />
    <%--file uploading--%>
    <%--  <script src="/App_Resources/js/fileupload/jquery.ui.widget.js" type="text/javascript"></script>   --%>
    <script src="/App_Resources/js/fileupload/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="/App_Resources/js/fileupload/jquery.fileupload.js" type="text/javascript"></script>
    <%--  <script src="/App_Resources/js/fileupload/upload.js" type="text/javascript"></script>--%>

    <style>
        .top-buffer {
            margin-top: 20px;
        }
    </style>



    <%--Signature pad--%>
    <script type="text/javascript">
        $(document).ready(function () {
            //var xsign = document.getElementById('signature-pad');
            //if ( xsign != null)
            // {
            /* var signaturePad = new SignaturePad(document.getElementById('signature-pad'), {
                 backgroundColor: 'rgba(150,150,150,0.1)',
                 penColor: 'rgb(0, 0, 0)'
             });*/
            //}
            //$("#btnClear").click(function() {
            //     signaturePad.clear();			
            //});

            $("#BodyContent_Wizard1_chk_mktg_ContactConsent").click(function () {
                var byes = document.getElementById("BodyContent_Wizard1_chk_mktg_ContactConsent").checked
                var bno = document.getElementById("BodyContent_Wizard1_chk_mktg_ContactConsentNo").checked;
                if (byes && bno) {
                    $("#BodyContent_Wizard1_chk_mktg_ContactConsent").prop('checked', true);
                    $("#BodyContent_Wizard1_chk_mktg_ContactConsentNo").prop('checked', false);

                }

            });
            $("#BodyContent_Wizard1_chk_mktg_ContactConsentNo").click(function () {
                var byes = document.getElementById("BodyContent_Wizard1_chk_mktg_ContactConsent").checked
                var bno = document.getElementById("BodyContent_Wizard1_chk_mktg_ContactConsentNo").checked;
                if (byes && bno) {
                    $("#BodyContent_Wizard1_chk_mktg_ContactConsent").prop('checked', false);
                    $("#BodyContent_Wizard1_chk_mktg_ContactConsentNo").prop('checked', true);

                }
            });
            /********************************************************************************/
            /* newx switching signature and print name
            */

            /********************************************************************************/

            /********************************************************************************/

            $("#btnClearPrintName").click(function () {
                //var btnClearPrint = document.getElementById('txtPrintName');
                $("#BodyContent_Wizard1_txtPrintName").val("");

                var canvas = document.getElementById('signature-pad'),
                    context = canvas.getContext('2d');
                context.clearRect(0, 0, canvas.width, canvas.height);

            });

            $("#BodyContent_Wizard1_txtPrintName").keyup(function (event) {
                var stt = $(this).val();
                var lng = stt.length;
                var fnt = 30;
                //max 20!
                if (lng < 20) { fnt = 30; }
                else if (lng < 30) { fnt = 20; }
                else { fnt = 15; }

                var canvas = document.getElementById('signature-pad');
                var context = canvas.getContext('2d');
                context.clearRect(0, 0, canvas.width, canvas.height);
                var fntsize = fnt + 'pt';
                context.font = 'italic ' + fntsize + ' Sacramento, cursive ';
                context.fillText(stt, 50, 60);
            });

            /********************************************************************************/



            $("#BodyContent_Wizard1_FinishNavigationTemplateContainerID_FinishButton").click(function () {
                var byes = document.getElementById("BodyContent_Wizard1_chk_mktg_ContactConsent").checked
                var bno = document.getElementById("BodyContent_Wizard1_chk_mktg_ContactConsentNo").checked;
                if (byes == false && bno == false) {
                    alert("Please tick yes or no if you wish to be contacted.");

                } else {

                    var printnamecontrol = $("#<%=txtPrintName.ClientID%>");
                    var appli_date = $("#<%=txtApplicationDate.ClientID%>");
                    if (printnamecontrol.val().length < 5) {
                        alert("Please type your full name.");

                    } else {


                        var canvas = document.getElementById('signature-pad');
                        var context = canvas.getContext('2d');
                        var dataUri = canvas.toDataURL("image/png").replace("image/png", "image/octet-stream");  // here is the most important part because if you dont replace you will get a DOM 18 exception.

                        //var data = signaturePad.toDataURL('image/png');
                        // var dataUri = signaturePad.toDataURL();
                        $("#sketch_data").val(dataUri);
                        var hiddencontrol = $("#<%=sketch_data_label.ClientID%>");
                        $(hiddencontrol).val(dataUri);

                        $("#hid_printname").val(printnamecontrol.val());
                        var hiddencontrol2 = $("#<%=hid_printname_label.ClientID%>");
                        $(hiddencontrol2).val($("#hid_printname").val());

                        $("#hid_dt").val(appli_date.val());
                        var hiddencontrol3 = $("#<%=hid_dt_label.ClientID%>");
                        $(hiddencontrol3).val(appli_date.val());

                        <%--if (data.length < 4000) {
                                $("#sketch_data").val("");
                                var hiddencontrol = $("#<%=sketch_data_label.ClientID%>");
                                $(hiddencontrol).val("");

                                alert("Please type your full name.");

                            } else {--%>





                        // } 

                    }//endif btnSignPadSignature






                }



            });
        });

    </script>
    <script type="text/javascript">

        var bAnyErrors = false;

        function ValidatePage() {
            if (typeof (Page_ClientValidate) == 'validateSelect') {
                Page_ClientValidate();
            }
            if (Page_IsValid != "undefined") showErrorPanel(Page_IsValid);
        }

        function validateSelect(oSrc, args) {
            args.IsValid = (args.Value != 0);

           
            if (!args.IsValid) {
                //  alert(oSrc.controltovalidate);
                bAnyErrors = true;
            }
            //else
            //{ bAnyErrors = false; }            
            //if (args.IsValid) { bAnyErrors = false; }
            showErrorPanel(args.IsValid);
        }

        function validateText(oSrc, args) {

            args.IsValid = (args.Value != "");

            showErrorPanel(args.IsValid);
        }

        function showErrorPanel(state) {
            if (!state || bAnyErrors) {
                $(".error_panel").show();
            } else {
                $(".error_panel").hide();
            }
        }

        $(function () {
            $("#accordion").accordion({
                collapsible: true,
                heightStyle: "content"
            });

            $("#accordion_privacy").accordion({ header: "h3", collapsible: true, heightStyle: "content", active: false });
        });

        <%  if (_App != null)
        {
            COURSE_LEVEL = (DSP.BAL.CourseLevel)Enum.ToObject(typeof(DSP.BAL.CourseLevel), _App._app_officeuse1_CourseLevel);
            COURSE_LEVEL_NUMER = _App._app_officeuse1_CourseLevel;
        }
        var course_lvl = COURSE_LEVEL_NUMER;
                %>
        var course_level =<%=course_lvl%> ;

        $(document).ready(function () {
            $(".DatepickerInput").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                yearRange: '-100:+0'

            });
            var date = new Date();
            date.setFullYear(date.getFullYear() - 15)
            $("#<%=txtDOB.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                yearRange: '-100:+0',
                maxDate: date

            });
            $(".CollapseHeader").click(function () {

                $header = $(this);
                $titled = $(this).attr('tooltip');
                //getting the next element
                $content = $header.next();
                //open up the content needed - toggle the slide- if visible, slide up, if not slidedown.
                $content.slideToggle(500, function () {
                    //execute this after slideToggle is done
                    //change text of header based on visibility of content div
                    $header.text(function () {
                        //change text based on condition
                        return $content.is(":visible") ? $titled + " (Click to Collapse) " : $titled + " (Click to Expand)";
                    });
                });

            });

            $(".CollapseHeaderFinal").click(function () {

                $header = $(this);
                $titled = $(this).attr('tooltip');
                //getting the next element
                $content = $header.next();
                //open up the content needed - toggle the slide- if visible, slide up, if not slidedown.
                $content.slideToggle(500, function () {
                    //execute this after slideToggle is done
                    //change text of header based on visibility of content div
                    $header.text(function () {
                        //change text based on condition
                        return $content.is(":visible") ? $titled + " (Click to close) " : $titled + " (Click to open)";
                    });
                });

            });


            $("#<%=btnConfirmEnrolment.ClientID%>").toggle(false);

            $("#<%=chkApp_officeuse1_IsLiteracyNumeracyDone.ClientID%>").click(function () {
                changedcheck(this.checked);
            });
            $("#<%=chkApp_officeuse1_IsAllDocumentsSigned.ClientID%>").click(function () {
                changedcheck(this.checked);
            });
            $("#<%=chkApp_officeuse1_IsConfirmEnrolment.ClientID%>").click(function () {
                changedcheck(this.checked);
            });

            ConfigureValidators();

            switch (course_level) {
                case 3:
                    $("#BodyContent_Wizard1_pLevel3").show();
                    $("#BodyContent_Wizard1_pLevel4").hide();
                    $("#BodyContent_Wizard1_pLevel5").hide();
                    $("#BodyContent_Wizard1_pLevel3a").show();
                    $("#BodyContent_Wizard1_pLevel4a").hide();
                    $("#BodyContent_Wizard1_pLevel5a").hide();
                    break;
                case 4:
                    $("#BodyContent_Wizard1_pLevel3").hide();
                    $("#BodyContent_Wizard1_pLevel4").show();
                    $("#BodyContent_Wizard1_pLevel5").hide();
                    $("#BodyContent_Wizard1_pLevel3a").hide();
                    $("#BodyContent_Wizard1_pLevel4a").show();
                    $("#BodyContent_Wizard1_pLevel5a").hide();
                    break;
                case 5:
                    $("#BodyContent_Wizard1_pLevel3").hide();
                    $("#BodyContent_Wizard1_pLevel4").hide();
                    $("#BodyContent_Wizard1_pLevel5").show();
                    $("#BodyContent_Wizard1_pLevel3a").hide();
                    $("#BodyContent_Wizard1_pLevel4a").hide();
                    $("#BodyContent_Wizard1_pLevel5a").show();
                    break;
                default:
                    $("#BodyContent_Wizard1_pLevel3").hide();
                    $("#BodyContent_Wizard1_pLevel4").hide();
                    $("#BodyContent_Wizard1_pLevel5").show();
                    $("#BodyContent_Wizard1_pLevel3a").hide();
                    $("#BodyContent_Wizard1_pLevel4a").hide();
                    $("#BodyContent_Wizard1_pLevel5a").show();
                    break;

            }

            ValidatePage();

        });
        function ConfigureValidators() {
            if (typeof Page_Validators != 'undefined') {
                for (i = 0; i <= Page_Validators.length; i++) {
                    if (Page_Validators[i] != null) {
                        var visible = $('#' + Page_Validators[i].controltovalidate).parent().is(':visible');
                        Page_Validators[i].enabled = visible;
                    }
                }
            };
        }

        function changedcheck(state) {
            if ((document.getElementById('<%=chkApp_officeuse1_IsLiteracyNumeracyDone.ClientID%>').checked)
                && (document.getElementById('<%=chkApp_officeuse1_IsAllDocumentsSigned.ClientID%>').checked)
                && (document.getElementById('<%=chkApp_officeuse1_IsConfirmEnrolment.ClientID%>').checked)) {
                $("#<%=btnConfirmEnrolment.ClientID%>").toggle(true);
            } else { $("#<%=btnConfirmEnrolment.ClientID%>").toggle(false); }

        }

        function ControlEnable(obj, state) {
            if (state) {
                $(obj).attr('disabled', false);
            } else {
                $(obj).attr('disabled', true);
            }
        }

    </script>

    <style type="text/css">
        .signature_wrapper {
            background-color: #808080;
            width: 520px;
            height: 120px;
        }

        .wrapper {
            background-color: #ffffff;
            position: relative;
            width: 500px;
            height: 100px;
            -moz-user-select: none;
            -webkit-user-select: none;
            -ms-user-select: none;
            user-select: none;
            left: 10px;
            top: 10px;
        }

        img {
            position: absolute;
            left: 0;
            top: 0;
        }

        .signature-pad {
            position: absolute;
            left: 0;
            top: 0;
            width: 400px;
            height: 100px;
        }
    </style>

    <%--uploading file--%>
    <style>
        #progressbar {
            background-color: skyblue;
            background-repeat: repeat-x;
            border-radius: 5px; /* (height of inner div) / 2 + padding */
            padding: 3px;
        }

            #progressbar > div {
                background-color: lightskyblue;
                width: 0%; /* Adjust with JavaScript */
                height: 20px;
                border-radius: 5px;
            }
    </style>

</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <%
        if (_App != null)
        {
            COURSE_LEVEL = (DSP.BAL.CourseLevel)Enum.ToObject(typeof(DSP.BAL.CourseLevel), _App._app_officeuse1_CourseLevel);

        }
    %>

    <asp:Label ID="lblError" runat="server" CssClass="error_panel required-field-indicator" Visible="false">There are errors on the page, please contact administrator of the site.</asp:Label>
    <div class="error_panel required-field-indicator" style="display: none">There are errors on the page, please correct and try again.</div>

    <h4 class="title-regular">Manual Process
        <asp:LinkButton OnClick="btnHomePortal_Click" SkinID="LinkButton" ID="btnHomePortal" Text='Home' runat="server" ValidationGroup="none" />
    </h4>
    <br />

    <div class="CollapseContainer">
        <div class="CollapseHeader form-horizontal well" tooltip="Office Use Only - Extra Fields">
            Office Use Only - Extra Fields <span>(Click to Expand)</span>

        </div>
        <div class="CollapseContent">
            <div class="form-horizontal">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="well">
                            <fieldset>
                                <legend>Learner</legend>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Unique Learner Number</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_UniqueLearnerReference" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Start Date</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_StartDate" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">End Date</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_EndDate" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Apprenticeship Framework</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_ApprenticeshipFramework" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Learner ID</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_LearnerId" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>



                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">CQC inspection Date</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_CQCInspectionDate" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">UKPRN</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_UKPRN" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Employer ID</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_EmployerId" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>







                            </fieldset>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="well">
                            <fieldset>
                                <legend>Proof of ID</legend>


                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">ID Reference</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_ReferenceId" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Evidence Seen</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:CheckBox runat="server" class="form-control input-sm" ID="txtApp_officeuse_IsEvidenceSeen" AutoPostBack="false" />



                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">ID Type</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_ReferenceIdType" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </div>



                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Reference Date</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:TextBox ValidationGroup="none" ID="txtApp_officeuse_ReferenceDate" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
                                        </div>
                                    </div>
                                </div>

                            </fieldset>

                            <fieldset>
                                <legend>Course Funding</legend>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Funding</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:DropDownList ID="ddl_office_funding" runat="server" class="form-control input-sm">
                                                <asp:ListItem Enabled="true" Text="Full Cost" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Advanced Learner Loan" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Funded" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>

                            </fieldset>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="well">
                            <asp:LinkButton OnClick="btnSaveOfficeUse_Click" SkinID="LinkButton" ID="btnSaveOfficeUse" Text='Save' runat="server" ValidationGroup="none" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <asp:Panel ID="pnl_confirmEnrolment" Visible="false" runat="server">

        <div class="CollapseContainer">
            <div class="CollapseHeader form-horizontal well" tooltip="Office Use Only - Enrolment Confirmation">
                Office Use Only - Enrolment Confirmation<span>(Click to Expand)</span>

            </div>
            <div class="CollapseContent">
                <div class="row show-grid">
                    <div class="col-lg-12">
                        <div class="well">
                            <fieldset>
                                <legend>Enrolment Checklist</legend>

                                <div class="form-group">
                                    <label class="col-md-4 col-sm-4">Learner Enrolment Course</label>
                                    <div class="col-md-8 col-sm-8">
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlEnrolmentCourse" runat="server" class="form-control input-sm" DataTextField="CourseTitle" DataValueField="Course_Id" DataSourceID="SDS_GetCourseList"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_GetCourseList" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionOsca %>"
                                                SelectCommand="SP_GetListQualCourses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvEnrolmentCourse" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlEnrolmentCourse" ErrorMessage="* Course is required to generate the learner on Portal" class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvEnrolmentCourse" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlEnrolmentCourse" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />

                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-md-8 col-sm-8">Have The Literacy/Numeracy tests been completed and returned?</label>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="controls">
                                            <asp:CheckBox runat="server" class="form-control input-sm" ValidationGroup="none" ID="chkApp_officeuse1_IsLiteracyNumeracyDone" AutoPostBack="false" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-8 col-sm-8">Have all documents been completed/signed?</label>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="controls">
                                            <asp:CheckBox runat="server" class="form-control input-sm" ValidationGroup="none" ID="chkApp_officeuse1_IsAllDocumentsSigned" AutoPostBack="false" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-8 col-sm-8">Confirm Enrolment?</label>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="controls">
                                            <asp:CheckBox runat="server" class="form-control input-sm" ValidationGroup="none" ID="chkApp_officeuse1_IsConfirmEnrolment" AutoPostBack="false" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-8 col-sm-8"></label>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="controls">
                                            <asp:LinkButton OnClick="btnConfirmEnrolment_Click" SkinID="LinkButton" Visible="true" ID="btnConfirmEnrolment" Text='Confirm Enrolment' runat="server" ValidationGroup="none" />
                                        </div>
                                    </div>
                                </div>


                            </fieldset>
                        </div>
                    </div>


                </div>
            </div>
        </div>

    </asp:Panel>




    <br />
    <div class="error_panel required-field-indicator" style="display: none">There are errors on the page, please correct and try again.</div>
    <br />
    <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false" HeaderText="Manual Process of application"
        OnNextButtonClick="Wizard1_NextButtonClick" OnPreviousButtonClick="Wizard1_PreviousButtonClick" OnFinishButtonClick="Wizard1_FinishButtonClick"
        Width="100%">


        <WizardSteps>
            <%--step1--%>

            <asp:WizardStep ID="WizardStep1" runat="server" Title="1: About Me" StepType="Start">
                <%--------------%>
                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Personal Information</legend>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">First Name (s) *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txtName" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_Name" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtName" ErrorMessage="* Name is required " class="required-field-indicator" />

                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtName" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Surname *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <div class="controls">
                                                <asp:TextBox ID="txtSurname" runat="server" class="form-control input-sm" />
                                                <asp:RequiredFieldValidator ID="rfv_Surname" runat="server" EnableClientScript="True"
                                                    ControlToValidate="txtSurname" ErrorMessage="* Surname is required " class="required-field-indicator" />

                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtSurname" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Gender *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:DropDownList ID="ddlGender" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_Gender"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_Gender" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Gender" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_Gender" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlGender" ErrorMessage="* Gender is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvGender" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlGender" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Date of birth *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txtDOB" runat="server" class="form-control input-sm" />
                                            <asp:CompareValidator
                                                ID="dateValidator" runat="server"
                                                Type="Date"
                                                Operator="DataTypeCheck"
                                                ControlToValidate="txtDOB"
                                                ErrorMessage="Please enter a valid date." class="required-field-indicator" CultureInvariantValues="true">
                                            </asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="rfvDOB" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtDOB" ErrorMessage="* Date of birth is required " class="required-field-indicator" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Email *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_Email" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_Email" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_Email" ErrorMessage="* Email is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Email" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Email" ID="RegularExpressionValidator17" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Invalid Email address" class="required-field-indicator"></asp:RegularExpressionValidator>


                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Mobile Number *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txtMobile" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMobile" ID="revtxtMobile" ValidationExpression="^[\s\S]{0,20}$" runat="server" ErrorMessage="Maximum 20 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMobile" ID="RegularExpressionValidator6" ValidationExpression="^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$" runat="server" ErrorMessage="Must be a valid UK mobile number." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtMobile" ErrorMessage="* Mobile Number is required " class="required-field-indicator" />
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-fluid submit-area"></div>
                <div class="denotesmandatory">Fields marked with * are mandatory.</div>


            </asp:WizardStep>

            <%--step2--%>

            <asp:WizardStep ID="WizardStep3" runat="server" Title="2: About Organization">


                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Organization's Details</legend>


                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Organisation Name</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_CompanyName" runat="server" class="form-control input-sm" />                                          
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Organisation Address (Where you are based)</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress1" runat="server" class="form-control input-sm" />

                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6"></label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress2" runat="server" class="form-control input-sm" />

                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Town</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress3" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Post Code</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlacePostCode" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Telephone Number</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_Tel" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Tel" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,20}$" runat="server" ErrorMessage="Maximum 20 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Tel" ID="RegularExpressionValidator7" ValidationExpression="^\d+?$" runat="server" ErrorMessage="Value must be a number." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Manager Name</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_ContactName" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>                                     

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Manager Email Address</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_Email" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Email" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Email" ID="RegularExpressionValidator12" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Invalid Email address" class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">ACS WDS Number</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_ACS_WDSNumber" runat="server" class="form-control input-sm" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>

                <%--------------%>
                <div class="container-fluid submit-area"></div>
                <div class="denotesmandatory">Fields marked with * are mandatory.</div>


            </asp:WizardStep>


            <asp:WizardStep ID="WizardStep5" runat="server" Title="5: Confirmation">
                <%  if (_App != null)
                    {
                        COURSE_LEVEL = (DSP.BAL.CourseLevel)Enum.ToObject(typeof(DSP.BAL.CourseLevel), _App._app_officeuse1_CourseLevel);
                    }

                %>
                <br />
                Please Note: By clicking SUBMIT you are confirming that all of the information in which you have provided is correct. The application form will take the information exactly as you have input it. Please check now and correct any spelling mistakes or errors before authorising your submission.
                 <br />

                <div id="accordion">
                    <h3>1- About Me</h3>
                    <div>

                        <label class="col-md-8 col-sm-8 item_key">First Name (s)	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_FirstName">
                            <asp:Literal ID="lit_App_FirstName" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Surname	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Surname">
                            <asp:Literal ID="lit_App_Surname" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Gender	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Gender">
                            <asp:Literal ID="lit_App_Gender" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Date of birth	</label>                       
                        <label class="col-md-4 col-sm-4 item_value" id="App_DOB">
                            <asp:Literal ID="lit_App_DOB" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Email Address	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Email">
                            <asp:Literal ID="lit_App_Email" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Mobile Number	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Mobile">
                            <asp:Literal ID="lit_App_Mobile" runat="server"></asp:Literal></label>

                    </div>

                    <h3>2: About Organization </h3>
                    <div>

                        <label class="col-md-8 col-sm-8 item_key">Organisation Name	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_CompanyName'>
                            <asp:Literal ID='lit_App_emp_CompanyName' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">
                            Organisation Address
                            <br />
                            <br />
                            <br />
                        </label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_WorkPlaceAddress'>
                            <asp:Literal ID='lit_App_emp_WorkPlaceAddress' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Post Code	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_WorkPlacePostCode'>
                            <asp:Literal ID='lit_App_emp_WorkPlacePostCode' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Telephone Number	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_Tel'>
                            <asp:Literal ID='lit_App_emp_Tel' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Manager Name	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_ContactName'>
                            <asp:Literal ID='lit_App_emp_ContactName' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Manager Email Address</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_Email'>
                            <asp:Literal ID='lit_App_emp_Email' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">ACS WDS Number</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_ACS_WDSNumber'>
                            <asp:Literal ID='lit_App_ACS_WDSNumber' runat='server'></asp:Literal></label>
                    </div>
                </div>


                <br />
                Please Note: By clicking SUBMIT you are confirming that all of the information provided is correct and you are giving consent for Access Skills to use the personal information submitted to process your application. (Our Privacy Notice can be found at the bottom of the page: please read carefully). If you have any questions about the collection, storage or use of your information, you can contact our Data Protection Officer on Tel: 0121 510 2169. The application form will retain the information exactly as you have input it. Please check now and correct any errors or omissions before authorising your submission.
                 <br />


                <!--<div id="accordion_privacy">-->
                <h3>Privacy Notice</h3>
                <div>
                    You may be contacted after you have completed your programme of learning to establish your employed circumstances or if you have further training or education requirements.
                        <br />
                    <br />
                    Please tick to indicate below that you wish to be contacted for such purposes.
                  
                        <br />
                    <asp:CheckBox ID="chk_mktg_ContactConsent" runat="server" Text="" />&nbsp;&nbsp;Yes
                        &nbsp;&nbsp;<asp:CheckBox ID="chk_mktg_ContactConsentNo" runat="server" Text="" />&nbsp;&nbsp;No
                        &nbsp;&nbsp;<asp:CheckBox ID="chk_mktg_ByPost" runat="server" Checked="false" Visible="false" Text="" />&nbsp;&nbsp; 
                        &nbsp;&nbsp;<asp:CheckBox ID="chk_mktg_ByEmail" runat="server" Checked="false" Visible="false" Text="" />&nbsp;&nbsp; 
                        &nbsp;&nbsp;<asp:CheckBox ID="chk_mktg_ByPhone" runat="server" Checked="false" Visible="false" Text="" />&nbsp;&nbsp; 

                        <br />
                </div>

                <!--</div>-->
                <h3>Signature:</h3>
                <p>
                    Please ensure that you have read the declaration before signing below. 
                Your enrolment on a course is not confirmed without your signature.
                </p>



                <div class="form-group">
                    <label class="col-md-2 col-sm-2">Application Date: </label>
                    <div class="col-md-10 col-sm-10">
                        <asp:TextBox ID="txtApplicationDate" runat="server" class="form-control input-sm" CssClass="DatepickerInputApplication" Enabled="false" />
                        <asp:CompareValidator
                            ID="txtApplicationDate_validator" runat="server"
                            Type="Date"
                            Operator="DataTypeCheck"
                            ControlToValidate="txtApplicationDate"
                            ErrorMessage="Please enter today's date." class="required-field-indicator" CultureInvariantValues="true">
                        </asp:CompareValidator>
                    </div>
                </div>


                <div id="panel_printname">

                    <label class="col-md-12 col-sm-12">Please print your name in the box below. By clicking Submit Application I agree that the signature and print name will be the electronic representation of my signature for all purposes when I use them on documentation relating to my course.</label>
                    <div class="form-group">

                        <div class="col-md-6 col-sm-6">
                            <asp:TextBox ID="txtPrintName" runat="server" Visible="true" Text="" MaxLength="30" class="form-control input-sm" placeholder="type your full name..."></asp:TextBox>
                            <span id="btnClearPrintName" class="button medium blue">Clear Print Name</span>
                        </div>

                        <asp:RequiredFieldValidator ID="rfvtxtPrintName" runat="server" EnableClientScript="False"
                            ControlToValidate="txtPrintName" ErrorMessage="* Your full name is required " class="required-field-indicator" />
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPrintName" ID="revtxtPrintName" ValidationExpression="^[\s\S]{0,60}$" runat="server" ErrorMessage="Maximum 60 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>

                    </div>
                    <br />
                    <br />

                </div>
                <div id="panel_signature">
                    <!-- Please sign in the box: -->

                    <div class="col-md-12 col-sm-12">
                        <div class="signature_wrapper">
                            <div class="wrapper">
                                <canvas id="signature-pad" class="signature-pad" width="500" height="100"></canvas>
                            </div>
                        </div>
                        <div>
                            <br />
                            <span id="btnClear" class="button medium blue hidden">Clear Signature</span>
                            <input type="hidden" id="sketch_data" name="sketch_data" />
                            <input type="hidden" id="hid_printname" name="hid_printname" />
                            <input type="hidden" id="hid_dt" name="hid_dt" />

                            <asp:TextBox ID="sketch_data_label" runat="server" Visible="false" Text=""></asp:TextBox>
                            <asp:TextBox ID="hid_printname_label" runat="server" Visible="false" Text=""></asp:TextBox>
                            <asp:TextBox ID="hid_dt_label" runat="server" Visible="false" Text=""></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfv_signature" runat="server" EnableClientScript="True"
                                ControlToValidate="sketch_data_label" ErrorMessage="* Signature is required " class="required-field-indicator" />--%>
                        </div>
                    </div>

                </div>

                <br />




            </asp:WizardStep>


        </WizardSteps>


        <StartNavigationTemplate>

            <asp:LinkButton ID="StartNextButton" runat="server" OnClientClick="ValidatePage();" CommandName="MoveNext" Text="Next" SkinID="LinkButton" />

        </StartNavigationTemplate>

        <StartNextButtonStyle CssClass="button medium blue" />
        <StepNextButtonStyle CssClass="button medium blue" />
        <StepPreviousButtonStyle CssClass="button medium blue" />
        <FinishPreviousButtonStyle CssClass="button medium blue" />
        <HeaderTemplate>
            <ul id="wizHeader">
                <asp:Repeater ID="SideBarList" runat="server">
                    <ItemTemplate>
                        <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                            <%# Eval("Name")%></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </HeaderTemplate>

    </asp:Wizard>

    <div class="error_panel required-field-indicator" style="display: none">There are errors on the page, please correct and try again.</div>
    <div id="divError" runat="server" visible="false" style="color: #CF0C2F; text-align: center;">
        There is some error submitting your details, Please contact admin for more details..
    </div>

    <asp:Label ID="lblAppId" runat="server" Visible="false"></asp:Label>



</asp:Content>




