using UnityEngine;

public class OpenWorldController : MonoBehaviour
{
    public float moveSpeed = 10f;
    //public float rotationSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * moveSpeed;

        // Rotation
        if (movement != Vector3.zero)
        {
            //Quaternion newRotation = Quaternion.LookRotation(movement);
            //rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
