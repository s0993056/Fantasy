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
		 new Conversation("red", "這裡是……？"),
         new Conversation("crystal", "啊！醒來了！\n還好嗎？勇者大人？"),
         new Conversation("act", "crystal"),
         new Conversation("red", "勇者大人？是在說我嗎？\n還有你是？"),
         new Conversation("crystal", "誒！勇者大人都不記得了嗎？我是小精靈啊！\n不會連自己的名字都忘記了吧？"),
         new Conversation("red", "我嗎？我是……\n我是小勇，這我還記得啦……"),
        new Conversation("red", "（好像漸漸地想起來了）"),
        new Conversation("red", "（幾天前我正常的回家休息，早上醒來就在森林了）\n（然後這個小精靈突然冒出來說我是勇者）"),
        new Conversation("red", "（雖然難以置信，但這裡好像真的是異世界）\n（也有遇到過魔物，雖然艱難但還是打敗了不少）"),
        new Conversation("red", "（雖然不知道為什麼會來到這裡，）\n（但有魔物的世界實在太危險，所以得想辦法回去……）"),
        new Conversation("red", "我記得是在找回去的辦法，對吧？"),
        new Conversation("crystal", "沒錯！太好了，勇者大人還記得這件事！\n還以為勇者大人失憶了呢！"),
         new Conversation("crystal", "想穿越世界只能找魔王們問問看，\n只有牠們才對異世界有研究"),
        new Conversation("crystal", "不過牠們脾氣都不太好，所以可能會演變成戰鬥\n但勇者大人一定沒問題的！"),
        new Conversation("red", "哈哈，你對我真有信心呢……\n不過不這麼做就回不去了"),
        new Conversation("noImage", "沒錯，無論如何都得回去才行\n不管發生什麼事都一樣"),
        new Conversation("red", "一定得回去才行……"),///16小字
         new Conversation("crystal", "勇者大人？真的沒事嗎？\n臉色好像不太好耶？"),
         new Conversation("red", "嗯？我沒事喔，不用擔心"),
         new Conversation("crystal", "那就好，這幾天一直在趕路和戰鬥\n勇者大人也應該很累了，才在這裡睡了很久"),
         new Conversation("crystal", "而且裝備都被之前出現的大塊頭給弄壞了\n我的魔力也消耗了很多，現在只能用一些簡單的魔法"),
         new Conversation("red", "沒事的小精靈，你已經幫我很多了\n裝備只要再找就有……應該吧？"),
         new Conversation("crystal", "沒問題！就交給我吧！\n我一定會找到豪華寶箱的！"),
         new Conversation("red", "那就拜託你囉！\n我們先繼續往前吧，希望這裡沒有太多魔物"),
         new Conversation("crystal", "收到！勇者大人！\n按住『左右方向鍵』可以移動喔！"),
         new Conversation("red", "嗯？"),
         new Conversation("crystal", "嗯？怎麼了嗎？"),
         new Conversation("red", "不，沒什麼……\n（偶爾會說奇怪的話呢，是在對誰說話嗎？）"),
         new Conversation("act","walk"),
        new Conversation("red", "（怎麼突然出現這麼高的牆？）\n（都高過我的頭了，剛剛明明還沒有啊？）"),
        new Conversation("crystal", "我感覺到了！\n有好東西在那上面喔！"),
         new Conversation("red", "上面嗎？突然就出現比人高的牆，上面還有寶箱……\n這裡果然是異世界呢"),
         new Conversation("crystal", "咦？勇者大人還不相信嗎？"),
         new Conversation("red", "不是啦，只是感慨一下\n以前只會在遊戲裡才看的到這種情況"),
         new Conversation("red", "總之，你剛剛說上面有好東西對吧？"),
         new Conversation("crystal", "絕對沒錯！我的直覺告訴我上面一定有寶箱！\n可是，勇者大人沒問題嗎？才剛恢復沒多久……"),
         new Conversation("red", "應該沒問題，我試試看！"),
         new Conversation("crystal", "那就按『上方向鍵』試試看吧！"),
         new Conversation("act","jump"),
         new Conversation("red", "嗯，看來沒什麼問題！"),
         new Conversation("crystal", "看來勇者大人應該恢復得差不多了\n這種程度的牆是難不倒勇者大人的！"),
         new Conversation("red", "「因為能跳上牆所以是勇者」\n這樣說總覺得心情複雜……"),
         new Conversation("crystal", "啊！勇者大人快看那邊！就是那個寶箱！\n感覺就有好東西在裡面！"),
         new Conversation("crystal", "前面還有斷層，要小心不要摔下去喔！"),
         new Conversation("red", "嗯，我知道"),
        new Conversation("act","chest"),
        new Conversation("red", "啊，前面那是！"),
        new Conversation("crystal", "是魔物呢！"),
         new Conversation("red", "魔物……看起來應該是小型魔物吧？"),
         new Conversation("crystal", "沒錯，只是普通到不能再普通的小魔物\n只要用這把劍痛打一頓就好啦！"),
         new Conversation("red", "應該不會突然變形變大吧？"),
         new Conversation("crystal", "不會啦！正好勇者大人剛恢復過來\n不正適合用來練手嗎？"),
         new Conversation("crystal", "按下『D鍵』就會施展攻擊\n連按會使出連擊"),
         new Conversation("crystal", "把敵人的血量歸零就可以打倒敵人\n反過來說自己的血量歸零就輸了"),
         new Conversation("crystal", "怎麼樣？很簡單吧！"),
         new Conversation("red", "用說的當然簡單啊……\n如果我輸了會死嗎？"),
         new Conversation("crystal", "不知道耶？不過應該沒問題吧！\n畢竟是勇者大人！"),
        new Conversation("red", "這種地方就很隨便呢……"),
        new Conversation("act", "attack"),
    };
}
