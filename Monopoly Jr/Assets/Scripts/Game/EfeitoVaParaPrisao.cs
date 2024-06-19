using System.Threading.Tasks;

namespace Game
{
    public class EfeitoVaParaPrisao : Efeito
    {
        private EfeitoTeleporte efeitoTeleporte;
        private EfeitoPrisao efeitoPrisao;

        public EfeitoVaParaPrisao(int posicaoPrisao)
        {
            efeitoTeleporte = new(posicaoPrisao);
            efeitoPrisao = new();
        }
        public async Task RealizarEfeito()
        {
            await efeitoTeleporte.RealizarEfeito();
            Tabuleiro.GetInstance().JogadorAtual().efeitoInicial = efeitoPrisao;
        }
    }
}