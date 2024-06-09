<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Raiso.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" href="./Style/Style.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container gap-3 bg-secondary">
            <h2 class="text-light">Login</h2>
            <asp:TextBox ID="txtUsername" Class="" runat="server" placeholder="Username"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <br />

            <asp:TextBox ID="txtPassword" Class="" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:CheckBox ID="chkRememberMe" Class="text-light" runat="server" Text="Remember Me" />
            <br />

            <asp:LinkButton ID="LinkButton1" class="text-warning" runat="server" OnClick="LinkButton1_Click"
                >Dont Have Account?</asp:LinkButton>
            <br />
         
            <asp:Button ID="btnLogin" Class="btn btn-primary btn-lg" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <br />
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
