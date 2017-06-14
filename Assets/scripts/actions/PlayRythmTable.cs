using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRythmTable : Actions
{
    public bool launched = false;
    public GameObject rythmTable;
    public override void LaunchAction(bool isActive)
    {
        if (isActive && !launched)
        {
            launched = true;
            rythmTable.GetComponent<RythmTable>().StartButton();
        }
        else
        {
            
        }
    }
}
