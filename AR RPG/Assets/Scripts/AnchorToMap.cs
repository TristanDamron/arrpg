using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorToMap : MonoBehaviour {
	void OnTriggerEnter (Collider c) {
		if (c.tag != "Player") {
			transform.parent = c.transform;
		}
	}
}
