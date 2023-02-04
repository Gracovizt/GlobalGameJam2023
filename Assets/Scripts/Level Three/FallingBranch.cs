using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBranch : MonoBehaviour
{
    public float segundosAzules;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DesaparecePlataforma());
        }
    }

    IEnumerator DesaparecePlataforma()
    {
        yield return new WaitForSeconds(segundosAzules);
        gameObject.SetActive(false);
    }
}
