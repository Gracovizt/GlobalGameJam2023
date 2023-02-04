using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralBranch : MonoBehaviour
{
    public GameObject plataforma;
    public float segundosRojos;
    public bool timesUp;
    

    void Update()
    {
        if (timesUp)
        {
            plataforma.SetActive(false);
        }
    }

    public void TimesRunning()
    {
        if (plataforma.CompareTag("Rojo"))
        {
            plataforma.SetActive(true);
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
