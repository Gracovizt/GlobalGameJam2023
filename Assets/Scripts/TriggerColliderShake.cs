using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class TriggerColliderShake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraShaker.Instance.ShakeOnce(.3f, .3f, .1f, .1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CameraShaker.Instance.ShakeOnce(.3f, .3f, .1f, .1f);
    }
}
