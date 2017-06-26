using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeRythm : Effect
{
    private float initValue = 0.5f;

    public float actualValue { get; set; }
    public float faderValue { get; set; }
    private CustomArrayList aRythmBox;
    public GameObject rythmObject;
    void Start()
    {
        actualValue = initValue;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + (initValue - 0.5f));
    }

    public override void ApplyEffect(float value)
    {
        aRythmBox = rythmObject.GetComponent<RythmTable>().test;
        if (value != -1) { actualValue = value; }
        foreach (List<GameObject> liste in aRythmBox)
        {
            for (int i = 0; i < aRythmBox.nbElementPerLine; i++)
                liste[i].GetComponent<AudioSource>().volume = 0.5F + gameObject.transform.localPosition.z;
        }

    }
}
