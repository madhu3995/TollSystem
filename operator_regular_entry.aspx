<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="operator_regular_entry.aspx.cs" Inherits="Toll_System.operator_regular_entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toll system</title>
        <link href="StyleSheet1.css" rel="stylesheet" />
    </head>
<body>
    <form id="form1" runat="server">
 <div class="navbar">
<ul>
<li><a href="operator_regular_entry.aspx">Entry</a></li>
 <li><a href="oprator_add_pass.aspx">Add Pass</a></li>
 <li><a href="operator_local_pass.aspx">Local Pass</a></li>
 <li><a href="operator_check_pass.aspx">Check Pass</a></li>
 <li><a href="operator_change_password.aspx">Change Password</a></li>
 <li><a href="operator_profile.aspx">Profile</a></li>
 <li><a href="Index.aspx">LogOut</a></li>
</ul>
</div>
        <div class="content">
    <div class="left">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            ShowHeader="False">
            <Columns>
            <asp:ImageField DataImageUrlField="photo" ControlStyle-Height="200 " ControlStyle-Width="200"></asp:ImageField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="right">
    <br />
    <table>
    <tr>
    <td>Toll Plaza Name :</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Transport No :</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Transport Date&Time :</td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Vehicle No :</td>
    <td>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the Vehicle No" ControlToValidate="TextBox4" SetFocusOnError="true" ForeColor="red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>Vehicle Type :</td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>LCV</asp:ListItem>
        <asp:ListItem>MA</asp:ListItem>
        <asp:ListItem>FTL</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>Journey Type :</td>
    <td>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
        <asp:ListItem>Single</asp:ListItem>
        <asp:ListItem>Return</asp:ListItem>        
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>Fare :</td>
    <td> 
        <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Lane No :</td>
    <td>
        <asp:DropDownList ID="DropDownList3" runat="server">
        <asp:ListItem>Lane 1</asp:ListItem>
        <asp:ListItem>Lane 2</asp:ListItem>
        <asp:ListItem>Lane 3</asp:ListItem>
        <asp:ListItem>Lane 4</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>Operator Name :</td>
    <td> 
        <asp:TextBox ID="TextBox6" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="Button2_Click" /></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    </tr>
    </table>
    </div>
    </div>
     <div class="footer">
     <p>All Copy Rights are Reserved @2024</p>
</div>
    </form>
</body>
</html>
