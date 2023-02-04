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

        player.GetComponent<PlayerMovement>().pajaroHombro.SetActive(false);

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
        if (collision.gameObject.layer == 3 || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Pared") || collision.gameObject.layer == 7 || collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            player.GetComponent<PlayerMovement>().pajaritoLanzado = false;
            player.GetComponent<PlayerMovement>().pajaroHombro.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Pared") || collision.gameObject.layer == 7 || collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            player.GetComponent<PlayerMovement>().pajaritoLanzado = false;
            player.GetComponent<PlayerMovement>().pajaroHombro.SetActive(true);
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
