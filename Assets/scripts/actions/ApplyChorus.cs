using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyChorus : Actions {
	public GameObject rotator;
	public GameObject wetCube;
	public GameObject optCube;

	// Use this for initialization
	void Start () { Reset(); }

	public void Reset() {
		rotator.GetComponent<Movable> ().Reset ();
		wetCube.GetComponent<Movable> ().Reset ();
		optCube.GetComponent<Movable> ().Reset ();
		
		rotator.GetComponent<Movable> ().Locked (true);
		wetCube.GetComponent<Movable> ().Locked (true);
		optCube.GetComponent<Movable> ().Locked (true);

        audioSource.GetComponent<AudioChorusFilter>().dryMix=1.0F;

        audioSource.GetComponent<AudioChorusFilter> ().delay
			= audioSource.GetComponent<AudioChorusFilter> ().depth
			= audioSource.GetComponent<AudioChorusFilter> ().rate
			= audioSource.GetComponent<AudioChorusFilter> ().wetMix1
			= audioSource.GetComponent<AudioChorusFilter> ().wetMix2
			= audioSource.GetComponent<AudioChorusFilter> ().wetMix3
			= 0.0f;
	}
	
	public override void LaunchAction(bool isActive) {
		if (isActive) {
			rotator.GetComponent<Movable> ().Locked (false);
			wetCube.GetComponent<Movable> ().Locked (false);
			optCube.GetComponent<Movable> ().Locked (false);
		} else {
			Reset ();
		}
	}
}
