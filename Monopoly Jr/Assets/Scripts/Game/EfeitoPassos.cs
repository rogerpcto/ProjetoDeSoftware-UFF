using System;

namespace Game
{
    public class EfeitoPassos : Efeito
    {
        private int passos;

        public EfeitoPassos(int passos)
        {
            this.passos = passos;
        }

        public void RealizarEfeito()
        {
        }

        private void AndarJogador()
        {
            throw new NotImplementedException();
        }
    }
}