using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    string note = "2-3";
    int nowpage;
    int clickNumber = GameController.clickNumber;
    void Awake()
    {
        string[] notes= note.Split('-');
        if (notes[0]=="2")
            diary = new List<string> {  Diary.diary[0]};
        if (notes[1] == "3")
            diary.Add( Diary.diary[1]);
        left.SetActive(false);
        right.SetActive(false);
        nowpage=PlayerPrefs.GetInt("nowpage", nowpage);
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
        if (Input.GetKeyDown(KeyCode.RightArrow)&&nowpage<diary.Count)
            nowpage++;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && nowpage>1)
            nowpage--;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("nowpage",nowpage);
            SceneManager.LoadScene("Stage2");
        }

    }
}
