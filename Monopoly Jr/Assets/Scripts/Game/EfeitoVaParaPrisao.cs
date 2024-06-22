using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game
{
    public class EfeitoVaParaPrisao : Efeito
    {
        List<string> motivosParaPrisao = new List<string>
        {
            "A Receita Federal te pegou! Pague seus impostos corretamente da pr�xima vez.",
            "Voc� foi pego dirigindo um carrinho de golfe na rodovia. Vai para a pris�o!",
            "Tentou subornar o prefeito com 'dinheiro de brincadeira'. Agora � brincadeira na pris�o!",
            "Foi flagrado vendendo limonada sem licen�a. Parece que o ver�o vai ser atr�s das grades.",
            "Tentou construir um hotel no Parque P�blico. V� direto para a pris�o!",
            "Voc� foi pego tentando usar um cart�o 'Saia da Pris�o' falso. Agora � pris�o de verdade!",
            "Organizou uma corrida ilegal de tartarugas. As tartarugas est�o livres, mas voc� n�o!",
            "Tentou abrir um cassino no meio da cidade. As cartas n�o estavam a seu favor!",
            "Foi pego estacionando seu carro em cima do tabuleiro. O tabuleiro � para as pe�as!",
            "Tentou fazer uma festa na cadeia e foi pego. Agora voc� � um h�spede permanente!",
            "Foi pego tentando trocar dinheiro falso por dinheiro de verdade. Boa sorte na pris�o!",
            "Foi pego tentando subornar o banqueiro com propriedades. Agora sua casa � a pris�o!",
            "Tentou monopolizar a rua inteira. Parab�ns, voc� tem uma cela s� para voc�!"
        };

        private EfeitoTeleporte efeitoTeleporte;
        private EfeitoPrisao efeitoPrisao;

        public EfeitoVaParaPrisao(int posicaoPrisao)
        {
            efeitoTeleporte = new(posicaoPrisao);
            efeitoPrisao = new();
        }
        public async Task RealizarEfeito()
        {
            Tabuleiro tabuleiro = Tabuleiro.GetInstance();
            
            Random random = new Random();
            int indiceAleatorio = random.Next(motivosParaPrisao.Count);

            await tabuleiro.InterfaceUsuario.MostrarMensagem(motivosParaPrisao[indiceAleatorio]);
            await efeitoTeleporte.RealizarEfeito();
            Tabuleiro.GetInstance().JogadorAtual().efeitoInicial = efeitoPrisao;
        }
    }
}