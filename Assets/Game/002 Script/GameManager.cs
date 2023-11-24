using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }
    void Awake() => Inst = this;

    public bool isOpening;
    public Damage_Fill damage_fill;

    public void GameStart()
    {
        Player_Char.Inst.Player_Move(true);

        Mob_Create.Inst.Spawn();
    }

    public int stage; //스테이지
    public int wave; //웨이브

    public int damage; //공격력
}
