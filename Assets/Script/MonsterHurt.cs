using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHurt : MonoBehaviour
{
    #region 資料區
    [SerializeField]
    private GameObject Monster;
    [SerializeField]
    private Sprite HP0;
    [SerializeField]
    private Sprite HP1;
    [SerializeField]
    private Sprite HP2;
    [SerializeField]
    private Sprite HP3;
    [SerializeField]
    private Sprite HP4;
    [SerializeField]
    private Sprite HP5;
    [SerializeField]
    private SpriteRenderer _HP;//血量
    [SerializeField]
    private GameObject bag;
    int HP = 30;
    public int hp ;
    public int attack=10;////////// 攻擊暫時放這
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        _HP = GetComponent<SpriteRenderer>();
        _HP.sprite = HP5;
        _HP.gameObject.transform.position = new Vector2(Monster.transform.position.x, Monster.transform.position.y+2.5f);
        hp = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > (int)HP * .8) _HP.sprite = HP5;
        else if (hp > (int)HP * .6) _HP.sprite = HP4;
        else if (hp > (int)HP * .4) _HP.sprite = HP3;
        else if (hp > (int)HP * .2) _HP.sprite = HP2;
        else if (hp > 0) _HP.sprite = HP1;
        else
        {
            _HP.sprite = HP0;
            GameController.monsterNumber--;
            GameObject a= Instantiate(bag);
            a.transform.position = new Vector2(Monster.transform.position.x, Monster.transform.position.y - 2);
            Destroy(Monster);
        }
    }
}
