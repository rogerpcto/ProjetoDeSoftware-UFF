using System;

namespace Game
{
    public class EfeitoVaParaPrisao : Efeito
    {
        private EfeitoTeleporte efeitoTeleporte;
        private EfeitoPrisao efeitoPrisao;

        public EfeitoVaParaPrisao()
        {
            efeitoTeleporte = new();
            efeitoPrisao = new();
        }

        public void RealizarEfeito()
        {
            throw new NotImplementedException();
        }
    }
}