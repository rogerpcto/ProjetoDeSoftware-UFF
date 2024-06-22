using Game;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class ComprarPropriedadeJanela : Janela
    {
        [SerializeField]
        private Button _buttonConfirm;
        [SerializeField]
        private Button _buttonCancel;
        [SerializeField]
        private PropriedadeJanela _propriedadeJanela;

        public async Task Inicializar(Propriedade propriedade, Action confirmar, Action cancelar, TaskCompletionSource<Task> tcs)
        {
            gameObject.SetActive(true);
            _buttonConfirm.onClick.RemoveAllListeners();
            _buttonCancel.onClick.RemoveAllListeners();
            _buttonConfirm.interactable = false;
            _buttonCancel.interactable = false;

            _propriedadeJanela.Inicializar(propriedade);

            _buttonConfirm.onClick.AddListener(async () =>
            {
                await FecharEDesativarBotoes();
                confirmar();
                tcs.SetResult(Task.CompletedTask);
            });
            _buttonCancel.onClick.AddListener(async () =>
            {
                await FecharEDesativarBotoes();
                cancelar();
                tcs.SetResult(Task.CompletedTask);
            });
            await Abrir().AsTask(this);

            if (ehBot)
            {
                await Task.Delay(750);
                System.Random random = new();
                int botao = random.Next(2);
                if (botao == 0)
                    _buttonConfirm.onClick.Invoke();
                else
                    _buttonCancel.onClick.Invoke();
            }
            else
            {
                _buttonConfirm.interactable = true;
                _buttonCancel.interactable = true;
            }
        }

        private async Task FecharEDesativarBotoes()
        {
            await Fechar().AsTask(this);
            _buttonConfirm.interactable = false;
            _buttonCancel.interactable = false;
        }
    }
}
