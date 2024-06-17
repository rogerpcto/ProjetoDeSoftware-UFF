using System.Threading.Tasks;

namespace Game
{
    public interface InterfaceUsuario
    {
        void MudarVez(Personagem personagem, bool vez);
        void AtualizarSaldo(Personagem personagem, int saldo);
        void AdicionarPropriedade(Personagem personagem, Propriedade propriedade);
        void RemoverPropriedade(Personagem personagem, Propriedade propriedade);
        Task AnimarDado(int resultado);
        Task MoverPersonagemUmPasso(Personagem personagem, int posicaoFinal);
        void AcabarJogo();
    }
}
