using UnityEngine;
using TMPro;

public class Buy : MonoBehaviour
{
    public TextMeshProUGUI BowlCount;
    public int CostPerBowl = 10;
    private CatCounter catCounterScript;

    private void Start()
    {
        catCounterScript = FindObjectOfType<CatCounter>();
    }

    public void AddBowl()
    {
        int currentCount = int.Parse(BowlCount.text);
        if (catCounterScript.MoneyAmount >= CostPerBowl)
        {
            currentCount++;
            BowlCount.text = currentCount.ToString();
            catCounterScript.SubtractMoney(CostPerBowl);
        }
        else
        {
            Debug.Log("Not enough money to buy a bowl.");
        }
    }
}
