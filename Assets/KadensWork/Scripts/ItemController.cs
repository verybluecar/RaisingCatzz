using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public TextMeshProUGUI BowlCount;
    public GameObject ItemPrefab;
    public Transform SpawnPoint;

    private int currentCount;

    private void Start()
    {
        currentCount = int.Parse(BowlCount.text);
    }

    public void SpawnItem()
    {
        if (currentCount > 0)
        {
            Instantiate(ItemPrefab, SpawnPoint.position, Quaternion.identity);
            currentCount--;
            BowlCount.text = currentCount.ToString();
        }
    }
}

