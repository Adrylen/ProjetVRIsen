using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CDWall : MonoBehaviour {
	public GameObject templateCube;
	public GameObject[] cds; 

	private GameObject wall;
	private Vector3 origin;

	// Use this for initialization
	void Start () {
		DirectoryInfo dir = new DirectoryInfo("assets/sounds");
		FileInfo[] info = dir.GetFiles("*.*");

        //cds = new GameObject[info.Length];
        //wall = transform.root.gameObject;

        //origin = new Vector3 (wall.transform.localPosition.x - wall.transform.localScale.x/2 + templateCd.transform.localScale.x, 
        //			          wall.transform.localPosition.y+wall.transform.localScale.y/2 - templateCd.transform.localScale.y,
        //			          wall.transform.localPosition.z-wall.transform.localScale.z/2);

        ////templateCd.transform.localScale (new Vector3());
        //cds [0] = Instantiate (templateCd);
        //cds [0].transform.Rotate (new Vector3 (90, 0, 0));
        //cds [0].transform.position = origin;
        //cds [0].transform.parent = wall.transform;

        initCdWall(info);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initCdWall (FileInfo[] infos)
    {
        GameObject temp;
        GameObject parentCube = new GameObject();
        Vector3 position;
        int xPos=0, yPos=0;

        for (int i = 0; i< infos.Length; i++)
        {
            if (yPos == 13) { xPos++; }
            yPos = i % 14;
            position = new Vector3((float)xPos * 1.1F,(float)yPos*1.1F, 0);
            temp = (GameObject)Instantiate(templateCube, position, Quaternion.identity,parentCube.transform);
        }

        parentCube.transform.parent = gameObject.transform;
        parentCube.transform.rotation = gameObject.transform.rotation;
        parentCube.transform.position = gameObject.transform.position;
        parentCube.transform.localPosition = new Vector3(-2.2F, 0.1F, 0);
        parentCube.transform.localScale = new Vector3(0.3F, 0.1F, 0.2F);
    }
}
