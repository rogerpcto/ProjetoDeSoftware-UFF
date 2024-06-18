using System;

namespace Game
{
    public class EfeitoPropriedadeGratis : Efeito
    {
        private int indicePropriedade;

        public EfeitoPropriedadeGratis(int indicePropriedade)
        {
            this.indicePropriedade = indicePropriedade;
        }

        public void RealizarEfeito()
        {
        }

        private Propriedade PegarOuPagar()
        {
            throw new NotImplementedException();
        }
    }
}