using UnityEngine;
using System.Collections;

// based on code by @robotduck 2011

public class TorqueTurnAndRetreat : TurnController {
 
	public float force = 0.01f;
	private float angleDiff;
	public float angleMargin = 5;
	public float tooClose = 4f;
	public float retreatTime = 3;
	private float resumeTime = 0;
	public float dampFactor = 2;
	public float avoidTime = 2;
 
	void FixedUpdate () {
		
		//determine rotation
		float targetDist = Vector3.Distance(transform.position,target.position);
		Vector3 targetDelta;
		 if(targetDist > tooClose && resumeTime <= Time.time){
			targetDelta = target.position - transform.position;
		} else {
			//retreat if too close to target
			targetDelta = transform.position - target.position;
			resumeTime = (resumeTime <= Time.time ? Time.time + retreatTime : resumeTime);	
		}
		
		//get the angle between transform.forward and target delta
		angleDiff = Vector3.Angle(transform.forward, targetDelta);
 
		// get its cross product, which is the axis of rotation to
		// get from one vector to the other
		Vector3 cross = Vector3.Cross(transform.forward, targetDelta);
 
		// apply torque along that axis according to the magnitude of the angle.
		if(angleDiff >= angleMargin){
			rigidbody.AddTorque(cross * angleDiff * force);
			//rigidbody.maxAngularVelocity = 10000;
		}else{
			rigidbody.angularVelocity /= dampFactor;
			//rigidbody.angularVelocity = Vector3.zero;
			//rigidbody.maxAngularVelocity = 0;
		}
	}
}