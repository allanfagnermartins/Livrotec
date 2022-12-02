<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="duvidas.aspx.cs" Inherits="LivrotecTCC.comodoar" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Dúvidas</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="https://blogfonts.com/css/aWQ9NTYyNDgmc3ViPTI0OCZjPWgmdHRmPUhpbmRLb2NoaS1NZWRpdW0udHRmJm49aGluZC1rb2NoaS1tZWRpdW0tMw/Hind Kochi Medium.ttf" rel="stylesheet" type="text/css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&display=swap" rel="stylesheet">
    <link rel="preload" href="fontes/HindKochi-Regular.woff2" as="font" type="font/woff2" crossorigin="">
    <script type="text/javascript" src="js/script.js"></script>
</head>

<body>
    <form id="form1" runat="server">

        <header id="headerTelaPrincipal">
            <a href='index.aspx'>
                <div id="areaLogo">
                    <img src="imagens/LogoLivrotec.png"/ class="logoLivrotec">
                </div>
            </a>
        </header>

        <main id="mainDuvidas">

            <section class="secDuvidas">
                <h1 id="tituloComoDoar">
                    Como Doar?
                </h1>
                <p id="pComoDoar">
                    O processo é muito simples! Basta o usuário se comparecer à sua unidade escolar com o livro que deseja doar, onde um funcionário da escola o cadastrará no sistema.
                </p>
                <img src="imagens/doacaolivro.png" class="imgDuvidas"/>
            </section>

            <section class="secDuvidas">
                <h1 id="tituloEsqcSenha">
                    Esqueceu sua senha?
                </h1>
                <p>
                    Contate sua instituição sobre o ocorrido para que seja solicitada uma nova senha!
                </p>
                <img src="imagens/esquecisenha.png" class="imgDuvidas"/>
            </section>

            <section class="secDuvidas">
                <h1>
                    Perdeu o livro?
                </h1>
                <p>
                    Contate a instituição sobre o ocorrido e as devidas providências sejam tomadas.
                </p>
                <img src="imagens/livroPerdido.png" class="imgDuvidas"/>
            </section>



        </main>
        
    </form>
</body>
</html>
