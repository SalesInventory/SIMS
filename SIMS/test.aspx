<%@ Page Title="" Language="C#" MasterPageFile="~/mstsims.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="SIMS.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContent" runat="server">
    <form id="form1" runat="server">
        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
        <hr />
        <asp:PlaceHolder ID="plBarCode" runat="server" />
    </form>
</asp:Content>
