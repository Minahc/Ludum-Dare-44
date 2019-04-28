using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	public static bool inShop = false;
	public static bool inLevel = false;
	public GameObject[] enemies;
	public static int currentLevel = 1;


	public void Awake()
	{
		spawn();
	}
	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			if (!inShop) {
				SceneManager.LoadScene("Shop");
				inShop = true;
				inLevel = false;
				currentLevel++;
				if (inLevel && !inShop) {
					spawn();
				}
			}
		}
		GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text = currentLevel + "";
	}

	public void spawn() {
		float normal = Mathf.Pow(4 / 5f, currentLevel-10);
		float buff = currentLevel - 3;
		float fire = 20 - (normal + buff + 2);
		Debug.Log(normal);
		Debug.Log(buff);
		Debug.Log(fire);
		
        for (int i = 0; i<normal; i++) Instantiate(enemies[0], new Vector3(Random.Range(-19,19),Random.Range(-11,11)), Quaternion.identity);
        for (int i = 0; i< 2; i++) Instantiate(enemies[1], new Vector3(Random.Range(-19, 19), Random.Range(-11, 11)), Quaternion.identity);
        for (int i = 0; i<buff; i++) Instantiate(enemies[3], new Vector3(Random.Range(-19, 19), Random.Range(-11, 11)), Quaternion.identity);
        for (int i = 0; i< fire; i++) Instantiate(enemies[2], new Vector3(Random.Range(-19,19),Random.Range(-11,11)), Quaternion.identity);
		Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
	}
}
