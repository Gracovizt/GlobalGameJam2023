using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private GameObject gameManager;

    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public float angularDrag = 0;
    public float fuerza;

    public GameObject pajaroHombro;
    public GameObject pajaroProyectil;
    public bool pajaritoLanzado = false;

    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool canDoubleJump;
    private bool doubleJump;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (!canDoubleJump)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        else
        {
            if (IsGrounded() && !Input.GetButton("Jump"))
            {
                doubleJump = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (IsGrounded() || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                    doubleJump = !doubleJump;
                }
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        // Pajaro
        if (Input.GetButtonDown("Fire2") && IsGrounded() && !pajaritoLanzado)
        {
            pajaritoLanzado = true;

            Instantiate(pajaroProyectil, transform.position, Quaternion.identity);

        }

        else if (Input.GetButtonDown("Fire2") && !IsGrounded() && !pajaritoLanzado)
        {
            pajaritoLanzado = true;
            Instantiate(pajaroProyectil, transform.position, Quaternion.Euler(0f, 0f, 90f));
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            gameManager.gameObject.GetComponent<GameManager>().GameOver();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 newVector = collision.gameObject.transform.position - transform.position;

            if (newVector.x < 0)
            {
                rb.AddForce(new Vector3(1, 1, 0) * fuerza, ForceMode2D.Impulse);
            }

            else
            {
                rb.AddForce(new Vector3(-1, 1, 0) * fuerza, ForceMode2D.Impulse);
            }
            
            gameManager.gameObject.GetComponent<GameManager>().quitarVida();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            gameManager.gameObject.GetComponent<GameManager>().GameOver();
        }
    }
}
