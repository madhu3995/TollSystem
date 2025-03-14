<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Toll_System.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toll System</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="navbar">
            <ul>
                <li><a href="index.aspx">Home</a></li>
                <li><a href="register.aspx">Registration</a></li>
            </ul>
        </div>
        <div class="content">
            <div class="left"></div>
            <div class="right">
                <asp:Panel ID="Panel1" runat="server" CssClass="a" Height="280">
                    <br />
                        <marquee direction = "right"><h4>Login Details</h4></marquee>

                    <table>
                        <tr>
                            <td>User Name:</td>
                            <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td> <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td> <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /> </td>
                            <td> <asp:Button ID="Button2" runat="server" Text="Cancel" /> </td>
                        </tr>
                        <tr>
                            <td> <asp:Label ID="Label1" runat="server" ></asp:Label> </td>
                        </tr>
                        <tr>
                            <td> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Registration Here</asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Forget Password</asp:LinkButton> </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
        <div class="footer">
            <p>All Copy Rights are Reserved @2024</p>
        </div>
    </form>
</body>
</html>
