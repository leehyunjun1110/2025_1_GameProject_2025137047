using UnityEngine;
using TMPro;

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
