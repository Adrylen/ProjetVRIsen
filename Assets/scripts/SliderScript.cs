using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    Vector3 startSliderButtonPosition = new Vector3(0.0f, 0.0f, 0.0f);
    public float zMax = 0.5F, zMin = -0.5F;
    public float zTest , sliderValue;
    public int count=0;


    void Start()
    {
		startSliderButtonPosition = new Vector3 (0.0f, 0.0f, sliderValue - 0.5f);
        transform.localPosition = startSliderButtonPosition; // Initialisation du bouton
        zTest = transform.localPosition.z;
    }

    void Update()
    {
        
        if (hasMouseMoved() && Input.GetMouseButton(0))
        {
            
            if(zTest <= zMax && Input.GetAxis("Mouse Y") > 0)
            {
                zTest += Input.GetAxis("Mouse Y") * 0.05F;
            }

            if(zTest >= zMin && Input.GetAxis("Mouse Y") < 0)
            {
                zTest += Input.GetAxis("Mouse Y") * 0.05F;
            }
        }
        
        if (zTest > zMax) { zTest = zMax; }
        else if (zTest < zMin) { zTest = zMin; }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zTest);
        zTest = transform.localPosition.z;
        sliderValue = (zTest - zMin);
        gameObject.GetComponent<Effect>().ApplyEffect(sliderValue);

        //Debug.Log("Slider:" +  sliderValue);
        //Debug.Log("zTest:" + zTest);
    }

    bool hasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

}

