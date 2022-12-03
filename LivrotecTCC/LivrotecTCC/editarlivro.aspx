<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarlivro.aspx.cs" Inherits="LivrotecTCC.editarlivro" %>

<!DOCTYPE html>

<html>

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Administrar livro</title>
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

           <section class="icone" id="icone" runat="server"> <p><%=  this.Email?.Substring(0, 1)?.ToUpper()  %> </p> </section>
            <div class="dropdown" id ="dropdown" runat="server">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round" d="    19.5 8.25l-7.5 7.5-7.5-7.5" />
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

        <main id="doacao">
            <div>
                <section style="text-align:center;">
                    <h2>Editar ISBN: <%= this.ISBN %></h2>
                </section>
 

                <section id="secNome" runat="server">
                    <p>Nome Livro</p>
                    <asp:TextBox ID="TxtNome" runat="server" class="form-contrl filtroLogin" placeholder="Digite o nome do livro"></asp:TextBox>
                </section>
                <section id="secCapa" runat="server" >
                    <p>Sinopse</p>
                    <asp:TextBox ID="TxtSinopse" runat="server" class="form-contrl filtroLogin" placeholder="Digite a sinopse do livro"></asp:TextBox>
                </section>
                <section id="Section1" runat="server" >
                    <p>Quantidade Exemplares</p>
                    <asp:TextBox ID="TxtQuantidade" runat="server" type="number" class="form-contrl filtroLogin" placeholder="Digite a quantidade de exemplares"></asp:TextBox>
                </section>

                <section id="secImagem" runat="server">
                    <p>Foto da Capa</p>
                    <asp:FileUpload ID="fileUp" runat="server" />
                </section>

                <section style="text-align:center;">
                    <asp:Button ID="btnLogin" runat="server" Text="Confirmar" OnClick="btnLogin_Click" />
                </section>
                <section class="erro" >
                <asp:Label ID="txtErro" runat="server" Text="" ></asp:Label>
                </section>
            </div>
        </main>
 


    </form>
</body>
</html>
