using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : Movable {
    private Rigidbody rBody;
    private bool active;

    void Start()
    {
        active = false;
        rBody = GetComponent<Rigidbody>();
    }

	void LateUpdate() {
		if (transform.localPosition.y < -15.0f) {
			transform.localPosition = new Vector3(5.3F,2.2F,-1.5F);
		}
	}

    public override void enterInput(Object controller)
    {
        gameObject.tag = "DrumStick";
    }

    public override void leaveInput()
    {
        transform.tag = "Pickable";
    }

    public override void triggerClicked()
    {
        if (active)
        {
            transform.parent = null;
            rBody.useGravity = true;
            rBody.isKinematic = false;
            rBody.freezeRotation = false;
        }
        active = !active;

    }

    public override void Movement(GameObject controller) {
        if (active)
        {
            rBody.velocity = Vector3.zero;
            rBody.freezeRotation = true;
            rBody.useGravity = false;
            rBody.isKinematic = true;
            transform.parent = controller.transform;
            transform.localEulerAngles = new Vector3(90, 0, 0);
            transform.localPosition = new Vector3(0, -0.03F, 0.05F);
        }
    }


    public bool isAlreadyGrabbed() {
        return active;
    }
}
