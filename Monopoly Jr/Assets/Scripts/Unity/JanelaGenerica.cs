using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class JanelaGenerica : Janela
    {
        [SerializeField]
        private TextMeshProUGUI _texto;
        [SerializeField]
        private Button _buttonOk;

        public async Task Inicializar(string message, TaskCompletionSource<Task> tcs)
        {
            _buttonOk.interactable = false;
            gameObject.SetActive(true);
            _buttonOk.onClick.RemoveAllListeners();

            _buttonOk.onClick.AddListener(async () =>
            {
                await Fechar().AsTask(this);
                _buttonOk.interactable = false;
                tcs.SetResult(Task.CompletedTask);
            });
            _texto.text = "?";
            await Abrir().AsTask(this);
            _texto.text = message;

            if (ehBot)
            {
                await Esperar(1.5f).AsTask(this);
                _buttonOk.onClick.Invoke();
            }
            else
            {
                _buttonOk.interactable = true;
            }
        }
    }
}
