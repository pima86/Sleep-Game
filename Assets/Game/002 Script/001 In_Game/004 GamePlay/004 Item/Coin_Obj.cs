using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Coin_Obj : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public int price;
    public Rigidbody2D rigid;

    void Update()
    {
        if (Player_Char.Inst.anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Dash") && rigid.velocity.y == 0)
        {
            rigid.velocity = new Vector2(-4, rigid.velocity.y);
        }
    }

    private void OnEnable()
    {
        item_eat = false;
    }

    public void Return_pool()
    {
        Pool.Release(this.gameObject);
    }

    bool item_eat = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && item_eat)
        {
            GameManager.Inst.gold += price;
            Setting.Gold();
            Return_pool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Land")
        {
            item_eat = true;
        }
    }
}
