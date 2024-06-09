using System;

namespace Game
{
    public class EfeitoEspecialPersonagem : Efeito
    {
        private EfeitoComprarCarta comprarCarta;
        private Personagem personagem;

        public EfeitoEspecialPersonagem(Personagem personagem)
        {
            this.personagem = personagem;
            comprarCarta = new();
        }

        public void RealizarEfeito()
        {
            throw new NotImplementedException();
        }
        
        private Propriedade EscolherPropriedade()
        {
            throw new NotImplementedException();
        }

        private void EntregarCartaAoPersonagem()
        {
            throw new NotImplementedException();
        }
    }
}