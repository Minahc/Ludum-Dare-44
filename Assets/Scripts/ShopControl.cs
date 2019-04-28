using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour {
	public static int basePrice = 10;
	public static bool homingClick = false;
	public int homingBasePrice = 20;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text = EnemySpawner.currentLevel + "";
		GameObject.Find("Health").GetComponent<Text>().text = PlayerController.health + "";
		//GameObject.Find("BurnPrice").GetComponent<Text>().text = (basePrice + 3 * BulletControl.burn) + "";
		GameObject.Find("DmgPrice").GetComponent<Text>().text = (basePrice + 3 * BulletControl.dmgUp) + "";
		GameObject.Find("HomingPrice").GetComponent<Text>().text = homingBasePrice + "";
		GameObject.Find("KnockbackPrice").GetComponent<Text>().text = (basePrice + 3 * BulletControl.knock) + "";
		GameObject.Find("PiercingPrice").GetComponent<Text>().text = (basePrice + 3 * BulletControl.piercing) + "";
		GameObject.Find("ShockPrice").GetComponent<Text>().text = (basePrice + 3 * BulletControl.shock) + "";
		//GameObject.Find("FinalPrice").GetComponent<Text>().text = PlayerController.health + "";

		if (homingClick) {
			GameObject.Find("HomingButton").SetActive(false);
			GameObject.Find("HomingText").SetActive(false);
			GameObject.Find("HomingHeart").SetActive(false);
			GameObject.Find("HomingPrice").SetActive(false);
		}

		}

	public void setPrice(int index)
	{
		/*if (index == 3)
		{
			PlayerController.health -= (basePrice + 3 * BulletControl.burn);
			BulletControl.burn++;
		}*/
		if (index == 1)
		{
			PlayerController.health -= (basePrice + 3 * BulletControl.dmgUp);
			BulletControl.dmgUp++;
		}
		if (index == 2)
		{
			PlayerController.health -= homingBasePrice;
			BulletControl.homing++;
			homingClick = true;
		}
		if (index == 4)
		{
			PlayerController.health -= (basePrice + 3 * BulletControl.knock);
			BulletControl.knock++;
		}
		if (index == 0)
		{
			PlayerController.health -= (basePrice + 3 * BulletControl.piercing);
			BulletControl.piercing++;
		}
		if (index == 5)
		{
			PlayerController.health -= (basePrice + 3 * BulletControl.shock);
			BulletControl.shock++;
		}
		/*if (index == 6 && EnemySpawner.currentLevel >= 10)
		{
			PlayerController.health -= PlayerController.health;
		}*/
	}

	public void nextLevel(int index) {
		if (index == 7) {
			SceneManager.LoadScene("Level");
			EnemySpawner.inShop = false;
			EnemySpawner.inLevel = true;
		}
	}
}
