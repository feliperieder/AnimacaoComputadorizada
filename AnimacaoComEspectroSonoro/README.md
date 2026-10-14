# Visualizador Musical

## Descrição do Projeto

> Este projeto foi desenvolvido como parte da disciplina de *Animação Computadorizada*, com o objetivo de utilizar a análise de áudio para criar efeitos visuais em tempo real na Unity. A aplicação utiliza a Transformada Rápida de Fourier (FFT) para analisar as frequências de uma música e modificar os elementos visuais de acordo com o som reproduzido.
>
> O projeto divide o áudio em três faixas de frequência: graves, médios e agudos. Cada faixa influencia o comportamento de um modelo 3D da Suzanne, fazendo com que seus efeitos visuais reajam à música. Além disso, a cor de fundo da câmera alterna entre vermelho, verde e azul quando são detectadas variações significativas nas frequências graves.

---

## Estrutura do Projeto

| Arquivo | Descrição |
|---|---|
| `AudioScript.cs` | Captura os dados do áudio, realiza a análise das frequências com FFT, separa o espectro em graves, médios e agudos e controla a mudança de cor do fundo. |
| `SuzanneScript.cs` | Controla os efeitos visuais aplicados ao modelo Suzanne de acordo com a intensidade de cada faixa de frequência. |

---

## Informações Técnicas

- **Engine:** Unity
- **Linguagem:** C#
- **Técnica de análise de áudio:** Fast Fourier Transform (FFT)
- **Componentes utilizados:** `AudioSource`, `Camera` e `MonoBehaviour`
- **Dependências:** Recursos nativos da Unity
- **Plataforma-alvo:** A definir conforme a build do projeto.

---

## Exemplos

### 1. Frequências Graves

#### Descrição:
> As frequências graves representam os sons de baixa frequência, como os bumbos e os baixos presentes em muitas músicas. Os dados dessa faixa são utilizados para modificar o comportamento visual do modelo Suzanne.

#### O que este exemplo demonstra:

- **Faixa de frequência:** 20 Hz a 250 Hz.
- **Análise de áudio:** Soma das magnitudes dos componentes do espectro correspondentes aos graves.
- **Interação visual:** A boca da Suzanne reage à intensidade das frequências graves.
- **Detecção de batidas:** Variações significativas nos graves podem provocar a mudança da cor de fundo da câmera.

### 2. Frequências Médias

#### Descrição:
> As frequências médias abrangem uma região importante do espectro musical, incluindo componentes de instrumentos e vozes. Essa faixa é analisada separadamente para controlar os efeitos visuais do modelo.

#### O que este exemplo demonstra:

- **Faixa de frequência:** 250 Hz a 4.000 Hz.
- **Análise de áudio:** Identificação e soma das magnitudes dos componentes correspondentes aos médios.
- **Interação visual:** A cabeça da Suzanne reage às variações de intensidade dessa faixa.
- **Processamento em tempo real:** Os valores são atualizados durante a reprodução do áudio.

### 3. Frequências Agudas

#### Descrição:
> As frequências agudas representam os sons de maior frequência, como pratos de bateria e componentes mais agudos de instrumentos musicais. Essa faixa também é utilizada para gerar alterações visuais no modelo Suzanne.

#### O que este exemplo demonstra:

- **Faixa de frequência:** 4.000 Hz a 20.000 Hz.
- **Análise de áudio:** Identificação e soma das magnitudes dos componentes correspondentes aos agudos.
- **Interação visual:** Os olhos da Suzanne reage à intensidade das frequências agudas.

---

## Comportamentos Demonstrados

| Comportamento | Exemplo |
|---|---|
| Análise do espectro de áudio | Graves / Médios / Agudos |
| Separação do áudio por faixas de frequência | Graves / Médios / Agudos |
| Reação visual às frequências graves | Suzanne |
| Reação visual às frequências médias | Suzanne |
| Reação visual às frequências agudas | Suzanne |
| Detecção de variações nos graves | Fundo da câmera |
| Mudança de cor em resposta ao áudio | Fundo da câmera |
| Processamento em tempo real | Todos os exemplos |

---

## Análise de Áudio

A análise sonora é realizada utilizando o método `GetSpectrumData()` da classe `AudioSource`, que fornece os valores do espectro de frequência do áudio reproduzido.

O projeto utiliza um vetor de **512 amostras** para armazenar os dados do espectro. Em cada atualização, os valores são analisados e separados em três faixas:

- **Graves:** de 20 Hz a 250 Hz.
- **Médios:** de 250 Hz a 4.000 Hz.
- **Agudos:** de 4.000 Hz a 20.000 Hz.

A frequência aproximada de cada posição do vetor é calculada com base no índice da amostra, no tamanho do vetor e na taxa de amostragem de saída da Unity.

Os valores obtidos são enviados ao script `SuzanneScript.cs`, que os utiliza para controlar os efeitos visuais do modelo.

---

## Mudança de Cor do Fundo

A câmera alterna entre três cores: vermelho, verde e azul. Essa mudança é controlada pela análise das frequências graves, buscando identificar aumentos significativos na intensidade do som.

Para evitar mudanças excessivamente rápidas, são utilizados parâmetros que definem:

- **Limite mínimo (`beatLimit`):** intensidade mínima dos graves necessária para permitir uma mudança de cor.
- **Variação mínima (`beatIncrease`):** aumento necessário em relação ao valor anterior dos graves.
- **Intervalo (`waitColorChange`):** tempo mínimo entre mudanças consecutivas de cor.

Dessa forma, a mudança de cor depende tanto da intensidade dos graves quanto da variação detectada e do intervalo entre as alterações.

---

## Conceitos Aplicados

- **FFT (Fast Fourier Transform):** técnica utilizada para analisar as frequências presentes no áudio.
- **Espectro de frequência:** representação dos componentes de frequência do som.
- **Processamento em tempo real:** atualização contínua dos valores durante a reprodução da música.
- **Animação procedural:** modificação dos elementos visuais a partir de valores calculados durante a execução.
- **Interação entre áudio e imagem:** utilização das características sonoras para controlar efeitos visuais.

---
