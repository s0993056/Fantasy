using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    public float speed = 0f;//0.3小精靈///1平時
    float playerY;
    Vector2 playerPos0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.i < 6) speed = 0;
        else if (GameController.i ==6) speed = 0.3f;
        playerPos0 = Player.transform.position;
        if (playerPos0.y < 9.5) playerY = 9.5f;
        else playerY = playerPos0.y;
        transform.position =new Vector3(Mathf.Lerp(transform.position.x,playerPos0.x,0.002f* speed), 
            Mathf.Lerp(transform.position.y, playerY, 0.01f* speed),-1);
    }
}
