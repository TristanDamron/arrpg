﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSpin : MonoBehaviour {
	void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * 10f);
	}
}
