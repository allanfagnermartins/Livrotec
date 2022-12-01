<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doacoes.aspx.cs" Inherits="LivrotecTCC.doacoes" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Livrotec</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="https://blogfonts.com/css/aWQ9NTYyNDgmc3ViPTI0OCZjPWgmdHRmPUhpbmRLb2NoaS1NZWRpdW0udHRmJm49aGluZC1rb2NoaS1tZWRpdW0tMw/Hind Kochi Medium.ttf" rel="stylesheet" type="text/css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&display=swap" rel="stylesheet">
    <link rel="preload" href="fontes/HindKochi-Regular.woff2" as="font" type="font/woff2" crossorigin="">
</head>
<body>

    <form id="form1" runat="server">

        <header id="headerTelaPrincipal">
            <a href='index.aspx'>
                <div id="areaLogo">
                    <img src="imagens/LogoLivrotec.png"/ class="logoLivrotec">
                </div>
            </a>

            <div id="areaUsuario">
                <div id="notificacoesUsuario"></div>
                <div id="funcoesUsuario"></div>
            </div>
        </header>

        <div id="areaFiltros">
            <input placeholder="Buscar livro" type="text" name="Busca" class="form-control" id="filtroBusca">
            <button id="btnFiltro" onclick="filtroBusca"><i class="fa fa-search"></i> </button>
        </div>

        <main id="mainAreaDoacoes">
            <asp:Literal ID="litDoacoes" runat="server"></asp:Literal>
        </main>

    </form>

</body>
</html>
