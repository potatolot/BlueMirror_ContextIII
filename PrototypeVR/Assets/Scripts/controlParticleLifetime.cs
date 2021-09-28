using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class controlParticleLifetime : MonoBehaviour
{
    ParticleSystem waterFalling;

    [SerializeField] GameObject waterPlane;

    [SerializeField] float startLifetimeBegin = 1.46f;
    [SerializeField] float startLifetimeEnd = .4f;
    [SerializeField] float waterPlaneBegin = 0f;
    [SerializeField] float waterPlaneEnd = 4.5f;

    float startLifetimeCalculate;


    // Start is called before the first frame update
    void Start()
    {
        waterFalling = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float waterHeight = waterPlane.transform.position.y;

        startLifetimeCalculate = Mathf.Lerp(startLifetimeBegin, startLifetimeEnd, (waterHeight - waterPlaneBegin) / (waterPlaneEnd - waterPlaneBegin));

        var main = waterFalling.main;
        main.startLifetime = startLifetimeCalculate;
    }
}
