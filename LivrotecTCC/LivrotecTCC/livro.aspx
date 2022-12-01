<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="livro.aspx.cs" Inherits="LivrotecTCC.livro" %>

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
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Raleway&display=swap" rel="stylesheet">
</head>

<body>
    <form id="form1" runat="server">
        <header id="headerTelaPrincipal">
            <a href='index.aspx'>
                <div id="areaLogo">
                    <img src="imagens/LogoLivrotec.png"/ class="logoLivrotec">
                </div>
            </a>

            <a href='login.aspx' ID="AreaLogin" runat="server">
                <div id="areaLogin">
                    <h2> Login </h2>
                </div>
            </a>

           <section class="icone" id="icone" runat="server"> <asp:Literal ID="litInicialEmail" runat="server"></asp:Literal> </section>
            <div class="dropdown" id ="dropdown" runat="server">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 8.25l-7.5 7.5-7.5-7.5" />
                </svg>
                <div class="dropdown-content">
                      <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click" >Sair</asp:LinkButton>  
                </div>
            </div>

            <div id="areaUsuario">
                <div id="notificacoesUsuario"></div>
                <div id="funcoesUsuario"></div>
            </div>
        </header>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <main id="areaLivro">
                        <div id="areaFotoLivro">
                            <asp:Literal ID="litImagemLivro" runat="server"></asp:Literal>
                        </div>
                        <div id="areaInfoLivro">
                            <asp:Literal ID="litTituloLivro" runat="server"></asp:Literal>
                            <asp:Literal ID="litCategoriasLivro" runat="server"></asp:Literal>
                            <p id="tituloSinopseLivro">Sinopse</p>
                            <asp:Literal ID="litSinopseLivro" runat="server"></asp:Literal>
                            <section id="secQtBtnLivro">
                                <asp:Button ID="btnInfoLivro" runat="server" Text="Button" OnClick="btnInfoLivro_Click" />
                                <asp:Literal ID="litQuantidadeFila" runat="server"></asp:Literal>
                            </section>
                        </div>
                    </main>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
