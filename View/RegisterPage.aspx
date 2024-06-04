<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Raiso.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="./Style/Style.css" />

    <!-- Load Bootstrap CSS via CDN -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
            <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" />
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />

            <div>
                <label for="Name">Name:</label>
                <asp:TextBox ID="txtUserame" runat="server" MaxLength="50" />
                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name" ErrorMessage="Name is required." Display="Dynamic" />
                <asp:RegularExpressionValidator ID="NameLengthValidator" runat="server" ControlToValidate="Name" ValidationExpression="^.{5,50}$" ErrorMessage="Name must be between 5 and 50 characters." Display="Dynamic" />
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
                <asp:RequiredFieldValidator ID="GenderRequired" runat="server" ControlToValidate="Gender" InitialValue="" ErrorMessage="Gender is required." Display="Dynamic" />
            </div>

            <div>
                <label for="Address">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="Address" ErrorMessage="Address is required." Display="Dynamic" />
            </div>

            <div>
                <label for="Password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." Display="Dynamic" />
                <asp:RegularExpressionValidator ID="PasswordValidator" runat="server" ControlToValidate="Password" ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Password must be alphanumeric." Display="Dynamic" />
            </div>

            <div>
                <label for="Phone">Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" />
                <asp:RequiredFieldValidator ID="PhoneRequired" runat="server" ControlToValidate="Phone" ErrorMessage="Phone number is required." Display="Dynamic" />
            </div>

            <div>
                <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
            </div>
        </div>
    </form>

    <!-- Load Bootstrap JavaScript via CDN -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
