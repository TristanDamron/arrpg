using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private SwipeManager _manager;
	private Animator _animator;
	[SerializeField]	
	private Slider _hpSlider;	
	private DataHolder _data;
	[SerializeField]	
	private Slider _levelUpSlider;	
	[SerializeField]
	private Text _levelUpText;		
	[SerializeField]
	private Text _moneyText;
	private Animator _meshAnimator;
	private float _xp;
	private float _earnedXp;
	private bool _freeze;
	private float _xpTimer;
	private bool _moneyDrop;

	void Start() {
		//Initialize variables
		_animator = GetComponent<Animator>();
		_data = GameObject.Find("Data Holder").GetComponent<DataHolder>();

		_meshAnimator = gameObject.transform.GetChild(0).GetComponent<Animator>();

		//Set member values
		_hpSlider.maxValue = _data.player.hp;		
		_xp = _data.player.xp;
		_earnedXp = _data.player.GetXP(_data.enemy);

		_animator.speed = _data.player.speed;
	}

	void Update () {
		_hpSlider.value = _data.player.hp;

		//These conditionals are really inefficient..
		if (_data.player.hp <= 0) {
			_meshAnimator.Play("Death");
			_freeze = true;						
			_data.player.RestoreHP();
			_manager.enabled = false;
			Invoke("LoadMapScene", 5f);		
		}

		//These conditionals are really inefficient..
		if (_data.enemy.hp <= 0) {
			_freeze = true;			
			_manager.enabled = false;
			_xpTimer += Time.deltaTime;
			_data.player.RestoreHP();			

			//Only call this once
			// if (!_moneyDrop) {
			// 	_data.player.money += _data.enemy.CalculateMoneyDrop();
			// 	_moneyDrop = true;
			// 	_moneyText.GetComponent<TextFloat>().floatUp = true;				
			// 	_moneyText.text = "$" + _data.player.money;
			// 	Invoke("ResetMoneyText", 2f);
			// }

			_levelUpSlider.gameObject.SetActive(true);
			_levelUpSlider.maxValue = _data.player.nextLevel;
			_levelUpSlider.value = Mathf.Lerp(_xp, _xp + _earnedXp, _xpTimer / 2);

			_data.player.xp = _xp + _earnedXp;

			if (_data.player.CheckLevelUp()) {				
				_levelUpText.text = "LEVEL UP!";
				_xp = _data.player.xp;
				Invoke("ResetLevelUpText", 1f);
			}
		}

		if (!_freeze) {
			var type = _manager.type;

			if (type == ShapeDetector.ShapeType.SLASH && _manager.action) {
				_animator.Play("Slash");
				_meshAnimator.Play("Attack");
				Invoke("StartIdleAnimation", 1f);
			} 
		
			if (type == ShapeDetector.ShapeType.DODGE && _manager.action) {
				_animator.Play("Dodge");
				Invoke("StartIdleAnimation", 1f);			
			}

			if (type == ShapeDetector.ShapeType.AERIAL_ATTACK && _manager.action) {
				_animator.Play("Aerial Strike");
				_meshAnimator.Play("Attack");				
				Invoke("StartIdleAnimation", 1f);			
			}
		}
		
	}

	void OnTriggerEnter (Collider c) {
		if (c.tag == "Enemy") {						
			Camera.main.GetComponent<CameraController>().shake = true;				
			Camera.main.GetComponent<CameraController>().delay = 0f;							

			var d = _data;
			var type = _manager.type;

			if (type == ShapeDetector.ShapeType.SLASH && _manager.action) {							
				d.enemy.hp -= (int)d.player.Slash();
			} 
		
			if (type == ShapeDetector.ShapeType.AERIAL_ATTACK && _manager.action) {			
				d.enemy.hp -= (int)d.player.AerialStrike();
			}			

			// if (type == ShapeDetector.ShapeType.FIRE_STRIKE && _manager.action) {			
			// 	d.enemy.hp -= (int)d.player.FireStrike();
			// }			
		}
	}

	// public void ResetMoneyText() {
	// 	_moneyText.text = "";
	// }

	public void ResetLevelUpText() {
		_levelUpText.text = "";
	}

	public void StartIdleAnimation() {
		_animator.Play("Idle");
		_meshAnimator.Play("Idle");		
	}

	public void LoadMapScene() {
		_data.enemy.RestoreHealth();
		_data.SaveData();
		SceneManager.LoadScene(0);	
	}
	
}
