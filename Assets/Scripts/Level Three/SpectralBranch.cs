using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralBranch : MonoBehaviour
{
    public GameObject ramales;
    public float segundosRojos;
    public bool timesUp;
    

    void Update()
    {
        if (timesUp)
        {
            ramales.SetActive(false);
        }
    }

    public void TimesRunning()
    {
        if (ramales.CompareTag("Rojo"))
        {
            ramales.SetActive(true);
            StartCoroutine(DesaparecePlataforma());
        }
    }

    IEnumerator DesaparecePlataforma()
    {
        timesUp = false;
        yield return new WaitForSeconds(segundosRojos);
        timesUp = true;
    }
}
