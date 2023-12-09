using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_Char : MonoBehaviour
{
    public static Player_Char Inst { get; private set; }
    void Awake() => Inst = this;

    public Rigidbody2D rigid;
    public Animator anim;
    public float speed;

    void Update()
    {
        if (!GameManager.Inst.isOpening)
        {
            if (transform.position.x < 0)
            {
                Player_Move(true);

                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Dash"))
                    rigid.velocity = new Vector2(speed, rigid.velocity.y);
            }
            else
            {
                rigid.velocity = Vector3.zero;

                GameManager.Inst.Stage_Canvas.SetActive(true);
                GameManager.Inst.Money_Canvas.SetActive(true);

                GameManager.Inst.GameStart();
                GameManager.Inst.isOpening = true;
            }
        }
    }

    public Mob_Char mob;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            mob = collision.GetComponent<Mob_Char>();

            Player_Move(false);
        }
    }

    public void Player_Move(bool move)
    {
        anim.SetBool("isAttack", !move);
        anim.SetBool("isDash", move);
    }
}
