using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouseMove : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float verticalSpeed;
    private float h = 0.0F, y=0.0F;

    void LateUpdate()
    {
        // Vertical translations

        if (Input.GetKey(KeyCode.A)) transform.Translate(new Vector3(0.0f, -verticalSpeed, 0.0f));
        if (Input.GetKey(KeyCode.E)) transform.Translate(new Vector3(0.0f, verticalSpeed, 0.0f));

        // Camera Rotation

        if(hasMouseMoved())
        {
			h +=Input.GetAxis("Mouse X") * rotationSpeed;
			y -= Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.eulerAngles = new Vector3(y, h, 0.0F);
        }

        // Movement

        if (Input.GetKey(KeyCode.Z)) transform.Translate(0.0f, 0.0f, movementSpeed);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0.0f, 0.0f, -movementSpeed);
        if (Input.GetKey(KeyCode.D)) transform.Translate(movementSpeed, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.Q)) transform.Translate(-movementSpeed, 0.0f, 0.0f);
            
    }

    bool hasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }
}
