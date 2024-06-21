using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game
{
    public interface InterfaceUsuario
    {
        void MudarVez(Personagem personagem, bool vez);
        void AtualizarSaldo(Personagem personagem, int saldo);
        Task PerguntarComprarPropriedade(Propriedade propriedade, Action opcao1, Action opcao2);
        void AdicionarPropriedade(Personagem personagem, Propriedade propriedade);
        void RemoverPropriedade(Personagem personagem, Propriedade propriedade);
        Task AnimarDado(int resultado);
        Task MoverPersonagemUmPasso(Personagem personagem, int posicaoFinal);
        Task TeleportarPersonagem(Personagem personagem, int posicaoFinal);
        Task MostrarCarta(Carta carta);
        Task<EfeitoPassos> EscolherPassos();
        Task<Propriedade> EscolherPropriedade(List<Propriedade> propriedades);
        /// <summary>
        /// Retorna true se for Mover e false se for Comprar
        /// </summary>
        Task<bool> EscolheMoverOuComprar();
        void AcabarJogo();
    }
}
