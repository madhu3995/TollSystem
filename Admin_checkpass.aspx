<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_checkpass.aspx.cs" Inherits="Toll_System.Admin_checkpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toll System</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
    <ul>
    <li><a href="Admin_vehiclefare.aspx">Vehicle Fare</a></li>
     <li><a href="Admin_passfare.aspx">Pass Fare</a></li>
     <li><a href="Admin_checkpass.aspx">Check Pass</a></li>
     <li><a href="Admin_loginstatus.aspx">Login Status</a></li>
     <li><a href="Admin_reports.aspx">Reports</a></li>
     <li><a href="index.aspx">Log Out</a></li>
    </ul>
    </div>
    <div class="content">
    <div class="left">
     <br />
        <asp:Label ID="Label1" runat="server" Text="Check"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            ShowHeader="False">
            <Columns>
            <asp:ImageField DataImageUrlField="photo" ControlStyle-Height="200 " ControlStyle-Width="200"></asp:ImageField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="right">
    <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Paid Pass" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Local Pass" OnClick="Button2_Click" />
        <hr />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    </div>
        </div>
        <div class="footer">
            <p>All Copy Rights are Reserved @2024</p>
       </div>
    </form>
</body>
</html>
