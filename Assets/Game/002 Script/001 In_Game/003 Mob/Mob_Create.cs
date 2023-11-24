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
        int max_length = Pf_Mob[GameManager.Inst.stage - 1].Length;
        GameObject pf = Pf_Mob[GameManager.Inst.stage - 1][Random.Range(0, max_length)];

        var obj = Instantiate(pf, transform);
    }
}
