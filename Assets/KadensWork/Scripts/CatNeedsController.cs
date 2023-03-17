using UnityEngine;

public class CatNeedsController : MonoBehaviour
{
    [SerializeField] private CatController catController; // the CatController script attached to the cat
    [SerializeField] private float needsInterval = 10f; // the interval at which the cat needs to satisfy its needs
    [SerializeField] private Transform foodLocation; // the empty object representing the location of the food bowl
    [SerializeField] private Transform bathroomLocation; // the empty object representing the location of the litter box or bathroom
    [SerializeField] private Animator catAnimator; // the Animator component attached to the cat
    [SerializeField] private bool needsActive = true; // a flag to indicate whether the needs are active
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

        // if the timer has elapsed and the needs are active, set a new destination for the cat
        if (timer <= 0f && needsActive)
        {
            if (needsToUseBathroom)
            {
                catAnimator.SetTrigger("UseBathroom"); // play the "UseBathroom" animation
                catController.SetDestination(bathroomLocation.position);
            }

            if (isHungry)
            {
                catAnimator.SetTrigger("EatFood"); // play the "EatFood" animation
                catController.SetDestination(foodLocation.position);
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

    public void SetNeedsActive(bool isActive)
    {
        needsActive = isActive;
    }
}





