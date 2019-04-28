using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		GameObject.Find("Health").GetComponent<Text>().text = PlayerController.health + "";
		GameObject.Find("BurnPrice").GetComponent<Text>().text = (BulletControl.basePrice + 3 * BulletControl.burn) + "";
		GameObject.Find("DmgPrice").GetComponent<Text>().text = (BulletControl.basePrice + 3 * BulletControl.dmgUp) + "";
		GameObject.Find("HomingPrice").GetComponent<Text>().text = (BulletControl.basePrice + 3 * BulletControl.homing) + "";
		GameObject.Find("KnockbackPrice").GetComponent<Text>().text = (BulletControl.basePrice + 3 * BulletControl.knock) + "";
		GameObject.Find("PiercingPrice").GetComponent<Text>().text = (BulletControl.basePrice + 3 * BulletControl.piercing) + "";
		GameObject.Find("ShockPrice").GetComponent<Text>().text = (BulletControl.basePrice + 3 * BulletControl.shock) + "";
		GameObject.Find("FinalPrice").GetComponent<Text>().text = PlayerController.health + "";
	}

	public void setPrice(int index)
	{
		if (index == 3)
		{
			BulletControl.burn++;
		}
		if (index == 1)
		{
			BulletControl.dmgUp++;
		}
		if (index == 2)
		{
			BulletControl.homing++;
		}
		if (index == 4)
		{
			BulletControl.knock++;
		}
		if (index == 0)
		{
			BulletControl.piercing++;
		}
		if (index == 5)
		{
			BulletControl.shock++;
		}
	}
}
