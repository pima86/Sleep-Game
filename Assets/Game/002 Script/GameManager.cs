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

    private void Start()
    {
        gold_tmp.text = Number_Transform.Trans_str(gold);
        stage_tmp.text = "<size=30>Stage</size> " + stage.ToString() + " - " + wave.ToString();
    }

    public void GameStart()
    {
        Player_Char.Inst.Player_Move(true);
        Mob_Create.Inst.Spawn();
    }


    [Header("��������")]
    public int stage; //��������
    public int wave; //���̺�
    [HideInInspector]
    [SerializeField] TextMeshProUGUI stage_tmp;

    [Header("�ɷ�ġ")]
    public int damage; //���ݷ�

    [Header("��ȭ")]
    public long gold;

    [HideInInspector]
    [SerializeField] TextMeshProUGUI gold_tmp;
}
