using UnityEngine;
using System.Collections;

// Player's fire behavior.
public class PlayerFire : MonoBehaviour {
	
	public Transform newObject;
	public Transform spawnPoint;
	public float projectileSpeed = 10.0f;
	private int fireCount = 0;
	private Transform projectile;
	private Timer timer;
	public float cooldown = 0.2f;
	public string fireButton = "Fire1";
	
	void Start () {
		timer = gameObject.AddComponent("Timer") as Timer;
		timer.duration = cooldown;
   	 	timer.Set();
	}
	
	void Update () {
		if (Input.GetButton("Fire1") && timer.IsPaused()) {
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