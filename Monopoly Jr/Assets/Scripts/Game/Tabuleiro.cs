using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Tabuleiro
    {
        private const int POSICAO_GO_KARTS = 10;        
        private const int POSICAO_CALCADAO = 23;        

        #region Singleton
        private static Tabuleiro instance;

        private Tabuleiro()
        {
            foreach (Personagem personagem in Enum.GetValues(typeof(Personagem)))
            {
                jogadores.Add(new(personagem));
            }

            casas = new()
            {
                new Casa("GO", 0, new EfeitoTransacao(2)),
                new Propriedade("Taqueria", 1, 1, 1, Cor.MARROM),
                new Propriedade("Pizzaria", 2, 1, 1, Cor.MARROM),
                new Casa("Sorte ou Revés", 3, new EfeitoComprarCarta()),
                new Propriedade("Padaria", 4, 1, 1, Cor.AZUL_CLARO),
                new Propriedade("Sorveteria", 5, 1, 1, Cor.AZUL_CLARO),
                new Casa("Prisão", 6, new EfeitoPrisao()),
                new Propriedade("Museu", 7, 2, 2, Cor.ROSA),
                new Propriedade("Biblioteca", 8, 2, 2, Cor.ROSA),
                new Casa("Sorte ou Revés", 9, new EfeitoComprarCarta()),
                new Propriedade("Go Karts", 10, 2, 2, Cor.LARANJA),
                new Propriedade("Piscina", 11, 2, 2, Cor.LARANJA),
                new Casa("Estacionamento", 12, null),
                new Propriedade("Roda-gigante", 13, 3, 3, Cor.VERMELHO),
                new Propriedade("Montanha-russa", 14, 3, 3, Cor.VERMELHO),
                new Casa("Sorte ou Revés", 15, new EfeitoComprarCarta()),
                new Propriedade("Loja de Brinquedos", 16, 3, 3, Cor.AMARELO),
                new Propriedade("Pet Shop", 17, 3, 3, Cor.AMARELO),
                new Casa("Vá para prisão", 18, new EfeitoPrisao()),
                new Propriedade("Aquário", 19, 4, 4, Cor.VERDE),
                new Propriedade("Zoológico", 20, 4, 4, Cor.VERDE),
                new Casa("Sorte ou Revés", 21, new EfeitoComprarCarta()),
                new Propriedade("Parque", 22, 5, 5, Cor.AZUL_ESCURO),
                new Propriedade("Calçadão", 23, 5, 5, Cor.AZUL_ESCURO),
            };

            cartas = new()
            {
                new("Avance para uma casa azul claro ou vermelha. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.AZUL_CLARO, Cor.VERMELHO)),
                new("Avance para uma casa laranja ou verde. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.LARANJA, Cor.VERDE)),
                new("Avance para uma casa rosa ou azul escuro. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.ROSA, Cor.AZUL_ESCURO)),
                new("Avance para uma casa vermelha. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.VERMELHO)),
                new("Avance para uma casa azul claro. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.AZUL_CLARO)),
                new("Avance para uma casa laranja. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.LARANJA)),
                new("Avance para uma casa marrom ou amarela. Se uma estiver disponível, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoEscolherPropriedade(Cor.MARROM, Cor.AMARELO)),
                new("Avance para o Calçadão", new EfeitoTeleporte(POSICAO_CALCADAO)),
                new("Avance até 5 casas à frente.", new EfeitoEscolherPassos()),
                new("Avance 1 casa à frente ou pegue outra carta de Sorte.", new EfeitoEscolherPassos()),
                new("Avance para o Início. Receba $2.", new EfeitoTeleporte(0)),
                new("Avance para os Carrinhos de Bate-Bate. Se ninguém a possui, pegue-a de GRAÇA! Caso contrário, PAGUE aluguel ao proprietário.",
                    new EfeitoPropriedadeGratis(POSICAO_GO_KARTS)),
                new("Saia da prisão de graça. Guarde esta carta até precisar dela.", new EfeitoHabeasCorpus()),
                new("Você fez todos os seus deveres! Receba $2 do Banco.", new EfeitoTransacao(2)),
                new("É seu aniversário! Receba $2 do Banco. Feliz Aniversário!", new EfeitoTransacao(2)),
                new("Você comeu muitos doces! Pague $2 ao Banco.", new EfeitoTransacao(-2)),
                new("Dê esta carta ao Barco e pegue outra carta de Sorte.\n" +
                    "Barco: no seu próximo turno, navegue até qualquer casa livre e compre-a. Se todas estiverem ocupadas, compre uma propriedade de qualquer jogador!",
                    new EfeitoEspecialPersonagem(Personagem.BARCO)),
                new("Dê esta carta ao Cachorro e pegue outra carta de Sorte.\n" +
                    "Cachorro: no seu próximo turno, navegue até qualquer casa livre e compre-a. Se todas estiverem ocupadas, compre uma propriedade de qualquer jogador!",
                    new EfeitoEspecialPersonagem(Personagem.CACHORRO)),
                new("Dê esta carta ao Carro e pegue outra carta de Sorte.\n" +
                    "Carro: no seu próximo turno, navegue até qualquer casa livre e compre-a. Se todas estiverem ocupadas, compre uma propriedade de qualquer jogador!",
                    new EfeitoEspecialPersonagem(Personagem.CARRO)),
                new("Dê esta carta ao Gato e pegue outra carta de Sorte.\n" +
                    "Gato: no seu próximo turno, navegue até qualquer casa livre e compre-a. Se todas estiverem ocupadas, compre uma propriedade de qualquer jogador!",
                    new EfeitoEspecialPersonagem(Personagem.GATO)),
            };
            cartas = EmbaralharCartas();
        }

        public static Tabuleiro GetInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }
        #endregion

        public List<Jogador> jogadores = new();
        public List<Casa> casas = new();
        public List<Carta> cartas = new();
        public InterfaceUsuario InterfaceUsuario;
        private int jogadorDaVez = 0;
        private int cartaDaVez;

        public void ProximoJogador()
        {
            InterfaceUsuario.MudarVez(JogadorAtual().GetPersonagem(), false);

            jogadorDaVez++;    

            if (jogadorDaVez >= jogadores.Count)
            {
                jogadorDaVez = 0;
            }
            InterfaceUsuario.MudarVez(JogadorAtual().GetPersonagem(), true);
            JogadorAtual().IniciarRodada();
        }

        public Jogador JogadorAtual()
        {
            return jogadores[jogadorDaVez];
        }

        private List<Carta> EmbaralharCartas()
        {
            cartaDaVez = 0;
            Random random = new();
            return cartas.OrderBy(c => random.Next()).ToList();
        }

        public Carta PegarCarta()
        {
            cartaDaVez++;
            if (cartaDaVez >= cartas.Count)
                EmbaralharCartas();
            return cartas[cartaDaVez];
        }
    }
}