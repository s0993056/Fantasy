using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    public float time = 3;
    float time1;
    int m=1;
    int mm = 100;
    Vector2 playerPos0;
    Vector2 playerPos1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        time1=time;
        playerPos0 = Player.transform.position;
        playerPos1 = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*time1 -= Time.deltaTime;
        m++;
        if (time1 < 0)
        {
            playerPos1= playerPos0;*/
            playerPos0 = Player.transform.position;
            /*time1 = time;
            mm=m;
            m= 1;
        }
        Debug.Log($"{mm}");*/
        transform.position =new Vector3(Mathf.Lerp(transform.position.x,playerPos0.x,0.002f), 
            Mathf.Lerp(transform.position.y, playerPos0.y,0.01f),-1);
    }
}
