<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="Toll_System.forgetpassword" %>

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
    <br /><br />
        <asp:Panel ID="Panel1" runat="server" CssClass="a" Height="300">
            <br />
            <marquee direction = "right"><h4>Forget Password</h4></marquee>
            <table>
                <tr>
                    <td>User Name  :</td>
                    <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter User Name" ControlToValidate="textBox1" SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                </tr>
                <tr>
    <td>Security Que:</td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem> What is your Name</asp:ListItem>
        <asp:ListItem> What is your nike</asp:ListItem>
        <asp:ListItem> What is your mother name</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td>Ans:</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          </td>
          <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Ans" ControlToValidate="TextBox2" SetFocusOnError="false"></asp:RequiredFieldValidator>
          </td>
    </tr>
     <tr>
         <td> <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /> </td>
         <td> <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" /> </td>
      </tr>
                <tr>
                    <td> Your Password:</td>
                    <td> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </td>
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
