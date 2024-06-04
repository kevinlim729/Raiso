<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Raiso.View.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>

    <!-- Load Bootstrap CSS via CDN -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Navigation Bar Placeholder -->
            <asp:PlaceHolder ID="NavBarPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
    </form>

    <!-- Load Bootstrap JavaScript via CDN -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
