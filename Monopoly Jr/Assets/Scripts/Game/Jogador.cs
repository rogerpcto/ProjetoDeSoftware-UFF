namespace Game
{
    public class Jogador
    {
        private int saldo;
        private int posicao;
        private Personagem personagem;

        public List<Propriedade> propriedades = new();
        public Efeito efeitoInicial;
        public EfeitoHabeasCorpus efeitoHabeasCorpus;


        private int JogarDado()
        {
            Random dado = new Random();
            int resultado = dado.Next(1, 6);
            return resultado;
        }

        private void GanharDinheiroPorVolta()
        {
            saldo += 10;
        }

        public void Receber(int dinheiro)
        {
            saldo += dinheiro;
        }

        public void Pagar(int dinheiro)
        {
            saldo -= dinheiro;

        }

        public void IniciarRodada()
        {
            Jogador jogador = Tabuleiro.GetInstance().JogadorAtual();
            int passos = jogador.JogarDado();
            jogador.Mover(passos);
        }

        public void Mover(int passos)
        {
            List<Casa> casas = Tabuleiro.GetInstance().casas;
            for (int passo = 1; passo <= passos; passo++)
            {
                if (posicao > casas.Count())
                {
                    posicao = 0;

                    GanharDinheiroPorVolta();
                }
                else
                {
                    posicao += 1;
                }
            }
        }

        public void Teleportar(int posicaoCasa)
        {
            posicao = posicaoCasa;
        }
    }

}
