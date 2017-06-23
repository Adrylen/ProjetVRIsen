using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : Movable
{
    private bool placed = false;

    public GameObject parent;
    public Vector3 origin_position;
    public Vector3 origin_scale;
    public string fileName;

	void Start() {}

    void LateUpdate() {
        if(placed && GetComponent<Renderer>().material.shader == ObjectInteraction.outlinedShader) {
            GetComponent<Renderer>().material.shader = ObjectInteraction.standardShader;
        }
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
		transform.GetChild (0).GetComponent<TextMesh>().text = fileName;
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

    public override void enterInput(Object controller) {
        if(((SteamVR_TrackedController)controller).triggerPressed) {
            Detach();
        }
    }

    public override void leaveInput()
    {
        if (!placed)
        {
            //GetComponent<Renderer>().material.shader = ObjectInteraction.standardShader;
            transform.parent = parent.transform;
            transform.localPosition = origin_position;
            transform.localRotation = Quaternion.identity;
            transform.localScale = origin_scale;
        }
    }

    public override void Movement(GameObject controller)
    {
        if(placed) {
            //GetComponent<Renderer>().material.shader = ObjectInteraction.standardShader;
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