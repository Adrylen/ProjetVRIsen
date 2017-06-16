using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockSound : Movable {
    public string filename;
    public Renderer boxMaterial;
    public Color boxColor;
    private GameObject cube;

    void Start()
    {
        boxColor = GetComponent<Renderer>().material.color;
    }


	void OnTriggerEnter(Collider other) {
		GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().PlayOneShot (LoadResources.audioFiles[filename]);
	}

	void OnTriggerExit(Collider other){
		GetComponent<AudioSource> ().Stop ();
	}

    public override void Movement(GameObject controller)
    {
        controller.GetComponent<ControllerCD>().filename = filename;
        controller.GetComponent<ControllerCD>().boxMaterial = boxMaterial;

            if (controller.transform.childCount < 2)
            {
            cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cube.transform.position = controller.transform.position;
            cube.transform.parent = controller.transform;
            cube.transform.localScale = new Vector3(0.03F, 0.03F, 0.03F);
            cube.transform.localPosition= new Vector3(0.0f, -0.08f, 0.04F);
            }

            controller.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_Color", boxColor);
        }

}
