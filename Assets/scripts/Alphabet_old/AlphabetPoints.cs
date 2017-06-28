using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class AlphabetPoints : MonoBehaviour {

	/* ===== ATTRIBUTES ===== */
	private const int X_VALUE = 0;
	private const int Y_VALUE = 1;
	private const float SPACE_LETTER_SCALE = 10.0f;
	private const float MAX_ACC = 0.07f;
	private const float SCALE_ACC = 0.003f;

	private ParticleSystem.Particle[] particleArray = null;
	private List<float> particleOffsetX = new List<float> ();
	private List<float> particleOffsetY = new List<float> ();
	private List<Vehicle_old> vehicles = new List<Vehicle_old>();
	private char[] bottom_letters = {'g','j','p','q','y'};
	private float[,] targetPositions;
	private float acc;
	private bool accPos;

	public Letter[] letters;
	public string text;
	public float letterSpacing = 0.15f;
	public float particleHeight = -0.3f;
	public float particleSize = 0.05f;
	public float particleScale = 0.01f;

	/* ===== UNITY FUNCTIONS ===== */

	// At Start of the Application
	void Start () {
		transform.localPosition = new Vector3 (0.0f, 0.0f, transform.parent.localScale.z / -2.0f);

		JsonUtility.FromJsonOverwrite(
			File.ReadAllText (
				Path.Combine (
					Directory.GetCurrentDirectory (),
					".\\Assets\\fonts\\alphabet.json"
		)), this);
	}

	// Everytime during the process
	void LateUpdate() {
		if (text == "") {
			ResetParticleSystem ();
		} else {
			if (particleArray == null) {
				int size = 0;
				foreach (char c in text) {
					int id = GetIdOfLetter (c);
					if (id == -1) { continue; }

					size += letters [id].points.Length;
				}
				InitParticleArray (size);
			}
			DisplayParticles ();
		}
	}

	/* ===== MANAGEMENT FUNCTIONS ===== */

	// Reset all particles and tools containers 
	private void ResetParticleSystem() {
		GetComponent<ParticleSystem> ().Clear ();
		vehicles.Clear ();
		targetPositions = new float[0,0];
		particleArray = null;
	}

	private void DisplayParticles() {
		for (int i = 0; i < vehicles.Count; ++i) {
			vehicles[i].Behaviors ();
			vehicles[i].UpdatePosition ();
			particleArray [i].position = vehicles [i].position;
			Debug.Log (particleArray [i].position.x);
		}

		GetComponent<ParticleSystem> ().SetParticles (particleArray, particleArray.Length);
	}

	// Instanciante and Place all particles of the word
	private void InitParticleArray(int size) {
		particleArray = new ParticleSystem.Particle[size];
		targetPositions = new float[2, size];
		acc = 0.001f; accPos = true;
		InitOffsets ();

		int id = 0;
		for (int i = 0; i < text.Length; ++i) {
			int l = GetIdOfLetter (text[i]);
			if (l == -1) { continue; }

			//float particleOffsetY = particleScale * MaxValue (letters [l].points, Y_VALUE) + particleHeight;
			for (int j = 0; j < letters[l].points.Length; ++j) {

				particleArray [id] = new ParticleSystem.Particle ();
				particleArray [id].startSize = particleSize;
				particleArray [id].startColor = Color.white;

				vehicles.Add(new Vehicle_old(new Vector3(
					particleOffsetX [i] + particleScale * letters [l].points [j].x,
					particleOffsetY [i] - particleScale * letters [l].points [j].y,
					-0.05f
				)));
					
				particleArray [id].position = vehicles[id].position;

				id++;
			}
		}
	}

	private void InitOffsets() {
		InitXOffset ();
		InitYOffset ();
	}
	
	// Center all letters with others
	private void InitXOffset() {
		particleOffsetX.Clear();
		float globalSize = letterSpacing * (text.Length - 1);
		foreach (char c in text) {
			int id = GetIdOfLetter (c);
			if (id == -1) {
				globalSize += SPACE_LETTER_SCALE;
			} else {
				globalSize += SizeOfLetter(letters [id].points, X_VALUE);
			}
		}

		Vehicle_old.minRange.x = 0.0f;
		Vehicle_old.maxRange.x = globalSize;
		Vehicle_old.minRange.y = 0.0f;
		Vehicle_old.maxRange.y = 100.0f;
		
		float halfSize = globalSize / 2.0f;
		float min = -1.0f;
		float max = -1.0f;
		for (int i = 0; i < text.Length; ++i) {
			int id = GetIdOfLetter (text[i]);
			
			if (i == 0) {
				min = (id != 1 ? MinValue (letters [id].points, X_VALUE) : 0.0f) - halfSize;
			} else {
				// Division to avoid late multiplication
				min = max + letterSpacing / particleScale;
			}
			max = min + (id != -1 ? SizeOfLetter (letters [id].points, X_VALUE) : SPACE_LETTER_SCALE);

			particleOffsetX.Add (min * particleScale);
		}
	}

	private void InitYOffset() {
		particleOffsetY.Clear();
		foreach (char c in text) {
			int id = GetIdOfLetter (c);
			if (id == -1) {
				particleOffsetY.Add(0);
				continue;
			}
			float offset = particleScale * MaxValue (letters [id].points, Y_VALUE) + particleHeight;
			foreach (char letter in bottom_letters) {
				if (letter == c) {
					offset -= 0.4f;
				}
			}
			particleOffsetY.Add (offset);
		}
	}

	private void DefineAcceleration() {
		if (accPos) {
			acc += SCALE_ACC;
			if (acc >= MAX_ACC) { accPos = !accPos; }
		} else {
			if (acc <= 0.0f) {
				acc = 0.0f;
				return;
			}
			acc -= SCALE_ACC;
		}
		if (Mathf.Abs (particleArray [0].position.x) > Mathf.Abs (targetPositions [0, 0])) {
			acc *= acc < 0.0f ? 1 : -1;
		} else {
			acc *= acc >= 0.0f ? 1 : -1;
		}
	}

	/* ===== LITTLE ALGORYTHMS ===== */

	// Get the Size of a letter from an axis
	private float SizeOfLetter(Point[] points, int axis) {
		return MaxValue (points, axis) - MinValue (points, axis);
	}

	// Get the Max value of an axis in particle list
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

	// Get the Min value of an axis in particle list
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

	// Get id in letters from char 
	private int GetIdOfLetter(char c) {
		if (c >= 'a' && c <= 'z') {
			return c - 'a' + 26;
		} else if (c >= 'A' && c <= 'Z') {
			return c - 'A';
		} else {
			return -1;
		}
	}

	/* ===== STRUCTURE CLASSES ===== */

	// Letter Class
	// Have a list of particles to
	// represent this letter
	[System.Serializable]
	public class Letter {
		public Point[] points;
	}

	// Point Class
	// Represent one of all particle
	// of a letter
	[System.Serializable]
	public class Point {
		public float x;
		public float y;
	}
}
