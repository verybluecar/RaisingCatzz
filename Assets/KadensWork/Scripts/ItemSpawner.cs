using UnityEngine;
using TMPro;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public TextMeshProUGUI bowlCountText;
    public int costPerItem = 1;
    public Transform handTransform;

    private bool isBowlSpawned = false;

    public void SpawnItem()
    {
        int currentCount = int.Parse(bowlCountText.text);
        if (!isBowlSpawned && currentCount >= costPerItem)
        {
            GameObject item = Instantiate(itemPrefab, handTransform.position, handTransform.rotation);
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.SetParent(handTransform);
            currentCount -= costPerItem;
            bowlCountText.text = currentCount.ToString();
            isBowlSpawned = true;
        }
        else
        {
            Debug.Log("Not enough bowls to spawn an item or a bowl is already spawned!");
        }
    }

    public void OnButtonClick()
    {
        SpawnItem();
    }

    // Call this function when the spawned bowl is picked up
    public void BowlPickedUp()
    {
        isBowlSpawned = false;
    }
}






