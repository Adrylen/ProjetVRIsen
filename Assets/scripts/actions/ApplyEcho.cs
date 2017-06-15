using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyEcho : Actions {
	public GameObject cursor;
	public GameObject slider;

	void Start () { Reset(); }

	public void Reset() {
		cursor.GetComponent<Movable> ().Reset ();
		slider.GetComponent<Movable> ().Reset ();

		cursor.GetComponent<Movable> ().Locked (true);
		slider.GetComponent<Movable> ().Locked (true);

		audioSource.GetComponent<AudioEchoFilter> ().delay = 10.0f;
		audioSource.GetComponent<AudioEchoFilter> ().decayRatio = 0.0f;
		audioSource.GetComponent<AudioEchoFilter> ().enabled = false;
	}
	
	public override void LaunchAction(bool isActive) {
		if (isActive) {
			cursor.GetComponent<Movable> ().Locked (false);
			slider.GetComponent<Movable> ().Locked (false);
			audioSource.GetComponent<AudioEchoFilter> ().enabled = true;
		} else {
			Reset ();
		}
	}
}
