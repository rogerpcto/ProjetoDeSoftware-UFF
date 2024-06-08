using System;
using System.Collections.Generic;

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

        public void ProximoJogador()
        {
            throw new NotImplementedException();
        }

        public Jogador JogadorAtual()
        {
            throw new NotImplementedException();
        }
    }
}