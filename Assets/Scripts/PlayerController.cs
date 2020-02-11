using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string[] inputs;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private Vector3 jump;
    private bool grounded;
    [SerializeField] private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision col) => grounded = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && grounded)
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
        transform.Translate(Input.GetAxis(inputs[0]) * speed * Time.deltaTime, 0, Input.GetAxis(inputs[1]) * speed * Time.deltaTime);
    }
}
