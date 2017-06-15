using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTempoSlider : Effect
{
    private float initValue = 0.5f;
    private float actualGain;

    public float actualValue { get; set; }
    public float faderValue { get; set; }

	public TextMesh text;


    public GameObject rythmtable;

    void Start()
    {
     
    }

    void Update()
    {
    }

    public override void ApplyEffect(float value)
    {
		value = value + 0.2f;
        if (value != -1) { actualValue = value; }
        rythmtable.GetComponent<RythmTable>().changeTempo(actualValue* 0.5f);
		text.text = (int)(1/actualValue*60) + "BPM";
    }
}
