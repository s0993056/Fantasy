using System.Collections;
using System.Collections.Generic;

public class Conversation
{
	public string Who;
	public string Say;
	public Conversation(string who, string say)
	{
		Who = who;
		Say = say;
	}
    public static List<Conversation> Talk=new ()//-15
    {
		 new Conversation("red","�o�̬O�K�K���̡H\n�ګ��|�b�o�̿��ӡH"),
         new Conversation("red","�ӥB��B���O��K�K"),
         new Conversation("red","�o�̸Ӥ��|�O�˪L�a�H\n���|�a�I"),
         new Conversation("red","�ڬQ�ѱߤW�����^��a��ı�F\n���|�]��˪L�̡H"),
         new Conversation("red","�쩳�O���^�ưڡI�I"),
         new Conversation("crystal","�z�z�I���n��M�j�s�աI\n�զ��|�h�C�I"),
         new Conversation("act", "crystal"),
         new Conversation("red","�z�I����F��I"),
         new Conversation("crystal","�~���O�F��O�I�ڬO�p���F�աI\n�A�ש���ӤF�I"),
         new Conversation("crystal","�O�����j�H���ڨ����U�A����I\n�i�H�i�D�ڧA���W�r�ܡH"),
         new Conversation("red","�W�K�K�W�r�ܡH\n�ڥs�K�K�p�i"),
         new Conversation("crystal","�ڡI��ӬO�A�A�A�N�O�i�̤j�H�I"),
         new Conversation("crystal","²��ӻ��A�o�̴N�O���@�ɳ�I"),
         new Conversation("red","�M�H�ڡA��p\n���n��ť������y�o�̬O���@�ɡz���_���o���K�K"),
         new Conversation("crystal","��ڡA��褣�N���F�ܡH\n�o�̬O���@�ɳ�I"),
         new Conversation("red","�o�K�K�o�˰�\n���A����k���ڦ^�h��Ӫ��@�ɶܡH"),
         new Conversation("crystal","�ڤ����D�C"),
         new Conversation("red","�K�K�K�x�H"),
         new Conversation("crystal","���L�A�]�������Ӫ��D���^�h"),
         new Conversation("red","�o�A�n�����ڡK�K\n�x�H�]���K�̡H"),
         new Conversation("crystal","��A�����j�H���]���̴x���F���@�ɪ�����\n�ҥH���Ӫ��D�n���^�h"),
         new Conversation("red","���K�K�Ӥ��|�n�����]���a�H"),
         new Conversation("crystal","���γ�I�����j�H���u�n�μC�ݤ@�ݴN�n�F�I"),
         new Conversation("red","�����N�O�n���]�����ܡI\n�ڰ�����աI"),
         new Conversation("crystal","�o�N�]�b�ڨ��W�a�I\n�����j�H���F�A�޾ɨ����U�i�̤j�H�N�O�ڪ��ϩR�I "),
         new Conversation("red","�i�K�K�i�O�ڡK�K"),
         new Conversation("crystal","�i�̤j�H���O�Q�^�h�ܡH\n�������]���N�^���h�F�A�o�ˤ��|�x�Z�ܡH"),
         new Conversation("red","�O�K�K�O�o�˨S���K�K"),
         new Conversation("crystal","�S���D�A�ڷ|���U�i�̤j�H���I\n�O�ݧڳo�ˡA���ګܱj��I"),
         new Conversation("noImage","�ҥH�u��Q��k�����]���F\n�L�צp�󳣥����e�i"),
         new Conversation("noImage","���ఱ�b�o��\n�u��Q��k�ոլ�"),
         new Conversation("red","�]���p���F���|���U�ڡA�����w�����|�K�K�^"),
         new Conversation("red","�p���F�A�A�@�N���U�ڥ����]���ܡH"),
         new Conversation("crystal","��M�o�I��褣�N���F�ܡH\n�޾ɨ����U�i�̤j�H�N�O�ڪ��ϩR�I "),
         new Conversation("red","���§A�A�p���F�I"),
         new Conversation("crystal","���Ȯ��I"),
         new Conversation("crystal","���ڭ̥����e���a�I\n�ڷPı��e���n�����n�F��A�����w������i�̤j�H�I"),
         new Conversation("crystal","�Q�Ρ]���k��V��^�i�H�i�沾�ʳ�I"),
         new Conversation("red","��H����H"),
         new Conversation("crystal","��H"),
         new Conversation("red","��H��ť���F�ܡK�K"),
         new Conversation("noImage","�i�ϥΡ]���k��V��^���ʨ���"),
         new Conversation("act","walk"),
         new Conversation("crystal","�ڷPı��F�I\n���n�F��b���W����I"),
         new Conversation("red","�W�K�K�W���H\n�i�O�o�򰪡A�]�S���ӱ�K�K"),
         new Conversation("crystal","�ӱ�H���ݭn�ڡI\n�u�n���W�h�N�n�F�I"),
         new Conversation("red","���K�K���W�h�H\n���i��աI�o���𳣤�ڰ��F�A�����o�W�h�I"),
         new Conversation("crystal","����S���D���I\n�i�̤j�H�N���ոլݧa�I"),
         new Conversation("red","���K�K�ڥ��ոլݧa"),
        new Conversation("noImage", "�i�ϥΡ]�W��V��^���D"),
        new Conversation("act","jump"),
         new Conversation("red","�M�H�M�H\n�u�K�K�u�����W�ӤF�I"),
         new Conversation("red","�S���Τ���u��N���W����ٰ�����\n�ӥB�Pı�����O�O�K�K"),
         new Conversation("crystal","�ڴN���a�I�ϰϤ@�D��O�����˫i�̤j�H���I"),
         new Conversation("red","�O�K�K�O�o�˶ܡH\n�������گu���O���ӫi�̡H"),
         new Conversation("crystal","�i�̤j�H�֬ݨ���I�N�O�����_�c�I\n�Pı�N���n�F��b�̭��I "),
         new Conversation("act","chest"),
    };
}
