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
            gameObject.SetActive(true);
            _buttonConfirm.onClick.RemoveAllListeners();

            _buttonConfirm.onClick.AddListener(async () =>
            {
                await Fechar().AsTask(this);
                await carta.RealizarEfeito();
                tcs.SetResult(Task.CompletedTask);
            });
            await Abrir().AsTask(this);
            _texto.text = "?";
            await FadeTexto(1, 0).AsTask(this);
            _texto.text = carta.GetTexto();
            await FadeTexto(0, 1).AsTask(this);
        }

        private IEnumerator FadeTexto(float alphaInicial, float alphaFinal)
        {
            _texto.alpha = alphaInicial;

            float duration = .50f;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                _texto.alpha = Mathf.Lerp(alphaInicial, alphaFinal, normalizedTime);
                yield return null;
            }
        }
    }
}
