using UnityEngine;
using System.Collections;
 
// @robotduck 2011
// set the object's rigidbody angular drag to a high value, like 10
 
public class TorqueTurnAndAvoidWall : TurnController {
 
	//public Transform target;
	public float force = 0.01f;
	private float angleDiff;
	public float angleMargin = 5;
	public float tooClose = 4f;
	public float retreatTime = 3;
	private float resumeTime = 0;
	public float dampFactor = 2;
	public float avoidTime = 2;
 
	void FixedUpdate () {
		
		Ray collisRay = new Ray(transform.position,transform.rotation.eulerAngles);
		//Initializing some variables
	     RaycastHit hitInfo;
		int layerMask = 1 << 8;
		layerMask = ~layerMask;
	    //Grab the information we need
	    bool obstacleAhead = Physics.Raycast( 
			collisRay, out hitInfo, rigidbody.velocity.magnitude * avoidTime, layerMask);
	    //Note this function also returns a boolean about whether it actually hit anything, so you can use that to check first if hitInfo is null or not
	    //And find the point of impact
		//targetObject= hitInfo.transform;
 
		//determine rotation
		float targetDist = Vector3.Distance(transform.position,target.position);
		Vector3 targetDelta;
		if(obstacleAhead){
			targetDelta = hitInfo.point - transform.position;
			resumeTime = (Time.time + retreatTime);	
		}else if(targetDist > tooClose && resumeTime <= Time.time){
			targetDelta = target.position - transform.position;
		}else{
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
		//target.GetComponent(TestGui).addText = angleDiff;
	}
}