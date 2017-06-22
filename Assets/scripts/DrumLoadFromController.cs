using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumLoadFromController : Movable {

	public string filename;
	public Renderer boxMaterial;
	public Color boxColor;


	void Start()
	{
		//boxMaterial = gameObject.GetComponent<Renderer>();
		//boxColor = boxMaterial.material.color;
	}


	public override void Movement(GameObject controller)
	{
		if(controller.GetComponent<ControllerCD>().filename == "")
		{
			filename = "";
		}
		if (filename != controller.GetComponent<ControllerCD>().filename)
		{
            GetComponent<PlaySoundOnCollision>().filename = controller.GetComponent<ControllerCD>().filename;
			filename = controller.GetComponent<ControllerCD>().filename;
            //boxMaterial = controller.GetComponent<ControllerCD>().boxMaterial;
            boxColor = controller.GetComponent<ControllerCD>().boxMaterial.material.color;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", boxColor);
        }

    }

}
