using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary 
{
public readonly static string[] diary = new string[] {
//---------------------------------------------------------
$@"之前的紀錄在與大塊頭的戰鬥遺失了，裝備也都壞了，
小精靈和我好不容易才脫離，只好重新記錄。
幾天前我正常的回家休息，結果早上醒來就在異世界了。
然後小精靈突然冒出來說我是勇者，但我只是普通人啊。
我問小精靈回去原本世界的方法，結果他說
離開異世界的方法只有魔王知道，大概要戰鬥。
我怎麼會遇到這麼恐怖的事啊。
",//Conversation("act","walk")  0
	$@"魔物沒想像中難對付，有小精靈幫忙戰鬥，
事情比想像中還順利，不過還是要變得更強才行，
這樣才能對付之前的大塊頭和魔王。
一定可以回到原本的世界，一定沒問題的！
" ,//Conversation("act", "end")  1
	$@"剛才有種奇怪的感覺，好像受了重傷。
明明身上沒有傷口，體力也很充沛。
偏偏就是有這奇怪的感覺，而且覺得有種似曾相識的感覺。
或許是在叫我小心一點吧。
",//Dead 2
	$@"跟剛來的時候比，戰鬥能力強了許多，
也擊敗了不少魔物，感覺自己變強了……
我沒想變強阿，我想趕快回去。
",// powwer 3
   };
}
