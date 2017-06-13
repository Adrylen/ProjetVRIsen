using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCubeRythm : Movable {

    public string filename;
    public Renderer boxMaterial;

    public override void Movement(GameObject controller)
    {
        filename = controller.GetComponent<ControllerCD>().filename;
        boxMaterial = controller.GetComponent<ControllerCD>().boxMaterial;
    }

}
