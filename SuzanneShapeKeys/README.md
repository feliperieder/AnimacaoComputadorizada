# Animação com Shape Keys

## Descrição do Projeto

> Este projeto foi desenvolvido como parte da disciplina *Animação Computadorizada* com o objetivo de utilizar Shape Keys para modificar e animar um modelo 3D. O projeto utiliza o Blender para criação do modelo e dos Shape Keys, e a Unity para reprodução da animação e controle das deformações.
>
> O modelo utilizado é a Suzanne, modelo padrão do Blender, que recebeu três Shape Keys diferentes: `BocaIncha`, `CabecaGrande` e `Olhao`. Cada Shape Key modifica uma parte diferente do modelo e pode ser animada através de keyframes.
>
> Na Unity, há dois modelos, um que reproduz a animação feita pelo Blender e uma que pode ser alterada pelo jogador.

---

## Estrutura do Projeto

Os principais arquivos e pastas do projeto estão organizados da seguinte forma:

| Arquivo/Pasta | Descrição |
|----------------------|------------------------------------------------------------|
| `BELNDER/` | Pasta contendo o projeto e os arquivos utilizados no Blender. |
| `BELNDER/SuzanneAnimation.blend` | Arquivo do projeto Blender contendo o modelo Suzanne, os Shape Keys e a animação. |
| `SuzanneAnimation.glb` | Modelo exportado do Blender contendo os Shape Keys e os dados de animação. |
| `SuzanneAnimationTest.fbx` | Modelo exportado em formato FBX para utilização na Unity. |
| `SuzanneAnimation.fbx` | Modelo exportado em formato FBX para utilização na Unity, o qual a animação não foi ewxportada corretamente |
| `Assets/` | Pasta principal contendo os arquivos utilizados pelo projeto Unity. |
| `AnimationScript.cs` | script responsável pelo controle do modelo e dos Shape Keys. |

---

## Informações Técnicas

- **Engine:** Unity 6000.3.13f1
- **Modelagem e animação:** Blender
- **Linguagem:** C#
- **Formatos utilizados:** `.blend`, `.glb` e `.fbx`
- **Sistema de animação:** Animation / Shape Keys
- **Plataforma-alvo:** WebGL e Windows

---

## Modelo 3D

### Suzanne

#### Descrição:

> O modelo utilizado no projeto é a Suzanne, modelo 3D padrão do Blender. Foram criados três Shape Keys para modificar diferentes características do modelo.

### Shape Keys utilizadas:

- **BocaIncha** — modifica o formato da boca da Suzanne.
- **CabecaGrande** — aumenta o tamanho da cabeça.
- **Olhao** — modifica o tamanho/formato dos olhos.

Cada Shape Key possui um valor de influência que pode variar de `0` a `1` no Blender, ou de `0` a `100` na Unity.

---

## Animação

### Descrição:

> Foi criada uma animação utilizando os Shape Keys da Suzanne. Cada deformação é ativada em diferentes momentos da animação, permitindo visualizar individualmente as alterações realizadas no modelo.

### Sequência da animação:

| Shape Key | Início | Fim |
|-----------|--------|-----|
| `BocaIncha` | Frame 1 | Frame 60 |
| `CabecaGrande` | Frame 30 | Frame 90 |
| `Olhao` | Frame 60 | Frame 120 |

Após a utilização dos três Shape Keys, a animação retorna os valores para a posição inicial.

### O que a animação demonstra:

- Utilização de Shape Keys;
- Criação de keyframes;
- Alteração gradual dos valores dos Shape Keys;
- Animação de diferentes deformações do mesmo modelo;
- Reprodução de uma sequência de animação.

---

## Unity

### Descrição:

> O modelo criado no Blender é importado para a Unity, onde seus Shape Keys podem ser utilizados através do componente `Skinned Mesh Renderer`. A Unity permite acessar e modificar os valores dos Blend Shapes durante a execução do projeto.

Os principais componentes utilizados são:

- **Skinned Mesh Renderer** — responsável pela renderização do modelo e pelos Blend Shapes.
- **Animator** — responsável pela reprodução das animações.
- **Animation Clip** — contém os keyframes da animação.
- **Scripts C#** — utilizados para controlar os valores dos Shape Keys.

---

## Controle dos Shape Keys

Os Shape Keys também podem ser controlados durante a execução do projeto.

### Controles:

| Teclas | Ação |
|------|------|
| `E` & `Q` | Controla `BocaIncha` |
| `W` & `S` | Controla `CabecaGrande` |
| `A` & `D` | Controla `Olhao` |

Os valores dos Shape Keys são alterados através do componente `SkinnedMeshRenderer` utilizando a função `SetBlendShapeWeight()`.

---

## Comportamentos demonstrados

| **Comportamento** | **Exemplo** |
|-------------------|-------------|
| Alteração da boca | `BocaIncha` |
| Alteração do tamanho da cabeça | `CabecaGrande` |
| Alteração dos olhos | `Olhao` |
| Animação através de keyframes | Todos os Shape Keys |
| Controle por teclado | Todos os Shape Keys |
| Controle de Blend Shapes via código | Todos os Shape Keys |

---

## Shape Keys

Foram utilizados três Shape Keys diferentes no modelo:

### 1. BocaIncha

> Shape Key responsável por modificar o formato da boca da Suzanne. Seu valor é alterado gradualmente durante a animação.

### 2. CabecaGrande

> Shape Key responsável por aumentar o tamanho da cabeça da Suzanne. É ativado após a animação de `BocaIncha`.

### 3. Olhao

> Shape Key responsável por modificar os olhos da Suzanne. É ativado após a animação de `CabecaGrande`.

---
