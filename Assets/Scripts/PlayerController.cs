using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

#pragma warning disable 0649

public enum MovementState 
{
    STANDING,
    MOVING,
    AERIAL
}

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public GameController gameController;
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
    private Vector3 bouncePad;
    private bool grounded;
    private GameObject newJumpEffect;
    [SerializeField] private GameObject spit;
    private Vector3 spitPosition;
    private Vector3 spitHitVelocity;
    [SerializeField] private float spitSpeed;
    private bool spitShot = false;
    private GameObject winScreen;
    private bool gameOver = false;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        winScreen = GameObject.FindWithTag("Win Screen");
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        spitHitVelocity = new Vector3(0.0f, 0.0f, -15.0f);
        bouncePad = new Vector3(0.0f, 22.0f, 0.0f);
    }

    void OnCollisionEnter(Collision col) => grounded = true;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Death")
        {
            if (gameController.stage == 2)
            {
                if (gameController.passedCheckpoints <= 18)
                {
                    transform.position = gameController.dreamyCheckpointLocations[(gameController.passedCheckpoints)];
                }
                else 
                {
                transform.position = new Vector3(0.0f, 3.0f, 0.0f);
                }
            }
            if (gameController.stage == 3)
            {
                if (gameController.passedCheckpoints <= 23)
                {
                    transform.position = gameController.floatyCheckpointLocations[(gameController.passedCheckpoints)];
                }
                else 
                {
                transform.position = new Vector3(0.0f, 3.0f, 0.0f);
                }
            }
        }

        if (col.tag == "Bounce")
        {
            rb.velocity = bouncePad;
        }

        if (col.tag == "Checkpoint")
        {
            gameController.CheckpointPassed();
            Destroy(col.gameObject);
        }

        if (col.tag == "Spit")
        {
            rb.AddForce(transform.position + transform.forward * 300);
            Destroy(col.gameObject);
        }
    }

    void Update()
    {
        spitPosition = new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z);
        
        if (Input.GetKeyDown(KeyCode.Escape) && gameOver)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetAxis(inputs[3]) != 0 && !spitShot)
        {
            spitShot = true;
            GameObject newSpit = Instantiate(spit, spitPosition, transform.rotation);
            newSpit.GetComponent<Rigidbody>().AddForce(-transform.forward * (spitSpeed * 10));
            StartCoroutine(SpitTimer());
        }

        if (gameController.passedCheckpoints == (gameController.stageCheckpointAmounts) && !gameOver)
        {
            Time.timeScale = 0;
            winScreen.GetComponent<RectTransform>().position = Vector3.zero;
            gameOver = true;
        }
    }

    IEnumerator SpitTimer()
    {
        yield return new WaitForSeconds(2);
        spitShot = false;
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

        if (-Input.GetAxis(inputs[1]) != 0 && grounded)
        {
            ChangeMovementState();
        }

        else 
        {
            ChangeMovementState();
        }

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
