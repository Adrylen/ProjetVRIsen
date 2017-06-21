using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource sound;
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
            sound.Play();
            SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)3999);
        }
    }
}
