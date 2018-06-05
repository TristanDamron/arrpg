using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {
	public DataHolder data;

	void Start () {
		data = GameObject.Find("Data Holder").GetComponent<DataHolder>();
	}

	void Update () {
		GetComponent<Text>().text = "Level " + data.player.level;
	}
}
