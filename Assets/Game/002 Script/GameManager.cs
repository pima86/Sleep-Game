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
        GameManager.Inst.Stage_Canvas.SetActive(false);
        GameManager.Inst.Money_Canvas.SetActive(false);

        //나중에 세이브파일을 통해 로드할 수 있도록
        WAVE = 1;
    }

    public void GameStart()
    {
        Setting.Stage();
        Setting.Gold();

        Player_Char.Inst.Player_Move(true);
        Mob_Create.Inst.Spawn();
    }


    [Header("스테이지")]
    public int stage; //스테이지
    public int wave {
        set
        {
            if (value > 10)
            {
                stage++;
                WAVE = 1;
            }
            else
                WAVE = value;
        }
        get
        {
            return WAVE;
        }
    }int WAVE; //웨이브

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
    public GameObject Stage_Canvas;
    public GameObject Money_Canvas;
}
