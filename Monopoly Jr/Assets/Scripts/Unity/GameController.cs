using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private UIController _UIController;
        private Tabuleiro _tabuleiro;

        public void IniciarJogo()
        {
            _tabuleiro = Tabuleiro.GetInstance();
            _tabuleiro.InterfaceUsuario = _UIController;
            _UIController.InicializarUI(_tabuleiro.jogadores);
            _tabuleiro.InterfaceUsuario.MudarVez(_tabuleiro.JogadorAtual().GetPersonagem(), true);
            foreach (Jogador jogador in _tabuleiro.jogadores)
            {
                jogador.Receber(0);
            }
            _tabuleiro.JogadorAtual().IniciarRodada();
        }

        public void ReiniciarJogo()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
