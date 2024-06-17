using System.Threading.Tasks;

namespace Game
{
    public interface InterfaceUsuario
    {
        Task MoverPersonagemUmPasso(Personagem personagem, int posicaoFinal);
        Task AnimarDado(int resultado);
    }
}
