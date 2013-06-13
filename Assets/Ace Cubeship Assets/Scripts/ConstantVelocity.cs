using UnityEngine;
using System.Collections;

public class ConstantVelocity : VelocityController {

// Primary means of propulsion for enemy ships
// NOTE: Setting velocity directly is not reccomended for physics objects.
// Doing so here is a conscious decision.
public Vector3 direction = Vector3.forward;
	
	void Start ()
	{
		speed = direction.z;
	}
	
	void Update ()
	{
		direction = new Vector3(0,0,speed);
	    rigidbody.velocity =  transform.rotation * direction;
	}
}
