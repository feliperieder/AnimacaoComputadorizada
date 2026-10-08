using UnityEngine;


[RequireComponent (typeof(SkinnedMeshRenderer))]
public class SuzanneScript: MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;

    float lastGrave = 0f;
    float lastMedio = 0f;
    float lastSmooth = 0f;

    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BassEffect(float bass) {
        if (skinnedMeshRenderer == null) return;
        float newGrave = Mathf.Clamp(bass * 100, 0f, 100f);
        newGrave = Mathf.Lerp(lastGrave, newGrave, Time.deltaTime * 5f); // Smooth transition
        skinnedMeshRenderer.SetBlendShapeWeight(0, newGrave); // Assuming the blend shape index for the mouth is 0
        lastGrave = newGrave;
    }

    public void MediumEffect(float medio) {
        if (skinnedMeshRenderer == null) return;
        float newMedio = Mathf.Clamp(medio * 100, 0f, 100f);
        newMedio = Mathf.Lerp(lastMedio, newMedio, Time.deltaTime * 5f); // Smooth transition
        skinnedMeshRenderer.SetBlendShapeWeight(1, newMedio); // Assuming the blend shape index for the eyes is 1
        lastMedio = newMedio;
    }

    public void SharpEffect(float smooth) {
        if (skinnedMeshRenderer == null) return;
        float newSmooth = Mathf.Clamp(smooth * 100, 0f, 100f);
        newSmooth = Mathf.Lerp(lastSmooth, newSmooth, Time.deltaTime * 5f); // Smooth transition
        skinnedMeshRenderer.SetBlendShapeWeight(2, newSmooth); // Assuming the blend shape index for the eyebrows is 2
        lastSmooth = newSmooth;
    }
}
