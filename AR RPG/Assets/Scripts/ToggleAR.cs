using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ToggleAR : MonoBehaviour {
	public UnityARCameraManager manager;
	public UnityARVideo video;
	public bool ar;

	void Awake() {
		Toggle();
	}

	public void Toggle() {
		ar = !ar;
		manager.enabled = ar;
		video.enabled = ar;

		if (ar) {
			Camera.main.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
		}
		else {
			Camera.main.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
			Camera.main.transform.parent.position = Vector3.zero;
			Camera.main.transform.parent.rotation = Quaternion.identity;
		}

	}
}
