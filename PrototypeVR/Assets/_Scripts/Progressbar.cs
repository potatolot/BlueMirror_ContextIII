using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{

    public float max;
    public float current;
    public Image mask;



    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float amount = (float)current / (float)max;
        mask.fillAmount = amount;
    }
}
