using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockSound : Movable {
    public string filename;
    public Renderer boxMaterial;

    public override void Movement(GameObject controller)
    {
        controller.GetComponent<ControllerCD>().filename = filename;
        controller.GetComponent<ControllerCD>().boxMaterial = boxMaterial;
    }

}
