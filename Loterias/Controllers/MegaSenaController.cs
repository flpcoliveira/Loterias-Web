using Loterias.Models.Dados;
using Loterias.Models.Util;
using Loterias.Servicos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Loterias.Controllers
{
    public class MegaSenaController : Controller
    {
        private static MegaSenaServico megaSenaServico = new MegaSenaServico();

        // GET: MegaSena
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Apostar()
        {
            return View(megaSenaServico.Jogo);
        }

        [HttpPost]
        public ActionResult RegistrarAposta(int [] numeros = null, bool surpresinha = false)
        {
            var aposta = megaSenaServico.RegistrarAposta(numeros, surpresinha);

            if(aposta != null)
            {
                return View("Confirmacao", aposta);
            }

            List<string> mensagens = new List<string>();
            mensagens.Add("Selecione no máximo " + megaSenaServico.Jogo.QtdNumerosAposta + " números");

            ViewBag.Mensagens = mensagens;
            ViewBag.Numeros = numeros;


            return View("Apostar", megaSenaServico.Jogo);
        }
    }
}