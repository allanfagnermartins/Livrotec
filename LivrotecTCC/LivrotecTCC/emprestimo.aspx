<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emprestimo.aspx.cs" Inherits="LivrotecTCC.emprestimo" %>

<%@ Register Src="~/LHeader.ascx" TagPrefix="uc1" TagName="LHeader" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/estilo.css" media="screen" />
    <title>Empréstimo</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="https://blogfonts.com/css/aWQ9NTYyNDgmc3ViPTI0OCZjPWgmdHRmPUhpbmRLb2NoaS1NZWRpdW0udHRmJm49aGluZC1rb2NoaS1tZWRpdW0tMw/Hind Kochi Medium.ttf" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
         
        <uc1:LHeader runat="server" ID="LHeader" />
        <main id="areaLivro">
            <div id="areaFotoLivro">
                <asp:Literal ID="litImagemLivro" runat="server"></asp:Literal>
            </div>

            <div id="areaInfoEmprestimo">

                <section>
                    <asp:Literal ID="litTituloLivro" runat="server"></asp:Literal>
                    <asp:Literal ID="litEmailUsuario" runat="server"></asp:Literal>
                </section>
                
                <section>
                    <p id="pDataEmprestimo">Data Empréstimo: <asp:Literal ID="litDataEmprestimo" runat="server"></asp:Literal> </p>
                </section>
                
                <section>
                    <p id="pDataDevolucao">Data Devolução Prevista: <asp:Literal ID="litDataDevolucao" runat="server"></asp:Literal> </p>
                </section>

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>

                <section>
                    <p id="pDataEfetiva">Data Devolução Efetiva: <asp:Literal ID="litDataEfetiva" runat="server"></asp:Literal> </p>
                </section>

                <asp:Button ID="btnConfirmarDevolucao" runat="server" Text="Confirmar Devolução" OnClick="btnEmprestimo_Click" />
                <asp:Button ID="btnConfirmarEmprestimo" runat="server" Text="Confirmar Empréstimo" OnClick="outroBtnEmprestimo_Click" />
                <asp:Button ID="btnCancelarEmprestimo" runat="server" Text="Cancelar Empréstimo" OnClick="btnCancelarEmprestimo_Click" />
                <asp:Button ID="btnEmprestimoRoubado" runat="server" Text="Confirmar Roubo" OnClick="btnEmprestimoRoubado_Click" />

                <asp:Literal ID="litSituacaoEmprestimo" runat="server"></asp:Literal>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </main>

    </form>
</body>
</html>
