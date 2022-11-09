<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Timedout.aspx.cs" Inherits="root_App_Timedout" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">



    <script type="text/javascript" charset="utf-8">

        $(window).load(function () {
            
        });




    </script>


</asp:Content>
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
       
<asp:Label ID="lbl_UserId" runat="server" Visible ="false" ></asp:Label>
  

    
     <h1 class="title-regular">online application form</h1>


    <div class="flexslider" style="display: none">
        <ul class="slides">
            <li>
                <img alt="" src="App_Resources/images/slider1.jpg" />
            </li>
            <li>
                <img alt="" src="App_Resources/images/slider2.jpg" />
            </li>
            <li>
                <img alt="" src="App_Resources/images/slider3.jpg" />
            </li>
        </ul>
    </div>

     
    <asp:Panel ID="pnl_startapp" runat="server" CssClass="alert alert-info">
      Sorry your session was expired. Please try again. If the problem persists please contact the administrator.

    </asp:Panel>
  
    <p>
         

    </p>

     <asp:LinkButton OnClick="btnLogout_Click" SkinID="LinkButton" ID="btnLogout" Text='Logout' runat="server" />


</asp:Content>
