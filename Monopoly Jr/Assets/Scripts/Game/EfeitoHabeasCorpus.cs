using System.Threading.Tasks;

namespace Game
{
    public class EfeitoHabeasCorpus : Efeito
    {
        public async Task RealizarEfeito()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            jogadorAtual.efeitoHabeasCorpus = this;
            await Task.CompletedTask;
        }

        public void SairDaPrisao()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            jogadorAtual.efeitoHabeasCorpus = null;
        }
    }
}