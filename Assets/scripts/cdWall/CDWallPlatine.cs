using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDWallPlatine : MonoBehaviour {
    public GameObject templateCD;

    private GameObject[,] wall;
    private const int rows = 5;
    private const int cols = 7;

	void Start () {
        wall = new GameObject[rows, cols];
		for(int i = 0; i < LoadResources.audioFiles.Count; ++i)
        {
            CreateCd((int)i / cols, i % cols, i);
        }
	}

    void CreateCd(int y, int x, int i)
    {
        wall[y, x] = Instantiate(templateCD);
        wall[y, x].transform.parent = transform;

        wall[y, x].GetComponent<CD>()
            .SetParent(gameObject)
            .SetFileName(LoadResources.fileNames[i])
            .SetPosition(new Vector3(0.3f * (3 - x), 0.27f * (3 - y) + 0.02f, 0.04f))
            .SetScale(new Vector3(0.15f, 0.15f, 1));

        wall[y, x].transform.localPosition = wall[y, x].GetComponent<CD>().origin_position;
        wall[y, x].transform.localScale = wall[y, x].GetComponent<CD>().origin_scale;
        
    }
}
