using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCube : MonoBehaviour {
	void Start () {		
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf != null ? mf.mesh : null;

		if(mesh == null || mesh.uv.Length != 24) {
			Debug.Log("Script must be attached to a cube");
			return;
		}

		Vector2[] uvs = new Vector2[mesh.vertices.Length];

		Debug.Log (mesh.vertices);

		#region Front
		uvs[0]  = new Vector2(  0.0f,0.5f);	// Bottom	Left
		uvs[1]  = new Vector2(0.333f,0.5f);	// Bottom	Right
		uvs[2]  = new Vector2(  0.0f,1.0f);	// Top		Left
		uvs[3]  = new Vector2(0.333f,1.0f);	// Top		Right
		#endregion
		#region Top
		uvs[8]  = new Vector2(0.334f,0.5f);	// Bottom	Left
		uvs[9]  = new Vector2(0.666f,0.5f);	// Bottom	Right
		uvs[4]  = new Vector2(0.334f,1.0f);	// Top		Left
		uvs[5]  = new Vector2(0.666f,1.0f);	// Top		Right
		#endregion
		#region Back
		uvs[7]  = new Vector2(0.667f,0.5f);	// Bottom	Left
		uvs[6]  = new Vector2(  1.0f,0.5f);	// Bottom	Right
		uvs[11] = new Vector2(0.667f,1.0f);	// Top		Left
		uvs[10] = new Vector2(  1.0f,1.0f);	// Top		Right
		#endregion
		#region Bottom
		uvs[12] = new Vector2(0.334f,0.0f);	// Bottom	Left
		uvs[15] = new Vector2(0.666f,0.0f);	// Bottom	Right
		uvs[13] = new Vector2(0.334f,0.5f);	// Top		Left
		uvs[14] = new Vector2(0.666f,0.5f);	// Top		Right
		#endregion
		#region Right
		uvs[20] = new Vector2(  0.0f,0.0f);	// Bottom	Left
		uvs[23] = new Vector2(0.333f,0.0f);	// Bottom	Right
		uvs[21] = new Vector2(  0.0f,0.5f);	// Top		Left
		uvs[22] = new Vector2(0.333f,0.5f);	// Top		Right
		#endregion
		#region Left
		uvs[16] = new Vector2(0.667f,0.0f);	// Bottom	Left
		uvs[19] = new Vector2(  1.0f,0.0f);	// Bottom	Right
		uvs[17] = new Vector2(0.667f,0.5f);	// Top		Left
		uvs[18] = new Vector2(  1.0f,0.5f);	// Top		Right
		#endregion

		mesh.uv = uvs;
	}
}
