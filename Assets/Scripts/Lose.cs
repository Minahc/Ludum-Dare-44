using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		GameObject.Find("LevelCount").GetComponent<Text>().text = EnemySpawner.currentLevel + "";
	}
	public void restart(int index)
	{
		if (index == 8)
		{
			EnemySpawner.currentLevel = 1;
			PlayerController.health = 100f;
			SceneManager.LoadScene("Level");
		}
	}
}
