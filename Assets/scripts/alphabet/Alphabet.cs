using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Alphabet : MonoBehaviour {

	private const int X_VALUE = 0;
	private const int Y_VALUE = 1;

	private List<ParticleSystem.Particle> particleArray = new List<ParticleSystem.Particle>();
	private List<Vehicle> vehicles = new List<Vehicle> ();
	private List<int> wordIndex = new List<int>();
	private bool initialized = false;
	private float zOffset;

	public Letter[] letters;

	public string word;
	public float particleSize = 1.0f;
	public float letterSpace = 10.0f;

	/* ===== UNITY FUNCTIONS ==== */
	void Start () {
		zOffset = transform.parent.localScale.z / -2.0f;
		transform.localPosition = new Vector3 (0.0f, 0.0f, zOffset);

		JsonUtility.FromJsonOverwrite(
			File.ReadAllText (
				Path.Combine (
					Directory.GetCurrentDirectory (),
					".\\Assets\\fonts\\alphabet.json"
		)), this);
	}

	void LateUpdate () {
		if (word == "") {
			ResetAlphabet ();
		} else {
			InitAlphabet ();
			DisplayAlphabet ();
		}
	}

	/* ===== STRUCTURES FUNCTIONS ==== */
	private void ResetAlphabet() {
		if (initialized) {
			particleArray.Clear();
			vehicles.Clear();
			wordIndex.Clear();

			initialized = !initialized;
		}
	}

	private void InitAlphabet() {
		if (!initialized) {
			foreach (char c in word) {
				SetWordIndex (c);
			}

			SetWordDimentions ();
			SetParticleArray ();

			initialized = !initialized;
		}
	}

	private void DisplayAlphabet() {
		for (int i = 0; i < particleArray.Count; ++i) {
			vehicles [i].Behaviors ();
			vehicles [i].UpdatePosition();
			ParticleSystem.Particle tmp = particleArray [i];
			tmp.position = vehicles [i].position;
			particleArray [i] = tmp;
		}

		GetComponent<ParticleSystem> ().SetParticles (particleArray.ToArray(), particleArray.Count);
	}

	/* ===== CONFIGURATION FUNCTIONS ==== */
	private void SetWordIndex(char c) {
		if (c >= 'A' && c <= 'Z') {
			wordIndex.Add (c - 'A');
		} else if (c >= 'a' && c <= 'z') {
			wordIndex.Add (c - 'a' + 26);
		} else {
			wordIndex.Add (-1);
		}
	}

	private void SetWordDimentions() {
		float minX = 999.0f;
		float maxX = 0.0f;

		float minY = 999.0f;
		float maxY = 0.0f;

		float size = 0.0f;

		for (int i = 0; i < wordIndex.Count; ++i) {
			int id = wordIndex [i];

			size += SizeOfLetter (letters [id].points, X_VALUE) + letterSpace;

			if (minY > MinValue (letters [id].points, Y_VALUE)) {
				minY = MinValue (letters [id].points, Y_VALUE);
			}
			if (maxY < MaxValue (letters [id].points, Y_VALUE)) {
				maxY = MaxValue (letters [id].points, Y_VALUE);
			}
		}

		minX = MinValue (letters [wordIndex [0]].points, X_VALUE);
		maxX = size;

		Vehicle.minRange.x = minX;
		Vehicle.minRange.y = minY;
		Vehicle.maxRange.x = maxX;
		Vehicle.maxRange.y = maxY;
	}

	private void SetParticleArray() {
		foreach (int id in wordIndex) {
			for (int i = 0; i < letters[id].points.Length; ++i) {
				Point p = letters[id].points[i];
				Vehicle vehicle = new Vehicle (new Vector3 (p.x, p.y, zOffset));

				ParticleSystem.Particle particle = new ParticleSystem.Particle ();
				particle.startSize = particleSize;
				particle.startColor = Color.white;
				particle.position = vehicle.position;

				particleArray.Add (particle);
				vehicles.Add (vehicle);
			}
		}
	}

	/* ===== LITTLE ALGORYTHMS ===== */
	private float SizeOfLetter(Point[] points, int axis) {
		return MaxValue (points, axis) - MinValue (points, axis);
	}

	private float MaxValue(Point[] points, int axis) {
		float max = 0;
		foreach (Point p in points) {
			if (axis == X_VALUE) {
				max = max < p.x ? p.x : max;
			} else if (axis == Y_VALUE) {
				max = max < p.y ? p.y : max;
			}
		}
		return max;
	}

	private float MinValue(Point[] points, int axis) {
		float min = 999.9f;
		foreach (Point p in points) {
			if (axis == X_VALUE) {
				min = min > p.x ? p.x : min;
			} else if (axis == Y_VALUE) {
				min = min > p.y ? p.y : min;
			}
		}
		return min;
	}

	/* ===== STRUCTURE CLASSES ===== */
	[System.Serializable]
	public class Letter {
		public Point[] points;
	}

	[System.Serializable]
	public class Point {
		public float x;
		public float y;
	}
}
