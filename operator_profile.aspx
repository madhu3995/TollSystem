<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="operator_profile.aspx.cs" Inherits="Toll_System.operator_profile" %>

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
    <td>User Name :</td>
    <td> 
        <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Gender :</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Mobile No :</td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Address :</td>
    <td>
        <asp:TextBox ID="TextBox4" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
    <td>DOJ :</td>
    <td>
        <asp:TextBox ID="TextBox5" runat="server" Enabled="false"></asp:TextBox></td>
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
