using System;
using System.Threading.Tasks;

namespace Game
{
    public class EfeitoTransacao : Efeito
    {
        private int transacao;

        public EfeitoTransacao(int transacao)
        {
            this.transacao = transacao;
        }

        public async Task RealizarEfeito()
        {
            AplicarTransacao(transacao);
        }

        private void AplicarTransacao(int valor)
        {
            Jogador jogadorAtual = Tabuleiro.GetInstance().JogadorAtual();
            if(valor < 0)
            {
                jogadorAtual.Pagar(-valor);
            }
            else
            {
                jogadorAtual.Receber(valor);
            }
        }

    }
}