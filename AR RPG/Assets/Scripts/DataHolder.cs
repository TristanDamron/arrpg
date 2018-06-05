using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHolder : MonoBehaviour {
	public Player player;
	public Dictionary<string, Enemy> enemies;
	public Enemy enemy;
	public List<GameObject> models;
	public static DataHolder instance;

	void Awake() {
		DontDestroyOnLoad(gameObject);				
     	if (instance == null) {
         	instance = this;
     	} else {
         	DestroyObject(gameObject);
     	}		
		
		var masterPath = Application.persistentDataPath;
		var path = Path.Combine(masterPath, "playerData.json");

		if (File.Exists(path)) {
			var json = File.ReadAllText(path);
			var p = JsonUtility.FromJson<Player>(json);
			player = p;
		} else {
			player = new Player(5, 3, 1, 1);
			SaveData();
		}
		
		enemies = new Dictionary<string, Enemy>() 
		{
			{"Enemy", new Enemy(10, 1, 3, 1, models[0])},
			{"Fast Enemy", new Enemy(10, 1, 1, 1, models[1])},
			{"Bob", new Enemy(25, 2, 2, 2, models[2])},
			{"Sally", new Enemy(20, 4, 3, 2, models[3])},			
			{"Boss", new Enemy(40, 4, 2, 3, models[4])},						
			{"Jim", new Enemy(40, 2, 3, 4, models[5])},									
			{"Jacob", new Enemy(60, 8, 5, 4, models[6])}
		};

	}

	public void SaveData() {
		var json = JsonUtility.ToJson(player);
		var masterPath = Application.persistentDataPath;		
		var path = Path.Combine(masterPath, "playerData.json");
		File.WriteAllText(path, json);
	}
}
