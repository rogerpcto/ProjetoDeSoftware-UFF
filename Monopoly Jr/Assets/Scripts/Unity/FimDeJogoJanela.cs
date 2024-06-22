using Game;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class FimDeJogoJanela : Janela
    {
        [SerializeField]
        private Image _vencedor;
        [SerializeField]
        private Sprite[] _personagens;

        public async Task Inicializar(Personagem personagem)
        {
            gameObject.SetActive(true);
            _vencedor.sprite = _personagens[(int)personagem];
            await Abrir().AsTask(this);
        }
    }
}
