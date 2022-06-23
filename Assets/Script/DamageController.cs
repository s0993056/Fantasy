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
	int AA = 0;
	int A=0;
	bool B = false;
	float t = 0;
	// Start is called before the first frame update
	void Awake()
	{
		box = GetComponent<BoxCollider2D>();
		box.size = new Vector2(0, 0);
			box.offset = Vector2.right * 2.51f;
		T1 = T.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		if (AA != PlayerController.Attacking)
		{
			box.size = Vector2.zero;
			AA = PlayerController.Attacking;
			if ((t == 0 && PlayerController.Attacking == 1) || (A == 1 && PlayerController.Attacking == 2)
				|| (A == 2 && PlayerController.Attacking == 3) || (A == 3 && PlayerController.Attacking == 1))
			{
				A = PlayerController.Attacking;
				B = true;
			}
			else B = false;
			t = 0;
		}
		if (AA > 0)
		{
			t += Time.deltaTime;
			box.size = new Vector2(2.8f, 3);
		}
		T1.sortingOrder = n;////////
	}
	void OnTriggerEnter2D(Collider2D other)//§ðÀ»°»´ú
	{
		if (other.gameObject.tag == "Finish"&&B)//////////
			n *= -1;////////////
		else if (other.gameObject.tag == "attack")
		{
			print(t + " " + PlayerController.Attacking);
		}
	}
}
