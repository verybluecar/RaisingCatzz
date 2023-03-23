using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    private int currentHour;
    private int currentMinute;

    void Start()
    {
        currentHour = 0;
        currentMinute = 0;
        InvokeRepeating("UpdateTime", 60.0f, 1.0f);
    }

    void UpdateTime()
    {
        currentMinute++;
        if (currentMinute >= 60)
        {
            currentMinute = 0;
            currentHour++;
            if (currentHour >= 24)
            {
                currentHour = 0;
            }
        }
        UpdateClockText();
    }

    void UpdateClockText()
    {
        string hourText = currentHour.ToString("00");
        string minuteText = currentMinute.ToString("00");
        clockText.text = hourText + ":" + minuteText;
    }
}



