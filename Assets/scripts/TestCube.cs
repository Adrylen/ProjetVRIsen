using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour {
	public bool active;

	public Shader shader1;
	public Shader shader2;
	public Renderer rend;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		shader1 = Shader.Find("Standard");
		shader2 = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			rend.material.shader = shader2;
		} else {
			rend.material.shader = shader1;
		}
	}
}
