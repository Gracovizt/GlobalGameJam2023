using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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
        ramales.SetActive(true);

        if (ramales.CompareTag("Rojo"))
        { 
            StartCoroutine(DesaparecePlataforma());
        }
    }

    IEnumerator DesaparecePlataforma()
    {
        timesUp = false;
        yield return new WaitForSeconds(segundosRojos);
        timesUp = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird") && gameObject.CompareTag("Button"))
        {
            TimesRunning();
        }
    }
}
