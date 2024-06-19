namespace Game
{
    public class EfeitoHabeasCorpus : Efeito
    {
        public void RealizarEfeito()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            jogadorAtual.efeitoHabeasCorpus = this;
        }

        public void SairDaPrisao()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            jogadorAtual.efeitoHabeasCorpus = null;
        }
    }
}