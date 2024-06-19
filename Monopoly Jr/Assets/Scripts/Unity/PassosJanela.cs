using Game;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class PassosJanela : Janela
    {
        [SerializeField]
        private Button[] _buttons;

        public async Task Inicializar(TaskCompletionSource<EfeitoPassos> tcs)
        {
            gameObject.SetActive(true);
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].onClick.RemoveAllListeners();
                int passos = i + 1;
                _buttons[i].onClick.AddListener(async () =>
                {
                    EfeitoPassos efeito = new(passos);
                    await Fechar().AsTask(this);
                    tcs.SetResult(efeito);
                });
            }
            await Abrir().AsTask(this);
        }
    }
}
