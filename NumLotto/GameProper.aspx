<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameProper.aspx.cs" Inherits="NumLotto.GameProper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNumber" runat="server" Text="Input your number below: "></asp:Label>
            <br />
            <asp:TextBox ID="txtNumber" runat="server" Height="63px" Font-Bold="True" Font-Size="Large" TextMode="Number" Width="181px"></asp:TextBox>
            <p>
                <asp:Button ID="btnGuess" runat="server" Text="Click & Good Luck!" OnClick="GuessNumber" UseSubmitBehavior="false" />
            </p>
            <p>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />
            </p>
        </div>
    </form>
</body>
</html>
