<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarUsuario.aspx.cs" Inherits="LivrotecTCC.editarUsuario" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" >
    <title>Usuários</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="https://blogfonts.com/css/aWQ9NTYyNDgmc3ViPTI0OCZjPWgmdHRmPUhpbmRLb2NoaS1NZWRpdW0udHRmJm49aGluZC1rb2NoaS1tZWRpdW0tMw/Hind Kochi Medium.ttf" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <header id="headerTelaPrincipal">
            <a href='index.aspx'>
                <div id="areaLogo">
                    <img src="imagens/LogoLivrotec.png"/ class="logoLivrotec"/>
                </div>
            </a>
           <section class="icone" id="icone" runat="server"> <p><%=  this.Email?.Substring(0, 1)?.ToUpper() %> </p> </section>

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

        <main id="areaEditarUsuario">
            <div>
                <section style="text-align:center;">
                    <h2>Editar Usuário</h2>
                </section>
                <section>
                    <p>Email</p>
                    <asp:TextBox ID="txtEmail" runat="server" class="form-contrl filtroLogin" placeholder="Digite o e-mail do usuário"></asp:TextBox>
                </section>

                <section style="text-align:center;">
                    <asp:Button ID="btnSelecionarUsuario" runat="server" Text="Selecionar Usuário" OnClick="btnSelecionarUsuario_Click"/>
                </section>

                <section>
                    <p><asp:Literal ID="litNome" runat="server"></asp:Literal></p>
                    <asp:TextBox ID="txtNome" runat="server" class="form-contrl filtroLogin invisivel" placeholder="Digite o"></asp:TextBox>
                </section>

                <section>
                    <p><asp:Literal ID="litSenha" runat="server"></asp:Literal></p>
                    <asp:TextBox ID="txtSenha" runat="server" class="form-contrl filtroLogin invisivel" placeholder="Digite a nova senha"></asp:TextBox>
                </section>

                <section>
                    <p><asp:Literal ID="litTelefone" runat="server"></asp:Literal></p>
                    <asp:TextBox ID="txtTelefone" runat="server" class="form-contrl filtroLogin invisivel" placeholder="Digite o novo telefone"></asp:TextBox>
                </section>

                <section>
                    <p><asp:Literal ID="litCPF" runat="server"></asp:Literal></p>
                    <asp:TextBox ID="txtCPF" runat="server" class="form-contrl filtroLogin invisivel" placeholder="Digite o novo CPF"></asp:TextBox>
                </section>

                <section style="text-align:center;">
                    <asp:Button ID="btnEditar" runat="server" Text="Editar Usuário" OnClick="btnEditar_Click"/>
                </section>
                
                <section class="erro" >
                    <asp:Label ID="erro" runat="server" Text="" ></asp:Label>
                </section>

            </div>
        </main>

    </form>
</body>
</html>
