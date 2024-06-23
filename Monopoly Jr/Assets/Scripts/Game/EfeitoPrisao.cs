using System.Threading.Tasks;

namespace Game
{
    public class EfeitoPrisao : Efeito
    {
        public async Task RealizarEfeito()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            if (!VerificarHabeasCorpus())
            {
                await tabuleiro.InterfaceUsuario.MostrarMensagem("Voc� pagou a fian�a de $ 1 para poder sair da pris�o.");
                CobrarMulta();
            }
            else
            {
                await tabuleiro.InterfaceUsuario.MostrarMensagem("Voc� utilizou sua carta para sair da pris�o de gra�a!");
                jogadorAtual.efeitoHabeasCorpus.SairDaPrisao();
            }
            await Task.CompletedTask;
        }

        private bool VerificarHabeasCorpus()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();

            if (jogadorAtual.efeitoHabeasCorpus != null)
            {
                return true;
            }
            return false;
        }

        private void CobrarMulta()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            jogadorAtual.Pagar(1);

        }
    }
}