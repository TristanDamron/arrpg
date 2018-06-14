using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
	private static Limbs _limb;
	private static Heads _head;
	private static Torsos _torso;
	private static Armor _armor;
	private static Weapons _weapon;
	private static float _hp;
	private static float _damage;
	private static int _defense;
	private static int _speed;


	public enum Limbs {
		None,
		Frog,
		Grasshopper,
		Robot,
		Tentacle,
		Unicycle,
		Levitation
	};

	public enum Heads {
		None,
		Butterfly,
		GIJimmy,
		Robot,
		Brain,
		Popsicle,
		Fish,
		Frog,
		Doll,
		InvisibleMan,
		Rabbit
	};

	public enum Torsos {
		None,
		Robot,
		Gameboy,
		Clock,
		Apple,
		Battery,
		PlushToy,
		Bug,
		UrinalCake,
		Toaster, 
		Cookie
	};

	public enum Armor {
		None,
		Shell,
		Lego,
		Mug,
		Leaves,
		Bubble,
		Tube,
		WaterGun,
		Net
	};

	public enum Weapons {
		None,
		Screw,
		Plug,
		Pencil,
		Taser,
		LazerSword,
		Flamer,
		BottleRocket,
		Duster,
		Glove
	};

	public static void SetLimb(Limbs limb) {
		_limb = limb;
	}	
	
	public static void SetTorso(Torsos torso) {
		_torso = torso;
	}		

	public static void SetHead(Heads head) {
		_head = head;
	}		

	public static void SetArmor(Armor armor) {
		_armor = armor;
	}		

	public static void CalculateStats() {
		switch(_limb) {
			case Limbs.Frog:
				_speed += 3;
				_defense -= 1;
				break;
			case Limbs.Grasshopper:
				_speed += 2;
				break;			
			case Limbs.Robot:
				_speed -= 1;
				_defense += 2;
				break;		
			case Limbs.Tentacle:
			 	_speed -= 1;
				break;			
			case Limbs.Unicycle:
				_speed += 4;
				_defense -= 2;
				break;			
			case Limbs.Levitation:
				_speed = -1;
				break;									
		}

		switch (_head) {
			case Heads.Butterfly:
				_defense += 2;
				break;
			case Heads.GIJimmy:
				break;
			case Heads.Robot:
				_defense += 1;
				break;
			case Heads.Brain:
				_defense -= 1;
				break;
			case Heads.Popsicle:
				break;
			case Heads.Fish:
				_speed += 2;
				break;
			case Heads.Frog:
				_speed += 1;
				_defense -= 1;
				break;
			case Heads.Doll:
				break;
			case Heads.InvisibleMan:
				_speed += 3;
				break;
			case Heads.Rabbit:
				break;				
		}

		switch (_torso) {
			case Torsos.Robot:
				_defense += 2;
				break;
			case Torsos.Gameboy:
				_defense += 1;
				break;
			case Torsos.Clock:
				_defense += 1;
				break;
			case Torsos.Apple:
				_defense -= 1;
				_speed += 1;
				break;
			case Torsos.Battery:
				_defense += 1;
				_speed += 2;
				break;
			case Torsos.PlushToy:
				_defense -= 2;
				_speed += 3;
				break;
			case Torsos.Bug:
				_defense -= 1;
				_speed += 2;
				break;
			case Torsos.UrinalCake:
				_defense -= 1;
				break;
			case Torsos.Toaster:
				_defense += 3;
				break;
			case Torsos.Cookie:
				_defense += 1;
				break;				
		}

		switch (_armor) {
			case Armor.Shell:
				_defense += 3;
				_speed -= 2;
				break;
			case Armor.Lego:
				_defense += 1;
				_speed -= 1;
				break;
			case Armor.Mug:
				_defense += 1;
				_speed -= 1;
				break;
			case Armor.Leaves:
				_defense += 1;
				break;
			case Armor.Bubble:
				_defense += 1;			
				break;
			case Armor.Tube:
				_defense += 2;			
				break;
			case Armor.WaterGun:
				_defense += 1;			
				break;
			case Armor.Net:
				_defense += 1;			
				break;				
		}

		switch (_weapon) {
			case Weapons.Screw: 
				_damage += 4f;
				_speed -= 2;				
				break;
			case Weapons.Plug:
				_damage += 1f;			 
				break;
			case Weapons.Pencil: 
				_damage += 5f;			
				_speed -= 2;
				break;
			case Weapons.Taser: 
				_damage += 3f;			
				break;
			case Weapons.LazerSword: 
				_damage += 3f;	
				_speed += 1;		
				break;
			case Weapons.Flamer: 
				_damage += 3f;
				break;
			case Weapons.BottleRocket: 
				_damage += 3f;			
				break;
			case Weapons.Duster: 
				_damage += 1f;			
				break;
			case Weapons.Glove: 
				_damage += 1f;			
				break;				
		}

		if (_speed < 0) {
			_speed = 0;
		}

		if (_defense <= 0) {
			_defense = 1;
		}

		_hp = _defense * 3;		
	}

	public static float GetDamage() {
		return _damage;
	}

	public static float GetHP() {
		return _hp;
	}

	public static int GetSpeed() {
		return _speed;
	}

	public static int GetDefense() {
		return _defense;
	}
}
