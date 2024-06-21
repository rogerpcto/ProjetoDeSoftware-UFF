using Game;
using System;
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
            _buttonMover.enabled = false;
            _buttonComprar.enabled = false;

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
            _buttonMover.enabled = true;
            _buttonComprar.enabled = true;
        }

        private async Task FecharEDesativarBotoes()
        {
            await Fechar().AsTask(this);
            _buttonMover.enabled = false;
            _buttonComprar.enabled = false;
        }
    }
}
