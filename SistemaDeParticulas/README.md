# Sistema de Partículas

## Descrição do Projeto

> Este projeto foi desenvolvido como parte da disciplina *Animação Computadorizada* com o objetivo de usar os sistemas de partículas da Unity. O jogador pode visualizar 3 tipos de interações com partículas apertando 1, 2 e 3. Cada exemplo mostra um comportamento diferente. Ao apertar 1 o jogador vê o exemplo de uma chama, ao apertar 2 o jogador observa uma explosão e ao pressionar 3 o jogador pode observar a chuva.

---

## Estrutura do Projeto

Listar e escrever brevemente sobre os principais scripts do projeto.

| Arquivo              | Descrição                                                  |
|----------------------|------------------------------------------------------------|
| `GameManagerButtons.cs` |Gerencia a troca do exemplo de partículas a partir do teclado numérico|
| `ParticulaFogo.mat`      | O material que dá a textura às partículas da chama|
| `ExplosionOrange.mat`      | O material que do flash da explosão|

---
## Informações Técnicas

- **Engine:** Unity 6000.3.13f1  
- **Linguagem:** C#  
- **Dependências:** TextMeshPro, Input System (Unity)  
- **Plataforma-alvo:** WebGL e Windows  

---

## Exemplos

### 1. Fogo

#### Descrição:
> Sistema de partículas utilizado para representar uma chama. As partículas são emitidas a partir de um emissor em formato de cone e se movimentam para cima.

#### O que este exemplo demonstra:

- Emissor: Cone
- Trajetória: Movimento ascendente
- Variação de cor: Amarelo → Laranja → Vermelho
- Variação de tamanho: As partículas aumentam e diminuem de tamanho durante sua vida
- Variação de transparência: As partículas ficam gradualmente transparentes até desaparecerem
- Critério de morte: Tempo de vida / transparência

### 2. Explosão

#### Descrição:
> Sistema de partículas que representa uma explosão. As partículas nascem a partir de um ponto central e são lançadas em diferentes direções.

#### O que este exemplo demonstra:

Emissor: Esfera
- Nascimento: Emissão em forma de Burst
- Trajetória: Movimento radial, afastando-se do centro da explosão
- Gravidade: As partículas sofrem uma força para baixo durante o movimento
- Variação de tamanho: As partículas aumentam e posteriormente diminuem
- Critério de morte: Tempo de vida

### 3. Chuva

#### Descrição:
> Sistema de partículas que representa gotas de chuva. As partículas são distribuídas por uma área e se movimentam verticalmente para baixo.

#### O que este exemplo demonstra:

- Emissor: Box
- Trajetória: Movimento vertical descendente
- Velocidade: Movimento rápido em direção ao solo
- Variação de transparência: As partículas podem desaparecer gradualmente
- Critério de morte: Colisão com o chão e/ou tempo de vida

## Comportamentos demonstrados

|**Comportamento**         |	**Exemplo**          |
|----------------------|-------------------|
| Movimento ascendente |	Fogo |
|Movimento radial |	Explosão |
|Movimento com gravidade	| Explosão |
|Movimento vertical descendente |	Chuva |
|Variação de cor |	Fogo / Explosão |
|Variação de tamanho	| Fogo / Explosão |
|Variação de transparência	| Fogo / Explosão / Chuva

## Link para a Build

🔗 [https://roedor.itch.io/trabalho-animacao-computadorizada-curvas-paramtricas]([https://usuario.itch.io/nome-do-jogo](https://roedor.itch.io/trabalho-animacao-computadorizada-curvas-paramtricas))

---
