namespace Game
{
    public class EfeitoEspecialPersonagem : Efeito
    {
        private EfeitoComprarCarta comprarCarta;
        private Personagem personagem;

        public EfeitoEspecialPersonagem(Personagem personagem)
        {
            this.personagem = personagem;
            comprarCarta = new();
        }

        public async Task RealizarEfeito()
        {
            Jogador jogador = Tabuleiro.GetInstance().JogadorAtual();
            if (jogador.GetPersonagem() == personagem)
            {
                await EscolherPropriedade();
            }
            else
            {
                EntregarCartaAoPersonagem();
            }
        }

        private async Task EscolherPropriedade()
        {
            Jogador jogadorAtual = Tabuleiro.GetInstance().JogadorAtual();
            List<Propriedade> propriedades = (List<Propriedade>)Tabuleiro.GetInstance().casas.OfType<Propriedade>();
            List<Propriedade> propriedadesFiltradas = (List<Propriedade>)propriedades.Where(p => p.GetProprietario() == null);
            if (propriedadesFiltradas.Count() == 0)
            {
                await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(propriedades);
            }
            else
            {
                Propriedade propriedade = await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(propriedadesFiltradas);
                propriedade.GetProprietario().Receber(propriedade.GetPreco());
                jogadorAtual.Pagar(propriedade.GetPreco());
                propriedade.RemoverProprietario(propriedade.GetProprietario());
                propriedade.SetProprietario(jogadorAtual);
            }
        }

        private void EntregarCartaAoPersonagem()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            List<Jogador> jogadores = tabuleiro.jogadores;
            foreach (Jogador jogador in jogadores)
            {
                if (jogador.GetPersonagem() == personagem)
                {
                    jogador.efeitoInicial = this;
                }

            }
            tabuleiro.PegarCarta();
        }
    }
}