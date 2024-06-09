<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Raiso.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="./Style/Style.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container bg-secondary">
            <h2 class="text-light">Register</h2>
            <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" />
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />

            <div>
                <label for="txtUserame">Name:</label>
                <asp:TextBox ID="txtUserame" runat="server" MaxLength="50" />
                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="txtUserame" ErrorMessage="Name is required." Display="Dynamic" />
                <asp:RegularExpressionValidator ID="NameLengthValidator" runat="server" ControlToValidate="txtUserame" ValidationExpression="^.{5,50}$" ErrorMessage="Name must be between 5 and 50 characters." Display="Dynamic" />
            </div>

            <div>
                <label for="DOB">Date of Birth:</label>
                <asp:TextBox ID="DOB" runat="server" TextMode="Date" />
                <asp:RequiredFieldValidator ID="DOBRequired" runat="server" ControlToValidate="DOB" ErrorMessage="Date of Birth is required." Display="Dynamic" />
                <asp:CustomValidator ID="DOBValidator" runat="server" ControlToValidate="DOB" OnServerValidate="ValidateDOB" ErrorMessage="You must be at least 1 year old." Display="Dynamic" />
            </div>

            <div>
                <label for="Gender">Gender:</label>
                <asp:RadioButtonList ID="radiobtnGender" runat="server">
                    <asp:ListItem Text="Male" Value="Male" />
                    <asp:ListItem Text="Female" Value="Female" />
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="GenderRequired" runat="server" ControlToValidate="radiobtnGender" InitialValue="" ErrorMessage="Gender is required." Display="Dynamic" />
            </div>

            <div>
                <label for="Address">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required." Display="Dynamic" />
            </div>

            <div>
                <label for="Password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." Display="Dynamic" />
                <asp:RegularExpressionValidator ID="PasswordValidator" runat="server" ControlToValidate="txtPassword" ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Password must be alphanumeric." Display="Dynamic" />
            </div>

            <div>
                <label for="Phone">Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" />
                <asp:RequiredFieldValidator ID="PhoneRequired" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number is required." Display="Dynamic" />
            </div>

            <div>

                <asp:Button ID="RegisterButton" Class="btn btn-primary btn-lg" runat="server" Text="Register" OnClick="RegisterButton_Click" />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
