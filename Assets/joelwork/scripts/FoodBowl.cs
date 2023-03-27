using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : MonoBehaviour
{
    public GameObject fullOfFood;
    public GameObject ALmostEmptyFood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cat"))
        {
            foodeating();
        }
    }

    public void foodeating()
    {
        fullOfFood.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(foodEatingTimer());
        

    }


    IEnumerator foodEatingTimer()
    {
        yield return new WaitForSeconds(2f);
        ALmostEmptyFood.GetComponent<MeshRenderer>().enabled = false;
    }
}
