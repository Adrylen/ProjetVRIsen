using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : Movable {
    private Rigidbody rBody;
    private bool active;
	private Vector3 origin_position;

    void Start()
    {
        active = false;
        rBody = GetComponent<Rigidbody>();
		origin_position = transform.localPosition;
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

    //public override void PadClicked()
    //{
    //   rBody.detectCollisions = false;
    //}

    //public override void PadReleased() {
    //    Debug.Log("COUCOU");
    //    rBody.detectCollisions = true;
    //}

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


    public bool isAlreadyGrabbed()
    {
        // return transform.parent.CompareTag("Controller");
        return active;
    }
}
