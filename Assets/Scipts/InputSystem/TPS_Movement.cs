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




    Animator PlayerAnimator;
    Rigidbody rbRef;

    Vector2 InputVector;
    Vector3 MoveDirection;




    // animator hashes
    public readonly int MovementXHash = Animator.StringToHash("MovementX");
    public readonly int MovementYHash = Animator.StringToHash("MovementY");
    public readonly int RunHash = Animator.StringToHash("Running");
    public readonly int JumpHash = Animator.StringToHash("Jumping");





    void Start()
    {

        PlayerAnimator = GetComponent<Animator>();
        rbRef = GetComponent<Rigidbody>();

        WalkSpeed = 3.0f;
        RunSpeed = 5.0f;
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





        // determine walking or running 
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

        // make movement vector
        Vector3 movement = MoveDirection * (CurrentSpeed * Time.deltaTime);

        // apply movement
        transform.position += movement;
        
    }




    // wasd input
    public void OnMove(InputValue input)
    {
        print(input.Get());

        // get input vector from input value
        InputVector = input.Get<Vector2>();



        // set animation for animator
        PlayerAnimator.SetFloat(MovementXHash, InputVector.x);
        PlayerAnimator.SetFloat(MovementYHash, InputVector.y);


    }





    // sprint input
    public void OnSprint(InputValue input)
    {
        if (input.Get().ToString()=="1")
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;;
        }
    }

}