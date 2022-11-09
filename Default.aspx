<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="root_Default" %>
    <asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
   
 

<script type="text/javascript" charset="utf-8">

    $(window).load(function () {
        $(".flexslider").flexslider();
    
    });

 


    </script>


</asp:Content>
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
  <h1 class="title-regular"> online application form</h1>  


<div class="flexslider" style="display:none" >   
<ul class="slides">
<li>
<img alt="" src="App_Resources/images/slider1.jpg" />
</li>
<li> <img alt="" src="App_Resources/images/slider2.jpg" />
</li>
<li>
<img alt="" src="App_Resources/images/slider3.jpg" />
</li>
</ul>
</div>

<br />
<br />
  
<p>
 
</p>

    <p> 

         
    </p>

        
</asp:Content>
