using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public Progressbar progressbar;
    public Transform slider1;
    public float key1;
    public float max1;

    public float value1;
    public float pos1;

    public Transform slider2;
    public float key2;
    public float max2;

    public float value2;
    public float pos2;

    public Transform slider3;
    public float key3;
    public float max3;

    public float value3;
    public float pos3;

    public float totalvalue;

    void Awake()
    {
        float r = Random.Range(-0.19f, 0.19f);
        slider1.localPosition = new Vector3(slider1.localPosition.x, slider1.localPosition.y, r);
        r = Random.Range(-0.19f, 0.19f);
        slider2.localPosition = new Vector3(slider2.localPosition.x, slider2.localPosition.y, r);
        r = Random.Range(-0.19f, 0.19f);
        slider3.localPosition = new Vector3(slider3.localPosition.x, slider3.localPosition.y, r);
    }
    void Start()
    {
        progressbar.max = 1.0f;

        key1 = 0.0f;
        key2 = 0.15f;
        key3 = -0.15f;

        max1 = Mathf.Abs(0.19f - key1);
        max2 = Mathf.Max(Mathf.Abs(key2 - slider2.TransformPoint(new Vector3(0.0f, 0.0f, 0.19f)).z), Mathf.Abs(key2 - slider2.TransformPoint(new Vector3(0.0f, 0.0f, -0.19f)).z));
        max3 = Mathf.Max(Mathf.Abs(key3 - slider3.TransformPoint(new Vector3(0.0f, 0.0f, 0.19f)).z), Mathf.Abs(key3 - slider3.TransformPoint(new Vector3(0.0f, 0.0f, -0.19f)).z));

        key2 = slider2.TransformPoint(new Vector3(0.0f, 0.0f, key2)).z;
        key3 = slider3.TransformPoint(new Vector3(0.0f, 0.0f, key3)).z;


    }

    void Update()
    {
        CollectData();
        UpdateBar();
    }

    void CollectData()
    {
        pos1 = slider1.TransformPoint(new Vector3(0.0f, 0.0f, slider1.position.z)).z;
        value1 = 1 - (Mathf.Abs(key1 - pos1) / max1);

        pos2 = slider2.TransformPoint(new Vector3(0.0f, 0.0f, slider2.position.z)).z;
        value2 = 1 - (Mathf.Abs(key2 - pos2) / max2);

        pos3 = slider3.TransformPoint(new Vector3(0.0f, 0.0f, slider3.position.z)).z;
        value3 = 1 - (Mathf.Abs(key3 - pos3) / max3);

        totalvalue = (value1 + value2 + value3) / 3;
    }

    void UpdateBar()
    {
        progressbar.current = totalvalue;
    }
}
