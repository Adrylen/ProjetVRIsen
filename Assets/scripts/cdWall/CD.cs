using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : Movable
{
    private Transform origin;
    private bool placed = false;
	public string fileName;

	void Start() {
        origin = gameObject.transform;
        Debug.Log("Position : " + origin.position.x + "/" + origin.position.y + "/" + origin.position.z);
    }

    public Transform GetOrigin()
    {
        return origin;
    }

    public bool IsPlaced()
    {
        return placed;
    }

    public void SetPlaced(bool placed)
    {
        this.placed = placed;
    }

    public override void Movement(GameObject controller)
    {
        base.Movement(controller);
        if(placed)
        {
            Debug.Log("Position : " + origin.position.x + "/" + origin.position.y + "/" + origin.position.z);
            transform.parent = null;
            transform.SetPositionAndRotation(origin.position, origin.rotation);
            //transform.position = origin.position;
            //transform.rotation = origin.rotation;
            //transform.localPosition = origin.localPosition;
            //transform.localRotation = origin.localRotation;
            transform.localScale = origin.localScale;
            placed = false;
            Detach();
        }
    }

    //public override void triggerClicked()
    //{
    //    if(placed == true) {
    //        gameObject.transform.position = origin.position;
    //        gameObject.transform.rotation = origin.rotation;
    //        //placed = false;
    //        Detach();
    //    }
    //}
}