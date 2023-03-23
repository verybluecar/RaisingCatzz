using UnityEngine;
using TMPro;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public TextMeshProUGUI bowlCountText;
    public int costPerItem = 1;
    public Transform handTransform;
    public Transform cameraTransform;

    private bool isBowlSpawned = false;
    private GameObject spawnedItem;

    private IEnumerator CheckForChildObject()
    {
        while (true)
        {
            if (handTransform.childCount == 0)
            {
                // Allow spawning of another item
                isBowlSpawned = false;
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void Start()
    {
        // Start the coroutine to check for child object every second
        StartCoroutine(CheckForChildObject());
    }

    public void SpawnItem()
    {
        int currentCount = int.Parse(bowlCountText.text);
        isBowlSpawned = false; // reset the flag

        if (currentCount >= costPerItem)
        {
            // Check if there is a child object in the handTransform
            if (handTransform.childCount > 0)
            {
                Debug.Log("There is already a spawned item in hand!");
                return;
            }

            spawnedItem = Instantiate(itemPrefab, handTransform.position, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().isKinematic = true;
            spawnedItem.transform.SetParent(handTransform);
            currentCount -= costPerItem;
            bowlCountText.text = currentCount.ToString();
            isBowlSpawned = true;
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

    // Call this function when the spawned bowl is picked up
    public void BowlPickedUp()
    {
        Transform spawnedObjectTransform = handTransform.GetChild(0);
        spawnedObjectTransform.SetParent(null);
        spawnedObjectTransform.GetComponent<Rigidbody>().isKinematic = false;
        isBowlSpawned = false;
    }

    public void PlaceItemOnGround()
    {
        if (isBowlSpawned)
        {
            Vector3 rayOrigin = cameraTransform.position;
            Vector3 rayDirection = cameraTransform.forward;
            if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo))
            {
                spawnedItem.transform.position = hitInfo.point;
                spawnedItem.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                spawnedItem.GetComponent<Rigidbody>().isKinematic = false;
                spawnedItem = null;
                isBowlSpawned = false;
            }
        }
        else
        {
            Debug.Log("No spawned item in hand to place on ground!");
        }
    }
}










