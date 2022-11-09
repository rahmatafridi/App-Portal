<%@ Page Title="Log In" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="root_Login" %>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <h2>Access Skills Application Portal
    </h2>
    <p>
        Please enter your email and password for existing application process. Or you can register and follow your application's progress. You will need to activate your access from your email.
      
    </p>

     

    <div class="form-horizontal">
        <div class="row show-grid">

            <div class="col-lg-6">
                <div class="well">
                    <fieldset class="login">
                        <legend>Login</legend>

                        <div class="form-group">
                            <label class="col-md-3 col-sm-3">Email *</label>
                            <div class="col-md-9 col-sm-9">
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                                    ValidationGroup="LoginUserValidationGroup">* Email is required</asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 col-sm-3">Password *</label>
                            <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                    ValidationGroup="LoginUserValidationGroup">* Password is required</asp:RequiredFieldValidator>
                            </div>
                        </div>

                      
                             <asp:LinkButton SkinID="LinkButton" runat="server" OnClick="LoginButton_Click" ID="LoginButton" ValidationGroup="LoginUserValidationGroup"
                                CommandName="Login" Text="Log In" />
                         <br />
                           <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid.<br/> Please try again." Visible="False"></asp:Label>




                    </fieldset>
                </div>
            </div>


            <div class="col-lg-6">
                <div class="well">
                    <fieldset>
                        <legend>Register</legend>

                        <div class="form-group">
                            <label class="col-md-3 col-sm-3">Full Name *</label>
                            <div class="col-md-9 col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    CssClass="failureNotification" ErrorMessage="Full Name is required." ToolTip="Full Name is required."
                                    ValidationGroup="RegisterUserValidationGroup">* Full Name is required</asp:RequiredFieldValidator>

                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-md-3 col-sm-3">Email *</label>
                            <div class="col-md-9 col-sm-9">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtEmailRequired" runat="server" ControlToValidate="txtEmail"
                                    CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                                    ValidationGroup="RegisterUserValidationGroup">* Email is required</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="txtEmail"  ValidationGroup="RegisterUserValidationGroup" ErrorMessage="* Invalid Email Format"></asp:RegularExpressionValidator>


                            </div>
                        </div>


                           <asp:LinkButton ID="btnRegister" SkinID="LinkButton" runat="server" OnClick="Register_Click" Text="Register" ValidationGroup ="RegisterUserValidationGroup" />


                        <br />
                            <asp:Label ID="InvalidRegisterCredentialsMessage" runat="server" ForeColor="Red" Text="<b>Your email is invalid.<br/> Please try again.</b>" Visible="False"></asp:Label>
                         

                        <asp:RequiredFieldValidator
                            runat="server"
                            ID="UserValid"
                            ControlToValidate="txtEmail"
                            Display="None"
                            ErrorMessage="<b>Required Field Missing</b><br />An email is required." />


                     


                    </fieldset>
                </div>
            </div>



        </div>
    </div>














    <p class="submitButton">
    </p>

    <a id="lnkPasswdRetrieval" class="forget" href="ResetPassword.aspx">I have forgotten my password</a> &nbsp;
 
  <a id="lnkContactWave" class="forget" href="http://www.accessskills.co.uk/">Contact us</a>

    <script language="javascript">
        $(document).ready(function () {
            $('#<%= Password.ClientID %>').keypress(function (e) {
                if (e.keyCode == 13)
                    $('#<%= LoginButton.ClientID %>').click();
            });
        });
    </script>
</asp:Content>
