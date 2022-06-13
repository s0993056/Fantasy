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
    "",///6
    "�z�I����F��I",
    "�~���O�F��O�I�ڬO�p���F�աI\n�A�ש���ӤF�I",
    "�O�����j�H���ڨ����U�A����I\n�i�H�i�D�ڧA���W�r�ܡH",
    "�W�K�K�W�r�ܡH\n�ڥs�K�K�p�i",
    "�ڡI��ӬO�A�A�A�N�O�i�̤j�H�I",
    "²��ӻ��A�o�̴N�O���@�ɳ�I",
    "�M�H�ڡA��p\n���n��ť������y�o�̬O���@�ɡz���_���o���K�K",
    "��ڡA��褣�N���F�ܡH\n�o�̬O���@�ɳ�I",
    "�o�K�K�o�˰�\n���A����k���ڦ^�h��Ӫ��@�ɶܡH",
    "�ڤ����D�C",
    "�K�K�K�x�H",
    "���L�A�]�������Ӫ��D���^�h",
    "�o�A�n�����ڡK�K\n�x�H�]���K�̡H",
    "��A�����j�H���]���̴x���F���@�ɪ�����\n�ҥH���Ӫ��D�n���^�h",
    "���K�K�Ӥ��|�n�����]���a�H",
    "���γ�I�����j�H���u�n�μC�ݤ@�ݴN�n�F�I",
    "�����N�O�n���]�����ܡI\n�ڰ�����աI",
    "�o�N�]�b�ڨ��W�a�I\n�����j�H���F�A�޾ɨ����U�i�̤j�H�N�O�ڪ��ϩR�I ",
    "�i�K�K�i�O�ڡK�K",
    "�i�̤j�H���O�Q�^�h�ܡH\n�������]���N�^���h�F�A�o�ˤ��|�x�Z�ܡH",
    "�O�K�K�O�o�˨S���K�K",
    "�S���D�A�ڷ|���U�i�̤j�H���I\n�O�ݧڳo�ˡA���ګܱj��I",
    "�ҥH�u��Q��k�����]���F\n�L�צp�󳣥����e�i",
    "���ఱ�b�o��\n�u��Q��k�ոլ�",
    "�]���p���F���|���U�ڡA�����w�����|�K�K�^",
    "�p���F�A�A�@�N���U�ڥ����]���ܡH",
    "��M�o�I��褣�N���F�ܡH\n�޾ɨ����U�i�̤j�H�N�O�ڪ��ϩR�I ",
    "���§A�A�p���F�I",
    "���Ȯ��I",
    "���ڭ̥����e���a�I\n�ڷPı��e���n�����n�F��A�����w������i�̤j�H�I",
    "�Q�Ρ]���k��V��^�i�H�i�沾�ʳ�I",
    "��H����H",
    "��H",
    "��H��ť���F�ܡK�K",
    "�i�ϥΡ]���k��V��^���ʨ���M���D",
    "",///42
    "�ڷPı��F�I\n���n�F��b���W����I",
    "�W�K�K�W���H\n�i�O�o�򰪡A�]�S���ӱ�K�K",
    "�ӱ�H���ݭn�ڡI\n�u�n���W�h�N�n�F�I",
    "���K�K���W�h�H\n���i��աI�o���𳣤�ڰ��F�A�����o�W�h�I",
    "����S���D���I\n�i�̤j�H�N���ոլݧa�I",
    "���K�K�ڥ��ոլݧa",
    "",///49
    "�M�H�M�H\n�u�K�K�u�����W�ӤF�I",
    "�S���Τ���u��N���W����ٰ�����\n�ӥB�Pı�����O�O�K�K",
    "�ڴN���a�I�ϰϤ@�D��O�����˫i�̤j�H���I",
    "�O�K�K�O�o�˶ܡH\n�������گu���O���ӫi�̡H",
    "�i�̤j�H�֬ݨ���I�N�O�����_�c�I\n�Pı�N���n�F��b�̭��I ",
    "",//55
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
    void redCrystal(bool red, int n,int i)//���y��n����
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
        if (totalTime > 7)//�_��7��
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
		switch (clickNumber)//��ܱ���
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