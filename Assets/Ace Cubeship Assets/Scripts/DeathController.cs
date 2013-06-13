using UnityEngine;
using System.Collections;

// Abstract class to allow multiple ways to handle ship deaths.
public abstract class DeathController : MonoBehaviour {
	
	//Initiates destruction.
	public abstract void Prime();
}
