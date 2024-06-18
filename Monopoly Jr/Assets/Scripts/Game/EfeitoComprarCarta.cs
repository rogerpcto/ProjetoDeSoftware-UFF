using System;

namespace Game
{
    public class EfeitoComprarCarta : Efeito
    {
        public void RealizarEfeito()
        {
            Carta carta = ComprarCarta();
            Tabuleiro.GetInstance().InterfaceUsuario.MostrarCarta(carta);
        }

        private Carta ComprarCarta()
        {
            return Tabuleiro.GetInstance().PegarCarta();
        }
    }
}