using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    Quaternion rotation = Quaternion.Euler(0, 0, 0);
    float y, speedRot = 3.0F, maxRotY = 150.0F, minRotY = -150.0F, rotValue;

    void Start ()
    {
        y = 0.0F;
        transform.parent.localRotation = rotation;
	}
	
	void Update ()
    {
        if(Input.GetMouseButton(0) && mouseHasmoved())
        {
            if(y <= maxRotY && Input.GetAxis("Mouse X")>0)
            {
                y += Input.GetAxis("Mouse X") * speedRot;
            }

            if (y >= minRotY && Input.GetAxis("Mouse X") < 0)
            {
                y += Input.GetAxis("Mouse X") * speedRot;
            }
        }

        if (y > maxRotY) { y = maxRotY; }
        if (y < minRotY) { y = minRotY; }
        transform.parent.localRotation = Quaternion.Euler(0.0F, y, 0.0F);

        rotValue = (y - minRotY ) / 3.0F;
        Debug.Log("RotValue : " + rotValue);
    }

    bool mouseHasmoved()
    {
        return ((Input.GetAxis("Mouse X")!=0) && (Input.GetAxis("Mouse Y") != 0)) ;
    }
}
