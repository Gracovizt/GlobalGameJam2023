using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematicas : MonoBehaviour
{
    public GameObject player;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            player.gameObject.GetComponent<PlayerAttack>().enabled = false;
        }
    }
}
