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


    [Header("��������")]
    public int stage; //��������
    public int wave; //���̺�

    [HideInInspector]
    public TextMeshProUGUI stage_tmp;
    [HideInInspector]
    public GameObject point;
    [HideInInspector]
    public RectTransform[] point_transform;


    [Header("�ɷ�ġ")]
    public int damage; //���ݷ�

    [Header("��ȭ")]
    public long gold;

    [HideInInspector]
    public TextMeshProUGUI gold_tmp;
    public GameObject Money_Canvas;
}
