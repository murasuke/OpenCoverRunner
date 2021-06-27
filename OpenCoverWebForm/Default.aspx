<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenCoverWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ManualTestTarget</title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" class="auto-style1"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Selected="True" Value="0">＋</asp:ListItem>
                        <asp:ListItem Value="1">－</asp:ListItem>
                        <asp:ListItem Value="2">×</asp:ListItem>
                        <asp:ListItem Value="3">÷</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" class="auto-style1"></asp:TextBox></td>
                <td>=</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" TextMode="Number" class="auto-style1"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="計 算" Width="64px" />
                   </td>
            </tr>
        </table>
    </form>
</body>
</html>
