using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScrollText : MonoBehaviour {
	private TextMesh text;

	private int index;
	private int length;
	public int maxLetters;
	private char[] baseString;

	public static char[] SubArray(char[] data, int index, int length)
	{
		char[] result = new char[length];
		Array.Copy(data, index, result, 0, length);
		return result;
	}

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
		baseString = text.text.ToCharArray();
		length = baseString.Length;
		InvokeRepeating ("UpdateText", 0.0f, 0.5f);
	}


	void UpdateText(){
        //text.text = baseString [index % length].ToString();

        if (maxLetters < length)
        {
            text.text = new string(SubArray(baseString, index, maxLetters));
            index++;
            if ((index + maxLetters) >= length + 1)
            {
                index = 0;
            }
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
