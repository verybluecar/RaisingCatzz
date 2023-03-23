using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float secondsPerMinute = 1.0f;
    public Text clockText;

    private float _startTime;

    void Start()
    {
        _startTime = Time.time;
        InvokeRepeating("UpdateClock", 0.0f, secondsPerMinute);
    }

    void Update()
    {
        float timeOfDay = CalculateTimeOfDay();
        UpdateLighting(timeOfDay);
    }

    void UpdateLighting(float timeOfDay)
    {
        float sunAngle = timeOfDay * 360.0f;
        sun.transform.localRotation = Quaternion.Euler(sunAngle, 0.0f, 0.0f);
    }

    float CalculateTimeOfDay()
    {
        float timeInSeconds = Time.time - _startTime;
        float timeOfDay = timeInSeconds / (24.0f * 60.0f); // convert to fraction of day
        return timeOfDay;
    }

    void UpdateClock()
    {
        float timeInSeconds = Time.time - _startTime;
        int hours = Mathf.FloorToInt(timeInSeconds / 60.0f / 60.0f);
        int minutes = Mathf.FloorToInt((timeInSeconds / 60.0f) % 60.0f);
        clockText.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }
}

