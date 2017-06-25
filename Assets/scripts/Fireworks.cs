using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {
    public ParticleSystem fire1, fire2, fire3, fire4, fire5;
    private ParticleSystem.EmissionModule em1,em2,em3,em4,em5;
    public int numberOfFrequencies;
    public int numberOfDecomposition;
    private float[] spectrumDecomposition;
    public AudioSource sourceAudio;
    private int numberOfFireworks = 6;
    public Gradient multicolorGradient;

    // Use this for initialization
    void Start () {

        em1 = fire1.emission;
        em2 = fire2.emission;
        em3 = fire3.emission;
        em4 = fire4.emission;
        em5 = fire5.emission;

        em1.enabled = true;
        em2.enabled = true;
        em3.enabled = true;
        em4.enabled = true;
        em5.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        spectrumDecomposition = fft.makeFft(numberOfDecomposition, numberOfFrequencies);
        for (int i = 0; i < numberOfDecomposition; i++)
        {
            float spectrumValue = spectrumDecomposition[i];
        }
    }

    void changeFireworksParameter (ParticleSystem aFirework, float[] aSpectrum)
    {
        int subEmitterCount = aFirework.subEmitters.subEmittersCount;

    }
}
