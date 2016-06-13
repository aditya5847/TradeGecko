<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="WebApplication1._Default" Codebehind="Default.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <input type=file id=File1 name=File1 runat="server" />
    <br />
    <br />
    <br />
    &nbsp;
    <input type="submit" id="Submit1" value="Upload" runat="server" />
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="" />
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        #File1
        {
            width: 700px;
        }
    </style>
</asp:Content>