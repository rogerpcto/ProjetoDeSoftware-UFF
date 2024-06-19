using System;
using System.Threading.Tasks;

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

        public async Task RealizarEfeito()
        {
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