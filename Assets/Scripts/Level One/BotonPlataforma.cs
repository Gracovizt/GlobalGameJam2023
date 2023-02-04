using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BotonPlataforma : MonoBehaviour
{
    public GameObject plataforma;
    public GameObject destino;
    public bool isBird;

    // Start is called before the first frame update
    void Start()
    {
        isBird = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer==7)
        {
            if (isBird)
            {
                plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, destino.transform.position, Time.deltaTime * 8);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird") && gameObject.CompareTag("Button"))
        {
            isBird = true;
            CameraShaker.Instance.ShakeOnce(.2f, .2f, .1f, .1f);
            if(gameObject.layer == 8)
            {
                gameObject.GetComponent<PlataformasVuelven>().TimesRunning();
            }
            else if (gameObject.layer == 9)
            {
                gameObject.GetComponent<SpectralBranch>().TimesRunning();
            }
                
        }
    }
}
