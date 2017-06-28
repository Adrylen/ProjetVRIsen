using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource sound;
    private SteamVR_TrackedController controller;

    public string filename;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        if(filename != "")
        {
            GetComponent<AudioSource>().clip = LoadResources.soundFiles[filename];
        }
    }

    void Vibration()
    {
        SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)3999);
    }


    // Mettre un collider sur chacun des objets
    void OnTriggerEnter(Collider test)
    {
        controller = test.GetComponentInParent<SteamVR_TrackedController>();
        
        if (test.gameObject.CompareTag("Pickable"))
        {
            GetComponent<AudioSource>().PlayOneShot(LoadResources.soundFiles[filename]);
            if (controller != null)
            {
                Invoke("Vibration", 0.2f);
            }
        }
    }
}
