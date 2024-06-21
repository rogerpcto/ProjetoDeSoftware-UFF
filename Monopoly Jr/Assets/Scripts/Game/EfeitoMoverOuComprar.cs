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
            Efeito efeito = await EscolherMoverOuComprar();
            await efeito.RealizarEfeito();
        }

        public async Task<Efeito> EscolherMoverOuComprar()
        {
            bool mover = await Tabuleiro.GetInstance().InterfaceUsuario.EscolheMoverOuComprar();
            return mover ? efeitoPassos : efeitoComprarCarta;  
        }
    }
}