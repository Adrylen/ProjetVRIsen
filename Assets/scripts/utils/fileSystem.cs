using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class fileSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DirectoryInfo dir = new DirectoryInfo("assets/sounds");
		FileInfo[] info = dir.GetFiles("*.*");
		foreach (FileInfo f in info) {
			Debug.Log (f.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
