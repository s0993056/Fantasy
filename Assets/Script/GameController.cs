using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Conversation;
    public GameObject red;
    public GameObject crystal;
    public TMPro.TMP_Text _Text;
    public static int step = 0;
    float tt=0;
    float t = 0;
    public static int i = 0;//6小精靈出現
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
    void Start()
    {
        //Conversation= GameObject.FindWithTag("Conversation");
        Conversation.SetActive(false);
    }
    private void Image(int who)
    {
        red.SetActive(false);
        crystal.SetActive(false);
        if(who == 1) red.SetActive(true);
        if (who == 2) crystal.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        t+=Time.deltaTime;
        if (t > 7)
        {
            Conversation.SetActive(true);
            if (Input.anyKeyDown && i < a.Length-1&&i != 6)
            {
                i++;
            }
        }
		//Debug.Log(i);
		_Text.text = a[i];
		switch (i)
		{
            case 0 : Image(1); break;
            case 5: Image(2); tt = t;break;
            case 6: Conversation.SetActive(false);
                    if(t-tt>1.8)i++;
                    break;
            case 7: Image(1);  break;
            case 8: Image(2); break;
            default:break;
		}
        
    }
}
enum Step
{
    Begin, Run, Jump, Attcak
}