using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public bool shake;
	public float delay;

	void Update () {
		if (shake) {
			Invoke("Shake", delay);
			shake = false;
			Invoke("ResetPosition", delay + 0.05f);
		}
	}

    private void Shake()
    {
        transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(Vector3.zero.x + Random.Range(-1f, 1f), Vector3.zero.y + Random.Range(-1f, 1f), Vector3.zero.z), Time.deltaTime * 10f);
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize - 0.2f, GetComponent<Camera>().orthographicSize, Time.deltaTime * 2f);
    }

	private void ResetPosition() {
		CancelInvoke("Shake");
		transform.localPosition = Vector3.zero;
	}
}
