using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAssembler : MonoBehaviour {
	public List<Transform> parts;
	private GameObject _monsterRig;
	private List<Transform> _bones;

	void Start () {
		parts = new List<Transform>();
		_bones = new List<Transform>();
		_monsterRig = GameObject.Find("MonsterRig");
		var b = _monsterRig.GetComponentsInChildren<Transform>();
		foreach (Transform t in b) {
			_bones.Add(t);
		}
	}

	public void Assemble() {
		var limbs = new Object();
		var torso = new Object();
		var head = new Object();
		
		foreach (Transform t in parts) {
			var name = t.name;			

			switch (name) {
				case "Limb":
					//Placeholder
					limbs = Resources.Load("Tentacle");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;
				case "Torso":
					//Placeholder				
					torso = Resources.Load("Torso");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Head":
					head = Resources.Load("Head");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;
			}
			
			parts.Remove(t);							
		}
	}

	private void AddTorso(Object torso) {
		var torsoIndex = _bones.FindIndex(trans => trans.name == "Torso_Anchor");
		var tor = (GameObject)Instantiate(torso, _bones[torsoIndex]);
	}

	private void AddHead(Object head) {
		var headIndex = _bones.FindIndex(trans => trans.name == "Head_Anchor");
		var h = (GameObject)Instantiate(head, _bones[headIndex]);
	}

	private void AddLimbs(Object limbs) {
		var llegIndex = _bones.FindIndex(trans => trans.name == "LLeg_Anchor");
		var rlegIndex = _bones.FindIndex(trans => trans.name == "RLeg_Anchor");
		var larmIndex = _bones.FindIndex(trans => trans.name == "LArm_Anchor");
		var rarmIndex = _bones.FindIndex(trans => trans.name == "RArm_Anchor");
		
		var lleg = (GameObject)Instantiate(limbs, _bones[llegIndex]);
		var rleg = (GameObject)Instantiate(limbs, _bones[rlegIndex]);
		var larm = (GameObject)Instantiate(limbs, _bones[larmIndex]);
		var rarm = (GameObject)Instantiate(limbs, _bones[rarmIndex]);
	}

	void Update() {
		Assemble();
	}
}
