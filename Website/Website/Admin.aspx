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
                <asp:Button runat="server" Text="Create new item" OnClick="CreateItem"/>
           </div>
            <div>
                <asp:Button runat="server" Text="Update item" OnClick="UpdateItem"/>
            </div>
            <div>
            <asp:Button runat="server" Text="Read data" OnClick="ReadItem"/>
            </div>
            <div>
            <asp:Button runat="server" Text="Delete item" OnClick="DeleteItem"/>
            </div>
        </div>
    </form>
</body>
</html>
