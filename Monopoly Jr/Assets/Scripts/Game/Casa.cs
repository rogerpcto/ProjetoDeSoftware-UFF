using System;

namespace Game
{
    public class Casa
    {
        private string nome;
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
            throw new NotImplementedException();
        }
    }
}