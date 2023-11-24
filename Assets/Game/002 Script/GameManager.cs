using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }
    void Awake() => Inst = this;

    [HideInInspector]
    public bool isOpening;
    [HideInInspector]
    public Damage_Fill damage_fill;

    public void GameStart()
    {
        Setting.Stage();
        Setting.Gold();

        Player_Char.Inst.Player_Move(true);
        Mob_Create.Inst.Spawn();
    }


    [Header("스테이지")]
    public int stage; //스테이지
    public int wave; //웨이브

    [HideInInspector]
    public TextMeshProUGUI stage_tmp;
    [HideInInspector]
    public GameObject point;
    [HideInInspector]
    public RectTransform[] point_transform;


    [Header("능력치")]
    public int damage; //공격력

    [Header("재화")]
    public long gold;

    [HideInInspector]
    public TextMeshProUGUI gold_tmp;
    public GameObject Money_Canvas;
}
