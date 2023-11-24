using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class SleepMode : MonoBehaviour
{
    [SerializeField] GameObject SleepMode_Canvas; 
    [SerializeField] Animator Ice;

    public void OnClick_SleepModeON()
    {
        SleepMode_Canvas.SetActive(true);
        Camera.main.orthographicSize = 5f;
        Ice.Play("Ice Elemental Idle");
    }

    public void Jump()
    {
        Ice.Play("Ice Elemental Jump");
    }

}
