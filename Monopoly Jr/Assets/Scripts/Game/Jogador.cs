using System;
using System.Collections.Generic;

namespace Game
{
    public class Jogador
    {
        private int saldo;
        private int posicao;
        private Personagem personagem;

        public List<Propriedade> propriedades = new();
        public Efeito efeitoInicial;
        public EfeitoHabeasCorpus efeitoHabeasCorpus;

        public Jogador(Personagem personagem)
        {
            saldo = 18;
            posicao = 0;
            this.personagem = personagem;
        }

        private int JogarDado()
        {
            Random dado = new Random();
            int resultado = dado.Next(1, 6);
            return resultado;
        }

        private void GanharDinheiroPorVolta()
        {
            saldo += 2;
        }

        public void Receber(int dinheiro)
        {
            saldo += dinheiro;
        }

        public void Pagar(int dinheiro)
        {
            saldo -= dinheiro;

        }

        public void IniciarRodada()
        {
            Jogador jogador = Tabuleiro.GetInstance().JogadorAtual();
            int passos = jogador.JogarDado();
            jogador.Mover(passos);
        }

        public async void Mover(int passos)
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            List<Casa> casas = tabuleiro.casas;
            for (int passo = 0; passo < passos; passo++)
            {
                if (posicao > casas.Count)
                {
                    posicao = 0;

                    GanharDinheiroPorVolta();
                }
                else
                {
                    posicao += 1;
                }
                await tabuleiro.InterfaceUsuario.MoverPersonagemUmPasso(personagem, posicao);
            }
        }

        public void Teleportar(int posicaoCasa)
        {
            posicao = posicaoCasa;
        }
    }
}
