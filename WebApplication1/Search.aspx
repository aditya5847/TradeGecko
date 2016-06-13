<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="WebApplication1.Search" Codebehind="Search.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style3">
                    Object Type</td>
                <td class="style4">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>ObjectA</asp:ListItem>
                        <asp:ListItem>ObjectB</asp:ListItem>
                        <asp:ListItem>ObjectC</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Object ID</td>
                <td class="style4">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" 
                    ControlToValidate="TextBox1" ErrorMessage="Value must be a whole number" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;Time
                </td>
                <td class="style4">
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly = "true"></asp:TextBox>
                    <img src="calender.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Reset" onclick="Button2_Click" 
                    OnClientClick="this.form.reset();return false;" />
                </td>
            </tr>
            </table>

            <br />
            <br />
            <asp:Label runat="server" id="Result" EnableViewState="false" />
    </div>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=TextBox2.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m, %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
</asp:Content>