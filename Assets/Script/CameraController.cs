using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    [SerializeField]
    private float speed = 0f;//0.3小精靈///1平時
    float playerY;
    Vector2 playerPos0;
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") speed = 0.3f;//小精靈出現慢移
        else if (Conversation.Talk[GameController.clickNumber].Say == "walk") speed =1f;//平時
        playerPos0 = Player.transform.position;
        if (playerPos0.y < 9.5) playerY = 9.5f;//限制不看地底
        else playerY = playerPos0.y;
        //看主角
        transform.position =new Vector3(Mathf.Lerp(transform.position.x,playerPos0.x,1.2f* speed*Time.deltaTime), 
            Mathf.Lerp(transform.position.y, playerY, 6f* speed*Time.deltaTime),-1);
    }
}
