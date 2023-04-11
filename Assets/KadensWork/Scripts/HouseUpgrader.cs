using UnityEngine;

public class HouseUpgrader : MonoBehaviour
{
    public GameObject[] houses; // Array of house prefabs to be upgraded
    public bool upgrade = false; // Boolean flag for upgrading houses

    private int currentHouseIndex = 0; // Index of the current house prefab

    private GameObject currentHouseInstance; // Reference to the current house instance

    private void Start()
    {
        // Spawn the first house prefab
        currentHouseInstance = Instantiate(houses[currentHouseIndex], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (upgrade)
        {
            // Destroy the current house instance
            Destroy(currentHouseInstance);

            // Increment the current house index
            currentHouseIndex++;

            // If we've reached the end of the array, wrap around to the beginning
            if (currentHouseIndex >= houses.Length)
            {
                currentHouseIndex = 0;
            }

            // Spawn the next house prefab
            currentHouseInstance = Instantiate(houses[currentHouseIndex], transform.position, Quaternion.identity);

            // Reset the upgrade flag
            upgrade = false;
        }
    }
}
