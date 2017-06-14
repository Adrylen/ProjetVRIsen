using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gain : Effect {
	public float maximum = 1.0f;

	public override void ApplyEffect(float value){
        maximum = Mathf.Pow(10.0f, (value * 24.0f - 12.0f) / 10.0f);
    }
}
