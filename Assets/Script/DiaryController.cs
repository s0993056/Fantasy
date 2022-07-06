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
    string note;
    int nowpage;
    int lastpage;
	void readNote()
	{
        if(note!="")
        {
        string[] notes= note.Split('-');
        diary = new List<string> {};
            foreach (var item in notes)
            {
                diary.Add(Diary.diary[int.Parse(item)]);
            }
        lastpage = diary.Count;
		}
        else lastpage = 0;
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
    void Awake()
    {
        var a = PlayerPrefs.GetString("a", "");
        if (a != "")
        {
            note = JsonUtility.FromJson<SaveDate>(a).note;
        }
            readNote();
        left.SetActive(false);
        right.SetActive(false);
        nowpage=PlayerPrefs.GetInt("nowpage"+"a", nowpage);
    }
    void Update()
    {
        show(nowpage);
        if (Input.GetKeyDown(KeyCode.RightArrow)&&nowpage< lastpage)
            nowpage++;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && nowpage>1)
            nowpage--;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("nowpage"+"a",nowpage);
            SceneManager.LoadScene("Stage2");
        }

    }
}
