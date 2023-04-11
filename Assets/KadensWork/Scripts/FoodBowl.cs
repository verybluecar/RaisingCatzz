using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : MonoBehaviour
{
    public int foodAmount;

    public void AddFood(int amount)
    {
        foodAmount += amount;
        Debug.Log("Added " + amount + " food to the bowl. Total food: " + foodAmount);
    }

    public bool TakeFood(int amount)
    {
        if (foodAmount >= amount)
        {
            foodAmount -= amount;
            Debug.Log("Took " + amount + " food from the bowl. Total food: " + foodAmount);
            return true;
        }
        else
        {
            Debug.Log("Not enough food in the bowl.");
            return false;
        }
    }
}
