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

        public SortedSet<byte> NumerosSelecionados { get;  }

        public bool Surpresinha { get;  }

        public Aposta(bool surpresinha)
        {
            NumAposta = ProximoNumeroAposta++;
            this.NumerosSelecionados = new SortedSet<byte>();
            this.Surpresinha = surpresinha;
        }

        public void Alterar()
        {
            
        }
    }
}