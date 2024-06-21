using System;
using System.Linq;
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
            Jogador jogador = Tabuleiro.GetInstance().JogadorAtual();
            if (jogador.GetPersonagem() == personagem)
            {
                var propriedades = Tabuleiro.GetInstance().casas.OfType<Propriedade>(); ;
                var propriedadesSemProprietario = propriedades.Where(p => p.GetProprietario() == null);
                if (propriedadesSemProprietario.Count() > 0)
                {
                await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(propriedadesSemProprietario.ToList());
                }
                else
                {

                }
            }
            else
            {

            }
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