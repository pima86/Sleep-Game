using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sleep_Ice : MonoBehaviour
{
    [SerializeField] GameObject SleepMode_Canvas;

    public void SleepModeON()
    {
        SleepMode_Canvas.SetActive(false);
        Camera.main.orthographicSize = 4f;
    }
}
