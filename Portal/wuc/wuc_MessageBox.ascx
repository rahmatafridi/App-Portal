<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuc_MessageBox.ascx.cs"
    Inherits="wuc_MessageBox" %>


<asp:Panel ID="MessageBox" style="margin: 5px;" runat="server">
    <asp:HyperLink runat="server" ID="CloseButton">
            <asp:Image runat="server" ImageUrl="~/App_Resources/images/btn_close.png" 
            AlternateText="Click here to close this message" />
    </asp:HyperLink>
    <p>
        <asp:Literal ID="litMessage" runat="server"></asp:Literal>
    </p>
</asp:Panel>
