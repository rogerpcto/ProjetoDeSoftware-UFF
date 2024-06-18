using Game;
using System;
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
        private List<JogadorUI> _jogadoresUI;
        [SerializeField]
        private Dado dado;
        [SerializeField]
        private PropriedadeJanela propriedadeJanela;

        public void MudarVez(Personagem personagem, bool vez)
        {
            _jogadoresUI[(int)personagem].MudarVez(vez);
        }
        
        public void AtualizarSaldo(Personagem personagem, int saldo)
        {
            _jogadoresUI[(int)personagem].AtualizarSaldo(saldo);
        }
        
        public void AdicionarPropriedade(Personagem personagem, Propriedade propriedade)
        {
            _jogadoresUI[(int)personagem].AdicionaPropriedade(propriedade);
        }
        
        public void RemoverPropriedade(Personagem personagem, Propriedade propriedade)
        {
            _jogadoresUI[(int)personagem].RemovePropriedade(propriedade);
        }
        
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

            float duration = .75f;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                personagemAtual.position = Vector3.Lerp(posInicial, posFinal, normalizedTime);
                yield return null;
            }

            personagemAtual.position = posFinal;
            personagemAtual.SetParent(_casas[posicaoFinal].transform);
        }

        public void AcabarJogo()
        {
            throw new NotImplementedException();
        }

        public async Task PerguntarComprarPropriedade(Propriedade propriedade, Action opcao1, Action opcao2)
        {
            propriedadeJanela.Inicializar(propriedade, opcao1, opcao2);
        }
    }
}
