using System;

namespace Game
{
    public class EfeitoEscolherPropriedade : Efeito
    {
        private Cor cor1, cor2;

        public EfeitoEscolherPropriedade(Cor cor1, Cor cor2)
        {
            this.cor1 = cor1;
            this.cor2 = cor2;
        }

        public EfeitoEscolherPropriedade(Cor cor1)
        {
            this.cor1 = cor1;
        }

        public void RealizarEfeito()
        {
        }

        private Propriedade EscolherPropriedadeCor()
        {
            throw new NotImplementedException();
        }
    }
}