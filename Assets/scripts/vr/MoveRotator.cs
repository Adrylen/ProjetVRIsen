using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotator : Movable {
    private float yMax = 150.0F;
    private float yMin = -150.0F;
    private Quaternion origin;
    private Vector3 vecTransition;

    void Start () {
        origin = transform.parent.localRotation;
        vecTransition = transform.parent.localEulerAngles;
    }

	public void Reset(bool max=false) {
        transform.parent.localRotation = Quaternion.Euler(origin.eulerAngles.x, max ? yMax : yMin, origin.eulerAngles.z);
    }

    public override void Movement(GameObject controller)
    {
        if (!locked)
        {
            transform.parent.rotation = controller.transform.rotation;
            if (transform.parent.localRotation != origin)
            {
                float yLoc = transform.parent.localRotation.eulerAngles.y;
                yLoc -= yLoc >= 180 ? 360.0F : 0;
                yLoc = yLoc > yMax ? yMax : yLoc < yMin ? yMin : yLoc;
                transform.parent.localRotation = Quaternion.Euler(vecTransition.x, yLoc, vecTransition.z);
                gameObject.GetComponentInParent<Effect>().ApplyEffect((yLoc - yMin) / 300.0F);
            }
        }
    }
}

