using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player.transform.position.x - 6f);
        if (GameController.clickNumber < 5) transform.position = new Vector3(Player.transform.position.x - 6f, Player.transform.position.y + 2, 0);//一開始鏡頭外
        if (GameController.clickNumber >= 6)//6小精靈出現慢移
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x - 1.3f, 0.003f), Player.transform.position.y + 2, 0);
        if((Step)GameController.step >= Step.Run)
            transform.position = new Vector3( Player.transform.position.x-1.3f, Player.transform.position.y+2,0);
    }
}
