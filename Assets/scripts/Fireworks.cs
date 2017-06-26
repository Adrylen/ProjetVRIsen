using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {
    public ParticleSystem fire1, fire2, fire3, fire4, fire5;
    private ParticleSystem test;
    private ParticleSystem.EmissionModule em1,em2,em3,em4,em5;
    public int numberOfFrequencies;
    public int numberOfDecomposition;
    private float[] spectrumDecomposition;
    public AudioSource sourceAudio;
    private int numberOfFireworks = 6;
    public Gradient multicolorGradient;
    public Gradient subGradient;
    private System.Random rnd;
    private float spectrumValue;
    private int count = 0;

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


        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);

    }


    void onOnbeatDetected()
    {

            rnd = new System.Random();

            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

    }



    // Update is called once per frame
    void LateUpdate()
    {
        
        
        spectrumValue = 0;
        spectrumDecomposition = fft.makeFft(numberOfDecomposition, numberOfFrequencies);
        for (int i = 0; i < numberOfDecomposition; i++)
        {
            spectrumValue += spectrumDecomposition[i] / 1.8F;

           
        }
        for (int i =0; i<5; i++)
        {
            test = gameObject.transform.GetChild(i).GetComponent<ParticleSystem>();
            changeFireworksParameter(ref test, spectrumValue);
        }

        if (spectrumValue > 0.2 && count > 100 || spectrumValue > 0.5 && count > 15)
        {
            rnd = new System.Random();
            int t = rnd.Next(1, 6);
            for (int i = rnd.Next(1, t); i < t; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
            }
            count = 0;
        }
        count++;
    }


    void changeFireworksParameter (ref ParticleSystem aFirework, float value)
    {
        ParticleSystem.MainModule subSettings;
        ParticleSystem fire;
        int subEmitterCount = aFirework.subEmitters.subEmittersCount;
        float param;

        for(int i=0; i< aFirework.transform.childCount; i++)
        {
            param = value;
            fire = aFirework.transform.GetChild(i).GetComponent<ParticleSystem>();
            fire.startColor = multicolorGradient.Evaluate(param);
            
            for(int j=0; j<fire.transform.childCount; j++)
            {
                    fire.transform.GetChild(j).GetComponent<ParticleSystem>().startColor = subGradient.Evaluate(param);
            }
        }

    }
}
