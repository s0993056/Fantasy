using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	#region ��ư�
	[SerializeField]
	private GameObject Talk;
	[SerializeField]
	private Sprite red;
	[SerializeField]
	private Sprite crystal;
	[SerializeField]
	private Sprite NoImage;
	[SerializeField]
	private Image _Image;
	[SerializeField]
	private TMPro.TMP_Text _Text;//��ܮ�

	[SerializeField]
	private Sprite HP0;
	[SerializeField]
	private Sprite HP1;
	[SerializeField]
	private Sprite HP2;
	[SerializeField]
	private Sprite HP3;
	[SerializeField]
	private Sprite HP4;
	[SerializeField]
	private Sprite HP5;
	[SerializeField]
	private Sprite HP6;
	[SerializeField]
	private Sprite HP7;
	[SerializeField]
	private Sprite HP8;
	[SerializeField]
	private Sprite HP9;
	[SerializeField]
	private Sprite HP10;
	[SerializeField]
	private Image _HP;//��q
	[SerializeField]
	private GameObject Player;
	public static int step { get; private set; }
	float tempTime = 0;
	float totalTime = 0;
	public static int HP = 100;
	public static int monsterNumber;//�Ǫ��ƶq(�O�_����)
	public static int clickNumber { get; private set; }
	#endregion
	void Awake()
	{
		Talk.SetActive(false);//���ù�ܮ�
		_HP.gameObject.SetActive(false);//���æ�q
		step = 0;
		//���ե� ��_���ʵe
		clickNumber = 0;//58
						//totalTime = 7;//�R��
		/* if (json != null)
		 {
			 SaveDate saveDate = JsonUtility.FromJson<SaveDate>(json);
			 //Player.transform.position = saveDate.position;
			 clickNumber = saveDate.clickNumber;
			 totalTime = saveDate.totalTime;
		 }
		 print(totalTime);*/
		//PlayerPrefs.DeleteAll();/*
			clickNumber = PlayerPrefs.GetInt("clickNumber", clickNumber);
			totalTime=PlayerPrefs.GetFloat("totalTime", totalTime);//*/
	}
	/// <summary>
	/// �����Y��
	/// </summary>
	void Image(string who)
	{
		switch (who)
		{
			case "red": _Image.sprite = red; break;
			case "crystal": _Image.sprite = crystal; break;
			default: _Image.sprite = NoImage; break;
		}
	}
	/// <summary>
	/// ��ܦ��
	/// </summary>
	void ShowHP(int hp)
	{
		if (hp > 90) _HP.sprite = HP10;
		else if (hp > 80) _HP.sprite = HP9;
		else if (hp > 70) _HP.sprite = HP8;
		else if (hp > 60) _HP.sprite = HP7;
		else if (hp > 50) _HP.sprite = HP6;
		else if (hp > 40) _HP.sprite = HP5;
		else if (hp > 30) _HP.sprite = HP4;
		else if (hp > 20) _HP.sprite = HP3;
		else if (hp > 10) _HP.sprite = HP2;
		else if (hp > 0) _HP.sprite = HP1;
		else _HP.sprite = HP0;
	}
	void Update()
	{
		//print(PlayerPrefs.GetInt("clickNumber",1001));
		totalTime += Time.deltaTime;
		if (totalTime > 7)//�_��7��
		{
			Talk.SetActive(true);
			_HP.gameObject.SetActive(false);
			//��Z/Enter����
			if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) && clickNumber < Conversation.Talk.Count - 1 && Conversation.Talk[clickNumber].Who != "act")
				clickNumber++;
		}
		if (PlayerController.events)//����w��
		{
			clickNumber++;
			PlayerController.events = false;
		}
		_Text.text = Conversation.Talk[clickNumber].Say;
		_Text.fontSize = 36;
		if (clickNumber + 1 < Conversation.Talk.Count)//�}��ʧ@�e�̫᪺���
		{
			if (Conversation.Talk[clickNumber + 1].Who == "act")
			{
				if (Conversation.Talk[clickNumber + 1].Say == "crystal")
					tempTime = totalTime;
				if (Conversation.Talk[clickNumber + 1].Say == "attack")
					monsterNumber = 1;
			}
		}
		if (Conversation.Talk[clickNumber].Who == "act")//�}��ʧ@
		{
			Talk.SetActive(false);
			if (Conversation.Talk[clickNumber].Say == "crystal")
				if (totalTime - tempTime > 1.2) clickNumber++;
			if (Conversation.Talk[clickNumber].Say == "walk")
				step = 1;
			if (Conversation.Talk[clickNumber].Say == "jump" || Conversation.Talk[clickNumber].Say == "chest")
				step = 2;
			if (Conversation.Talk[clickNumber].Say == "attack")
			{
				step = 3;
				_HP.gameObject.SetActive(true);
				//var save = new SaveDate() {position=Player.GetComponent<PlayerController>().position, clickNumber=clickNumber,totalTime=totalTime};
				//print(save.position);
				PlayerPrefs.SetInt("clickNumber", clickNumber);
				PlayerPrefs.SetFloat("totalTime", totalTime);
			}
			if (Conversation.Talk[clickNumber].Say == "end")
				SceneManager.LoadScene("Stage2");
		}
		if (clickNumber - 1 > 0)//�i�J���
		{
			if (Conversation.Talk[clickNumber - 1].Who == "act")
			{
					step = 0;
				if (Conversation.Talk[clickNumber].Say == "attack")
					PlayerPrefs.Save();
			}
		}
		if (clickNumber == 16) _Text.fontSize = 30;
		Image(Conversation.Talk[clickNumber].Who);
		ShowHP(HP);
	}
}
/// <summary>
/// �ʧ@����h��
/// </summary>
enum Step
{
	Begin, Run, Jump, Attack
}