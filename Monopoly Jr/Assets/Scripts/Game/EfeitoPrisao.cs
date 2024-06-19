namespace Game
{
    public class EfeitoPrisao : Efeito
    {
        public void RealizarEfeito()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();
            if (!VerificarHabeasCorpus())
            {
                CobrarMulta();
            }
            else
            {
                jogadorAtual.efeitoHabeasCorpus.SairDaPrisao();
            }
            tabuleiro.ProximoJogador();
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