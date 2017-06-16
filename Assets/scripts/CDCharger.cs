using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDCharger : MonoBehaviour
{
	public AudioSource sound;
    public GameObject playControl;
    public GameObject loopControl;
    private string actualFileName = "";

	// Use this for initialization
	void Start()
	{
        sound.playOnAwake = false;
	}

    void Update()
    {
        if(transform.childCount == 0) {
            if(sound.isPlaying) { sound.Stop(); }
			ResetButtons ();
        }
    }

	private void ResetButtons() {
		playControl.GetComponent<MovableButton>().Reset();
		loopControl.GetComponent<MovableButton>().Reset();
		playControl.GetComponent<PlayAudio>().launched = false;
		loopControl.GetComponent<LoopAction>().audioSource.loop = false;
	}

	// Mettre un collider sur chacun des objets
	void OnTriggerEnter(Collider other)
	{
		//SteamVR_TrackedController controller = other.GetComponentInParent<SteamVR_TrackedController>();

		if (other.gameObject.CompareTag("Pickable"))
		{
            
            //Debug.Log("collision");
			if (other.GetComponent<CD> () != null && !other.GetComponent<CD>().IsPlaced() && other. GetComponent<CD>().fileName!=actualFileName) {
                // Eject previous CD
                if(GetComponentInChildren<CD>() != null) {
                    GetComponentInChildren<CD>().Movement(null);
                }
                
                // Place the CD
                CD cd = other.GetComponent<CD>();
                cd.SetPlaced(true);
				cd.transform.parent = this.gameObject.transform;

                // Transform of CD
                cd.transform.position = transform.position;
                cd.transform.rotation = transform.rotation;

                cd.transform.localPosition = new Vector3(0.04f, 1.03f, 0.0f);
                cd.transform.localRotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f));
                cd.transform.localScale = new Vector3(0.55f, 0.55f, 1.0f);

                // Sound Manager
				ResetButtons();
                sound.clip = LoadResources.audioFiles[cd.fileName];

                if(LoadResources.audioFiles[cd.fileName] == null) {
                    Debug.Log("Problème chargement cd dans CDCharger");
                }

                // Out of control
                other.gameObject.GetComponent<Movable>().Detach();
			}
			//SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)3999);
		}
	}
}
