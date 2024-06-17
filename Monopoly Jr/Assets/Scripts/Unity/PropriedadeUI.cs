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
            ColorUtility.TryParseHtmlString(GerarHexCor(propriedade.Cor), out Color color);
            _image.color = color;
            Nome = propriedade.GetNome();
            _text.text = Nome;
        }

        private string GerarHexCor(Cor cor)
        {
            return cor switch
            {
                Cor.AMARELO => "#FFDC00",
                Cor.AZUL_CLARO => "#75C2FA",
                Cor.AZUL_ESCURO => "#0025FF",
                Cor.LARANJA => "#FF8100",
                Cor.MARROM => "#904C3A",
                Cor.VERDE => "#00FF27",
                Cor.VERMELHO => "#FF1E00",
                Cor.ROSA => "#FF4C87",
                _ => "#FFFFFF",
            };
        }
    }
}