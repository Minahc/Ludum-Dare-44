using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Transform player;
    public float speed = 5f;
    public float health;
    public enum enemyType {
        Normal, Health, Buff, Fire
    }

    public enemyType type;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    // Update is called once per frame
    void Update() {
      if (type == enemyType.Health) {
            Vector2 direction = -(player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
      } else {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
      }
	  if (health <= 0) {
			Destroy(gameObject);
		}
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
			if (BulletControl.dmgUp == 1) {
				health -= 2;
			} else if(BulletControl.dmgUp == 2) {
				health -= 3;
			} else {
				health--;
			}
			
        }
		if (type == enemyType.Health) {
			if (collision.gameObject.CompareTag("Wall")) {
				Destroy(gameObject);	
			}
		}
    }
}
