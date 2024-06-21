using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
                await EntregarCartaAoPersonagem();
            }
        }

        private async Task EscolherPropriedade()
        {
            Jogador jogadorAtual = Tabuleiro.GetInstance().JogadorAtual();
            var propriedades = Tabuleiro.GetInstance().casas.OfType<Propriedade>();
            var propriedadesFiltradas = propriedades.Where(p => p.GetProprietario() == null);

            if (propriedadesFiltradas.Count() != 0)
            {
                Propriedade propriedade = await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(propriedades.ToList());
                await jogadorAtual.Teleportar(propriedade.GetPosicao());

            }
            else
            {
                Propriedade propriedade = await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(propriedadesFiltradas.ToList());
                propriedade.GetProprietario().Receber(propriedade.GetPreco());
                jogadorAtual.Pagar(propriedade.GetPreco());
                propriedade.RemoverProprietario(propriedade.GetProprietario());
                propriedade.SetProprietario(jogadorAtual);
            }
        }

        private async Task EntregarCartaAoPersonagem()
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
            Efeito efeito = new EfeitoComprarCarta();
            await efeito.RealizarEfeito();
        }
    }
}