using Loterias.Models.Util;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;

namespace Loterias.Models.Dados
{

    public class DadosJogos
    {
        private static HashSet<JogoLoteria> jogos = new HashSet<JogoLoteria>();
        public static void RegistrarJogos()
        {
            jogos.Add(new JogoLoteria { Nome = JogoLoteriaEnum.MegaSena.GetDescricao(), QtdNumerosDisponiveis = 60, QtdNumerosAposta = 6, IncluirZero = false });
        }

        internal static JogoLoteria ObterAposta(JogoLoteriaEnum jogo)
        {
            return jogos.FirstOrDefault(x => x.Nome.Equals(jogo.GetDescricao()));
        }

        public static void RegistrarAposta(JogoLoteriaEnum jogo,  Aposta aposta)
        {
            var megaSena = jogos.FirstOrDefault(x => x.Nome.Equals(jogo.GetDescricao()));
            megaSena.IncluirAposta(aposta);
        }


        public enum JogoLoteriaEnum
        {
            [Description("Mega Sena")]
            MegaSena
        }
    }
}