<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="holdingpage.aspx.cs" Inherits="root_holdingpage" %>

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
  

    
     <h3 class="title-regular">online application form</h3>


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
      Sorry the system is down for a maintenance. Please try again later.

    </asp:Panel>
  
    <p>
         

    </p>

     <asp:LinkButton OnClick="btnLogout_Click" SkinID="LinkButton" ID="btnLogout" Text='Logout' runat="server" />


</asp:Content>
