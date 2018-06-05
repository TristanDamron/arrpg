using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerFight : MonoBehaviour {
	private Text _message;
	private PostProcessingProfile _profile;	
	private DataHolder _data;
	private bool _bloom;
	
	void Start() {
		_message = GameObject.Find("Battle Message").GetComponent<Text>();
		_profile = Camera.main.GetComponent<PostProcessingBehaviour>().profile;		
		_data = GameObject.Find("Data Holder").GetComponent<DataHolder>();
	}

	void OnTriggerEnter (Collider c) {
		if (c.tag == "Player") {
			_message.text = "WATCH OUT!";
			_bloom = true;
						
			var name = gameObject.name.Replace("(Clone)", "");
			_data.enemy = _data.enemies[name];
						
			Invoke("StartFightScene", 2f);
		}
	}

	void Update () {
		var settings = _profile.bloom.settings;		
		if (_bloom) {	
			settings.bloom.intensity = Mathf.Lerp(settings.bloom.intensity, 1000f, Time.deltaTime);			
		} 

		_profile.bloom.settings = settings;		
	}

	public void StartFightScene() {
		SceneManager.LoadScene(1);
	}
}
