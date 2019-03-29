<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Website.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ristorante Duomo Administration</title>
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
            <img class="logo" src="assets/logoDuomo.png" />
        </div>
        <div class="sidenav">
            <a href="Home.aspx">Forside</a>
            <a href="Menu.aspx">Menu</a>
            <a href="Contact.aspx">Kontakt</a>
        </div>
        <br /><br /><br />
        <div class="adminNav">
            <div>
                <input type="text" placeholder="ID" id="idSearch" name="topping" runat="server" />
                <asp:Button runat="server" Text="Create new item" OnClick="createItem"/>
           </div>
            <div>
                <input type="text" placeholder="Navn" id="nameSearch" name="topping" runat="server" />
                <asp:Button runat="server" Text="Update item" OnClick="updateItem"/>
            </div>
            <div>
                <input type="text" placeholder="Pris" id="priceSearch" name="topping" runat="server" />
                <asp:Button runat="server" Text="Read data" OnClick="readItem"/>
            </div>
            <div>
                <asp:Button runat="server" Text="Delete item" OnClick="deleteItem"/>
            </div>
            <div>
                <div class="menuItems">
                    <asp:GridView ID="gridViewPizza" runat="server" AutoGenerateColumns="False">

                    </asp:GridView>
                </div>
                <div class="menuItems">
                    <asp:GridView ID="gridViewTopping" runat="server" AutoGenerateColumns="False">

                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
