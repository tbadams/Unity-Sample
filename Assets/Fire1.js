#pragma strict

var newObject : Transform;
var spawnPoint : Transform;
var projectileSpeed = 10.0;
private var fireCount = 0;
private var projectile: Transform;


function Update () {

	if (Input.GetButtonDown("Fire1")) {
		projectile = Instantiate(newObject, spawnPoint.position, spawnPoint.rotation);
		fireCount++;
		if(projectile.GetComponent(Rigidbody)){
			projectile.rigidbody.velocity = (transform.rotation* Vector3.forward * projectileSpeed) + gameObject.rigidbody.velocity;
		}else if(projectile.GetComponentInChildren(Rigidbody)){
			projectile.GetComponentInChildren(Rigidbody).velocity = (transform.rotation* Vector3.forward * projectileSpeed) + gameObject.rigidbody.velocity;
		}
		
	}
}