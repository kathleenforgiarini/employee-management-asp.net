<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Maintenance</title>
    <style type="text/css">
        .auto-style1 {
            width: 71%;
        }
        .auto-style4 {
            width: 61px;
        }
        .auto-style7 {
            width: 125px;
            text-align: right;
        }
        .auto-style8 {
            margin-left: 0px;
        }
        .auto-style9 {
            width: 125px;
        }
        .auto-style10 {
            width: 94%;
        }
        .auto-style12 {
            width: 664px;
            text-align: right;
            height: 59px;
        }
        .auto-style14 {
            height: 59px;
            width: 362px;
        }
        .auto-style16 {
            height: 59px;
            width: 310px;
        }
        .auto-style18 {
            height: 59px;
            width: 239px;
            text-align: right;
        }
        .auto-style19 {
            height: 603px;
        }
        .auto-style20 {
            color: #0000FF;
        }
        .auto-style21 {
            color: #000000;
        }
    </style>
</head>
<body style="width: 803px; height: 645px">
    <form id="form1" runat="server" class="auto-style19">
    <table class="auto-style1">
        <tr>
            <td colspan="3" style="text-align: center; color: #CD6906; font-weight: bold; font-size: large;">Employee Maintenance</td>
        </tr>
        <tr>
            <td class="auto-style7">Employee ID</td>
            <td>
                <asp:TextBox ID="txtId" runat="server" Width="139px" CssClass="auto-style8" Height="27px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="btnSave_Click" Text="Save" Width="112px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">First Name</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" Height="27px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnUpdate" runat="server" Height="40px" OnClick="btnUpdate_Click" Text="Update" Width="112px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Last Name</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" Height="27px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnDelete" runat="server" Height="40px" OnClick="btnDelete_Click" Text="Delete" Width="112px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Job Title</td>
            <td>
                <asp:TextBox ID="txtJobTitle" runat="server" Height="27px" Width="232px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnListAll" runat="server" Height="40px" Text="List All" Width="112px" OnClick="btnListAll_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        </table>
        <table class="auto-style10">
            <tr>
                <td class="auto-style12">Search By</td>
                <td class="auto-style14">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="177px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtSearch" runat="server" Width="236px"></asp:TextBox>
                </td>
                <td class="auto-style18">
                    <asp:Button ID="btnSearch" runat="server" Height="38px" Text="Search" Width="150px" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <br />
        <span class="auto-style20">
        <asp:Label ID="Label1" runat="server" CssClass="auto-style21"></asp:Label>
        </span>
        <br />
        <br />
        <span class="auto-style20">Employees List</span><br />
        <asp:GridView ID="GridView1" runat="server" Width="608px">
        </asp:GridView>
        
    </form>
    </body>
</html>
