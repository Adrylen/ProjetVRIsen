using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaOfParticles : MonoBehaviour {
	
	private ParticleSystem.Particle[] particlesArray;
	private Gradient colorGradient;
	private float perlinNoiseAnimX = 0.01f;
	private float perlinNoiseAnimY = 0.01f;
	private float[] pointsArrays;

    public int seaResolution = 100;
    public float spacing = 0.25f;
    public float noiseScale = 0.2f;
    public float fftScale = 1.2f;
    public float heightScale = 3f;
    public float particleSize = 0.5f;

    void Start()
    {
		// Particles points
        particlesArray = new ParticleSystem.Particle[seaResolution * seaResolution];
		// FFT points
		pointsArrays = new float[seaResolution * seaResolution];
		// Scripted gradient
		colorGradient = GenerateGradient();

        GetComponent<ParticleSystem>().Emit(seaResolution * seaResolution);
		GetComponent<ParticleSystem>().GetParticles(particlesArray);
    }

	void LateUpdate() {
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
				particlesArray[i * seaResolution + j].startColor = colorGradient.Evaluate(pointsArrays[i * seaResolution + j]);
				particlesArray[i * seaResolution + j].position = new Vector3(i * spacing, pointsArrays[i * seaResolution + j] * heightScale, j * spacing);
                particlesArray[i * seaResolution + j].startSize = particleSize;
            }
		}
		perlinNoiseAnimX += 0.01f;
		GetComponent<ParticleSystem>().SetParticles(particlesArray, particlesArray.Length);
	}

	private Gradient GenerateGradient() {
		Gradient g = new Gradient ();

		g.SetKeys (
			new GradientColorKey[]{
				new GradientColorKey(Color.cyan, 0.0f),
				new GradientColorKey(Color.green, 0.5f),
				new GradientColorKey(Color.magenta, 1.0f)
			},
			new GradientAlphaKey[]{
				new GradientAlphaKey(1.0f, 0.0f),
				new GradientAlphaKey(1.0f, 0.5f),
				new GradientAlphaKey(1.0f, 1.0f)
			}
		);

		return g; 
	}
}
