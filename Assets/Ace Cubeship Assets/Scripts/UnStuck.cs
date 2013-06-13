using UnityEngine;
using System.Collections;

// Attempt to fix problem of enemies getting stuck on walls/player/each other/etc.
// Enemies should notice when somethingis in front of them and back up.
// Currently gets false positives besides looking weird, suspending work on it for now.
public class UnStuck : MonoBehaviour {
	
	private float detectLength = 5.01f;
	private float stoppedTime = 2f;
	private float checkTime = 0;
	private float releaseTime = 0;
	private bool reversed = false;
	public float reverseTime = 2f;
	
	void Start () {

	}
	
	void Update () {
		VelocityController vc = GetComponent<VelocityController>();
		//TurnController tc = GetComponent<TurnController>();
		
		Ray collisRay = new Ray(transform.position,transform.rotation.eulerAngles);
		//Initializing some variables
	     RaycastHit hitInfo;
		int layerMask = 1 << 8;
		layerMask = ~layerMask;
	    //Grab the information we need
	    bool obstacleAhead = Physics.Raycast( 
			// TODO: layermask is not working.
			collisRay, out hitInfo, detectLength, layerMask);
//		Debug.Log(transform.ToString()+"obstacle="+obstacleAhead+",reversed="+reversed+",releaseTime="+
//				releaseTime+",v="+(Quaternion.FromToRotation(transform.forward,Vector3.forward))*rigidbody.velocity);
		//Vector3 localVelocity = (Quaternion.FromToRotation(transform.forward,Vector3.forward))*rigidbody.velocity;
//		Debug.Log("obstacle="+obstacleAhead+",reversed="+reversed+",releaseTime="+
//				releaseTime+",timeTilCheck="+(checkTime-Time.time)+",time="+Time.time);
		if(releaseTime <= Time.time && obstacleAhead ){
			if(checkTime <= 0){
				checkTime = Time.time + stoppedTime;
			}else if (checkTime <= Time.time){
				checkTime = 0;
				releaseTime = Time.time + reverseTime;
				vc.speed = -vc.speed;
				reversed = true;
			}
		}else if(releaseTime <= Time.time && reversed){
			reversed = false;
			vc.speed = -vc.speed;
		}else if(checkTime <= Time.time && checkTime != 0){
			checkTime = 0;	
		}
		
	
	}
}
