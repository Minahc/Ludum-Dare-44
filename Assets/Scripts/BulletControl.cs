using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour {
	public static int piercing = 0;
	public static int dmgUp = 0;
	public static int homing = 0;
	//public static int burn = 0;
	public static int knock = 0;
	public static int shock = 0;
	//public static bool final = false;

	public int enemyHit = 0;
	public float timer;
	public static bool isDestroyed = false;
	

	// Start is called before the first frame update
	void Start() {
		isDestroyed = false;
    }

    // Update is called once per frame
    void Update() {
		if (enemyHit - 1 >= piercing) {
			isDestroyed = true;
			Destroy(gameObject);
		}
		if (homing == 1 && enemyHit - 1 < piercing) {
			Vector2 direction = (ClosestEnemy().transform.position - transform.position).normalized;
			transform.GetComponent<Rigidbody2D>().velocity = direction * GameObject.Find("Player").GetComponent<PlayerController>().bulletSpeed;
		}
		timer += Time.deltaTime;
		if (timer >= 3) Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			enemyHit++;
			if (shock >= 1) {
				shockwave(transform.position, shock*2, collision.transform.GetComponent<EnemyController>());
			}
		}
		if (collision.gameObject.CompareTag("Wall")) Destroy(gameObject);
	}

	public void updateVariables(int index) {
		if (index == 0) piercing++;
		if (index == 1) dmgUp++;
		if (index == 2) homing++;
		//if (index == 3) burn++;
		if (index == 4) knock++;
		if (index == 5) shock++;
		//if (index == 6 && EnemySpawner.currentLevel >= 10) final = true;
	}

	public GameObject ClosestEnemy() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach(GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	public void shockwave(Vector3 center, float radius, EnemyController enemy) {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
		for (int i = 0; i < hitColliders.Length; i++) {
			float r = (hitColliders[i].transform.position - center).magnitude;
			float percent = r / radius;
			float closeToCenter = 1 - percent;
			closeToCenter *= closeToCenter;
			enemy.health -= closeToCenter*(dmgUp+3);
			Debug.Log(closeToCenter * (dmgUp + 1));
		}
	}
}
