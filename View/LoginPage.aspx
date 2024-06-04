<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Raiso.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" href="./Style/Style.css" />

    <!-- Load Bootstrap CSS via CDN -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container bg-secondary">
            <h2>Login</h2>
            <asp:TextBox ID="txtUsername" Class="bg-dark" runat="server" placeholder="Username"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="txtPassword" Class="bg-dark" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="chkRememberMe" Class="text-light" runat="server" Text="Remember Me" />
            <br />
            <asp:Button ID="btnLogin" Class="btn btn-primary btn-lg" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>

    <!-- Load Bootstrap JavaScript via CDN -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
