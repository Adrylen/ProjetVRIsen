using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumLoadFromController : Movable {

	public string filename;
	public Renderer boxMaterial;
	public Color boxColor;


	void Start()
	{
		boxMaterial = gameObject.GetComponent<Renderer>();
		boxColor = boxMaterial.material.color;
	}


	public override void Movement(GameObject controller)
	{
		if(controller.GetComponent<ControllerCD>().filename == "")
		{
			filename = "";
			boxColor = Color.white;
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
			gameObject.GetComponent<AudioSource>().Stop();
		}
		if (filename != controller.GetComponent<ControllerCD>().filename)
		{
			filename = controller.GetComponent<ControllerCD>().filename;
			boxMaterial = controller.GetComponent<ControllerCD>().boxMaterial;
			boxColor = boxMaterial.material.color;
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", boxMaterial.material.color);
		}

	}

}
