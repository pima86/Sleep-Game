using UnityEngine;

public class Splash_Item
{
    public static void Coin_Shot(Vector3 pos, int price)
    {
        int amount = 10;//Random.Range(3, 12);

        for (int i = 0; i < amount; i++)
        {
            var obj = Coin_Pool.Inst.Pool.Get().GetComponent<Coin_Obj>();
            obj.transform.position = new Vector2(pos.x, 0);
            obj.price = price;

            float x = Random.Range(0.5f, 3f);
            float y = Random.Range(0.5f, 3f);

            obj.rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
        }
    }
}
