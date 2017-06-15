using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmTable : Movable
{

    private CustomArrayList test = new CustomArrayList();
    public GameObject templateCube;
    public GameObject InteractionButton;
    private Transform buttonTransform;
    private Vector3 origin = new Vector3();
    private int index = 0;
    private float space = 0.3F;

	bool active = false;
	float _tempo;

    // Use this for initialization
    void Start()
    {
        InitRythmBox(test);
        buttonTransform = transform.GetChild(13);
        origin = buttonTransform.transform.localPosition;
		_tempo = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        lineUpdateOnButtonPos(test, buttonTransform);
    }

    public void changeTempo(float tempo)
    {
		if (active) {
			_tempo = tempo;
			CancelInvoke ();
			InvokeRepeating ("tempo", _tempo, _tempo);
		}
    }

    public void StartButton()
    {
		active = true;
        CancelInvoke();
        InvokeRepeating("tempo", 0f, _tempo);
    }

    public void StopButton()
    {
		active = false;

        foreach(List<GameObject> liste in test)
        {
            for(int i=0; i<liste.Count; i++)
            {
                liste[i].GetComponent<AudioSource>().Stop();
            }
        }
        CancelInvoke();
    }

    void tempo()
    {
        Renderer temp;
        foreach(List<GameObject> liste in test)
        {
            for(int i=0; i<liste.Count; i++)
            {
                liste[i].GetComponent<Renderer>().material.SetColor("_Color", liste[i].GetComponent<SoundCubeRythm>().boxColor);
            }
        }
        
        foreach (List<GameObject> liste in test)
        {
            temp = liste[index].GetComponent<Renderer>();
            temp.material.SetColor("_Color", Color.cyan);
            if (liste[index].GetComponent<SoundCubeRythm>().filename != "")
            {
                liste[index].GetComponent<AudioSource>().Stop();
                liste[index].GetComponent<AudioSource>().PlayOneShot(LoadResources.soundFiles[liste[index].GetComponent<SoundCubeRythm>().filename]);
            }
        }
        index++;
        
        if (index >= test.nbElementPerLine) { index = 0; }
    }

    public override void Movement(GameObject controller)
    {
        transform.position = controller.transform.position;
        if (transform.localPosition != origin)
        {
            buttonTransform.transform.localPosition = new Vector3(transform.localPosition.z, transform.localPosition.y, origin.z);
        }

    }


    void InitRythmBox(CustomArrayList aRythmBox)
    {
        GameObject temp = new GameObject();
        Vector3 tempPosition;

        float xPos, yPos;

        List<GameObject> newList1 = new List<GameObject>();
        List<GameObject> newList2 = new List<GameObject>();
        List<GameObject> newList3 = new List<GameObject>();

        // Set the default model configuration

        aRythmBox.nbElementPerLine = 4;
        aRythmBox.nbLine = 3;

        // Horizontal line creation

        aRythmBox.Add(newList1);
        aRythmBox.Add(newList2);
        aRythmBox.Add(newList3);

        yPos = 0;
        xPos = 0;

        // Cube filling

        foreach (List<GameObject> element in aRythmBox)
        {
            for (int i = 0; i < aRythmBox.nbElementPerLine; i++)
            {
                tempPosition = new Vector3(((space+1) * i), yPos, 0);
                element.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
            }
            yPos -= (space+1);
            xPos = gameObject.transform.localPosition.x;
        }

        // Rotation adaptation

        temp.transform.localScale = transform.localScale;
        temp.transform.rotation = transform.rotation;
        temp.transform.localPosition = transform.position;
        temp.transform.parent = transform;

        // Moving children to root of the gameobject

        for (int i = temp.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = temp.transform.GetChild(i);
            child.transform.parent = gameObject.transform;
        }

        // Removing Object for Rotation

        Destroy(temp);

        // Interaction button generation & placement
        tempPosition = new Vector3(0, 0, 0);
        temp = (GameObject)Instantiate(InteractionButton, tempPosition, Quaternion.identity, gameObject.transform);
        temp.transform.rotation = transform.rotation;
        tempPosition = new Vector3((space+1) * aRythmBox.nbElementPerLine, -(space+1) * aRythmBox.nbLine, 0);
        temp.transform.localPosition = tempPosition;
    }


    void addRows(CustomArrayList aRythmBox)
    {
        float xPos, yPos;
        GameObject temp = new GameObject();
        yPos = 0;

        // Updating aRythmBox columnn number

        xPos = (space+1) * aRythmBox.nbElementPerLine;
        aRythmBox.nbElementPerLine++;

        // Cube filling

        foreach (List<GameObject> element in aRythmBox)
        {
            Vector3 tempPosition = new Vector3(xPos, yPos, 0.0f);
            element.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
            yPos -= (space+1);
        }

        // Rotation adaptation

        temp.transform.localScale = transform.localScale;
        temp.transform.rotation = transform.rotation;
        temp.transform.localPosition = transform.position;
        temp.transform.parent = transform;


        // Moving children to root of the gameobject

        for (int i = temp.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = temp.transform.GetChild(i);
            child.transform.parent = gameObject.transform;
        }

        // Removing Object for Rotation

        Destroy(temp);

    }

    void addLine(CustomArrayList aRythmBox)
    {
        List<GameObject> newList = new List<GameObject>();
        GameObject temp = new GameObject();
        Vector3 tempPosition;
        float yPos, xPos;
        yPos = -(space+1) * aRythmBox.nbLine;
        xPos = 0;

        aRythmBox.Add(newList);
        aRythmBox.nbLine++;

        for (int i = 0; i < aRythmBox.nbElementPerLine; i++)
        {
            tempPosition = new Vector3(xPos + ((space+1) * i), yPos, 0);
            newList.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
        }

        // Rotation adaptation

        temp.transform.localScale = transform.localScale;
        temp.transform.rotation = transform.rotation;
        temp.transform.localPosition = transform.position;
        temp.transform.parent = transform;


        // Moving children to root of the gameobject

        for (int i = temp.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = temp.transform.GetChild(i);
            child.transform.parent = gameObject.transform;
        }

        // Removing Object for Rotation

        Destroy(temp);
    }

    void removeRow(CustomArrayList aRythmBox)
    {
        GameObject temp;

        // removing last cube for each horizontal line
        if (aRythmBox.nbElementPerLine > 1)
        {
            foreach (List<GameObject> aList in aRythmBox)
            {
                temp = aList[aList.Count - 1];
                aList.RemoveAt(aList.Count - 1);
                Destroy(temp);
            }
            // updating rows numbers
            aRythmBox.nbElementPerLine--;
        }

        index = 0;

    }

    void removeLine(CustomArrayList aRythmBox)
    {
        if (aRythmBox.nbLine > 1)
        {
            List<GameObject> tempList = (List<GameObject>)aRythmBox[aRythmBox.nbLine - 1];

            foreach (GameObject element in tempList)
            {
                Destroy(element);
            }
            tempList.Clear();
            aRythmBox.RemoveAt(aRythmBox.nbLine - 1);
            aRythmBox.nbLine--;
        }
        index = 0;
    }

    void lineUpdateOnButtonPos(CustomArrayList aRythmBox, Transform aButton)
    {
        if (aButton.transform.localPosition.x > (aRythmBox.nbElementPerLine + 1) * (space + 1)) { addRows(aRythmBox); }
        if (aButton.transform.localPosition.x < (aRythmBox.nbElementPerLine - 1) * (space + 1)) { removeRow(aRythmBox); }
        if (aButton.transform.localPosition.y < -(aRythmBox.nbLine + 1) * (space + 1)) { addLine(aRythmBox); }
        if (aButton.transform.localPosition.y > -(aRythmBox.nbLine - 1) * (space + 1)) { removeLine(aRythmBox); }
    }
}
