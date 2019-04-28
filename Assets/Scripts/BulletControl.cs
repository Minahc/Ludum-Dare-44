using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour {
	public static int piercing = 0;
	public static int dmgUp = 0;
	public static int homing = 0;
	public static int burn = 0;
	public static int knock = 0;
	public static int shock = 0;
	public static bool final = false;

	public int enemyHit = 0;
	public static int basePrice = 10;

	// Start is called before the first frame update
	void Start() {
       
    }

    // Update is called once per frame
    void Update() {
		if (enemyHit - 1 == piercing) {
			Destroy(gameObject);
		}
    }

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			enemyHit++;
		}
	}

	public void updateVariables(int index) {
		if (index == 0) piercing++;
		if (index == 1) dmgUp++;
		if (index == 2) homing++;
		if (index == 3) burn++;
		if (index == 4) knock++;
		if (index == 5) shock++;
		if (index == 6 && GameObject.Find("-GAME LOGIC-").GetComponent<EnemySpawner>().currentLevel >= 10) final = true;
	}
}
