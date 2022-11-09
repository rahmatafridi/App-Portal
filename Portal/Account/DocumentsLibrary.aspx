<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"
    CodeFile="DocumentsLibrary.aspx.cs" Inherits="Learners_DocumentsLibrary" %>

 


    <asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    
    <link type="text/css" href="../../App_Resources/css/cupertino/jquery-ui-1.8.18.custom.css" rel="stylesheet" />	
    <script type="text/javascript" src="../../App_Resources/js/ui/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../App_Resources/js/ui/jquery-ui-1.8.18.custom.min.js"></script>
		
        	
<script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
<link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
 

    <script language="javascript" type="text/javascript">
        $(function () {
            $("#accordion").accordion();
        });
    </script>

    </asp:Content>

<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   <h1 class="title-regular">Documents Library</h1>  
    
    

      <span id="jgrowlwarn" ></span> 

    <asp:Panel ID="pnl_panels" runat="server" ></asp:Panel>
    
</asp:Content>
