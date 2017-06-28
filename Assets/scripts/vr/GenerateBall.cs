using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBall : MonoBehaviour {
    private bool pressed = false;
	void Update () {
		if(GetComponent<SteamVR_TrackedController>().triggerPressed)
        {
            if(!pressed)
            {
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ball.transform.position = transform.position;
                ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                ball.AddComponent<Rigidbody>();
                pressed = true;
            }
        } else
        {
            pressed = false;
        }
	}
}
