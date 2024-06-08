using System;

namespace Game
{
    public class EfeitoMoverOuComprar : Efeito
    {
        private EfeitoPassos efeitoPassos;
        private EfeitoComprarCarta efeitoComprar;

        public EfeitoMoverOuComprar()
        {
            efeitoPassos = new(1);
            efeitoComprar = new();
        }

        public void RealizarEfeito()
        {
            throw new NotImplementedException();
        }

        public Efeito EscolherMoverOuComprar()
        {
            throw new NotImplementedException();
        }
    }
}