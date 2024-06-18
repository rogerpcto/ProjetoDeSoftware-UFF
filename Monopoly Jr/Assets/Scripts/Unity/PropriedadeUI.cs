using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class PropriedadeUI : MonoBehaviour
    {
        [HideInInspector]
        public string Nome;

        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private Image _image;

        public void Inicializar(Propriedade propriedade)
        {
            ColorUtility.TryParseHtmlString(propriedade.Cor.GerarHex(), out Color color);
            _image.color = color;
            Nome = propriedade.GetNome();
            _text.text = Nome;
        }
    }
}