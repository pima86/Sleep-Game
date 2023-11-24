using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    public void Mob_Heat()
    {
        //데미지 부여
        if (Player_Char.Inst.mob != null)
        {
            Player_Char.Inst.mob.Heat(GameManager.Inst.damage);
        }
    }
}
