using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : Effect {
    void Start() {
        Reset();
    }

    public void Reset() {
    	transform.localPosition = new Vector3(0.0F , 0.0F , 0.25F);
    	audioSource.pitch = 1;
    }

    public override void ApplyEffect(float value) {
        audioSource.pitch = (value - 0.5F) * 4.0F;
    }
}
