using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : Effect {
    void Start() {
        transform.localPosition = new Vector3(0.0F , 0.0F , 0.25F);
    }
    public override void ApplyEffect(float value) {
        audioSource.pitch = (value - 0.5F) * 4.0F;
    }
}
