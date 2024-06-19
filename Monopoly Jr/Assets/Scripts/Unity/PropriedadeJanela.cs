using Game;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class PropriedadeJanela : Janela
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

        public async Task Inicializar(Propriedade propriedade, Action confirmar, Action cancelar, TaskCompletionSource<Task> tcs)
        {
            gameObject.SetActive(true);
            _buttonConfirm.onClick.RemoveAllListeners();
            _buttonCancel.onClick.RemoveAllListeners();

            ColorUtility.TryParseHtmlString(propriedade.Cor.GerarHex(), out Color color);
            _cor.color = color;
            _nome.text = propriedade.GetNome();
            _valor.text = $"$ {propriedade.GetPreco()}";
            _buttonConfirm.onClick.AddListener(async () =>
            {
                await Fechar().AsTask(this);
                confirmar();
                tcs.SetResult(Task.CompletedTask);
            });
            _buttonCancel.onClick.AddListener(async () =>
            {
                await Fechar().AsTask(this);
                cancelar();
                tcs.SetResult(Task.CompletedTask);
            });
            await Abrir().AsTask(this);
        }
    }
} 
