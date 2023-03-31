using UnityEngine;

public class GrowUp : MonoBehaviour
{
    public GameObject smallish; // reference to the smallish object
    public GameObject medium; // reference to the medium object
    public GameObject large; // reference to the large object
    public GameObject xLarge; // reference to the xLarge object
    public float growthInterval = 5f; // time interval between each growth

    private GameObject currentSize; // reference to the current size of the object

    void Start()
    {
        // Set the initial size of the object to smallish
        currentSize = smallish;

        // Set the initial scale of the object to smallish
        transform.localScale = smallish.transform.localScale;

        // Start the growth loop
        InvokeRepeating("Grow", growthInterval, growthInterval);
    }

    void Grow()
    {
        // Check if the current size is not xLarge
        if (currentSize != xLarge)
        {
            // Get the next size object
            GameObject nextSize = null;

            if (currentSize == smallish)
            {
                nextSize = medium;
            }
            else if (currentSize == medium)
            {
                nextSize = large;
            }
            else if (currentSize == large)
            {
                nextSize = xLarge;
            }

            // Change the current size to the next size
            currentSize = nextSize;

            // Set the new size for the object
            Instantiate(currentSize, transform.position, transform.rotation, transform);

            // Destroy the old size object
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}



