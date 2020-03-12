using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    private Rigidbody rb;
    [SerializeField] private string[] inputs;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject jumpEffect;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (transform.position.y <= -10.0f)
        {
            transform.position = new Vector3(0, 3.27f, 0);
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
