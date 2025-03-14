<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_loginstatus.aspx.cs" Inherits="Toll_System.Admin_loginstatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="410" CssClass="a">
                <marquee direction = "right"><h4>Login Status</h4></marquee>
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" DataKeyNames="id">
        <Columns>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
            <asp:Button ID="Button1" runat="server" Text="Edit"  OnClick="Button1_Click"/>
        </ItemTemplate>
        </asp:TemplateField>
       
       <asp:BoundField DataField="username" HeaderText="Operator Name" />
       <asp:BoundField DataField="gender" HeaderText="Gender" />
       <asp:BoundField DataField="mob" HeaderText="Mobile Number" />
       <asp:BoundField DataField="address" HeaderText="Address" />
       <asp:BoundField DataField="status" HeaderText="Status" />
       <asp:ImageField DataImageUrlField="photo"  HeaderText="Photo" ControlStyle-Height="80 " ControlStyle-Width="80">
           <ControlStyle Height="80px" Width="80px" />
            </asp:ImageField>
        </Columns>
        </asp:GridView>
        </asp:Panel>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2" CancelControlID="Button4" TargetControlID="label1">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="aa" Height="200" Width="300">
                <br />
                <table>
        <tr>
        <td>ID:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>User Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
        <td>Gender</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Mobile No :</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Status</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" /></td>
        <td>
            <asp:Button ID="Button3" runat="server" Text="Delete"  OnClick="Button3_Click"/></td>
         <td>
             <asp:Button ID="Button4" runat="server" Text="Cancel"  OnClick="Button4_Click"/></td>
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
