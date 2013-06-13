using UnityEngine;
using System.Collections;

// Makes enemies attack the player when player approaches.
public class EnemyNoticeTrigger : MonoBehaviour {
	
	public Transform target;

	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other){
		// TODO: Sort out "Player" vs. "MainCamera"
		if(other.tag.Equals("MainCamera")){
			target = other.transform;
			UpdateTargets();
		}
		
	}
	
	void Update () {
	
	}
	
	void UpdateTargets(){
		// Set each TargetBehavior to the player and activate if necessary.
		TargetBehaviour [] targetNeeders = GetComponents<TargetBehaviour>();
		foreach(TargetBehaviour comp in targetNeeders){
			comp.target = target;
			comp.enabled = (target != null);
		}
		// Also start engines.
		GetComponent<VelocityController>().enabled = (target != null);
	}
}
