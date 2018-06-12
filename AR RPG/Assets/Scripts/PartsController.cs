using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour {
	[SerializeField]
	private Transform _moveTarget;	
	[SerializeField]
	private bool _scaleDown;

	public void SetMoveTarget(Transform target) {
		_moveTarget = target;
	}

	public void MoveToBottom() {
		var bottom = GameObject.Find("Bottom").transform;
		_moveTarget = bottom;		
		_scaleDown = true;
	}

	void Update() {
		if (_moveTarget != null) {
			transform.position = Vector3.Lerp(transform.position, _moveTarget.position, Time.deltaTime);
		} 

		if (_scaleDown) {
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider c) {
		if (c.name == "Mouth") {
			MoveToBottom();
		}
	}
}
