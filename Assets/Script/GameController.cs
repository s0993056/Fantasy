using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject Conversation;
    // Start is called before the first frame update
    void Start()
    {
        Conversation= GameObject.FindWithTag("Conversation");
        Conversation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
