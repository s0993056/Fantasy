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
		new string[] {"突然醒了過來"
			,"沒有任何前兆，就像眼睛突然睜開一樣"
			,"但是眼前一片黑暗"
			,"我是醒來了？還是還在夢中？" },
		new string[]{"想要移動身體，卻感覺不到四肢"
			,"我這是怎麼了？"
			,"好像要想起什麼，卻撈不出任何記憶"
			,"遠處好像有個聲音……" },
		new string[]{"誰……？"},
		new string[]{ "是在……叫我？"
			,"但是我……醒不來………"
			,"得回去才行……"},
		new string[]{"是啊"
			,"得回去才行"
			,"無論如何"
			,"都得回去才行"
			,"所以" },
		new string[]{ "所以，我再次醒來" } };
	string[] b = { "「 醒……醒！」","「 請……醒……勇……人！」", "「 聽得……勇……快醒……大人……」" , "「 請醒過來，勇者大人 」" };
	// Start is called before the first frame update
	void Start()
	{

	}
	/*public string Show(int j, string a)
    {
        if (j > a.Length) j = a.Length ;
        string result="";
		for (int i = 0; i < j; i++)
		{ 
            result+= a[i]+"\n"; 
		}      
            return result;
    }*/
	// Update is called once per frame
	void Update()
	{
		text0.text = a[j][0];
		if (i > 0 && a[j].Length>1) text1.text = a[j][1];
		if (i > 1 && a[j].Length > 2) text2.text = a[j][2];
		if (i > 2 && a[j].Length > 3) text3.text = a[j][3];
		if (i > 3&& a[j].Length > 4) text4.text = a[j][4];
		if (i ==0) text0.color=new Color(text0.color.r, text0.color.g, text0.color.b,time/delay);
		if (i == 1) text1.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 2) text2.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 3) text3.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i == 4) text4.color = new Color(text0.color.r, text0.color.g, text0.color.b, time / delay);
		if (i ==a[j].Length + 1&&j<5)
		{
			text.text = b[j - 1];
			text.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - MathF.Abs(time)) / delay);
		}
		time += Time.deltaTime;
		//Debug.Log($"{j} {i}");
			if (i == a[j].Length)
			{
				text0.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay-time) / (delay+delaydelay));
				text1.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
				text2.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
				text3.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
				text4.color = new Color(text0.color.r, text0.color.g, text0.color.b, (delay - time) / (delay + delaydelay));
			
		}
		if (time > delay)
		{
			i++;
			time = 0;
			if (i == a[j].Length)
			{
				time = -delaydelay;
			}

			if (i == a[j].Length+1)
			{
				if(j==0)i++;
				if(j>0)	time = -delay;
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
