using TMPro;
using UnityEngine;

public class Setting
{
    public static void Stage()
    {
        int stage = GameManager.Inst.stage;
        int wave = GameManager.Inst.wave;
        TextMeshProUGUI stage_tmp = GameManager.Inst.stage_tmp;

        stage_tmp.text = "<size=30>Stage</size> " + stage.ToString() + " - " + wave.ToString();

        Marker();
    }

    static void Marker()
    {
        int wave = GameManager.Inst.wave;

        if (wave > 10)
            return;

        GameObject point = GameManager.Inst.point;
        RectTransform[] point_transform = GameManager.Inst.point_transform;

        point.transform.position = new Vector3(
            point_transform[wave - 1].position.x,
            point.transform.position.y,
            point.transform.position.z);
    }

    public static void Gold()
    {
        long gold = GameManager.Inst.gold;
        TextMeshProUGUI gold_tmp = GameManager.Inst.gold_tmp;

        gold_tmp.text = Number_Transform.Trans_str(gold);
    }
}
