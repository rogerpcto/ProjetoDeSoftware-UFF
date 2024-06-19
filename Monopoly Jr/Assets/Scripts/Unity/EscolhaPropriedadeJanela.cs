using Game;
using System.Linq;
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

        public async Task Inicializar(Cor cor1, Cor cor2, TaskCompletionSource<Propriedade> tcs)
        {
            gameObject.SetActive(true);

            var propriedades = Tabuleiro.GetInstance().casas.OfType<Propriedade>(); ;
            var propriedadesFiltradas = propriedades.Where(p => p.GetProprietario() != null && (p.Cor == cor1 || p.Cor == cor2));
            if (propriedadesFiltradas.Count() == 0)
            {
                propriedadesFiltradas = propriedades.Where(p => p.Cor == cor1 || p.Cor == cor2);
            }

            foreach (Propriedade propriedade in propriedadesFiltradas)
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
