using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBarGraph : MonoBehaviour {

    private int[,] NeonMat = new int[32, 192];
    GameObject neonScene;
    private Renderer[] LightBar;


    void Start()
    {
        
        int i = 1;
        LightBar = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer element in LightBar)
        {
            Debug.Log("Material " + i + ": " + element.ToString());
            element.material.EnableKeyword("_EMISSION");
            element.material.SetColor("_Emission", new Color(1.0F, i*0.1F, 1.0F));
            element.material.SetColor("_Color", new Color(1.0F, i * 0.1F, 1.0F));
            element.material.SetColor("_SpecColor", new Color(1.0F, i * 0.1F, 1.0F));
            if (i == 10) { i = 1; }
            i++;
           
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
