using UnityEngine;
using System.Collections;

public class ChangeCrossHair : MonoBehaviour {
	
	public Texture crosshair;
	public Texture crosshair2;
	private GUITexture gui;

	void Start () {
	
	}
	
	void Update () {
		gui = GetComponent<GUITexture>();
		Ray screenRay= Camera.main.ScreenPointToRay( 
			new Vector3(Camera.main.pixelWidth/2,Camera.main.pixelHeight/2 ));
	    RaycastHit hitInfo;
		// TODO Figure out how to detect only ships
		int layerMask = 1 << 9;
	    //Grab the information we need
	    if(Physics.Raycast( screenRay, out hitInfo, Mathf.Infinity, layerMask)){
			gui.texture = crosshair2;
		}else{
			gui.texture = crosshair;
		}
	}
}
