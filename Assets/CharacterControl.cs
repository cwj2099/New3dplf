//Script STolen from JanetGilbert
//modified so the jump is more "dynamic"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // Cache
    CharacterController characterController;
    public Animator animator;

    // Set in editor
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float raiseTime = 1.0f;//the max time for no grav and constance jump
    [SerializeField] private float gravity = 20.0f;

    // Controls
    private Vector3 moveDirection = Vector3.zero;
    private float xMove;
    private float yMove;
    private bool jump;
    private float riseCounter = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        //animator.SetBool("Grounded", characterController.isGrounded);

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(xMove, 0.0f, yMove);
            moveDirection *= speed;


            //animator.SetFloat("MoveSpeed", moveDirection.magnitude);

            if (jump)
            {
                riseCounter = raiseTime;
               // moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            //able to change direction in air
            moveDirection = new Vector3(xMove*speed, moveDirection.y, yMove*speed);
        }

        // Face in direction of movement.
        if (moveDirection.magnitude > float.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x,0, moveDirection.z) );
        }

        if (jump&&riseCounter>0f)
        {
            riseCounter -= Time.fixedDeltaTime;
            moveDirection.y = jumpSpeed;
        }
        else
        {
            riseCounter = 0f;
            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.fixedDeltaTime;
        }
        
        // Move the controller
        characterController.Move(moveDirection * Time.fixedDeltaTime);

    }

    // Player input should be registered in Update() because FixedUpdate may not update every frame.
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        jump = Input.GetButton("Jump");
    }
}
