using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour {
	[SerializeField]
	private Transform _bookShelf;
	private Vector3 _targetRot;
	private MonsterAssembler _assembler;

	void Start() {
		_targetRot = _bookShelf.eulerAngles;
		_assembler = GetComponent<MonsterAssembler>();
	}

	void Update() {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		_bookShelf.rotation = Quaternion.Lerp(_bookShelf.rotation, Quaternion.Euler(_targetRot), Time.deltaTime * 10f);		
		
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1000f)) {
			if (hit.transform.tag == "Part" && Input.GetMouseButtonDown(0)) {
				// var mouth = GameObject.Find("Mouth").transform;
				_assembler.parts.Add(hit.transform);
				hit.transform.GetComponentInChildren<ParticleSystem>().Play();
				// hit.transform.gameObject.GetComponent<PartsController>().SetMoveTarget(mouth);
				Invoke("Rotate72", 1f);
			}
		}
	}

	private void Rotate72() {
		var rot = _bookShelf.eulerAngles;
		rot.y -= 72;
		_targetRot = rot;
	}
}