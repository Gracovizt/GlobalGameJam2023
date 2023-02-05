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

    // Start is called before the first frame update
    void Start()
    {
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator CDVida()
    {
        isVida = false;
        health--;
        anim.SetTrigger("Damage");
        CameraShaker.Instance.ShakeOnce(.5f, .5f, .1f, .1f);
        yield return new WaitForSeconds(0.25f);
        isVida = true;
    }
}
