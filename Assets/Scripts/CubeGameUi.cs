using UnityEngine;
using TMPro;

public class CubeGameUi : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Timer;

    private void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "생존 시간 : " + Timer.ToString("0.00");
    }
}
