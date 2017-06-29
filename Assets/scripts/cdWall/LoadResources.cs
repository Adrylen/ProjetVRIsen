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
	void Start () {
        audioFiles = new Dictionary<string, AudioClip>();
        string directory;
        DirectoryInfo dir;

        #if UNITY_STANDALONE_WIN
        Debug.Log("Build");
        directory = "IsenBoxVR_Data/Assets/Resources/";
        #endif
        #if UNITY_EDITOR
        Debug.Log("Editor");
        directory = "Assets/Resources/";
        #endif

        dir = new DirectoryInfo(directory+"Musics/");
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
		dir = new DirectoryInfo(directory+"Sounds");
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
