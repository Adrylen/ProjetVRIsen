using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDCharger : MonoBehaviour
{
	public AudioSource sound;
    private string actualFileName = "";
	// Use this for initialization
	void Start()
	{
		//GetComponent<AudioSource>().playOnAwake = false;
		//sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;
	}

	// Mettre un collider sur chacun des objets
	void OnTriggerEnter(Collider other)
	{
		//SteamVR_TrackedController controller = other.GetComponentInParent<SteamVR_TrackedController>();

		if (other.gameObject.CompareTag("Pickable"))
		{
            
            //Debug.Log("collision");
			if (other.GetComponent<CD> () != null && !other.GetComponent<CD>().IsPlaced() && other. GetComponent<CD>().fileName!=actualFileName) {
                CD cd = other.GetComponent<CD>();
                cd.SetPlaced(true);
				cd.transform.parent = this.gameObject.transform;

                cd.transform.position = transform.position;
                cd.transform.rotation = transform.rotation;

                cd.transform.localPosition = new Vector3(0.04f, 1.03f, 0.0f);
                cd.transform.localRotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f));
                cd.transform.localScale = new Vector3(0.55f, 0.55f, 1.0f);

                
                //cd.gameObject.transform.position = this.gameObject.transform.position;
                //            cd.gameObject.transform.rotation = this.gameObject.transform.rotation;
                //            cd.gameObject.transform.localScale = this.gameObject.transform.localScale;

                //AudioClip clip1 = (AudioClip)Resources.Load(other.GetComponent<CD>().fileName);
                //AudioClip clip1 = (AudioClip)Resources.Load(cd.fileName);
                //actualFileName = cd.fileName;
                sound.Stop();
                sound.PlayOneShot(LoadResources.audioFiles[cd.fileName]);

                if(LoadResources.audioFiles[cd.fileName] == null)
                {
                    Debug.Log("Problème chargement cd dans CDCharger");
                }

                other.gameObject.GetComponent<Movable>().Detach();
			}
			//SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)3999);
		}
	}
}
