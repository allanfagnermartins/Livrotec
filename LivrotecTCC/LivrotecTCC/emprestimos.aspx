<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emprestimos.aspx.cs" Inherits="LivrotecTCC.emprestimos" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" 
    rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" 
    crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Livrotec</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="https://blogfonts.com/css/aWQ9NTYyNDgmc3ViPTI0OCZjPWgmdHRmPUhpbmRLb2NoaS1NZWRpdW0udHRmJm49aGluZC1rb2NoaS1tZWRpdW0tMw/Hind Kochi Medium.ttf" rel="stylesheet" type="text/css"/>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>
        <div id="areaFiltros">
            <input placeholder="Buscar livro" type="text" name="Busca" class="form-control" id="filtroBusca">
            <button id="btnFiltro" onclick="filtroBusca"><i class="fa fa-search"></i> </button>
        </div>

        <main class="areaLivros">
            <asp:Literal ID="litEmprestimos" runat="server"></asp:Literal>
        </main>
                        </ContentTemplate>
                </asp:UpdatePanel>

    </form>
</body>
</html>
