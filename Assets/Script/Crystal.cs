using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    GameObject Player;
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (GameController.clickNumber < 2) transform.position = new Vector3(Player.transform.position.x - 6f, Player.transform.position.y + 2, 0);//�@�}�l���Y�~
        if (GameController.clickNumber >= 2)//6�p���F�X�{�C��
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x - 1.3f, 1.2f * Time.deltaTime), Player.transform.position.y + 2, 0);
        if((Step)GameController.step >= Step.Run)
            transform.position = new Vector3( Player.transform.position.x-1.3f, Player.transform.position.y+2,0);
    }
}
