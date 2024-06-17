using System;

namespace Game
{
    public class EfeitoVaParaPrisao : Efeito
    {
        private EfeitoTeleporte efeitoTeleporte;
        private EfeitoPrisao efeitoPrisao;

        public EfeitoVaParaPrisao(int posicaoPrisao)
        {
            efeitoTeleporte = new(posicaoPrisao);
            efeitoPrisao = new();
        }

        public void RealizarEfeito()
        {
            throw new NotImplementedException();
        }
    }
}