using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Damage_Obj : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public float destroy_time;
    public float speed;

    public TextMeshPro tmp;

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }

    public void Request_Return()
    {
        tmp.text = string.Format("{0:#,###}", GameManager.Inst.damage);
        Invoke("Return_pool", destroy_time);
    }

    void Return_pool()
    {
        Pool.Release(this.gameObject);
    }
}
