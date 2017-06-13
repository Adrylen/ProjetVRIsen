using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCylinder : MonoBehaviour {
	void Start () {
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf != null ? mf.mesh : null;

		if(mesh == null || mesh.uv.Length != 88) {
			Debug.Log("Script must be attached to a cylinder");
			return;
		}

		Vector2[] uvs = new Vector2[mesh.vertices.Length];

		uvs[40]	= new Vector2(0.000f, 0.666f);
		uvs[48]	= new Vector2(0.000f, 0.334f);
		// uvs[0]	= new Vector2(0.000f, 0.000f);
		// uvs[1]	= new Vector2(0.000f, 0.000f);
		// uvs[2]	= new Vector2(1.000f, 0.333f);
		// uvs[3]	= new Vector2(0.000f, 0.333f);
		// uvs[4]	= new Vector2(0.000f, 0.000f);
		// uvs[5]	= new Vector2(0.000f, 0.000f);
		// uvs[6]	= new Vector2(0.000f, 0.000f);
		// uvs[7]	= new Vector2(0.000f, 0.000f);
		// uvs[8]	= new Vector2(0.000f, 0.000f);
		// uvs[9]	= new Vector2(0.000f, 0.000f);
		// uvs[10]	= new Vector2(0.000f, 0.000f);
		// uvs[11]	= new Vector2(0.000f, 0.000f);
		// uvs[12]	= new Vector2(0.000f, 0.000f);
		// uvs[13]	= new Vector2(0.000f, 0.000f);
		// uvs[14]	= new Vector2(0.000f, 0.000f);
		// uvs[15]	= new Vector2(0.000f, 0.000f);
		// uvs[16]	= new Vector2(0.000f, 0.000f);
		// uvs[17]	= new Vector2(0.000f, 0.000f);
		// uvs[18]	= new Vector2(0.000f, 0.000f);
		// uvs[19]	= new Vector2(0.000f, 0.000f);
		// uvs[20]	= new Vector2(0.000f, 0.000f);
		// uvs[21]	= new Vector2(0.000f, 0.000f);
		// uvs[22]	= new Vector2(0.000f, 0.000f);
		// uvs[23]	= new Vector2(0.000f, 0.000f);
		// uvs[24]	= new Vector2(0.000f, 0.000f);
		// uvs[25]	= new Vector2(0.000f, 0.000f);
		// uvs[26]	= new Vector2(0.000f, 0.000f);
		// uvs[27]	= new Vector2(0.000f, 0.000f);
		// uvs[28]	= new Vector2(0.000f, 0.000f);
		// uvs[29]	= new Vector2(0.000f, 0.000f);
		// uvs[30]	= new Vector2(0.000f, 0.000f);
		// uvs[31]	= new Vector2(0.000f, 0.000f);
		// uvs[32]	= new Vector2(0.000f, 0.000f);
		// uvs[33]	= new Vector2(0.000f, 0.000f);
		// uvs[34]	= new Vector2(0.000f, 0.000f);
		// uvs[35]	= new Vector2(0.000f, 0.000f);
		// uvs[36]	= new Vector2(0.000f, 0.000f);
		// uvs[37]	= new Vector2(0.000f, 0.000f);
		// uvs[38]	= new Vector2(0.000f, 0.000f);
		// uvs[39]	= new Vector2(0.000f, 0.000f);
		// uvs[40]	= new Vector2(0.000f, 0.000f);
		// uvs[41]	= new Vector2(0.000f, 0.000f);
		// uvs[42]	= new Vector2(0.000f, 0.000f);
		// uvs[43]	= new Vector2(0.000f, 0.000f);
		// uvs[44]	= new Vector2(0.000f, 0.000f);
		// uvs[45]	= new Vector2(0.000f, 0.000f);
		// uvs[46]	= new Vector2(0.000f, 0.000f);
		// uvs[47]	= new Vector2(0.000f, 0.000f);
		// uvs[48]	= new Vector2(0.000f, 0.000f);
		// uvs[49]	= new Vector2(0.000f, 0.000f);
		// uvs[50]	= new Vector2(0.000f, 0.000f);
		// uvs[51]	= new Vector2(0.000f, 0.000f);
		// uvs[52]	= new Vector2(0.000f, 0.000f);
		// uvs[53]	= new Vector2(0.000f, 0.000f);
		// uvs[54]	= new Vector2(0.000f, 0.000f);
		// uvs[55]	= new Vector2(0.000f, 0.000f);
		// uvs[56]	= new Vector2(0.000f, 0.000f);
		// uvs[57]	= new Vector2(0.000f, 0.000f);
		// uvs[58]	= new Vector2(0.000f, 0.000f);
		// uvs[59]	= new Vector2(0.000f, 0.000f);
		// uvs[60]	= new Vector2(0.000f, 0.000f);
		// uvs[61]	= new Vector2(0.000f, 0.000f);
		// uvs[62]	= new Vector2(0.000f, 0.000f);
		// uvs[63]	= new Vector2(0.000f, 0.000f);
		// uvs[64]	= new Vector2(0.000f, 0.000f);
		// uvs[65]	= new Vector2(0.000f, 0.000f);
		// uvs[66]	= new Vector2(0.000f, 0.000f);
		// uvs[67]	= new Vector2(0.000f, 0.000f);
		// uvs[68]	= new Vector2(0.000f, 0.000f);
		// uvs[69]	= new Vector2(0.000f, 0.000f);
		// uvs[70]	= new Vector2(0.000f, 0.000f);
		// uvs[71]	= new Vector2(0.000f, 0.000f);
		// uvs[72]	= new Vector2(0.000f, 0.000f);
		// uvs[73]	= new Vector2(0.000f, 0.000f);
		// uvs[74]	= new Vector2(0.000f, 0.000f);
		// uvs[75]	= new Vector2(0.000f, 0.000f);
		// uvs[76]	= new Vector2(0.000f, 0.000f);
		// uvs[77]	= new Vector2(0.000f, 0.000f);
		// uvs[78]	= new Vector2(0.000f, 0.000f);
		// uvs[79]	= new Vector2(0.000f, 0.000f);
		// uvs[80]	= new Vector2(0.000f, 0.000f);
		// uvs[81]	= new Vector2(0.000f, 0.000f);
		// uvs[82]	= new Vector2(0.000f, 0.000f);
		// uvs[83]	= new Vector2(0.000f, 0.000f);
		// uvs[84]	= new Vector2(0.000f, 0.000f);
		// uvs[85]	= new Vector2(0.000f, 0.000f);
		// uvs[86]	= new Vector2(0.000f, 0.000f);
		// uvs[87]	= new Vector2(0.000f, 0.000f);

		mesh.uv = uvs;
	}
}
