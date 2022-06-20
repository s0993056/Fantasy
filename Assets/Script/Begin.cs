using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
	public TMPro.TMP_Text text0;
	public TMPro.TMP_Text text1;
	public TMPro.TMP_Text text2;
	public TMPro.TMP_Text text3;
	public TMPro.TMP_Text text4;
	public Text text;
	int i = 0;
	int j = 0;
	public float delay = 1.5f;
	public float delaydelay = 0.6f;
	float time;

	string[][] a = {
		new string[] {"��M���F�L��"
			,"�S������e���A�N��������M�C�}�@��"
			,"���O���e�@���·t"
			,"�ڬO���ӤF�H�٬O�٦b�ڤ��H" },
		new string[]{"�Q�n���ʨ���A�o�Pı����|��"
			,"�ڳo�O���F�H"
			,"�n���n�Q�_����A�o�����X����O��"
			,"���B�n�������n���K�K" },
		new string[]{"�֡K�K�H"},
		new string[]{ "�O�b�K�K�s�ڡH"
			,"���O�ڡK�K�����ӡK�K�K"
			,"�o�^�h�~��K�K"},
		new string[]{"�O��"
			,"�o�^�h�~��"
			,"�L�צp��"
			,"���o�^�h�~��"
			,"�ҥH" },
		new string[]{ "�ҥH�A�ڦA������" } };
	string[] b = { "�u ���K�K���I�v", "�u �СK�K���K�K�i�K�K�H�I�v", "�u ť�o�K�K�i�K�K�ֿ��K�K�j�H�K�K�v", "�u �п��L�ӡA�i�̤j�H �v" };
	void Update()
	{
		text0.text = a[j][0];
		if (i > 0 && a[j].Length > 1) text1.text = a[j][1];
		if (i > 1 && a[j].Length > 2) text2.text = a[j][2];
		if (i > 2 && a[j].Length > 3) text3.text = a[j][3];
		if (i > 3 && a[j].Length > 4) text4.text = a[j][4];
		if (i == 0) text0.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 1) text1.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 2) text2.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 3) text3.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 4) text4.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == a[j].Length)
		{
			text0.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
			text1.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
			text2.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
			text3.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
			text4.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
		}
		if (i == a[j].Length + 1 && j < 5)
		{
			text.text = b[j - 1];
			text.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - MathF.Abs(time)) / delay);
		}
		time += Time.deltaTime;
		if (Input.anyKeyDown)
		{
			time = delay;
			if (i == a[j].Length && j > 0&&j<5)
			{
				text0.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0);
				text1.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0);
				text2.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0);
				text3.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0);
				text4.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0);
				i++;
				time = 0;
			}
		}
		if (time > delay)
		{
			i++;
			time = 0;
			if (i == a[j].Length)
				time = -delaydelay;
			if (i == a[j].Length + 1)
			{
				if (j == 0) i++;
				if (j > 0) time = -delay;
				if (j == 5) SceneManager.LoadScene("Stage1");
			}
			if (i == a[j].Length + 2)
			{
				text0.text = "";
				text1.text = "";
				text2.text = "";
				text3.text = "";
				text4.text = "";
				i = 0;
				j++;
			}
		}
	}
}
