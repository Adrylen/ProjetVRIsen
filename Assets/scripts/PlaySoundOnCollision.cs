using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource sound;

	public string filename;
    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        sound = GetComponent<AudioSource>();
    }

    // Mettre un collider sur chacun des objets
    void OnTriggerEnter(Collider test)
    {
        SteamVR_TrackedController controller = test.GetComponentInParent<SteamVR_TrackedController>();
        
        if (test.gameObject.CompareTag("Pickable"))
        {
			//this ray will generate a vector which points from the center of 
			//the falling object TO object hit. You subtract where you want to go from where you are
			
			Ray MyRay = controller.transform.position - transform.position;
			
			//this will declare a variable which will store information about the object hit
			RaycastHit MyRayHit; 
			
			//this is the actual raycast
			Physics.Raycast(MyRay, out MyRayHit);
			
			//this will get the normal of the point hit, if you dont understand what a normal is 
			//wikipedia is your friend, its a simple idea, its a line which is tangent to a plane
			
			Vector3 MyNormal = MyRayHit.normal;

			//this will convert that normal from being relative to global axis to relative to an
			//objects local axis
			
			MyNormal = MyRayHit.transform.TransformDirection(MyNormal);
			
			//this next line will compare the normal hit to the normals of each plane to find the 
			//side hit
			
			if(MyNormal == MyRayHit.transform.up)
			{
				sound.PlayOneShot (LoadResources.soundFiles [filename]);
				SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)3999);
			}
        }
    }
}
