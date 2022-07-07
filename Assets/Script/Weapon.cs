using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	string name;
	int attack;
	int buy;
	int sold;
	public Weapon(string n, int a, int b)
	{
		name = n;
		attack = a;
		buy = b;
		sold = (int)0.6f * b;
	}
	public readonly static List<Weapon> weapons = new()
	{
		new Weapon("¼C", 3, 10),
	};
	}
