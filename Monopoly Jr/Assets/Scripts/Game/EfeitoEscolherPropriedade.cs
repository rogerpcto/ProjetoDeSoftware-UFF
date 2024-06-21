using System.Linq;
using System.Threading.Tasks;

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
            this.cor2 = cor1;
        }

        public async Task RealizarEfeito()
        {
            Propriedade propriedade = await EscolherPropriedadeCor();
            Jogador jogadorAtual = Tabuleiro.GetInstance().JogadorAtual();

            if (propriedade.GetProprietario() == null)
            {
                jogadorAtual.propriedades.Add(propriedade);
                propriedade.SetProprietario(jogadorAtual);
            }
            await jogadorAtual.Teleportar(propriedade.GetPosicao());
        }

        private async Task<Propriedade> EscolherPropriedadeCor()
        {
            var propriedades = Tabuleiro.GetInstance().casas.OfType<Propriedade>(); ;
            var propriedadesFiltradas = propriedades.Where(p => p.GetProprietario() == null && (p.Cor == cor1 || p.Cor == cor2));
            if (propriedadesFiltradas.Count() == 0)
            {
                propriedadesFiltradas = propriedades.Where(p => p.Cor == cor1 || p.Cor == cor2);
            }
            return await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(propriedadesFiltradas.ToList());
        }
    }
}