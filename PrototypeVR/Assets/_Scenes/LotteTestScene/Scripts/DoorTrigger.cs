using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator doorAnimation;
    public GameObject sound;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("heavyObject"))
        {
            doorAnimation.SetTrigger("DoorOpens");
            sound.SetActive(false);
        }
    }
}
