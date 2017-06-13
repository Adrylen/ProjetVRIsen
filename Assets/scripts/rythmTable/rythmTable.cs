using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rythmTable : MonoBehaviour {

    CustomArrayList test = new CustomArrayList();
    public GameObject templateCube;
    Vector3 origin = new Vector3();

    // Use this for initialization
    void Start() {
        origin = transform.localPosition;
        InitRythmBox(test);
        addRows(test);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1))
        {
            addRows(test);
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

        yPos = gameObject.transform.localPosition.y;
        xPos = gameObject.transform.localPosition.x;

        // Cube filling

        foreach (List<GameObject> element in aRythmBox)
        {
            for (int i = 0; i < aRythmBox.nbElementPerLine; i++)
            {
                tempPosition = new Vector3(xPos + transform.localScale.x * (1.1f * i), yPos, transform.localPosition.z);
                element.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
            }
            yPos += transform.localScale.y * (1.1F);
            xPos = gameObject.transform.localPosition.x;
        }

        // Rotation adaptation

        temp.transform.rotation = transform.rotation;
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


    void addRows (CustomArrayList aRythmBox)
    {
        float xPos, yPos;
        GameObject temp = new GameObject();
        yPos = gameObject.transform.position.y;

        // Updating aRythmBox columnn number
      
        xPos = gameObject.transform.position.x + transform.localScale.x * (1.1F) * aRythmBox.nbElementPerLine;
        aRythmBox.nbElementPerLine++;

        // Cube filling

        foreach (List<GameObject> element in aRythmBox)
        {
            Vector3 tempPosition = new Vector3(xPos, yPos, transform.position.z);
            element.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
            yPos += transform.localScale.y * (1.1F);
        }

        // Rotation adaptation

        temp.transform.rotation = transform.rotation;
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
}
