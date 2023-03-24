using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEat : MonoBehaviour
{
    public AudioClip eating;

    private AudioSource cateat;
    
    // Start is called before the first frame update
    void Start()
    {

        cateat = GetComponent<AudioSource>();

        cateat.clip = eating;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CatFood"))
        {
            cateat.Play();
        }
    }
}
