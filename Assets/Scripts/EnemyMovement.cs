using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject ida;
    public GameObject vuelta;
    public float speed;

    public bool yendo = true;

    void Update()
    {
        if (yendo)
        {
            transform.position = Vector3.MoveTowards(transform.position, vuelta.transform.position, Time.deltaTime*speed);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, ida.transform.position, Time.deltaTime*speed);
        }

        if(transform.position == ida.transform.position)
        {
            yendo = true;
        }


        else if (transform.position == vuelta.transform.position)
        {
            yendo = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }
    }
}
