using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer mesh;

    public float velocidade = 100f;

    void Update()
    {
        float boca = mesh.GetBlendShapeWeight(0);
        float cabeca = mesh.GetBlendShapeWeight(1);
        float olhos = mesh.GetBlendShapeWeight(2);

        if (Input.GetKey(KeyCode.E))
            boca += velocidade * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            boca -= velocidade * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            cabeca += velocidade * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            cabeca -= velocidade * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            olhos += velocidade * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            olhos -= velocidade * Time.deltaTime;

        mesh.SetBlendShapeWeight(0, Mathf.Clamp(boca, 0, 100));
        mesh.SetBlendShapeWeight(1, Mathf.Clamp(cabeca, 0, 100));
        mesh.SetBlendShapeWeight(2, Mathf.Clamp(olhos, 0, 100));
    }
}
