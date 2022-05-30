using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    int zoom = 10;
    int y = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(zoom<50) zoom += 5;
            if (y < 34) y += 5;
            Camera.main.orthographicSize = (float)zoom / 2;
            transform.position = new Vector3(4, (float)y /2,-1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (y >4&&zoom<41) y -= 5;
            if (zoom > 10) zoom -= 5;
            Camera.main.orthographicSize = (float)zoom / 2;
            transform.position = new Vector3(4, (float)y /2, -1);
        }
    }
}
