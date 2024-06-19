using System.Threading.Tasks;

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

        public string GetTexto() => texto;

        public async Task RealizarEfeito()
        {
            await efeito.RealizarEfeito();
        }
    }
}