using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjectOnCollision : MonoBehaviour
{
    public float force;
    GameObject cameraMovable;
    FixedJoint joint;
    void Start()
    {
        cameraMovable = GameObject.FindGameObjectWithTag("MainCamera");
    }
    
    void OnTriggerEnter(Collider col)
    {
        Rigidbody colR = col.GetComponent<Rigidbody>();
        if(col.gameObject.CompareTag("Pickable"))
        {
            Physics.IgnoreCollision(col.GetComponent<Collider>(), GetComponent<Collider>());
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = colR;
            colR.useGravity = false;
            colR.mass = 0;
        }
    }

    // Ajouter RigidBody à la camera & un collider en trigger
    
}
