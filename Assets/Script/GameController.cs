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
    public static int i = 0;//6�p���F�X�{
    string[] a = { "�o�̬O�K�K���̡H\n�ګ��|�b�o�̿��ӡH", 
        "�ӥB��B���O��K�K",
    "�o�̸Ӥ��|�O�˪L�a�H\n���|�a�I",
    "�ڬQ�ѱߤW�����^��a��ı�F\n���|�]��˪L�̡H",
    "�쩳�O���^�ưڡI�I",
    "�z�z�I���n��M�j�s�աI\n�զ��|�h�C�I",
    "",
    "�z�I����F��I",
    "�~���O�F��O�I�ڬO�p���F�աI\n�A�ש���ӤF�I",
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