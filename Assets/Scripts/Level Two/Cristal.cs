using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Cristal : MonoBehaviour
{
    public GameObject plataforma;
    public GameObject destino;
    public bool isFalling;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, destino.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFalling = true;
        }
    }
}
