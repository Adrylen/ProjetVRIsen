using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : Movable
{
    private Transform origin;
    private bool placed = false;

    public GameObject parent;
    public Vector3 origin_position;
    public Vector3 origin_scale;
    public string fileName;

	void Start() {
        origin = gameObject.transform;
        Debug.Log("Position : " + origin.position.x + "/" + origin.position.y + "/" + origin.position.z);
    }

	public bool IsPlaced(){
		return placed;
	}

    public void SetPlaced(bool placed)
    {
        this.placed = placed;
    }

    public CD SetParent(GameObject parent) {
        return this;
    }

    public CD SetFileName(string fileName) {
        return this;
    }

    public CD SetPosition(Vector3 position)
    {
        return this;
    }

    public CD SetRotation(Quaternion rotation)
    {
        return this;
    }

    public override void Movement(GameObject controller)
    {
        if(placed) {
            transform.parent = parent.transform;
            transform.localPosition = origin_position;
            transform.localRotation = Quaternion.identity;
            transform.localScale = origin_scale;
            placed = false;
            Detach();
        } else {
            base.Movement(controller);
        }
    }
}