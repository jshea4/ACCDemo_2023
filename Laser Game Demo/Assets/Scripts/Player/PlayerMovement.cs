using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody rb;

    [SerializeField] private int speed = 5;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the rigidbody attached to this GameObject
    }
    
    //OnMove will be called when we press (or release) WASD
    private void OnMove(InputValue value)
    {
        //This input action returns a Vector2, which is an (x, y) pair.
        //'y' is considered forward, equivalent to z in 3D space
        // W: (0, 1)
        // A: (-1, 0)
        // S: (0, -1)
        // D: (1, 0) 
        movementInput = value.Get<Vector2>();   
    }
    
    //FixedUpdate is like Update, but in sync with the physics engine. Use when dealing with physics
    private void FixedUpdate()
    {

        //--MOVEMENT--
        //Convert the 2D movementInput into a 3D vector. 
        //Remember, we're using the y value of the Vector2 as "forward", so it's z in a Vector3.
        Vector3 movementVector = new Vector3(movementInput.x, 0, movementInput.y);
        
        //We need to multiply by Time.deltaTime to make our movement framerate independent
        movementVector = movementVector * speed * Time.deltaTime;
        
        //Move the player
        rb.MovePosition( transform.position + movementVector );


        //--ROTATE--
        //Create a ray that shoots from the mouse position into the world
        Ray mouseRay = Camera.main.ScreenPointToRay( Mouse.current.position.ReadValue() );
        
        //If the ray hits anything, Physics.Raycast will return true, and we'll go into the if statement
        //The data from the raycast will be stored in the hitData variable
        RaycastHit hitData;
        if (Physics.Raycast(mouseRay, out hitData, 100))
        {
            //Make the player look at the point the mouse hit
            transform.LookAt( new Vector3(hitData.point.x, transform.position.y, hitData.point.z) );
        }
    }
}
