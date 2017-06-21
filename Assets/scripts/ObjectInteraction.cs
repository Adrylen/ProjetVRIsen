using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
	private SteamVR_TrackedController controller;
	private GameObject target = null;
    private bool isClicked = false;
    public int pulsation = 900;
    private Shader shader1;
    private Shader shader2;

    void OnEnable() {
		controller = GetComponent<SteamVR_TrackedController>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
    }

	void Update() {
        if (controller.gripped)
        {
            if(controller.transform.childCount>1)
            {
                controller.GetComponent<ControllerCD>().Reset();
                Destroy(controller.transform.GetChild(1).gameObject);
            }
        }

        // Trigger pressed
		if (controller.triggerPressed) {
            // Has target
			if(target != null) {
                // Is movable
                if(target.GetComponent<Movable>() != null) {
                    if (!isClicked) {
                        target.GetComponent<Movable>().triggerClicked();
                        isClicked = true;
                    }
                    target.GetComponent<Movable>().Movement(gameObject);
                }
            }
		} else {
            isClicked = false;
            if(target != null) {
                if (target.GetComponent<Movable>() != null) {
                    target.GetComponent<Movable>().leaveInput();
                }
            }
        }
	}

	void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Pickable") && target == null) {
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.shader = shader2;
            }
            SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)pulsation);
            target = other.gameObject;
            if (target.GetComponent<Movable>() != null) {
                target.GetComponent<Movable>().enterInput(controller);
            }
		}
        if(other.gameObject.CompareTag("DrumStick") && target == null) {
            if(!other.gameObject.GetComponent<DrumStick>().isAlreadyGrabbed()) {
                target = other.gameObject;
            }
        }
	}
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable") && target == other.gameObject)
        {
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.shader = shader1;
            }
            if (target.GetComponent<Movable>() != null)
            {
                target.GetComponent<Movable>().leaveInput();
            }
            target = null;
        }
        if (other.gameObject.CompareTag("DrumStick") && target == other.gameObject){
            if (!other.gameObject.GetComponent<DrumStick>().isAlreadyGrabbed()){
                if (target.GetComponent<Movable>() != null)
                {
                    target.GetComponent<Movable>().leaveInput();
                }
                target = null;
            }
        }
    }

    public void Detach()
    {
        target = null;
    }
}
