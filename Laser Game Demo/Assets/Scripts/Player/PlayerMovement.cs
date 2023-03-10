using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody rb;

    [SerializeField] private int speed = 5;
    [SerializeField] private GameObject gun;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();   
    }

    private void FixedUpdate()
    {
        //Movement
        Vector3 movementVector = new Vector3(movementInput.x, 0, movementInput.y);
        movementVector = movementVector * speed * Time.deltaTime;
        rb.MovePosition( transform.position + movementVector );

        //Look towards mouse
        Ray mouseRay = Camera.main.ScreenPointToRay( Mouse.current.position.ReadValue() );
        RaycastHit hitData;
        if (Physics.Raycast(mouseRay, out hitData, 100))
        {
            transform.LookAt( new Vector3(hitData.point.x, transform.position.y, hitData.point.z) );
        }
    }
}
