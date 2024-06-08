using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        private void GanharDinheiroPorVolta()
        {
            throw new NotImplementedException();
        }

        public void Receber(int dinheiro)
        {
            throw new NotImplementedException();
        }

        public void Pagar(int dinheiro)
        {
            throw new NotImplementedException();
        }

        public void IniciarRodada()
        {
            throw new NotImplementedException();
        }

        public void Mover(int passos)
        {
            throw new NotImplementedException();
        }

        public void Teleportar(int posicaoCasa)
        {
            throw new NotImplementedException();
        }

    }
}