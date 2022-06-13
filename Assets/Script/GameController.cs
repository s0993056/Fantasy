using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject Conversation;
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
    public static int clickNumber { get; private set; } //6小精靈出現
    string[] a = { "這裡是……哪裡？\n我怎麼會在這裡醒來？", 
        "而且到處都是樹……",
    "這裡該不會是森林吧？\n不會吧！",
    "我昨天晚上明明回到家睡覺了\n怎麼會跑到森林裡？",
    "到底是怎麼回事啊！！",
    "哇哇！不要突然大叫啦！\n耳朵會痛耶！",
    "",
    "哇！什麼東西！",
    "才不是東西呢！我是小精靈啦！\n你終於醒來了！",
    };
    // Start is called before the first frame update
    void Awake()
    {
        Conversation.SetActive(false);//隱藏對話框
        step = 0;
        clickNumber = 0;
    }
    void Image(string who)//切換頭像
    {
		switch (who)
		{
            case "red": _Image.sprite = red; break;
            case "crystal": _Image.sprite = crystal; break;
            default:_Image.sprite = NoImage;break;
		}		
    }
    void redCrystal(bool red, int n)//輪流講n次話
    {
        string who1; string who2;
        if (red) { who1 = "red"; who2 = "crystal"; }
        else {who1 = "crystal"; who2 = "red"; }
		if (n%2==1) Image("who1");
        else Image("who2");
    }
    // Update is called once per frame
    void Update()
    {
        totalTime+=Time.deltaTime;
        if (totalTime > 7)//起身7秒
        {
            Conversation.SetActive(true);
            if (Input.anyKeyDown && clickNumber < a.Length-1&&clickNumber != 6)
            {
                clickNumber++;
            }
        }
		//Debug.Log(i);
		_Text.text = a[clickNumber];
		switch (clickNumber)//對話控制
        {
            case 0 : Image("red"); break;
            case 5 : Image("crystal"); tempTime = totalTime;break;
            case 6 : Conversation.SetActive(false);
                    if(totalTime-tempTime>1.8)clickNumber++;
                    break;
            case 7 : Image("red");  break;
            case 8 : Image("crystal"); break;
            default:break;
		}
        
    }
}
enum Step
{
    Begin, Run, Jump, Attcak
}