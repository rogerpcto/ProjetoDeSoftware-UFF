using System;

namespace Game
{
    public class Casa
    {
        protected string nome;
        private int posicao;
        private Efeito efeito;

        public Casa(string nome, int posicao, Efeito efeito)
        {
            this.nome = nome;
            this.posicao = posicao;
            this.efeito = efeito;
        }

        public string GetNome() => nome;

        public virtual void RealizarEfeitos()
        {
            //if (efeito != null)
            //    efeito.RealizarEfeito();
            Tabuleiro.GetInstance().ProximoJogador();
            throw new NotImplementedException();
        }
    }
}