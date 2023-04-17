using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEat : MonoBehaviour
{
    public AudioClip eating;
    private AudioSource cateat;

    public int maxHunger = 100;
    public int hunger = 100;

    public delegate void HungerThresholdReached(int threshold);
    public event HungerThresholdReached OnHungerThresholdReached;

    public CatRoam catRoam; // Reference to the CatRoam script

    // Start is called before the first frame update
    void Start()
    {
        cateat = GetComponent<AudioSource>();
        cateat.clip = eating;

        InvokeRepeating("DecreaseHunger", 1f, 1f); // Call DecreaseHunger() every second
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger <= 0)
        {
            Die();
        }

        // Check if hunger level has reached certain thresholds
        if (OnHungerThresholdReached != null)
        {
            if (hunger == 50)
            {
                OnHungerThresholdReached(50);
                catRoam.hungry = true; // Activate the hungry boolean in the CatRoam script
            }
            else if (hunger == 25)
            {
                OnHungerThresholdReached(25);
                catRoam.hungry = true; // Activate the hungry boolean in the CatRoam script
            }
            else if (hunger == 10)
            {
                OnHungerThresholdReached(10);
                catRoam.hungry = true; // Activate the hungry boolean in the CatRoam script
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CatFood"))
        {
            cateat.Play();
            hunger += 20; // Eating restores 20 hunger
            if (hunger > maxHunger)
            {
                hunger = maxHunger;
            }
        }
    }

    private void DecreaseHunger()
    {
        hunger -= 1; // Decrease hunger by 1 every second
    }

    private void Die()
    {
        Debug.Log("The cat has died of hunger!");
        Destroy(gameObject);
        // Add any death-related actions here, like disabling the script or playing a death animation
    }
}


