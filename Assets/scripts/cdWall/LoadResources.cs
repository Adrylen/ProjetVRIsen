using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoadResources : MonoBehaviour {
    public static Dictionary<string, AudioClip> audioFiles;
    public static string[] fileNames;

	// Use this for initialization
	void Awake () {
        audioFiles = new Dictionary<string, AudioClip>();
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources");
        FileInfo[] info = dir.GetFiles("*.mp3");

        fileNames = new string[info.Length];
        int i = 0;
        foreach (var file in info)
        {
            string fileName = Regex.Replace(file.Name, @".mp3", "");
            fileNames[i++] = fileName;
            audioFiles[fileName] = (AudioClip)Resources.Load(fileName);
        }
    }
}
