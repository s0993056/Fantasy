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
    public static int clickNumber { get; private set; } //6�p���F�X�{
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
    void Awake()
    {
        Conversation.SetActive(false);//���ù�ܮ�
        step = 0;
        clickNumber = 0;
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
    void redCrystal(bool red, int n)//���y��n����
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
        if (totalTime > 7)//�_��7��
        {
            Conversation.SetActive(true);
            if (Input.anyKeyDown && clickNumber < a.Length-1&&clickNumber != 6)
            {
                clickNumber++;
            }
        }
		//Debug.Log(i);
		_Text.text = a[clickNumber];
		switch (clickNumber)//��ܱ���
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