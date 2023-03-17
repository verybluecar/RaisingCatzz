using UnityEngine;

public class CatNeedsController : MonoBehaviour
{
    [SerializeField] private CatController catController; // the CatController script attached to the cat
    [SerializeField] private float needsInterval = 10f; // the interval at which the cat needs to satisfy its needs
    [SerializeField] private Transform foodLocation; // the empty object representing the location of the food bowl
    [SerializeField] private Animator catAnimator; // the Animator component attached to the cat
    [SerializeField] private bool isHungry = false; // a flag to indicate whether the cat is hungry
    [SerializeField] private bool needsToUseBathroom = false; // a flag to indicate whether the cat needs to use the bathroom

    private float timer; // a timer to keep track of when the cat needs to satisfy its needs

    private void Start()
    {
        timer = needsInterval;
    }

    private void Update()
    {
        // decrement the timer
        timer -= Time.deltaTime;

        // if the timer has elapsed and the cat needs to satisfy its needs, set a new destination for the cat
        if (timer <= 0f)
        {
            if (needsToUseBathroom)
            {
                catAnimator.SetTrigger("UseBathroom"); // play the "UseBathroom" animation
                catController.SetDestination(transform.position); // stay still to use the bathroom
            }

            if (isHungry)
            {
                // Check if the cat is near the food bowl
                if (Vector3.Distance(transform.position, foodLocation.position) < 1f)
                {
                    catAnimator.SetTrigger("EatFood"); // play the "EatFood" animation
                    catController.SetDestination(transform.position); // stay still to eat
                }
                else
                {
                    catController.SetDestination(foodLocation.position); // go to the food bowl
                }
            }

            // reset the timer
            timer = needsInterval;
        }
    }

    public void SetHungry(bool isHungry)
    {
        this.isHungry = isHungry;

        if (isHungry)
        {
            needsToUseBathroom = false; // set needsToUseBathroom to false to avoid conflicts
        }
    }

    public void SetNeedsToUseBathroom(bool needsToUseBathroom)
    {
        this.needsToUseBathroom = needsToUseBathroom;

        if (needsToUseBathroom)
        {
            isHungry = false; // set isHungry to false to avoid conflicts
        }
    }
}






