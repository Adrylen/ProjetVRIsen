using UnityEngine;

public class TextureCylinder : MonoBehaviour {
	void Start () {
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf != null ? mf.mesh : null;

		if(mesh == null || mesh.uv.Length != 88) {
			Debug.Log("Script must be attached to a cylinder");
			return;
		}

		float[,] colors = new float[,] {
			#region BottomPoints
			{ 0.0f, 1.0f },	//  0
			{ 1.0f, 1.0f },	//  1
			{ 2.0f, 1.0f },	//  2
			{ 3.0f, 1.0f },	//  3
			{ 4.0f, 1.0f },	//  4
			{ 5.0f, 1.0f },	//  5
			{ 6.0f, 1.0f },	//  6
			{ 7.0f, 1.0f },	//  7
			{ 8.0f, 1.0f },	//  8
			{ 9.0f, 1.0f },	//  9
			{10.0f, 1.0f },	// 10
			{11.0f, 1.0f },	// 11
			{12.0f, 1.0f },	// 12
			{13.0f, 1.0f },	// 13
			{14.0f, 1.0f },	// 14
			{15.0f, 1.0f },	// 15
			{16.0f, 1.0f },	// 16
			{17.0f, 1.0f },	// 17
			{18.0f, 1.0f },	// 18
			{19.0f, 1.0f },	// 19
			#endregion
			#region TopPoints
			{ 0.0f, 3.0f },	// 20
			{ 1.0f, 3.0f },	// 21
			{ 2.0f, 3.0f },	// 22
			{ 3.0f, 3.0f },	// 23
			{ 4.0f, 3.0f },	// 24
			{ 5.0f, 3.0f },	// 25
			{ 6.0f, 3.0f },	// 26
			{ 7.0f, 3.0f },	// 27
			{ 8.0f, 3.0f },	// 28
			{ 9.0f, 3.0f },	// 29
			{10.0f, 3.0f },	// 30
			{11.0f, 3.0f },	// 31
			{12.0f, 3.0f },	// 32
			{13.0f, 3.0f },	// 33
			{14.0f, 3.0f },	// 34
			{15.0f, 3.0f },	// 35
			{16.0f, 3.0f },	// 36
			{17.0f, 3.0f },	// 37
			{18.0f, 3.0f },	// 38
			{19.0f, 3.0f },	// 39
			#endregion
			#region CenterPoints
			{10.0f, 0.0f },	// 40	// Bottom
			{10.0f, 4.0f },	// 41	// Top
			#endregion
			#region MissedBands
			{ 9.0f, 1.0f },	// 42	// Bottom	theta = 0
			{ 9.0f, 3.0f },	// 43	// Top 		theta = 0
			{19.0f, 1.0f },	// 44	// Bottom	theta = pi
			{19.0f, 3.0f },	// 45	// Top 		theta = pi
			{20.0f, 3.0f },	// 46	// Top		theta = -9pi/10
			{20.0f, 1.0f },	// 47	// Bottom	theta = -9pi/10
			#endregion
			#region BottomCircle
			{ 1.0f, 1.0f },	// 48
			{ 0.0f, 1.0f },	// 49
			{ 2.0f, 1.0f },	// 50
			{ 3.0f, 1.0f },	// 51
			{ 4.0f, 1.0f },	// 52
			{ 5.0f, 1.0f },	// 53
			{ 6.0f, 1.0f },	// 54
			{ 7.0f, 1.0f },	// 55
			{ 8.0f, 1.0f },	// 56
			{ 9.0f, 1.0f },	// 57
			{10.0f, 1.0f },	// 58
			{11.0f, 1.0f },	// 59
			{12.0f, 1.0f },	// 60
			{13.0f, 1.0f },	// 61
			{14.0f, 1.0f },	// 62
			{15.0f, 1.0f },	// 63
			{16.0f, 1.0f },	// 64
			{17.0f, 1.0f },	// 65
			{18.0f, 1.0f },	// 66
			{19.0f, 1.0f },	// 67
			#endregion
			#region TopCircle
			{ 0.0f, 3.0f },	// 68
			{ 1.0f, 3.0f },	// 69
			{ 2.0f, 3.0f },	// 70
			{ 3.0f, 3.0f },	// 71
			{ 4.0f, 3.0f },	// 72
			{ 5.0f, 3.0f },	// 73
			{ 6.0f, 3.0f },	// 74
			{ 7.0f, 3.0f },	// 75
			{ 8.0f, 3.0f },	// 76
			{ 9.0f, 3.0f },	// 77
			{10.0f, 3.0f },	// 78
			{11.0f, 3.0f },	// 79
			{12.0f, 3.0f },	// 80
			{13.0f, 3.0f },	// 81
			{14.0f, 3.0f },	// 82
			{15.0f, 3.0f },	// 83
			{16.0f, 3.0f },	// 84
			{17.0f, 3.0f },	// 85
			{18.0f, 3.0f },	// 86
			{19.0f, 3.0f }	// 87
			#endregion
		};

		Vector2[] uvs = new Vector2[mesh.vertices.Length];

		for (int i = 0; i < mesh.vertices.Length; ++i) {
			uvs [i] = new Vector2 (colors[i, 0] / 20.0f, colors[i, 1] / 4.0f);
		}

		mesh.uv = uvs;
	}
}