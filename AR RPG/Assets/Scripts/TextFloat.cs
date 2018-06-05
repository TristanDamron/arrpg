using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFloat : MonoBehaviour {
	public bool floatUp;

	void Update () {
		if (floatUp)
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);	
	}
}
