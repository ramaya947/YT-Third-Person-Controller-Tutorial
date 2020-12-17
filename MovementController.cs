using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 15f, jumpHeight = 2f, fallMultiplier = 2.5f;
    public Camera camera;
    public GameObject groundCheck;

    private Vector3 inputs;
    private Rigidbody rb;

    // Start is called before the first frame updat
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs = Vector3.zero;
        inputs.x = Input.GetAxisRaw("Horizontal");
        inputs.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            jump();
    }

    private void jump()
    {
        if (groundCheck.GetComponent<GroundCheckController>().getIsGrounded())
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            groundCheck.GetComponent<GroundCheckController>().setIsGrounded(false);
        }
    }

    void FixedUpdate()
    {
        if (inputs != Vector3.zero)
            move();

        if (!groundCheck.GetComponent<GroundCheckController>().getIsGrounded())
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    private void move()
    {
        //Movement
        var cf = camera.transform.forward;
        cf.y = 0f;
        cf.Normalize();

        var cr = camera.transform.right;
        cr.y = 0f;
        cr.Normalize();

        var move = inputs.x * cr + inputs.z * cf;
        transform.position += move * speed * Time.fixedDeltaTime;
        //Movement

        //Rotation
        transform.LookAt(transform.position + move);
        //Rotation
    }
}
