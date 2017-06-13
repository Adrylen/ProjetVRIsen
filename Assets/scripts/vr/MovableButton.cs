using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableButton : Movable {
	public Material active;
	public Material inactive;
	public bool isActive;

	private Vector3 origin;
	private bool outFlag;
    private float base_scale_y;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sharedMaterial = inactive;

		isActive = false;
		outFlag = true;
        base_scale_y = transform.localScale.y;
		origin = transform.localPosition;
	}

    public void Reset()
    {
        isActive = false;
        transform.localScale = new Vector3(transform.localScale.x, base_scale_y, transform.localScale.z);
        GetComponent<Renderer>().sharedMaterial = inactive;
    }

	public override void leaveInput(){
		outFlag = true;
	}

	public override void Movement(GameObject controller) {
		if (outFlag) {
            outFlag = false;
			isActive = !isActive;
		}

		if (isActive) {
            transform.localScale = new Vector3(transform.localScale.x, base_scale_y * 0.8f, transform.localScale.z);
			GetComponent<Renderer>().sharedMaterial = active;
		} else { Reset(); }

		GetComponent<Actions> ().LaunchAction (isActive);

        transform.localPosition = origin;
    }
}
