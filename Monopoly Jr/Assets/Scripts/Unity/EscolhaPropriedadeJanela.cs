using Game;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class EscolhaPropriedadeJanela : Janela
    {
        [SerializeField]
        private PropriedadeJanela _prefabPropriedade;
        [SerializeField]
        private Transform _grid;

        public async Task Inicializar(List<Propriedade> propriedades, TaskCompletionSource<Propriedade> tcs)
        {
            gameObject.SetActive(true);

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
            }

            await Abrir().AsTask(this);
        }
    }
}
