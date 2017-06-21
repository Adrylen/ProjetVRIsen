using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAudioGraph : MonoBehaviour
{

    public ParticleSystem aParticleSystem;
    private ParticleSystem.Particle[] particlesArray;
    public int screenX, screenY;
    public float spacing = 0.2F;
    public int numberOfFrequencies;
    public int numberOfDecomposition;
    public float particleSize;
    private float[] spectrumDecomposition;
    public AudioSource sourceAudio;


    // Use this for initialization
    void Start()
    {
        aParticleSystem = gameObject.GetComponent<ParticleSystem>();
        particlesArray = new ParticleSystem.Particle[screenX * screenY];
        aParticleSystem.GetParticles(particlesArray);

        for (int i = 0; i < screenX; i++)
        {
            for (int j = 0; j < screenY; j++)
            {
                particlesArray[i * screenY + j] = new ParticleSystem.Particle();
                particlesArray[i * screenY + j].position = new Vector3(i * spacing, j * spacing, 1);
                particlesArray[i * screenY + j].startSize = particleSize;
                changeParticleColor(ref particlesArray[i * screenY + j], Color.black);
            }
        }
        changeParticleColor(ref particlesArray[8], Color.blue);
        switchOnColumn(1, 8, particlesArray);

        aParticleSystem.SetParticles(particlesArray, particlesArray.Length);
        spectrumDecomposition = new float[numberOfDecomposition];
    }

    // Update is called once per frame
    void Update()
    {
        barGraph(particlesArray);
        aParticleSystem.SetParticles(particlesArray, particlesArray.Length);
    }

    void changeParticleColor (ref ParticleSystem.Particle aParticle, Color aColor)
    {
        aParticle.startColor = aColor;
    }

    void switchOnColumn(int column, int value, ParticleSystem.Particle[] aParticlesArray)
    {
        int i, j;
        j = column;
        float test;
        for (i = 0; i<value;i++)
        {
            test = screenY - i;
            float rValue = 1 - test / 22;
            if (test > 20) { rValue = 0.5F + (float)test / 150; }
            float vValue = test / 22;
            changeParticleColor(ref aParticlesArray[j*screenY+i], new Color(rValue, vValue, 1));
        }
    }

    void particleFall(ParticleSystem.Particle[] aParticlesArray)
    {
        int i = 0, j = 0;
        Color tempColor;
        while (i < screenX)
        {
            j = screenY-1;
            while (j > 0)
            {
                if (aParticlesArray[i * screenY + j].startColor != Color.black)
                {
                    tempColor = aParticlesArray[i * screenY + j -1].startColor;
                    aParticlesArray[i * screenY + j].startColor = Color.black;
                    aParticlesArray[i * screenY + j -1].startColor = tempColor;
                    if (i < screenX-1) { i++; j = screenY-1; }
                    else { j = 0; }
                }

                else { j--; }
            }
            i++;
        }
    }

    void barGraph(ParticleSystem.Particle[] aParticlesArray)
    {
        spectrumDecomposition = fft.makeFft(numberOfDecomposition, numberOfFrequencies);
        particleFall(aParticlesArray);
        for (int i = 0; i < numberOfDecomposition; i++)
        {
            float spectrumValue = spectrumDecomposition[i] * 100;
            if (spectrumValue > 31f)
            {
                spectrumValue = 31f;
            }
            int width = 182 / numberOfDecomposition;
            int valeur = i * (width);
            for (int j = valeur; j < valeur + width; j++)
            {
                switchOnColumn(j, (int)spectrumValue, aParticlesArray);
            }

        }
    }


}

