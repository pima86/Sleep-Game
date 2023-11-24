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

    #region ������Ʈ Ǯ��
    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
        OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);

        // �̸� ������Ʈ ���� �س���
        for (int i = 0; i < defaultCapacity; i++)
        {
            Damage_Obj obj = CreatePooledItem().GetComponent<Damage_Obj>();
            obj.Pool.Release(obj.gameObject);
        }
    }

    // ����
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(bulletPrefab, transform);
        poolGo.GetComponent<Damage_Obj>().Pool = this.Pool;
        return poolGo;
    }

    // ���
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
        poolGo.GetComponent<Damage_Obj>().Request_Return();
    }

    // ��ȯ
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // ����
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
    #endregion
}
