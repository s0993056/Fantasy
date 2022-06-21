using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    private GameObject T;
    BoxCollider2D box;
    int n = 8;
    SpriteRenderer T1;
    // Start is called before the first frame update
    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.size= new Vector2(0,0);
        T1 = T.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Attacking)
        {
            box.size = new Vector2(2.8f, 3);
            box.offset = Vector2.right * 2.51f;
        }
        else box.size = Vector2.zero;
        T1.sortingOrder = n;
    }
    void OnTriggerEnter2D(Collider2D other)//§ðÀ»°»´ú
    {
        if (other.gameObject.tag == "Finish")
            n*=-1;
    }
}
