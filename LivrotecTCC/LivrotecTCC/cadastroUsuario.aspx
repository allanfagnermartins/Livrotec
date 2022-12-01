<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroUsuario.aspx.cs" Inherits="LivrotecTCC.cadastroUsuario" %>

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

        <main id="doacao">
            <div>
                <section style="text-align:center;">
                    <h2>Novo usuário</h2>
                </section>
                <section>
                    <p>Email</p>
                    <asp:TextBox ID="Email" runat="server" class="form-contrl filtroLogin" placeholder="Digite o Email do usuário"></asp:TextBox>
                </section>

                <section>
                    <p>Nome</p>
                    <asp:TextBox ID="Nome" runat="server" class="form-contrl filtroLogin" placeholder="Digite o nome do usuário"></asp:TextBox>
                </section>
                <section>
                    <p>Senha</p>
                    <asp:TextBox ID="Senha" runat="server" class="form-contrl filtroLogin" placeholder="Digite a semja do usuário"></asp:TextBox>
                </section>
                <section>
                     <p>Telefone</p>
                    <asp:TextBox ID="Telefone" runat="server" class="form-contrl filtroLogin" placeholder="Digite o telefone do usuário"></asp:TextBox>
                </section>
                <section>
                     <p>CPF</p>
                    <asp:TextBox ID="CPF" runat="server" class="form-contrl filtroLogin" placeholder="Digite o CPF do usuário"></asp:TextBox>
                </section>

                <section style="text-align:center;">
                    <asp:Button ID="btnLogin" runat="server" Text="Criar usuário" OnClick="btnLogin_Click"  />
                </section>
                <section class="erro" >
                <asp:Label ID="erro" runat="server" Text="" ></asp:Label>
                </section>
            </div>
        </main>

        <div>
        </div>
    </form>
</body>
</html>
