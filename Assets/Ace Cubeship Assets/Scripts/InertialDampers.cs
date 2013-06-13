using UnityEngine;
using System.Collections;

// Sets player's drag with mousewheel input.
public class InertialDampers : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		 float adjust = Input.GetAxis("Mouse ScrollWheel");
		rigidbody.drag = Mathf.Max(0, rigidbody.drag + adjust);
	}
}
