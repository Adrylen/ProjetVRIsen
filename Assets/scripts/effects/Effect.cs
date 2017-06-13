using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect:MonoBehaviour
{
	public AudioSource audioSource;
	public abstract void ApplyEffect (float value);
}

