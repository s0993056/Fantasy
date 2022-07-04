using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
	BoxCollider2D box;
	int nowAttack = 0;
	int lastAttack=0;
	bool Attacking = false;
	float t = 0;//§ðÀ»´Á¶¡
	int damage;

	// Start is called before the first frame update
	void Awake()
	{
		box = GetComponent<BoxCollider2D>();
		box.size = new Vector2(0, 0);
			box.offset = Vector2.right * 2.51f;

	}

	// Update is called once per frame
	void Update()
	{
		damage = 1+2;
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
	}
	void OnTriggerEnter2D(Collider2D other)//§ðÀ»°»´ú
	{
		if (other.gameObject.tag == "monster" && Attacking)//////////
		{
			if(nowAttack==1) other.GetComponentInChildren<MonsterHurt>().hp-=(int)(damage*1.5f);
			if (nowAttack == 2) other.GetComponentInChildren<MonsterHurt>().hp -= damage;
			if (nowAttack == 3)
			{
				other.GetComponentInChildren<MonsterHurt>().hp -= damage * 2;
				other.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerController.LR*160, 160));
			}
		}
	}
}
