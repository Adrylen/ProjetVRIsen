using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTestParent : MonoBehaviour {
    GameObject ground;
	// Use this for initialization
	void Start () {
        ground = GameObject.FindGameObjectWithTag("test");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)){
            transform.parent = ground.transform;
        }
	}
}
