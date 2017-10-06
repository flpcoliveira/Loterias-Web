using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loterias.Models
{
    public class Aposta
    {

        private static ulong ProximoNumeroAposta { get; set; } = 1;

        public ulong NumAposta { get; private set; }

        public SortedSet<int> NumerosSelecionados { get;  }

        public bool Surpresinha { get;  }

        public Aposta(bool surpresinha, IEnumerable<int> numeros)
        {
            NumAposta = ProximoNumeroAposta++;
            this.NumerosSelecionados = new SortedSet<int>(numeros);
            this.Surpresinha = surpresinha;
        }

        public void Alterar()
        {
            
        }
    }
}