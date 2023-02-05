using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JUEGA_YA : MonoBehaviour
{
    public GameObject controles;

    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ControlesMenu()
    {
        controles.SetActive(true);
    }

    public void Back()
    {
        controles.SetActive(false);
    }
}
