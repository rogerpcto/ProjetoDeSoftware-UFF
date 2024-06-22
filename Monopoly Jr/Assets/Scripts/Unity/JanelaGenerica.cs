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
            _buttonOk.enabled = false;
            gameObject.SetActive(true);
            _buttonOk.onClick.RemoveAllListeners();

            _buttonOk.onClick.AddListener(async () =>
            {
                await Fechar().AsTask(this);
                _buttonOk.enabled = false;
                tcs.SetResult(Task.CompletedTask);
            });
            _texto.text = "?";
            await Abrir().AsTask(this);
            _texto.text = message;
            _buttonOk.enabled = true;
        }
    }
}
