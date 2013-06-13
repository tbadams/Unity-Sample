using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public double health =  10;
	public double shields = 0;
	public GameObject explosionPrefab;
	public bool exploding = false;

	void Start () {
	
	}
	
	void Update () {
		// Check if actor is dead; if so, disable AI components and initiate death sequence
		if(health <= 0 &! exploding){
			exploding = true;
			if(GetComponent<ConstantVelocity>() != null){
				Destroy(GetComponent<ConstantVelocity>());
			}
			if(GetComponent<EnemyFire>() != null){
				Destroy(GetComponent<EnemyFire>());
			}
			if(GetComponent<TurnController>() != null){
				Destroy(GetComponent<TurnController>());
			}
			GetComponent<DeathController>().Prime();
		}
	}
	
	void OnCollisionEnter( Collision collision ) {
		
		var dealsDamage = 
				collision.collider.transform.GetComponent(typeof(DealsDamage)) as DealsDamage;
		if(dealsDamage != null){
//			Debug.Log("Dealing projectile damage");
			health -= dealsDamage.damage;
		}else{
//			Debug.Log("Dealing default damage");
			health -= 1;
			// TODO make default damage a constant
		}
	}
	
}
