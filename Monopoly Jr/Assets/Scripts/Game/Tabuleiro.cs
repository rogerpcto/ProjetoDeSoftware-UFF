namespace Game
{
    public class Tabuleiro
    {
        #region Singleton
        private static Tabuleiro instance;

        private Tabuleiro() { }

        public static Tabuleiro GetInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }
        #endregion

        public List<Jogador> jogadores = new();
        public List<Casa> casas = new();
        public List<Carta> cartas = new();
        public InterfaceUsuario InterfaceUsuario;
        public int jogadorDaVez = 0;
        public void ProximoJogador()
        {

            if (jogadorDaVez > jogadores.Count())
            {
                jogadorDaVez = 0;
            }
            jogadorDaVez++;
        }

        public Jogador JogadorAtual()
        {
            return jogadores[jogadorDaVez];
        }
    }
}