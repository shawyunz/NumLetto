<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumLotto.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div {
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="Label1" runat="server" Text="1. Choose your price below: "></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList" runat="server">
                    <asp:ListItem Value="10">1-10</asp:ListItem>
                    <asp:ListItem Value="20">1-20</asp:ListItem>
                    <asp:ListItem Value="50">1-50</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="BtnStart" runat="server" Text="2. Start Game" OnClick="ClickStart" />

            </p>
            <asp:Label ID="LblNumber" runat="server" Text="3. Input your number below: "></asp:Label>
            <br />
            <asp:TextBox ID="TxtNumber" runat="server" Height="63px" Font-Bold="True" Font-Size="Large" TextMode="Number" Width="181px">0</asp:TextBox>
            <p>
                <asp:Button ID="BtnGuess" runat="server" Text="4. Click & Good Luck!" OnClick="ClickGuess" />
            </p>
            <p>
                <asp:Label ID="LblMessage" runat="server" Text="No Message. "></asp:Label>
                <br />
                <asp:Label ID="LblPriceTxt" runat="server" Text="Your Price: $"></asp:Label>
                <asp:Label ID="LblPrice" runat="server" Text="0"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
