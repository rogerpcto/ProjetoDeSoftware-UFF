using Game;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity
{
    public class UIController : MonoBehaviour, InterfaceUsuario
    {
        [SerializeField]
        private List<GameObject> _casas;
        [SerializeField]
        private List<GameObject> _personagens;
        [SerializeField]
        private Dado dado;

        public async Task AnimarDado(int resultado)
        {
            await dado.RolarDado(resultado).AsTask(this);
        }
        

        public async Task MoverPersonagemUmPasso(Personagem personagem, int posicaoFinal)
        {
            await MoverPersonagem(personagem, posicaoFinal).AsTask(this);
        }

        private IEnumerator MoverPersonagem(Personagem personagem, int posicaoFinal)
        {
            Transform personagemAtual = _personagens[(int)personagem].transform;

            personagemAtual.SetParent(transform);
            personagemAtual.SetAsLastSibling();
            Vector3 posInicial = personagemAtual.position;
            Vector3 posFinal = _casas[posicaoFinal].transform.position;

            float duration = 1;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                personagemAtual.position = Vector3.Lerp(posInicial, posFinal, normalizedTime);
                yield return null;
            }

            personagemAtual.position = posFinal;
            personagemAtual.SetParent(_casas[posicaoFinal].transform);
        }

    }
}
