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
    float t=0;
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
            Image(1);
            _Text.text = "";
        }
    }
}
enum Step
{
    Begin, Run, Jump, Attcak
}