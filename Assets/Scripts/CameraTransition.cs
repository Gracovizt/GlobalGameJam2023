using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class CameraTransition : MonoBehaviour
{

    public CinemachineVirtualCamera CamClose;
    
    

    IEnumerator ZoomOut()
    {
        CamClose.Priority = 8;
        yield return new WaitForSeconds(4);
        CamClose.Priority = 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            StartCoroutine(ZoomOut()); 
        }
    }
}
