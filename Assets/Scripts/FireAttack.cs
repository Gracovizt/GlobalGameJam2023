using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    GameObject player;
    private bool isLookingForward;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<PlayerMovement>().isFacingRight)
        {
            isLookingForward = true;
        }

        else
        {
            isLookingForward = false;
            Flip();
        }
    }

    void Update()
    {
        if (isLookingForward)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
