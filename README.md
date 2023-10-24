# 8-Puzzle

Link no Github: https://github.com/Eric-Catarina/8-Puzzle


## Explicação do Código

O jogo começa inicializando uma matriz 3x3 com os números de 1 a 8 e os embaralhando.
O bloco que o jogador controla é o bloco vazio, e sua localização é feita através das variáveis `emptyRow` e `emptyCol`

Enquanto o jogador não desiste(gameOver) ou ganha(matriz 012..678), o input do jogador é lido com as letras WASD igual em um jogo normal. Esses inputs indicam a direção que o bloco vazio irá se mover, trocando sua posição com o número ao seu lado. Dessa forma, depois de vários movimentos, um jogador capacitado conseguirá organizar o tabuleiro e vencer. 🥳🥳