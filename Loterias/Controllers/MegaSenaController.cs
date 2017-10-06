using Loterias.Models;
using Loterias.Models.Dados;
using Loterias.Models.Util;
using Loterias.Servicos;
using System;
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
        public ActionResult RegistrarAposta(int[] numeros = null, bool surpresinha = false)
        {
            var aposta = megaSenaServico.RegistrarAposta(numeros, surpresinha);

            if (aposta != null)
            {
                return View("Confirmacao", aposta);
            }

            List<string> mensagens = new List<string>();
            mensagens.Add("Selecione no máximo " + megaSenaServico.Jogo.QtdNumerosAposta + " números");

            ViewBag.Mensagens = mensagens;
            ViewBag.Numeros = numeros;


            return View("Apostar", megaSenaServico.Jogo);
        }

        public ActionResult Sorteio()
        {
            megaSenaServico.RegistrarSorteio();
            return View(megaSenaServico.Jogo.Resultado);
        }

        public ActionResult Resultados(Nullable<ulong> numAposta)
        {
            Aposta apostaEncontrada;
            if(numAposta != null)
            {
                apostaEncontrada = megaSenaServico.Jogo.ObterAposta(numAposta);
                ViewBag.NumAposta = numAposta;
                ViewBag.Aposta = apostaEncontrada;
                if(apostaEncontrada == null)
                {
                    var listaMsg = new List<string>();
                    listaMsg.Add("Aposta não encontrada");
                    ViewBag.Mensagens = listaMsg;
                }
                else
                {
                    int qtdAcertos = megaSenaServico.ContarAcertos(numAposta);
                    ViewBag.QtdAcertos = qtdAcertos;
                }
            }
            return View(megaSenaServico.Jogo);
        }
    }
}