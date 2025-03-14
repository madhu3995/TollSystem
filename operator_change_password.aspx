<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="operator_change_password.aspx.cs" Inherits="Toll_System.operator_change_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toll System</title>
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
 <script>
     function digitKeyOnly(e)
     {
         var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
         if ((keyCode >= 37 && keyCode <= 40) || (keyCode == 8 || keyCode == 9 || keyCode == 13) || (keyCode >= 48 && keyCode <= 57))
         {
             return true;
         }
         return false;
     }
 </script>
    <table>
    <tr>
    <td>Enter Old Password :</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Old Password" ControlToValidate="TextBox1" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td>Enter New Password :</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Enter Confirm Password :</td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox></td>
        <td>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="TextBox2" ControlToValidate="TextBox3" 
                ErrorMessage="Missmatch Password" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Reset" /></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    <td></td>
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
