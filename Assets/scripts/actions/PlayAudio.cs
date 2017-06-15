using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : Actions {
    public bool launched = false;

	public override void LaunchAction (bool isActive)
	{
		if (isActive) {
			if(launched) {
                audioSource.UnPause();
				if (!audioSource.isPlaying) {
					audioSource.Play ();
				}
            } else {
                audioSource.Play();
                launched = true;
            }
		} else {
			audioSource.Pause ();
		}
	}
}
