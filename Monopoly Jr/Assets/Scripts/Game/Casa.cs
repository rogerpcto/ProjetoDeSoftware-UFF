using System;
using System.Threading.Tasks;

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
        public int GetPosicao() => posicao;

        public virtual async Task RealizarEfeitos()
        {
            if (efeito != null)
                await efeito.RealizarEfeito();
        }
    }
}