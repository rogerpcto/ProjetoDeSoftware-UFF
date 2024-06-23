using Game;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class CartaJanela : Janela
    {
        [SerializeField]
        private TextMeshProUGUI _texto;
        [SerializeField]
        private Button _buttonConfirm;

        public async Task Inicializar(Carta carta, TaskCompletionSource<Task> tcs)
        {
            _buttonConfirm.interactable = false;
            gameObject.SetActive(true);
            _buttonConfirm.onClick.RemoveAllListeners();

            _buttonConfirm.onClick.AddListener(async () =>
            {
                await Fechar().AsTask(this);
                _buttonConfirm.interactable = false;
                await carta.RealizarEfeito();
                tcs.SetResult(Task.CompletedTask);
            });
            _texto.text = "?";
            await Abrir().AsTask(this);
            await FadeTexto(1, 0).AsTask(this);
            _texto.text = carta.GetTexto();
            await FadeTexto(0, 1).AsTask(this);

            if (ehBot)
            {
                await Esperar(1.5f).AsTask(this);
                _buttonConfirm.onClick.Invoke();
            }
            else
                _buttonConfirm.interactable = true;
        }

        private IEnumerator FadeTexto(float alphaInicial, float alphaFinal)
        {
            _texto.alpha = alphaInicial;

            float duration = 1f;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                _texto.alpha = Mathf.Lerp(alphaInicial, alphaFinal, normalizedTime);
                yield return null;
            }
        }
    }
}
