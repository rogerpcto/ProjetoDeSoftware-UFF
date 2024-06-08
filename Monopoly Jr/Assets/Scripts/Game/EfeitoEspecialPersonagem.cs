using System;

namespace Game
{
    public class EfeitoEspecialPersonagem : Efeito
    {
        private Personagem personagem;
        private EfeitoComprarCarta comprarCarta;

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