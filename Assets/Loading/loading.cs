using UnityEngine;
using System.Collections;

public class loading : MonoBehaviour
{

	public GameObject particle;
	Renderer[] renderers;

	void Start ()
	{
		
		renderers = Resources.FindObjectsOfTypeAll (typeof(Renderer)) as Renderer[];
		ProceduralMaterial.substanceProcessorUsage = ProceduralProcessorUsage.One;
		
		for (int i = 0; i < renderers.Length; ++i) {
			ProceduralMaterial substance = renderers[i].sharedMaterial as ProceduralMaterial;
			if (substance) {
				if (substance.HasProceduralProperty ("OldnDirty")) {
					substance.CacheProceduralProperty ("OldnDirty", true);
					substance.cacheSize = ProceduralCacheSize.NoLimit;
					substance.SetProceduralFloat ("OldnDirty", 0.01f);
					substance.RebuildTextures ();
				}
			}
		}
		
		Application.LoadLevelAdditiveAsync (1);
		
		// Update particle system to display particles at launch time
		for (int i = 0; i < 20; ++i)
			particle.GetComponent<ParticleEmitter> ().Simulate (i / 10.0f);
	}

	void Update ()
	{
	}
}
