<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Portal/PortalMaster.master" AutoEventWireup="true"  
    CodeFile="ViewLearnerMatrix.aspx.cs" Inherits="Assessors_ViewLearnerMatrix" %>

  <%@ Register TagPrefix="atk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>    
  
 
  <asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">
    
<link type="text/css" href="../../App_Resources/css/cupertino/jquery-ui-1.8.18.custom.css" rel="stylesheet" />	
<script type="text/javascript" src="../../App_Resources/js/ui/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="../../App_Resources/js/ui/jquery-ui-1.8.18.custom.min.js"></script>
	
<script src="../../App_Resources/js/jgrowl/jquery.jgrowl.js" type="text/javascript"></script>
<link href="../../App_Resources/js/jgrowl/jquery.jgrowl.css" rel="stylesheet" type="text/css" />
 
     
<script language="javascript" type="text/javascript">
      
    $(document).ready(function () {     
        // Datepicker
        $(".DatepickerInput").datepicker({ dateFormat: 'dd/mm/yy' });
         $(".d_complete_date").datepicker({ dateFormat: 'dd/mm/yy' });
  
    });
    
 
      

</script> 

 
<script type = "text/javascript">
 

    function UpdateOutcome(ctrl) {

        var ctlid = ctrl.id;
        var res = ctlid.split("_");
        ctlid = res[2];

        //var sVal = ctrl.value;
        var sVal = $('#' + ctrl.id).is(':checked');
        if (sVal == true) { sVal = "1"; } else { sVal = "0"; }

        var sName = ctlid + "_" + sVal;

        $.ajax({
            type: "POST",
            url: "ViewLearnerMatrix.aspx/UpdateOutcome",
            data: '{name: "' + sName + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });
    }


    function OnSuccess(response) {
        // alert(response.d);
        $.jGrowl(response.d);

    }


    function UpdateOutcomeAllTicked() {
        //var n = $('input:checkbox[id^="BodyContent_chk_"]:checked').length;
        //$('input:checkbox[id^="BodyContent_chk_"]:checked').each(function () {        
        $('input:checkbox[id^="BodyContent_chk_"]').each(function () {
             // alert($(this).attr("id"));
            $('#lbl_TickAll_1').text += $(this).attr("id");
            var ctlid = $(this).attr("id");
            var res = ctlid.split("_");
            ctlid = res[2];     
            // alert($(this).attr("id") + "-" + ctlid);            
            $(this).prop("checked", true);
            var sName = ctlid + "_1" ;
            $.ajax({
                type: "POST",
                url: "ViewLearnerMatrix.aspx/UpdateOutcome",
                data: '{name: "' + sName + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessTickAll,
                failure: function (response) {
                    alert(response.d);
                }
            });     
        });
        $.jGrowl('All ticked');

     }

     function OnSuccessTickAll(response) {
         // alert(response.d);
       //  $.jGrowl(response.d);
      //   $.jGrowl('Multiple actions performed');
     }




     function UpdateOutcomeAllUnTicked() {             
         $('input:checkbox[id^="BodyContent_chk_"]').each(function () {            
             var ctlid = $(this).attr("id");
             var res = ctlid.split("_");
             ctlid = res[2];            
             $(this).prop("checked", false);
             var sName = ctlid + "_0";
             $.ajax({
                 type: "POST",
                 url: "ViewLearnerMatrix.aspx/UpdateOutcome",
                 data: '{name: "' + sName + '" }',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: OnSuccessTickAll,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         });
         $.jGrowl('All unticked');     
     }
   




</script>


</asp:Content>

 
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">
     
  <atk:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />


 <h1 class="title-regular"><asp:Label ID="lbl_fullname" runat="server" Text=""></asp:Label></h1>  
  
  <%--<div>
Your Name :
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
<input id="btnGetTime" type="button" value="Show Current Time"
    onclick = "ShowCurrentTime()" />
</div>--%>



  <div>
<table class="GridView" width="100%">
    <tr>
        <td>
            Select Learner <br />
            <asp:DropDownList ID="ddl_list_learners" runat="server"   
                OnSelectedIndexChanged="ddl_list_learners_SelectedIndexChanged" 
                AutoPostBack="true">
            </asp:DropDownList>
                       
             
        </td>


        <td>
            Select Learner Course <br /> <asp:DropDownList ID="ddl_list_learnercourses" runat="server"/> 
               <asp:LinkButton SkinID="LinkButton" runat="server" ID="btnChooseCourse" Text="Choose" OnClick="btnChooseCourse_Click" />
    
        </td> 
                
        </tr>     
          
 <tr>
         
        <td style="width:95%" colspan="3">Task  <br /> 
           <asp:DropDownList Width="95%" CssClass="ob_gNT" ID="ddl_CourseTopics" runat="server"  DataTextField="SSJLP_Topic" DataValueField="SSJLP_id"  OnSelectedIndexChanged="ddl_CourseTopics_SelectedIndexChanged" 
                AutoPostBack="true"></asp:DropDownList>
 
         </td> 
        </tr>

</table>
  
  
<span id="jgrowlwarn" ></span> 


  <asp:Panel ID="pnl_matrix_levels" runat="server"   CssClass="GridView" width="100%">

<%--  <asp:LinkButton SkinID="LinkButton" runat="server" ID="btnUpdateOutcomes" Text="Update" OnClick="btnUpdateOutcomes_Click" />
--%>
 </asp:Panel>
  


<asp:Panel ID="pnl_activity_ss" runat="server"  Visible="false">


  
 <span id="Span1" ></span>
 

<asp:Label ID="lbl_LearnerId" runat="server" Visible ="false" ></asp:Label>
<asp:Label ID="lbl_LearnerCourseId" runat="server" Visible ="false" ></asp:Label>
<asp:Label ID="lbl_TopicId" runat="server" Visible ="false" ></asp:Label>
    

 <%--<div id="section_qcf" class="GridView">
  
  



<br />
 
 <asp:GridView   ID="grid_ss_matrix" runat="server"  OnRowDataBound="grid_ss_matrix_OnRowDataBound"
    AutoGenerateColumns="False"     PageSize="30" DataSourceID="SDS_SS_GetListJourneyLearnerProgressHistory"
    Width="100%" EnableModelValidation="True" CssClass="GridView" SkinID="GridView">

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
            Sorry, no data available.
         </div>
    </EmptyDataTemplate>             


<Columns>
      
 
<asp:TemplateField HeaderText="Id"   Visible="False">
<ItemTemplate>
 <asp:Label ID="lbl_EH_Id" Text='<%# Eval("EH_Id")%>' CssClass="qcf_txt_item" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_EH_LearnerId" Text='<%# Eval("EH_LearnerId")%>' CssClass="qcf_txt_item" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_EH_CourseId" Text='<%# Eval("EH_CourseId")%>' CssClass="qcf_txt_item" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_EH_TopicId" Text='<%# Eval("EH_TopicId")%>' CssClass="qcf_txt_item" runat="server" Visible="false"></asp:Label>
   <asp:Label ID="lbl_FileName" Text='<%# Eval("EH_FileName")%>' CssClass="qcf_txt_item" runat="server" Visible="false"></asp:Label>
   <asp:Label ID="lbl_FileCaption" Text='<%# Eval("EH_FileCaption")%>' CssClass="qcf_txt_item" runat="server" Visible="false"></asp:Label> 
   
    


</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Date"  Visible="True"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%" >
<ItemTemplate>
 <asp:Label ID="lbl_EH_SentDate" runat="server" Text='<%# Bind("EH_SentDate") %>'  ></asp:Label>
 
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Topic" Visible="True" ItemStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="70%"  ItemStyle-Width="70%" >
<ItemTemplate>
   Subject:    <asp:Label ID="lbl_EH_Subject" Text='<%# Eval("EH_Subject")%>' CssClass="qcf_txt_item" runat="server"></asp:Label><br/> 
   From:       <asp:Label ID="lbl_Users_Username" Text='<%# Eval("Users_Username")%>' CssClass="qcf_txt_item" runat="server" Visible="true"></asp:Label> 
   Message:    <asp:Label ID="lbl_EH_Body" Text='<%# Eval("EH_Body")%>' CssClass="qcf_txt_item" runat="server"></asp:Label>  
   <br/>       
 <asp:Panel ID="pnl" runat="server"></asp:Panel> 
 
</ItemTemplate>
</asp:TemplateField>
  
</Columns>
 
</asp:GridView>  




 
<asp:SqlDataSource ID="SDS_SS_GetListJourneyLearnerProgressHistory" runat="server" 
ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
SelectCommand="SP_SS_GetListJourneyLearnerProgressHistory" 
SelectCommandType="StoredProcedure">
<SelectParameters>
<asp:ControlParameter ControlID="lbl_LearnerId" DefaultValue="0" Name="LearnerId" Type="Int32" PropertyName="Text" /> 
<asp:ControlParameter ControlID="lbl_LearnerCourseId" DefaultValue="0" Name="LearnerCourseId" Type="Int32" PropertyName="Text" /> 
<asp:ControlParameter ControlID="lbl_TopicId" DefaultValue="0" Name="TopicId" Type="Int32" PropertyName="Text" />  
 <asp:Parameter DefaultValue="1" Name="Hidden" Type="Int32" /> 

 
 </SelectParameters> 
 
 </asp:SqlDataSource>  
  
</div>--%>
 
  



</asp:Panel>



</div>
 
     


           
</asp:Content>
