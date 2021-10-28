using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool DoorOpen;
    public bool radiofixed;
    public Robot robotpuzzle;
    public MapPuzzle mappuzzle;
    public GameObject water;
    public float speed;

    private void Awake()
    {
        DoorOpen = false;
        radiofixed = false;
    }
    private void Update()
    {
        if (radiofixed)
        {
            if(water.transform.localPosition.y < -2.8f)
                water.transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
        }

    }
    public void DoorOpened()
    {
        DoorOpen = true;
        StartCoroutine(robotpuzzle.TurnOn());
    }

    public void RadioFixed()
    {
        mappuzzle.activated = true;

        StartCoroutine(robotpuzzle.RadioOn());
    }
}
