using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrail : MonoBehaviour {
	private GameObject[] trail;
	private GameObject head;

	public int size = 1;
	
	void Awake() {
		size = size > 10 ? 10 : size < 0 ? 0 : size;

		trail = new GameObject[size];
		head = transform.GetChild(0).gameObject;

		for(int i = 0; i < size; ++i) {
			trail[i] = Instantiate(head);
			trail[i].transform.parent = transform;
			trail[i].transform.position = head.transform.position;
			trail[i].transform.localScale *= 0.999f - 0.01f * i;
			trail[i].name = "CubeTrail"+(i+1);

			trail[i].GetComponent<Collider>().isTrigger = false;
			Destroy(trail[i].GetComponent<Rigidbody>());
		}
	}

	void Update() {
		if (!head.transform.position.Equals (trail [trail.Length - 1].transform.position)) {
			Debug.Log ("OK");
			for (int i = trail.Length - 1; i > 0; --i) {
				trail [i].transform.position = trail [i-1].transform.position;
			}
			trail [0].transform.position = head.transform.position;
		}
	}
}
