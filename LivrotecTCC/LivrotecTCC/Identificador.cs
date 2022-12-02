using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

namespace LivrotecTCC
{
    class Identificador
    {
        public BancoDeDados BD;
        public string Email => cookie?["Email"];
        public string Senha => cookie?["Senha"];
        Page pagina;
                
        HttpCookie cookie => pagina.Request.Cookies["loginUsuario"];
        public Identificador( BancoDeDados bd, Page pagina)
        {
            BD = bd;
            this.pagina = pagina;
            pagina.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            pagina.Response.Cache.SetMaxAge(TimeSpan.Zero);
            pagina.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            pagina.Response.Cache.SetNoStore();
        }
        public void RegistrarCookie(string email, string senha)
        {
            HttpCookie novoCookie = new HttpCookie("loginUsuario");

            novoCookie["Email"] = email;
            novoCookie["Senha"] = senha;
            novoCookie.HttpOnly = true;

            pagina.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            pagina.Response.Cache.SetMaxAge(TimeSpan.Zero);
            pagina.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            pagina.Response.Cache.SetNoStore();
            pagina.Response.Cookies.Add(novoCookie);
        }
        public bool EstaLogado()
        {
            return cookie != null && cookie["Email"] != null && cookie["Senha"] != null;
        }
        public bool LoginValido()
        {
            return EstaLogado() && BD.Usuarios.LoginValido(Email, Senha);
        }
        public bool EhAdministrador()
        {
            return LoginValido() && BD.Usuarios.VerificarAdmin(Email);
        }

        public void Logout()
        {
            if (EstaLogado())
                pagina.Response.Cookies["loginUsuario"].Expires = DateTime.Now.AddDays(-1);
            pagina.Response.Redirect("index.aspx");
        }
    }
}