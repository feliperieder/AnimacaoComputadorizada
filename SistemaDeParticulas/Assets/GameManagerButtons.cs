using UnityEngine;

public class GameManagerButtons : MonoBehaviour
{
    [SerializeField] private GameObject particlesFire;
    [SerializeField] private GameObject particlesExplosion;
    [SerializeField] private GameObject particlesRain;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            particlesFire.SetActive(true);
            particlesExplosion.SetActive(false);
            particlesRain.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            particlesFire.SetActive(false);
            particlesExplosion.SetActive(true);
            particlesRain.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            particlesFire.SetActive(false);
            particlesExplosion.SetActive(false);
            particlesRain.SetActive(true);
        }
    }
}
