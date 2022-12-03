<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminUsuario.aspx.cs" Inherits="LivrotecTCC.adminUsuario" %>

<%@ Register Src="~/LHeader.ascx" TagPrefix="uc1" TagName="LHeader" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Usuários</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="https://blogfonts.com/css/aWQ9NTYyNDgmc3ViPTI0OCZjPWgmdHRmPUhpbmRLb2NoaS1NZWRpdW0udHRmJm49aGluZC1rb2NoaS1tZWRpdW0tMw/Hind Kochi Medium.ttf" rel="stylesheet" type="text/css"/>
    <script src="https://code.iconify.design/3/3.0.1/iconify.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:LHeader runat="server" ID="LHeader" />
        <div class="container" id="areaAdmin">

            <a href='cadastroUsuario.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <svg xmlns="http://www.w3.org/2000/svg" width='250' height='250' preserveAspectRatio='xMidYMid meet' viewBox="0 0 24 24" fill="#8A6B32" class="w-6 h-6"> <path d="M6.25 6.375a4.125 4.125 0 118.25 0 4.125 4.125 0 01-8.25 0zM3.25 19.125a7.125 7.125 0 0114.25 0v.003l-.001.119a.75.75 0 01-.363.63 13.067 13.067 0 01-6.761 1.873c-2.472 0-4.786-.684-6.76-1.873a.75.75 0 01-.364-.63l-.001-.122zM19.75 7.5a.75.75 0 00-1.5 0v2.25H16a.75.75 0 000 1.5h2.25v2.25a.75.75 0 001.5 0v-2.25H22a.75.75 0 000-1.5h-2.25V7.5z" /></svg>
                    <p class='prAdmin'>Cadastrar Usuário</p>
                </div>
            </a>

            <a href='usuarioEditar.aspx' class='aAdmin'>
                <div class='divAdmin'>
                    <span class="iconify" data-icon="fa-solid:user-edit" style="color: #8a6b32;" data-width="250" data-height="250"></span>            
                    <p class='prAdmin'>Editar Usuário</p>
                </div>
            </a>

        </div>

    </form>
</body>
</html>
