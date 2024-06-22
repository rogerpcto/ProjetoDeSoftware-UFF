using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game
{
    public class EfeitoVaParaPrisao : Efeito
    {
        List<string> motivosParaPrisao = new List<string>
        {
            "A Receita Federal te pegou! Pague seus impostos corretamente da próxima vez.",
            "Você foi pego dirigindo um carrinho de golfe na rodovia. Vai para a prisão!",
            "Tentou subornar o prefeito com 'dinheiro de brincadeira'. Agora é brincadeira na prisão!",
            "Foi flagrado vendendo limonada sem licença. Parece que o verão vai ser atrás das grades.",
            "Tentou construir um hotel no Parque Público. Vá direto para a prisão!",
            "Você foi pego tentando usar um cartão 'Saia da Prisão' falso. Agora é prisão de verdade!",
            "Organizou uma corrida ilegal de tartarugas. As tartarugas estão livres, mas você não!",
            "Tentou abrir um cassino no meio da cidade. As cartas não estavam a seu favor!",
            "Foi pego estacionando seu carro em cima do tabuleiro. O tabuleiro é para as peças!",
            "Tentou fazer uma festa na cadeia e foi pego. Agora você é um hóspede permanente!",
            "Foi pego tentando trocar dinheiro falso por dinheiro de verdade. Boa sorte na prisão!",
            "Foi pego tentando subornar o banqueiro com propriedades. Agora sua casa é a prisão!",
            "Tentou monopolizar a rua inteira. Parabéns, você tem uma cela só para você!"
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