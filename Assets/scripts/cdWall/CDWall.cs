using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CDWall : MonoBehaviour {
	public GameObject templateCd;
	public GameObject[] cds; 

	private GameObject wall;
	private Vector3 origin;

	// Use this for initialization
	void Start () {
		DirectoryInfo dir = new DirectoryInfo("assets/sounds");
		FileInfo[] info = dir.GetFiles("*.*");

		cds = new GameObject[info.Length];
		wall = transform.root.gameObject;

		origin = new Vector3 (wall.transform.localPosition.x - wall.transform.localScale.x/2 + templateCd.transform.localScale.x, 
					          wall.transform.localPosition.y+wall.transform.localScale.y/2 - templateCd.transform.localScale.y,
					          wall.transform.localPosition.z-wall.transform.localScale.z/2);
		
		//templateCd.transform.localScale (new Vector3());
		cds [0] = Instantiate (templateCd);
		cds [0].transform.Rotate (new Vector3 (90, 0, 0));
		cds [0].transform.position = origin;
		cds [0].transform.parent = wall.transform;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
