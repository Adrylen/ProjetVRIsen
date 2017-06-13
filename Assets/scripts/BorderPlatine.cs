using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPlatine : MonoBehaviour {
	private const int number_of_cubes = 32;
	private const float translation_scale = 0.499f;

	void Awake () {
//		Debug.Log ("Position | x = "+transform.position.x+"; y = "+transform.position.y+"; z = "+transform.position.z+"\n Rotation | x = "+transform.rotation.x+"; y = "+transform.rotation.y+"; z = "+transform.rotation.z);
		for (int i = 0; i < number_of_cubes; ++i) {
			float angle = i * 2 * Mathf.PI / number_of_cubes;

			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.parent = transform;

			//cube.transform.Translate (Mathf.Cos(angle), 0.0f, Mathf.Sin(angle));
//
//			cube.transform.Translate(new Vector3(
//				gameObject.transform.position.x + Mathf.Cos(angle) * translation_scale * gameObject.transform.parent.transform.localScale.x,
//				gameObject.transform.position.y,
//				gameObject.transform.position.z + Mathf.Sin(angle) * translation_scale * gameObject.transform.parent.transform.localScale.z
//			));
//
//			cube.transform.rotation = new Vector3 (
//				gameObject.transform.rotation.x,
//				gameObject.transform.rotation.y + -1 * angle * 180.0f / Mathf.PI,
//				gameObject.transform.rotation.z + 45.0f
//			);
//
//			cube.transform.localScale = new Vector3(
//				gameObject.transform.localScale.x * 0.14f,
//				gameObject.transform.localScale.y * 0.14f,
//				gameObject.transform.localScale.z * 0.14f
//			);

			cube.transform.localRotation = Quaternion.Euler(0.0f,-1 * angle * 180.0f / Mathf.PI,45.0f);

			cube.transform.localPosition = new Vector3 ( Mathf.Cos(angle) * translation_scale, 0.0f, Mathf.Sin(angle) * translation_scale);

			cube.transform.localScale = new Vector3 (0.14f, 0.14f, 0.14f);
		}
	}
}
