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

        public bool ChecarProprietario(Jogador jogador)
        {
            throw new NotImplementedException();
        }

        public int CobrarAluguel()
        {
            throw new NotImplementedException();
        }
        
        public int Comprar(Jogador comprador)
        {
            throw new NotImplementedException();
        }
    }
}