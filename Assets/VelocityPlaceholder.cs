using UnityEngine;
using System.Collections;

public class VelocityPlaceholder : VelocityController {
	
	public Vehicle vehicle;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void onEnable(){
		GetComponent<AutonomousVehicle>().enabled = true;
	}
	
	void onDisable(){
		GetComponent<Vehicle>().enabled = false;
	}
	
	void onDestroy(){
		Object.Destroy(GetComponent<Vehicle>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
