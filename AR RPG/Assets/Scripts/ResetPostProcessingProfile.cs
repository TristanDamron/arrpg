using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ResetPostProcessingProfile : MonoBehaviour {
	void Start () {
		var settings = Camera.main.GetComponent<PostProcessingBehaviour>().profile.bloom.settings;
		settings.bloom.intensity = 1f;
		Camera.main.GetComponent<PostProcessingBehaviour>().profile.bloom.settings = settings;		
	}
}
