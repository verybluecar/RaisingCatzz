using UnityEngine;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public int amount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddAmount(int value)
    {
        amount += value;
        UpdateText();
    }

    private void UpdateText()
    {
        if (textMesh != null)
        {
            textMesh.text = amount.ToString();
        }
    }
}






