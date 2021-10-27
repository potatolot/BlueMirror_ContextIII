using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator doorAnimation;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("heavyObject")) doorAnimation.SetTrigger("DoorOpens");
    }
}
