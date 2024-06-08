using System;

namespace Game
{
    public class Casa
    {
        private string nome;
        private int posicao;
        private Efeito efeito;

        public virtual void RealizarEfeitos()
        {
            throw new NotImplementedException();
        }
    }
}