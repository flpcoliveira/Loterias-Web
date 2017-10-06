using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loterias.Models.Util;

namespace Loterias.Servicos
{
    public sealed class MegaSenaServico : LoteriaServico
    {
        public MegaSenaServico() : base(JogoLoteriaEnum.MegaSena)
        {
        }

        internal int ContarAcertos(ulong? numAposta)
        {
            var aposta = Jogo.ObterAposta(numAposta);

            if (aposta == null) return -1;
            int qtdAcertos = 0;

            foreach (var resultado in Jogo.Resultado)
            {
                foreach (var num in aposta.NumerosSelecionados)
                {
                    if (resultado == num) qtdAcertos++;
                }
            }
            return qtdAcertos;            
        }
    }
}