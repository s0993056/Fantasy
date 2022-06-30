using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryController : MonoBehaviour
{
    [SerializeField]
    GameObject left;
    [SerializeField]
    GameObject right;
    [SerializeField]
    Text page;
    [SerializeField]
    TMPro.TMP_Text text;
    List<string> diary;
        int nowpage;
    int clickNumber = 80;///////////////
    void Awake()
    {
        if (clickNumber > 30)
            diary = new List<string> {  Diary.diary[0]};
        if (clickNumber > 70)
            diary.Add( Diary.diary[1]);
        left.SetActive(false);
        right.SetActive(false);

    }

    void show(int nowpage)
    {
        if (diary == null) return;
        if (diary != null&&nowpage==0)
        {
            nowpage = 1;
        }
            text.text = diary[nowpage-1];
            page.text = $"{nowpage}";
            if (diary.Count > nowpage)
                right.SetActive(true);
        else right.SetActive(false);
        if ( nowpage>1)
            left.SetActive(true);
        else left.SetActive(false);
    }
    void Update()
    {
        show(nowpage);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            nowpage++;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            nowpage--;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var s = new SaveDate() { nowpage = nowpage };
            print(s.nowpage); 
        }

    }
}
