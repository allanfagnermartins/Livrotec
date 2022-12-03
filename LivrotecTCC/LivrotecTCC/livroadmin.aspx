<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="livroadmin.aspx.cs" Inherits="LivrotecTCC.livroAdmin" %>

<%@ Register Src="~/LHeader.ascx" TagPrefix="uc1" TagName="LHeader" %>


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
        <uc1:LHeader runat="server" ID="LHeader" />
      
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
                                <asp:Button ID="btnEditarLivro" CssClass="btnLivro" runat="server" Text="Editar Livro" OnClick="btnEditarLivro_Click" />
                                <asp:Literal ID="litQuantidadeFila" runat="server"></asp:Literal>
                            </section>
                        </div>
                    </main>
                </ContentTemplate>
            </asp:UpdatePanel>


    </form>
</body>
</html>
