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
    "",///6
    "哇！什麼東西！",
    "才不是東西呢！我是小精靈啦！\n你終於醒來了！",
    "是神明大人派我來幫助你的喔！\n可以告訴我你的名字嗎？",
    "名……名字嗎？\n我叫……小勇",
    "啊！原來是你，你就是勇者大人！",
    "簡單來說，這裡就是異世界喔！",
    "誒？啊，抱歉\n剛剛好像聽見什麼『這裡是異世界』的奇妙發言……",
    "對啊，剛剛不就說了嗎？\n這裡是異世界喔！",
    "這……這樣啊\n那，有辦法讓我回去原來的世界嗎？",
    "我不知道耶",
    "………咦？",
    "不過，魔王們應該知道怎麼回去",
    "這你要早說啊……\n咦？魔王…們？",
    "對，神明大人說魔王們掌握了異世界的知識\n所以應該知道要怎麼回去",
    "那……該不會要打敗魔王吧？",
    "不用喔！神明大人說只要用劍問一問就好了！",
    "那不就是要跟魔王打嗎！\n我做不到啦！",
    "這就包在我身上吧！\n神明大人說了，引導並幫助勇者大人就是我的使命！ ",
    "可……可是我……",
    "勇者大人不是想回去嗎？\n不打敗魔王就回不去了，這樣不會困擾嗎？",
    "是……是這樣沒錯……",
    "沒問題，我會幫助勇者大人的！\n別看我這樣，其實我很強喔！",
    "所以只能想辦法打敗魔王了\n無論如何都必須前進",
    "不能停在這裡\n只能想辦法試試看",
    "（剛剛小精靈說會幫助我，說不定有機會……）",
    "小精靈，你願意幫助我打敗魔王嗎？",
    "當然囉！剛剛不就說了嗎？\n引導並幫助勇者大人就是我的使命！ ",
    "謝謝你，小精靈！",
    "不客氣喔！",
    "那我們先往前走吧！\n我感覺到前面好像有好東西，說不定能幫到勇者大人！",
    "利用（左右方向鍵）可以進行移動喔！",
    "嗯？什麼？",
    "嗯？",
    "嗯？我聽錯了嗎……",
    "可使用（左右方向鍵）移動角色和跳躍",
    "",///42
    "我感覺到了！\n有好東西在那上面喔！",
    "上……上面？\n可是這麼高，也沒有樓梯……",
    "樓梯？不需要啊！\n只要跳上去就好了！",
    "跳……跳上去？\n不可能啦！這個牆都比我高了，怎麼跳得上去！",
    "絕對沒問題的！\n勇者大人就先試試看吧！",
    "唉……我先試試看吧",
    "",///49
    "誒？誒？\n真……真的跳上來了！",
    "沒有用什麼工具就跳上比我還高的牆\n而且感覺不怎麼費力……",
    "我就說吧！區區一道牆是難不倒勇者大人的！",
    "是……是這樣嗎？\n難不成我真的是那個勇者？",
    "勇者大人快看那邊！就是那個寶箱！\n感覺就有好東西在裡面！ ",
    "",//55
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
    void redCrystal(bool red, int n,int i)//輪流講n次話
    {

        string who1; string who2;
        if (red) { who1 = "red"; who2 = "crystal"; }
        else {who1 = "crystal"; who2 = "red"; }
        if(clickNumber-i-n<0&&clickNumber>=i)
        {
            if ((clickNumber - i) % 2 == 0) Image(who1);
            else if ((clickNumber - i) % 2 == 1) Image(who2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        totalTime+=Time.deltaTime;
        if (totalTime > 7)//起身7秒
        {
            Conversation.SetActive(true);
            if (Input.anyKeyDown && clickNumber < a.Length-1&&
                clickNumber != 6&& clickNumber != 42 && clickNumber != 49 && clickNumber != 55)
            {
                clickNumber++;
            }
        }
        switch (PlayerController.events)
        {
            case 1: clickNumber=43;
                    PlayerController.events = 0; break;
            case 2: clickNumber = 50;
                    PlayerController.events = 0; break;
            default:break;
        }
		_Text.text = a[clickNumber];
		switch (clickNumber)//對話控制
        {
            case 0 : Image("red"); break;
            case 5 : Image("crystal"); tempTime = totalTime;break;
            case 6 : Conversation.SetActive(false);
                    if(totalTime-tempTime>1.8)clickNumber++;
                    break;
            case 29: Image(" "); break;
            case 31: Image("red"); break;
            case 41: Image(" "); break;
            case 42: Conversation.SetActive(false);
                step = 1;break;
            case 43:step = 0; break;
            case 49: Conversation.SetActive(false);
                step = 2; break;
            case 50: Image("red");
                step = 0; break;
            case 55: Conversation.SetActive(false);
                step = 2; break;
            default:break;
		}
        redCrystal(true, 2, 7);
        redCrystal(true, 2, 10);
        redCrystal(true, 16, 13);
        redCrystal(true, 4, 32); 
        redCrystal(true, 3, 38);
        redCrystal(false, 6, 43);
        redCrystal(true, 4, 51);

    }

}
enum Step
{
    Begin, Run, Jump, Attcak
}