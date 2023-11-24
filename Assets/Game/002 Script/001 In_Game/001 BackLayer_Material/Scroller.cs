using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public static Scroller Inst { get; private set; }
    void Awake() => Inst = this;

    [SerializeField] MeshRenderer[] m_Renderer;
    [SerializeField] float[] speed;

    public bool isMove;

    void Update()
    {
        if (isMove && Player_Char.Inst.anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Dash"))
        {
            for (int i = 0; i < m_Renderer.Length; i++)
                m_Renderer[i].material.mainTextureOffset += new Vector2(Time.deltaTime * speed[i], 0);
        }
        else
        {
            m_Renderer[4].material.mainTextureOffset += new Vector2(Time.deltaTime * 0.01f, 0);
            m_Renderer[7].material.mainTextureOffset += new Vector2(Time.deltaTime * 0.005f, 0);
        }
    }
}
