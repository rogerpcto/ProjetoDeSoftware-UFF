# Escopo do Sistema
O sistema consiste em um jogo de tabuleiro conhecido como Banco Imobiliário Junior. O jogo pode ser multiplayer, de 2 a 4 jogadores, ou contra o computador. 

Inicialmente, o sistema escolhe aleatoriamente o jogador que irá começar a partida. Para o jogador se movimentar no tabuleiro, ele irá jogar um dado que varia de 1 a 6. Todos os jogadores jogarão no mesmo tabuleiro que é composto por 3 tipos de casas: propriedade, carta de sorte ou prisão. Cada jogador terá um saldo, todos recebem o mesmo valor inicialmente, e o usará para adquirir propriedades, pagar aluguel a outros jogadores ou sair da prisão. 

Ao cair em uma casa do tipo propriedade, o jogador tem a opção de não comprar ou comprá-la, caso ela não possua nenhum proprietário e ele tenha saldo para isso. Se a propriedade tiver dono, o jogador deverá pagar um aluguel. Se um mesmo proprietário possui todas as propriedades de uma mesma cor, então cada aluguel dessas propriedades tem o seu valor dobrado. Caso o jogador caia na casa do tipo carta de sorte, ele deverá comprar uma carta de sorte e ativar o efeito descrito nela. Caso o jogador caia na casa do tipo prisão, o jogador sofrerá as consequências conforme o efeito descrito na carta.

O jogo termina quando o primeiro jogador ficar sem saldo, ou seja, quando o primeiro jogador falir. O vencedor da partida é o jogador com o maior saldo no momento. Caso haja empate, o vencedor será decidido somando o valor das propriedades de cada jogador.


---


# Requisitos Funcionais

* Seleção de jogadores: 
O sistema permite que o usuário escolha o número de jogadores que participarão da partida, podendo ser 2, 3 ou 4 jogadores, além da opção de jogar contra o computador.


* Início da partida: 
O sistema escolhe aleatoriamente o jogador que irá começar a partida.


* Compra de propriedades: 
O sistema permite que os jogadores comprem propriedades quando caírem em casas desse tipo, desde que possuam saldo suficiente e que a propriedade já não tenha proprietário.

* Pagamento de aluguel: O sistema calcula automaticamente e realiza a transação sobre o valor do aluguel que deve ser pago por um jogador a outro quando cai em uma propriedade já comprada. Se um mesmo jogador possuir todas as propriedades com a mesma cor, o aluguel dessas propriedades tem o seu valor dobrado.

* Cartas de sorte: O sistema permite que os jogadores comprem cartas de sorte quando caírem em casas do tipo “cartas de sorte” e ativa o efeito descrito na carta.

* Prisão: Quando o jogador estiver na prisão, no início da sua vez de jogar, o sistema deve obrigá-lo a pagar o valor da fiança ou utilizar a carta de sorte que permite que o jogador saia da prisão, se o jogador possuí-la.

* Fim da partida: O sistema identifica o jogador que ficou sem saldo e conta o saldo total de cada jogador. Quem tiver o maior saldo, é declarado vencedor da partida. Em caso de empate, o sistema soma o valor das propriedades de cada jogador e declara o vencedor com base no maior saldo final.

---

## Requisitos Não Funcionais

* Tempo de resposta do sistema: O sistema deve responder de forma rápida às ações dos jogadores, garantindo uma experiência fluida e sem atrasos perceptíveis.

* Segurança: O sistema deve garantir a segurança dos dados dos jogadores, evitando acesso não autorizado e protegendo as informações pessoais.

* Disponibilidade : O sistema deve estar disponível sempre que os jogadores quiserem jogar




## Caso de Uso 01 - < Comprar propriedade >

#### Nome:Comprar propriedade

#### Resumo:O jogador compra uma propriedade

#### Lista de atores: Jogador

#### Pré-condições: Jogador estar em cima da casa da propriedade

#### Cenário típico:
    1. Sistema Verifica a situação da propriedade
    2. Jogador Escolhe comprar a propriedade    
    3. Sistema Aloca a propriedade no patrimonio do jogador.


#### Cenário Alternativo: 
    A1 A propriedade ja possui um dono
        1. O jogador paga um aluguel igual ao valor da propriedade ao dono
    A2 O jogador escolhe não comprar a propriedade
        1. O jogador apenas espera em cima da propriedade a sua proxima vez


#### Regras de Negócio: ??


