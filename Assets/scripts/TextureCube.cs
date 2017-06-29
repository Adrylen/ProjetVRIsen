using UnityEngine;

public class TextureCube : MonoBehaviour {
	void Start () {		
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf != null ? mf.mesh : null;

		if(mesh == null || mesh.uv.Length != 24) {
			Debug.Log("Script must be attached to a cube");
			return;
		}

		float[,] colors = new float[,] {
			#region Front
			{  0.0f,0.5f},	// Bottom	Left
			{0.333f,0.5f},	// Bottom	Right
			{  0.0f,1.0f},	// Top		Left
			{0.333f,1.0f},	// Top		Right
			#endregion
			#region Top
			{0.334f,0.5f},	// Bottom	Left
			{0.666f,0.5f},	// Bottom	Right
			{0.334f,1.0f},	// Top		Left
			{0.666f,1.0f},	// Top		Right
			#endregion
			#region Back
			{0.667f,0.5f},	// Bottom	Left
			{  1.0f,0.5f},	// Bottom	Right
			{0.667f,1.0f},	// Top		Left
			{  1.0f,1.0f},	// Top		Right
			#endregion
			#region Bottom
			{0.334f,0.0f},	// Bottom	Left
			{0.666f,0.0f},	// Bottom	Right
			{0.334f,0.5f},	// Top		Left
			{0.666f,0.5f},	// Top		Right
			#endregion
			#region Right
			{  0.0f,0.0f},	// Bottom	Left
			{0.333f,0.0f},	// Bottom	Right
			{  0.0f,0.5f},	// Top		Left
			{0.333f,0.5f},	// Top		Right
			#endregion
			#region Left
			{0.667f,0.0f},	// Bottom	Left
			{  1.0f,0.0f},	// Bottom	Right
			{0.667f,0.5f},	// Top		Left
			{  1.0f,0.5f}	// Top		Right
			#endregion
		};

		Vector2[] uvs = new Vector2[mesh.vertices.Length];

		for (int i = 0; i < mesh.vertices.Length; ++i) {
			uvs [i] = new Vector2 (colors[i, 0] / 20.0f, colors[i, 1] / 4.0f);
		}


		mesh.uv = uvs;
	}
}
