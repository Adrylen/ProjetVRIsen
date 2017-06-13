using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoadResources : MonoBehaviour {
    public static Dictionary<string, AudioClip> audioFiles;

	// Use this for initialization
	void Start () {
        audioFiles = new Dictionary<string, AudioClip>();
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources");
        FileInfo[] info = dir.GetFiles("*.mp3");
        
        foreach (var file in info)
        {
            string fileName = Regex.Replace(file.Name, @".mp3", "");
            audioFiles[fileName] = (AudioClip)Resources.Load(fileName);
        }
    }
}
