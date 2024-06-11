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

        public override void RealizarEfeitos()
        {
            throw new NotImplementedException();
        }

        //rever necessidade.
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
            }
        }
    }
}