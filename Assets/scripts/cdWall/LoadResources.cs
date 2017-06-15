using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoadResources : MonoBehaviour {
    public static Dictionary<string, AudioClip> audioFiles;
    public static string[] fileNames;

	public static Dictionary<string, AudioClip> soundFiles;
	public static string[] soundNames;

    private string[] extentions = {
        "*.mp3",
        "*.wav"
    };

	// Use this for initialization
	void Awake () {
        audioFiles = new Dictionary<string, AudioClip>();
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Musics");
        List<FileInfo> info = new List<FileInfo>();
        foreach(string ext in extentions) {
            info.AddRange(dir.GetFiles(ext));
        }

        fileNames = new string[info.Count];
        int i = 0;
        foreach (var file in info.ToArray())
        {
            string fileName = Regex.Replace(file.Name, @".mp3", "");
            fileNames[i++] = fileName;
            audioFiles[fileName] = (AudioClip)Resources.Load("Musics/" + fileName);
        }


		soundFiles = new Dictionary<string, AudioClip>();

		dir = new DirectoryInfo("Assets/Resources/Sounds");
		info = new List<FileInfo>();
		foreach(string ext in extentions) {
			info.AddRange(dir.GetFiles(ext));
		}

		soundNames = new string[info.Count];
		i = 0;
		foreach (var file in info.ToArray())
		{
			string fileName = Regex.Replace(file.Name, @".mp3", "");
			soundNames[i++] = fileName;
			soundFiles[fileName] = (AudioClip)Resources.Load("Sounds/" + fileName);
		}

    }
}
