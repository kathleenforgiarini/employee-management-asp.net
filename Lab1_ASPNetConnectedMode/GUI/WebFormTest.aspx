<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            width: 239px;
        }
        .auto-style4 {
            height: 25px;
            width: 239px;
        }
        .auto-style5 {
            width: 205px;
        }
        .auto-style6 {
            height: 25px;
            width: 205px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="ButtonConnectDB" runat="server" OnClick="ButtonConnectDB_Click" Text="Connect DB" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
