using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTempoSlider : Effect
{
    private float initValue = 0.5f;
    private float actualGain;

    public float actualValue { get; set; }
    public float faderValue { get; set; }

    public GameObject rythmtable;

    void Start()
    {
     
    }

    void Update()
    {
    }

    public override void ApplyEffect(float value)
    {
        if (value != -1) { actualValue = value; }
        rythmtable.GetComponent<RythmTable>().changeTempo(actualValue* 0.5f);
        Debug.Log(actualValue);
    }
}
