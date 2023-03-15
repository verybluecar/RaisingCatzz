using UnityEngine;
using TMPro;

public class CatCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private float moneyPerCatPerSecond = 1f;

    private int catCount;
    private float moneyAmount;
    private float timeSinceLastUpdate;

    private void Start()
    {
        timeSinceLastUpdate = 0f;
        moneyAmount = 0f;
    }

    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= 1f)
        {
            catCount = GameObject.FindGameObjectsWithTag("Cat").Length;
            moneyAmount += (catCount * moneyPerCatPerSecond);
            moneyText.text = "$" + Mathf.Round(moneyAmount).ToString();
            timeSinceLastUpdate = 0f;
        }
    }
}



