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
    }

    public bool IsPlaced()
    {
        return placed;
    }

    public void SetPlaced(bool placed)
    {
        this.placed = placed;
    }

    public CD SetParent(GameObject parent) {
        this.parent = parent;
        return this;
    }

    public CD SetFileName(string fileName) {
        this.fileName = fileName;
        return this;
    }

    public CD SetPosition(Vector3 position) {
        origin_position = position;
        return this;
    }

    public CD SetScale(Vector3 scale) {
        origin_scale = scale;
        return this;
    }

    public override void leaveInput()
    {
        if (!placed)
        {
            transform.parent = parent.transform;
            transform.localPosition = origin_position;
            transform.localRotation = Quaternion.identity;
            transform.localScale = origin_scale;
        }
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