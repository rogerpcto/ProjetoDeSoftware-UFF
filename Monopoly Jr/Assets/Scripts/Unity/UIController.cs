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
        private Dado _dado;
        [SerializeField]
        private ComprarPropriedadeJanela _comprarPropriedadeJanela;
        [SerializeField]
        private CartaJanela _cartaJanela;
        [SerializeField]
        private PassosJanela _passosJanela;
        [SerializeField]
        private EscolherPropriedadeJanela _escolherPropriedadeJanela;
        [SerializeField]
        private MoverOuComprarJanela _moverOuComprarJanela;
        [SerializeField]
        private JanelaGenerica _janelaGenerica;
        [SerializeField]
        private FimDeJogoJanela _fimDeJogojanela;

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
            await _dado.RolarDado(resultado).AsTask(this);
        }

        public async Task MoverPersonagemUmPasso(Personagem personagem, int posicaoFinal)
        {
            await MoverPersonagem(personagem, posicaoFinal).AsTask(this);
        }

        public async Task TeleportarPersonagem(Personagem personagem, int posicaoFinal)
        {
            await MoverPersonagem(personagem, posicaoFinal).AsTask(this);
        }

        public IEnumerator MoverPersonagem(Personagem personagem, int posicaoFinal)
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

        public async Task PerguntarComprarPropriedade(Propriedade propriedade, Action opcao1, Action opcao2)
        {
            var tcs = new TaskCompletionSource<Task>();
            await _comprarPropriedadeJanela.Inicializar(propriedade, opcao1, opcao2, tcs);
            await tcs.Task;
        }

        public async Task MostrarCarta(Carta carta)
        {
            var tcs = new TaskCompletionSource<Task>();
            await _cartaJanela.Inicializar(carta, tcs);
            await tcs.Task;
        }

        public async Task<EfeitoPassos> EscolherPassos()
        {
            var tcs = new TaskCompletionSource<EfeitoPassos>();
            await _passosJanela.Inicializar(tcs);
            EfeitoPassos resultado = await tcs.Task;

            return resultado;
        }
        public async Task<Propriedade> EscolherPropriedade(List<Propriedade> propriedades)
        {
            var tcs = new TaskCompletionSource<Propriedade>();
            await _escolherPropriedadeJanela.Inicializar(propriedades, tcs);
            Propriedade resultado = await tcs.Task;

            return resultado;
        }

        public async Task<bool> EscolheMoverOuComprar()
        {
            var tcs = new TaskCompletionSource<bool>();
            await _moverOuComprarJanela.Inicializar(tcs);

            bool resultado = await tcs.Task;

            return resultado;
        }

        public async Task MostrarMensagem(string message)
        {
            var tcs = new TaskCompletionSource<Task>();
            await _janelaGenerica.Inicializar(message, tcs);

            await tcs.Task;
        }

        public async Task AcabarJogo(Personagem vencedor)
        {
            await _fimDeJogojanela.Inicializar(vencedor);
        }
    }
}
