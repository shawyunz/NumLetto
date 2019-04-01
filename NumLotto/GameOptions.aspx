<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameOptions.aspx.cs" Inherits="NumLotto.GameOptions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label runat="server" Text="Choose the range of numbers below: "></asp:Label>
                <asp:RadioButtonList ID="radioButtonOptions" runat="server" OnSelectedIndexChanged="radioButtonOptions_SelectedIndexChanged">
                    <asp:ListItem Value="10">1-10</asp:ListItem>
                    <asp:ListItem Value="20">1-20</asp:ListItem>
                    <asp:ListItem Value="50">1-50</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="BtnStart" runat="server" Text="Start Game" OnClick="StartGame"/>
            </p>
        </div>
    </form>
</body>
</html>
