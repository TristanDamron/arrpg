using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
	public int hp;
	public float damage;
	public float attackDelay;
	public int level;
	public GameObject model;
	public int _defaultHp;	

	public Enemy(int h, float dam, float delay, int l, GameObject m) {
		hp = h;
		damage = dam;
		attackDelay = delay;
		level = l;
		model = m;
		_defaultHp = hp;
	}

	public void RestoreHealth() {
		hp = _defaultHp;
	}

	//@TODO: This will probably need to be balanced...
	public int CalculateMoneyDrop() {
		return Random.Range(level * 10, level * 20);
	}
}
