using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<GameObject> connections;
    [SerializeField] private GameObject panel;
    [SerializeField] private List<GameObject> dials;

    private bool _withinRange = false;

    private List<Vector3> differenceDials = new List<Vector3>();

    private Rigidbody _rb;

    public int _connections = 0;
    public bool _puzzleComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        for (int i = 0; i < dials.Count; i++)
        {
            differenceDials.Add(dials[i].transform.position - transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RobotTarget"))
        {
            _withinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RobotTarget")) _withinRange = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 robotPlayerNormal = Vector3.Normalize(transform.forward);

        for (int i = 0; i < connections.Count; i++)
        {
            if (connections[i].GetComponent<MeshRenderer>().material.color == Color.yellow)
                _connections++;
        }

        if (_connections == 4) _puzzleComplete = true;
        else _connections = 0;

        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));

        _rb.velocity = new Vector3(0, 0, 0);
        _rb.isKinematic = true;

        if (!_withinRange)
        {

            _rb.isKinematic = false;

            _rb.velocity = (transform.forward * 2);
            //Debug.Log("Works");
            //Debug.DrawLine(transform.position, transform.forward);
        }
            panel.transform.position = transform.position + transform.forward / 4.0f;
            panel.transform.eulerAngles = new Vector3(panel.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (_puzzleComplete)
        {
            panel.SetActive(false);
            foreach(GameObject dial in dials)
            {
                dial.SetActive(false);
            }
        }
        //for (int i = 0; i < dials.Count; i++)
        //{

        //    transform.forward.Scale(differenceDials[i]);
        //    dials[i].transform.position = transform.position - differenceDials[i];
        //    dials[i].transform.eulerAngles = new Vector3(dials[i].transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //}

    }
}
