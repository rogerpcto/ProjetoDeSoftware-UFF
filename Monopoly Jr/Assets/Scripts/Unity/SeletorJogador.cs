using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class SeletorJogador : MonoBehaviour
    {
        [SerializeField]
        private Personagem _personagem;
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private Button _previous;
        [SerializeField]
        private Button _next;

        private int _indice;
        private static int indiceGeral = 1;
        private readonly Color[] _colors = new Color[5]
        {
            Color.gray,
            Color.red,
            Color.green,
            Color.yellow,
            Color.cyan
        };

        private void Start()
        {
            indiceGeral = 1;
            if (_personagem == Personagem.BARCO)
                _indice = 1;
        }

        public void TrocarParaJogador()
        {
            _next.gameObject.SetActive(false);
            _previous.gameObject.SetActive(true);
            indiceGeral++;
            _indice = indiceGeral;
            _text.text = $"P{_indice}";
            _text.color = _colors[_indice];
        }
        public void TrocarParaCPU()
        {
            _next.gameObject.SetActive(true);
            _previous.gameObject.SetActive(false);
            _indice = 0;
            indiceGeral--;
            _text.text = "CPU";
            _text.color = _colors[_indice];
        }

        public int GetNumeroPlayer() => _indice;
    }
}