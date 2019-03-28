﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Website.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ristorante Duomo</title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css"/>
    <script type="text/javascript" src="/js/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="/js/functions.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="progress-container">
            <div class="progress-bar" id="myBar">
            </div>
        </div>
        <div class="backImg">
        </div>
        <div>
            <img class="logo" src="assets/logoDuomo.png" alt="duomo pizzaria logo"/>
        </div>
        <div class="sidenav">
            <a href="Home.aspx">Forside</a>
            <a href="Menu.aspx">Menu</a>
            <a href="Contact.aspx">Kontakt</a>
            <input type="text" placeholder="Search for topping" id="searchBar" name="topping" runat="server"/>
            <button type="submit" class="searchButton" runat="server">Search</button>
        </div>
        <div class="menuItems">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Nummer"/>
                    <asp:BoundField DataField="Name" HeaderText="Pizza Navn"/>
                    <asp:BoundField DataField="Price" HeaderText="Pris"/>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <p>Hello There!</p>
        </div>
    </form>
</body>
</html>
