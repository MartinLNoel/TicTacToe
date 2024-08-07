using UnityEngine;

public class OpenWorldController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Key - Horizontal");
        float moveVertical = Input.GetAxis("Key - Vertical");
        float moveUp = Input.GetAxis("Key - Jump");

        Vector3 movement = new(moveHorizontal, moveUp, moveVertical);


        /*do
        {
            //moveSpeed = 15f;
            Debug.Log($"1{moveSpeed}");

        } while (Input.GetKeyDown(KeyCode.LeftShift));
        */
        if (Input.GetKeyDown(KeyCode.LeftShift))
            moveSpeed = 15f;

        Debug.Log(moveSpeed);

        rb.velocity = movement * moveSpeed;

        // Rotation
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
