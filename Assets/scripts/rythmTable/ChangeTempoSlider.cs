﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTempoSlider : Effect
{
	public GameObject rythmtable;
	public TextMesh text;
    public float actualValue { get; set; }
    public float faderValue { get; set; }

    public override void ApplyEffect(float value)
    {
		value += 0.2f;
        if (value != -1) { actualValue = value; }
        rythmtable.GetComponent<RythmTable>().changeTempo(actualValue* 0.5f);
		text.text = (int)(1/actualValue*60) + "BPM";
    }
}
