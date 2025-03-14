<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_vehiclefare.aspx.cs" Inherits="Toll_System.Admin_vehiclefare" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <li><a href="Admin_vehiclefare.aspx">Vehical Fare </a></li>
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
            <br /> <script>
               function digitKeyOnly(e) {
                   var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
                   if ((keyCode >= 37 && keyCode <= 40) || (keyCode == 8 || keyCode == 9 || keyCode == 13) || (keyCode >= 48 && keyCode <= 57)) {
                       return true;
                   }
                   return false;
               }
            </script>
            <asp:Panel ID="Panel1" runat="server" CssClass="a" Height="200">

                <marquee direction = "right"><h4>Admin Vehicle Fare</h4></marquee>
                <br />
         <table>
    <tr>
    <td>Select Vehicle Type :</td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>LCV</asp:ListItem>
        <asp:ListItem>MA</asp:ListItem>
        <asp:ListItem>FTL</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>Journey Type:</td>
    <td>
         <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>Single</asp:ListItem>
        <asp:ListItem>Return</asp:ListItem>
        
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td>Amount :</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /></td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </td>
    </tr>
  <tr>
  <td>
      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
  </tr>
    </table>
        </asp:Panel>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" DataKeyNames="id" BackColor="#FF99FF">
        <Columns>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
            <asp:Button ID="Button3" runat="server" Text="Edit"  OnClick="Button3_Click" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="vtype" HeaderText="Vehicle Type" />
        <asp:BoundField DataField="jtype" HeaderText="Journey type" />
        <asp:BoundField  DataField="amt" HeaderText="Amount"/>
        </Columns>
        </asp:GridView>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="label2" PopupControlID="panel2"  CancelControlID="Button6">
 </asp:ModalPopupExtender>
            
        <asp:Panel ID="Panel2" runat="server" BackColor="BurlyWood" Width="300">
         <table>
         <tr>
         <td>ID:</td>
         <td>
             <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
         </tr>
    <tr>
    <td>Select Vehicle Type :</td>
    <td>
        <asp:DropDownList ID="DropDownList3" runat="server">
        <asp:ListItem>LCV</asp:ListItem>
        <asp:ListItem>MA</asp:ListItem>
        <asp:ListItem>FTL</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>Journey Type:</td>
    <td>
         <asp:DropDownList ID="DropDownList4" runat="server">
        <asp:ListItem>Single</asp:ListItem>
        <asp:ListItem>Return</asp:ListItem>
        
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td>Amount :</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" /></td>
    <td>
        <asp:Button ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="Cancel" />
        </td>
    </tr>
  <tr>
  <td>
      <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
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
