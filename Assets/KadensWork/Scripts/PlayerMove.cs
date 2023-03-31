using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;
   

    Vector3 veclocity;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
       
    }
}
