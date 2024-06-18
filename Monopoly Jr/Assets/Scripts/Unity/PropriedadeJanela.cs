using Game;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity
{
    public class PropriedadeJanela : MonoBehaviour
    {
        [SerializeField]
        private Image _cor;
        [SerializeField]
        private TextMeshProUGUI _nome;
        [SerializeField]
        private TextMeshProUGUI _valor;
        [SerializeField]
        private Button _buttonConfirm;
        [SerializeField]
        private Button _buttonCancel;

        public async Task Inicializar(Propriedade propriedade, Action confirmar, Action cancelar)
        {
            gameObject.SetActive(true);
            _buttonConfirm.onClick.RemoveAllListeners();
            _buttonCancel.onClick.RemoveAllListeners();

            ColorUtility.TryParseHtmlString(GerarHexCor(propriedade.Cor), out Color color);
            _cor.color = color;
            _nome.text = propriedade.GetNome();
            _valor.text = $"$ {propriedade.GetPreco()}";
            _buttonConfirm.onClick.AddListener(() =>
            {
                confirmar();
                gameObject.SetActive(false);
            });
            _buttonCancel.onClick.AddListener(() =>
            {
                cancelar();
                gameObject.SetActive(false);
            });
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
