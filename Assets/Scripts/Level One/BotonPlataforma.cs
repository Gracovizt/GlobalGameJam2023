using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlataforma : MonoBehaviour
{
    public GameObject plataforma;
    public GameObject destino;
    public bool isBird;

    // Start is called before the first frame update
    void Start()
    {
        isBird = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBird)
        {
            plataforma.transform.position = Vector3.MoveTowards(destino.transform.position, destino.transform.position, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            isBird = true;
        }
    }
}