﻿using Loterias.Models;
using Loterias.Models.Dados;
using Loterias.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loterias.Servicos
{
    public abstract class LoteriaServico
    {
        public JogoLoteria Jogo { get; private set; }

        protected LoteriaServico(JogoLoteriaEnum jogoEnum)
        {
            Jogo = DadosJogos.ObterJogoLoteria(jogoEnum);
        }

        public Aposta RegistrarAposta(int[] numeros, bool surpresinha)
        {
            HashSet<int> listaNumeros;
            Aposta aposta = null;
            if (surpresinha || numeros == null)
            {
                listaNumeros = new HashSet<int>(ObterNumeros(Jogo.QtdNumerosAposta));
            }
            else
            {
                listaNumeros = new HashSet<int>(numeros);
                if (listaNumeros.Count <= Jogo.QtdNumerosAposta)
                {
                    while (listaNumeros.Count != Jogo.QtdNumerosAposta)
                    {
                        List<int> numerosFaltando = ObterNumeros(Jogo.QtdNumerosAposta - listaNumeros.Count);
                        foreach (var v in numerosFaltando)
                        {
                            listaNumeros.Add(v);
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            aposta = new Aposta(surpresinha, listaNumeros.ToList());
            Jogo.IncluirAposta(aposta);
            return aposta;
        }

        protected int ObterNumero(int inicio, int fim)
        {
            Random random = new Random();
            int numero = random.Next(inicio, fim);
            return numero;
        }

        protected List<int> ObterNumeros(int qtdMaxima)
        {
            List<int> numeros = new List<int>();
            int inicio = 0;
            int fim = Jogo.QtdNumerosDisponiveis;
            int numero;

            if (!Jogo.IncluirZero)
            {
                inicio++;
                fim++;
            }

            while (numeros.Count != qtdMaxima)
            {
                numero = ObterNumero(inicio, fim);
                if (!numeros.Contains(numero))
                {
                    numeros.Add(numero);
                }
            }

            return numeros;
        }

        public void RegistrarSorteio()
        {
            var numeros = ObterNumeros(Jogo.QtdNumerosSorteados);
            if (Jogo.Resultado.Count != Jogo.QtdNumerosSorteados)
            {
                foreach (var numero in numeros)
                {
                    Jogo.Resultado.Add(numero);
                }
            }

        }


    }
}