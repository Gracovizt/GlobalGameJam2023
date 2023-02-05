using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attack;
    public GameObject fuegoProyectil;

    public bool isAttacking;

    public Animator anim;

    private void Start()
    {
        attack.SetActive(false);
        isAttacking = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && !isAttacking)
        {
            anim.SetTrigger("Attack");
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        attack.SetActive(true);
        isAttacking = true;
        Instantiate(fuegoProyectil, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        attack.SetActive(false);
        isAttacking = false;
    }
}
