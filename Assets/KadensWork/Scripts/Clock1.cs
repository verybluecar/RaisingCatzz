using TMPro;
using UnityEngine;

public class Clock1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private LightingManager lightingManager;

    private void Update()
    {
        if (timeText == null || lightingManager == null)
            return;

        int hours = Mathf.FloorToInt(lightingManager.TimeOfDay);
        int minutes = Mathf.FloorToInt((lightingManager.TimeOfDay - hours) * 60);

        string hoursStr = hours.ToString().PadLeft(2, '0');
        string minutesStr = minutes.ToString().PadLeft(2, '0');

        timeText.text = hoursStr + ":" + minutesStr;
    }
}

