#pragma strict

var UIX = 10.0;
var UIY = 10.0;
var UIWidth = 150.0;
var UIHeight = 150.0;
var addText = "";
// JavaScript
function OnGUI () {
	GUI.TextArea (Rect (UIX, UIY, UIWidth, UIHeight), 
			"Absolute Velocity:" + rigidbody.velocity + "\n" + 
			"Relative Velocity:" + (Quaternion.FromToRotation(transform.forward,Vector3.forward) * rigidbody.velocity) + "\n" +
			"Rotation:" + transform.rotation.eulerAngles + "\n" + 
			"Damping:" + rigidbody.drag + "\n"
//			"Mswheel:" + Input.GetAxis("Mouse ScrollWheel")
//			"Health:" + GetComponent(Health).health
			);

}