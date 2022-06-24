using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
	[SerializeField]
	private GameObject T;///////////
	BoxCollider2D box;////////
	SpriteRenderer T1;///////////////
	int n = 8;////////////
	int nowAttack = 0;
	int lastAttack=0;
	bool Attacking = false;
	float t = 0;
	// Start is called before the first frame update
	void Awake()
	{
		box = GetComponent<BoxCollider2D>();
		box.size = new Vector2(0, 0);
			box.offset = Vector2.right * 2.51f;
		T1 = T.GetComponent<SpriteRenderer>();////////
	}

	// Update is called once per frame
	void Update()
	{
		if (nowAttack != PlayerController.Attacking)
		{
			box.size = Vector2.zero;
			nowAttack = PlayerController.Attacking;
			if ((t == 0 && nowAttack == 1) || (lastAttack == 1 && nowAttack == 2)
				|| (lastAttack == 2 && nowAttack == 3) || (lastAttack == 3 && nowAttack == 1))
			{
				lastAttack = nowAttack;
				Attacking = true;
			}
			else Attacking = false;
			t = 0;
		}
		if (nowAttack > 0)
		{
			t += Time.deltaTime;
			box.size = new Vector2(2.8f, 4);
		}
		T1.sortingOrder = n;////////
	}
	void OnTriggerEnter2D(Collider2D other)//§ðÀ»°»´ú
	{
		if (other.gameObject.tag == "monster" && Attacking)//////////
		{
			n *= -1;
			if(nowAttack==1) GameController.HP=10;
			if (nowAttack == 2) GameController.HP = 20;
			if (nowAttack == 3) GameController.HP = 30;
		}
	}
}
