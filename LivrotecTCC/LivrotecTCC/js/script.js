var btnTelaFila = document.querySelector(".cardFila");
var telaBloqueio = document.querySelector(".bloqueio");
var telaInfoFila = document.querySelector(".containerTelaLivro");
var btnFecharFila = document.querySelectorAll(".btnFecharTela");
var btnSairFila = document.querySelector(".btnSairFila");
var btnEntrarFila = document.querySelector(".btnEntrarFila");

function fecharTelaInfoLivro(event)
{
    telaBloqueio.classList.add("invisivel");
    console.log("oiii");
}

btnFiltro.addEventListener('click', filtroBusca);

function filtroBusca(event)
{
    event.preventDefault();

    let txtNome = document.querySelector("#buscaLivro").value.toUpperCase();
    let cards = document.querySelectorAll("#cardFila");

    for (var i = 0; i < cards.length; i++) {
        
        if (txtNome != cards[i].querySelector("#titulo").textContent.toUpperCase().substring(0, txtNome.length)) {
            console.log(cards[i]);
            cards[i].classList.add("invisivel");
        }
        else { 
            cards[i].classList.remove("invisivel");
        };
    }

}

function deleteAllCookies() {
    var cookies = document.cookie.split(";");

    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        var eqPos = cookie.indexOf("=");
        var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}


