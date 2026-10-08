using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioScript : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    [SerializeField] Camera m_Camera; // Reference to the camera in the scene. This is used to determine the position of the audio listener in relation to the audio source.

    int colorIndex = 0; // Index to keep track of the current color. This is used to cycle through different colors when the energy of the low frequencies exceeds a certain threshold.

    float waitColorChange = 0.25f;
    private float beatLimit = 1.5f;
    float beatIncrease = 0.2f;

    float previousBass = 0f;
    float nextColorChange = 0f;

    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float[] spectrum = new float[512];//Deve ser em potência de 2, pois o FFT é feito em potências de 2. Ex: 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536

        float sampleRate = AudioSettings.outputSampleRate; //Obtem a taxa de amostragem do áudio. A taxa de amostragem é o número de amostras de áudio por segundo. Por exemplo, uma taxa de amostragem de 44100 Hz significa que há 44100 amostras de áudio por segundo. 

        m_MyAudioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular); //Preenche o array spectrum com os dados do espectro de áudio. O primeiro parâmetro é o array a ser preenchido, o segundo é o canal de áudio (0 para o canal esquerdo, 1 para o canal direito) e o terceiro é a janela FFT a ser usada (Rectangular, Hamming, Hanning, Blackman, etc.).

        float bass = 0f; //Variável para armazenar a energia das frequências graves (20 Hz a 250 Hz).
        float medium = 0f; //Variável para armazenar a energia das frequências médias (250 Hz a 2000 Hz).
        float sharp = 0f; //Variável para armazenar a energia das frequências agudas (2000 Hz a 20000 Hz).

        for (int i = 0; i < spectrum.Length/2; i++)
        {
            float frequency = i * sampleRate / spectrum.Length; //Calcula a frequência correspondente ao índice do bin atual. A frequência é determinada pelo índice do bin, a taxa de amostragem e o número total de bins nos dados do espectro.
            if (frequency >= 20 && frequency < 250f) //Verifica se é uma frequência grave (20 Hz a 250 Hz).
            {
                bass += spectrum[i]; //Acumula a energia das frequências graves.
            }
            else if (frequency >= 250f && frequency < 4000f) //Verifica se é uma frequência média (250 Hz a 2000 Hz).
            {
                medium += spectrum[i]; //Acumula a energia das frequências médias.
            }
            else if (frequency >= 4000f && frequency < 20000f) //Verifica se é uma frequência aguda (2000 Hz a 20000 Hz).
            {
                sharp += spectrum[i]; //Acumula a energia das frequências agudas.
            }
        }



        /*
        //Desenhando a faixa de frequência no console para depuração. Isso ajuda a entender quais frequências estão sendo representadas pelos diferentes bins do espectro.
     
        float scaleX = 0.1f; // Escala pelo eixo X. 
        float center = spectrum.Length / 2f; // Calcula o centro do espectro. O centro é usado para calcular a posição x dos bins do espectro em relação ao centro. 

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            float x1 = (i - 1 - center) *scaleX; // The x-coordinate of the previous bin in the spectrum data.
            float x2 = (i - center) * scaleX; // The x-coordinate of the next bin in the spectrum data.
            float logX1 = (Mathf.Log(i - 1) - Mathf.Log(center));
            float logX2 = (Mathf.Log(i) - Mathf.Log(center));
                    
            //Desenhando a faixa de frequência no console para depuração. Isso ajuda a entender quais frequências estão sendo representadas pelos diferentes bins do espectro.
            Debug.DrawLine(new Vector3(x1, spectrum[i-1] + 10, 0), new Vector3(x2, spectrum[i] + 10, 0), Color.red); 
            Debug.DrawLine(new Vector3(x1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(x2, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan); 
            Debug.DrawLine(new Vector3(logX1, spectrum[i - 1] - 10, 1), new Vector3(logX2, spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(logX1, Mathf.Log(spectrum[i - 1]), 3), new Vector3(logX2, Mathf.Log(spectrum[i]), 3), Color.blue);
            */

        foreach(SuzanneScript suzanne in FindObjectsOfType<SuzanneScript>())
        {
            suzanne.BassEffect(bass); //Redimensiona o cubo com base na energia das frequências graves. A energia é multiplicada por 10 para aumentar a escala do cubo.
            suzanne.MediumEffect(medium); //Redimensiona o cubo com base na energia das frequências médias. A energia é multiplicada por 10 para aumentar a escala do cubo.
            suzanne.SharpEffect(sharp); //Redimensiona o cubo com base na energia das frequências agudas. A energia é multiplicada por 10 para aumentar a escala do cubo.
        }

        bool beat = bass > beatLimit && bass - previousBass >= beatIncrease; ; //Verifica se a energia das frequências graves é maior que o limite definido para detectar um batimento.

        if (beat && Time.time >= nextColorChange)
        {

            switch (colorIndex){
                case 0:
                    m_Camera.backgroundColor = Color.red; //Muda a cor do fundo da câmera para vermelho se a energia das frequências graves for maior ou igual a 1.
                    colorIndex +=1;
                    break;
                case 1:
                    m_Camera.backgroundColor = Color.green; //Muda a cor do fundo da câmera para verde se a energia das frequências graves for maior ou igual a 1.
                    colorIndex +=1;
                    break;
                case 2:
                    m_Camera.backgroundColor = Color.blue; //Muda a cor do fundo da câmera para azul se a energia das frequências graves for maior ou igual a 1.
                    colorIndex = 0;
                    break;
            }
            nextColorChange = Time.time + waitColorChange; //Atualiza o tempo para a próxima mudança de cor. Isso evita que a cor mude muito rapidamente.
        }
        previousBass = bass; //Atualiza a energia das frequências graves para a próxima verificação de batimento. Isso é usado para comparar a energia atual com a energia anterior e determinar se houve um aumento significativo na energia das frequências graves.
    }
}
