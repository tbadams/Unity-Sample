using UnityEngine;
using System.Collections;

public class async_start : MonoBehaviour
{

	public GameObject scene;

	Renderer[] renderers;
	bool isLoaded;

	// Called when the level is fully loaded, ie. all the substances are generated
	void OnLevelLoaded ()
	{
		ProceduralMaterial.substanceProcessorUsage = ProceduralProcessorUsage.All;
		scene.SetActiveRecursively (true);
		
		GameObject loadingScene = GameObject.Find ("LoadingScene");
		if (loadingScene) {
			loadingScene.SetActiveRecursively (false);
		}
	}

	// Called by update loop when the level is available
	void OnUpdateLevel ()
	{
	}

	// Use this for initialization
	void Start ()
	{
		
		scene.SetActiveRecursively (false);
		renderers = Resources.FindObjectsOfTypeAll (typeof(Renderer)) as Renderer[];
		ProceduralMaterial.substanceProcessorUsage = ProceduralProcessorUsage.One;
		
		for (int i = 0; i < renderers.Length; ++i) {
			ProceduralMaterial substance = renderers[i].sharedMaterial as ProceduralMaterial;
			if (substance) {
				if (substance.HasProceduralProperty ("OldnDirty")) {
					substance.CacheProceduralProperty ("OldnDirty", true);
					substance.cacheSize = ProceduralCacheSize.NoLimit;
					substance.SetProceduralFloat ("OldnDirty", 0.01f);
				}
				
				if (!substance.isLoadTimeGenerated) {
					substance.RebuildTextures ();
				}
			}
		}
		
		isLoaded = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (!isLoaded) {
			bool isLoading = false;
			
			for (int i = 0; i < renderers.Length; ++i) {
				ProceduralMaterial substance = renderers[i].sharedMaterial as ProceduralMaterial;
				if (substance && !substance.isLoadTimeGenerated && substance.isProcessing) {
					isLoading = true;
				}
			}
			
			if (!isLoading) {
				isLoaded = true;
				OnLevelLoaded ();
			}
		} else {
			OnUpdateLevel ();
		}
	}
}
