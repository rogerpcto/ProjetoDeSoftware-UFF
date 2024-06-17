using Game;
using System;
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
            _tabuleiro.InterfaceUsuario.MudarVez(_tabuleiro.JogadorAtual().GetPersonagem(), true);
            foreach(Jogador jogador in _tabuleiro.jogadores)
            {
                jogador.Receber(0);
            }
            _tabuleiro.JogadorAtual().IniciarRodada();
        }
    }
}
