using UnityEngine;
using TMPro;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public TextMeshProUGUI bowlCountText;
    public int costPerItem = 1;
    public Transform handTransform;

    public void SpawnItem()
    {
        int currentCount = int.Parse(bowlCountText.text);
        if (currentCount >= costPerItem)
        {
            GameObject item = Instantiate(itemPrefab, handTransform.position, handTransform.rotation);
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.SetParent(handTransform);
            currentCount -= costPerItem;
            bowlCountText.text = currentCount.ToString();
        }
        else
        {
            Debug.Log("Not enough bowls to spawn an item!");
        }
    }

    public void OnButtonClick()
    {
        SpawnItem();
    }
}





