using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    int zoom = 10;
    int y = 4;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        //text.gameObject.GetComponent<Text>;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(zoom<50) zoom += 5;
            if (y < 39) y += 5;
            Camera.main.orthographicSize = (float)zoom / 2;
            transform.position = new Vector3(4, (float)y /2,-1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (y >4&&zoom<46) y -= 5;
            if (zoom > 10) zoom -= 5;
            Camera.main.orthographicSize = (float)zoom / 2;
            transform.position = new Vector3(4, (float)y /2, -1);
        }
        text.text = $"√Ë¿Y§j§p : {zoom/5}";
    }
}
