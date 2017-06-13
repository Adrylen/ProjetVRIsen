using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour {
	public GameObject hand;

	private GameObject grabbedObject = null;
	private Transform objectOrgParent = null;

	void OnCollisionStay(Collision collision) {
		if (Input.GetMouseButton (0) == true) {
			grabbedObject = collision.gameObject;
			grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
			objectOrgParent = grabbedObject.transform.parent;
			grabbedObject.transform.parent = hand.transform;
		}
	}

	void FixedUpdate() {
		if (grabbedObject != null) {
			if (Input.GetMouseButton (0) == false) {
				grabbedObject.transform.parent = objectOrgParent;
				grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
				grabbedObject = null;
			}
		}
	}
}
