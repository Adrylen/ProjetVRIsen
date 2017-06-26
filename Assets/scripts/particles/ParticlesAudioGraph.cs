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
    Gradient colorGradient;

    // Use this for initialization
    void Start()
    {
        colorGradient = new Gradient();
        colorGradientAssigner(ref colorGradient);
        aParticleSystem = gameObject.GetComponent<ParticleSystem>();
        particlesArray = new ParticleSystem.Particle[screenX * screenY];
        aParticleSystem.GetParticles(particlesArray);

        for (int i = 0; i < screenX; i++)
        {
            for (int j = 0; j < screenY; j++)
            {
                particlesArray[i * screenY + j] = new ParticleSystem.Particle();
                particlesArray[i * screenY + j].position = new Vector3(i * spacing * transform.parent.localScale.x, j * spacing, 0);
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
    void LateUpdate()
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
        float tempColor;
        j = column;
        for (i = 0; i<value;i++)
        {
            tempColor = (float) i / (screenY-1);
            changeParticleColor(ref aParticlesArray[j * screenY + i], colorGradient.Evaluate(tempColor));
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
        spectrumDecomposition = fft.makeFft(numberOfDecomposition, numberOfFrequencies, sourceAudio);
        particleFall(aParticlesArray);
        for (int i = 0; i < numberOfDecomposition; i++)
        {
            float spectrumValue = spectrumDecomposition[i] * 100;
            if (spectrumValue > 31f)
            {
                spectrumValue = 31f;
            }
            int width = screenX / numberOfDecomposition;
            int valeur = i * (width);
            for (int j = valeur; j < valeur + width; j++)
            {
                switchOnColumn(j, (int)spectrumValue, aParticlesArray);
            }

        }
    }

    Gradient colorGradientAssigner(ref Gradient aColorGradient)
    {
        GradientAlphaKey[] gak = new GradientAlphaKey[3];
        GradientColorKey[] gck = new GradientColorKey[3];

        gck[0].color = Color.magenta;
        gck[0].time = 0.0F;
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;


        gck[1].color = new Color((float)75 / 255, (float)192 / 255, (float)200 / 255);
        gck[1].time = 0.45F;
        gak[1].alpha = 1.0F;
        gak[1].time = 0.45F;


        gck[2].color = Color.white;
        gck[2].time = 1;
        gak[2].alpha = 1.0F;
        gak[2].time = 1F;


        aColorGradient.SetKeys(gck, gak);
        return aColorGradient; 
    }

}

