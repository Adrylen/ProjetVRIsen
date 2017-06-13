using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTransform : MonoBehaviour {
	
	public static int[] Transform(string toTransform){
		return intToRGBArray (hashCode (toTransform));
	}


	public static int[] intToRGBArray(int i){
		int [] colorArray = new int[3];
		i = Mathf.Abs(i);

		colorArray[0] = (i/255)%255;
		i = i/255;
		colorArray[1] = (i/255)%255;
		i = i/255;
		colorArray[2] = (i/255)%255;

		return colorArray;

	}
	public static int hashCode(string str){
		var hash = 0;
		for (var i = 0; i < str.Length; i++) {
			hash = str[i] + ((hash << 6) - hash);
		}
		return hash;
	}


}
