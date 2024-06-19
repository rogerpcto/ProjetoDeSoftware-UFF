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
        }

        private void AplicarTransacao()
        {
            throw new NotImplementedException();
        }

    }
}