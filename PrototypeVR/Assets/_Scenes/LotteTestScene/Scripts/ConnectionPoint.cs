using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    [SerializeField] private GameObject buttonMaterial;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("connection"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.yellow;
            buttonMaterial.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("connection"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.black;
            buttonMaterial.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
