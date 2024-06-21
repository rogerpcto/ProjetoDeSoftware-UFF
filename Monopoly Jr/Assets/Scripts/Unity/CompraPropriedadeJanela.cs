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

            _propriedadeJanela.Inicializar(propriedade);

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
