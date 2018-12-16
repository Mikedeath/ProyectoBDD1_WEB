<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_principal.aspx.cs" Inherits="ProyectoBDD1_WEB.WebForm2" %>

<!DOCTYPE html>
<html lang="en">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title>Menu Principal</title>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
    <link href='https://fonts.googleapis.com/css?family=Oswald:300' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">

    <link rel='stylesheet' href='https://ilt-insightdlp-static.s3.amazonaws.com/css/default.css'>

    <link rel="stylesheet" href="css/style.css">
</head>

<body>
    <style>
        body, h1, h2, h3, h4, h5 {
            font-family: "Raleway", sans-serif;
            font-size:90px;
            margin-top: 100px;
            top: -97px;
            left: 1px;
        }
    </style>
    <div class="w3-content" style="max-width: 1400px">

        <header class="w3-container w3-center w3-padding-32">
            <h1>&nbsp;<b>MENU PRINCIPAL</b></h1>
            
        </header>
    </div>

    <form runat="server">
        <div class="container row-xGrid-yMiddle">
            <div class="row-xGrid iso-standard">



                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Clientes" ID="Clientes_btn" runat="server" BackColor="#f0b81f" OnClick="Clientes_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Ordenes de Desarrollo" ID="Ordenes_btn" runat="server" BackColor="#f0b81f" OnClick="Ordenes_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Equipos" ID="Equipos_btn" runat="server" BackColor="#f0b81f" OnClick="Equipos_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Empleados" ID="Empleados_btn" runat="server" BackColor="#f0b81f" OnClick="Empleados_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Equipos de Trabajo" ID="Equipos_de_trabajo_btn" runat="server" BackColor="#f0b81f" OnClick="Equipos_de_trabajo_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Herramientas" ID="Herramientas_btn" runat="server" BackColor="#f0b81f" OnClick="Herramientas_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Proyectos" ID="Proyectos_btn" runat="server" BackColor="#f0b81f" OnClick="Proyectos_btn_Click"></asp:Button>

                <asp:Button class="ctrl-standard is-reversed typ-subhed fx-bubbleDown" Text="Actividades" ID="Actividades_btn" runat="server" BackColor="#f0b81f" OnClick="Actividades_btn_Click"></asp:Button>
            </div>
        </div>

    </form>





</body>

</html>
