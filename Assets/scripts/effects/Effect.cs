using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect:MonoBehaviour
{
	public AudioSource audioSource;
	public virtual void ApplyEffect (float value) {}
	public virtual void ApplyEffect (float x, float y, float z) {}
}

