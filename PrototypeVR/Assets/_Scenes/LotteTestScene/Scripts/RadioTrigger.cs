using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class RadioTrigger : MonoBehaviour
{
    //  [SerializeField] private XRInputSubsystemDescriptor interactable;
    [SerializeField] Transform playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("radio"))
        {
          //  other.GetComponent("XR Grab Interactable").gameObject.SetActive(false);
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.transform.position = transform.position;
            other.transform.LookAt(new Vector3(playerTransform.position.x, other.transform.position.y, playerTransform.position.z));
            other.transform.parent = transform;
        }
    }
}
