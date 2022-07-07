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
	[SerializeField]
	private GameObject Camera;
	public static int step { get; private set; }
	float tempTime = 0;
	float totalTime = 0;
	string note = "";
	public static int HP = 100;
	public static int monsterNumber;//�Ǫ��ƶq(�O�_����)
	public static int clickNumber { get; private set; }
	int dead;
	public static int power;
	public static List<Weapon> weapons = new List<Weapon>();
	//string json;
	SaveDate saveDate;
	public SaveDate loadDate;
	#endregion
	void Awake()
	{
		Talk.SetActive(false);//���ù�ܮ�
		_HP.gameObject.SetActive(false);//���æ�q
		step = 0;
		saveDate = new SaveDate(); 
		Loading("a");
	}
	/// <summary>
	/// ���J
	/// </summary>
	public void Loading(string name)
	{
		var a = PlayerPrefs.GetString(name, "");/*
			"";//*/
		if (a != "")
		{
			loadDate = JsonUtility.FromJson<SaveDate>(a);
			clickNumber = loadDate.clickNumber;
			totalTime = loadDate.totalTime;
			dead = loadDate.dead;
			power = loadDate.power;
			Player.transform.position = loadDate.position;
			Camera.transform.position = loadDate.position;
			saveDate.position = loadDate.position;
		}
		else
		{
		clickNumber = 0;
		saveDate.position = new Vector2(-17, 2);
			power = 2;
		}
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
	/// <summary>
	/// �g��O
	/// </summary>
	void WriteNote(int i)
	{
		if (i == 0) note = "0";
		else note += $"-{i}";
		saveDate.note= note;
	}
	/// <summary>
	/// �s��
	/// </summary>
	void Saving(string name)//a
	{
		saveDate.clickNumber = clickNumber-1;//////////////////////////
		saveDate.totalTime = totalTime;
		saveDate.dead = dead;
		if (saveDate.position == Vector2.zero) saveDate.position = new Vector2(-17,2);
			PlayerPrefs.SetString(name,JsonUtility.ToJson(saveDate));
		PlayerPrefs.Save();
	}
	void Update()
	{
		totalTime += Time.deltaTime;
		if (totalTime > 7)//�_��7��
		{
			Talk.SetActive(true);
			_HP.gameObject.SetActive(false);
			//��Z/Enter����
			if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) 
				&& clickNumber < Conversation.Talk.Count - 1 && Conversation.Talk[clickNumber].Who != "act")
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
			{
				step = 1;
				WriteNote(0);
			}
			if (Conversation.Talk[clickNumber].Say == "jump" || Conversation.Talk[clickNumber].Say == "chest")
				step = 2;
			if (Conversation.Talk[clickNumber].Say == "attack")
			{
				step = 3;
				_HP.gameObject.SetActive(true);
				if (HP<=0)
				{
					tempTime = totalTime;
						dead++;
					if (dead == 1) WriteNote(2);
						HP = 100; 
					}
					if (totalTime-tempTime>0.5&& totalTime - tempTime < 0.6)
					{
					Player.transform.position =saveDate.position;
				}
			}
			if (Conversation.Talk[clickNumber].Say == "end")
			{
				step = 3;
				WriteNote(1);
				if (Input.GetKeyDown(KeyCode.Space)) PlayerPrefs.DeleteKey("a");
				//SceneManager.LoadScene("Stage2");
			}
		}
		if (clickNumber - 1 > 0)//�i�J���
		{
			if (Conversation.Talk[clickNumber - 1].Who == "act")
			{
				step = 0;
				if (Conversation.Talk[clickNumber - 1].Say == "chest")
					saveDate.position = Player.transform.position;
				if (Conversation.Talk[clickNumber-1].Say == "attack")
				{
					Saving("a");//////////////////////////////////////////////////////////////////////////////a
				}
			}
		}
		if (clickNumber == 16) _Text.fontSize = 30;///////�Y�p�r
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