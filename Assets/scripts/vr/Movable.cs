﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
    private GameObject controller;
    private Vector3 offsetPosition;
	protected bool locked = false;

    void Start()
    {
        offsetPosition = Vector3.zero;
    }

	public virtual void Locked(bool locked) {
		this.locked = locked;
	}

    public virtual void Movement(GameObject controller)
    {
        this.controller = controller;
        if(offsetPosition.Equals(Vector3.zero))
        {
            offsetPosition = transform.position - controller.transform.position;
        }

        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;
    }

    public virtual void Detach()
    {
        if(this.controller != null)
        {
            controller.GetComponent<ObjectInteraction>().Detach();
        }
    }

    public virtual void leaveInput()
    {
        offsetPosition = Vector3.zero;
    }

	public virtual void Reset() {}
    public virtual void Movement(Object controller) { }
    public virtual void enterInput(Object controller) { }
    public virtual void triggerClicked() { }
    public virtual void PadClicked() { }
    public virtual void PadReleased() { }
}
