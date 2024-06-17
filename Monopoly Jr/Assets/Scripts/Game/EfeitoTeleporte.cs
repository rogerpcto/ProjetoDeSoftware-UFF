using System;

namespace Game
{
    public class EfeitoTeleporte : Efeito
    {
        private int destino;
        
        public EfeitoTeleporte(int destino)
        {
            this.destino = destino;
        }

        public void RealizarEfeito()
        {
            throw new NotImplementedException();
        }
        private void TeleportarJogador()
        {
            throw new NotImplementedException();
        }
    }
}