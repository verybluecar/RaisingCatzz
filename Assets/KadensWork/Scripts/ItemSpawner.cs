using UnityEngine;
using TMPro;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public TextMeshProUGUI bowlCountText;
    public int costPerItem = 1;
    public Transform spawnPoint;

    public void SpawnItem()
    {
        int currentCount = int.Parse(bowlCountText.text);
        if (currentCount >= costPerItem)
        {
            Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            currentCount -= costPerItem;
            bowlCountText.text = currentCount.ToString();
        }
        else
        {
            Debug.Log("Not enough bowls to spawn an item!");
        }
    }
}
