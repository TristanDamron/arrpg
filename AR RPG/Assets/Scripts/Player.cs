using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player {
	public int hp;
	public int defense;
	public int speed;
	public float damage;
	public int level;
	public float xp;
	public float nextLevel;
	public int defaultHp;	

	public Player(int h, int dam, int s, int d) {
		hp = h;
		defaultHp = hp;
		damage = dam;
		speed = s;
		defense = d;

		level = 1;
	}

	public float Slash() {
		return damage;
	}

 	public void RestoreHP() {
		hp = defaultHp;
	}

	public float AerialStrike() {
		return damage * Random.Range(1, 3);
	}

	public float GetXP(Enemy e) {
		return e.level * 2f;
	}

	public bool CheckLevelUp() {
		if (xp >= nextLevel) {
			xp = 0;
			level++;			
			nextLevel = level * 10;
			damage = damage * 2;
			hp = hp + 5;
			defaultHp = hp;			
			return true;
		} 

		return false;
	}
}