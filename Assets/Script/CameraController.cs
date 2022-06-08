using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    public float time = 3;
    float time1;
    Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        time1=time;
        playerPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time1 -= Time.deltaTime;
        if (time1 < 0)
        {
            playerPos = Player.transform.position;
            time1 = time;
        }
        transform.position = new Vector2(playerPos.x,playerPos.y+7.95f);
    }
}
