using System;
using System.Threading.Tasks;

namespace Game
{
    public class EfeitoMoverOuComprar : Efeito
    {
        private EfeitoPassos efeitoPassos;
        private EfeitoComprarCarta efeitoComprarCarta;

        public EfeitoMoverOuComprar()
        {
            efeitoPassos = new(1);
            efeitoComprarCarta = new();
        }

        public async Task RealizarEfeito()
        {
        }

        public Efeito EscolherMoverOuComprar()
        {
            throw new NotImplementedException();
        }
    }
}