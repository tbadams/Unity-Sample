using UnityEngine;
using System.Collections;

// Primary enemy firing behaviour.
// Fires if target within set angle and weapons aren't on cooldown.
public class EnemyFire : TargetBehaviour {
	
	public Transform newObject;
	public Transform spawnPoint;
	public float projectileSpeed = 10.0f;
	private int fireCount = 0;
	private Transform projectile;
	private Timer timer;
	public float accuracyDegrees = 5;
	public float cooldown = 1f;
	
	void Start () {
		timer = gameObject.AddComponent("Timer") as Timer;
		timer.duration = cooldown;
   	 	timer.Set();
	}
	
	void Update () {
		Vector3 targetDelta = target.position - transform.position;
		// Get the angle between transform.forward and target delta
		var angleDiff = Vector3.Angle(transform.forward, targetDelta);
		if (angleDiff < accuracyDegrees && timer.IsPaused()) {
			timer.Set();
			projectile = Instantiate(newObject, spawnPoint.position, spawnPoint.rotation) as Transform;
			fireCount++;
			if(projectile.GetComponent<Rigidbody>()){
				projectile.rigidbody.velocity = (transform.rotation * Vector3.forward * projectileSpeed) + gameObject.rigidbody.velocity;
			} else if(projectile.GetComponentInChildren<Rigidbody>()){
				projectile.GetComponentInChildren<Rigidbody>().velocity = (transform.rotation* Vector3.forward * projectileSpeed) + gameObject.rigidbody.velocity;
			}
		
		}
	}
	
}
