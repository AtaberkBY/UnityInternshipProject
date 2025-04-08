using UnityEngine;

public class Box : MonoBehaviour
{
    private float movementSpeed = 5;
    public bool isMoving;
    private Rigidbody rb;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //down- sadece basýldýðýnda çalýþýr, basýlý tutmak bir iþe yaramaz
        // Input.GetKey(KeyCode.Space);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += movementSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += movementSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += movementSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += movementSpeed * Time.deltaTime * Vector3.right;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 20f;
        }
        else
        {
            movementSpeed = 5;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
