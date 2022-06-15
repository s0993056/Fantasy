using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private TMPro.TMP_Text _Text;
    public static int step { get; private set; }
    float tempTime=0;
    float totalTime = 0;
    public static int clickNumber { get; private set; } 
	#endregion
	
    void Awake()
    {
        Talk.SetActive(false);//���ù�ܮ�
        step = 0;
        clickNumber = 56;
    }
    void Image(string who)//�����Y��
    {
		switch (who)
		{
            case "red": _Image.sprite = red; break;
            case "crystal": _Image.sprite = crystal; break;
            default:_Image.sprite = NoImage;break;
		}		
    }
    void Update()
    {
        totalTime+=Time.deltaTime;
        if (totalTime > 7)//�_��7��
        {
            Talk.SetActive(true);
            //�����N����
            if (Input.anyKeyDown && clickNumber < Conversation.Talk.Count-1&& Conversation.Talk[clickNumber].Who!="act")
                clickNumber++;
        }
		if (PlayerController.events!=0)//����w��
		{
            clickNumber++;
            PlayerController.events = 0;
        }
        _Text.text = Conversation.Talk[clickNumber].Say;
        if (clickNumber + 1 < Conversation.Talk.Count)//�}��ʧ@�e�̫᪺���
        {
            if (Conversation.Talk[clickNumber + 1].Who == "act")
            {
                if (Conversation.Talk[clickNumber + 1].Say == "crystal")
                    tempTime = totalTime;
            }
        }
        if (Conversation.Talk[clickNumber].Who == "act")//�}��ʧ@
        {
            Talk.SetActive(false);
            if (Conversation.Talk[clickNumber].Say == "crystal")
                if (totalTime - tempTime > 1.8) clickNumber++;
            if (Conversation.Talk[clickNumber].Say == "walk")
                step = 1;
            if (Conversation.Talk[clickNumber].Say == "jump"|| Conversation.Talk[clickNumber].Say == "chest")
                step = 2;
        }
        if(clickNumber - 1>0)//�i�J���
        {
            if (Conversation.Talk[clickNumber - 1].Who == "act")
            {
                step = 0;
            }
        }
        Image(Conversation.Talk[clickNumber].Who);
    }
}
enum Step//�ʧ@����
{
    Begin, Run, Jump, Attcak
}