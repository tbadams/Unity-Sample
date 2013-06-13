using UnityEngine;
using System.Collections;
 
// @robotduck 2011
// set the object's rigidbody angular drag to a high value, like 10
 
public class TorqueLookRotation2 : TurnController {
 
	//public Transform target;
	public float force = 0.01f;
	public float angleDiff;
	public float angleMargin = 5;
 
	void FixedUpdate () {
 
		Vector3 targetDelta = target.position - transform.position;
 
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
			rigidbody.angularVelocity /= 2;
			//rigidbody.angularVelocity = Vector3.zero;
			//rigidbody.maxAngularVelocity = 0;
		}
		//target.GetComponent(TestGui).addText = angleDiff;
	}
}