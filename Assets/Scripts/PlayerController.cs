using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private string[] inputs;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private Vector3 jump;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision col) => grounded = true;

    void Update()
    {
        if (Input.GetAxis(inputs[2]) != 0 && grounded)
        {
            grounded = false;
            rb.velocity = jump;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void FixedUpdate()
    {
        // float moveHorizontal = -Input.GetAxisRaw("LeftJoyStickHorizontal");
        // float moveVertical = Input.GetAxisRaw("LeftJoyStickVertical");
        transform.position += transform.forward * -Input.GetAxis(inputs[1]) * moveSpeed * Time.deltaTime;
        // Input.GetAxis(inputs[1]) * speed * Time.deltaTime
        transform.Rotate(0.0f, Input.GetAxis(inputs[0]) * rotateSpeed * Time.deltaTime, 0.0f);
    }
}
