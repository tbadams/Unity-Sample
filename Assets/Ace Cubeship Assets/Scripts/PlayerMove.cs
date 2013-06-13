using UnityEngine;
using System.Collections;

// Handles input and movement for player.
public class PlayerMove : MonoBehaviour {

	public float thrust = 5f;
	// Scales thrust so that drag will not change top speed, only decceleration. Is a bit wonky.
	public bool dragComp = false; 
	
	void Start () {
	
	}
	
	void Update () {
		float adjust = dragComp ? rigidbody.drag : 1;
		var x = Input.GetAxis("Horizontal") * thrust;
		var z = Input.GetAxis("Vertical") * thrust * adjust;
		var y = Input.GetAxis("Jump") * thrust;
		rigidbody.AddRelativeForce(x, y, z);
		var roll = Input.GetAxis("Roll") * thrust;
		rigidbody.AddTorque(roll,roll,roll);
	}
}
