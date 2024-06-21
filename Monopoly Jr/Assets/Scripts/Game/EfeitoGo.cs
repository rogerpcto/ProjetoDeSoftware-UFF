using System.Threading.Tasks;

namespace Game
{
    public class EfeitoGo : Efeito
    {
        private EfeitoTeleporte efeitoTeleporte;
        private EfeitoTransacao efeitoTransacao;

        public EfeitoGo(int posicao)
        {
            efeitoTeleporte = new EfeitoTeleporte(posicao);
            efeitoTransacao = new EfeitoTransacao(2);
        }

        public async Task RealizarEfeito()
        {
            await efeitoTeleporte.RealizarEfeito();
            await efeitoTransacao.RealizarEfeito();
        }
    }
}