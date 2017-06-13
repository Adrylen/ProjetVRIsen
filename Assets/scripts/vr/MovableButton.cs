using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableButton : Movable {
	public bool active;

	private Vector3 origin;
	private bool outFlag;
    private float base_scale_y;

	// Use this for initialization
	void Start () {
		active = false;
		outFlag = true;
        base_scale_y = transform.localScale.y;
		origin = transform.localPosition;
	}

	public override void enterInput(){
	}

	public override void leaveInput(){
		outFlag = true;
	}

	public override void Movement(GameObject controller) {
		if (outFlag) {
            outFlag = false;
			active = !active;
		}

		if (active) {
            transform.localScale = new Vector3(transform.localScale.x, base_scale_y * 0.8f, transform.localScale.z);
		} else {
            transform.localScale = new Vector3(transform.localScale.x, base_scale_y, transform.localScale.z);
		}
		GetComponent<Actions> ().LaunchAction (active);

        transform.localPosition = origin;
    }
}
