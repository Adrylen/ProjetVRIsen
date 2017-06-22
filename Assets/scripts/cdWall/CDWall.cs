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
        initCdWall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initCdWall ()
    {
        GameObject temp;
        GameObject parentCube = new GameObject();
        Renderer tempColor;
        int[] tempArray;
        Vector3 position;
        float xPos=0, yPos=0;
        

        for (int i = 0; i< LoadResources.soundNames.Length; i++)
        {
            xPos = i / 10;
            yPos = (i % 10) + 0.1f;

            position = new Vector3((float)xPos * 1.5F,(float)yPos*1.5F, 0);
            temp = (GameObject)Instantiate(templateCube, position, Quaternion.identity,parentCube.transform);
			temp.GetComponentInChildren<TextMesh>().text = LoadResources.soundNames[i];
            tempColor=temp.GetComponent<Renderer>();
			tempArray = StringTransform.TransformColor(LoadResources.soundNames[i]);
            tempColor.material.SetColor("_Color", new Color((float)tempArray[0]/255, (float)tempArray[1]/255, (float)tempArray[2]/255));
            temp.GetComponent<StockSound>().filename = LoadResources.soundNames[i];
            temp.GetComponent<StockSound>().boxMaterial = tempColor;
        }

        parentCube.transform.name = "Sound Library";
        parentCube.transform.parent = gameObject.transform;
        parentCube.transform.rotation = gameObject.transform.rotation;
        parentCube.transform.position = gameObject.transform.position;
        parentCube.transform.localPosition = new Vector3(-2.2F, 0.1F, 0);
        parentCube.transform.localScale = new Vector3(0.3F, 0.1F, 0.2F);
    }
}
