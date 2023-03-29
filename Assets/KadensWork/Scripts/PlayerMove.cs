using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Canvas LootBoxCanvas;
    
   

    Vector3 veclocity;
    
    // Start is called before the first frame update
    void Start()
    {
        LootBoxCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       

        // the float x and z will get the axis of your mouse
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // this will actually move the mouse 
        Vector3 move = transform.right * x + transform.forward * z;

        //this will move the character and use the speed float to control the speed
        controller.Move(move * speed * Time.deltaTime);

        

        //will move the controller down to what the gravity is from the line above 
        controller.Move(veclocity * Time.deltaTime);

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LootBoxShop"))
        {
            LootBoxCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("working e canvas thing");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LootBoxShop"))
        {
            LootBoxCanvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
