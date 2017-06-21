using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Alphabet : MonoBehaviour {
	public List<List<Letter>> list;
	public Alphabet () {

		list = new List<List<Letter>> ();
		
		List<Letter> temp = new List<Letter> ();
		for (int i = 0; i < 20; i++){
			Letter letter = new Letter ();
			letter.x = 5;
			letter.y = 2;
			temp.Add(letter);
		}

		list.Add(temp);
	}
}
