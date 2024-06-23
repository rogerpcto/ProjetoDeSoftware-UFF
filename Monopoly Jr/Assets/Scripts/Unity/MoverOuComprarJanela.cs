using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class MoverOuComprarJanela : Janela
    {
        [SerializeField]
        private Button _buttonMover;
        [SerializeField]
        private Button _buttonComprar;

        public async Task Inicializar(TaskCompletionSource<bool> tcs)
        {
            gameObject.SetActive(true);
            _buttonMover.onClick.RemoveAllListeners();
            _buttonComprar.onClick.RemoveAllListeners();
            _buttonMover.interactable = false;
            _buttonComprar.interactable = false;

            _buttonMover.onClick.AddListener(async () =>
            {
                await FecharEDesativarBotoes();
                tcs.SetResult(true);
            });
            _buttonComprar.onClick.AddListener(async () =>
            {
                await FecharEDesativarBotoes();
                tcs.SetResult(false);
            });
            await Abrir().AsTask(this);

            if (ehBot)
            {
                await Esperar(0.75f).AsTask(this);
                System.Random random = new();
                int botao = random.Next(2);
                if (botao == 0)
                    _buttonMover.onClick.Invoke();
                else
                    _buttonComprar.onClick.Invoke();
            }
            else
            {
                _buttonMover.interactable = true;
                _buttonComprar.interactable = true;
            }
        }

        private async Task FecharEDesativarBotoes()
        {
            await Fechar().AsTask(this);
            _buttonMover.interactable = false;
            _buttonComprar.interactable = false;
        }
    }
}
