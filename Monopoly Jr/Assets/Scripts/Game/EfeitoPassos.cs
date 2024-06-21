using System.Threading.Tasks;

namespace Game
{
    public class EfeitoPassos : Efeito
    {
        private int passos;

        public EfeitoPassos(int passos)
        {
            this.passos = passos;
        }

        public async Task RealizarEfeito()
        {
            await AndarJogador();
        }

        private async Task AndarJogador()
        {
            await Tabuleiro.GetInstance().JogadorAtual().Mover(passos);
        }
    }
}