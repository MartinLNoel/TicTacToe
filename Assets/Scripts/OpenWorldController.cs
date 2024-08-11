using UnityEngine;

public class OpenWorldController : MonoBehaviour
{
    private readonly float walkSpeed = 4f;
    private readonly float sprintSpeed = 8;
    private readonly float rotationSpeed = 10f;

    public float MoveSpeed { get; set; }
    private Rigidbody rb;
    private Animator animator;
    public bool animatorJump;


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

        Vector3 movement = new(moveHorizontal, 0f, moveVertical);

        //Animation for jump(glide)
        if (Input.GetKeyDown(KeyCode.Space) && animatorJump == false)
        {
            animator.SetBool("Jump", true);
            animatorJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && animatorJump == true)
        {
            animator.SetBool("Jump", false);
            animatorJump = false;
        }

        //Functionality and animation of sprint, walk, and idle
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = sprintSpeed;
            animator.SetBool("Sprint", true);
            animator.SetBool("Walk", false);
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && movement != new Vector3(0f,0f,0f))
        {
            MoveSpeed = walkSpeed;
            animator.SetBool("Sprint", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Sprint", false);
            animator.SetBool("Walk", false);
        }

        // Set the velocity of the Rigidbody
        rb.velocity = movement * MoveSpeed;
        // Set the animator Speed parameter based on current velocity magnitude
        animator.SetFloat("Speed", rb.velocity.magnitude);

        // Output debug information to ensure correct speed setting
        //Debug.Log($"Velocity Magnitude: {rb.velocity.magnitude}, Speed Parameter: {animator.GetFloat("Speed")}");

        // Rotation
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
