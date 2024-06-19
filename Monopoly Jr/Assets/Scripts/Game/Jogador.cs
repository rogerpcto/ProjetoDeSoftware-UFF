using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game
{
    public class Jogador
    {
        private int saldo;
        private int posicao;
        private readonly Personagem personagem;

        public List<Propriedade> propriedades = new();
        public Efeito efeitoInicial;
        public EfeitoHabeasCorpus efeitoHabeasCorpus;

        public Jogador(Personagem personagem)
        {
            saldo = 18;
            posicao = 0;
            this.personagem = personagem;
        }

        public Personagem GetPersonagem() => personagem;

        private async Task<int> JogarDado()
        {
            Random dado = new Random();
            int resultado = dado.Next(1, 6);
            await Tabuleiro.GetInstance().InterfaceUsuario.AnimarDado(resultado);
            return resultado;
        }

        private void GanharDinheiroPorVolta()
        {
            saldo += 2;
            Tabuleiro.GetInstance().InterfaceUsuario.AtualizarSaldo(personagem, saldo);
        }

        public void Receber(int dinheiro)
        {
            saldo += dinheiro;
            Tabuleiro.GetInstance().InterfaceUsuario.AtualizarSaldo(personagem, saldo);
        }

        public void Pagar(int dinheiro)
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            saldo -= dinheiro;
            tabuleiro.InterfaceUsuario.AtualizarSaldo(personagem, saldo);
            if (saldo < 0)
                tabuleiro.InterfaceUsuario.AcabarJogo();
        }

        public async Task IniciarRodada()
        {
            if (efeitoInicial != null)
            {
                await efeitoInicial.RealizarEfeito();
                efeitoInicial = null;
            }

            int passos = await JogarDado();
            await Mover(passos);
            Tabuleiro.GetInstance().ProximoJogador();
            // Resto da Rodada
            // Tabuleiro.GetInstance().ProximoJogador();
        }

        public async Task Mover(int passos)
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            List<Casa> casas = tabuleiro.casas;
            for (int passo = 0; passo < passos; passo++)
            {
                posicao++;
                if (posicao >= casas.Count)
                {
                    posicao = 0;

                    GanharDinheiroPorVolta();
                }
                await tabuleiro.InterfaceUsuario.MoverPersonagemUmPasso(personagem, posicao);
            }
            await casas[posicao].RealizarEfeitos();
        }

        public async Task Teleportar(int posicaoCasa)
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            List<Casa> casas = tabuleiro.casas;
            await tabuleiro.InterfaceUsuario.TeleportarPersonagem(personagem, posicaoCasa);
            await casas[posicaoCasa].RealizarEfeitos();
            if (posicaoCasa == 0)
            {
                GanharDinheiroPorVolta();
            }
        }
    }
}
