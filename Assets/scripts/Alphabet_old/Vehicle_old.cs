using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_old {
	private Vector3 target;
	private Vector3 speed;
	private Vector3 acceleration;
	private float maxSpeed;
	private float maxForce;

	public static ScreenRange minRange = new ScreenRange();
	public static ScreenRange maxRange = new ScreenRange();

	public Vector3 position;

	public Vehicle_old(Vector3 target) {
		position = new Vector3 (
			Random.Range(minRange.x, maxRange.x),
			Random.Range(minRange.y, maxRange.y),
			target.z
		);
		this.target = target;
		speed = new Vector3 (
			Random.Range (0.0f, 1.0f),
			Random.Range (0.0f, 1.0f),
			Random.Range (0.0f, 1.0f)
		);
		acceleration = Vector2.zero;
		maxSpeed = 10.0f;
		maxForce = 1.0f;
	}

	public void Behaviors() {
		Vector3 arrive = Arrive(target);
		ApplyForce(arrive);
	}

	public void ApplyForce(Vector3 f) {
		acceleration += f;
	}

	public void UpdatePosition() {
		position += speed;
		speed += acceleration;
		acceleration = Vector3.zero;
	}

	public Vector3 Arrive(Vector3 target) {
		Vector3 desired = target - position;
		float d = desired.magnitude;
		float speed = maxSpeed;
		if (d < 100) {
			speed = Map(d, 0, 100, 0, maxSpeed);
		}
		SetMagnitude(ref desired, speed);
		Vector3 steer = desired - this.speed;
		Vector3.ClampMagnitude (steer, maxForce);
		return steer;
	}

	private float Map(float value, float fromCurrent, float toCurrent, float fromTarget, float toTarget) {
		if (value <= fromTarget) {
			return fromCurrent;
		} else if (value >= toTarget) {
			return toCurrent;
		} else {
			return (toCurrent - fromCurrent) * ((value - fromTarget) / (toTarget - fromTarget)) + fromCurrent;
		}
	}

	private void SetMagnitude(ref Vector3 v, float mag) {
		v.Normalize ();
		v = new Vector3 (
			v.x * mag,
			v.y * mag,
			v.z * mag
		);
	}

	public class ScreenRange {
		public float x { get; set; }
		public float y { get; set; }
	}
}
