using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statisticsText;
    [SerializeField] private TextMeshProUGUI moneyText;

    private float timeAlive = 0f;

    private void Update()
    {
        timeAlive += Time.deltaTime;

        int minutesAlive = Mathf.FloorToInt(timeAlive / 60f);
        int secondsAlive = Mathf.FloorToInt(timeAlive % 60f);

        statisticsText.text = " " + minutesAlive.ToString("D2") + ":" + secondsAlive.ToString("D2");

        int moneyEarned = Mathf.FloorToInt(timeAlive / 45f);
        moneyText.text = "Earned: " + moneyEarned.ToString();
    }
}


