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
            throw new NotImplementedException();
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
        }
    }
}