<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateInvite.aspx.cs" MasterPageFile="~/Portal/PortalMaster.master" Inherits="Portal_Admin_CreateInvite" Title="Create Invite" %>

<%@ Register Src="~/Portal/wuc/wuc_MessageBox.ascx" TagName="MyMessageBox" TagPrefix="msgbx" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    <link href="../../App_Resources/bootstrap-3.3.1-dist/dist/css/bootstrap.css" rel="stylesheet" />
    <link type="text/css" href="../../editors/tinyeditor/tinyeditor.css" rel="stylesheet" />
    <script type="text/javascript" src="../../editors/tinyeditor/tiny.editor.packed.js"></script>


    <link type="text/css" href="../../App_Resources/css/cupertino/jquery-ui-1.8.18.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../App_Resources/js/ui/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../App_Resources/js/ui/jquery-ui-1.8.18.custom.min.js"></script>

</asp:Content>





<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="Server">
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            Dropzone.autoDiscover = false;
            //Simple Dropzonejs 
            $("#dZUpload2").dropzone({
                url: "AppPortalAttachments.ashx",
                maxFiles: 10,
                maxFilessize: 20,
                autoProcessQueue: false,
                uploadMultiple: true,
                addRemoveLinks: true,
                parallelUploads: 20,

                init: function () {
                    var myDropZone2 = this;
                    var submitButton2 = document.querySelector("#submitForm2");
                    var wrapperThis2 = this;

                    submitButton2.addEventListener("click", function () {
                        // debugger;
                        $("#error2").html("<span></span>");
                        $("#response2").html("<span></span>");

                        if (myDropZone2.files.length < 1) {
                            $("#error2").html("<span>No File Selected</span>");
                        }
                        else
                            if (myDropZone2.files.length > 10) {
                                $("#error2").html("<span>You cannot select more than 10 files</span>");
                            }
                            else {
                                wrapperThis2.processQueue();
                            }

                    });

                    this.on("addedfile", function (file) {
                    });

                    // Also if you want to post any additional data, you can do it here
                    this.on('sending', function (data, xhr, formData) {
                        //debugger;
                        formData.append("UserName", "<%=Membership.GetUser().UserName%>");
                        formData.append("ident", "<%=Membership.GetUser().UserName%>");

                    });
                    this.on("complete", function (file) {
                        myDropZone2.removeFile(file);
                    });
                    this.on("maxfilesexceeded", function (file) {
                        alert('max files exceeded');
                        // handle max+1 file.
                    });
                },
                success: function (file, response) {
                    $("#error2").html("<span></span>");
                    $("#response2").html("<span> " + response + " </span>");

                },
                error: function (file, response) {
                    $("#error2").html("<span> " + response + " </span>");
                }
            }); //end of uploader
        });//doc ready ends
    </script>

     

    <div class="panel panel-info">
            <div class="panel-heading">Create Invite</div>
                
         
            <msgbx:MyMessageBox ID="msgbox" runat="server" width ="50%"/>
         
        <div class="panel-body">

            <div class="col-lg-12 alert alert-info">
                    

                <div class="alert alert-info">
                    This invite sends an email to the learner to login to the portal. Learner doesn't need to create the account but only to login. There is also no need to validate the account.
                </div>
                <div class="form-horizontal">
                    <div class="form-group-sm">
                        <label for="inputEmail3" class="col-sm-2 control-label">First Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control input-sm" MaxLength="50" ToolTip="First Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group-sm">
                        <label for="inputEmail3" class="col-sm-2 control-label">Last Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-sm" MaxLength="50" ToolTip="Last Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group-sm">
                        <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" MaxLength="50" ToolTip="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group-sm">
                        <label for="inputEmail3" class="col-sm-2 control-label">Password</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-sm" MaxLength="50" ToolTip="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group-sm">
                        <label for="inputEmail3" class="col-sm-2 control-label">Course</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddl_Courses"
                                runat="server" DataSourceID="SDS_ListCourses"
                                DataTextField="Course_Title" DataValueField="Course_Id"
                                AutoPostBack="true" CssClass="form-control input-sm"
                                OnSelectedIndexChanged="ddl_Courses_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SDS_ListCourses" runat="server"
                                ConnectionString="<%$ ConnectionStrings:DBConnectionOsca %>"
                                SelectCommand="SP_SS_GetListCourses"
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                        <br />
                    </div>
                    <%-- <div class="form-group">
                <label for="inputEmail3" class="col-sm-2 control-label">Attachment</label>
                <div class="col-sm-10">
                    <asp:Panel ID="pnlAttachments" runat="server">
                        <div class="uploadFilesSection default-state" style="display: block;">
                            <center>
                                <div style="text-align: left; padding: 0 0 10px 0;">
                                </div>
                                <div id="dZUpload2" class="dropzone">
                                    <div class="dz-default dz-message">
                                        Drop files here or click to upload.                           
                                    </div>
                                </div>
                                <div style="text-align: left; padding-top: 10px;">
                                    <button type="button" id="submitForm2" class="ob_btn">Upload Selected Files </button>
                                    <label style="color: red;" id="error2"></label>
                                    <label style="color: green;" id="response2"></label>
                                </div>
                            </center>
                        </div>
                    </asp:Panel>
                </div>
            </div>--%>
                    <asp:Panel ID="pnlEmail" runat="server">
                        <div class="form-group-sm">
                            <label for="inputEmail3" class="col-sm-2 control-label" style="padding: 15px;">Body</label>
                            <div class="col-sm-10" style="padding: 15px;">
                                <FCKeditorV2:FCKeditor ID="fckEditor" runat="server" Width="100%" Height="400px">
                                </FCKeditorV2:FCKeditor>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="form-group-sm">
                        <div class="col-sm-offset-2 col-sm-10" style="padding: 10px;">
                            <asp:Button ID="btn_SeeInvite" OnClick="btn_SeeInvite_Click" SkinID="LinkButton" CssClass="btn btn-primary btn-xs" runat="server" Text="Check Generated Email" />
                            <asp:Button ID="btn_AddInvite" OnClick="btn_AddInvite_Click" SkinID="LinkButton" CssClass="btn btn-success btn-xs" runat="server" Text="Send Invite" />
                        </div>
                    </div>
                </div>

                        </div>

            </div>

    </div>
    

    <asp:Label ID="lbl_AppPortal_CourseId" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_AppPortal_Body" runat="server" Text="" Visible="false"></asp:Label>

</asp:Content>
