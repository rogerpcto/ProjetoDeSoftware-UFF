using System.Threading.Tasks;

namespace Game
{
    public class EfeitoPropriedadeGratis : Efeito
    {
        private int indicePropriedade;

        public EfeitoPropriedadeGratis(int indicePropriedade)
        {
            this.indicePropriedade = indicePropriedade;
        }

        public async Task RealizarEfeito()
        {
            await PegarOuPagar();
        }

        private async Task PegarOuPagar()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            Propriedade propriedade = (Propriedade)tabuleiro.casas[indicePropriedade];

            await jogadorAtual.Teleportar(indicePropriedade);

            if (propriedade.GetProprietario() != null)
            {
                if (!propriedade.ChecarProprietario(jogadorAtual))
                {
                    Jogador dono = propriedade.GetProprietario();
                    jogadorAtual.Pagar(propriedade.GetPreco());
                    dono.Receber(propriedade.GetPreco());
                }
            }
            else
            {
                propriedade.SetProprietario(jogadorAtual);
            }
        }
    }
}