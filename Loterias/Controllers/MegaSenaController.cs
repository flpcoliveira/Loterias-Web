using Loterias.Models.Dados;
using System.Web.Mvc;

namespace Loterias.Controllers
{
    public class MegaSenaController : Controller
    {
        // GET: MegaSena
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Apostar()
        {
            return View(DadosJogos.ObterAposta(DadosJogos.JogoLoteriaEnum.MegaSena));
        }

        [HttpPost]
        public ActionResult RegistrarAposta(int [] numeros = null, bool surpresinha = false)
        {
            return View("Index");
        }
    }
}