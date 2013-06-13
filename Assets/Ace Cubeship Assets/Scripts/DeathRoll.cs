using UnityEngine;
using System.Collections;

// Primary DeathController for all ships.  Ship is surrounded by fire before exploding.
public class DeathRoll : DeathController {
	
	public Timer timer;
	public Transform explosionPrefab;
	public Transform dieEffectPrefab;
	private Transform dieEffect;
	private bool primed = false;
	public float time = 3;
	public float timeVar = 1;
	public float explodeChance = 1;
	 private Component[] particleEmitters;
	
	void Start () {
	}
	
	public override void Prime (){
		// Start the initial "death roll" effect.
		dieEffect = (Instantiate(dieEffectPrefab, transform.position, transform.rotation) as Transform);
		dieEffect.parent = transform;
		transform.rigidbody.angularDrag = 0;
		transform.rigidbody.drag = 0;
		// Start explosion timer.
		timer = gameObject.AddComponent("Timer") as Timer;
		timer.duration = time + Random.Range(-timeVar,timeVar);
	    timer.Set();
		primed = true;
	}
	
	void Update () {
		if(primed){
			particleEmitters = dieEffect.GetComponentsInChildren<ParticleEmitter>();
			foreach (ParticleEmitter emitter in particleEmitters) {
				emitter.worldVelocity = transform.rigidbody.velocity;
			}
			if(timer.IsPaused()){ // Explode.
			    Instantiate(explosionPrefab, transform.position, transform.rotation);
			    Destroy (gameObject);
			}
		}
	}
}
