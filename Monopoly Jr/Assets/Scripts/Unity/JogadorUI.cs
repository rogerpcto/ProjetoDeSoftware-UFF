using Game;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class JogadorUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _saldo;
        [SerializeField]
        private TextMeshProUGUI _player;
        [SerializeField]
        private Transform _gridPropriedades;
        [SerializeField]
        private PropriedadeUI _propriedadePrefab;
        [SerializeField]
        private Image _personagem;
        [SerializeField]
        private Sprite[] _personagens;
        [SerializeField]
        private Image _image;
        private List<PropriedadeUI> _propriedadesUI = new();
        
        private readonly Color[] _colors = new Color[5]
        {
            Color.gray,
            Color.red,
            Color.green,
            Color.yellow,
            Color.cyan
        };


        public void Inicializar(Jogador jogador)
        {
            _personagem.sprite = _personagens[(int)jogador.GetPersonagem()];
            if (jogador.EhBot())
                _player.text = $"CPU";
            else
                _player.text = $"P{jogador.GetNumeroPlayer()}";
            _player.color = _colors[jogador.GetNumeroPlayer()];
        }

        public void MudarVez(bool ativar)
        {
            _image.enabled = ativar;
        }

        public void AtualizarSaldo(int novoSaldo)
        {
            _saldo.text = $"Saldo $ {novoSaldo}";
        }

        public void AdicionaPropriedade(Propriedade propriedade)
        {
            PropriedadeUI propriedadeUI = Instantiate(_propriedadePrefab);
            propriedadeUI.Inicializar(propriedade);
            propriedadeUI.transform.SetParent(_gridPropriedades);
            _propriedadesUI.Add(propriedadeUI);
        }

        public void RemovePropriedade(Propriedade propriedade)
        {
            PropriedadeUI propriedadeUI = _propriedadesUI.Find(p => p.Nome == propriedade.GetNome());
            Destroy(propriedadeUI.gameObject);
        }

    }
}