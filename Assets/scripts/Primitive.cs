using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive : MonoBehaviour
{
    private SteamVR_TrackedController controller;
    private GameObject target = null;
    private Vector3 base_offset;
    private Vector3 offset_position;
    private Quaternion offset_rotation;

    void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
    }

    void Start()
    {
        base_offset = new Vector3(-9999, -9999, -9999);
    }

    void Update()
    {
        if (controller.triggerPressed)
        {
            if(target != null) {
                //offset_position = offset_position == base_offset ? target.transform.position : offset_position;
                //offset_rotation = offset_rotation.eulerAngles == base_offset ? target.transform.rotation : offset_rotation;
                target.transform.position = transform.position;// + offset_position;

				Vector3 temp;
				float targetAngle; 
				target.transform.rotation.ToAngleAxis(out targetAngle, out temp);
				float controllerAngle;
				transform.rotation.ToAngleAxis (out controllerAngle, out temp);



				
                target.transform.rotation = transform.rotation;// * offset_rotation;
            } else {
                offset_position = base_offset;
                offset_rotation.eulerAngles = base_offset;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In:" + other.name);
        if (other.name=="Cube" && target == null)
        {
            target = other.gameObject;
            //Debug.Log("In");
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Out:" + other.name);

        if (other.name=="Cube" && target == other.gameObject)
        {
            target = null;
            //Debug.Log("Out");
        }
    }
}
