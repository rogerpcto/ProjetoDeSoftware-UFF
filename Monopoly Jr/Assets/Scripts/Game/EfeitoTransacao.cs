using System;

namespace Game
{
    public class EfeitoTransacao : Efeito
    {
        private int transacao;

        public EfeitoTransacao(int transacao)
        {
            this.transacao = transacao;
        }

        public void RealizarEfeito()
        {
            throw new NotImplementedException();
        }

        private void AplicarTransacao()
        {
            throw new NotImplementedException();
        }

    }
}