using System.Threading.Tasks;

namespace Game
{
    public class EfeitoEscolherPassos : Efeito
    {
        public async Task RealizarEfeito()
        {
            Efeito passos = await EscolherPassos();
            await passos.RealizarEfeito();
        }

        private async Task<EfeitoPassos> EscolherPassos()
        {
            return await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPassos();
        }
    }
}