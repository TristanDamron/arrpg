using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour {
	private DataHolder _data;	

	void Start () {
		_data = GameObject.Find("Data Holder").GetComponent<DataHolder>();
		// GetComponent<Text>().text = "$" + _data.player.money;
	}
}
