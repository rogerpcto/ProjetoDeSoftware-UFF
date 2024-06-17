using Game;
using UnityEngine;

namespace Unity
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private UIController _UIController;
        private Tabuleiro _tabuleiro;

        private void Start()
        {
            _tabuleiro = Tabuleiro.GetInstance();
            _tabuleiro.InterfaceUsuario = _UIController;
            _tabuleiro.JogadorAtual().IniciarRodada();
        }

        private void Update()
        {

        }
    }
}
