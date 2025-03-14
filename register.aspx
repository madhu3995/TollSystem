<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Toll_System.Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toll System</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navbar">
                <ul>
                <li><a href="index.aspx">Home</a></li>
                <li><a href="register.aspx">Registration</a></li>
                </ul>
            </div>
            <div class="content">
                <div class="left"></div>
                <div class="right">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <script>
            function digitKeyOnly(e) {
                var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
                if ((keyCode >= 37 && keyCode <= 40) || (keyCode == 8 || keyCode == 9 || keyCode == 13) || (keyCode >= 48 && keyCode <= 57)) {
                    return true;
                }
                return false;
            }
                    </script>
                    <asp:Panel ID="Panel1" runat="server" CssClass="a" Height="450">
     <marquee direction = "right"><h4> Operator Registration</h4></marquee>

                        <table>
    <tr>
    <td>User Name :</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Password:</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ></asp:TextBox></td>
    </tr>
     <tr>
    <td>Confirm Password:</td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" ></asp:TextBox>
       </td>
       <td>  <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="TextBox2" ControlToValidate="TextBox3" 
            ErrorMessage="MissMatch Password" ForeColor="#FF3300" SetFocusOnError="True"></asp:CompareValidator>
        </td>
    </tr>
     <tr>
    <td>Gender:</td>
    <td>
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="a" /> 
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="a" />
    </td>
    </tr>
     <tr>
    <td>Contact No:</td>
    <td>
        <asp:TextBox ID="TextBox4" runat="server" onkeypress="return digitKeyOnly(event)" ></asp:TextBox></td>
    </tr>
     <tr>
    <td>Address:</td>
    <td>
        <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
     <tr>
    <td>DOJ:</td>
    <td>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="TextBox6">
        </asp:CalendarExtender>        
    </td>
    </tr>
     <tr>
    <td>Photo:</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
    </tr>
     <tr>
    <td>Sqcurity Que:</td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem> What is your Name</asp:ListItem>
        <asp:ListItem> What is your Nike</asp:ListItem>
        <asp:ListItem> What is your Mother Name</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
      <tr>
    <td>Ans:</td>
    <td>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </td>
    </tr>
  <tr>
  <td>
      <asp:Label ID="Label1" runat="server" ></asp:Label></td>
  </tr>
    </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="footer">
            <p>All Copy Rights are Reserved @2024</p>
        </div>
    </form>
</body>
</html>
