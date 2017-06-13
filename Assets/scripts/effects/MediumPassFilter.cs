using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPassFilter : Effect {
	public GameObject highController;
	public GameObject lowController;

	private float initValue = 1000.0f;

	void Start() {
		highController.GetComponent<HighPassFilter> ().SetMinValue(initValue);
		lowController.GetComponent<LowPassFilter> ().SetMaxValue(initValue);
	}

	public override void ApplyEffect (float value)
	{
		highController.GetComponent<HighPassFilter> ().SetMinValue(initValue * Mathf.Pow(2, 1 - 2*value)).ApplyEffect(value);
		lowController.GetComponent<LowPassFilter> ().SetMaxValue(initValue * Mathf.Pow(2, 2*value - 1)).ApplyEffect(value);
	}
}
