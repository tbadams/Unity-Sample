using UnityEngine;
using System.Collections;

public class LerpToward : TurnController {
	
	//public Transform target;
	public float damp = .5f;
	public float tooClose = 5;
	public float retreatTime = 3;
	public float retreatDampSoften = 2;
	private float resumeTime = 0;
	
//	void Update () {
//		var rotation = Quaternion.LookRotation(target.position - transform.position);
//		transform.rotation = 
//			Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damp);
//	}
	
//	void Start () {
//		timer = gameObject.AddComponent("Timer") as Timer;
//		timer.duration = cooldown;
//   	 	timer.Set();
//	}
	
	void FixedUpdate () {
		float targetDist = Vector3.Distance(transform.position,target.position);
		Quaternion rotation;
		if(targetDist > tooClose && resumeTime <= Time.time){
			rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = 
					Quaternion.Lerp(transform.rotation, rotation, damp);
		}else{
			rotation = Quaternion.LookRotation(transform.position - target.position);
			resumeTime = (resumeTime <= Time.time ? Time.time + retreatTime : resumeTime);
			transform.rotation = 
					Quaternion.Lerp(transform.rotation, rotation, damp/retreatDampSoften);
		}

	}
	
//	public Transform target;
//	public float damp = .5f;
//	
////	void Update () {
////		var rotation = Quaternion.LookRotation(target.position - transform.position);
////		transform.rotation = 
////			Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damp);
////	}
//	
//	void FixedUpdate () {
//		var rotation = Quaternion.LookRotation(target.position - transform.position);
//		transform.rotation = 
//			Quaternion.Slerp(transform.rotation, rotation, damp);
//	}
	
}
