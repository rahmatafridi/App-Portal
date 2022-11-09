<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="root_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContainer" runat="server">


    <script type="text/javascript" charset="utf-8">

        $(window).load(function () {

        });




    </script>


</asp:Content>
<asp:Content ID="cHeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="cBodyContent" runat="server" ContentPlaceHolderID="BodyContent">

    <asp:Label ID="lbl_UserId" runat="server" Visible="false"></asp:Label>
    <h3 class="title-regular">online application form</h3>

    <%-- <div class="flexslider" style="display: none">
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
    </div>--%>

    <asp:Panel ID="pnl_startapp" runat="server" CssClass="alert alert-info">
        Start a new application &nbsp;<br />
        <asp:LinkButton OnClick="btnStart_Click" SkinID="LinkButton" ID="btnStart" Text='Start' runat="server" />

    </asp:Panel>
    <div class="panel panel-info">
        <div class="panel-heading">Existing application progress:</div>
        <div class="panel-body">

            <asp:SqlDataSource ID="SDS_App_GetUserApplications" runat="server"
                ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                SelectCommand="SP_App_GetUserApplications"
                SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lbl_UserId" DefaultValue="0" Name="UserId" Type="Int32" PropertyName="Text" />
                </SelectParameters>



            </asp:SqlDataSource>
            <asp:GridView ID="grid_userapplications" runat="server"
                AutoGenerateColumns="False" CssClass="table table-condensed table-bordered"
                OnRowDataBound="grid_userapplications_OnRowDataBound"
                DataSourceID="SDS_App_GetUserApplications" PageSize="100"
                Width="100%" EnableModelValidation="True">

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
                        No application recorded.
                    </div>
                </EmptyDataTemplate>


                <Columns>


                    <asp:TemplateField HeaderText="Id" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbl_AppId" Text='<%# Eval("AppUser_App_Id")%>' runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lbl_UserId" Text='<%# Eval("AppUser_UserId")%>' runat="server" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Application Date" Visible="True" ItemStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_CreatedOn" Text='<%# Eval("CreatedOn")%>' runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Time" Visible="True" ItemStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_CreatedTime" Text='<%# Eval("CreatedTime")%>' runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Submitted" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Submitted" runat="server" Text='<%# Bind("IsSubmitted") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Submitted on/Completed" Visible="True" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="22%" ItemStyle-Width="22%">
                        <ItemTemplate>
                            <asp:Label ID="lbl_SumittedDate" runat="server" Text='<%# Bind("SumittedDate") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="" ShowHeader="true" HeaderStyle-Width="40%" ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:LinkButton OnClick="btn_Edit_Click" SkinID="LinkButton" ID="btn_Edit" Text='Continue/Amend Application' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>

        </div>
    </div>

   <%-- <div class="panel panel-info">
        <div class="panel-heading">Forms to sign:</div>
        <div class="panel-body">
            <asp:GridView ID="grid_FormsToSign" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-bordered" DataSourceID="SDS_App_GetUserApplications">
                <HeaderStyle CssClass="HeaderStyle" />
                <EmptyDataTemplate>
                    <div class="notice">
                        No application recorded.
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Application Date" Visible="True">
                        <ItemTemplate>
                            <asp:Label ID="lbl_CreatedOn" Text='<%# Eval("CreatedOn")%>' runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Time" Visible="True">
                        <ItemTemplate>
                            <asp:Label ID="lbl_CreatedTime" Text='<%# Eval("CreatedTime")%>' runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>--%>
    <asp:LinkButton OnClick="btnLogout_Click" SkinID="LinkButton" ID="btnLogout" Text='Logout' runat="server" />


</asp:Content>
