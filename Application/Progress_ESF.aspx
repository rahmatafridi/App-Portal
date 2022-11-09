<%@ Page Title="Application progress" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Progress_ESF.aspx.cs" Culture="en-GB" Inherits="Application_Progress_ESF" %>

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

                        
                            <div class="col-lg-6">
                               <div class="well">
                                <fieldset>
                                    <legend>Personal Information</legend>
                                                <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Title *</label>
                                        <div class="col-md-6 col-sm-6">

                                            <asp:DropDownList class="form-control input-sm" ID="ddlTitles" runat="server" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_Titles"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_Titles" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Title" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_title" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlTitles" ErrorMessage="* Title is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvTitle" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlTitles" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
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
                                        <label class="col-md-6 col-sm-6">National Insurance Number *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txtNI" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtNI" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,20}$" runat="server" ErrorMessage="Maximum 20 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtNI" ID="RegularExpressionValidator15" ValidationExpression="^\s*[a-zA-Z]{2}(?:\s*\d\s*){6}[a-zA-Z]?\s*$" runat="server" ErrorMessage="Invalid National Insurance Number" class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvNI" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtNI" ErrorMessage="* National Insurance Number is required " class="required-field-indicator" />

                                            <%-- <asp:RegularExpressionValidator EnableClientScript="true" Display="Dynamic" ControlToValidate="txtNI" ID="revNI"
                                                 ValidationExpression="^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D]{1}$/i" 
                                                runat="server" ErrorMessage="Maximum 20 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>--%>
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
                                        <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Unique Learner Number</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_Unique_Number" runat="server" class="form-control input-sm" />
                                          
                                        </div>
                                    </div>
                                </fieldset>
                            </div>

                            </div>
                            <div class="col-lg-6">
                                  <div class="well">
                                <fieldset>
                                    <legend>Contact Information</legend>


                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Permanent Address *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtAddress1" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtAddress1" ErrorMessage="* Address is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAddress1" ID="revtxtAddress1" ValidationExpression="^[\s\S]{0,300}$" runat="server" ErrorMessage="Maximum 300 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4"></label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtAddress2" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAddress2" ID="revtxtAddress2" ValidationExpression="^[\s\S]{0,300}$" runat="server" ErrorMessage="Maximum 300 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Town *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtAddress3" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfvAddress3" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtAddress3" ErrorMessage="* Town is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAddress3" ID="revtxtAddress3" ValidationExpression="^[\s\S]{0,300}$" runat="server" ErrorMessage="Maximum 300 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Post Code *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtPostcode" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfvPostcode" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtPostcode" ErrorMessage="* Post Code is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPostcode" ID="revtxtPostcode" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Home Telephone Number </label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtTel" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTel" ID="revtxtTel" ValidationExpression="^[\s\S]{0,20}$" runat="server" ErrorMessage="Maximum 20 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTel" ID="RegularExpressionValidator5" ValidationExpression="^\s*\(?(020[7,8]{1}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\s*$" runat="server" ErrorMessage="Must be a valid UK number." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <%--<asp:RequiredFieldValidator ID="rfvTel" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtTel" ErrorMessage="* Home Telephone Number is required " class="required-field-indicator" />
                                            --%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Email *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txt_Email" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_Email" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_Email" ErrorMessage="* Email is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Email" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Email" ID="RegularExpressionValidator17" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Invalid Email address" class="required-field-indicator"></asp:RegularExpressionValidator>


                                        </div>
                                    </div>
                                 <%--   <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Email*</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="revtxtEmail" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtEmail" ErrorMessage="* Email is required " class="required-field-indicator" />
                                        </div>
                                    </div>--%>

                                </fieldset>
                            </div>

                            </div>
                              <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Other Details</legend>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Nationality *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlNationality" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_Nationality"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_Nationality" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Nationality" Type="String" />
                                                    <asp:Parameter Name="SortColumn" DefaultValue="Opt_Title" Type="String" />
                                                    <asp:Parameter Name="SortOrder" DefaultValue="ASC" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvNationality" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlNationality" ErrorMessage="* Nationality is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvNationality" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlNationality" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Have you lived in the UK EU/EEA continuously over the last three years? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlIsLivedEULast3Years" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvIsLivedEULast3Years" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlIsLivedEULast3Years" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvIsLivedEULast3Years" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlIsLivedEULast3Years" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>


<%--                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">If no please state date of entry into the UK </label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtLivedEntryDate" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
                                            <asp:CompareValidator
                                                ID="CompareValidator1" runat="server"
                                                Type="Date"
                                                Operator="DataTypeCheck"
                                                ControlToValidate="txtLivedEntryDate"
                                                ErrorMessage="Please enter a valid date." class="required-field-indicator" CultureInvariantValues="true">
                                            </asp:CompareValidator>
                                            <asp:CustomValidator ID="cvLivedEntryDate" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="txtLivedEntryDate" ErrorMessage="* Please select date" ClientValidationFunction="validateText" ValidateEmptyText="True" />
                                        </div>
                                    </div>--%>

                                    
                                 

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">If you are a Non EU or UK national, can you please confirm how long you have lived in the UK?</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtNonEUUKHowLongLiveInUK" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtNonEUUKHowLongLiveInUK" ID="revNonEUUKHowLongLiveInUK" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you a refugee/asylum seeker?</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlrefugee" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Refgee_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="Refgee_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                           
                                        </div>
                                    </div>
                                              
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Have you  been granted leave to remain in the UK?</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlgrantedleave" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Greant_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="Greant_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                           
                                        </div>
                                    </div>

        
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Ethnicity *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlEthnicity" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_Ethnicity"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_Ethnicity" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Ethnicity" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvEthnicity" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlEthnicity" ErrorMessage="* Ethnicity is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvEthnicity" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlEthnicity" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                                  
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you live in a single adult household with a dependant child?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlsingleadult" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Single_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="Single_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlsingleadult" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="CustomValidator2" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlsingleadult" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                             
                                 


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have a disability and/or learning difficulty? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlAnyDisability" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvAnyDisability" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlAnyDisability" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvAnyDisability" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlAnyDisability" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">If yes please state your primary disability and/or learning difficulty</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlAnyDisabilityPrimary" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_AnyDisabilityPrimary"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_AnyDisabilityPrimary" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Disabilities" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvAnyDisabilityPrimary" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlAnyDisabilityPrimary" ErrorMessage="* Primary Disability and/or Difficulty is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvAnyDisabilityPrimary" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlAnyDisabilityPrimary" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <div class="form-group">

                                        <label class="col-md-12 col-sm-12">Please select any other disabilities and/or learning difficulties</label>
                                        <div class="col-md-12 col-sm-12" style="background: #fefefe">
                                            <asp:CheckBoxList ID="chkListDisabilities" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                                <asp:ListItem Text="01 Emotional/behavioural difficulties" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="02 Multiple disabilities" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="03 Multiple learning difficulties" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="04 Visual impairment" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="05 Hearing impairment" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="06 Disability affecting mobility" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="07 Profound complex disabilities" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="08 Social and emotional difficulties" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="09 Mental health difficulty" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10 Moderate learning difficulty" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11 Severe learning difficulty" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12 Dyslexia" Value="12"></asp:ListItem>
                                                <asp:ListItem Text="13 Dyscalculia" Value="13"></asp:ListItem>
                                                <asp:ListItem Text="14 Autism spectrum disorder" Value="14"></asp:ListItem>
                                                <asp:ListItem Text="15 Asperger's syndrome" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="16 Temporary disability after illness (for example post-viral) or accident" Value="16"></asp:ListItem>
                                                <asp:ListItem Text="17 Speech, language and communication need" Value="17"></asp:ListItem>
                                                <asp:ListItem Text="93 Other physical disability" Value="18"></asp:ListItem>
                                                <asp:ListItem Text="94 Other specific learning difficulty (e.g. Dyspraxja)" Value="19"></asp:ListItem>
                                                <asp:ListItem Text="95 Other medical condition (e.g. epilepsy, asthma, diabetes)" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="96 Other learning difficulty" Value="21"></asp:ListItem>
                                                <asp:ListItem Text="97 Other disability" Value="22"></asp:ListItem>
                                                <asp:ListItem Text="98 Prefer not to say" Value="23"></asp:ListItem>
                                            </asp:CheckBoxList>


                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are there any other reasons why you may need learning support e.g. mental health difficulty, medical condition? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlNeedLearningSupport" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvNeedLearningSupport" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlNeedLearningSupport" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvNeedLearningSupport" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlNeedLearningSupport" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
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

            <asp:WizardStep ID="WizardStep2" runat="server" Title="2: About Organization">


                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Organization's Details</legend>


                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Company Name *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_CompanyName" runat="server" class="form-control input-sm" />                                          
                                      <asp:RequiredFieldValidator ID="rfEmp_CompanyName" runat="server" EnableClientScript="True"
                                                ControlToValidate="txt_emp_CompanyName" ErrorMessage="* Company Name is required " class="required-field-indicator" />

                                            </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Workplace Address (Where you are based) *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress1" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfWork_place_Address" runat="server" EnableClientScript="True"
                                                ControlToValidate="txt_emp_WorkPlaceAddress1" ErrorMessage="* Worplace Address is required " class="required-field-indicator" />

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
                                        <label class="col-md-6 col-sm-6">Type of Service Provided*</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_type_ServiceProvider" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rftxt_type_provider" runat="server" EnableClientScript="True"
                                                ControlToValidate="txt_type_ServiceProvider" ErrorMessage="* Service Provided is required " class="required-field-indicator" />

                                        </div>
                                    </div>                                     
                                    
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">What is your job Role?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_JobFunction" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_job_JobFunction"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_job_JobFunction" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Job Function" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_job_JobFunction" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_JobFunction" ErrorMessage="* Your job function is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_JobFunction" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_JobFunction" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                  
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is your organisation registered with Skills for Care?* </label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlOrg_Skill" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="OrgSkill_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="OrgSkill_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rf_OrgSkill" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlOrg_Skill" ErrorMessage="* Your Org Skill is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_Org_Skill" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlOrg_Skill" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                        </div>
                                    </div>

                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is your organisation Registered with CQC?* </label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Org_Cqc" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="OrgCqc_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="OrgCqc_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                             <asp:RequiredFieldValidator ID="rv_Org_Cqc" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Org_Cqc" ErrorMessage="* Your Org  CQC required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_Org_Cqc" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Org_Cqc" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
         
                                        </div>
                                    </div>

                                    
                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is your organisation Registered with Quality Compliance Systems (QCS)? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Org_Reg_Cqc" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="OrgRegCqc_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="OrgRegCqc_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                             <asp:RequiredFieldValidator ID="rf_Reg_Cqc" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Org_Reg_Cqc" ErrorMessage="* Your Org Register CQC required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_Reg_Cqc" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Org_Reg_Cqc" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         

                                        </div>
                                    </div>

                                                 
                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Does your organisation employee less than 250 staff members?* </label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Org_Emp" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="OrgEmp_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="OrgEmp_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                              <asp:RequiredFieldValidator ID="rf_Org_Emp" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Org_Emp" ErrorMessage="* Your Org Employee Staff required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_Org_Emp" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Org_Emp" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
         
                                        </div>
                                    </div>

                                     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is the manager registered with Skills for Care?* </label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlmangerreg" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="ManagerReg_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="ManagerReg_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                             <asp:RequiredFieldValidator ID="rf_manager" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlmangerreg" ErrorMessage="* Your Manager Skill required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_manager" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlmangerreg" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         

                                        </div>
                                    </div>

                                         <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is your organisation in need of support when completing PID?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlorgpid" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="OrgPID_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="OrgPID_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                             <asp:RequiredFieldValidator ID="rf_org_pid" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlorgpid" ErrorMessage="* Your Organisation PID  required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_org_pid" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlorgpid" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                        </div>
                                    </div>


                                          <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is your organisation Registered with your Local Authority?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlorgreglocalAuthority" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="OrgRegLocalAuth_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="OrgRegLocalAuth_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         

                                            <asp:RequiredFieldValidator ID="rf_org_Auth" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlorgreglocalAuthority" ErrorMessage="* Your  Local Authority  required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_org_Auth" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlorgreglocalAuthority" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is the turnover less than €50 million/balance less than €43 million?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlmillionbalance" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="MillionBalance_YESNO"></asp:DropDownList>
                                            <asp:SqlDataSource ID="MillionBalance_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                              <asp:RequiredFieldValidator ID="rf_million" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlmillionbalance" ErrorMessage="* Your Million/Balance  required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_million" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlmillionbalance" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
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

           <asp:WizardStep ID="WizardStep3" runat="server" Title="3: Education">


                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Education History</legend>


                                                                    
                                    
                                  
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have basic level English?* </label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlbasicenglish" runat="server" class="form-control input-sm"
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="BasicEnglish_YESNO"></asp:DropDownList>
                                           
                                            <asp:RequiredFieldValidator ID="rfbasicEnglish" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlbasicenglish" ErrorMessage="* Basic English is required " class="required-field-indicator" />
                                             <asp:CustomValidator ID="cv_basicenghlish" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlbasicenglish" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         

                                            <asp:SqlDataSource ID="BasicEnglish_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>
                                    </div>

                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have basic level Maths?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlbasicmath" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="BasicMath_YESNO"></asp:DropDownList>
                                          
                                              <asp:RequiredFieldValidator ID="rfBasicMath" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlbasicmath" ErrorMessage="* Basic Math is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_basicmath" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlbasicmath" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="BasicMath_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>
                                    </div>

                                    
                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have Level 2 English?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddllevel2english" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Level2English_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfLevel2English" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddllevel2english" ErrorMessage="* Level 2 English is required " class="required-field-indicator" />
                                              <asp:CustomValidator ID="cv_level2english" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddllevel2english" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            
                                            <asp:SqlDataSource ID="Level2English_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>
                                    </div>

                                                 
                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have Level 2 Maths?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddllevel2math" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Level2Math_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rfLevel2Math" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddllevel2math" ErrorMessage="* Level 2 Math is required " class="required-field-indicator" />
                                            
                                            <asp:CustomValidator ID="cv_level2math" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddllevel2math" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Level2Math_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>
                                    </div>

                                     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">What is your highest Qualification?*</label>
                                        <div class="col-md-4 col-sm-4">
                                         <asp:TextBox ID="txt_hight_qualification" runat="server" class="form-control input-sm" />
                                              <asp:RequiredFieldValidator ID="rfHighQualification" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_hight_qualification" ErrorMessage="* Highest Qualification is required " class="required-field-indicator" />
                                            
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
            <asp:WizardStep ID="WizardStep4" runat="server" Title="4: Statement">


                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Statement of Application</legend>


                                    <div class="form-group">
                                        <label class="col-md-12 col-sm-12">I wish to apply for admission to the ESF project and Business Support programme. If offered a place I agree to comply with the general regulations and any particular conditions set out in the offer. I am aware that this programme is partly funded by the European Social Fund. I agree to comply with the general regulations and any particular conditions set out in the offer. 
 
Access Skills will provide you with guidance to enable you to make an informed decision about your programme study, and an assessment of your suitability to study the programme   </label>
                                 
                                    </div>

                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">I understand and agree to Access Skills holding and processing personal data about me*</label>
                                             <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Access_Skill_Hold" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Acc_Skill_Hold_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rv_acc_skill_hold" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Access_Skill_Hold" ErrorMessage="* Access Skill Hold is required " class="required-field-indicator" />
                                           
                                                

                                                 <asp:CustomValidator ID="cv_acc_Skill_Hold" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Access_Skill_Hold" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                                 <asp:CompareValidator ID="CompareValidator1" runat="server" style="margin-left:-95px"
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_Access_Skill_Hold" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />

                                            <asp:SqlDataSource ID="Acc_Skill_Hold_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>

                                    
                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">I understand that this programme is part funded by the European Social Fund*</label>
                                              <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_European_Social" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="European_Social_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rv_Eruopean" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_European_Social" ErrorMessage="* European Social is required " class="required-field-indicator" />
                                            
                                                 <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_European_Social" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />
                                            <asp:CustomValidator ID="cv_Eruopen" runat="server" style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_European_Social" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="European_Social_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>

                                                 
                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">This business has fewer than 250 employees and the turnover less than €50 million and/or a balance less than €43 million*</label>
                                                <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Employee_Million" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Employee_Million_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rv_Employee_Million" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Employee_Million" ErrorMessage="* Employee Million is required " class="required-field-indicator" />
                                            <asp:CompareValidator ID="CompareValidator3" runat="server"
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_Employee_Million" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />


                                            <asp:CustomValidator ID="cv_Employee_Million" runat="server"  style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Employee_Million" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Employee_Million_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>

                                     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">I am authorised to act on behalf of my organisation*</label>
                                                   <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Behalf" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Behalf_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rv_behalf" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Behalf" ErrorMessage="* Behalf is required " class="required-field-indicator" />
                                             
                                                       <asp:CompareValidator ID="CompareValidator4" runat="server" 
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_Behalf" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />



                                            <asp:CustomValidator ID="cv_behalf" runat="server" style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Behalf" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Behalf_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-8">
                                            I can confirm the initial guidance assessment and enrolment has been covered in the areas described above*
                                        </label>
                                             <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="dll_Assessment" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Assessment_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rf_Assessment" runat="server" EnableClientScript="False"
                                                ControlToValidate="dll_Assessment" ErrorMessage="* Assessment is required " class="required-field-indicator" />
                                              <asp:CompareValidator ID="CompareValidator5" runat="server" 
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="dll_Assessment" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />


                                            <asp:CustomValidator ID="cv_Assessment" runat="server" style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="dll_Assessment" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Assessment_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>
                                      <div class="form-group"> 
                                        <label class="col-md-8 col-lg-8">
                                       I agreed to abide by Access Skills code of conduct.
                                       I understand that I may be required to withdraw from Access Skills if I do not comply                                        

                                        </label>
                                             <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Access_Skill" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Access_Skill_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rf_Access" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Access_Skill" ErrorMessage="* Access Skill is required " class="required-field-indicator" />
                                            
 <asp:CompareValidator ID="CompareValidator6" runat="server" 
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_Access_Skill" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />



                                            <asp:CustomValidator ID="cv_Access" runat="server"  style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Access_Skill" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Access_Skill_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>
                                    <div  class="form-group">
                                        <label class="col-md-8">
                                            I certify that all information supplied by me on this form is true and accurate I will inform Access Skills of any changes of details understand and agree to Access Skills holding and processing personal data about me*
                                        </label>
                                               <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Info_Supplied" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Info_Supplied_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rv_info_supplied" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Info_Supplied" ErrorMessage="* Information Supplied is required " class="required-field-indicator" />
                                            
                                                 <asp:CompareValidator ID="CompareValidator7" runat="server" 
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_Info_Supplied" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />


                                            <asp:CustomValidator ID="cv_info_supplied" runat="server" style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Info_Supplied" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Info_Supplied_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
                                        </div>

                                    </div>

                                       <div class="form-group">
                                        <label class="col-md-8">
       I declare that on the date my course is due to commence I will have been legally resident in the UK/ EU/ EEU a for the last three years and that my main purpose for such residents was not to receive full time education during any part of that three year*                                        </label>
                                             <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_Legally_Uk" runat="server" class="form-control input-sm" 
                                                DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="Legally_Uk_YESNO"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rv_regally_uk" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_Legally_Uk" ErrorMessage="* Legally in Uk is required " class="required-field-indicator" />
                                            
                                                   <asp:CompareValidator ID="CompareValidator8" runat="server" 
                                                     EnableClientScript="True" class="required-field-indicator" ControlToValidate="ddl_Legally_Uk" ValueToCompare="2" Operator="NotEqual"
                                                      Type="Integer" ErrorMessage="Please select Yes in order to continue" />


                                            <asp:CustomValidator ID="cv_legally_uk" runat="server" style="margin-left:-240px;" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_Legally_Uk" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
         
                                            <asp:SqlDataSource ID="Legally_Uk_YESNO" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
         
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
                    <h3>1: About Me</h3>
                    <div>
                            <div class="col-lg-12">
                                 <label class="col-md-8 col-sm-8 item_key">Title</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Title">
                            <asp:Literal ID="lit_App_Title" runat="server"></asp:Literal></label>
                          
                                      
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
                                  
                        <label class="col-md-8 col-sm-8 item_key">National Insurance Number:</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_NI">
                            <asp:Literal ID="lit_App_NI" runat="server"></asp:Literal></label>

                            <label class="col-md-8 col-sm-8 item_key">Unique Learner Number:</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Unique_Number">
                            <asp:Literal ID="lit_App_Unique_Number" runat="server"></asp:Literal></label>
                           
                            


                            
                            </div>

                   
                            <div class="col-lg-12">
                                <div>
                                <label class="col-md-8 col-sm-8 item_key">
                                      Permanent Address
                                  </label>
                                 <label class="col-md-4 col-sm-4 item_value" id="App_PermAddress1">
                            <asp:Literal ID="lit_App_PermAddress1" runat="server"></asp:Literal></label>
                                    </div>
                                <div>
                             <label  class="col-md-8 col-sm-8 item_key">Email Address	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Email">
                            <asp:Literal ID="lit_App_Email" runat="server"></asp:Literal></label>
                                    </div>
                                
                                
                                <div>
                        <label class="col-md-8 col-sm-6 item_key">Mobile Number	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Mobile">
                            <asp:Literal ID="lit_App_Mobile" runat="server"></asp:Literal></label>
                          </div>
                                <div>
                        <label class="col-md-8 col-sm-8 item_key">Post Code	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_PermPostCode">
                            <asp:Literal ID="lit_App_PermPostCode" runat="server"></asp:Literal></label>
                           </div>
                                <div>
                        <label class="col-md-8 col-sm-8 item_key">Home Telephone Number	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_HomeTel">
                            <asp:Literal ID="lit_App_HomeTel" runat="server"></asp:Literal></label>
                     </div>
                        

                            </div>
                       <br />
                        <br />
                        <br />
                        <div class="col-lg-12">
                               <label class="col-md-8 col-sm-8 item_key">Nationality	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Nationality">
                            <asp:Literal ID="lit_App_Nationality" runat="server"></asp:Literal></label>

                                 <label class="col-md-8 col-sm-8 item_key">Have you lived in the UK continuously over the last three years?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsLivedEULast3Years">
                            <br />
                            <asp:Literal ID="lit_App_IsLivedEULast3Years" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">If you are a Non EU or UK national, can you please confirm how long you have lived in the UK?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_NonEUUKHowLongLiveInUK">
                            <br />
                            <asp:Literal ID="lit_App_NonEUUKHowLongLiveInUK" runat="server"></asp:Literal></label>

                                     <label class="col-md-8 col-sm-8 item_key">Are you a refugee/asylum seeker	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Refugee">
                            <asp:Literal ID="lit_App_Refugee" runat="server"></asp:Literal></label>

                            <label class="col-md-8 col-sm-8 item_key">Have you  been granted leave to remain in the UK</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Granted_Leave">
                            <asp:Literal ID="lit_App_Granted_Leave" runat="server"></asp:Literal></label>

                            
                        <label class="col-md-8 col-sm-8 item_key">Ethnicity	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Ethnicity">
                            <asp:Literal ID="lit_App_Ethnicity" runat="server"></asp:Literal></label>

                            <label class="col-md-8 col-sm-8 item_key">Do you live in a single adult household with a dependant child	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Single">
                            <asp:Literal ID="lit_App_Signle" runat="server"></asp:Literal></label>

                             <label class="col-md-8 col-sm-8 item_key">Do you have a disability and/or learning difficulty?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_AnyDisability">
                            <asp:Literal ID="lit_App_AnyDisability" runat="server"></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">If yes please state your primary disability and/or learning difficulty</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_AnyDisabilityPrimary">
                            <asp:Literal ID="lit_App_AnyDisabilityPrimary" runat="server"></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Please select any other disabilities and/or learning difficulties</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_AnyDisabilitySecondaries">
                            <asp:Literal ID="lit_App_AnyDisabilitySecondaries" runat="server"></asp:Literal></label>



                        <label class="col-md-8 col-sm-8 item_key">Are there any other reasons why you may need learning support e.g. mental health difficulty, medical condition?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_NeedLearningSupport">
                        <br />
                            <asp:Literal ID="lit_App_NeedLearningSupport" runat="server"></asp:Literal></label>

                        </div>

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

                        <label class="col-md-8 col-sm-8 item_key">Type of Service Provided	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Type_Service_Proivded'>
                            <asp:Literal ID='lit_App_Type_Service_Proivded' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Job Role</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Job_Role'>
                            <asp:Literal ID='lit_App_Job_Role' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Is your organisation registered with Skills for Care</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Org_Skill'>
                            <asp:Literal ID='lit_App_Org_Skill' runat='server'></asp:Literal></label>

                        
                        <label class="col-md-8 col-sm-8 item_key">Is your organisation Registered with CQC</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Org_Reg_Cqc'>
                            <asp:Literal ID='lit_App_Org_Reg_Cqc' runat='server'></asp:Literal></label>

                        
                        <label class="col-md-8 col-sm-8 item_key">Is your organisation Registered with Quality Compliance Systems (QCS)</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Org_Cqc'>
                            <asp:Literal ID='lit_App_Org_Cqc' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Does your organisation employee less than 250 staff members</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Org_Emp'>
                            <asp:Literal ID='lit_App_Org_Emp' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Is the manager registered with Skills for Care</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Manager_Reg'>
                            <asp:Literal ID='lit_App_Manager_Reg' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Is your organisation in need of support when completing PID</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Org_PId'>
                            <asp:Literal ID='lit_App_Org_PId' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Is your organisation Registered with your Local Authority</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Org_Local_Authority'>
                            <asp:Literal ID='lit_App_Org_Local_Authority' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Is the turnover less than €50 million/balance less than €43 million</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Million_Balance'>
                            <asp:Literal ID='lit_App_Million_Balance' runat='server'></asp:Literal></label>

                    </div>
                    <h3>3: Education</h3>
                    <div>
                               <label class="col-md-8 col-sm-8 item_key">Do you have basic level English</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Basic_English'>
                            <asp:Literal ID='lit_App_Bacis_English' runat='server'></asp:Literal></label>

                               <label class="col-md-8 col-sm-8 item_key">Do you have basic level Maths</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Basic_Math'>
                            <asp:Literal ID='lit_App_Basic_Match' runat='server'></asp:Literal></label>

                               <label class="col-md-8 col-sm-8 item_key">Do you have Level 2 English</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Level_2_English'>
                            <asp:Literal ID='lit_App_Level_2_English' runat='server'></asp:Literal></label>
                               <label class="col-md-8 col-sm-8 item_key">Do you have Level 2 Maths</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_Level_2_Math'>
                            <asp:Literal ID='lit_App_Level_2_Math' runat='server'></asp:Literal></label>
                               <label class="col-md-8 col-sm-8 item_key">What is your highest Qualification</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_High_Qualification'>
                            <asp:Literal ID='lit_App_High_Qu' runat='server'></asp:Literal></label>
                    </div>
                     <h3>4: Statement of Application</h3>
                    <div>
                      <label class="col-md-12 col-sm-12 item_key">I wish to apply for admission to the ESF project and Business Support programme. If offered a place I agree to comply with the general regulations and any particular conditions set out in the offer. 
                          I am aware that this programme is partly funded by the European Social Fund. I agree to comply with the general regulations and any particular conditions set out in the offer.
                          Access Skills will provide you with guidance to enable you to make an informed decision about your programme study, and an assessment of your suitability to study the programme
                      </label>

                        <label class="col-md-9 col-sm-9 item_key">
                        I understand and agree to Access Skills holding and processing personal data about me*    
                        </label>
                         <label class='col-md-3 col-sm-3 item_value' id='App_emp_access_skill_hold'>
                            <asp:Literal ID='lit_App_access_skill_hold' runat='server'></asp:Literal></label>

                           <label class="col-md-9 col-sm-9 item_key">
                     I understand that this programme is part funded by the European Social Fund*              
                           </label>
                         <label class='col-md-3 col-sm-3 item_value' id='App_European_Social'>
                            <asp:Literal ID='lit_App_european' runat='server'></asp:Literal></label>
                          <label class="col-md-9 col-sm-9 item_key">
This business has fewer than 250 employees and the turnover less than €50 million and/or a balance less than €43 million*                           </label>
                        
                        <label class='col-md-3 col-sm-3 item_value' id='App_Employee_Million'>
                            <asp:Literal ID='lit_App_employee_million' runat='server'></asp:Literal></label>
                        
                        <label class="col-md-9 col-sm-9 item_key">
                 I am authorised to act on behalf of my organisation*         
                           </label>
                         <label class='col-md-3 col-sm-3 item_value' id='App_Behalf'>
                            <asp:Literal ID='lit_App_behalf' runat='server'></asp:Literal></label>
                          <label class="col-md-9 col-sm-9 item_key">
                    I can confirm the initial guidance assessment and enrolment has been covered in the areas described above*           
                           </label>
                                         <label class='col-md-3 col-sm-3 item_value' id='App_Assessment'>
                            <asp:Literal ID='lit_App_assessment' runat='server'></asp:Literal></label>
                         <label class="col-md-9 col-sm-9 item_key">
I agreed to abide by Access Skills code of conduct. I understand that I may be required to withdraw from Access Skills if I do not comply                       
                             
                         </label>
                                <label class='col-md-3 col-sm-3 item_value' id='App_access_skill'>
                            <asp:Literal ID='lit_App_access_skill' runat='server'></asp:Literal></label>
                         <label class="col-md-9 col-sm-9 item_key">
                         I certify that all information supplied by me on this form is true and accurate I will inform Access Skills of any changes of details understand and agree to Access Skills holding and processing personal data about me*     
                         </label>
                                   <label class='col-md-3 col-sm-3 item_value' id='App_Info_Supplied'>
                            <asp:Literal ID='lit_App_info_supplied' runat='server'></asp:Literal></label>
                         <label class="col-md-9 col-sm-9 item_key">
I declare that on the date my course is due to commence I will have been legally resident in the UK/ EU/ EEU a for the last three years and that my main purpose for such residents was not to receive full time education during any part of that three year*
                         </label>
                                  <label class='col-md-3 col-sm-3 item_value' id='App_Legally_UK'>
                            <asp:Literal ID='lit_App_legally_uk' runat='server'></asp:Literal></label>
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
                        <%--<asp:CompareValidator
                            ID="txtApplicationDate_validator" runat="server"
                            Type="Date"
                            Operator="DataTypeCheck"
                            ControlToValidate="txtApplicationDate"
                            ErrorMessage="Please enter today's date." class="required-field-indicator" CultureInvariantValues="true">
                        </asp:CompareValidator>--%>
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
    </div>
       <asp:LinkButton ID="btnSaveAndLogout" runat="server" Text="Save and Exit" SkinID="LinkButton"
        CausesValidation="false"
        OnClientClick="return confirm('Are you sure you want to save and logout?');"
        OnClick="btnSaveAndLogout_Click" />
    <asp:Label ID="lblAppId" runat="server" Visible="false"></asp:Label>



</asp:Content>




