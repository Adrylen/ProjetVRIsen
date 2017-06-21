using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadJSON : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Alphabet alphabet = new Alphabet ();
		string json = JsonUtility.ToJson(alphabet);
		
		Debug.Log (alphabet.list[0].Count);
		Debug.Log (json);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
