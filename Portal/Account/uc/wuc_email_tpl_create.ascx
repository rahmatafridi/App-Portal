<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuc_email_tpl_create.ascx.cs"
    Inherits="account_wuc_email_tpl_create" %>

<%@ Register Src="~/Portal/wuc/wuc_MessageBox.ascx" TagName="MyMessageBox" TagPrefix="msgbx" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<msgbx:MyMessageBox ID="MessageBox" runat="server" />


<table style="width: 100%">
    <tr valign="top">
        <td class="ob_gNRM">Title
            <br />

            <asp:TextBox ID="txt_title" runat="server" MaxLength="50"
                ToolTip="Title" Width="95%"></asp:TextBox>
        </td>
    </tr>
     <tr valign="top">
        <td class="ob_gNRM">Subject
            <br />

            <asp:TextBox ID="txt_Subject" runat="server" MaxLength="500"
                ToolTip="Title" Width="95%"></asp:TextBox>
        </td>
    </tr>
     <tr valign="top">
        <td class="ob_gNRM">Code
            <br />

            <asp:TextBox ID="txt_Code" runat="server" MaxLength="50"
                ToolTip="Title" Width="95%"></asp:TextBox>
        </td>
    </tr>


    <tr valign="top">
        <td class="ob_gNRM">Active 
            <asp:CheckBox ID="chk_editable" runat="server" Checked="True" /></td>
    </tr>


    <tr valign="top">
        <td class="ob_gNRM">



            <FCKeditorV2:FCKeditor ID="fckEditor" runat="server" Width="95%" Height="400px">
            </FCKeditorV2:FCKeditor>


        </td>
    </tr>

    <tr>
        <td colspan="1">
            <asp:LinkButton ID="btnAdd" SkinID="LinkButton" runat="server" OnClick="btnAdd_Click" Text="Create" />
            <asp:LinkButton ID="btnCancel" SkinID="LinkButton" runat="server" OnClick="btnCancel_Click" Text="Cancel" />


        </td>
    </tr>

</table>

<asp:Label ID="lbl_Id" runat="server" Text="" Visible="false"></asp:Label>