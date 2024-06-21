using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Propriedade : Casa
    {
        private int preco;
        private int aluguel;
        private bool aluguelDobrado;
        private Jogador proprietario;

        public Cor Cor;

        public Propriedade(string nome, int posicao, int preco, int aluguel, Cor cor) : base(nome, posicao, null)
        {
            this.preco = preco;
            this.aluguel = aluguel;
            aluguelDobrado = false;
            proprietario = null;
            Cor = cor;
        }

        public override async Task RealizarEfeitos()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            Jogador jogadorAtual = tabuleiro.JogadorAtual();

            if (proprietario == null)
            {
                await tabuleiro.InterfaceUsuario.PerguntarComprarPropriedade(this,
                    () => Comprar(jogadorAtual),
                    () => { });
            }
            else
            {
                if (!ChecarProprietario(jogadorAtual))
                    CobrarAluguel();
            }
        }

        public bool ChecarProprietario(Jogador jogador)
        {
            if (jogador == proprietario)
            {
                return true;
            }
            return false;
        }

        public void CobrarAluguel()
        {
            Jogador jogadorDaVez = Tabuleiro.GetInstance().JogadorAtual();
            int valorAPagar = aluguel;

            if (aluguelDobrado)
            {
                valorAPagar *= 2;
            }
            // jogador da Vez tem saldo suficiente? se não, passa todo o dinheiro dele pro proprietário e acaba o jogo
            proprietario.Receber(valorAPagar);
            jogadorDaVez.Pagar(valorAPagar);
        }

        public void Comprar(Jogador comprador)
        {
            if (proprietario == null)
            {
                comprador.Pagar(preco);
                SetProprietario(comprador);
            }
        }

        public int GetPreco() => preco;
        public Jogador GetProprietario() => proprietario;

        public void SetProprietario(Jogador jogador)
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            proprietario = jogador;
            Propriedade propriedadeMesmaCor = jogador.propriedades.FirstOrDefault(p => p.Cor == Cor);
            jogador.propriedades.Add(this);

            if (propriedadeMesmaCor != null)
            {
                aluguelDobrado = true;
                propriedadeMesmaCor.aluguelDobrado = true;

            }
            tabuleiro.InterfaceUsuario.AdicionarPropriedade(jogador.GetPersonagem(), this);
        }
        public void RemoverProprietario(Jogador jogador)
        {
            proprietario = null;
            foreach (Propriedade propriedade in jogador.propriedades)
            {
                if (propriedade == this)
                {
                    jogador.propriedades.Remove(propriedade);
                    aluguelDobrado = false;
                }
            }
        }
    }
}