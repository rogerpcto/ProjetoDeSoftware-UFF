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
                await tabuleiro.InterfaceUsuario.MostrarMensagem("Você pagou a fiança de $ 1 para poder sair da prisão.");
                CobrarMulta();
            }
            else
            {
                await tabuleiro.InterfaceUsuario.MostrarMensagem("Você utilizou sua carta para sair da prisão de graça!");
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