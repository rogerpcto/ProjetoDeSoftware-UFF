using System.Collections.Generic;

namespace Game
{
    public class Carta
    {
        private string texto;
        private Efeito efeito;
        
        public Carta(string texto, Efeito efeito)
        {
            this.texto = texto;
            this.efeito = efeito;
        }

        public void RealizarEfeitos()
        {
            throw new System.NotImplementedException();
        }
    }
}