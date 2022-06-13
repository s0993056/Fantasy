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
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameController.clickNumber < 6) speed = 0;//一開始固定
        else if (GameController.clickNumber ==6) speed = 0.3f;//6小精靈出現慢移
        else if (GameController.clickNumber > 40) speed =1f;
        playerPos0 = Player.transform.position;

        if (playerPos0.y < 9.5) playerY = 9.5f;//限制不看地底
        else playerY = playerPos0.y;
        //看主角
        transform.position =new Vector3(Mathf.Lerp(transform.position.x,playerPos0.x,0.002f* speed), 
            Mathf.Lerp(transform.position.y, playerY, 0.01f* speed),-1);
    }
}
