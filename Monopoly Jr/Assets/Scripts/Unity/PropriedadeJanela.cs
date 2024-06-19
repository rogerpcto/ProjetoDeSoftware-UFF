using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class PropriedadeJanela : MonoBehaviour
    {
        [SerializeField]
        private Image _cor;
        [SerializeField]
        private Image _proprietario;
        [SerializeField]
        private Sprite[] _personagens;
        [SerializeField]
        private TextMeshProUGUI _nome;
        [SerializeField]
        private TextMeshProUGUI _valor;

        public void Inicializar(Propriedade propriedade)
        {
            ColorUtility.TryParseHtmlString(propriedade.Cor.GerarHex(), out Color color);
            _cor.color = color;

            var proprietario = propriedade.GetProprietario();
            if (proprietario != null)
            {
                _proprietario.sprite = _personagens[(int)proprietario.GetPersonagem()];
            }
            _proprietario.enabled = proprietario != null;
            _nome.text = propriedade.GetNome();
            _valor.text = $"$ {propriedade.GetPreco()}";
        }
    }
}