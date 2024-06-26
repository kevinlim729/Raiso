﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Raiso.View.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <link rel="stylesheet" href="./Style/Style.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-light bg-secondary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img src="./Asset/logo.png" width="30" height="24" class="d-inline-block align-text-top" />
                    <h3 class="text-light d-inline-block">Raiso</h3>
                </a>
                <!-- Navigation Bar Placeholder -->
                <asp:PlaceHolder ID="NavBarPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </nav>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
