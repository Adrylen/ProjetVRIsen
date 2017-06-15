using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotator : Movable {
    private float yMax = 150.0F;
    private float yMin = -150.0F;
    private Quaternion origin;
    private Vector3 vecTransition;
    private bool locked = false;

    void Start () {
        origin = transform.parent.localRotation;
        vecTransition = transform.parent.localEulerAngles;
    }

    public void Reset() {
        transform.parent.localRotation = Quaternion.Euler(origin.eulerAngles.x, yMin, origin.eulerAngles.z);
    }

    public void Locked(bool locked) {
        this.locked = locked;
    }

    public override void Movement(GameObject controller)
    {
        transform.parent.rotation = controller.transform.rotation;
        if (transform.parent.localRotation != origin)
        {
            float yLoc = transform.parent.localRotation.eulerAngles.y;
            yLoc -= yLoc >= 180 ? 360.0F : 0;
			yLoc = yLoc > yMax ? yMax : yLoc < yMin ? yMin : yLoc;
            transform.parent.localRotation = Quaternion.Euler(vecTransition.x, yLoc, vecTransition.z);
            gameObject.GetComponentInParent<Effect>().ApplyEffect((yLoc - yMin)/ 300.0F);
        }
    }
}

