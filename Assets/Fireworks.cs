using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {
    public GameObject mainProjectile;
    public ParticleSystem mainParticleSystem;
    private ParticleSystem.EmissionModule em;
	// Use this for initialization
	void Start () {
        em = mainParticleSystem.emission;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            em.enabled = true;
            mainParticleSystem.Play();
        }

	}
}
