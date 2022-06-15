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
		 new Conversation("red","這裡是……哪裡？\n我怎麼會在這裡醒來？"),
         new Conversation("red","而且到處都是樹……"),
         new Conversation("red","這裡該不會是森林吧？\n不會吧！"),
         new Conversation("red","我昨天晚上明明回到家睡覺了\n怎麼會跑到森林裡？"),
         new Conversation("red","到底是怎麼回事啊！！"),
         new Conversation("crystal","哇哇！不要突然大叫啦！\n耳朵會痛耶！"),
         new Conversation("act", "crystal"),
         new Conversation("red","哇！什麼東西！"),
         new Conversation("crystal","才不是東西呢！我是小精靈啦！\n你終於醒來了！"),
         new Conversation("crystal","是神明大人派我來幫助你的喔！\n可以告訴我你的名字嗎？"),
         new Conversation("red","名……名字嗎？\n我叫……小勇"),
         new Conversation("crystal","啊！原來是你，你就是勇者大人！"),
         new Conversation("crystal","簡單來說，這裡就是異世界喔！"),
         new Conversation("red","誒？啊，抱歉\n剛剛好像聽見什麼『這裡是異世界』的奇妙發言……"),
         new Conversation("crystal","對啊，剛剛不就說了嗎？\n這裡是異世界喔！"),
         new Conversation("red","這……這樣啊\n那，有辦法讓我回去原來的世界嗎？"),
         new Conversation("crystal","我不知道耶"),
         new Conversation("red","………咦？"),
         new Conversation("crystal","不過，魔王們應該知道怎麼回去"),
         new Conversation("red","這你要早說啊……\n咦？魔王…們？"),
         new Conversation("crystal","對，神明大人說魔王們掌握了異世界的知識\n所以應該知道要怎麼回去"),
         new Conversation("red","那……該不會要打敗魔王吧？"),
         new Conversation("crystal","不用喔！神明大人說只要用劍問一問就好了！"),
         new Conversation("red","那不就是要跟魔王打嗎！\n我做不到啦！"),
         new Conversation("crystal","這就包在我身上吧！\n神明大人說了，引導並幫助勇者大人就是我的使命！ "),
         new Conversation("red","可……可是我……"),
         new Conversation("crystal","勇者大人不是想回去嗎？\n不打敗魔王就回不去了，這樣不會困擾嗎？"),
         new Conversation("red","是……是這樣沒錯……"),
         new Conversation("crystal","沒問題，我會幫助勇者大人的！\n別看我這樣，其實我很強喔！"),
         new Conversation("noImage","所以只能想辦法打敗魔王了\n無論如何都必須前進"),
         new Conversation("noImage","不能停在這裡\n只能想辦法試試看"),
         new Conversation("red","（剛剛小精靈說會幫助我，說不定有機會……）"),
         new Conversation("red","小精靈，你願意幫助我打敗魔王嗎？"),
         new Conversation("crystal","當然囉！剛剛不就說了嗎？\n引導並幫助勇者大人就是我的使命！ "),
         new Conversation("red","謝謝你，小精靈！"),
         new Conversation("crystal","不客氣喔！"),
         new Conversation("crystal","那我們先往前走吧！\n我感覺到前面好像有好東西，說不定能幫到勇者大人！"),
         new Conversation("crystal","利用（左右方向鍵）可以進行移動喔！"),
         new Conversation("red","嗯？什麼？"),
         new Conversation("crystal","嗯？"),
         new Conversation("red","嗯？我聽錯了嗎……"),
         new Conversation("noImage","可使用（左右方向鍵）移動角色"),
         new Conversation("act","walk"),
         new Conversation("crystal","我感覺到了！\n有好東西在那上面喔！"),
         new Conversation("red","上……上面？\n可是這麼高，也沒有樓梯……"),
         new Conversation("crystal","樓梯？不需要啊！\n只要跳上去就好了！"),
         new Conversation("red","跳……跳上去？\n不可能啦！這個牆都比我高了，怎麼跳得上去！"),
         new Conversation("crystal","絕對沒問題的！\n勇者大人就先試試看吧！"),
         new Conversation("red","唉……我先試試看吧"),
        new Conversation("noImage", "可使用（上方向鍵）跳躍"),
        new Conversation("act","jump"),
         new Conversation("red","誒？誒？\n真……真的跳上來了！"),
         new Conversation("red","沒有用什麼工具就跳上比我還高的牆\n而且感覺不怎麼費力……"),
         new Conversation("crystal","我就說吧！區區一道牆是難不倒勇者大人的！"),
         new Conversation("red","是……是這樣嗎？\n難不成我真的是那個勇者？"),
         new Conversation("crystal","勇者大人快看那邊！就是那個寶箱！\n感覺就有好東西在裡面！ "),
         new Conversation("act","chest"),
    };
}
