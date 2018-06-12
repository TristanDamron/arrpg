using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleAndRotate : MonoBehaviour {
	private float _speed;
	private int _xDir;
	private int _yDir;

	void Start() {
		_speed = Random.Range(5f, 10f);
		_xDir = Random.Range(0, 2) * 2 - 1;
		_yDir = Random.Range(0, 2) * 2 - 1;		
	}

	void Update () {
		transform.Rotate(Vector3.right * _yDir, Time.deltaTime * _speed);
		transform.Rotate(Vector3.up * _xDir, Time.deltaTime * _speed);
	}
}
