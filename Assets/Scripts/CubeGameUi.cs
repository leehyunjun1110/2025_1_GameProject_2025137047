using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class CubeGameUi : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Timer;

    private void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "���� �ð� : " + Timer.ToString("0.00");
    }
}
