<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Website.Contact" %>

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
            <img class="logo" src="assets/logoDuomo.png" />
        </div>
        <div class="sidenav">
            <a href="Home.aspx">Forside</a>
            <a href="Menu.aspx">Menu</a>
            <a href="Contact.aspx">Kontakt</a>
        </div>
        <div>
            <address class="contact">Fejøgade 3 <br />4800 Nykøbing Falster<br />Tlf. 54 82 40 40<br />MobilePay: 942330</address>
        </div>
        <div>
            <p class="contact">Åbningstider:<br />Mandag - lørdag<br />11.00 - 22.00<br /><br />Søn- og helligdage<br />12.00 - 22.00</p>
        </div>
        <div>
            <p class="contact">Udbringning i<br />Nykøbing F.:<br />16.00 - 21.00<br />Kørsel: kr. 20.-<br />Min. køb kr. 100.-<br />Kontant/MobilePay</p>
        </div>
    </form>
</body>
</html>
