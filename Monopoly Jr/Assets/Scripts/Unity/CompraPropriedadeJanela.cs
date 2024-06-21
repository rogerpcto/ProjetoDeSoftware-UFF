using Game;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class CompraPropriedadeJanela : Janela
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
            _buttonConfirm.enabled = false;
            _buttonCancel.enabled = false;

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
            _buttonConfirm.enabled = true;
            _buttonCancel.enabled = true;
        }

        private async Task FecharEDesativarBotoes()
        {
            await Fechar().AsTask(this);
            _buttonConfirm.enabled = false;
            _buttonCancel.enabled = false;
        }
    }
}
