using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;

public class GameManager : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    public bool isVida;

    public Animator anim;
    public Animator circlel;

    private bool pause;
    public GameObject pauseObj;

    private bool isDead;

    public AudioSource sourceOfAudio;
    public AudioClip hit;
    public AudioClip gameOnBitches;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        pause = false;
        isVida = true;
        healthText.text = "x" + health;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "x" + health;

        if (health <= 0)
        {
            GameOver();
        }

        pauseObj.gameObject.SetActive(pause);

        if (Input.GetButtonDown("Pause"))
        {
            if (!pause)
            {
                pause = true;
                Time.timeScale = 0;
            }

            else
            {
                pause = false;
                Time.timeScale = 1;
            }
        }
    }

    public void quitarVida()
    {
        if (isVida)
        {
            StartCoroutine(CDVida());
        }
    }

    public void GameOver()
    {
        StartCoroutine(DieDieDie());
    }

    IEnumerator CDVida()
    {
            isVida = false;
            sourceOfAudio.PlayOneShot(hit);
            health--;
            anim.SetTrigger("Damage");
            CameraShaker.Instance.ShakeOnce(.5f, .5f, .1f, .1f);
            yield return new WaitForSeconds(0.25f);
            isVida = true;
    }

    IEnumerator DieDieDie()
    {
        if (!isDead)
        {
            isDead = true;
            circlel.SetTrigger("die");
            sourceOfAudio.PlayOneShot(gameOnBitches);
            CameraShaker.Instance.ShakeOnce(.5f, .5f, .1f, .1f);
            yield return new WaitForSeconds(1f);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
