using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaritoMovement : MonoBehaviour
{
    GameObject player;
    private bool isLookingForward;
    private bool isFlying;
    public float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<PlayerMovement>().IsGrounded())
        {
            isFlying = false;

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

        else
        {
            isFlying = true;
        }
    }

    void Update()
    {
        if (!isFlying)
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

        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            player.GetComponent<PlayerMovement>().pajaritoLanzado = false;
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
