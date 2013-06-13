using UnityEngine;
using System.Collections;

/// <summary>
/// created by Markus Davey 22/11/2011
/// Basic projectile script
/// Skype: Markus.Davey
/// Unity forums: MarkusDavey
/// </summary>

public class projectileScript : MonoBehaviour 
{
    public Vector3 muzzleVelocity;
    
    public float TTL;
    
    public bool isBallistic;
    public float Drag; // in metres/s lost per second.
	public double damage = 1;
    
    // Use this for initialization
    void Start () 
    {
        if (TTL == 0)
            TTL = 5;
        print(TTL);
        Invoke("projectileTimeout", TTL);
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (Drag != 0)
            muzzleVelocity += muzzleVelocity * (-Drag * Time.deltaTime);
        
        if (isBallistic)
            muzzleVelocity += Physics.gravity * Time.deltaTime;
        
        if (muzzleVelocity == Vector3.zero)
            return;
        else
            transform.position += muzzleVelocity * Time.deltaTime;
        transform.LookAt(transform.position + muzzleVelocity.normalized);
        Debug.DrawLine(transform.position, transform.position + muzzleVelocity.normalized, Color.red);
    }
    
    void projectileTimeout()
    {
        DestroyObject(gameObject);
    }
    
	void OnCollisionEnter( Collision other ) {
//		//var otherHealth = other.collider.GetComponent(Health);
//		if(other.collider.GetComponent(Health).health != null){
//			other.collider.GetComponent(Health).health -= damage;
//		}
	}
}