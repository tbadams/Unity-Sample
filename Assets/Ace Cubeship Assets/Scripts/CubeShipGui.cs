using UnityEngine;
using System.Collections;

// Displays player gui.  Currently very barebones.
public class CubeShipGui : MonoBehaviour {
	
	float UIX = 10.0f;
	float UIY = 10.0f;
	float UIWidth = 150.0f;
	float UIHeight = 150.0f;
	
	void OnGUI () {
		//Game Info
		GUI.TextArea ( new Rect (UIX, UIY, UIWidth, UIHeight), 
				"Absolute Velocity:" + rigidbody.velocity + "\n" + 
				"Relative Velocity:" + (Quaternion.FromToRotation(transform.forward,Vector3.forward) * rigidbody.velocity) + "\n" +
				"Rotation:" + transform.rotation.eulerAngles + "\n" + 
				"Damping:" + rigidbody.drag + "\n" +
				"Health:" + GetComponent<Health>().health);
		
		// Controls Reminder
		// TODO: Toggle Controls reminder with a key
		GUI.TextArea ( new Rect (UIX, (2 * UIY) + UIHeight, UIWidth, UIHeight), 
				"Controls:\n " +
				"Movement: WASD/ Directional Keys\n" +
				"Fire: Mouse1/ Left Ctrl\n" +
				"Up/Down: Space/C\n" +
				"Roll: Q/E\n" +
				"Adjust Damping: Mouse Wheel");
	
	}
	
}
