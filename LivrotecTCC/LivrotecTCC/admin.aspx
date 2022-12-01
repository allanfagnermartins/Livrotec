<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="LivrotecTCC.admin" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Admin</title>
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
                    <svg xmlns='http://www.w3.org/2000/svg' width='250' height='250' preserveAspectRatio='xMidYMid meet' viewBox='0 0 24 24'><path fill='#8A6B32' d='M17.726 13.02L14 16H9v-1h4.065a.5.5 0 0 0 .416-.777l-.888-1.332A1.995 1.995 0 0 0 10.93 12H3a1 1 0 0 0-1 1v6a2 2 0 0 0 2 2h9.639a3 3 0 0 0 2.258-1.024L22 13l-1.452-.484a2.998 2.998 0 0 0-2.822.504zm1.532-5.63c.451-.465.73-1.108.73-1.818s-.279-1.353-.73-1.818A2.447 2.447 0 0 0 17.494 3S16.25 2.997 15 4.286C13.75 2.997 12.506 3 12.506 3a2.45 2.45 0 0 0-1.764.753c-.451.466-.73 1.108-.73 1.818s.279 1.354.73 1.818L15 12l4.258-4.61z' /></svg>
                    <p class='prAdmin'>Doações</p>
                </div>
            </a>
 
            <a href='emprestimos.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <svg xmlns='http://www.w3.org/2000/svg' width='250' height='250' preserveAspectRatio='xMidYMid meet' viewBox='0 0 24 24'><path fill='#8A6B32' d='M6 23q-.825 0-1.412-.587Q4 21.825 4 21V10q0-.825.588-1.413Q5.175 8 6 8h3v2H6v11h12V10h-3V8h3q.825 0 1.413.587Q20 9.175 20 10v11q0 .825-.587 1.413Q18.825 23 18 23Zm5-7V4.825l-1.6 1.6L8 5l4-4l4 4l-1.4 1.425l-1.6-1.6V16Z' /></svg>
                    <p class='prAdmin'>Empréstimos</p>
                </div>
            </a>
            <a href='livrosadmin.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <svg xmlns='http://www.w3.org/2000/svg' width='250' height='250' preserveAspectRatio='xMidYMid meet' viewBox='0 0 24 24'><path fill='#8A6B32' d='M14 8.775q0-.225.163-.463q.162-.237.362-.312q.725-.25 1.45-.375T17.5 7.5q.5 0 .988.062q.487.063.962.163q.225.05.387.25q.163.2.163.45q0 .425-.275.625t-.7.1q-.35-.075-.737-.113Q17.9 9 17.5 9q-.65 0-1.275.125q-.625.125-1.2.325q-.45.175-.737-.025q-.288-.2-.288-.65Zm0 5.5q0-.225.163-.463q.162-.237.362-.312q.725-.25 1.45-.375T17.5 13q.5 0 .988.062q.487.063.962.163q.225.05.387.25q.163.2.163.45q0 .425-.275.625t-.7.1q-.35-.075-.737-.113q-.388-.037-.788-.037q-.65 0-1.275.113q-.625.112-1.2.312q-.45.175-.737-.013q-.288-.187-.288-.637Zm0-2.75q0-.225.163-.463q.162-.237.362-.312q.725-.25 1.45-.375t1.525-.125q.5 0 .988.062q.487.063.962.163q.225.05.387.25q.163.2.163.45q0 .425-.275.625t-.7.1q-.35-.075-.737-.113q-.388-.037-.788-.037q-.65 0-1.275.125q-.625.125-1.2.325q-.45.175-.737-.025q-.288-.2-.288-.65Zm-1 5.525q1.1-.525 2.213-.788Q16.325 16 17.5 16q.9 0 1.763.15q.862.15 1.737.45V6.7q-.825-.35-1.712-.525Q18.4 6 17.5 6q-1.175 0-2.325.3q-1.15.3-2.175.9Zm-1 2.425q-.35 0-.662-.087q-.313-.088-.588-.238q-.975-.575-2.05-.862Q7.625 18 6.5 18q-1.05 0-2.062.275q-1.013.275-1.938.775q-.525.275-1.012-.025Q1 18.725 1 18.15V6.1q0-.275.138-.525q.137-.25.412-.375q1.15-.6 2.4-.9Q5.2 4 6.5 4q1.45 0 2.838.375Q10.725 4.75 12 5.5q1.275-.75 2.663-1.125Q16.05 4 17.5 4q1.3 0 2.55.3q1.25.3 2.4.9q.275.125.413.375q.137.25.137.525v12.05q0 .575-.487.875q-.488.3-1.013.025q-.925-.5-1.938-.775Q18.55 18 17.5 18q-1.125 0-2.2.288q-1.075.287-2.05.862q-.275.15-.587.238q-.313.087-.663.087Z' /></svg>
                    <p class='prAdmin'>Livros</p>
                </div>
            </a>

        </div>

    </form>

</body>
</html>
