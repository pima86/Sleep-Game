using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Damage_Font : MonoBehaviour
{
    public static Damage_Font Inst;

    public int defaultCapacity = 10;
    public int maxPoolSize = 15;

    public GameObject bulletPrefab;
    public IObjectPool<GameObject> Pool { get; private set; }

    private void Awake()
    {
        if (Inst == null)
            Inst = this;
        else
            Destroy(this.gameObject);


        Init();
    }

    #region 오브젝트 풀링
    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
        OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);

        // 미리 오브젝트 생성 해놓기
        for (int i = 0; i < defaultCapacity; i++)
        {
            Damage_Obj obj = CreatePooledItem().GetComponent<Damage_Obj>();
            obj.Pool.Release(obj.gameObject);
        }
    }

    // 생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(bulletPrefab, transform);
        poolGo.GetComponent<Damage_Obj>().Pool = this.Pool;
        return poolGo;
    }

    // 사용
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
        poolGo.GetComponent<Damage_Obj>().Request_Return();
    }

    // 반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
    #endregion
}
