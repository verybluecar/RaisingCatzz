using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxShop : MonoBehaviour
{
    public Canvas LootBoxCanvas;
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
        if (other.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            LootBoxCanvas.enabled = true;
        }

    }
}
