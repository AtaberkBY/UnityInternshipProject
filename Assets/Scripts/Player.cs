using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movementSpeed = 5;
    public bool isMoving;
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 direction;
    public bool isCollected;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //down- sadece basýldýðýnda çalýþýr, basýlý tutmak bir iþe yaramaz
        // Input.GetKey(KeyCode.Space);
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.back;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;



        if (Input.GetKey(KeyCode.LeftShift)) movementSpeed = 20f;
        else movementSpeed = 5;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 8f, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        Vector3 moveVelocity = direction.normalized * movementSpeed;
        moveVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = moveVelocity;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("jumpPad"))
        {
            //gameObject.SetActive(false);
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            print("Tebrikler");
            isCollected = true;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
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
