using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float playerSpeed = 5f;
    public float bulletSpeed = 10f;
	public static float health = 100f;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector3(x, y) * playerSpeed;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;
        transform.up = direction;
    }

    void Update() {
        if (Input.GetButtonDown("Fire")) {
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            GameObject projectile = (GameObject)Instantiate(Bullet, (Vector2)transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));   
            projectile.transform.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
		if (health <= 0) {
			SceneManager.LoadScene("Lose Screen");
		}
		GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = health+"";
    }
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			health--;
		}
	}
}
