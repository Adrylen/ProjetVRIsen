using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDrum : MonoBehaviour {
	void Start () {		
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf != null ? mf.mesh : null;

		if(mesh == null || mesh.uv.Length != 88) {
			Debug.Log("Script must be attached to a cylinder");
			return;
		}

		Vector2[] uvs = new Vector2[mesh.vertices.Length];

		//Debug.Log (mesh.vertices);

		#region Middle
		uvs[0]  = new Vector2(  0.0f,0.5f); //bas du tambour
		uvs[1]  = new Vector2(  0.0f,0.5f);
		uvs[2]  = new Vector2(  0.0f,0.5f);
		uvs[3]  = new Vector2(  0.0f,0.5f);
		uvs[4]  = new Vector2(  0.0f,0.5f);
		uvs[5]  = new Vector2(  0.0f,0.5f);
		uvs[6]  = new Vector2(  0.0f,0.5f);
		uvs[7]  = new Vector2(  0.0f,0.5f);
		uvs[8]  = new Vector2(  0.0f,0.5f);
		uvs[9]  = new Vector2(  0.0f,0.5f);
		//trou1
		uvs[42]  = new Vector2(  0.0f,0.5f); //moitié de trou1 comblée
		uvs[43]  = new Vector2(  0.0f,0.5f); 
		//trou1 comblé
		uvs[10]  = new Vector2(  0.0f,0.5f);
		uvs[11]  = new Vector2(  0.0f,0.5f);
		uvs[12]  = new Vector2(  0.0f,0.5f);
		uvs[13]  = new Vector2(  0.0f,0.5f);
		uvs[14]  = new Vector2(  0.0f,0.5f);
		uvs[15]  = new Vector2(  0.0f,0.5f);
		uvs[16]  = new Vector2(  0.0f,0.5f);
		uvs[17]  = new Vector2(  0.0f,0.5f);
		uvs[18]  = new Vector2(  0.0f,0.5f);
		uvs[19]  = new Vector2(  0.0f,0.5f);
		//trou2
		uvs[20]  = new Vector2(  0.0f,0.5f); //grande barre qui fait tout le tambour
		uvs[21]  = new Vector2(  0.0f,0.5f); 
		uvs[22]  = new Vector2(  0.0f,0.5f); 
		uvs[23]  = new Vector2(  0.0f,0.5f); 
		uvs[24]  = new Vector2(  0.0f,0.5f); 
		uvs[25]  = new Vector2(  0.0f,0.5f); 
		uvs[26]  = new Vector2(  0.0f,0.5f); 
		uvs[27]  = new Vector2(  0.0f,0.5f); 
		uvs[28]  = new Vector2(  0.0f,0.5f); 
		uvs[29]  = new Vector2(  0.0f,0.5f); 
		//trou1
		uvs[30]  = new Vector2(  0.0f,0.5f); //grande barre de l'autre côté
		uvs[31]  = new Vector2(  0.0f,0.5f);
		uvs[32]  = new Vector2(  0.0f,0.5f);
		uvs[33]  = new Vector2(  0.0f,0.5f);
		uvs[34]  = new Vector2(  0.0f,0.5f);
		uvs[35]  = new Vector2(  0.0f,0.5f);
		uvs[36]  = new Vector2(  0.0f,0.5f);
		uvs[37]  = new Vector2(  0.0f,0.5f);
		uvs[38]  = new Vector2(  0.0f,0.5f);
		uvs[39]  = new Vector2(  0.0f,0.5f);
		//trou2
		uvs[44]  = new Vector2(  0.0f,0.5f); //morceau de trou2 comblé
		uvs[45]  = new Vector2(  0.0f,0.5f); //idem
		uvs[46]  = new Vector2(  0.0f,0.5f); //moitié de trou2 comblée
		uvs[47]  = new Vector2(  0.0f,0.5f); 
		//trou2 comblé
		#endregion

		#region Bottom
		uvs[40]  = new Vector2(  0.0f,1.0f); //rond au centre du dessous
		//avec 0.0f,0.0f : dessous orange/vert/blanc en cercle de l'exté vers l'inté
		//avec 0.0f,0.5f : dessous orange et petit cercle vert au centre
		//avec 0.0f,1.0f : dessous tout blanc

		//petit triangle dans le dessous
		uvs[48]  = new Vector2(  0.0f,1.0f); //pris dans le orange
		uvs[49]  = new Vector2(  0.0f,1.0f);
		uvs[50]  = new Vector2(  0.0f,1.0f);
		uvs[51]  = new Vector2(  0.0f,1.0f);
		uvs[52]  = new Vector2(  0.0f,1.0f);
		uvs[53]  = new Vector2(  0.0f,1.0f);
		uvs[54]  = new Vector2(  0.0f,1.0f);
		uvs[55]  = new Vector2(  0.0f,1.0f);
		uvs[56]  = new Vector2(  0.0f,1.0f);
		uvs[57]  = new Vector2(  0.0f,1.0f);
		uvs[58]  = new Vector2(  0.0f,1.0f);
		uvs[59]  = new Vector2(  0.0f,1.0f);
		uvs[60]  = new Vector2(  0.0f,1.0f);
		uvs[61]  = new Vector2(  0.0f,1.0f);
		uvs[62]  = new Vector2(  0.0f,1.0f);
		uvs[63]  = new Vector2(  0.0f,1.0f);
		uvs[64]  = new Vector2(  0.0f,1.0f);
		uvs[65]  = new Vector2(  0.0f,1.0f);
		uvs[66]  = new Vector2(  0.0f,1.0f);
		uvs[67]  = new Vector2(  0.0f,1.0f);
		#endregion

		#region Top
		uvs[41]  = new Vector2(  0.0f,0.0f); //rond au centre du dessus
		uvs[68]  = new Vector2(  0.0f,0.0f); //petit triangle sur le dessus
		uvs[69]  = new Vector2(  0.0f,0.0f);
		uvs[70]  = new Vector2(  0.0f,0.0f);
		uvs[71]  = new Vector2(  0.0f,0.0f);
		uvs[72]  = new Vector2(  0.0f,0.0f);
		uvs[73]  = new Vector2(  0.0f,0.0f);
		uvs[74]  = new Vector2(  0.0f,0.0f);
		uvs[75]  = new Vector2(  0.0f,0.0f);
		uvs[76]  = new Vector2(  0.0f,0.0f);
		uvs[77]  = new Vector2(  0.0f,0.0f);
		uvs[78]  = new Vector2(  0.0f,0.0f);
		uvs[79]  = new Vector2(  0.0f,0.0f);
		uvs[80]  = new Vector2(  0.0f,0.0f);
		uvs[81]  = new Vector2(  0.0f,0.0f);
		uvs[82]  = new Vector2(  0.0f,0.0f);
		uvs[83]  = new Vector2(  0.0f,0.0f);
		uvs[84]  = new Vector2(  0.0f,0.0f);
		uvs[85]  = new Vector2(  0.0f,0.0f);
		uvs[86]  = new Vector2(  0.0f,0.0f);
		uvs[87]  = new Vector2(  0.0f,0.0f);


		#endregion

		mesh.uv = uvs;
	}
}