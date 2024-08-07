using UnityEngine;

public class OpenWorldController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 15;
    public float rotationSpeed = 10f;
    public float moveSpeed;
    private Rigidbody rb;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Key - Horizontal");
        float moveVertical = Input.GetAxis("Key - Vertical");
        float moveUp = Input.GetAxis("Key - Jump");

        Vector3 movement = new(moveHorizontal, moveUp, moveVertical);

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = sprintSpeed;
        else
            moveSpeed = walkSpeed;

        //Debug.Log($"I'm at speed: {moveSpeed}");

        // Set the velocity of the Rigidbody
        rb.velocity = movement * moveSpeed;

        // Set the animator Speed parameter based on current velocity magnitude
        animator.SetFloat("Speed", rb.velocity.magnitude);

        // Output debug information to ensure correct speed setting
        Debug.Log($"Velocity Magnitude: {rb.velocity.magnitude}, Speed Parameter: {animator.GetFloat("Speed")}");

        // Rotation
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
