<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CalculadoraJuan.Calculadora" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Calculadora Juan</title>
    <link href="Estilos.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    <main class="calculadora">
        <header><span class="marca">JUAN / CÁLCULO</span><h1>Calculadora Juan</h1></header>
        <div class="pantalla" aria-live="polite"><asp:Label ID="Pantalla" runat="server" Text="0" /></div>
        <asp:Label ID="Mensaje" runat="server" CssClass="mensaje" role="status" />
        <div class="teclado">
            <asp:Button runat="server" ID="Cuadrado" Text="x²" ToolTip="Elevar al cuadrado" OnClick="Unaria_Click" CommandArgument="cuadrado" CssClass="funcion" />
            <asp:Button runat="server" ID="Exponencial" Text="exp" ToolTip="e elevado al número mostrado" OnClick="Unaria_Click" CommandArgument="exp" CssClass="funcion" />
            <asp:Button runat="server" ID="Diez" Text="10ˣ" ToolTip="Diez elevado al número mostrado" OnClick="Unaria_Click" CommandArgument="diez" CssClass="funcion" />
            <asp:Button runat="server" ID="Limpiar" Text="C" ToolTip="Borrar todo" OnClick="Limpiar_Click" CssClass="limpiar" />
            <asp:Button runat="server" ID="N7" Text="7" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N8" Text="8" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N9" Text="9" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="Dividir" Text="÷" ToolTip="División" OnClick="Operacion_Click" CommandArgument="/" CssClass="operador" />
            <asp:Button runat="server" ID="N4" Text="4" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N5" Text="5" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N6" Text="6" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="Multiplicar" Text="×" ToolTip="Multiplicación" OnClick="Operacion_Click" CommandArgument="*" CssClass="operador" />
            <asp:Button runat="server" ID="N1" Text="1" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N2" Text="2" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N3" Text="3" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="Restar" Text="−" ToolTip="Resta" OnClick="Operacion_Click" CommandArgument="-" CssClass="operador" />
            <asp:Button runat="server" ID="Punto" Text="." ToolTip="Punto decimal" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="N0" Text="0" OnClick="Numero_Click" />
            <asp:Button runat="server" ID="Borrar" Text="⌫" ToolTip="Borrar el último dígito" OnClick="Borrar_Click" />
            <asp:Button runat="server" ID="Sumar" Text="+" ToolTip="Suma" OnClick="Operacion_Click" CommandArgument="+" CssClass="operador" />
            <asp:Button runat="server" ID="Igual" Text="=" ToolTip="Calcular resultado" OnClick="Igual_Click" CssClass="igual" />
        </div>
        <p class="nota">x² · exp · 10ˣ se aplican al número en pantalla.</p>
    </main>
</form>
</body>
</html>
