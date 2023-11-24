using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Damage_Fill : MonoBehaviour
{
    [SerializeField] GameObject hp_canvas;
    [SerializeField] Image hp_rect;
    [SerializeField] TextMeshProUGUI hp_tmp;

    public float speed;
    float sizeDelta_Sss = 1f;
    private void Update()
    {
        if (sizeDelta_Sss < hp_rect.fillAmount) //데미지 받은 경우
        {
            hp_rect.fillAmount -= Time.deltaTime * speed;
        }
    }

    public void Fill_img(float Hp, float Max_Hp)
    {
        float ft = Hp / Max_Hp;

        if (ft > 0)
        {
            if (!hp_canvas.gameObject.activeSelf)
            {
                hp_rect.fillAmount = 1;
                hp_canvas.SetActive(true);
            }
            
            hp_tmp.text = Hp + " / " + Max_Hp + "(" + (int)(ft * 100) + "%)";

            if (sizeDelta_Sss < hp_rect.fillAmount)
            {
                hp_rect.fillAmount = ft;
            }

            sizeDelta_Sss = ft;
        }
        else
        {
            hp_canvas.SetActive(false);
        }
    }
}
