using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float sqrDistance;
    private float trackingDistance;
    private SphereCollider collider;
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        sqrDistance = (player.transform.position - transform.position).sqrMagnitude;
        trackingDistance = 1;
        collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        sqrDistance = (player.transform.position - transform.position).sqrMagnitude;
        if (sqrDistance >= trackingDistance && collided)
        {
            Vector3 direction = player.transform.position - transform.position;
            transform.Translate(new Vector3(direction.x, 0.0f, direction.z) * speed * Time.deltaTime);
        }

    }

    public void OnCollisionEnter()
    {
        collided = true;
    }

    public void OnCollisionExit()
    {
        collided = false;
    }
}
