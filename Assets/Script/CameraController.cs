using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    [SerializeField]
    private float speed = 0f;//0.3�p���F///1����
    float playerY;
    Vector2 playerPos0;
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") speed = 0.3f;//�p���F�X�{�C��
        else if (GameController.clickNumber >= Conversation.Talk.IndexOf(Conversation("act", "walk"))) speed =1f;//����
        playerPos0 = Player.transform.position;
        if (playerPos0.y < 9.5) playerY = 9.5f;//����ݦa��
        else playerY = playerPos0.y;
        //�ݥD��
        transform.position =new Vector3(Mathf.Lerp(transform.position.x,playerPos0.x,1.2f* speed*Time.deltaTime), 
            Mathf.Lerp(transform.position.y, playerY, 6f* speed*Time.deltaTime),-1);
    }
}
