 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LivrotecTCC.index1" %>

<%@ Register Src="~/LHeader.ascx" TagPrefix="uc1" TagName="LHeader" %>


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
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&display=swap" rel="stylesheet">
    <link rel="preload" href="fontes/HindKochi-Regular.woff2" as="font" type="font/woff2" crossorigin>
    <script type="text/javascript" src="js/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">


        <uc1:LHeader runat="server" ID="LHeader" />
        <!--<div id="areaFiltros">
            <input placeholder="Buscar livro" type="text" name="Busca" class="form-control" id="filtroBusca">
            <button id="btnFiltro" onclick="filtroBusca"><i class="fa fa-search"></i> </button>
        </div>-->
        
        <h2 style='max-width: 85%; margin: auto;' id="TituloMinhasFilas" runat="server" visible="false"> Minhas Filas </h2>
        <main style="margin-top: 16px; margin-bottom: 36px;" class="areaLivros" id="MainMeusLivros" runat="server" visible="false">
            <asp:Repeater id="MinhasFilasRepeater" runat="server"> 
                <ItemTemplate>
                    <a href='livro.aspx?cd=<%# Eval("ISBN") %>' class = 'cardFila'>
                        <img src='imagens/<%# Eval("Caminho") %>.jpg'  class='imgLivro' alt='capa do livro '<%# Eval("Nome") %>>
                        <p id='titulo'><%# Eval("Nome") %></p>
                    </a> 
                </ItemTemplate> 
            </asp:Repeater>
        </main>

        <h2 style='max-width: 85%; margin: auto;' id="TituloNaoMinhasFilas" runat="server" visible="false"> Outras Filas </h2>
        <main style="margin-top: 16px; margin-bottom: 36px;" id="MainOutrasFilas" class="areaLivros" runat="server" visible="false">
            <asp:Repeater id="OutrasFilasRepeater" runat="server"> 
                <ItemTemplate>
                    <a href='livro.aspx?cd=<%# Eval("ISBN") %>' class = 'cardFila'>
                        <img src='imagens/<%# Eval("Caminho") %>.jpg'  class='imgLivro' alt='capa do livro '<%# Eval("Nome") %>>
                        <p id='titulo'><%# Eval("Nome") %></p>
                    </a> 
                </ItemTemplate> 
            </asp:Repeater>
        </main>

        <main class="areaLivros" id="MainTodasFilas" runat="server" visible="false">
            <asp:Repeater id="FilasRepeater" runat="server"> 
                <ItemTemplate>
                    <a href='livro.aspx?cd=<%# Eval("ISBN") %>' class = 'cardFila'>
                        <img src='imagens/<%# Eval("Caminho") %>.jpg'  class='imgLivro' alt='capa do livro '<%# Eval("Nome") %>>
                        <p id='titulo'><%# Eval("Nome") %></p>
                    </a> 
                </ItemTemplate> 
            </asp:Repeater>
        </main>
    </form>
</body>
</html>
