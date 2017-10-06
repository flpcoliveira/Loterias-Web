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
            Resultado = new SortedSet<int>();
        }

        public string Nome { get; set; }

        public byte QtdNumerosDisponiveis { get; set; }

        public byte QtdNumerosAposta { get; set; }

        public bool IncluirZero { get; set; }

        public byte QtdNumerosSorteados { get; set; }

        private List<Aposta> Apostas { get; set; }

        public SortedSet<int> Resultado { get; set; }

        public void IncluirAposta(Aposta aposta)
        {
            Apostas.Add(aposta);
        }

        internal Aposta ObterAposta(ulong? numAposta)
        {
            Aposta aposta = null;

            aposta = Apostas.FirstOrDefault(x => x.NumAposta == numAposta);

            return aposta;
        }
    }
}