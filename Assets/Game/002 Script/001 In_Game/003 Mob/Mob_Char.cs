using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Char : MonoBehaviour
{
    public ParticleSystem parti;
    public Rigidbody2D rigid;
    public BoxCollider2D boxcollider;
    public Animator anim;

    bool isDash = true;
    public bool isBoss;

    void Update()
    {
        if (isDash)
        {
            rigid.velocity = new Vector2(-4, rigid.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDash = false;
            rigid.velocity = Vector3.zero;
        }
    }


    public int HP;
    int Max_HP;

    private void OnEnable()
    {
        Max_HP = HP;
    }

    public void Heat(int damage)
    {
        var bulletGo = Damage_Font.Inst.Pool.Get();
        bulletGo.transform.position = transform.position + new Vector3(0, boxcollider.size.y, 0);

        if (HP - damage <= 0)
        {
            HP = 0;
            GameManager.Inst.GameStart();
            Player_Char.Inst.mob = null;

            //격파 애니메이션
            parti.Play();
            rigid.AddForce(new Vector2(9,3), ForceMode2D.Impulse);
            rigid.AddTorque(30f);
            Destroy(gameObject, 1f);
        }
        else
        {
            HP -= damage;
            anim.Play("Heat", -1, 0f);
        }

        if(isBoss)
            GameManager.Inst.damage_fill.Fill_img(HP, Max_HP);
    }
}
