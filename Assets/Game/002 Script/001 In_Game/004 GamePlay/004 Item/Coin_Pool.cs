using UnityEngine;
using UnityEngine.Pool;

public class Coin_Pool : MonoBehaviour
{
    public static Coin_Pool Inst;

    public int defaultCapacity = 10;
    public int maxPoolSize = 15;

    public GameObject Prefab;
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
            Coin_Obj obj = CreatePooledItem().GetComponent<Coin_Obj>();
            obj.Pool.Release(obj.gameObject);
        }
    }

    // ����
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(Prefab, transform);
        poolGo.GetComponent<Coin_Obj>().Pool = this.Pool;
        return poolGo;
    }

    // ���
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
        //poolGo.GetComponent<Coin_Obj>().Return_pool();
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
