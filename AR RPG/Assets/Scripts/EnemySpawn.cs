using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	[SerializeField]
	private List<GameObject> _enemies;
	private int _enemyCount;
	private DataHolder _data;

	void Start() {
		_data = GameObject.Find("Data Holder").GetComponent<DataHolder>();
		InvokeRepeating("SpawnEnemy", 20f, 20f);				
	} 

	void Update () {
		if (_enemyCount >= 3) {
			CancelInvoke("SpawnEnemy");
		}
	}

	public void SpawnEnemy() {
		var enemy = _enemies[(int)Random.Range(0, _enemies.Count)];
		_enemyCount++;
		var position = new Vector3 (transform.position.x + Random.Range(-40, 40), transform.position.y, transform.position.z + Random.Range(-40, 40));
		Instantiate(enemy, position, transform.rotation);			
		Handheld.Vibrate();					
	}
}
