using UnityEngine;
using System.Collections;

public class AsteroidField : MonoBehaviour {
	
	public Transform asteroid;
	public int numAsteroids = 100;
	public float radius = 33;
	public float minScale = 1;
	public float maxScale = 1;
	public float force = 0.1f;
	
	// Use this for initialization
	void Start () {
		for( int i = 0; i < numAsteroids; i++){
			Transform rock = Instantiate(asteroid, transform.position + Random.insideUnitSphere * radius, Random.rotation) as Transform;
			float scale = Random.Range(minScale, maxScale);
			rock.transform.localScale = new Vector3(scale,scale,scale);
			rock.rigidbody.mass *= Mathf.Pow(scale,3); 
			rock.rigidbody.AddForce(new Vector3(Random.Range (0, force),Random.Range (0, force),Random.Range (0, force)));
			rock.rigidbody.AddTorque(new Vector3(Random.Range (0, force),Random.Range (0, force),Random.Range (0, force)));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
