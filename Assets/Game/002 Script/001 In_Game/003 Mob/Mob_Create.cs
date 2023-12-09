using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Create : MonoBehaviour
{
    public static Mob_Create Inst { get; private set; }
    void Awake() => Inst = this;

    public List<GameObject[]> Pf_Mob = new List<GameObject[]>();
    public GameObject[] Pf_Mob_1;
    public GameObject[] Pf_Mob_2;

    private void Start()
    {
        Pf_Mob.Add(Pf_Mob_1);
        Pf_Mob.Add(Pf_Mob_2);
    }

    public void Spawn()
    {
        int stage = GameManager.Inst.stage; //현 stage 수치
        int wave = GameManager.Inst.wave; //현 wave 수치

        int max_length = Pf_Mob[stage - 1].Length; //몬스터 프리팹의 리스트 길이

        GameObject pf;
        if (wave != 10) //일반몬스터
            pf = Pf_Mob[stage - 1][Random.Range(0, max_length - 1)];
        else //보스몬스터
            pf = Pf_Mob[stage - 1][max_length - 1];

        var obj = Instantiate(pf, transform);
    }
}
