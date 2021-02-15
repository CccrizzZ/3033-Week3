using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPS_Movement : MonoBehaviour
{


    public float WalkSpeed;
    public float RunSpeed;
    public float JumpForce;
    
    
    
    bool isJumping;
    bool isRunning;
    float CurrentSpeed;



    Rigidbody rbRef;

    Vector2 InputVector;
    Vector3 MoveDirection;





    void Start()
    {
        rbRef = GetComponent<Rigidbody>();

        WalkSpeed = 5.0f;
        RunSpeed = 10.0f;
        JumpForce = 1.0f;

        isJumping = false;
        isRunning = false;
    }


    void Update()
    {
        // if is jumping dont move
        if(isJumping) return;
        // if no input dont move
        if(InputVector.magnitude <= 0) return;


        // determine walk or run 
        if (isRunning)
        {
            CurrentSpeed = RunSpeed;
        }
        else
        {
            CurrentSpeed = WalkSpeed;
        }

        // determine player direction
        MoveDirection = transform.forward * InputVector.y + transform.right * InputVector.x;

        Vector3 movement = MoveDirection * (CurrentSpeed * Time.deltaTime);


        // apply movement
        transform.position += movement;
        
    }



    public void OnMove(InputValue input)
    {
        print(input.Get());

        // get input vector from input value
        InputVector = input.Get<Vector2>();

        


    }
}
