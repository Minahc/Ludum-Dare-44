using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int currentLevel=1;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            currentLevel++;
            spawn();
        }
    }

    public void spawn() {
        for (int i = 0; i < Mathf.Pow(-currentLevel,1/3); i++) Instantiate(enemies[0]);
        for (int i = 0; i < 2; i++) Instantiate(enemies[1]);
        for (int i = 0; i < Mathf.Pow(currentLevel,1/4) -1; i++) Instantiate(enemies[3]);
        for (int i = 0; i < 20- ((Mathf.Pow(-currentLevel, 1 / 3)) + (Mathf.Pow(currentLevel, 1 / 4)) +2); i++) Instantiate(enemies[2]);
    }
}
