#pragma strict

var thrust = 5.0;

function Start () {

}

function Update () {
	
	var x = Input.GetAxis("Horizontal") * thrust;
	var z = Input.GetAxis("Vertical") * thrust;
	var y = Input.GetAxis("Jump") * thrust;
	rigidbody.AddRelativeForce(x, y, z);
	//var roll = Input.GetAxis("Roll") * thrust;
	//rigidbody.AddTorque(roll,roll,roll);
}