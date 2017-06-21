using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaOfParticles : MonoBehaviour {
	
	private ParticleSystem.Particle[] particlesArray;
	private float perlinNoiseAnimX = 0.01f;
	private float perlinNoiseAnimY = 0.01f;
	private float[] pointsArrays;

	public ParticleSystem particleSystem;
	public Gradient colorGradient;

	[Range(0.0f, 1.0f)]
	public float moveX = 1.0f;
	[Range(0.0f, 1.0f)]
	public float moveY = 1.0f;

    public int seaResolution = 100;
    public float spacing = 0.25f;
    public float noiseScale = 0.2f;
    public float fftScale = 1.2f;
    public float heightScale = 3f;

    void Start()
    {
		// Particles points
        particlesArray = new ParticleSystem.Particle[seaResolution * seaResolution];
		// FFT points
		pointsArrays = new float[seaResolution * seaResolution];

        particleSystem.maxParticles = seaResolution * seaResolution;
        particleSystem.Emit(seaResolution * seaResolution);
        particleSystem.GetParticles(particlesArray);
    }

    void Update()
    {
		//NoiseWave ();
		SoundWave ();
    }

	public void SoundWave() {
		float[] points = fft.makeFft (seaResolution, 512);
		float[] old_line = new float[seaResolution];

		for (int i = 0; i < seaResolution; i++) {
			for (int j = 0; j < seaResolution; j++) {
				if (i == 0) {
					old_line [j] = pointsArrays [i * seaResolution + j];
					pointsArrays [i * seaResolution + j] = points[j] * fftScale + Mathf.PerlinNoise(i * noiseScale + perlinNoiseAnimX, j * noiseScale + perlinNoiseAnimY) * noiseScale;
				} else {
					float swap = pointsArrays [i * seaResolution + j];
					pointsArrays [i * seaResolution + j] = old_line [j];
					old_line [j] = swap;
				}
				particlesArray[i * seaResolution + j].color = colorGradient.Evaluate(pointsArrays[i * seaResolution + j]);
				particlesArray[i * seaResolution + j].position = new Vector3(i * spacing, pointsArrays[i * seaResolution + j] * heightScale, j * spacing);
			}
		}
		perlinNoiseAnimX += 0.01f;
		particleSystem.SetParticles(particlesArray, particlesArray.Length);
	}

	public void NoiseWave() {
		for (int i = 0; i < seaResolution; i++)
		{
			for (int j = 0; j < seaResolution; j++)
			{
				float zPos = Mathf.PerlinNoise(i * noiseScale + perlinNoiseAnimX, j * noiseScale + perlinNoiseAnimY);

				particlesArray[i * seaResolution + j].color = colorGradient.Evaluate(zPos);

				particlesArray[i * seaResolution + j].position = new Vector3(i * spacing, zPos * heightScale, j * spacing);
			}
		}

		// Movement
		perlinNoiseAnimX += 0.01f * moveX;
		perlinNoiseAnimY += 0.01f * moveY;

		// Apply Particules
		particleSystem.SetParticles(particlesArray, particlesArray.Length);
	}
}
