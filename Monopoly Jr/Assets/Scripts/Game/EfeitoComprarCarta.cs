using System.Threading.Tasks;

namespace Game
{
    public class EfeitoComprarCarta : Efeito
    {
        public async Task RealizarEfeito()
        {
            Carta carta = ComprarCarta();
            await Tabuleiro.GetInstance().InterfaceUsuario.MostrarCarta(carta);
        }

        private Carta ComprarCarta()
        {
            return Tabuleiro.GetInstance().PegarCarta();
        }
    }
}