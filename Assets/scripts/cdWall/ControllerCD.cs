﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCD : MonoBehaviour {

    public string filename;
    public Renderer boxMaterial;

    public void Reset()
    {
        boxMaterial = gameObject.GetComponent<Renderer>();
        filename = "";
    }
}
