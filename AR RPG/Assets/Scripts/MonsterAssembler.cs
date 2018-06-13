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
		foreach (Transform t in parts) {
			var limbs = new Object();
			var torso = new Object();
			var head = new Object();
			
			var name = t.name;			

			switch (name) {
				case "FrogLegs":
					limbs = Resources.Load("FrogLegs");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;
				case "Grasshopper":
					limbs = Resources.Load("Grasshopper");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;
				case "RobotLegs":
					limbs = Resources.Load("RobotLegs");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;					
				case "Tentacle":
					limbs = Resources.Load("Tentacle");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;					
				case "Unicycle":
					limbs = Resources.Load("Unicycle");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;					
				case "Levitation":
					limbs = Resources.Load("Levitation");	
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();
					AddLimbs(limbs);
					break;										
				case "RobotTorso":
					torso = Resources.Load("RobotTorso");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Gameboy":
					torso = Resources.Load("Gameboy");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Clock":
					torso = Resources.Load("Clock");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Apple":
					torso = Resources.Load("Apple");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Battery":
					torso = Resources.Load("Battery");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "PlushToy":
					torso = Resources.Load("PlushToy");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Bug":
					torso = Resources.Load("Bug");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Urinalcake":
					torso = Resources.Load("UrinalCake");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Toaster":
					torso = Resources.Load("Toaster");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;
				case "Cookie":
					torso = Resources.Load("Cookie");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddTorso(torso);
					break;					
				case "Butterfly":
					head = Resources.Load("Butterfly");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;
				case "GIJimmy":
					head = Resources.Load("GIJimmy");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;	
				case "RobotHead":
					head = Resources.Load("RobotHead");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;									
				case "Brain":
					head = Resources.Load("Brain");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;					
				case "Popsicle":
					head = Resources.Load("Popsicle");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;					
				case "Fish":
					head = Resources.Load("Fish");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;					
				case "FrogHead":
					head = Resources.Load("FrogHead");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;					
				case "Doll":
					head = Resources.Load("Doll");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;
				case "InvisibleMan":
					head = Resources.Load("InvisibleMan");
					_monsterRig.GetComponentInChildren<ParticleSystem>().Play();					
					AddHead(head);				
					break;					
				case "Rabbit":
					head = Resources.Load("Rabbit");
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
		AddLeftArm(limbs);
		AddRightArm(limbs);
		AddRightLeg(limbs);
		AddLeftLeg(limbs);
	}

	private void AddLeftArm(Object limbs) {
		var larm = _bones.Find(trans => trans.name == "LArm_Anchor");
		var lforearm = _bones.Find(trans => trans.name == "LForeArm_Anchor");
		var lhand = _bones.Find(trans => trans.name == "LHand_Anchor");

		var limb = (GameObject)Instantiate(limbs, _monsterRig.transform);

		var llegBones = limb.GetComponentsInChildren<Transform>();


		foreach (Transform t in llegBones) {
			if (t.name == "Joint") {
				t.parent = larm;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Mid") {
				t.parent = lforearm;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Tip") {
				t.parent = lhand;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;
			}
		}				
	}

	private void AddRightArm(Object limbs) {
		var rarm = _bones.Find(trans => trans.name == "RArm_Anchor");
		var rforearm = _bones.Find(trans => trans.name == "RForeArm_Anchor");
		var rhand = _bones.Find(trans => trans.name == "RHand_Anchor");

		var limb = (GameObject)Instantiate(limbs, _monsterRig.transform);

		var llegBones = limb.GetComponentsInChildren<Transform>();


		foreach (Transform t in llegBones) {
			if (t.name == "Joint") {
				t.parent = rarm;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Mid") {
				t.parent = rforearm;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Tip") {
				t.parent = rhand;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;
			}
		}				
	}

	private void AddRightLeg(Object limbs) {
		var rleg = _bones.Find(trans => trans.name == "RLeft_Anchor");
		var rshin = _bones.Find(trans => trans.name == "RShin_Anchor");
		var rfoot = _bones.Find(trans => trans.name == "RFoot_Anchor");

		var limb = (GameObject)Instantiate(limbs, _monsterRig.transform);

		var llegBones = limb.GetComponentsInChildren<Transform>();


		foreach (Transform t in llegBones) {
			if (t.name == "Joint") {
				t.parent = rleg;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Mid") {
				t.parent = rshin;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Tip") {
				t.parent = rfoot;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;
			}
		}				
	}

	private void AddLeftLeg(Object limbs) {
		var lleg = _bones.Find(trans => trans.name == "LLeft_Anchor");
		var lshin = _bones.Find(trans => trans.name == "LShin_Anchor");
		var lfoot = _bones.Find(trans => trans.name == "LFoot_Anchor");

		var limb = (GameObject)Instantiate(limbs, _monsterRig.transform);

		var llegBones = limb.GetComponentsInChildren<Transform>();


		foreach (Transform t in llegBones) {
			if (t.name == "Joint") {
				t.parent = lleg;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Mid") {
				t.parent = lshin;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;				
			} else if (t.name == "Tip") {
				t.parent = lfoot;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;
			}
		}				
	}

	void Update() {
		Assemble();
	}
}
