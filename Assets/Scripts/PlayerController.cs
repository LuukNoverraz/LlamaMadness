using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public enum MovementState 
{
    STANDING,
    MOVING,
    AERIAL
}

public class PlayerController : MonoBehaviour
{
    public MovementState currentMovementState;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Animation fovAnimation;
    private bool fovAnimPlayed = false;
    [SerializeField] private string[] inputs;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject jumpEffect;
    [SerializeField] private Animator animator;
    private Vector3 jump;
    private bool grounded;
    private GameObject newJumpEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision col) => grounded = true;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Death")
        {
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (-Input.GetAxis(inputs[1]) != 0 && grounded)
        {
            ChangeMovementState();
        }

        else 
        {
            ChangeMovementState();
        }
    }

    void ChangeMovementState()
    {
        if(-Input.GetAxis(inputs[1]) == 0 && -Input.GetAxis(inputs[2]) == 0)
        {
            currentMovementState = MovementState.STANDING;
        }
        else if(Input.GetAxis(inputs[2]) != 0)
        {
            currentMovementState = MovementState.AERIAL;
        }
        else
        {
            currentMovementState = MovementState.MOVING;
        }
        switch(currentMovementState)
        {
            case MovementState.STANDING:
                if (fovAnimPlayed)
                {
                    fovAnimation.Play("FOVShiftReverse");
                }
                fovAnimPlayed = false;
                animator.SetBool("Walking", false);
                break;
            case MovementState.AERIAL:
                animator.SetBool("Walking", false);
                break;
            case MovementState.MOVING:
                if (!fovAnimPlayed)
                {
                    fovAnimation.Play("FOVShift");
                }
                fovAnimPlayed = true;
                animator.SetBool("Walking", true);
                break;
        }
    }

    void FixedUpdate()
    {
        // Add vertical force if jump button is pressed
        if (Input.GetAxis(inputs[2]) != 0 && grounded)
        {
            grounded = false;
            rb.velocity = jump;
            newJumpEffect = Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y - 1.6f,  transform.position.z), jumpEffect.transform.rotation);
            Destroy(newJumpEffect, newJumpEffect.GetComponent<Animation>().clip.length);
        }

        // Multiply gravity when falling down, adding a weightier effect
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1.0f) * Time.deltaTime;
        }

        // Change force of jump depending on amount of time jump button is pressed
        if (rb.velocity.y > 0 && Input.GetAxis(inputs[2]) == 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1.0f) * Time.deltaTime;
        }

        // Change position and rotate player based on inputs
        transform.position += transform.forward * -Input.GetAxis(inputs[1]) * moveSpeed * Time.deltaTime;
        transform.Rotate(0.0f, Input.GetAxis(inputs[0]) * rotateSpeed * Time.deltaTime, 0.0f);
    }
}
