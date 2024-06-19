using System;

namespace Game
{
    public class Propriedade : Casa
    {
        private int preco;
        private int aluguel;
        private bool aluguelDobrado;
        private Jogador proprietario;

        public Cor Cor;

        public Propriedade(string nome, int posicao, int preco, int aluguel, Cor cor) : base(nome, posicao, null)
        {
            this.preco = preco;
            this.aluguel = aluguel;
            aluguelDobrado = false;
            proprietario = null;
            Cor = cor;
        }

        public override void RealizarEfeitos()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();

            if (proprietario == null)
            {
                tabuleiro.InterfaceUsuario.PerguntarComprarPropriedade(this,
                    () => Comprar(jogadorAtual),
                    () => tabuleiro.ProximoJogador());
            }
            else 
            {
                if (!ChecarProprietario(jogadorAtual))
                    CobrarAluguel();
               
                tabuleiro.ProximoJogador();
            }
        }

        public bool ChecarProprietario(Jogador jogador)
        {
            if (jogador == proprietario)
            {
                return true;
            }
            return false;
        }

        public void CobrarAluguel()
        {
            Jogador jogadorDaVez = Tabuleiro.GetInstance().JogadorAtual();
            int valorAPagar = aluguel;

            if (aluguelDobrado)
            {
                valorAPagar *= 2;
            }
            // jogador da Vez tem saldo suficiente? se não, passa todo o dinheiro dele pro proprietário e acaba o jogo
            proprietario.Receber(valorAPagar);
            jogadorDaVez.Pagar(valorAPagar);
        }

        public void Comprar(Jogador comprador)
        {
            if (proprietario == null)
            {
                comprador.Pagar(preco);
                comprador.propriedades.Add(this);
                proprietario = comprador;
                Tabuleiro.GetInstance().InterfaceUsuario.AdicionarPropriedade(comprador.GetPersonagem(), this);
            }
            Tabuleiro.GetInstance().ProximoJogador(); // Rever
        }

        public int GetPreco() => preco;
    }
}