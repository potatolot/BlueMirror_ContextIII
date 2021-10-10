using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float launchForce = 10.0f;
    private Rigidbody Body;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    public void Launch()
    {
        Body.AddRelativeForce(Vector3.forward * launchForce, ForceMode.Impulse);
        Destroy(gameObject, 5.0f);
    }
}
