using UnityEngine;

public class BuyItem : MonoBehaviour
{
    [SerializeField] private int cost = 10;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform spawnLocation;

    public void Purchase()
    {
        CatCounter catCounter = FindObjectOfType<CatCounter>();

        if (catCounter != null && catCounter.MoneyAmount >= cost)
        {
            catCounter.SubtractMoney(cost);
            Debug.Log("Item purchased!");

            if (itemPrefab != null && spawnLocation != null)
            {
                Instantiate(itemPrefab, spawnLocation.position, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("Insufficient funds!");
        }
    }
}





