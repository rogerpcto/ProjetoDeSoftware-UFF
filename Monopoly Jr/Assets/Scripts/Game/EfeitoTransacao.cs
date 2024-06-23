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
            AplicarTransacao();
        }

        private void AplicarTransacao()
        {
            Jogador jogadorAtual = Tabuleiro.GetInstance().JogadorAtual();
            if (transacao < 0)
            {
                jogadorAtual.Pagar(-transacao);
            }
            else
            {
                jogadorAtual.Receber(transacao);
            }
        }

    }
}