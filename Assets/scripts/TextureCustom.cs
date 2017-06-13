using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCustom : MonoBehaviour {
	void Start () {
		gameObject.GetComponent<MeshFilter>().mesh.vertices = new Vector3[] {
			new Vector3(-0.5f,-0.5f,-0.5f),new Vector3(-0.5f, 0.5f,-0.5f),new Vector3( 0.5f, 0.5f,-0.5f),new Vector3( 0.5f,-0.5f,-0.5f),	//front
			new Vector3( 0.5f,-0.5f, 0.5f),new Vector3( 0.5f, 0.5f, 0.5f),new Vector3(-0.5f, 0.5f, 0.5f),new Vector3(-0.5f,-0.5f, 0.5f),	//back
			new Vector3( 0.5f,-0.5f,-0.5f),new Vector3( 0.5f, 0.5f,-0.5f),new Vector3( 0.5f, 0.5f, 0.5f),new Vector3( 0.5f,-0.5f, 0.5f),	//right
			new Vector3(-0.5f,-0.5f, 0.5f),new Vector3(-0.5f, 0.5f, 0.5f),new Vector3(-0.5f, 0.5f,-0.5f),new Vector3(-0.5f,-0.5f,-0.5f),	//left
			new Vector3(-0.5f, 0.5f,-0.5f),new Vector3(-0.5f, 0.5f, 0.5f),new Vector3( 0.5f, 0.5f, 0.5f),new Vector3( 0.5f, 0.5f,-0.5f),	//top
			new Vector3(-0.5f,-0.5f,-0.5f),new Vector3(-0.5f,-0.5f, 0.5f),new Vector3( 0.5f,-0.5f, 0.5f),new Vector3( 0.5f,-0.5f,-0.5f)		//bottom
		};
		gameObject.GetComponent<MeshFilter>().mesh.uv = new Vector2[] {
			new Vector2(0.000f,0.500f),new Vector2(0.333f,0.500f),new Vector2(0.333f,1.000f),new Vector2 (0.000f,1.000f),	// front
			new Vector2(0.667f,0.500f),new Vector2(1.000f,0.500f),new Vector2(1.000f,1.000f),new Vector2 (0.667f,1.000f),	// back
			new Vector2(0.667f,0.000f),new Vector2(1.000f,0.000f),new Vector2(1.000f,0.500f),new Vector2 (0.667f,0.500f),	// right
			new Vector2(0.000f,0.000f),new Vector2(0.333f,0.000f),new Vector2(0.333f,0.500f),new Vector2 (0.000f,0.500f),	// left
			new Vector2(0.334f,0.500f),new Vector2(0.666f,0.500f),new Vector2(0.666f,1.000f),new Vector2 (0.334f,1.000f),	// top
			new Vector2(0.334f,0.000f),new Vector2(0.666f,0.000f),new Vector2(0.666f,0.500f),new Vector2 (0.334f,0.500f)	// bottom
		};
		gameObject.GetComponent<MeshFilter>().mesh.triangles = new int[] {
			0,1,2,
			0,2,3,
			4,5,6,
			4,6,7,
			8,9,10,
			8,10,11,
			12,13,14,
			12,14,15,
			16,17,18,
			16,18,19,
			20,22,21,
			20,23,22
		};
		gameObject.GetComponent<MeshFilter>().mesh.normals = new Vector3[] {
			new Vector3( 0, 0,-1),new Vector3( 0, 0,-1),new Vector3( 0, 0,-1),new Vector3( 0, 0,-1),	//front
			new Vector3( 0, 0, 1),new Vector3( 0, 0, 1),new Vector3( 0, 0, 1),new Vector3( 0, 0, 1),	//back
			new Vector3( 1, 0, 0),new Vector3( 1, 0, 0),new Vector3( 1, 0, 0),new Vector3( 1, 0, 0),	//right
			new Vector3(-1, 0, 0),new Vector3(-1, 0, 0),new Vector3(-1, 0, 0),new Vector3(-1, 0, 0),	//left
			new Vector3( 0, 1, 0),new Vector3( 0, 1, 0),new Vector3( 0, 1, 0),new Vector3( 0, 1, 0),	//top
			new Vector3( 0,-1, 0),new Vector3( 0,-1, 0),new Vector3( 0,-1, 0),new Vector3( 0,-1, 0)		//bottom
		};
	}
}
