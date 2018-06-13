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
	private static float _defense;


	public enum Limbs {
		Frog,
		Grasshopper,
		Robot,
		Tentacle,
		Unicycle,
		Levitation
	};

	public enum Heads {
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

	private void CalculateStats() {
		switch(_limb) {
			case Limbs.Frog:
				break;
			case Limbs.Grasshopper:
				break;			
			case Limbs.Robot:
				break;		
			case Limbs.Tentacle:
				break;			
			case Limbs.Unicycle:
				break;			
			case Limbs.Levitation:
				break;									
		}

		switch (_head) {
			case Heads.Butterfly:
				break;
			case Heads.GIJimmy:
				break;
			case Heads.Robot:
				break;
			case Heads.Brain:
				break;
			case Heads.Popsicle:
				break;
			case Heads.Fish:
				break;
			case Heads.Frog:
				break;
			case Heads.Doll:
				break;
			case Heads.InvisibleMan:
				break;
			case Heads.Rabbit:
				break;				
		}

		switch (_torso) {
			case Torsos.Robot:
				break;
			case Torsos.Gameboy:
				break;
			case Torsos.Clock:
				break;
			case Torsos.Apple:
				break;
			case Torsos.Battery:
				break;
			case Torsos.PlushToy:
				break;
			case Torsos.Bug:
				break;
			case Torsos.UrinalCake:
				break;
			case Torsos.Toaster:
				break;
			case Torsos.Cookie:
				break;				
		}

		switch (_armor) {
			case Armor.Shell:
				break;
			case Armor.Lego:
				break;
			case Armor.Mug:
				break;
			case Armor.Leaves:
				break;
			case Armor.Bubble:
				break;
			case Armor.Tube:
				break;
			case Armor.WaterGun:
				break;
			case Armor.Net:
				break;				
		}

		switch (_weapon) {
			case Weapons.Screw: 
				break;
			case Weapons.Plug: 
				break;
			case Weapons.Pencil: 
				break;
			case Weapons.Taser: 
				break;
			case Weapons.LazerSword: 
				break;
			case Weapons.Flamer: 
				break;
			case Weapons.BottleRocket: 
				break;
			case Weapons.Duster: 
				break;
			case Weapons.Glove: 
				break;
				
		}
	}
}
