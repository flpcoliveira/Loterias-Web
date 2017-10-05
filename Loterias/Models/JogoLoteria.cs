using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loterias.Models
{
    public class JogoLoteria
    {
        public JogoLoteria()
        {
            this.Apostas = new List<Aposta>();
        }

        public string Nome { get; set; }

        public byte QtdNumerosDisponiveis { get; set; }

        public byte QtdNumerosAposta { get; set; }

        public bool IncluirZero { get; set; }

        private List<Aposta> Apostas { get; set; }

        public void IncluirAposta(Aposta aposta)
        {
            Apostas.Add(aposta);
        }
    }
}