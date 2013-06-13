using UnityEngine;
using System.Collections;

// Specialized controller that toggles 4 lights in sequence.
public class LandingLights : MonoBehaviour {
	
	public Transform [] lights;
	private Timer timer;
	private int lightNum = 0;
	
	void Start () {
		timer = GetComponent<Timer>();
	}
	
	// TODO: This seems off in one of the platforms.
	void Update () {
		if(timer.IsPaused()) {
			lights[lightNum].GetComponentInChildren<Light>().enabled = false;
			lightNum = (lightNum + 1) % 4;
			lights[lightNum].GetComponentInChildren<Light>().enabled = true;
			timer.Set ();
		}
	}
}
