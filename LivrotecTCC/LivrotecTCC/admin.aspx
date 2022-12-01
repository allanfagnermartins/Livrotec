﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="LivrotecTCC.admin" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
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

            <a href='login.aspx'>
                <div id="areaLogin">
                    <h2>
                    <asp:Literal ID="litLogin" runat="server"></asp:Literal>
                    </h2>
                </div>
            </a>

            <section class="icone" id="icone" runat="server"> <asp:Literal ID="litInicialEmail" runat="server"></asp:Literal> </section>
            <div class="dropdown" id ="dropdown" runat="server">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 8.25l-7.5 7.5-7.5-7.5" />
                </svg>
                <div class="dropdown-content">
                      <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">Sair</asp:LinkButton>  
                </div>
            </div>

            <div id="areaUsuario">
                <div id="notificacoesUsuario"></div>
                <div id="funcoesUsuario"></div>
            </div>
        </header>

        <div class="container" id="areaAdmin">
            <a href='doacao.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <img src='imagens/imgDoacaoLivro.png' alt='Uma mão segurando um livro' class='imgAdmin' style='height: 250px;'>
                    <p class='prAdmin'>Doações</p>
                </div>
            </a>
            <a href='emprestimos.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <img src='imagens/imgEmprestimoLivro.png' alt='Pilha de livros' class='imgAdmin' style='height: 250px;'>
                    <p class='prAdmin'>Empréstimos</p>
                </div>
            </a>
            <a href='livrosadmin.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <img src='imagens/imgEmprestimoLivro.png' alt='Pilha de livros' class='imgAdmin' style='height: 250px;'>
                    <p class='prAdmin'>Livros</p>
                </div>
            </a>

        </div>

    </form>

</body>
</html>
