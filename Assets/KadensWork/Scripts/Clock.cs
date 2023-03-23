using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dayText;
    public float hourPerRealSecond = 1.0f / 60.0f; // One hour per real-life minute
    public bool startOnAwake = true;

    private float _hours;
    private float _minutes;
    private int _days;

    private void Awake()
    {
        if (startOnAwake)
        {
            StartClock();
        }
    }

    private void StartClock()
    {
        float currentTime = Time.time;
        _hours = (currentTime / 60.0f) % 24.0f; // Current time in hours
        _minutes = (currentTime % 60.0f); // Current time in minutes
        _days = 0;
    }

    private void Update()
    {
        // Add time based on real-life seconds passed
        float realSecondsPassed = Time.deltaTime;
        float gameSecondsPassed = realSecondsPassed / hourPerRealSecond / 60.0f;
        AddTime(gameSecondsPassed);

        // Update time text
        timeText.text = string.Format("{0:00}:{1:00}", (int)_hours, (int)_minutes);

        // Update day text
        dayText.text = string.Format("Day {0}", _days);
    }

    private void AddTime(float gameSeconds)
    {
        _minutes += gameSeconds;
        if (_minutes >= 60.0f)
        {
            _hours += Mathf.Floor(_minutes / 60.0f);
            _minutes %= 60.0f;

            if (_hours >= 24.0f)
            {
                _days += Mathf.FloorToInt(_hours / 24.0f);
                _hours %= 24.0f;
            }
        }
    }
}




