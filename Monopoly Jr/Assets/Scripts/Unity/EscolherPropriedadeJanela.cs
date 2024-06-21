using Game;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class EscolherPropriedadeJanela : Janela
    {
        [SerializeField]
        private PropriedadeJanela _prefabPropriedade;
        [SerializeField]
        private Transform _grid;
        [SerializeField]
        private Scrollbar _scrollbar;

        public async Task Inicializar(List<Propriedade> propriedades, TaskCompletionSource<Propriedade> tcs)
        {
            gameObject.SetActive(true);

            List<Button> buttons = new List<Button>();

            foreach (Propriedade propriedade in propriedades)
            {
                PropriedadeJanela propriedadeJanela = Instantiate(_prefabPropriedade, _grid);
                propriedadeJanela.Inicializar(propriedade);
                Button button = propriedadeJanela.gameObject.AddComponent<Button>();
                button.onClick.AddListener(async () =>
                {
                    await Fechar().AsTask(this);
                    for (int i = 0; i < _grid.childCount; i++)
                    {
                        Destroy(_grid.GetChild(i).gameObject);
                    }
                    tcs.SetResult(propriedade);
                });
                button.enabled = false;
                buttons.Add(button);
            }

            await Abrir().AsTask(this);
            _scrollbar.value = 1;
            foreach (Button button in buttons)
            {
                button.enabled = true;
            }
        }
    }
}
