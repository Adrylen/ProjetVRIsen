using System;
using UnityEngine;
public class MyParticle 
{
	private Vector2 accel = new Vector2(0,0);
	private Vector2 speed = new Vector2(0,0);
	private Vector2 pos;


	public MyParticle (Vector2 initPos)
	{
		pos = initPos;
	}

	public void applySpeed(Vector2 speed){
		this.speed = speed;
	}

	public int getX(){
		return (int)pos.x;
	}

	public int getY(){
		return (int)pos.y;
	}

	public void applyForce(Vector2 force){
		accel = accel + force;
	}

	public void update(){
			speed = speed + accel;
			pos = pos + speed;
	}
}

