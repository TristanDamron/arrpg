using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	public Enemy enemy;
	[SerializeField]
	private bool _attacking;	
	[SerializeField]
	private Text _message;
	[SerializeField]
	private Slider _hpSlider;
	[SerializeField]
	private Slider _timer;
	private Animator _animator;		
	[SerializeField]
	private Animator _meshAnimator;
	private DataHolder _data;
	private bool _freeze;

	void Start() {
		//Initialize variables
		_animator = GetComponent<Animator>();		
		_data = GameObject.Find("Data Holder").GetComponent<DataHolder>();

		//Instantiate and position the enemy model to the primative
		GameObject m = Instantiate(_data.enemy.model);
		m.transform.SetParent(transform);
		m.transform.localPosition = m.transform.position;

		_meshAnimator = gameObject.transform.GetChild(1).GetComponent<Animator>();

		//Set slider values
		_hpSlider.maxValue = _data.enemy.hp;
		_timer.maxValue = _data.enemy.attackDelay;
		_timer.value = 0f;
	}

	void Update() {
		_hpSlider.value = _data.enemy.hp;

		if (!_freeze)
			_timer.value += Time.deltaTime;

		if (_data.enemy.hp <= 0) {
			_meshAnimator.Play("Death");
			_message.text = "VICTORY!";
			_freeze = true;
			Invoke("LoadMapScene", 5f);
		} else if (_data.player.hp <= 0) {
			_freeze = true;
		}

		if (_timer.value >= _data.enemy.attackDelay) {
			var roll = Random.Range(1,6);
			if (roll < 2) {
				_animator.Play("Dodge");				
			} else {
				_animator.Play("Attack");
				_meshAnimator.Play("Attack");
			}
			
			_timer.value = 0f;
			_attacking = true;
			Invoke("StartIdleAnimation", 1f);
		}
	}

	void OnTriggerEnter (Collider c) {
		if (c.tag == "Player" && _attacking) {
			Camera.main.GetComponent<CameraController>().shake = true;				
			Camera.main.GetComponent<CameraController>().delay = 0f;										
			var d = _data;
			d.player.hp -= (int)d.enemy.damage - d.player.defense;
		}
	}

	public void StartIdleAnimation() {
		_animator.Play("Idle");
		_meshAnimator.Play("Idle");		
		_attacking = false;
	}

	public void LoadMapScene() {
		_data.enemy.RestoreHealth();
		_data.SaveData();
		SceneManager.LoadScene(0);	
	}
}
