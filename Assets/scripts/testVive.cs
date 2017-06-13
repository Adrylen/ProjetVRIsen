using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class testVive : MonoBehaviour {
	public TextMesh text;


	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	void Start(){
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	void Update(){
		try{
			device = SteamVR_Controller.Input((int)trackedObject.index);
			if (device.GetAxis ().x != 0 || device.GetAxis ().y != 0) {
				//Debug.Log(device.GetAxis().x + " " + device.GetAxis().y);
				text.text = device.GetAxis ().x + " " + device.GetAxis ().y;
			}
		}catch(Exception e){
			text.text = "vive not detected";
		}
	}
}