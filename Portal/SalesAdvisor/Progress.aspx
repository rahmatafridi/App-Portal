 <%@ Page Title="Application progress" Language="C#" MasterPageFile="~/SiteMaster.master"  AutoEventWireup="true"
    CodeFile="Progress.aspx.cs" Culture="en-GB" Inherits="SalesAdvisor_Progress" %>

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

    <script type="text/javascript">
        $(document).ready(function () {

            //1- legal residency

            $('#btnFileUpload_legalresidency').fileupload({
                url: '/Application/FileUploaderHandler.ashx?upload=start',
                add: function (e, data) {
                    // console.log('add', data);
                    $('#progressbar_legalresidency').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar_legalresidency div').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar_legalresidency').hide();
                    $('#progressbar_legalresidency div').css('width', '0%');
                    $('#progressbar_message_legalresidency').attr('class', 'alert alert-success');
                    $('#progressbar_message_legalresidency').text("Uploaded successfully");
                    $("#uploaded_file_legalresidency").val(response);
                    var hiddencontrol = $("#<%=uploaded_file_path_legalresidency.ClientID%>");
                    $(hiddencontrol).val(response);
                    //console.log('success', response);
                },
                error: function (error) {
                    $('#progressbar_legalresidency').hide();
                    $('#progressbar_legalresidency div').css('width', '0%');
                    $('#progressbar_message_legalresidency').attr('class', 'alert alert-danger');
                    $('#progressbar_message_legalresidency').text("Could not upload the file.");
                }
            });

            /*pathways l3 */

            $('#btnFileUpload_havejobdescription_l3').fileupload({
                url: '/Application/FileUploaderHandler.ashx?upload=start',
                add: function (e, data) {
                    // console.log('add', data);
                    $('#progressbar_havejobdescription_l3').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar_havejobdescription_l3 div').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar_havejobdescription_l3').hide();
                    $('#progressbar_havejobdescription_l3 div').css('width', '0%');
                    $('#progressbar_message_havejobdescription_l3').attr('class', 'alert alert-success');
                    $('#progressbar_message_havejobdescription_l3').text("Uploaded successfully");
                    $("#uploaded_file_havejobdescription_l3").val(response);
                    /*  var hiddencontrol = $("#<   %=uploaded_file_path_havejobdescription_l3_doc.ClientID%>");*/
                    $(hiddencontrol).val(response);
                    //console.log('success', response);
                },
                error: function (error) {
                    $('#progressbar_havejobdescription_l3').hide();
                    $('#progressbar_havejobdescription_l3 div').css('width', '0%');
                    $('#progressbar_message_havejobdescription_l3').attr('class', 'alert alert-danger');
                    $('#progressbar_message_havejobdescription_l3').text("Could not upload the file.");
                }

            });

            //L5 have job desc 
            $('#btnFileUpload_havejobdescription_doc').fileupload({
                url: '/Application/FileUploaderHandler.ashx?upload=start',
                add: function (e, data) {
                    // console.log('add', data);
                    $('#progressbar_havejobdescription_doc').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar_havejobdescription_doc div').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar_havejobdescription_doc').hide();
                    $('#progressbar_havejobdescription_doc div').css('width', '0%');
                    $('#progressbar_message_havejobdescription_doc').attr('class', 'alert alert-success');
                    $('#progressbar_message_havejobdescription_doc').text("Uploaded successfully");
                    $("#uploaded_file_havejobdescription").val(response);
                    var hiddencontrol = $("#<%=uploaded_file_path_havejobdescription_doc.ClientID%>");
                    $(hiddencontrol).val(response);
                    //console.log('success', response);
                },
                error: function (error) {
                    $('#progressbar_havejobdescription_doc').hide();
                    $('#progressbar_havejobdescription_doc div').css('width', '0%');
                    $('#progressbar_message_havejobdescription_doc').attr('class', 'alert alert-danger');
                    $('#progressbar_message_havejobdescription_doc').text("Could not upload the file.");
                }

            });



        });
    </script>

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

            //$("#panel_signature").show();
            // $("#panel_printname").show(); 

            if ($("#<%=ddlAnyDisability.ClientID %>").val() == "2") {
                ControlEnable('#<%=ddlAnyDisabilityPrimary.ClientID %>', false);
            }
            if ($("#<%=ddlIsLivedEULast3Years.ClientID %>").val() == "1") {
                ControlEnable('#<%=txtLivedEntryDate.ClientID %>', false);
            }
            if ($("#<%=ddl_educ_IsGCSEMath.ClientID %>").val() == "1") {
                ControlEnable('#<%=txt_educ_EquivalentQualification.ClientID %>', false);
            }
            if ($("#<%=ddl_educ_IsALLFund.ClientID %>").val() == "2") {
                ControlEnable('#<%=txt_educ_ALLFundQualDetails.ClientID %>', false);
            }
            <%--if ($("#<%=ddlEUEAANational.ClientID %>").val() == "2") {
                //ValidatorEnable($("#<%=rfvEUEEAStatus.ClientID %>"), false); 
                //BodyContent_Wizard1_ddlEUEAANational
                document.getElementById("<%=rfvEUEEAStatus.ClientID%>").enabled = false;
            } else {
                document.getElementById("<%=rfvEUEEAStatus.ClientID%>").enabled = true;

            }--%>
            if ($("#<%=ddlEUEAANational.ClientID %>").val() == "1") {
                var val = $("#<%=rfvEUEEAStatus.ClientID %>");
               
                if (val != undefined) {
                    val.enabled =  false ;
                    //ValidatorEnable($("#<%=rfvEUEEAStatus.ClientID %>"), false);
                }
                
             }
            $("#<%=ddlAnyDisability.ClientID %>").change(function () {

                var state = false;
                var val = $(this).val();
                var skip = null;
                if (val == 1) {
                    // alert("Yes");// = "workPhoneValidator";
                    state = true;
                }
                else if (val == 2) {
                    state = false;
                    //alert("No");// 
                    //disable now
                    //                                
                }
                ControlEnable('#<%=ddlAnyDisabilityPrimary.ClientID %>', state);
                //  CustomValidatorEnable('<%=cvAnyDisabilityPrimary.ClientID %>', state);                
                ValidatorEnable($("#<%=rfvAnyDisabilityPrimary.ClientID %>"), state);
                // skip = "rfvAnyDisabilityPrimary";         
                //  var $skip = $("#" + skip)[0];
                //  alert($skip);//
                //  if (skip != "xxx") ValidatorEnable($skip, false);
                //   if (skip != "cellPhoneValidator") ValidatorEnable($skip, false);

            });
            $("#<%=ddlEUEAANational.ClientID %>").change(function () {

                var state = false;
                var val = $(this).val();
                var skip = null;
                if (val == 1) {

                    state = true;
                }
                else if (val == 2) {
                    state = false;

                }
                ControlEnable('#<%=ddlEUEEAStatus.ClientID %>', state);
                               
                //ValidatorEnable($("#<%=rfvEUEEAStatus.ClientID %>"), state);
                var val = $("#<%=rfvEUEEAStatus.ClientID %>");
                if (val != undefined) {
                    val.enabled = false;
                }

            });

            $("#<%=ddlIsLivedEULast3Years.ClientID %>").change(function () {

                var state = false;
                var val = $(this).val();
                var skip = null;
                if (val == 2) {
                    state = true;
                }
                else if (val == 1) {
                    state = false;
                }
                ControlEnable('#<%=txtLivedEntryDate.ClientID %>', state);
            });

            $("#<%=ddl_educ_IsGCSEMath.ClientID %>").change(function () {

                var state = false;
                var val = $(this).val();
                var skip = null;
                if (val == 2) {
                    state = true;
                }
                else if (val == 1) {
                    state = false;
                }
                ControlEnable('#<%=txt_educ_EquivalentQualification.ClientID %>', state);
            });

            $("#<%=ddl_educ_IsALLFund.ClientID %>").change(function () {

                var state = false;
                var val = $(this).val();
                var skip = null;
                if (val == 1) {
                    state = true;
                }
                else if (val == 2) {
                    state = false;
                }
                ControlEnable('#<%=txt_educ_ALLFundQualDetails.ClientID %>', state);
            });

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

            /********************************************************************************/
             
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

            //if (oSrc.id == "BodyContent_Wizard1_ddlAnyDisability" && $("#<%=ddlAnyDisability.ClientID %>").val() == 2) {
                //ValidatorEnable($("#<%=rfvAnyDisabilityPrimary.ClientID %>"), state);    
                // args.IsValid = true;
            //}

            if (oSrc.id == "BodyContent_Wizard1_cvAnyDisabilityPrimary" && $("#<%=ddlAnyDisability.ClientID %>").val() == 2) {
                //ValidatorEnable($("#<%=rfvAnyDisabilityPrimary.ClientID %>"), state);    
                args.IsValid = true;
            }
            
            if ($("#<%=ddlEUEAANational.ClientID %>").val() == 2) {
                $("#BodyContent_Wizard1_rfvEUEEAStatus").hide();  
                args.IsValid = true;
            }

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

            if (oSrc.id == "BodyContent_Wizard1_cvLivedEntryDate") {
                if ($("#<%=ddlIsLivedEULast3Years.ClientID %>").val() == 2) {
                    //needs to test the value of control to validate
                    if (!args.IsValid) {
                        bAnyErrors = true;
                    }
                }
                else {
                    args.IsValid = true;
                }
            }
            if (oSrc.id == "BodyContent_Wizard1_cv_educ_EquivalentQualification") {
                if ($("#<%=ddl_educ_IsGCSEMath.ClientID %>").val() == 2) {
                    //needs to test the value of control to validate
                    if (!args.IsValid) {
                        bAnyErrors = true;
                    }
                } else {
                    args.IsValid = true;
                }
            }

            if (oSrc.id == "BodyContent_Wizard1_cv_educ_ALLFundQualDetails") {
                //needs to test the value of control to validate
                if ($("#<%=ddl_educ_IsALLFund.ClientID %>").val() == 1) {
                    if (!args.IsValid) {
                        bAnyErrors = true;
                    }
                }
                else {
                    args.IsValid = true;
                }
            }
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
            COURSE_ID = _App._app_officeuse1_CourseId;
        }
        var course_lvl = COURSE_LEVEL_NUMER;
        var cour_id = COURSE_ID;
                %>
        var course_level =<%=course_lvl%> ;
        var course_id =<%=cour_id%> ;

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
                    //if (course_id == 82) {
                    //    $("#BodyContent_Wizard1_pLevel5Hide82a").hide();
                    //    $("#BodyContent_Wizard1_pLevel5Hide82").hide();
                    //}
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


            $("#<%=ddlAnyDisability.ClientID %>").change(function () {

                var state = false;
                var val = $(this).val();
                var skip = null;
                if (val == 1) {
                    // alert("Yes");// = "workPhoneValidator";
                    state = true;
                }
                else if (val == 2) {
                    state = false;
                    //alert("No");// 
                    //disable now
                    //                                
                }
                ControlEnable('#<%=ddlAnyDisabilityPrimary.ClientID %>', state);
              //  CustomValidatorEnable('<%=cvAnyDisabilityPrimary.ClientID %>', state);                
                ValidatorEnable($("#<%=rfvAnyDisabilityPrimary.ClientID %>"), state);
                // skip = "rfvAnyDisabilityPrimary";         
                //  var $skip = $("#" + skip)[0];
                //  alert($skip);//
                //  if (skip != "xxx") ValidatorEnable($skip, false);
                //   if (skip != "cellPhoneValidator") ValidatorEnable($skip, false);

            });


        });//end of ready

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
        //********* dependant questions checks

        //function CustomValidatorEnable(obj, state)
        //{
        //    //ddlAnyDisability
        //    //$(obj).attr('disabled', true);
        //    if (state ='false')  {
        //        $(obj).attr('disabled', true);
        //    }else{
        //        //  $("#"+obj+"").disabled = false;
        //        $(obj).attr('disabled', false);
        //    }

        //}

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

            <asp:WizardStep ID="WizardStep1" runat="server" Title="1: About You" StepType="Start">
                <%--------------%>
                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-6">
                            <div class="well">
                                <fieldset>
                                    <legend>Personal Information</legend>

                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Title *</label>
                                        <div class="col-md-8 col-sm-8">

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
                                    <%  //  }    %>
                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">First Name (s) *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtName" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_Name" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtName" ErrorMessage="* Name is required " class="required-field-indicator" />

                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtName" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Surname *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <div class="controls">
                                                <asp:TextBox ID="txtSurname" runat="server" class="form-control input-sm" />
                                                <asp:RequiredFieldValidator ID="rfv_Surname" runat="server" EnableClientScript="True"
                                                    ControlToValidate="txtSurname" ErrorMessage="* Surname is required " class="required-field-indicator" />

                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtSurname" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Gender *</label>
                                        <div class="col-md-8 col-sm-8">
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
                                        <label class="col-md-4 col-sm-4">Date of birth *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txtDOB" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
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
                                        <label class="col-md-4 col-sm-4">National Insurance Number *</label>
                                        <div class="col-md-8 col-sm-8">
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
                                        <label class="col-md-4 col-sm-4">Email *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txt_Email" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_Email" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_Email" ErrorMessage="* Email is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Email" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Email" ID="RegularExpressionValidator17" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Invalid Email address" class="required-field-indicator"></asp:RegularExpressionValidator>


                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>


                        <%--------------%>
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
                                        <label class="col-md-4 col-sm-4">Mobile Number *</label>
                                        <div class="col-md-8 col-sm-8">
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
                        <%--------------%>



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
                                        <label class="col-md-8 col-sm-8">If not British, please state country of legal residency and upload copy of resident permit here.</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtLegalResidency" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtLegalResidency" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>



                                            <input type="file" class="button medium blue" name="file" id="btnFileUpload_legalresidency" />
                                            <div id="progressbar_legalresidency" style="width: 100%; display: none;">
                                                <div>
                                                </div>
                                            </div>
                                            <div id="progressbar_message_legalresidency"></div>
                                            <input type="hidden" id="uploaded_file_legalresidency" name="uploaded_file_legalresidency" />
                                            <asp:TextBox ID="uploaded_file_path_legalresidency" runat="server" Visible="false" Text=""></asp:TextBox>
                                        </div>

                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Have you lived in the UK continuously over the last three years? *</label>
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


                                    <div class="form-group">
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
                                    </div>

                                    
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %> 

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">If you are a Non EU or UK national, can you please confirm how long you have lived in the UK?</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtNonEUUKHowLongLiveInUK" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtNonEUUKHowLongLiveInUK" ID="revNonEUUKHowLongLiveInUK" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you an EU/EEA national, arrived in the UK before 31/12/2020?</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlEUEAANational" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO" OnClientClick="DisableValidator('ddlEUEEAStatus');"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_YESNO1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="YesNo" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvEUEAA" runat="server" EnableClientScript="True"
                                               ClientValidationFunction="validateSelect"  ControlToValidate="ddlEUEAANational" ErrorMessage="* An answer is required " class="required-field-indicator" />                                    
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Which of the following status applies to you?</label>

                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlEUEEAStatus" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="EUEEAStatus"></asp:DropDownList>
                                            <asp:SqlDataSource ID="EUEEAStatus" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="EUEEAStatus" Type="String" />

                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                            <asp:RequiredFieldValidator ID="rfvEUEEAStatus" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlEUEEAStatus" ErrorMessage="* An answer is required " class="required-field-indicator" />

                                        </div>
                                    </div> 
                                    <%         
                                    } /*Questions to exclude for level 5 Adult (51)*/
                                    %> 

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

                                    
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %>                                  
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Religion *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlReligion" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_Religion"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_Religion" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Religion" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvReligion" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlReligion" ErrorMessage="* Religion is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvReligion" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlReligion" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    
                                    <%         
                                    } /*Questions to exclude for level 5 Adult (51)*/
                                    %> 


                                    <%-- <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Sexual Orientation *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlSexualOrientation" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_SexualOrientation"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_SexualOrientation" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Sexual Orientation" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvSexualOrientation" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlSexualOrientation" ErrorMessage="* Sexual Orientation is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvSexualOrientation" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlSexualOrientation" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

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


                                    
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have a Learner Support Plan (S139a) or an Education, Health and Care plan? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlHaveLearnerSupportProgram" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvHaveLearnerSupportProgram" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlHaveLearnerSupportProgram" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvHaveLearnerSupportProgram" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlHaveLearnerSupportProgram" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                     <%         
                                    } /*Questions to exclude for level 5 Adult (51)*/
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have access to a computer or other SMART media device?  *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlIsAccessToComputer" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvIsAccessToComputer" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlIsAccessToComputer" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvIsAccessToComputer" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlIsAccessToComputer" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                     <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have access to Face time, Skype, Microsoft Teams and Zoom?  *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlIsAccessToFaceTime" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvIsAccessToFaceTime" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlIsAccessToFaceTime" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvIsAccessToFaceTime" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlIsAccessToFaceTime" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                     <%         
                                    } /*Questions to exclude for level 5 Adult (51)*/
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have an email account and are able to send and receive documents through this medium?  *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlIsAccessToEmail" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvIsAccessToEmail" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlIsAccessToEmail" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvIsAccessToEmail" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlIsAccessToEmail" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you familiar with e-portfolios and confident that you would be able to upload your assignments through this medium?  *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlIsEPortoflioAware" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvIsEPortoflioAware" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlIsEPortoflioAware" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvIsEPortoflioAware" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlIsEPortoflioAware" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%--<div class="form-group">
                                        <label class="col-md-8 col-sm-8">How will you manage your work load, personal time and study commitments?  *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtManageWorkStudy" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfvManageWorkStudy" runat="server" EnableClientScript="False"
                                                ControlToValidate="txtManageWorkStudy" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                           

                                            
                                        </div>
                                    </div>--%>

                                   <%  
                                    if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                                    {
                                    %>										
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you an owner or part owner of the business? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlIsPartnerOfOwner" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True"
                                                ControlToValidate="ddlIsPartnerOfOwner" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlIsPartnerOfOwner" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%         
									} 
									%>
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Length of time at your home address? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtLengthOfAddress" TextMode="MultiLine" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtLengthOfAddress" ErrorMessage="* Required " class="required-field-indicator" />
                                            <%--<asp:RegularExpressionValidator Display="Dynamic" ControlToValidate ="txtAddress3" ID="RegularExpressionValidator15" ValidationExpression ="^[\s\S]{0,300}$" runat="server" ErrorMessage="Maximum 300 characters allowed." class="required-field-indicator" ></asp:RegularExpressionValidator>--%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have any pre-planned absences? If yes can you please provide dates? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtPrePlannedAbsence" TextMode="MultiLine" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="True"
                                                ControlToValidate="txtPrePlannedAbsence" ErrorMessage="* Required " class="required-field-indicator" />
                                            <%--<asp:RegularExpressionValidator Display="Dynamic" ControlToValidate ="txtAddress3" ID="RegularExpressionValidator15" ValidationExpression ="^[\s\S]{0,300}$" runat="server" ErrorMessage="Maximum 300 characters allowed." class="required-field-indicator" ></asp:RegularExpressionValidator>--%>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Please select your circumstances *</label>
                                        <div class="col-md-4 col-sm-4">

                                            <asp:DropDownList ID="ddlCircumstance" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_Circumstance"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_Circumstance" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Circumstances" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfvCircumstance" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddlCircumstance" ErrorMessage="* circumstance is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cvCircumstance" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddlCircumstance" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />


                                        </div>
                                    </div>
                                    
									<%         
									} /*Questions to exclude for level 5 Adult (51)*/
									%> 

                                </fieldset>
                            </div>
                        </div>
                        <%--------------%>
                    </div>
                </div>
                <%--------------%>

                <%--------------%>
                <div class="container-fluid submit-area"></div>
                <div class="denotesmandatory">Fields marked with * are mandatory.</div>


            </asp:WizardStep>

            <%--step2--%>

            <asp:WizardStep ID="WizardStep2" runat="server" Title="2: About Qualifications">

                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Education History</legend>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Prior level of achievement (please select your highest qualification achieved) *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_educ_HighestQual" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_educ_HighestQual">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_educ_HighestQual" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Qualifications" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_educ_HighestQual" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_educ_HighestQual" ErrorMessage="* level of achievement is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_educ_HighestQual" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_educ_HighestQual" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Have you achieved a GCSE in English A*-C *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_educ_IsGCSEEnglish" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_educ_IsGCSEEnglish">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_educ_IsGCSEEnglish" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="GCSE" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_educ_IsGCSEEnglish" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_educ_IsGCSEEnglish" ErrorMessage="* GCSE in English is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_educ_IsGCSEEnglish" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_educ_IsGCSEEnglish" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Have you achieved a GCSE in Maths A*-C *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_educ_IsGCSEMath" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_educ_IsGCSEMath">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_educ_IsGCSEMath" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="GCSE" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_educ_IsGCSEMath" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_educ_IsGCSEMath" ErrorMessage="* GCSE in Maths is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_educ_IsGCSEMath" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_educ_IsGCSEMath" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div> 
									
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">If you answered no to the above but have an equivalent qualification please state what this is in the box.</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_EquivalentQualification" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_educ_EquivalentQualification" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:CustomValidator ID="cv_educ_EquivalentQualification" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="txt_educ_EquivalentQualification" ErrorMessage="* Equivalent qualification is required" ClientValidationFunction="validateText" ValidateEmptyText="True" />
                                        </div>
                                    </div>

                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you enrolled at another institution? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_educ_IsEnrolledOther" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_educ_IsEnrolledOther" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_educ_IsEnrolledOther" ErrorMessage="* Enrolled at another institution is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_educ_IsEnrolledOther" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_educ_IsEnrolledOther" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%         
						            }  
                                    if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Please state previous school/college (if you left within the last 5 years)</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_PreviousCollege" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                        </div>
                                    </div>
                                    <%         
						            }  
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Please List any previous qualifications you have achieved including grade/level and date achieved (GCSE/GCE/CSE/NVQ/BTEC)</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_PreviousQual" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_educ_PreviousQual" ID="revEduPrevious" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">List any training received in the last 3 years include date taken [e.g. Health & Safety, Food Hygiene, Adult Protection, Moving & Handling, Customer Service, I.T., First Aid etc.]</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_PreviousTraining" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_educ_PreviousTraining" ID="revPreviousTraining" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%         
									}  
                                    if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you applying for an Advanced Learner Loan to fund your qualification? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_educ_IsALLFund" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_educ_IsALLFund" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_educ_IsALLFund" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_educ_IsALLFund" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_educ_IsALLFund" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">If yes can you confirm if you have taken out an Advanced Learner before and specify the qualifications below?</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_ALLFundQualDetails" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_educ_ALLFundQualDetails" ID="rev_educ_ALLFundQualDetails" ValidationExpression="^[\s\S]{0,800}$" runat="server" ErrorMessage="Maximum 800 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:CustomValidator ID="cv_educ_ALLFundQualDetails" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="txt_educ_ALLFundQualDetails" ErrorMessage="* Please confirm" ClientValidationFunction="validateText" ValidateEmptyText="True" />
                                        </div>
                                    </div>
                                    <%         
									} /*Questions to exclude for level 5 Adult (51)*/
									%> 

                                    <%--<div class="form-group">
                                        <label class="col-md-8 col-sm-8">What training, if any, do you have planned for the next 12 months? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_TrainingPlannedNext12Months" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_educ_TrainingPlannedNext12Months" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_educ_TrainingPlannedNext12Months" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                             <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate ="txt_educ_TrainingPlannedNext12Months" ID="revTrainingPlanned" ValidationExpression ="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator" ></asp:RegularExpressionValidator>
                                        </div>
                                    </div>--%>

                                    <%-- <div class="form-group">
                                        <label class="col-md-8 col-sm-8">What are your future work aspirations? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_educ_FutureInspirations" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_educ_FutureInspirations" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_educ_FutureInspirations" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                             <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate ="txt_educ_FutureInspirations" ID="revFutureInspirations" ValidationExpression ="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator" ></asp:RegularExpressionValidator>
                                        </div>
                                    </div>--%>
                                </fieldset>
                            </div>
                        </div>
                    </div>

                </div>

                <%--------------%>
                <div class="container-fluid submit-area"></div>
                <div class="denotesmandatory">Fields marked with * are mandatory.</div>


            </asp:WizardStep>

            <asp:WizardStep ID="WizardStep3" runat="server" Title="3: About Employer">


                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Employer's Details</legend>


                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Company Name *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_CompanyName" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_CompanyName" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_CompanyName" ErrorMessage="* Company Name is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_CompanyName" ID="revtxt_emp_CompanyName" ValidationExpression="^[\s\S]{0,200}$" runat="server" ErrorMessage="Maximum 200 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Employment Start Date *</label>
                                        <div class="col-md-6 col-sm-6">

                                            <asp:TextBox ID="txt_emp_EmpoyementStartDate" runat="server" class="form-control input-sm" CssClass="DatepickerInput" />
                                            <asp:CompareValidator
                                                ID="CompareValidator2" runat="server"
                                                Type="Date"
                                                Operator="DataTypeCheck"
                                                ControlToValidate="txt_emp_EmpoyementStartDate"
                                                ErrorMessage="Please enter a valid date." class="required-field-indicator" CultureInvariantValues="true">
                                            </asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="True"
                                                ControlToValidate="txt_emp_EmpoyementStartDate" ErrorMessage="* Employment Start Date is required " class="required-field-indicator" />
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Workplace Address (Where you are based) *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress1" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfvemp_WorkPlaceAddress1" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_WorkPlaceAddress1" ErrorMessage="* Address is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_WorkPlaceAddress1" ID="revtxt_emp_WorkPlaceAddress1" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6"></label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress2" runat="server" class="form-control input-sm" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_WorkPlaceAddress2" ID="revtxt_emp_WorkPlaceAddress2" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Town *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlaceAddress3" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_WorkPlaceAddress3" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_WorkPlaceAddress3" ErrorMessage="* Town is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_WorkPlaceAddress3" ID="revtxt_emp_WorkPlaceAddress3" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Post Code *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WorkPlacePostCode" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_WorkPlacePostCode" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_WorkPlacePostCode" ErrorMessage="* Post Code is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_WorkPlacePostCode" ID="revtxt_emp_WorkPlacePostCode" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Telephone Number *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_Tel" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_Tel" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_Tel" ErrorMessage="* Telephone Number is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Tel" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,20}$" runat="server" ErrorMessage="Maximum 20 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Tel" ID="RegularExpressionValidator7" ValidationExpression="^\d+?$" runat="server" ErrorMessage="Value must be a number." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Employer Contact Name (who you report to) *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_ContactName" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_ContactName" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_ContactName" ErrorMessage="* Contact Name is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_ContactName" ID="RegularExpressionValidator19" ValidationExpression="^[a-zA-Z ]*$" runat="server" ErrorMessage="Only letters allowed" class="required-field-indicator"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Position *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_Position" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_Position" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_Position" ErrorMessage="* Position is required " class="required-field-indicator" />
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-4 col-sm-4">Employer Email Address *</label>
                                        <div class="col-md-8 col-sm-8">
                                            <asp:TextBox ID="txt_emp_Email" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_Email" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_Email" ErrorMessage="* Email is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Email" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_Email" ID="RegularExpressionValidator12" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Invalid Email address" class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>


                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Company Details</legend>
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Business Sector *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_BusinessSector" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_emp_BusinessSector" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_BusinessSector" ErrorMessage="* Business Sector is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_BusinessSector" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%         
									} /*Questions to exclude for level 5 Adult (51)*/
									%> 
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Is the Company? *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:DropDownList ID="ddl_emp_CompanyEstablished" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_emp_CompanyEstablished"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_emp_CompanyEstablished" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Company Size" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_emp_CompanyEstablished" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_emp_CompanyEstablished" ErrorMessage="* Company Size is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_emp_CompanyEstablished" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_emp_CompanyEstablished" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">What are your usual hours of attendance? (include shift patterns if appropriate) and total working hours per week? *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:TextBox ID="txt_emp_WeeklyHours" runat="server" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_emp_WeeklyHours" ErrorMessage="* Business Sector is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_emp_WeeklyHours" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <%  
                                    if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                                    {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-6 col-sm-6">Are you self-employed? *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:DropDownList ID="ddl_emp_IsSelfEmployed" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_emp_IsSelfEmployed" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_emp_IsSelfEmployed" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_emp_IsSelfEmployed" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_emp_IsSelfEmployed" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%         
									}  
									%> 
                                    <%--<div class="form-group">
                                        <label class="col-md-6 col-sm-6">I confirm I have a contract of employment. *</label>
                                        <div class="col-md-6 col-sm-6">                                            
                                            <asp:CheckBox ID="chkConfirm16hrs" runat="server" Checked="true" Text="" />
                                             
                                            <asp:CustomValidator runat="server" id="cv_chkConfirm16hrs"  ControlToValidate=""  OnServerValidate="checkCheckBox" class="required-field-indicator" ErrorMessage="* Please check the tickbox to confirm." />

                                        </div>
                                    </div>--%>



                                    <%--<div class="form-group">
                                        <label class="col-md-6 col-sm-6">Is your employer paying your course fees? *</label>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:DropDownList ID="ddl_emp_IsEmployerPaying" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_emp_IsEmployerPaying" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_emp_IsEmployerPaying" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_emp_IsEmployerPaying" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_emp_IsEmployerPaying" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>
                                </fieldset>
                            </div>

                        </div>
                    </div>
                </div>

                <%--------------%>
                <div class="container-fluid submit-area"></div>
                <div class="denotesmandatory">Fields marked with * are mandatory.</div>


            </asp:WizardStep>


            <asp:WizardStep ID="WizardStep4" runat="server" Title="4: About Job Roles">
                <%  if (_App != null)
                    {
                        COURSE_LEVEL = (DSP.BAL.CourseLevel)Enum.ToObject(typeof(DSP.BAL.CourseLevel), _App._app_officeuse1_CourseLevel);
                    }
                %>

                <br />
                <div class="form-horizontal">
                    <div class="row show-grid">

                        <div class="col-lg-12">
                            <div class="well">
                                <fieldset>
                                    <legend>Current Job Roles</legend>

                                    

									
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">What is your job function?*</label>
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
									
                                    <%--Common Questions--%>
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">How long have you been in your current job role?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_HowLongWorkingJob" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_job_HowLongWorkingJob">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_job_HowLongWorkingJob" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="How long..." Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_job_HowLongWorkingJob" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_HowLongWorkingJob" ErrorMessage="* Your current job length is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_HowLongWorkingJob" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_HowLongWorkingJob" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">How long have you been working at your current employment?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_HowLongWorkingEmployer" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_job_HowLongWorkingEmployer">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_job_HowLongWorkingEmployer" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Howlongemployment" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_job_HowLongWorkingEmployer" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_HowLongWorkingEmployer" ErrorMessage="* Your working length with current employment is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_HowLongWorkingEmployer" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_HowLongWorkingEmployer" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                      
                                   <%-- <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have a current personal development plan?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_HaveCurrentDevPlan" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_HaveCurrentDevPlan" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_HaveCurrentDevPlan" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_HaveCurrentDevPlan" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_HaveCurrentDevPlan" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                    <%--<div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you aware of the Fundamental Standards?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsAwareFundamentalStd" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsAwareFundamentalStd" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsAwareFundamentalStd" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsAwareFundamentalStd" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsAwareFundamentalStd" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                      <%-- commons Questions --%>
                                 <%--   <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you require any further training and support to meet the needs and expectations of your role?*</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_IsFurtherTrainingNeeded" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_job_IsFurtherTrainingNeeded" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_IsFurtherTrainingNeeded" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_IsFurtherTrainingNeeded" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_IsFurtherTrainingNeeded" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                    </div>--%>
                                    <%         
                                        } /*Questions to exclude for level 5 Adult (51)*/
									%> 
                                     <%  /*Questions to exclude for level 5 Adult (51)*/
                                         if (_App._app_officeuse1_CourseLevel != 51 || _App._app_officeuse1_CourseLevel != 52)
                                         {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Which pathway is most relevant to your place of work? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_RelevantPathway" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_job_RelevantPathway">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_job_RelevantPathway" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblPathwaysLevel" Name="Header" PropertyName="Text" DefaultValue="Pathways" Type="String" />
                                                    <%-- <asp:Parameter Name="Header" DefaultValue="Pathways"  Type="String" />--%>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_job_RelevantPathway" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_RelevantPathway" ErrorMessage="* Your relevant pathway is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_RelevantPathway" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_RelevantPathway" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                   <%} %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have a current Job Description? If yes, please upload a copy here or please email to <a href="mailto:customerservice@accessskills.co.uk">customerservice@accessskills.co.uk</a>. *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_HaveJobDescription" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_HaveJobDescription" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_HaveJobDescription" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_HaveJobDescription" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_HaveJobDescription" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />

                                            <input type="file" class="button medium blue" name="file" id="btnFileUpload_havejobdescription_doc" />
                                            <div id="progressbar_havejobdescription_doc" style="width: 100%; display: none;">
                                                <div>
                                                </div>
                                                <div id="progressbar_message_havejobdescription_doc"></div>
                                                <input type="hidden" id="uploaded_file_havejobdescription" name="uploaded_file_havejobdescription" />
                                                <asp:TextBox ID="uploaded_file_path_havejobdescription_doc" runat="server" Visible="false" Text=""></asp:TextBox>

                                           </div>
                                        </div>
                                   </div>
                                                 <%--  <div class="form-group" >

                                                       <div class="col-md-8 col-sm-8">

                                                       </div>
                                                       <div class="col-md-4">
                                                       <asp:Button ID="DownloadFile" OnClick="bntDownloadFile_Click"  Text="Download" runat="server" />
                                                          <asp:TextBox ID="txt_FileData" runat="server" Visible="false" Text=""></asp:TextBox>

                                                           
                                                       </div>
                                                    </div>--%>
                                    <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel != 51)
                                    {
                                    %>
									
                                 <%--   <div class="form-group">
                                        <label class="col-md-8 col-sm-8">What are your main duties and responsibilities on a day to day basis? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:TextBox ID="txt_job_DailyMainDuties" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                            <asp:RequiredFieldValidator ID="rfv_job_DailyMainDuties" runat="server" EnableClientScript="False"
                                                ControlToValidate="txt_job_DailyMainDuties" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_job_DailyMainDuties" ID="revtxt_job_DailyMainDuties" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>--%>

<%--                                     <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Explain what other positions/responsibilities you have had within the organisation OR any previous work experience. *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_job_OtherPositionResponsabilities" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                                <asp:RequiredFieldValidator ID="rfv_job_OtherPositionResponsabilities" runat="server" EnableClientScript="False"
                                                    ControlToValidate="txt_job_OtherPositionResponsabilities" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_job_OtherPositionResponsabilities" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>--%>

                              <%--       <div class="form-group">
                                            <label class="col-md-8 col-sm-8">What would you say are your strengths? *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_job_AboutYourStrenghts" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />
                                                <asp:RequiredFieldValidator ID="rfv_job_AboutYourStrenghts" runat="server" EnableClientScript="False"
                                                    ControlToValidate="txt_job_AboutYourStrenghts" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_job_AboutYourStrenghts" ID="revtxt_job_AboutYourStrenghts" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>--%>
                               <%--         <div class="form-group">
                                            <label class="col-md-8 col-sm-8">What would you say are your areas for development? *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_job_AreasOfDevelopment" runat="server" TextMode="MultiLine" Rows="5" class="form-control input-sm" />

                                                <asp:RequiredFieldValidator ID="rfv_job_AreasOfDevelopment" runat="server" EnableClientScript="False"
                                                    ControlToValidate="txt_job_AreasOfDevelopment" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_job_AreasOfDevelopment" ID="revtxt_job_AreasOfDevelopment" ValidationExpression="^[\s\S]{0,8000}$" runat="server" ErrorMessage="Maximum 8000 characters allowed." class="required-field-indicator"></asp:RegularExpressionValidator>

                                            </div>
                                        </div> --%>                                 

									<%         
									} /*Questions to exclude for level 5 Adult (51)*/
									%> 
                                    <%-- Conditional Questions start here --%>

                                          <%-- Questions for Course level 2  --%>
                                    <% if (_App._app_officeuse1_CourseLevel == 20)
                                        {%>
                                  
                                     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you provide care or support to the service user?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_App_job_70" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_App_job_70" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_App_job_70" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_App_job_70" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_App_job_70" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                      <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you assist with eating and drinking?*</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_AssistEatingDrinking" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_AssistEatingDrinking" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_AssistEatingDrinking" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_AssistEatingDrinking" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_AssistEatingDrinking" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                        </div> 

                                    
                                    <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you take part in personal care to include: Assisting and Moving and Maintain and monitor nutrition?*</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_PersonalCareAssistingMoving" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_job_PersonalCareAssistingMoving" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_PersonalCareAssistingMoving" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_PersonalCareAssistingMoving" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_PersonalCareAssistingMoving" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                        </div> 

                                     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Promote health and wellbeing for the service users you support?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_App_job_71" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_App_job_71" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_App_job_71" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_App_job_71" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_App_job_71" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

<%--                                        <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you provide effective communication, where you’re communicating clearly and responsibly?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_App_job_72" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_App_job_72" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_App_job_72" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_App_job_72" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_App_job_72" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>


                                    <%} %>   <%-- End of Questions for Level 2 --%>



                                    <%-- Questions for Course level 3 Adult, 4 Adult--%>
                                    <% if (_App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 40)
                                        {%>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you involved in planning & implementing care?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_PlanImplementcare" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_PlanImplementcare" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_PlanImplementcare" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_PlanImplementcare" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_PlanImplementcare" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you write records & reports?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_WriteRecordReports" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_WriteRecordReports" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_WriteRecordReports" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_WriteRecordReports" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_WriteRecordReports" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>



                                    <%} %>   <%-- End of Level2, 3 Adult,3 Mental Health ,4 Adult Questions --%>

                                      <% if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 40)
                                       {%>
                                      <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you take part in supervisions?*</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_TakePartSupervisions" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rev_job_TakePartSupervisions" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_TakePartSupervisions" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_TakePartSupervisions" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_TakePartSupervisions" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                        </div>
             

                                    <%} %> 



                                    <%-- Questions for Course level 2 and 3 Adult --%>
                                    <% if (_App._app_officeuse1_CourseLevel == 20 || _App._app_officeuse1_CourseLevel == 30)
                                    {%>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you involved in social activities with the service user?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_SocialActivitieswithServiceUser" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_SocialActivitieswithServiceUser" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_SocialActivitieswithServiceUser" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_SocialActivitieswithServiceUser" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_SocialActivitieswithServiceUser" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div> 

                                    <%} %>   


                                    <%-- Questions for Course , 3 Adult, 3 Mental Health and 3 CYP --%>
                                    <% if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 32)
                                        {%>
                                    <%--   <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you have regular supervisions? *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_RegularSupervisions" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_job_RegularSupervisions" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_RegularSupervisions" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_RegularSupervisions" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_RegularSupervisions" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                        </div>--%>


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you involved in carrying out risk assessments? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_CarryoutRiskAssessment" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_CarryoutRiskAssessment" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_CarryoutRiskAssessment" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_CarryoutRiskAssessment" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_CarryoutRiskAssessment" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>


                                    <%} %>   <%-- End of Level2, 3 Adult and 3 CYP Questions --%>

                                    <%-- Questions for Course level 3 CYP --%>
                                    <% if (_App._app_officeuse1_CourseLevel == 30)
                                        {%>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you support CYP with education and development? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_SupportCYP" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_SupportCYP" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_SupportCYP" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_SupportCYP" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_SupportCYP" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you assess risk especially them that enable positive risk taking?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_PositiveRiskTaking" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_PositiveRiskTaking" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_PositiveRiskTaking" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_PositiveRiskTaking" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_PositiveRiskTaking" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>


                                    <%} %>   <%-- End of Level 3 CYP Questions --%>

                                    <%-- Questions for Course level 3 CYP, 3 Mental Health , 5 CYP--%>
                                    <% if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 32 || _App._app_officeuse1_CourseLevel == 50)
                                        {%>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you take part in safeguarding reports? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_SafeguardReports" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_SafeguardReports" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_SafeguardReports" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_SafeguardReports" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_SafeguardReports" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>







                                    <%} %>   <%-- End of Level 3 CYP Questions , 3 Mental Health , 5 CYP--%>

                                    <%-- Questions for Course level 3 CYP,5 CYP --%>
                                    <% if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 50)
                                        {%>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you review and implement support plans to include behaviour plans? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_ReviewSupportPlans" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_ReviewSupportPlans" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_ReviewSupportPlans" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_ReviewSupportPlans" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_ReviewSupportPlans" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Does your organisation provide residential services?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_OrgProvidesResidentialServices" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_OrgProvidesResidentialServices" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_OrgProvidesResidentialServices" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_OrgProvidesResidentialServices" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_OrgProvidesResidentialServices" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you work in partnership with other professionals? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_WorkPartnerProfessionals" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_WorkPartnerProfessionals" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_WorkPartnerProfessionals" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_WorkPartnerProfessionals" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_WorkPartnerProfessionals" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you work to support the resilience and well-being of CYP? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_CVPResilience" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_CVPResilience" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_CVPResilience" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_CVPResilience" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_CVPResilience" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you support communication, including the use of technology? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_TechCommunication" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_TechCommunication" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_TechCommunication" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_TechCommunication" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_TechCommunication" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <%} %>   <%-- End of Level 3 CYP, 5 CYP Questions --%>




                                    <%-- Questions for Level 3 Adult, 3 Mental Health --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 40)
                                    {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you a key worker?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_KeyWorker" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_KeyWorker" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_KeyWorker" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_KeyWorker" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_KeyWorker" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <%  } %>

                                    <%-- Questions for Level 3 Mental Health --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 32)
                                        {
                                    %>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you involved in therapy sessions? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_TherapySessions" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTherapySessions" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_TherapySessions" ErrorMessage="* An answer is required " class="required-field-indicator" />

                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you Contribute to promote positive mental health & well being? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_ContributeToMentalHealth" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_ContributeToMentalHealth" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_ContributeToMentalHealth" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_ContributeToMentalHealth" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_ContributeToMentalHealth" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you support individuals who suffer from depression, anxiety, phobias & health related issues? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_SupportIndvDepresionPhobias" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_SupportIndvDepresionPhobias" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_SupportIndvDepresionPhobias" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_SupportIndvDepresionPhobias" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_SupportIndvDepresionPhobias" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you work in partnerships with other professionals i.e. seeking help from professionals to create a balance? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_WorkinPartnershipswthProfesionals" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_WorkinPartnershipswthProfesionals" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_WorkinPartnershipswthProfesionals" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_WorkinPartnershipswthProfesionals" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_WorkinPartnershipswthProfesionals" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you take part in health promotion?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_HealthPromotion" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvHealthPromotion" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_HealthPromotion" ErrorMessage="* An answer is required " class="required-field-indicator" />

                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you act as an advocate?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_Advocate" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvAdvocate" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_Advocate" ErrorMessage="* An answer is required " class="required-field-indicator" />

                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you support service users to access other resources, including help/support groups?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_SupportServiceUsers" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvSupportServiceUsers" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_SupportServiceUsers" ErrorMessage="* An answer is required " class="required-field-indicator" />

                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you assess and review support plans? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_AssessReviewSupportPlans" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_AssessReviewSuportPlans" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_AssessReviewSupportPlans" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_AssessReviewSuportPlans" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_AssessReviewSupportPlans" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <%         
                                        } /*END OF IF QUESTIONS for Level 3 Mental Health*/
                                    %>

                                    <%-- Questions for LEVEL 4 Adult --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 40)
                                        {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you attend regular team meetings?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_TakePartMeetings" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_TakePartMeetings" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_TakePartMeetings" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_TakePartMeetings" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_TakePartMeetings" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you maintain your own personal development record?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_MaintainPersonalRecord" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_MaintainPersonalRecord" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_MaintainPersonalRecord" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_MaintainPersonalRecord" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_MaintainPersonalRecord" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you take part in risk assessments & ensure others comply?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_RiskAssessOthersComply" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_RiskAssessOthersComply" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_RiskAssessOthersComply" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_RiskAssessOthersComply" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_RiskAssessOthersComply" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you take part in safeguarding investigations?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_SafeguardInvestigations" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_SafeguardInvestigations" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_SafeguardInvestigations" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_SafeguardInvestigations" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_SafeguardInvestigations" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you work in a supportive role with service users & staff members? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_WorkSupportiveRole" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_WorkSupportiveRole" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_WorkSupportiveRole" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_WorkSupportiveRole" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_WorkSupportiveRole" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you ensure others follow policy and procedure? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsEnsureOthersFollowPolicy" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsEnsureOthersFollowPolicy" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsEnsureOthersFollowPolicy" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsEnsureOthersFollowPolicy" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsEnsureOthersFollowPolicy" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you take part in managing quality? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsTakePartInManagingQuality" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsTakePartInManagingQuality" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsTakePartInManagingQuality" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsTakePartInManagingQuality" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsTakePartInManagingQuality" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>


                                    <%         
                                        } /*END OF IF QUESTIONS for LEVEL 4 Adult*/
                                    %>

                                    <%-- Questions for Level 5 CYP, 5 Adult and 5 Apprenticeship--%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 50)
                                        {
                                    %>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you work in a management role? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_WorkMgtRole" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_WorkMgtRole" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_WorkMgtRole" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_WorkMgtRole" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_WorkMgtRole" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%         
                                        } /*END OF IF QUESTIONS for LEVEL 4 Adult*/
                                    %>


                                     <%-- Questions for Level 5 CYP, 5 Adult and 5 Apprenticeship--%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 50 || _App._app_officeuse1_CourseLevel == 51
                                              || _App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you undertake staff supervision and appraisals? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleStaffraisal" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleStaffraisal" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleStaffraisal" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsResponsibleStaffraisal" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleStaffraisal" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                      <%         
                                        } /*END OF IF QUESTIONS for LEVEL 4 Adult*/
                                    %>

                                     <%-- Questions for Level 5 CYP, 5 Adult and 5 Apprenticeship--%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 50 || _App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you respond to compliments and complaints?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_RespondCompliments" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_RespondCompliments" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_RespondCompliments" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_RespondCompliments" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_RespondCompliments" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                      <%         
                                        } /*END OF IF QUESTIONS for LEVEL 4 Adult*/
                                    %>

                                     <%  /*Questions to exclude for level 5 Adult (51)*/
                                    if (_App._app_officeuse1_CourseLevel == 50 || _App._app_officeuse1_CourseLevel == 52)
                                    {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you investigate safeguarding incidents? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsInvestigatingSafeguarding" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsInvestigatingSafeguarding" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsInvestigatingSafeguarding" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsInvestigatingSafeguarding" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsInvestigatingSafeguarding" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%         
									} /*Questions to exclude*/
									%> 
                                     <%-- Questions for Level 5 CYP, 5 Adult and 5 Apprenticeship--%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 50 || _App._app_officeuse1_CourseLevel == 51  || _App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you organise and lead staff meetings? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsOrganisingLeadStaffMeetings" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsOrganisingLeadStaffMeetings" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsOrganisingLeadStaffMeetings" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsOrganisingLeadStaffMeetings" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsOrganisingLeadStaffMeetings" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                     <%         
									} /*Questions to exclude*/
									%> 
                                     <%-- Questions for Level 5 CYP, 5 Adult and 5 Apprenticeship--%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 50 || _App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you review Health and Safety and complete risk assessments? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsEnsuringComplianceHS" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsEnsuringComplianceHS" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsEnsuringComplianceHS" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsEnsuringComplianceHS" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsEnsuringComplianceHS" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>


                                    <%         
                                        } /*END OF IF QUESTIONS for Level 5 CYP, 5 Adult,5 Apprenticeship*/
                                    %>

                                    <%-- Questions for Level 5 CYP --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 50)
                                        {
                                    %>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you lead on communication processes?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_LeadCommunicationProcesses" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_LeadCommunicationProcesses" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_LeadCommunicationProcesses" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_LeadCommunicationProcesses" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_LeadCommunicationProcesses" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you involved in staff recruitment and selection? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleRecruitment" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleRecruitment" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleRecruitment" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsResponsibleRecruitment" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleRecruitment" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you involved in undertaking staff induction such as the delivery of care certificate? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleStaffInduction" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleStaffInduction" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleStaffInduction" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsResponsibleStaffInduction" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleStaffInduction" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you contribute to the provision and monitoring of training? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleMonitoringStaff" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleMonitoringStaff" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleMonitoringStaff" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsResponsibleMonitoringStaff" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleMonitoringStaff" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you undertake the planning and reviewing of care? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsiblePlanningReviewing" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsResponsiblePlanningReviewing" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsiblePlanningReviewing" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsResponsiblePlanningReviewing" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsiblePlanningReviewing" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you implement and review policies, procedures and agreed ways of working? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsReviewAuditPolicies" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsReviewAuditPolicies" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsReviewAuditPolicies" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsReviewAuditPolicies" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsReviewAuditPolicies" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>



                                    <%         
                                        } /*END OF IF QUESTIONS for Level 5 CYP*/
                                    %>

                                    <%-- Questions for Level  5 Apprenticeship  --%>
                                   <%-- <%  if (_App._app_officeuse1_CourseLevel == 52)
                                        { 
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you contribute to the completion of the self-assessment process for regulators and local authorities? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsContributeSelfAssessment" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsContributeSelfAssessment" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsContributeSelfAssessment" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsContributeSelfAssessment" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsContributeSelfAssessment" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    <%         
                                        } /*END OF IF QUESTIONS for Level 5 CYP*/
                                    %>--%>

                                    <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 51 || _App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you write, review and audit policies and procedures? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsReviewAuditPolicy" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsReviewAuditPolicy" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsReviewAuditPolicy" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsReviewAuditPolicy" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsReviewAuditPolicy" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                     <%         
                                        } /*END OF IF QUESTIONS  */
                                    %>

                                    <%-- Questions for Level 5 Apprenticeship  --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %> 
                                    <%--<div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you lead partnership working with own team and other professionals? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsLeadPartnershipWorking" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsLeadPartnershipWorking" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsLeadPartnershipWorking" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsLeadPartnershipWorking" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsLeadPartnershipWorking" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you lead and ensure the provision delivers person centered care? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsLeadProvisionDelivers" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsLeadProvisionDelivers" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsLeadProvisionDelivers" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsLeadProvisionDelivers" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsLeadProvisionDelivers" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                 <%--   <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you responsible for managing key resources such as staff, food provisions, PPE, financial resources? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleKeyResources" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsResponsibleKeyResources" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleKeyResources" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsResponsibleKeyResources" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleKeyResources" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                    <%         
                                        } /*END OF IF QUESTIONS  */
                                    %>

                                    <%  //Questions for Level 5 Adult, 5 Apprenticeship
                                        if (_App._app_officeuse1_CourseLevel == 51 )
                                        {
                                    %> 
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you have responsibilities for staff recruitment?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_RecruitmentResponsibilities" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_RecruitmentResponsibilities" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_RecruitmentResponsibilities" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_RecruitmentResponsibilities" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_RecruitmentResponsibilities" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>
                                    <%         
                                        } /*END OF IF QUESTIONS  */
                                    %>
                                    
                                    <%-- Questions for Level 5 Apprenticeship  --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %> 
                                    <%--<div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you responsible for the management of quality & governance? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleManagingQuality" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsResponsibleManagingQuality" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleManagingQuality" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsResponsibleManagingQuality" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleManagingQuality" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

<%--                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do your responsibilities include the provision of staff induction and the delivery of the care certificate?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_StaffInductionCareCertificate" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rev_job_StaffInductionCareCertificate" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_StaffInductionCareCertificate" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_StaffInductionCareCertificate" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_StaffInductionCareCertificate" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Are you responsible for staff training, coaching and mentoring?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleStaffTraining" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsResponsibleStaffTraining" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleStaffTraining" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsResponsibleStaffTraining" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleStaffTraining" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                  <%--  <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do your responsibilities include business development planning, implementing service improvement & development? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsResponsibleIncludeDevelopment" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_IsResponsibleIncludeDevelopment" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsResponsibleIncludeDevelopment" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_IsResponsibleIncludeDevelopment" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsResponsibleIncludeDevelopment" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                     

                                    <%         
                                        } /*END OF IF QUESTIONS for Level 5 Adult, 5 Apprenticeship */
                                    %>

                                    <%-- Questions for Level 5 Apprenticeship --%>
                                    <%  if (_App._app_officeuse1_CourseLevel == 52)
                                        {
                                    %>



                                    <div class="form-group">
                                        <label class="col-md-12 col-sm-12">
                                            This programme is designed to develop your individual knowledge and experience in relation to the role of a leader in adult care. So we can determine your starting point with us, please indicate below to confirm your need to develop your  knowledge and experience in each topic listed. Please tell us if you possess a:<br />
                                            High level - of knowledge and experience in applying this Or Medium/low level - of knowledge and experience
                                        </label>

                                        <asp:SqlDataSource ID="SDS_LOWMEDIUMHIGH" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                            SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="Header" DefaultValue="LowMediumHigh" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>

<%--
                                    <div class="form-group">
                                        <label class="col-md-10 col-sm-10">
                                            Knowledge of statutory frameworks, standards, guidance and Codes of Practice in relation to the safe delivery of services in a health and social care setting.i.e. Care Act 2014, Fundamental Standards, Safeguarding and GDPR.*</label>
                                        <div class="col-md-2 col-sm-2">
                                            <asp:DropDownList ID="ddl_job_102_KnowledgeStatutoryFrameworks" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_LOWMEDIUMHIGH"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_102_KnowledgeStatutoryFrameworks" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_102_KnowledgeStatutoryFrameworks" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_102_KnowledgeStatutoryFrameworks" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_102_KnowledgeStatutoryFrameworks" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                 <%--   <div class="form-group">
                                        <label class="col-md-10 col-sm-10">
                                            Experience of managing a range of resources when delivering complex care to others.i.e. Staff recruitment and selection, budgeting, service user referral processes and additional support.*</label>
                                        <div class="col-md-2 col-sm-2">
                                            <asp:DropDownList ID="ddl_job_103_ExperienceOfManaging" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_LOWMEDIUMHIGH"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_103_ExperienceOfManaging" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_103_ExperienceOfManaging" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_103_ExperienceOfManaging" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_103_ExperienceOfManaging" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

                                <%--    <div class="form-group">
                                        <label class="col-md-10 col-sm-10">Ability to implement strategies to support others to manage the risks presented when balancing individual rights and professional duty of care i.e. Care planning (person centred), risk assessment, safeguarding investigations, service contingency planning. *</label>
                                        <div class="col-md-2 col-sm-2">
                                            <asp:DropDownList ID="ddl_job_104_AbilityImplementStrategies" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_LOWMEDIUMHIGH"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_104_AbilityImplementStrategies" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_104_AbilityImplementStrategies" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_104_AbilityImplementStrategies" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_104_AbilityImplementStrategies" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

<%--                                    <div class="form-group">
                                        <label class="col-md-10 col-sm-10 text">
                                            Experience of leading and supporting others to work in a person-centred which enhances the well-being and quality of life of individuals 
											i.e. Active participation practices and strategy, positive risk assessment, management of concerns and complaints processes, managing person centred care planning and development. *</label>
                                       
                                        
                                        <div class="col-md-2 col-sm-2">
                                            <asp:DropDownList ID="ddl_job_105_ExperienceLeadingSupporting" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_LOWMEDIUMHIGH"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_105_ExperienceLeadingSupporting" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_105_ExperienceLeadingSupporting" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_105_ExperienceLeadingSupporting" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_105_ExperienceLeadingSupporting" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>

<%--                                    <div class="form-group">
                                        <label class="col-md-10 col-sm-10">
                                            Carried out activities that monitor, evaluate and improve health, safety and risk management policies and practices in the service 
                                        i.e. process auditing, policy review, CQC inspection and self-assessment. *</label>
                                        <div class="col-md-2 col-sm-2">
                                            <asp:DropDownList ID="ddl_job_106_CarriedOutActivitiesMonitor" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_LOWMEDIUMHIGH"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_106_CarriedOutActivitiesMonitor" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_106_CarriedOutActivitiesMonitor" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_106_CarriedOutActivitiesMonitor" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_106_CarriedOutActivitiesMonitor" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>





                                    <%         
                                        } /*END OF IF QUESTIONS for Level 5 Apprenticeship*/
                                    %>

                                    <%--Last common Questions --%>

                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Is your employer happy with a virtual workplace observation visit to take place?*</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_AllowWorkplaceObsVisit" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_AllowWorkplaceObsVisit" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_AllowWorkplaceObsVisit" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_AllowWorkplaceObsVisit" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_AllowWorkplaceObsVisit" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>

                                    
									
                                    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">I confirm I have a contract of employment. *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:CheckBox ID="chk_job_Confirm16hrs" runat="server" Checked="true" Text="" />
                                            <asp:CustomValidator runat="server" ID="cv_chkConfirm16hrs" ControlToValidate="" OnServerValidate="checkCheckBox" class="required-field-indicator" ErrorMessage="* Please check the tickbox to confirm." />

                                            <asp:DropDownList ID="ddl_job_Confirm16hrsId" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                DataSourceID="SDS_ddl_job_Confirm16hrsId">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SDS_ddl_job_Confirm16hrsId" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Header" DefaultValue="Confirm16hrs" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_job_Confirm16hrsId" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_Confirm16hrsId" ErrorMessage="* Please select " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_ddl_job_Confirm16hrsId" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_Confirm16hrsId" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />


                                        </div>
                                    </div>
                                     


                                    <%--     <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Have you undertaken any previous management or leadership training? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_AnyPreviousManagement" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_AnyPreviousManagement" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_AnyPreviousManagement" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_AnyPreviousManagement" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_AnyPreviousManagement" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>


                                    <%--<div class="form-group">
                                <label class="col-md-8 col-sm-8">Are you responsible for staff task allocation and rotas? *</label>
                                <div class="col-md-4 col-sm-4">
                                    <asp:DropDownList ID="ddl_job_IsResponsibleTaskAllocationRotas" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleTaskAllocationRotas" runat="server" EnableClientScript="False"
                                        ControlToValidate="ddl_job_IsResponsibleTaskAllocationRotas" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                    <asp:CustomValidator ID="cv_job_IsResponsibleTaskAllocationRotas" runat="server" EnableClientScript="True" class="required-field-indicator"
                                        ControlToValidate="ddl_job_IsResponsibleTaskAllocationRotas" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                </div>
                            </div>--%>


                                    <%-- <div class="form-group">
                                <label class="col-md-8 col-sm-8">Are you responsible for organising referrals to other agencies? *</label>
                                <div class="col-md-4 col-sm-4">
                                    <asp:DropDownList ID="ddl_job_IsResponsibleOrganisingReferrals" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleOrganisingReferrals" runat="server" EnableClientScript="False"
                                        ControlToValidate="ddl_job_IsResponsibleOrganisingReferrals" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                    <asp:CustomValidator ID="cv_job_IsResponsibleOrganisingReferrals" runat="server" EnableClientScript="True" class="required-field-indicator"
                                        ControlToValidate="ddl_job_IsResponsibleOrganisingReferrals" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                </div>
                            </div>--%>

                                    <%--<div class="form-group">
                                <label class="col-md-8 col-sm-8">Are you responsible for organising partnerships? *</label>
                                <div class="col-md-4 col-sm-4">
                                    <asp:DropDownList ID="ddl_job_IsResponsibleOrganisingPartnerships" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleOrganisingPartnerships" runat="server" EnableClientScript="False"
                                        ControlToValidate="ddl_job_IsResponsibleOrganisingPartnerships" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                    <asp:CustomValidator ID="cv_job_IsResponsibleOrganisingPartnerships" runat="server" EnableClientScript="True" class="required-field-indicator"
                                        ControlToValidate="ddl_job_IsResponsibleOrganisingPartnerships" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                </div>
                            </div>--%>



                                    <%--    <div class="form-group">
                                        <label class="col-md-8 col-sm-8">Do you respond to complaints? *</label>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddl_job_IsRespondingToComplaints" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_job_IsRespondingToComplaints" runat="server" EnableClientScript="False"
                                                ControlToValidate="ddl_job_IsRespondingToComplaints" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                            <asp:CustomValidator ID="cv_job_IsRespondingToComplaints" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                ControlToValidate="ddl_job_IsRespondingToComplaints" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                        </div>
                                    </div>--%>


                                    <%--<div class="form-group">
                                <label class="col-md-8 col-sm-8">Are your responsible for writing the organisational development plan? *</label>
                                <div class="col-md-4 col-sm-4">
                                    <asp:DropDownList ID="ddl_job_IsResponsibleWritingDevPlan" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_job_IsResponsibleWritingDevPlan" runat="server" EnableClientScript="False"
                                        ControlToValidate="ddl_job_IsResponsibleWritingDevPlan" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                    <asp:CustomValidator ID="cv_job_IsResponsibleWritingDevPlan" runat="server" EnableClientScript="True" class="required-field-indicator"
                                        ControlToValidate="ddl_job_IsResponsibleWritingDevPlan" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                </div>
                            </div>--%>



                                    <%--<div class="form-group">
                                <label class="col-md-8 col-sm-8">Do you manage and lead staff meetings? *</label>
                                <div class="col-md-4 col-sm-4">
                                    <asp:DropDownList ID="ddl_job_HaveRegularStaffMeetings" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_job_HaveRegularStaffMeetings" runat="server" EnableClientScript="False"
                                        ControlToValidate="ddl_job_HaveRegularStaffMeetings" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                    <asp:CustomValidator ID="cv_job_HaveRegularStaffMeetings" runat="server" EnableClientScript="True" class="required-field-indicator"
                                        ControlToValidate="ddl_job_HaveRegularStaffMeetings" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                </div>
                            </div>--%>


                                    <%--<div class="form-group">
                                            <label class="col-md-8 col-sm-8">Which pathway is most relevant to your place of work? *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_RelevantPathway_L3" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value"
                                                    DataSourceID="SDS_job_RelevantPathway_L3">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SDS_job_RelevantPathway_L3" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                    SelectCommand="SP_GetApplicationOptions" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="Header" DefaultValue="PathwaysL3" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="rfv_job_RelevantPathway_L3" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_RelevantPathway_L3" ErrorMessage="* Your relevant pathway is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_RelevantPathway_L3" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_RelevantPathway_L3" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                        </div>--%>




                                    <%--<div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you have a current Job Description? If yes, please upload a copy here or please email to <a href="mailto:customerservice@accessskills.co.uk">customerservice@accessskills.co.uk</a>. *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_HaveJobDescription_L3" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_job_HaveJobDescription_L3" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_HaveJobDescription_L3" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_HaveJobDescription_L3" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_HaveJobDescription_L3" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />


                                                <input type="file" class="button medium blue" name="file" id="btnFileUpload_havejobdescription_l3" />
                                                <div id="progressbar_havejobdescription_l3" style="width: 100%; display: none;">
                                                    <div>
                                                    </div>
                                                </div>
                                                <div id="progressbar_message_havejobdescription_l3"></div>
                                                <input type="hidden" id="uploaded_file_havejobdescription_l3" name="uploaded_file_havejobdescription_l3" />
                                                <asp:TextBox ID="uploaded_file_path_havejobdescription_l3_doc" runat="server" Visible="false" Text=""></asp:TextBox>

                                            </div>
                                        </div>--%>


                                    <%--starts show conditional--%>

                                    <%--<div class="form-group">
                                            <label class="col-md-8 col-sm-8">Do you work in a supportive role with service users? *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_IsWorkSupportRoleServiceUsers" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_job_IsWorkSupportRoleServiceUsers" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_IsWorkSupportRoleServiceUsers" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_IsWorkSupportRoleServiceUsers" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_IsWorkSupportRoleServiceUsers" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                        </div>--%>


                                    <%--Questions for 85--%>




                                    <%--       <div class="form-group">
                                            <label class="col-md-8 col-sm-8">Are you involved in risk assessments? *</label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:DropDownList ID="ddl_job_IsInvolvedInRiskassessments" runat="server" class="form-control input-sm" DataTextField="Opt_Title" DataValueField="Opt_Value" DataSourceID="SDS_YESNO"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rev_job_IsInvolvedInRiskassessments" runat="server" EnableClientScript="False"
                                                    ControlToValidate="ddl_job_IsInvolvedInRiskassessments" ErrorMessage="* An answer is required " class="required-field-indicator" />
                                                <asp:CustomValidator ID="cv_job_IsInvolvedInRiskassessments" runat="server" EnableClientScript="True" class="required-field-indicator"
                                                    ControlToValidate="ddl_job_IsInvolvedInRiskassessments" ErrorMessage="* Please select" ClientValidationFunction="validateSelect" />
                                            </div>
                                     </div>--%>



                                    <%--end of questions to all level last step--%>
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
                    <h3>1- About You</h3>
                    <div>

                        <label class="col-md-8 col-sm-8 item_key">Title	</label>
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
						  
                       
                        <label class="col-md-8 col-sm-8 item_key">Email Address	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Email">
                            <asp:Literal ID="lit_App_Email" runat="server"></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">
                            Permanent Address
                            <br />
                            <br />
                            <br />
                        </label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_PermAddress1">
                            <asp:Literal ID="lit_App_PermAddress1" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Post Code	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_PermPostCode">
                            <asp:Literal ID="lit_App_PermPostCode" runat="server"></asp:Literal></label>
                        
                        <label class="col-md-8 col-sm-8 item_key">Home Telephone Number	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_HomeTel">
                            <asp:Literal ID="lit_App_HomeTel" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Mobile Number	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Mobile">
                            <asp:Literal ID="lit_App_Mobile" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Nationality	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Nationality">
                            <asp:Literal ID="lit_App_Nationality" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">If not British, please state country of legal residency </label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_LegalResidency">
                            <asp:Literal ID="lit_App_LegalResidency" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Have you lived in the UK continuously over the last three years?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsLivedEULast3Years">
                            <br />
                            <asp:Literal ID="lit_App_IsLivedEULast3Years" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">If no please state date of entry into the UK	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_LivedEntryDate">
                            <br />
                            <asp:Literal ID="lit_App_LivedEntryDate" runat="server"></asp:Literal></label>


                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						 <label class="col-md-8 col-sm-8 item_key">If you are a Non EU or UK national, can you please confirm how long you have lived in the UK?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_NonEUUKHowLongLiveInUK">
                            <br />
                            <asp:Literal ID="lit_App_NonEUUKHowLongLiveInUK" runat="server"></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Are you an EU/EEA national, arrived in the UK before 31/12/2020?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_EUEEANational">
                            <br />
                            <asp:Literal ID="lit_App_EUEEANational" runat="server"></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Which of the following status applies to you?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_EUEEAStatus">
                            <br />
                            <asp:Literal ID="lit_App_EUEEAStatus" runat="server"></asp:Literal></label>
			
						<%         
						} /*Questions to exclude for level 5 Adult (51)*/
						%> 

                       
                        <label class="col-md-8 col-sm-8 item_key">Ethnicity	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Ethnicity">
                            <asp:Literal ID="lit_App_Ethnicity" runat="server"></asp:Literal></label>

                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						  <label class="col-md-8 col-sm-8 item_key">Religion	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Religion">
                            <asp:Literal ID="lit_App_Religion" runat="server"></asp:Literal></label>			
						

                        <%--  <label class="col-md-8 col-sm-8 item_key">Sexual Orientation	</label>
                                                <label class="col-md-4 col-sm-4 item_value" id="App_SexualOrientation">
                                                    <asp:Literal ID="lit_App_SexualOrientation" runat="server"></asp:Literal></label>--%>
                         

                        <%         
						} /*Questions to exclude for level 5 Adult (51)*/
						%> 
                  
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
                        
                        
                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						<label class="col-md-8 col-sm-8 item_key">Do you have a Learner Support Plan (S139a) or an Education, Health and Care plan? 	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_HaveLearnerSupportProgram">
                            <br />
                            <asp:Literal ID="lit_App_HaveLearnerSupportProgram" runat="server"></asp:Literal></label>			
						<%         
						} /*Questions to exclude for level 5 Adult (51)*/
						%> 
                        
                        <%-- <label class="col-md-8 col-sm-8 item_key">Programme Applied For	</label>
                                                <label class="col-md-4 col-sm-4 item_value" id="App_ProgramAppliedFor">
                                                    <asp:Literal ID="lit_App_ProgramAppliedFor" runat="server"></asp:Literal></label>--%>
                        <label class="col-md-8 col-sm-8 item_key">Do you have access to a computer or other SMART media device?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsAccessToComputer">
                            <asp:Literal ID="lit_App_IsAccessToComputer" runat="server"></asp:Literal></label>
                       
                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						  <label class="col-md-8 col-sm-8 item_key">Do you have access to Face time, Skype, Microsoft Teams and Zoom?</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsAccessToFaceTime">
                            <asp:Literal ID="lit_App_IsAccessToFaceTime" runat="server"></asp:Literal></label>			
						<%         
						} /*Questions to exclude for level 5 Adult (51)*/
						%> 
                      
                        <label class="col-md-8 col-sm-8 item_key">Do you have an email account and are able to send and receive documents through this medium?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsAccessToEmail">
                            <br />
                            <asp:Literal ID="lit_App_IsAccessToEmail" runat="server"></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Are you familiar with e-portfolios and confident that you would be able to upload your assignments through this medium?  	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsEPortoflioAware">
                            <br />
                            <asp:Literal ID="lit_App_IsEPortoflioAware" runat="server"></asp:Literal></label>
                        <%-- <label class="col-md-8 col-sm-8 item_key">How will you manage your work load, personal time and study commitments?	</label>
                                                <label class="col-md-4 col-sm-4 item_value" id="App_ManageWorkStudy">
                                                    <asp:Literal ID="lit_App_ManageWorkStudy" runat="server"></asp:Literal></label>--%>
                       
                        <%  
                        if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                        {
                        %>	
						  <label class="col-md-8 col-sm-8 item_key">Are you an owner or part owner of the business?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_IsPartnerOfOwner">
                            <asp:Literal ID="lit_App_IsPartnerOfOwner" runat="server"></asp:Literal></label>
			            <%         
						} 
						%>
                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>

                        <label class="col-md-8 col-sm-8 item_key">Length of time at your home address?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_LengthOfAddress">
                            <asp:Literal ID="lit_App_LengthOfAddress" runat="server"></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you have any pre-planned absences? If yes can you please provide dates?	</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_PrePlannedAbsence">
                            <asp:Literal ID="lit_App_PrePlannedAbsence" runat="server"></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Your circumstances</label>
                        <label class="col-md-4 col-sm-4 item_value" id="App_Circumstance">
                            <asp:Literal ID="lit_App_Circumstance" runat="server"></asp:Literal></label>

						<%         
						} /*Questions to exclude for level 5 Adult (51)*/
						%> 
                      
                    </div>

                    <h3>2- About Qualifications</h3>
                    <div>

                        <label class="col-md-8 col-sm-8 item_key">
                            Prior level of achievement (please select your highest qualification achieved)<br />
                            <br />
                            <br />
                        </label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_HighestQual'>
                            <asp:Literal ID='lit_App_educ_HighestQual' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Have you achieved a GCSE in English A*-C	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_IsGCSEEnglish'>
                            <asp:Literal ID='lit_App_educ_IsGCSEEnglish' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Have you achieved a GCSE in Maths A*-C	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_IsGCSEMath'>
                            <asp:Literal ID='lit_App_educ_IsGCSEMath' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">If you answered no to the above but have an equivalent qualification please state what this is in the box.</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_EquivalentQualification'>
                            <asp:Literal ID='lit_App_educ_EquivalentQualification' runat='server'></asp:Literal></label>

                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						  <label class="col-md-8 col-sm-8 item_key">Are you enrolled at another institution? 	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_IsEnrolledOther'>
                            <asp:Literal ID='lit_App_educ_IsEnrolledOther' runat='server'></asp:Literal></label>                        
                        <%         
						}  
                        if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                        {
                        %> 
                        <label class="col-md-8 col-sm-8 item_key">Please state previous school/college (if you left within the last 5 years) 	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_PreviousCollege'>
                            <asp:Literal ID='lit_App_educ_PreviousCollege' runat='server'></asp:Literal></label>

                        <%         
						}  
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %> 
                        <label class="col-md-8 col-sm-8 item_key">Please List any previous qualifications you have achieved including grade/level and date achieved (GCSE/GCE/CSE/NVQ/BTEC)	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_PreviousQual'>
                            <br />
                            <asp:Literal ID='lit_App_educ_PreviousQual' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">List any training received in the last 3 years include date taken [e.g. Health & Safety, Food Hygiene, Adult Protection, Moving & Handling, Customer Service, I.T., First Aid etc.]	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_PreviousTraining'>
                            <br />
                            <br />
                            <asp:Literal ID='lit_App_educ_PreviousTraining' runat='server'></asp:Literal></label>
                        <%         
						}  
                        if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                        {
                        %> 
                        <label class="col-md-8 col-sm-8 item_key">Are you applying for an Advanced Learner Loan to fund your qualification?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_IsALLFund'>
                            <asp:Literal ID='lit_App_educ_IsALLFund' runat='server'></asp:Literal></label>
                        <br />

                        <label class="col-md-8 col-sm-8 item_key">If yes can you confirm if you have taken out an Advanced Learner before and specify the qualifications below?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_ALLFundQualDetails'>
                            <br />
                            <asp:Literal ID='lit_App_educ_ALLFundQualDetails' runat='server'></asp:Literal></label>
			
                        <%         
                        } /*Questions to exclude for level 5 Adult (51)*/
                        %> 
                      
                        <%--  <label class="col-md-8 col-sm-8 item_key">What training, if any, do you have planned for the next 12 months?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_TrainingPlannedNext12Months'>
                            
                            <asp:Literal ID='lit_App_educ_TrainingPlannedNext12Months' runat='server'></asp:Literal></label>--%>

                        <%--<label class="col-md-8 col-sm-8 item_key">What are your future work aspirations?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_educ_FutureInspirations'>
                          
                            <asp:Literal ID='lit_App_educ_FutureInspirations' runat='server'></asp:Literal></label>--%>
                    </div>
                    <h3>3- About Employer </h3>
                    <div>

                        <label class="col-md-8 col-sm-8 item_key">Company Name  	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_CompanyName'>
                            <asp:Literal ID='lit_App_emp_CompanyName' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Employment Start Date  	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_EmpoyementStartDate'>
                            <asp:Literal ID='lit_App_emp_EmpoyementStartDate' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">
                            Workplace Address
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
                        <label class="col-md-8 col-sm-8 item_key">Employer Contact Name (who you report to)	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_ContactName'>
                            <asp:Literal ID='lit_App_emp_ContactName' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">Position	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_Position'>
                            <asp:Literal ID='lit_App_emp_Position' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Employer Email Address</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_Email'>
                            <asp:Literal ID='lit_App_emp_Email' runat='server'></asp:Literal></label>

                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						<label class="col-md-8 col-sm-8 item_key">Business Sector	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_BusinessSector'>
                            <asp:Literal ID='lit_App_emp_BusinessSector' runat='server'></asp:Literal></label>			
                        <%         
                        } /*Questions to exclude for level 5 Adult (51)*/
                        %> 
                        
                        <label class="col-md-8 col-sm-8 item_key">Company Size </label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_CompanyEstablished'>
                            <asp:Literal ID='lit_App_emp_CompanyEstablished' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">What are your usual hours of attendance? (include shift patterns if appropriate) and total working hours per week? 	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_WeeklyHours'>
                            <asp:Literal ID='lit_App_emp_WeeklyHours' runat='server'></asp:Literal></label>
                        <%  
                        if (_App._app_officeuse1_CourseLevel != 51 && _App._app_officeuse1_CourseLevel != 20)
                        {
                        %> 
						  <label class="col-md-8 col-sm-8 item_key">Are you self-employed?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_IsSelfEmployed'>
                            <asp:Literal ID='lit_App_emp_IsSelfEmployed' runat='server'></asp:Literal></label>
                   			
                        <%         
                        } 
                        %> 
                           <%--<label class="col-md-8 col-sm-8 item_key">Is your employer paying your course fees?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_emp_IsEmployerPaying'>
                            <asp:Literal ID='lit_App_emp_IsEmployerPaying' runat='server'></asp:Literal></label>--%>
                    </div>
                    <h3>4- About Job Roles</h3>

                    <div>

						   <label class="col-md-8 col-sm-8 item_key">What is your job function:	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_JobFunction'>
                            <asp:Literal ID='lit_App_job_JobFunction' runat='server'></asp:Literal></label>
                        
                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">How long have you been in your current job role	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_HowLongWorkingJob'>
                            <asp:Literal ID='lit_App_job_HowLongWorkingJob' runat='server'></asp:Literal></label>
                        <label class="col-md-8 col-sm-8 item_key">How long have you been working at your current employment?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_HowLongWorkingEmployer'>
                            <asp:Literal ID='lit_App_job_HowLongWorkingEmployer' runat='server'></asp:Literal></label>

<%--                        <label class="col-md-8 col-sm-8 item_key">Do you have a current personal development plan?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_HaveCurrentDevPlan'>
                            <asp:Literal ID='lit_App_job_HaveCurrentDevPlan' runat='server'></asp:Literal></label>--%>

<%--                        <label class="col-md-8 col-sm-8 item_key">Are you aware of the Fundamental Standards?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsAwareFundamentalStd'>
                            <asp:Literal ID='lit_App_job_IsAwareFundamentalStd' runat='server'></asp:Literal></label>
                         --%>
                       <%-- <label class="col-md-8 col-sm-8 item_key">Do you require any further training and support to meet the needs and expectations of your role?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsFurtherTrainingNeeded'>
                            <br />
                            <asp:Literal ID='lit_App_job_IsFurtherTrainingNeeded' runat='server'></asp:Literal></label>--%>

                     
                        <%         
                            } /*Questions to exclude for level 5 Adult (51)*/
                        %> 
                           <%  /*Questions to exclude for level 5 Adult (51)*/
                               if (_App._app_officeuse1_CourseLevel != 51 || _App._app_officeuse1_CourseLevel != 52)
                               {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Which pathway is most relevant to your place of work?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_RelevantPathway'>
                            <asp:Literal ID='lit_App_job_RelevantPathway' runat='server'></asp:Literal></label>
                        <% } %>
                        <label class="col-md-8 col-sm-8 item_key">Do you have a current Job Description? If yes, please upload a copy here or please email to <a href="mailto:customerservice@accessskills.co.uk">customerservice@accessskills.co.uk</a>. </label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_HaveJobDescription'>
                            <asp:Literal ID='lit_App_job_HaveJobDescription' runat='server'></asp:Literal></label>

                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel != 51)
                        {
                        %>
						<%-- <label class="col-md-8 col-sm-8 item_key">What are your main duties and responsibilities on a day to day basis?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_DailyMainDuties'>
                            <asp:Literal ID='lit_App_job_DailyMainDuties' runat='server'></asp:Literal></label>--%>


                        <%--<label class="col-md-8 col-sm-8 item_key">Explain what other positions/responsibilities you have had within the organisation OR any previous work experience.	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_OtherPositionResponsabilities'>
                            <br />
                            <asp:Literal ID='lit_App_job_OtherPositionResponsabilities' runat='server'></asp:Literal></label>--%>


<%--                        <label class="col-md-8 col-sm-8 item_key">What would you say are your strengths?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_AboutYourStrenghts'>
                            <asp:Literal ID='lit_App_job_AboutYourStrenghts' runat='server'></asp:Literal></label>--%>

                       <%-- <label class="col-md-8 col-sm-8 item_key">What would you say are your areas for development?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_AreasOfDevelopment'>
                            <asp:Literal ID='lit_App_job_AreasOfDevelopment' runat='server'></asp:Literal></label>
			--%>
                        <%         
                        } /*Questions to exclude for level 5 Adult (51)*/
                        %> 
                        
                        <%-- Questions for Course level 2  --%>
                        <% if (_App._app_officeuse1_CourseLevel == 20)
                            {%>

                        <label class="col-md-8 col-sm-8 item_key">Do you provide care or support to the service user?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_70'>
                            <asp:Literal ID='lit_App_job_70' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you assist with eating and drinking?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_AssistEatingDrinking'>
                            <asp:Literal ID='lit_App_job_AssistEatingDrinking' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Do you take part in personal care to include: Assisting and Moving and Maintain and monitor nutrition?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_PersonalCareAssistingMoving'>
                            <asp:Literal ID='lit_App_job_PersonalCareAssistingMoving' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Promote health and wellbeing for the service users you support?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_71'>
                            <asp:Literal ID='lit_App_job_71' runat='server'></asp:Literal></label>

                        
                        <%-- <label class="col-md-8 col-sm-8 item_key">Do you provide effective communication, where you’re communicating clearly and responsibly?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_72'>
                            <asp:Literal ID='lit_App_job_72' runat='server'></asp:Literal></label>--%>

                        <% } %>  <%-- End of Questions--  Course level 2--%>
                          

                        <%-- Questions for Course level 2, 4 Adult, 3 Adult,3 Mental Health  --%>
                        <% if (_App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 32 || _App._app_officeuse1_CourseLevel == 40)
                            {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Are you involved in planning & implementing care?</label>
                            <label class='col-md-4 col-sm-4 item_value' id='App_job_PlanImplementcare'>
                                <asp:Literal ID='lit_App_job_PlanImplementcare' runat='server'></asp:Literal></label>

                        
                        <label class="col-md-8 col-sm-8 item_key">Do you write records & reports?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_WriteRecordReports'>
                            <asp:Literal ID='lit_App_job_WriteRecordReports' runat='server'></asp:Literal></label>


                        <% } %>  <%-- End of Questions--  Course level 2, 4 Adult, 3 Adult,3 Mental Health--%>

                        <%-- Questions for Course level 2, 3 Adult,3 Mental Health,3 CYP, 4 Adult  --%>
                        <% if (_App._app_officeuse1_CourseLevel == 30 
                               || _App._app_officeuse1_CourseLevel == 31                            
                               || _App._app_officeuse1_CourseLevel == 40)
                            {
                        %>
                         
                         <label class="col-md-8 col-sm-8 item_key">Do you take part in supervisions?	</label>
                            <label class='col-md-4 col-sm-4 item_value' id='App_job_TakePartSupervisions'>
                                <asp:Literal ID='lit_App_job_TakePartSupervisions' runat='server'></asp:Literal></label>


                        <% } %>    <%--End of  Questions-- for Course level 2, 3 Adult,3 Mental Health,3 CYP, 4 Adult--%>

                        <%-- Questions for Course level 2 and 3 Adult --%>
                        <% if (_App._app_officeuse1_CourseLevel == 20 || _App._app_officeuse1_CourseLevel == 30)
                        {%>
                        <label class="col-md-8 col-sm-8 item_key">Are you involved in social activities with the service user?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_SocialActivitieswithServiceUser'>
                            <asp:Literal ID='lit_App_job_SocialActivitieswithServiceUser' runat='server'></asp:Literal></label>
                         
                        <% } %>  

                        <%-- Questions for Course level 2, 3 Adult, 3 Mental Health and 3 CYP --%>
                        <% if (_App._app_officeuse1_CourseLevel == 20 || _App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 32)
                            {%>

                        <label class="col-md-8 col-sm-8 item_key">Are you involved in carrying out risk assessments?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_CarryoutRiskAssessment'>
                            <asp:Literal ID='lit_App_job_CarryoutRiskAssessment' runat='server'></asp:Literal></label>

                        <% } %><%--End of Questions for Course level 2, 3 Adult, 3 Mental Health and 3 CYP --%>

                        <%-- Questions for Course level 3 CYP --%>
                        <% if (_App._app_officeuse1_CourseLevel == 30)
                            {%>

                        <label class="col-md-8 col-sm-8 item_key">Do you support CYP with education and development?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_SupportCYP'>
                            <asp:Literal ID='lit_App_job_SupportCYP' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you assess risk especially them that enable positive risk taking?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_PositiveRiskTaking'>
                            <asp:Literal ID='lit_App_job_PositiveRiskTaking' runat='server'></asp:Literal></label>

                        <% } %>  <%-- End of  Questions for Course level 3 CYP --%>

                        <%-- Questions-- Level 3CYP, 3 Mental Health, 5CYP--%>
                        <% if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 32 || _App._app_officeuse1_CourseLevel == 50)
                            {%>
                        <label class="col-md-8 col-sm-8 item_key">Do you take part in Safeguarding Reports?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_SafeguardReports'>
                            <asp:Literal ID='lit_App_job_SafeguardReports' runat='server'></asp:Literal></label>



                        <% } %>   <%--End of Questions-- Level 3CYP, 3 Mental Health, 5CYP--%>

                        <%-- Questions for Course level 3 CYP,5 CYP --%>
                        <% if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 50)
                            {%>
                        <label class="col-md-8 col-sm-8 item_key">Do you review and implement support plans to include behaviour plans?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_ReviewSupportPlans'>
                            <asp:Literal ID='lit_App_job_ReviewSupportPlans' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Does your organisation provide residential services?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_OrgProvidesResidentialServices'>
                            <asp:Literal ID='lit_App_job_OrgProvidesResidentialServices' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you work in partnership with other professionals?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_WorkPartnerProfessionals'>
                            <asp:Literal ID='lit_App_job_WorkPartnerProfessionals' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you work to support the resilience and well-being of CYP?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_CVPResilience'>
                            <asp:Literal ID='lit_App_job_CVPResilience' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Do you support communication, including the use of technology?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_TechCommunication'>
                            <asp:Literal ID='lit_App_job_TechCommunication' runat='server'></asp:Literal></label>

                        <% } %>  <%--End of Questions for Course level 3 CYP,5 CYP --%>

                        <%-- Questions for Level 3 Adult, 3 Mental Health --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 30 || _App._app_officeuse1_CourseLevel == 31 || _App._app_officeuse1_CourseLevel == 40)
                        {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Are you a key worker?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_KeyWorker'>
                            <asp:Literal ID='lit_App_job_KeyWorker' runat='server'></asp:Literal></label>



                        <% }/*END OF IF QUESTIONS Course Level 3 Adult , Leval 3  Mental Health*/ %>

                        <%-- Questions for Level 3 Mental Health --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 32)
                            {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Are you involved in therapy sessions?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_TherapySessions'>
                            <asp:Literal ID='lit_App_job_TherapySessions' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you contribute to promote positive mental health and well being?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_ContributeToMentalHealth'>
                            <asp:Literal ID='lit_App_job_ContributeToMentalHealth' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you support individuals who suffer from depression, anxiety, phobias and health related issues?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_SupportIndvDepressionPhobias'>
                            <asp:Literal ID='lit_App_job_SupportIndvDepressionPhobias' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you work in partnership with other professionals i.e. seeking help from Professionals to create a balance?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_WorkinPartnershipswthProfessionals'>
                            <asp:Literal ID='lit_App_job_WorkinPartnershipswthProfessionals' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you take part in Health promotion?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_HealthPromotion'>
                            <asp:Literal ID='lit_App_job_HealthPromotion' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Do you act as an advocate?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App__job_Advocate'>
                            <asp:Literal ID='lit_App__job_Advocate' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you support service users to access other resources, including help/support?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_SupportServiceUsers'>
                            <asp:Literal ID='lit_App_job_SupportServiceUsers' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you assess and review support plans?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_AssessReviewSupportPlans'>
                            <asp:Literal ID='lit_App_job_AssessReviewSupportPlans' runat='server'></asp:Literal></label>



                        <%} /*END OF IF QUESTIONS Course Level 3  Mental Health*/  %>

                        <%-- Questions for LEVEL 4 Adult--%>
                        <%  if (_App._app_officeuse1_CourseLevel == 40)
                            {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Do you attend regular team meetings?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_TakePartMeetings'>
                            <asp:Literal ID='lit_App_job_TakePartMeetings' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Do you maintain your own personal development record?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_MaintainPersonalRecord'>
                            <asp:Literal ID='lit_App_job_MaintainPersonalRecord' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you take part in managing quality?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsTakePartInManagingQuality'>
                            <asp:Literal ID='lit_App_job_IsTakePartInManagingQuality' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you ensure others follow policy and procedure?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsEnsureOthersFollowPolicy'>
                            <asp:Literal ID='lit_App_job_IsEnsureOthersFollowPolicy' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Do you take part in risk assessments & ensure others comply?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_RiskAssessOthersComply'>
                            <asp:Literal ID='lit_App_job_RiskAssessOthersComply' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you take part in safeguarding investigations </label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_SafeguardInvestigations'>
                            <asp:Literal ID='lit_App_job_SafeguardInvestigations' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you work in a supportive role with service users & staff members?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_WorkSupportiveRole'>
                            <asp:Literal ID='lit_App_job_WorkSupportiveRole' runat='server'></asp:Literal></label>



                        <%} /*END OF IF QUESTIONS Course Leval 4 Adult*/  %>

                        <%-- Questions for Level 5 CYP, 5 Adult and 5 Apprenticeship--%>
                        <%  if (_App._app_officeuse1_CourseLevel == 50 
                                || _App._app_officeuse1_CourseLevel == 51                                              
                                || _App._app_officeuse1_CourseLevel == 52)
                            {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Do you undertake staff supervision and appraisals?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleStaffAppraisal'>
                            <asp:Literal ID='lit_App_job_IsResponsibleStaffAppraisal' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you organise and lead staff meetings?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsOrganisingLeadStaffMeetings'>
                            <asp:Literal ID='lit_App_job_IsOrganisingLeadStaffMeetings' runat='server'></asp:Literal></label>
                        <%         
                        } /*Questions to exclude for level 5 Adult (51)*/
                        %> 
                        <%  /*Questions to exclude for level 5 Adult (51)*/
                        if (_App._app_officeuse1_CourseLevel == 50)
                        {
                        %>								
                        <label class="col-md-8 col-sm-8 item_key">Do you review Health and Safety and complete risk assessments?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsEnsuringComplianceHS'>
                            <asp:Literal ID='lit_App_job_IsEnsuringComplianceHS' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you work in a management role?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_WorkMgtRole'>
                            <asp:Literal ID='lit_App_job_WorkMgtRole' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you investigate safeguarding incidents?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsInvestigatingSafeguarding'>
                            <asp:Literal ID='lit_App_job_IsInvestigatingSafeguarding' runat='server'></asp:Literal></label>


                        <label class="col-md-8 col-sm-8 item_key">Do you respond to compliments and complaints?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_RespondCompliments'>
                            <asp:Literal ID='lit_App_job_RespondCompliments' runat='server'></asp:Literal></label>



                        <%} /*END OF IF QUESTIONS Course Leval 5 CYP, 5 Adult, 5 Apprenticeship*/  %>

                        <%-- Questions for Level 5 CYP --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 50)
                            {
                        %>

                        <label class="col-md-8 col-sm-8 item_key">Are you involved in staff recruitment and selection?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleRecruitment'>
                            <asp:Literal ID='lit_App_job_IsResponsibleRecruitment' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Are you involved in undertaking staff induction such as the delivery of care certificate?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleStaffInduction'>
                            <asp:Literal ID='lit_App_job_IsResponsibleStaffInduction' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you contribute to the provision and monitoring of training?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleMonitoringStaff'>
                            <asp:Literal ID='lit_App_job_IsResponsibleMonitoringStaff' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you lead on communication processes?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_LeadCommunicationProcesses'>
                            <asp:Literal ID='lit_App_job_LeadCommunicationProcesses' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you undertake the planning and reviewing of care?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsiblePlanningReviewing'>
                            <asp:Literal ID='lit_App_job_IsResponsiblePlanningReviewing' runat='server'></asp:Literal></label>

                        <label class="col-md-8 col-sm-8 item_key">Do you implement and review policies, procedures and agreed ways of working?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsReviewAuditPolicies'>
                            <asp:Literal ID='lit_App_job_IsReviewAuditPolicies' runat='server'></asp:Literal></label>




                        <%} /*END OF IF QUESTIONS  */  %>

                        <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                       <%-- <%  if (_App._app_officeuse1_CourseLevel == 52)
                            {
                        %>

                        <label class="col-md-8 col-sm-8 item_key">Do you contribute to the completion of the self-assessment process for regulators and local authorities?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsContributeSelfAssessment'>
                            <asp:Literal ID='lit_App_job_IsContributeSelfAssessment' runat='server'></asp:Literal></label>

                        <%} /*END OF IF QUESTIONS   */  %>--%>
                        <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 51 
                                || _App._app_officeuse1_CourseLevel == 52)
                            {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Do you write, review and audit policies and procedures?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsReviewAuditPolicy'>
                            <asp:Literal ID='lit_App_job_IsReviewAuditPolicy' runat='server'></asp:Literal></label>

                        <%} /*END OF IF QUESTIONS   */  %>

                        <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 52)
                            {
                        %>
                        <%--<label class="col-md-8 col-sm-8 item_key">Do you lead partnership working with own team and other professionals?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsLeadPartnershipWorking'>
                            <asp:Literal ID='lit_App_job_IsLeadPartnershipWorking' runat='server'></asp:Literal></label>--%>

                        <label class="col-md-8 col-sm-8 item_key">Do you lead and ensure the provision delivers person centered care?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsLeadProvisionDelivers'>
                            <asp:Literal ID='lit_App_job_IsLeadProvisionDelivers' runat='server'></asp:Literal></label>

                        <%--<label class="col-md-8 col-sm-8 item_key">Are you responsible for managing key resources such as staff, food provisions, PPE, financial resources?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleKeyResources'>
                            <asp:Literal ID='lit_App_job_IsResponsibleKeyResources' runat='server'></asp:Literal></label>--%>

<%--                        <label class="col-md-8 col-sm-8 item_key">Are your responsible for staff training, coaching and mentoring?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleStaffTraining'>
                            <asp:Literal ID='lit_App_job_IsResponsibleStaffTraining' runat='server'></asp:Literal></label>--%>

<%--                        <label class="col-md-8 col-sm-8 item_key">Are you responsible for the management of quality & governance?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleManagingQuality'>
                            <asp:Literal ID='lit_App_job_IsResponsibleManagingQuality' runat='server'></asp:Literal></label>--%>

                         <%} /*END OF IF QUESTIONS   */  %>
                        <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 51 
                                )
                            {
                        %>

                        <label class="col-md-8 col-sm-8 item_key">Do you have responsibilities for staff recruitment?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_RecruitmentResponsibilities'>
                            <asp:Literal ID='lit_App_job_RecruitmentResponsibilities' runat='server'></asp:Literal></label>

                         <%} /*END OF IF QUESTIONS   */  %>

                        <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 52)
                            {
                        %>
                       <%-- <label class="col-md-8 col-sm-8 item_key">Do your responsibilities include the provision of staff induction and the delivery of the care certificate?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_StaffInductionCareCertificate'>
                            <asp:Literal ID='lit_App_job_StaffInductionCareCertificate' runat='server'></asp:Literal></label>--%>

                      <%--  <label class="col-md-8 col-sm-8 item_key">Do your responsibilities include business development planning, implementing service improvement & development?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsResponsibleIncludeDevelopment'>
                            <asp:Literal ID='lit_App_job_IsResponsibleIncludeDevelopment' runat='server'></asp:Literal></label>
--%>


                        <%} /*END OF IF QUESTIONS   */  %>

                        <%-- Questions for Level 5 Apprenticeship --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 52)
                            {
                        %>
                        <%-- 
                        <label class="col-md-8 col-sm-8 item_key">
                            Knowledge of statutory frameworks, standards, guidance and Codes of Practice in relation to the safe delivery of services in a health and social care setting.
i.e. Care Act 2014, Fundamental Standards, Safeguarding and GDPR.
                        </label>--%>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_102_KnowledgeStatutoryFrameworks'>
                            <asp:Literal ID='lit_App_job_102_KnowledgeStatutoryFrameworks' runat='server'></asp:Literal></label>

                        <%--<label class="col-md-8 col-sm-8 item_key">
                            Experience of managing a range of resources when delivering complex care to others.
i.e. Staff recruitment and selection, budgeting, service user referral processes and additional support.
                        </label>--%>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_103_ExperienceOfManaging'>
                            <asp:Literal ID='lit_App_job_103_ExperienceOfManaging' runat='server'></asp:Literal></label>

<%--                        <label class="col-md-8 col-sm-8 item_key">Ability to implement strategies to support others to manage the risks presented when balancing individual rights and professional duty of care i.e. Care planning (person centred), risk assessment, safeguarding investigations, service contingency planning.</label>--%>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_104_AbilityImplementStrategies'>
                            <asp:Literal ID='lit_App_job_104_AbilityImplementStrategies' runat='server'></asp:Literal></label>

<%--                        <label class="col-md-8 col-sm-8 item_key">
                            Experience of leading and supporting others to work in a person-centred which enhances the well-being and quality of life of individuals 
i.e. Active participation practices and strategy, positive risk assessment, management of concerns and complaints processes, managing person centred care planning and development.</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_105_ExperienceLeadingSupporting'>
                            <asp:Literal ID='lit_App_job_105_ExperienceLeadingSupporting' runat='server'></asp:Literal></label>--%>

                        <%--<label class="col-md-8 col-sm-8 item_key">
                            Carried out activities that monitor, evaluate and improve health, safety and risk management policies and practices in the service 
i.e. process auditing, policy review, CQC inspection and self-assessment.</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_106_CarriedOutActivitiesMonitor'>
                            <asp:Literal ID='lit_App_job_106_CarriedOutActivitiesMonitor' runat='server'></asp:Literal></label>--%>






                        <% } /*END OF IF QUESTIONS   */  %>

                        
                        <%-- Questions for Level 5 Adult, 5 Apprenticeship  --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 51 
                                || _App._app_officeuse1_CourseLevel == 52)
                            {
                        %>
                        <label class="col-md-8 col-sm-8 item_key">Is your employer happy for a virtual workplace observation visit to take place?</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_AllowWorkplaceObsVisit'>
                            <asp:Literal ID='lit_App_job_AllowWorkplaceObsVisit' runat='server'></asp:Literal></label>

                         <% } /*END OF IF QUESTIONS   */  %>
 
                        <%-- Questions for Level 5 Apprenticeship --%>
                        <%  if (_App._app_officeuse1_CourseLevel == 52)
                            {
                        %> 
                        <label class="col-md-8 col-sm-8 item_key">I confirm I have a contract of employment.</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_Confirm16hrs'>
                            <asp:Literal ID='lit_App_job_Confirm16hrs' runat='server'></asp:Literal>
                            - 
                                <asp:Literal ID='lit_App_job_Confirm16hrsTitle' runat='server'></asp:Literal>
                        </label>

                          <% } /*END OF IF QUESTIONS   */  %>
 

                        <%-- <label class="col-md-8 col-sm-8 item_key">Have you undertaken any previous management or leadership training? </label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_AnyPreviousManagement'>
                            <asp:Literal ID='lit_App_job_AnyPreviousManagement' runat='server'></asp:Literal></label>--%>

                        <%--       <label class="col-md-8 col-sm-8 item_key">Do you have regular supervisions?</label>
                            <label class='col-md-4 col-sm-4 item_value' id='App_job_RegularSupervisions'>
                                <asp:Literal ID='lit_App_job_RegularSupervisions' runat='server'></asp:Literal></label>--%>




                        <%--                        <label class="col-md-8 col-sm-8 item_key">Do you respond to complaints?	</label>
                        <label class='col-md-4 col-sm-4 item_value' id='App_job_IsRespondingToComplaints'>
                            <asp:Literal ID='lit_App_job_IsRespondingToComplaints' runat='server'></asp:Literal></label>--%>




                        <%--    <label class="col-md-8 col-sm-8 item_key">Are you involved in risk assessments?	</label>
                            <label class='col-md-4 col-sm-4 item_value' id='App_job_IsInvolvedInRiskAssessments'>
                                <asp:Literal ID='lit_App_job_IsInvolvedInRiskAssessments' runat='server'></asp:Literal></label>--%>
                    </div>
                    <%--do not delete this div--%>
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
    <asp:Label ID="lblPathwaysLevel" runat="server" Visible="false"></asp:Label>


</asp:Content>




