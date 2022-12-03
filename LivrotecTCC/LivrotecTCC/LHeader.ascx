<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LHeader.ascx.cs" Inherits="LivrotecTCC.LHeader" %>
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

    <section class="icone" id="icone" runat="server"> <p><%=  this.Email?.Substring(0, 1)?.ToUpper()  %> </p> </section>

    <div class="dropdown" id ="dropdown" runat="server">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
        <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 8.25l-7.5 7.5-7.5-7.5" />
        </svg>
        <div class="dropdown-content">
            <asp:LinkButton ID="btnSair" runat="server" OnClick="btnSair_Click">Sair</asp:LinkButton>  
            <asp:LinkButton href="duvidas.aspx" runat="server" >F.A.Q</asp:LinkButton>  
        </div>
    </div>
     
</header>