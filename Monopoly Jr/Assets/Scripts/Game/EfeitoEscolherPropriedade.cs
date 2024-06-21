using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game
{
    public class EfeitoEscolherPropriedade : Efeito
    {
        private Cor cor1, cor2;

        public EfeitoEscolherPropriedade(Cor cor1, Cor cor2)
        {
            this.cor1 = cor1;
            this.cor2 = cor2;
        }

        public EfeitoEscolherPropriedade(Cor cor1)
        {
            this.cor1 = cor1;
            this.cor2 = cor1;
        }
           
        public async Task RealizarEfeito()
        {
            Propriedade propriedade = await EscolherPropriedadeCor();
            Jogador jogadorAtual = Tabuleiro.GetInstance().JogadorAtual();

            if (propriedade.GetProprietario() == null)
            {
                jogadorAtual.propriedades.Add(propriedade);
                propriedade.SetProprietario(jogadorAtual);
            }
            jogadorAtual.Teleportar(propriedade.GetPosicao());
        }

        private async Task<Propriedade> EscolherPropriedadeCor()
        {
            return await Tabuleiro.GetInstance().InterfaceUsuario.EscolherPropriedade(cor1, cor2);
        }
    }
}