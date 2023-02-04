using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasVuelven : MonoBehaviour
{
    public GameObject plataforma;
    public GameObject destino;
    public bool timesUp;
    public float segundos;

    void Start()
    {
        timesUp = false;
    }

    void Update()
    {
        if (timesUp)
        {
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, destino.transform.position, Time.deltaTime * 8);
        }
    }

    public void TimesRunning()
    {
        StartCoroutine(VuelvePlataforma());
    }

    IEnumerator VuelvePlataforma()
    {
        timesUp = false;
        yield return new WaitForSeconds(segundos);
        timesUp = true;
        gameObject.GetComponent<BotonPlataforma>().isBird = false;
    }
}
