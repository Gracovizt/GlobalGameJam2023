using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematicas : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public Animator fafafade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Espada");
            StartCoroutine(Fafafafafafade());
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            player.gameObject.GetComponent<PlayerAttack>().enabled = false;
        }
    }

    IEnumerator Fafafafafafade()
    {
        yield return new WaitForSeconds(2f);
        fafafade.SetTrigger("Black");
    }
}
